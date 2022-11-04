using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT8
{
    public partial class Form1 : Form
    {
        Color tempColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            tempColor = btn.BackColor;
            btn.BackColor = Color.DeepPink;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            btn.BackColor = tempColor;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = ((Button)sender);
            btn.BackColor = Color.DarkOrange;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = ((Button)sender);
            btn.BackColor = Color.DeepPink;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            textBox1.Text += btn.Text;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

    }
}
