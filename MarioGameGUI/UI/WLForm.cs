using MarioGameGUI.GL;
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
    public partial class WLForm : Form
    {
        public WLForm(int score, string status, Image img)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Scorenum.Text = score.ToString();
            label1.Text = status;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage f = new MainPage();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameStage f = new GameStage(0);
            f.Show();
            this.Hide();

        }
    }
}
