using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_7
{
    public partial class Form1 : Form
    {
        private string phep_tinh, left_value , right_value ;

        public Form1()
        {
            InitializeComponent();
        }

        //a + b:    toán tử là a, b. Toán hạng là +

        //kiểm tra toán hạng khi nhập
        private void Nhap_ToanHang(string toan_hang)
        {
            int test;
            //kiểm tra xem người dùng có nhập toán hạng vào đầu không
            if (textBox_pheptinh.Text == "" && toan_hang != "-")
            {
                MessageBox.Show("Bạn cần nhập toán tử trước!!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox_pheptinh.Text != "" && !int.TryParse(textBox_pheptinh.Text, out test))    //kiểm tra biểu thức đã có toán hạng rồi thì không đc nhập toán hạng nữa
            {                                                                                          //(phục vụ cho vc tính toán giữa 2 toán tử)
                MessageBox.Show("Biểu thức không được chứa >1 toán hạng!!!\nMáy tính mô phỏng chỉ thực hiện trên 2 toán tử!!!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                phep_tinh = toan_hang.Trim();
                textBox_pheptinh.Text +=  toan_hang;  
            }
        }

        //nhập toán tử
        private void Nhap_ToanTu(string toan_tu)
        {
            double test;

            //kiểm tra xem biểu thức đã có toán hạng chưa nếu đã có rồi thì các giá trị nhập vào sẽ gán cho right_value nếu không thì gán cho left_value
            //kiểm tra nếu textBox_pheptinh.Text khác rỗng thì mới thực hiện chuyển đổi kiểu dữ liệu bằng trypase
            //textBox_pheptinh.Text != "" và textBox_pheptinh.Text != "-" nếu không có đk này thì khi chuyển đổi dữ liệu sẽ luôn sai
            if (textBox_pheptinh.Text != "" && textBox_pheptinh.Text != "-" && !Double.TryParse(textBox_pheptinh.Text, out test))
            {
                right_value += toan_tu;
            }
            else if (textBox_pheptinh.Text == "-")      //TH nhập toán tử đầu tiên là số âm
            {
                left_value = "-" + toan_tu;
            }
            else
            {
                left_value += toan_tu;
            }

            textBox_pheptinh.Text += toan_tu;
        }

        //sự kiện nhấn các nút button số
        private void button_0_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("0");
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("3");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("6");
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            Nhap_ToanTu("9");
        }

        private void button_cong_Click(object sender, EventArgs e)
        {
            Nhap_ToanHang(" + ");
        }

        private void button_tru_Click(object sender, EventArgs e)
        {
            Nhap_ToanHang("-");
        }

        private void button_nhan_Click(object sender, EventArgs e)
        {
            Nhap_ToanHang(" * ");
        }

        private void button_chia_Click(object sender, EventArgs e)
        {
            Nhap_ToanHang(" / ");
        }

        private void button_bang_Click(object sender, EventArgs e)
        {
            double vt, vp;
            vt = Convert.ToDouble(left_value);
            vp = Convert.ToDouble(right_value);

            if (phep_tinh == "+")
            {
                textBox_kq.Text = Convert.ToString(vt + vp);
            }
            else if (phep_tinh == "-")
            {
                textBox_kq.Text = (vt - vp).ToString();
            }
            else if (phep_tinh == "*")
            {
                textBox_kq.Text = (vt*vp).ToString();
            }
            else
            {
                textBox_kq.Text = (vt/vp).ToString();
            }
        }

        //nhấn nút C xóa toàn bộ dữ liệu đang hiển thị
        private void button_C_Click(object sender, EventArgs e)
        {
            left_value = "";
            right_value = "";
            textBox_pheptinh.Clear();
            textBox_kq.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //sự kiệ click vào menu thay đổi màu sắc của các phím
        private void thayĐổiMàuSắcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //duyệt từng control của tableLayoutPane1

                foreach (Control ctrl in tableLayoutPanel1.Controls)
                {
                    //nếu control có kiểu là button thì thực hiện đổi màu nền cho control đó
                    //if(ctrl is Button)
                    if(ctrl.GetType() == typeof(Button))
                    {
                        ctrl.BackColor = colorDialog1.Color;
                    }
                }
            }
        }

        //sự kiện click vào menu thay đổi font chữ của máy tính
        private void thayĐổiFontChữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font = fontDialog1.Font;
                menuStrip1.Font = fontDialog1.Font;
            }
        }
    }
}
