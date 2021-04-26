using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarcraftBuildManager
{
    public partial class BuildRunner : Form
    {
        //Calling starting variables
        MainMethods mainMethods;
        MainVariables mainVariables;
        BuildWindow buildWindow;
        int listWalker = 0;
        List<int> prefabTimestampList;
        List<string> prefabNameList;
        List<int> prefabIndexList;
        List<int> prefabNumberList;

        //splitting the strings from the safe file (aka the ones currently used) up, putting them in their seperate lists, and putting them into the timeline
        public BuildRunner(MainMethods givenMainMethods, MainVariables givenMainVariables, BuildWindow givenBuildWindow)
        {
            InitializeComponent();
            mainMethods = givenMainMethods;
            mainVariables = givenMainVariables;
            buildWindow = givenBuildWindow;
            this.BackgroundImage = mainVariables.BuildRunner_BackgroundBM;
            picBRunnerStart.Image = mainVariables.BuildRunner_StartBM;
            picBArrowLeft.Image = mainVariables.BuildRunner_ArrowLeftBM;
            picBArrowRight.Image = mainVariables.BuildRunner_ArrowRightBM;

            prefabTimestampList = new List<int> { };
            prefabNameList = new List<string> { };
            prefabIndexList = new List<int> { };
            prefabNumberList = new List<int> { };

            picBArrowLeft.Enabled = false;

            foreach(string currentString in buildWindow.Safe_List)
            {
                string[] currentArray = currentString.Split('_');
                prefabTimestampList.Add(Convert.ToInt32(currentArray[0]));
                prefabNameList.Add(currentArray[1]);
                prefabIndexList.Add(Convert.ToInt32(currentArray[2]));
                prefabNumberList.Add(Convert.ToInt32(currentArray[3]));
            }
            Update_Timeline(0);
        }

        private void picBRunnerStart_Click(object sender, EventArgs e)
        {

        }
        
        //Next Item in the list
        private void picBArrowRight_Click(object sender, EventArgs e)
        {
            Update_Timeline(1);
        }

        //Previous item in the list
        private void picBArrowLeft_Click(object sender, EventArgs e)
        {
            Update_Timeline(-1);
        }

        //The previous 3 items in the list, the item now, and the next 3 items
        private void Update_Timeline(int listMover)
        {
            listWalker += listMover;
            PictureBox pictureBox = null;
            int secondaryCounter;
            Label label = null;

            if (listWalker < 1)
            { listWalker = 0; picBArrowLeft.Enabled = false; picBArrowRight.Enabled = true; }
            else if(listWalker >= buildWindow.Safe_List.Count -1)
            { listWalker = buildWindow.Safe_List.Count - 1; picBArrowRight.Enabled = false; picBArrowLeft.Enabled = true; }
            else
            { picBArrowRight.Enabled = true;picBArrowLeft.Enabled = true; }
            
            for(int i = 0; i < 7; i++)
            {
                secondaryCounter = 0;
                switch(i)
                {
                    case 0:
                        pictureBox = picBBuildNow;
                        label = lblNow;
                        break;
                    case 1:
                        pictureBox = picBPreviousFirst;
                        secondaryCounter--;
                        label = lblPreviousFirst;
                        break;
                    case 2:
                        pictureBox = picBPreviousMid;
                        secondaryCounter -= 2;
                        label = lblPreviousMid;
                        break;
                    case 3:
                        pictureBox = picBPreviousLast;
                        secondaryCounter -= 3;
                        label = lblPreviousLast;
                        break;
                    case 4:
                        pictureBox = picBNextFirst;
                        secondaryCounter++;
                        label = lblNextFirst;
                        break;
                    case 5:
                        pictureBox = picBNextMid;
                        secondaryCounter += 2;
                        label = lblNextMid;
                        break;
                    case 6:
                        pictureBox = picBNextLast;
                        secondaryCounter += 3;
                        label = lblNextLast;
                        break;
                }
                int validifyWalker = listWalker + secondaryCounter;

                if (validifyWalker < 0)
                {
                    pictureBox.Image = null;
                    label.Text = "";
                }
                else if(validifyWalker > buildWindow.Safe_List.Count -1)
                {
                    pictureBox.Image = null;
                    label.Text = "";
                }
                else
                {
                    Prefab foundPrefab = Prefab_Finder(prefabNameList[validifyWalker], prefabIndexList[validifyWalker]);                    
                    pictureBox.Image = foundPrefab.Icon;
                    label.Text = prefabTimestampList[validifyWalker].ToString();
                }
            }
        }

        private Prefab Prefab_Finder(string arrayString, int index)
        {
            switch(arrayString)
            {
                case "building":
                    return buildWindow.Building_Array[index];

                case "unit":
                    return buildWindow.Unit_Array[index];

                case "upgrade":
                    return buildWindow.Upgrade_Array[index];
            }
            return null;
        }
    }
}
