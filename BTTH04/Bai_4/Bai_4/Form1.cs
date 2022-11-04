using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //lọc định dạng file có thể mở (vd: jpg, png, ...) (có thể chỉnh giá trị của thuộc tính "Filter" trực tiếp của hộp thoại openFileDialog1 không cần viết code)
            //(Filter không phải là thuộc tính của form)
            //(*.png)|*.png     : vế trái = (*.png)    phần hiển thị lên màn hình có thể nhìn thấy
            //                  : vế phải = *.png       phần máy hiểu

           // openFileDialog1.Filter = "(*.png)|*.png|(*.jpg)|*.jpg";
        }


        //sự kiện nhấn vào File/Exit => thoát trương trình 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //sự kiện click vào Change/Back Color bật cửa sổ chọn màu và màu nên thay đổi theo màu đc chọn
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mở hộ thoại color nếu đồng ý lấy màu đã chọn thì thay gán giá trị của thuộc tính BackColor = màu đã đc chọn
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog1.Color;
            }

            //màu mặc định của hệ thống
            //BackColor = DefaultBackColor;
        }


        //nhấn Change/Back Image mở hộp thoại chọn file ảnh => thay đổi hình nền của form
        private void backImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nếu như đồng ý mở ảnh đã chọn trong hộp thoại openFileDialog thì sẽ gán giá trị thuộc tính BackgroundImage của form = ảnh đã được chọn
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Image.FromFile(openFileDialog1.FileName)      :lấy ra hình ảnh
                //openFileDialog1.FileName                      :lấy ra đường dẫn ảnh đã chọn qua hộp thoại openFileDialog
                BackgroundImage = Image.FromFile(openFileDialog1.FileName);
            }

            //ảnh nền mặc định của hệ thống
            //BackgroundImage = null;
        }


        //Bấm vào menu Change/Font thì bật cửa sổ cho phép lựa chọn font và font chữ của các đối tượng trên form sẽ thay đổi theo font vừa lựa chọn.
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Font = fontDialog1.Font;
            }
        }
    }
}
