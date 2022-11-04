using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Chưa viết được thuật toán";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) { setColorButton(); }
        }

        private void setColorButton()
        {
            button0.BackColor = colorDialog1.Color;
            button1.BackColor = colorDialog1.Color;
            button2.BackColor = colorDialog1.Color;
            button3.BackColor = colorDialog1.Color;
            button4.BackColor = colorDialog1.Color;
            button5.BackColor = colorDialog1.Color;
            button6.BackColor = colorDialog1.Color;
            button7.BackColor = colorDialog1.Color;
            button8.BackColor = colorDialog1.Color;
            button9.BackColor = colorDialog1.Color;
            button10.BackColor = colorDialog1.Color;
            button11.BackColor = colorDialog1.Color;
            button12.BackColor = colorDialog1.Color;
            button13.BackColor = colorDialog1.Color;
            button14.BackColor = colorDialog1.Color;
            button15.BackColor = colorDialog1.Color;
        }

        public void setFont()
        {
            this.Font = fontDialog1.Font;
            toolStripMenuItem1.Font = fontDialog1.Font;
            toolStripMenuItem2.Font = fontDialog1.Font;
            toolStripMenuItem3.Font = fontDialog1.Font;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) { setFont(); }
        }
    }
}
