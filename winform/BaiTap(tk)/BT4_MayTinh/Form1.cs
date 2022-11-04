using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT4_MayTinh
{
    public partial class Form1 : Form
    {
        private bool isCalculated = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void appendCharToExpression(object sender, EventArgs e)
        {
            string c = ((Button)sender).Text;
            if (this.isCalculated)
            {
                textBoxExpression.Text = "";
                this.isCalculated = false;
            }
            textBoxResult.Text = "";
            textBoxExpression.Text += c;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string exText = textBoxExpression.Text;
            if (exText.Length > 0)
            {
                textBoxExpression.Text = exText.Remove(exText.Length - 1);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string exText = textBoxExpression.Text;
            if (exText.Length == 0)
            {
                return;
            }
            if (!Char.IsDigit(exText[0]) || !Char.IsDigit(exText[exText.Length - 1]))
            {
                textBoxResult.Text = "ERROR SYNTAX";
                return;
            }
            double result = calc(exText);
            if (Double.IsInfinity(result))
            {
                textBoxResult.Text = "ERROR DIVIDE BY 0";
                return;
            }
            textBoxResult.Text = Math.Round(result, 6).ToString();
            this.isCalculated = true;

        }

        private double calc(string ex)
        {
            if (ex.Contains("+"))
            {
                int opIndex = ex.IndexOf("+");
                string e1 = ex.Substring(0, opIndex);
                string e2 = ex.Substring(opIndex + 1);
                return calc(e1) + calc(e2);
            }
            if (ex.Contains("-"))
            {
                int opIndex = ex.IndexOf("-");
                string e1 = ex.Substring(0, opIndex);
                string e2 = ex.Substring(opIndex + 1);
                return calc(e1) - calc(e2);
            }
            if (ex.Contains("x"))
            {
                int opIndex = ex.IndexOf("x");
                string e1 = ex.Substring(0, opIndex);
                string e2 = ex.Substring(opIndex + 1);
                return calc(e1) * calc(e2);
            }
            if (ex.Contains("÷"))
            {
                int opIndex = ex.IndexOf("÷");
                string e1 = ex.Substring(0, opIndex);
                string e2 = ex.Substring(opIndex + 1);
                return calc(e1) / calc(e2);
            }
            return Convert.ToDouble(ex);
        }

        private void colorChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (Button btn in tableLayoutPanel1.Controls)
                {
                    btn.BackColor = colorDialog1.Color;
                }
            }
        }

        private void fontChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
                menuStrip1.Font = fontDialog1.Font;
            }
        }

    }
}
