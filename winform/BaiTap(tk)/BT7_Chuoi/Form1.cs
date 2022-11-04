using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT7_Chuoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b;
            if (textBox1.Text.Length < textBox2.Text.Length)
            {
                a = textBox1.Text;
                b = textBox2.Text;
            }
            else
            {
                a = textBox2.Text;
                b = textBox1.Text;
            }
            int c = 0;
            for (int i = 0; i <= b.Length - a.Length; i++)
            {
                if (b.Substring(i, a.Length) == a)
                {
                    c++;
                }
            }
            label3.Text = "Số lần xuất hiện của chuỗi ngắn trong chuỗi dài: " + c.ToString();
            string l7 = "";
            for (int i = textBox1.Text.Length - 1; i >= 0; i--)
            {
                l7 += textBox1.Text[i];
            }
            label4.Text = "Nghịch đảo chuỗi a: " + l7;

            string l8 = "";
            for (int i = textBox2.Text.Length - 1; i >= 0; i--)
            {
                l8 += textBox2.Text[i];
            }
            label5.Text = "Nghịch đảo chuỗi b:" + l8;

        }

        private void đổiMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.ForeColor = colorDialog1.Color;
            }

        }

        private void đổiFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Font = fontDialog1.Font;
            }
        }

        private void đổiMàuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.ForeColor = colorDialog1.Color;
            }
        }

        private void đổiFontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Font = fontDialog1.Font;
            }
        }

        private void đổiMàuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.ForeColor = colorDialog1.Color;
            }
        }

        private void đổiFontToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label3.Font = fontDialog1.Font;
            }
        }

        private void đổiMàuToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.ForeColor = colorDialog1.Color;
            }
        }

        private void đỔiFontToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Font = fontDialog1.Font;
            }
        }

        private void đổiFontToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label5.Font = fontDialog1.Font;
            }
        }

        private void đổiMàuToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                label5.ForeColor = colorDialog1.Color;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void ChangeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.ForeColor = colorDialog1.Color;
            }
        }

        private void ChangeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                contextMenuStrip1.SourceControl.Font = fontDialog1.Font;
            }
        }
    }
}
