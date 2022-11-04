using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                HOANVI hv = new HOANVI(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                hv.warp();
                textBox1.Text = Convert.ToString(hv.A);
                textBox2.Text = Convert.ToString(hv.B);
            }
            catch (FormatException)
            {
                MessageBox.Show("Xin hãy nhập số");
            }
        }
    }
}
