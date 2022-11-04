using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            double a, b, thuong;
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                if(b == 0)
                {
                    MessageBox.Show("Mau so phai != 0!!!", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    thuong = (double)a / b;
                    txt_tong.Text = "Tong a + b = " + (a + b);
                    txt_hieu.Text = "Hieu a - b = " + (a - b);
                    txt_tich.Text = "Tich a*b = " + a * b;
                    txt_thuong.Text = "Thuong a/b = " + thuong;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Gia tri a va b khong hop le!!!","Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
