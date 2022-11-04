using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT6_PhuongTrinhBacHai
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            this.BackColor = colorDialog1.Color;
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            this.Font = fontDialog1.Font;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(textBox1.Text);
                double b = Convert.ToDouble(textBox2.Text);
                double c = Convert.ToDouble(textBox3.Text);
                if (a == 0)
                {
                    labelResult.Text = "x = " + (-b / c).ToString();
                }
                else
                {
                    double delta = Math.Pow(b, 2) - 4 * a * c;
                    if (delta < 0)
                    {
                        labelResult.Text = "Phương trình vô nghiệm";
                    }
                    else if (delta == 0)
                    {
                        labelResult.Text = "x = " + (-b / (2 * a)).ToString();
                    }
                    else
                    {
                        labelResult.Text = "x1 = " + ((-b + Math.Sqrt(delta)) / (2 * a)).ToString()
                                        + "\nx2 = " + ((-b - Math.Sqrt(delta)) / (2 * a)).ToString();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kí tự nhập vào phải là số");
            }
        }

        private void ChangeColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.ForeColor = colorDialog1.Color;
            }
        }

        private void ChangeFontToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.Font = fontDialog1.Font;
            }
        }

        private void contextMenuStripForLabel_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

    }
}
