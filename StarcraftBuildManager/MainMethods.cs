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
    public class MainMethods
    {
        BuildWindow buildWindow;

        public MainMethods(BuildWindow givenBuildWindow)
        {
            buildWindow = givenBuildWindow;
        }
        public MainMethods()
        { }

        //Activating/Deactivating pictureboxes
        public void Activate_Picturebox(PictureBox pictureBox)
        { pictureBox.Visible = true; pictureBox.Enabled = true; }

        public void Deactivate_Picturebox(PictureBox pictureBox)
        { pictureBox.Visible = false; pictureBox.Enabled = false; }

        //Filling pictureboxes and backgrounds for forms
        public void Fill_Picturebox(PictureBox pictureBox, Bitmap bitmap)
        { pictureBox.Image = bitmap; }
        public void Fill_Form_Background(Form form, Bitmap bitmap)
        { form.BackgroundImage = bitmap; }

        public void Fill_Picturebox_Array(PictureBox[] pictureBoxes, Prefab[] prefabs)
        {
            int e = 0;
            for(int i = 0; i < prefabs.Length; i++)
            {
                pictureBoxes[i].Image = prefabs[i].Icon;
                e++;
            }
            for(int i = e; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Enabled = false;
                pictureBoxes[i].Visible = false;
            }
        }
    }
}
