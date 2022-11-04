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
namespace De_3
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_3;Integrated Security=True";
        SqlConnection sqlCon = null;
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        //tải dữ liệu lên dataGridView
        private void uploadData_GridView(string str)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_GridView("select MaSV as 'Mã SV', HoTen as 'Họ tên', NgaySinh as 'Ngày sinh', GioiTinh as 'Giới tính', NoiSinh as 'Nơi sinh' from SINHVIEN");
            sqlCon.Close(); 
        }

        //kiểm tra dữ liệu trên control
        private bool checkData_control()
        {
            if (txt_HoTen.Text.Trim() == "" || txt_HoTen.Text.Trim() == "" || cbb_NoiSinh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (radioButton_Nam.Checked == false && radioButton_Nu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        //kiểm tra mã sinh viên đã có chưa
        private bool checkMaSV(string str)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(str,sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sqlCon.Close();
                return true;
            }
            else
            {
                sqlCon.Close();
                return false;
            }
        }

        //thêm
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (checkData_control())
            {
                if (checkMaSV("select MaSV from SINHVIEN where MaSV = '" + txt_MaSV.Text.Trim() + "'") == false)
                {
                    sqlCon.Open();
                    string GioiTinh = (radioButton_Nam.Checked == true) ? "Nam" : "Nữ";
                    string sqlInsert = "insert into SINHVIEN (MaSV, HoTen, GioiTinh, NoiSinh) values ('" + txt_MaSV.Text.Trim() + "', N'" + txt_HoTen.Text.Trim() + "', N'" + GioiTinh+ "', N'" + cbb_NoiSinh.Text.Trim() + "')";
                    SqlCommand cmd = new SqlCommand(sqlInsert, sqlCon);
                    cmd.ExecuteNonQuery();
                    uploadData_GridView("select MaSV as 'Mã SV', HoTen as 'Họ tên', NgaySinh as 'Ngày sinh', GioiTinh as 'Giới tính', NoiSinh as 'Nơi sinh' from SINHVIEN");
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Mã SV đã tồn tại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //sửa
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                if (checkData_control())
                {
                    if (checkMaSV("select MaSV from SINHVIEN where MaSV = '" + txt_MaSV.Text.Trim() + "'") && txt_MaSV.Text.Trim() != dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim())
                    {
                        MessageBox.Show("Mã SV đã tồn tại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sqlCon.Open();
                        string GioiTinh = (radioButton_Nam.Checked == true) ? "Nam" : "Nữ";
                        string sqlUpdate = "update SINHVIEN set MaSV = '" + txt_MaSV.Text.Trim() + "', HoTen = N'" + txt_HoTen.Text.Trim() + "', GioiTinh = N'" + GioiTinh + "', NoiSinh = N'" + cbb_NoiSinh.Text.Trim() + "' where MaSV = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                        SqlCommand cmd = new SqlCommand(sqlUpdate, sqlCon);
                        cmd.ExecuteNonQuery();
                        uploadData_GridView("select MaSV as 'Mã SV', HoTen as 'Họ tên', NgaySinh as 'Ngày sinh', GioiTinh as 'Giới tính', NoiSinh as 'Nơi sinh' from SINHVIEN");
                        sqlCon.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //xóa
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                sqlCon.Open();
                       
                string sqlDelete= "delete SINHVIEN where MaSV = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim() + "'";
                SqlCommand cmd = new SqlCommand(sqlDelete, sqlCon);
                cmd.ExecuteNonQuery();
                uploadData_GridView("select MaSV as 'Mã SV', HoTen as 'Họ tên', NgaySinh as 'Ngày sinh', GioiTinh as 'Giới tính', NoiSinh as 'Nơi sinh' from SINHVIEN");
                sqlCon.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //lấy dữ liệu lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                txt_MaSV.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                txt_HoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                cbb_NoiSinh.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                radioButton_Nam.Checked = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")? true : false;
                radioButton_Nu.Checked = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nữ")? true : false;
            }
        }

        //nhấn vào nút Lọc => mở giao diện tìm kiếm
        private void btn_Loc_Click(object sender, EventArgs e)
        {
            //nếu form 2 chưa đc khởi tạo hoặc khởi tạo r n đã đc loại bỏ => khởi tạo form2 và hiển thị lên màn hình
            //form2.IsDisposed = true => control dc loại bỏ
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
                form2.Show();
            }
            
            //this.Visible = false; // ẩn Form1
        }
    }
}
