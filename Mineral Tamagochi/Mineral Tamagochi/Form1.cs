using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mineral_Tamagochi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            progressBar1.Value = 100; // Здоровье начальное
            label2.Text = Convert.ToString(progressBar1.Value);
            progressBar2.Value = 50; // Счастье начальное
            label4.Text = Convert.ToString(progressBar2.Value);
            progressBar3.Value = 50; // Голод начальный
            label6.Text = Convert.ToString(progressBar3.Value);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //Здоровье
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            //Счастье
        }

        private void progressBar3_Click(object sender, EventArgs e)
        {
            //Голод
        }

        private void progressBar4_Click(object sender, EventArgs e)
        {
            //Зависимость 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("D:\\CourseWork\\Mineral Tamagochi\\Mineral Tamagochi\\images/love-thx.gif");
        }
    }
}
