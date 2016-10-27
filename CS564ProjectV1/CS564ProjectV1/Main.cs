using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS564ProjectV1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void cmdLaunch_Click(object sender, EventArgs e)
        {
            // *GWL launch into login screen
            this.Hide();
            FrmLogin loginScreen = new FrmLogin();
            loginScreen.Show();
        }
    }
}
