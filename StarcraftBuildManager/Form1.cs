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
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
            StartWindow startWindow = new StartWindow(this);
            startWindow.Show();
            this.Hide();
        }
    }
}
