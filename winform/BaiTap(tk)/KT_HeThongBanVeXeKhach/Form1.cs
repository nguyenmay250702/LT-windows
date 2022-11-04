using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_HeThongBanVeXeKhach
{
    public partial class Form1 : Form
    {
        bool[] isSold = new bool[45];
        int seatSelected = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetForm()
        {
            textBox_name.Text = "";
            textBox_price.Text = "40000";
            numericUpDown1.Value = 0;
        }

        private void Seat_Btn_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(((Button)sender).Text);
            if (isSold[n])
            {
                return;
            }
            foreach (Button btn in tableLayoutPanel1.Controls)
            {
                int n1 = Convert.ToInt32(btn.Text);
                if (n1 == n && !isSold[n1])
                {
                    btn.BackColor = Color.Orange;
                }
                else if (!isSold[n1])
                {
                    btn.BackColor = Color.Transparent;
                }
            }
            if (n != seatSelected)
            {
                resetForm();
            }
            seatSelected = n;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double r = 50000;
            if (numericUpDown1.Value >= 50)
            {
                r *= 0.5;
            }
            else if (numericUpDown1.Value < 18)
            {
                r *= 0.8;
            }
            textBox_price.Text = r.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            if (seatSelected < 0)
            {
                return;
            }
            if (textBox_name.Text.Length == 0)
            {
                MessageBox.Show("Tên khách hàng không được bỏ trống");
                return;
            }
            foreach (Button btn in tableLayoutPanel1.Controls)
            {
                int n1 = Convert.ToInt32(btn.Text);
                if (n1 == seatSelected)
                {
                    btn.BackColor = Color.Red;
                }
            }
            isSold[seatSelected] = true;
            string[] dataToAdd = {
                seatSelected.ToString(),
                textBox_name.Text,
                numericUpDown1.Value.ToString(),
                textBox_price.Text
            };
            dataGridView1.Rows.Add(dataToAdd);
            seatSelected = -1;
            resetForm();
        }
    }
}
