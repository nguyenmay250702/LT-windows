using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isPrime(int value)
        {
            if (value < 2)
            {
                return false;
            }
            else
            {
                for (int i = 2; i < value; i++)
                {
                    if (value % i == 0)
                        return false;
                }
                return true;
            }
        }

        private bool isSquareNumber(int value)
        {
            int T = Convert.ToInt32(Math.Sqrt(value));
            if (T * T == value)
                return true;
            else
                return false;
        }

        private bool isPerfectNumber(int value)
        {
            int sum = 0;
            for (int i = 1; i <= value/2; i++)
            {
                if (value % i == 0)
                    sum += i;
            }
            if (sum == value)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = new Int32();
            try
            {
                value = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException)
            {
                label5.Text = "Giá trị nhập vào không hợp lệ";
                label5.ForeColor = Color.Red;
                return;
            }
            catch (OverflowException)
            {
                label5.Text = "0 < n < 1000";
                label5.ForeColor = Color.Red;
                return;
            }
            if (value <= 0 || value >= 1000)
            {
                label5.Text = "0 < n < 1000";
                label5.ForeColor = Color.Red;
                return;
            }
            else
            {
                label2.Text = "Các số nguyên tố nhỏ hơn " + Convert.ToString(value) + ": ";
                label3.Text = "Các số chính phương nhỏ hơn " + Convert.ToString(value) + ": ";
                label4.Text = "Các số hoàn chỉnh nhỏ hơn " + Convert.ToString(value) + ": ";
                label5.Text = "";
                for (int i = 2; i < value; i++)
                {
                    if (isPrime(i) && i < value)
                        label2.Text += Convert.ToString(i) + " ";
                    if (isSquareNumber(i) && i < value)
                        label3.Text += Convert.ToString(i) + " ";
                    if (isPerfectNumber(i) && i < value)
                        label4.Text += Convert.ToString(i) + " ";
                }
            }
        }
    }
}
