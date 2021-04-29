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
    public partial class StartWindow : Form
    {
        MainVariables mainVariables;
        MainMethods mainMethods;
        StartWindow startWindow;
        BuildWindow buildWindow;
        MainFrame mainFrame;
        bool mainMenuActive = true;
        public StartWindow(MainFrame givenMainFrame)
        {
            InitializeComponent();
            mainFrame = givenMainFrame;
            mainVariables = new MainVariables();
            mainMethods = new MainMethods();
            startWindow = this;
            Initialize_MainMenu();
            givenMainFrame.Hide();
            this.Icon = mainVariables.BuildManager_Icon;
        }

        //New Build & Zerg
        private void PicbNewBuild_Click(object sender, EventArgs e)
        {
            if (mainMenuActive)
            {
                mainMenuActive = false;
                startWindow.Height = mainVariables.NewBuild_Y;
                mainMethods.Activate_Picturebox(picbBackToMainMenu);
                mainMethods.Fill_Picturebox(picbNewBuildZerg, mainVariables.NewBuild_ZergBM);
                mainMethods.Fill_Picturebox(picbLoadBuildProtoss, mainVariables.NewBuild_ProtossBM);
                mainMethods.Fill_Picturebox(picbExitManagerTerran, mainVariables.NewBuild_TerranBM);
            }
            else
            {
                buildWindow = new BuildWindow("Zerg", mainVariables, mainFrame) ;
                buildWindow.Show();
                this.Icon.Dispose();
                this.Close();
            }
        }

        //Load Build & Protoss
        private void PicbLoadBuild_Click(object sender, EventArgs e)
        {
            if(mainMenuActive)
            {

            }
            else
            {
                buildWindow = new BuildWindow("Protoss", mainVariables, mainFrame);
                buildWindow.Show();
                this.Icon.Dispose();
                this.Close();
            }
        }

        //Exit Game & Terran
        private void PicbExitManager_Click(object sender, EventArgs e)
        {
            if(mainMenuActive)
            {
                Environment.Exit(0);
            }
            else
            {
                buildWindow = new BuildWindow("Terran", mainVariables, mainFrame);
                buildWindow.Show();
                this.Icon.Dispose();
                this.Close();
            }
        }

        private void picbBackToMainMenu_Click(object sender, EventArgs e)
        {
            Initialize_MainMenu();
        }

        private void Initialize_MainMenu()
        {
            mainMenuActive = true;
            startWindow.Width = mainVariables.MainMenu_X;
            startWindow.Height = mainVariables.MainMenu_Y;
            mainMethods.Fill_Form_Background(this, mainVariables.MainMenu_Background);
            mainMethods.Fill_Picturebox(picbNewBuildZerg, mainVariables.MainMenu_NewBuildBM);
            mainMethods.Fill_Picturebox(picbLoadBuildProtoss, mainVariables.MainMenu_LoadBuildBM);
            mainMethods.Fill_Picturebox(picbExitManagerTerran, mainVariables.MainMenu_ExitBM);
            mainMethods.Fill_Picturebox(picbBackToMainMenu, mainVariables.NewBuild_Back);
        }
    }
}
