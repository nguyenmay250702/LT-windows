using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B1_NhapSo
{
    public partial class Form1 : Form
    {
        private bool isValidTextBox = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isValidTextBox)
            {
                int tbValue = Convert.ToInt32(textBox1.Text);
                List<int> prime = new List<int>();
                List<int> perfectSquare = new List<int>();
                List<int> perfectNumber = new List<int>();
                for (int i = 1; i <= tbValue; i++)
                {
                    if (Utils.isPrime(i)) prime.Add(i);
                    if (Utils.isPerfectSquare(i)) perfectSquare.Add(i);
                    if (Utils.isPerfectNumber(i)) perfectNumber.Add(i);
                }
                label5.Text = String.Join(" ", prime.ToArray());
                label6.Text = String.Join(" ", perfectSquare.ToArray());
                label7.Text = String.Join(" ", perfectNumber.ToArray());
            }
            else
            {
                MessageBox.Show("Số nhập vào không hợp lệ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                return;
            }
            if (!int.TryParse(textBox1.Text, out int value))
            {
                MessageBox.Show("Kí tự được nhập vào phải là số!");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                return;
            }
            int value = Convert.ToInt32(((TextBox)sender).Text);
            if (value > 0 && value < 100)
            {
                this.isValidTextBox = true;
            }
            else
            {
                this.isValidTextBox = false;
                MessageBox.Show("Số nhập vào phải thỏa mãn 0 < n < 100");
            }
        }
    }
}
