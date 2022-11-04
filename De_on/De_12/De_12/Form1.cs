using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace De_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Khai báo biến toàn cục có kiểu là FromKhoa
        //FormKhoa formK;
      
        //đóng tất cả form con lại
        private void closeForm()
        {
            foreach(Form mdiForm in this.MdiChildren)
            {
                mdiForm.Close();
            }
        }

        //menu khoa
        private void toolStripBtn_Khoa_Click(object sender, EventArgs e)
        {
            //đóng tất cả form con lại
            closeForm();

            //khỏi tạo 1 form con mới và mở ra
            FormKhoa from = new FormKhoa();
            from.MdiParent = this;  //thiết lập from cha của form là Form1
            from.Show();

            //nếu from con chưa đc khởi tạo hoặc là đã tạo rồi n đã đc đóng thì thực hiện khởi tạo from con mới
            /*if ( formK == null || formK.IsAccessible)
            {
                FormKhoa from = new FormKhoa();
                from.MdiParent = this;
                from.Show();
            }*/
        }

        //menu xem điểm
        private void toolStripBtn_XemDiem_Click(object sender, EventArgs e)
        {
            closeForm();
            FormXemDiem form = new FormXemDiem();
            form.MdiParent = this;
            form.Show();
        }

        //thoát trương trình
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //sinh viên
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            closeForm();
            SinhVien from = new SinhVien();
            from.MdiParent = this;
            from.Show();
        }

        //nhập điểm
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            closeForm();
            NhapDiem from = new NhapDiem();
            from.MdiParent = this;
            from.Show();
        }
    }
}
