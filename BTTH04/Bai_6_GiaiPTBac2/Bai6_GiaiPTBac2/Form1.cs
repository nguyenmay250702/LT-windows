using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai6_GiaiPTBac2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c, delta;
            if(!Double.TryParse(textBox_a.Text, out a) || !Double.TryParse(textBox_b.Text, out b) || !Double.TryParse(textBox_c.Text, out c))
            {
                MessageBox.Show("Kiểm tra lại giá trị nhập của a, b, c!!!\nGiá trị a, b, c phải là các chữ số và không được bỏ trống!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pt_bac2.Text = a + "X^2 + " + b + "X + " + c + " = 0";

                if(a == 0 && b == 0 && c != 0)
                {
                    KetQua.Text = "- KQ: Phương trình vô nghiệm";
                }
                else if(a == 0 && b == 0 && c == 0)
                {
                    KetQua.Text = "- KQ: Phương trình vô số nghiệm";
                }
                else if(a == 0 && b != 0)
                {
                    KetQua.Text = "- KQ: Phương trình có nghiệm duy nhất:\t X = " + (-c/b);
                }
                else
                {
                    delta = b * b - 4 * a * c;
                    if (delta < 0)
                    {
                        KetQua.Text = "- KQ: Phương trình vô nghiệm";
                    }
                    else if (delta == 0)
                    {
                        double x = -b / (2 * a);
                        KetQua.Text = "- KQ : PT có nghiệm kép\n X1 = X2 = " + x;
                    }
                    else if (delta > 0)
                    {
                        double x1, x2;
                        x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                        x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                        KetQua.Text = "- KQ : PT có 2 nghiệm:\n+ X1 = " + x1 + "\n+ X2 = " + x2;
                    }
                }   
            }
        }

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ctrl.BackColor = colorDialog1.Color;
            }



            
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
