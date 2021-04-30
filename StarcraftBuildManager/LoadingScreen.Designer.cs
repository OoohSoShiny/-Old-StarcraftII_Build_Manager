
namespace StarcraftBuildManager
{
    partial class LoadingScreen
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
            this.txtLoad = new System.Windows.Forms.TextBox();
            this.picBBackToMenu = new System.Windows.Forms.PictureBox();
            this.picbExit = new System.Windows.Forms.PictureBox();
            this.picBLoad = new System.Windows.Forms.PictureBox();
            this.picBEyes = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBBackToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBEyes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoad
            // 
            this.txtLoad.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoad.Location = new System.Drawing.Point(28, 99);
            this.txtLoad.MaxLength = 10;
            this.txtLoad.Name = "txtLoad";
            this.txtLoad.Size = new System.Drawing.Size(100, 21);
            this.txtLoad.TabIndex = 0;
            // 
            // picBBackToMenu
            // 
            this.picBBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.picBBackToMenu.Location = new System.Drawing.Point(222, 12);
            this.picBBackToMenu.Name = "picBBackToMenu";
            this.picBBackToMenu.Size = new System.Drawing.Size(20, 20);
            this.picBBackToMenu.TabIndex = 73;
            this.picBBackToMenu.TabStop = false;
            this.picBBackToMenu.Click += new System.EventHandler(this.picBBackToMenu_Click);
            // 
            // picbExit
            // 
            this.picbExit.BackColor = System.Drawing.Color.Transparent;
            this.picbExit.Location = new System.Drawing.Point(248, 12);
            this.picbExit.Name = "picbExit";
            this.picbExit.Size = new System.Drawing.Size(20, 20);
            this.picbExit.TabIndex = 72;
            this.picbExit.TabStop = false;
            this.picbExit.Click += new System.EventHandler(this.picbExit_Click);
            // 
            // picBLoad
            // 
            this.picBLoad.BackColor = System.Drawing.Color.Transparent;
            this.picBLoad.Location = new System.Drawing.Point(28, 130);
            this.picBLoad.Name = "picBLoad";
            this.picBLoad.Size = new System.Drawing.Size(220, 45);
            this.picBLoad.TabIndex = 74;
            this.picBLoad.TabStop = false;
            this.picBLoad.Click += new System.EventHandler(this.picBLoad_Click);
            // 
            // picBEyes
            // 
            this.picBEyes.Location = new System.Drawing.Point(28, 48);
            this.picBEyes.Name = "picBEyes";
            this.picBEyes.Size = new System.Drawing.Size(220, 40);
            this.picBEyes.TabIndex = 75;
            this.picBEyes.TabStop = false;
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(280, 205);
            this.ControlBox = false;
            this.Controls.Add(this.picBEyes);
            this.Controls.Add(this.picBLoad);
            this.Controls.Add(this.picBBackToMenu);
            this.Controls.Add(this.picbExit);
            this.Controls.Add(this.txtLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingScreen";
            this.Deactivate += new System.EventHandler(this.LoadingScreen_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.picBBackToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBEyes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoad;
        private System.Windows.Forms.PictureBox picBBackToMenu;
        private System.Windows.Forms.PictureBox picbExit;
        private System.Windows.Forms.PictureBox picBLoad;
        private System.Windows.Forms.PictureBox picBEyes;
    }
}