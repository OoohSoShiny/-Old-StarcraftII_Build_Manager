using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StarcraftBuildManager
{
    public partial class LoadingScreen : Form
    {
        MainVariables mainVariables;
        StartWindow mainMenu;
        MainFrame mainFrame;
        List<string> Safe_List;
        public LoadingScreen(MainVariables givenMainVariables, StartWindow givenMainMenu, MainFrame givenMainFrame)
        {
            mainVariables = givenMainVariables;
            mainMenu = givenMainMenu;
            mainFrame = givenMainFrame;
            this.BackgroundImage = mainVariables.Loading_Area_Background;
            InitializeComponent();
            picbExit.Image = mainVariables.BuildingArea_UiCloseBM;
            picBBackToMenu.Image = mainVariables.BuildingArea_BackToMenu;
            picBLoad.Image = mainVariables.Loading_Area_LoadBM;
            picBEyes.Image = mainVariables.Loading_Area_ProtossEyes;
            Safe_List = new List<string> { };
        }

        private void LoadingScreen_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void picBLoad_Click(object sender, EventArgs e)
        {
            string userInput = txtLoad.Text;
            string loadPath = @"SafeFiles\" + userInput + ".txt";
            string line;

            if (txtLoad.Text == "" || !File.Exists(loadPath) || txtLoad.Text == null)
            {
                MessageBox.Show("404: File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(loadPath))
                    {
                        mainVariables.Active_Race = sr.ReadLine();
                        while ((line = sr.ReadLine()) != null)
                        {
                            Safe_List.Add(line);
                        }
                    }
                    BuildWindow buildWindow = new BuildWindow(mainVariables.Active_Race, mainVariables, mainFrame, Safe_List);
                    buildWindow.Show();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void picbExit_Click(object sender, EventArgs e)
        {
            mainFrame.Close();
        }

        private void picBBackToMenu_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Close();
        }
    }
}
