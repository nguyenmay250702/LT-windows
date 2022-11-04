using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT2_TinhTienKhamRang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total_Money = 0;
            if (checkBox1.Checked) total_Money += 100000;
            if (checkBox2.Checked) total_Money += 1200000;
            if (checkBox3.Checked) total_Money += 150000;
            if (checkBox4.Checked) total_Money += 100000;
            if (numericUpDown1.Value > 0) total_Money += 90000 * (int)numericUpDown1.Value;
            textBox2.Text = total_Money.ToString() + " VNĐ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
