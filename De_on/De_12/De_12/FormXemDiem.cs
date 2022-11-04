using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace De_12
{
    public partial class FormXemDiem : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True";
        SqlConnection sqlCon = null;
        public FormXemDiem()
        {
            InitializeComponent();
        }

        private void FormXemDiem_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_combobox(cbb_XemDiem_MaSo,"select MaSo from SinhVien","MaSo");
            sqlCon.Close();
        }

        //load dữ liệu lên combobox
        private void uploadData_combobox(ComboBox cbb, string str, string nameDisplayMember)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb.DataSource = table;
            cbb.DisplayMember = nameDisplayMember;
            cbb.SelectedIndex = -1;
        }

        //load dữ liệu lên dataGridView
        private void uploadData_gridView(string str)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        //tìm kiếm thông tin điểm của sinh viên
        private void btn_xem_Click(object sender, EventArgs e)
        {
            if (cbb_XemDiem_MaSo.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã số của sinh viên để tìm kiếm!!!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string str =    "select Mon.TenMH as 'Tên môn học', KetQua.Diem as 'Điểm sô'" +
                                " from Mon, KetQua" +
                                " where KetQua.MaSo = " + cbb_XemDiem_MaSo.Text.Trim() + "and KetQua.MaMH = Mon.MaMH";
                uploadData_gridView(str);
            }

        }

        //chỉ nhận các phím số, backspace, enter, esc, spacebar
        private void cbb_XemDiem_MaSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //khi chuột đang ở trên control đc đưa ra ngoài thì sự kiện đc click hoạt
        //lấy ra tên và khoa của sinh viên tương ứng với mã nhập vào
        private void cbb_XemDiem_MaSo_MouseLeave(object sender, EventArgs e)
        {
            if (cbb_XemDiem_MaSo.Text != "")
            {

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                txt_XemDiem_HoTen.Text = Convert.ToString(new SqlCommand("select HoTen from SinhVien where MaSo = " + cbb_XemDiem_MaSo.Text.Trim(), sqlCon).ExecuteScalar());
                txt_XemDiem_Khoa.Text = Convert.ToString(new SqlCommand("select TenKhoa from SinhVien,Khoa where MaSo = " + cbb_XemDiem_MaSo.Text.Trim() + "and Khoa.MaKhoa = SinhVien.MaKhoa", sqlCon).ExecuteScalar());
                sqlCon.Close();
            }
        }
    }
}
