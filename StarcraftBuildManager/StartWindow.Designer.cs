
namespace StarcraftBuildManager
{
    partial class StartWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.picbNewBuildZerg = new System.Windows.Forms.PictureBox();
            this.picbLoadBuildProtoss = new System.Windows.Forms.PictureBox();
            this.picbExitManagerTerran = new System.Windows.Forms.PictureBox();
            this.picbBackToMainMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbNewBuildZerg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLoadBuildProtoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbExitManagerTerran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbBackToMainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // picbNewBuildZerg
            // 
            this.picbNewBuildZerg.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picbNewBuildZerg, "picbNewBuildZerg");
            this.picbNewBuildZerg.Name = "picbNewBuildZerg";
            this.picbNewBuildZerg.TabStop = false;
            this.picbNewBuildZerg.Click += new System.EventHandler(this.PicbNewBuild_Click);
            // 
            // picbLoadBuildProtoss
            // 
            this.picbLoadBuildProtoss.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picbLoadBuildProtoss, "picbLoadBuildProtoss");
            this.picbLoadBuildProtoss.Name = "picbLoadBuildProtoss";
            this.picbLoadBuildProtoss.TabStop = false;
            this.picbLoadBuildProtoss.Click += new System.EventHandler(this.PicbLoadBuild_Click);
            // 
            // picbExitManagerTerran
            // 
            this.picbExitManagerTerran.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picbExitManagerTerran, "picbExitManagerTerran");
            this.picbExitManagerTerran.Name = "picbExitManagerTerran";
            this.picbExitManagerTerran.TabStop = false;
            this.picbExitManagerTerran.Click += new System.EventHandler(this.PicbExitManager_Click);
            // 
            // picbBackToMainMenu
            // 
            this.picbBackToMainMenu.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.picbBackToMainMenu, "picbBackToMainMenu");
            this.picbBackToMainMenu.Name = "picbBackToMainMenu";
            this.picbBackToMainMenu.TabStop = false;
            this.picbBackToMainMenu.Click += new System.EventHandler(this.picbBackToMainMenu_Click);
            // 
            // StartWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picbBackToMainMenu);
            this.Controls.Add(this.picbExitManagerTerran);
            this.Controls.Add(this.picbLoadBuildProtoss);
            this.Controls.Add(this.picbNewBuildZerg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartWindow";
            ((System.ComponentModel.ISupportInitialize)(this.picbNewBuildZerg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbLoadBuildProtoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbExitManagerTerran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbBackToMainMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbNewBuildZerg;
        private System.Windows.Forms.PictureBox picbLoadBuildProtoss;
        private System.Windows.Forms.PictureBox picbExitManagerTerran;
        private System.Windows.Forms.PictureBox picbBackToMainMenu;
    }
}