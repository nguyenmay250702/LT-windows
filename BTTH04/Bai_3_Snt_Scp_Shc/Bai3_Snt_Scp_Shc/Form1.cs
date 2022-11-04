using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai3_Snt_Scp_Shc
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        //sự kiện thay đổi giá trị của textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.ToString().Trim() != "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        //sự kiện rời khỏi ô textbox (chỉ click hoạt sự kiên khi cố thoát khỏi ô textbox đang thực thi và chuyển sang ô textbox khác)
        private void textbox_leave(object sender, EventArgs e)
        {   
            try
            {
                if(Convert.ToInt32(textBox1.Text) <= 0 || Convert.ToInt32(textBox1.Text)>=1000)
                {
                    MessageBox.Show("Giá trị n vượt giới hạn cho phép!!!\n(0< n <1000)","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Gía trị của n phải là số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //kiểm tra 1 có là số nguyên tố
        private bool kt_so_nguyen_to(int a)
        {
            if (a == 1) return false;
            
            for(int i = 2; i < a; i++)
            {
                if(a%i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //kiểm tra 1 có là số chính phương
        private bool kt_so_chinh_phuong(int a)
        {
            if((int)Math.Sqrt(a) * (int)Math.Sqrt(a) == a)
            {
                return true;
            }
            return false;
        }

        //kiểm tra 1 có là số hoàn chỉnh
        private bool kt_so_hoan_chinh( int a)
        {
            int sum = 0;
            for (int i = 1; i < a; i++)
            {
                if(a%i == 0)
                {
                    sum = sum + i;
                }
            }

            if(a == sum)
            {
                return true;
            }
            return false;
        }

        //sự kiện nhấn button nút hiển thị
        private void button1_Click(object sender, EventArgs e)
        {
            string cac_so_nguyen_to = "", cac_so_chinh_phuong = "", cac_so_hoan_chinh = "";
            try
            {
                if (Convert.ToInt32(textBox1.Text) <= 0 || Convert.ToInt32(textBox1.Text) >= 1000)
                {
                    MessageBox.Show("Giá trị n vượt giới hạn cho phép!!!\n(0< n <1000)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
                for (int i = 1; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    if (kt_so_nguyen_to(i))
                    {
                        cac_so_nguyen_to = cac_so_nguyen_to + i + "; ";
                    }
                    if (kt_so_chinh_phuong(i))
                    {
                        cac_so_chinh_phuong = cac_so_chinh_phuong + i + "; ";
                    }
                    if (kt_so_hoan_chinh(i))
                    {
                        cac_so_hoan_chinh = cac_so_hoan_chinh + i + "; ";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Gía trị của n phải là số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label2.Text = "Các số nguyên tố < n: " + cac_so_nguyen_to;
            label3.Text = "Các số chính phương < n: " + cac_so_chinh_phuong;
            label4.Text = "Các số hoàn chỉnh < n: " + cac_so_hoan_chinh;
        }
    }
}
