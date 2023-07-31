using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarioGameGUI
{
    public partial class Missions : Form
    {
        public Missions()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MainPage f = new MainPage();
            f.Show();
            this.Hide();
        }
    }
}
