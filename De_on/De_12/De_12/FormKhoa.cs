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
    public partial class FormKhoa : Form
    {
        public FormKhoa()
        {
            InitializeComponent();
        }

        //chuỗi kết nối
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True";

        //đối tương kết nối
        SqlConnection sqlCon = null;
        
        private void FormKhoa_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_GridView();
            sqlCon.Close();
        }

        //tải dữ liệu lên dataGridView
        private void uploadData_GridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select MaKhoa as'Mã khoa', TenKhoa as 'Tên khoa' from Khoa", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        //reset lại control
        private void resetControl()
        {
            txt_Khoa_MaKhoa.Clear();
            txt_Khoa_TenKhoa.Clear();
        }


        //kiểm tra mã trùng
        private bool checkCode(string str)
        {
            sqlCon.Open();
            SqlDataReader reader = new SqlCommand(str,sqlCon).ExecuteReader();
            if (reader.Read())
            {
                sqlCon.Close();
                return true;
            }
            sqlCon.Close();
            return false;
        }

        //thêm
        private void toolStripBtn_Them_Click(object sender, EventArgs e)
        {
            if(txt_Khoa_MaKhoa.Text == "" || txt_Khoa_TenKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkCode("select MaKhoa from Khoa where MaKhoa = '" + txt_Khoa_MaKhoa.Text.Trim() + "'"))
            {
                MessageBox.Show("Mã khoa đã tồn tại!!!\nVui lòng chọn lại mã khoa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("insert into Khoa values ('" + txt_Khoa_MaKhoa.Text.Trim() + "', N'" + txt_Khoa_TenKhoa.Text.Trim() + "')", sqlCon);
                cmd.ExecuteNonQuery();
                uploadData_GridView();
                resetControl();
                sqlCon.Close();
            }
        }

        //Sửa
        private void toolStripBtn_Sua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)      //kiểm tra xem có còn dữ liệu để thực hiện chỉnh sửa không
            {
                if(dataGridView1.SelectedRows.Count != 0)     //kiểm tra xem đã chọn dữ liệu để chỉnh sửa chưa
                {
                    //kiểm tra xem mã khoa mới muốn cập nhật đã tồn tại hay chưa
                    if (checkCode("select MaKhoa from Khoa where MaKhoa = '" + txt_Khoa_MaKhoa.Text.Trim() + "'") && (txt_Khoa_MaKhoa.Text.Trim() != dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim()))
                    {
                        MessageBox.Show("Mã khoa đã tồn tại!!!\nVui lòng chọn lại mã khoa.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlCommand cmd;
                        //kiểm tra xem thông tin của khoa đang muốn cập nhật thông tin đã có trong bảng sinh viên chưa
                        if (checkCode("select MaKhoa from SinhVien where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'"))
                        {
                            DialogResult luachon = MessageBox.Show("Thông tin của khoa này đã đc sử dụng trong bảng sinh viên!!!\n-Nếu tiếp tục chỉnh sửa dữ liệu thì dữ liệu có liên quan đến khoa này cũng sẽ đc cập nhật ở bảng SinhVien.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (luachon == DialogResult.Yes)
                            {
                                sqlCon.Open();
                                cmd = new SqlCommand("update Khoa set MaKhoa = '" + txt_Khoa_MaKhoa.Text.Trim() + "', TenKhoa = N'" + txt_Khoa_TenKhoa.Text.Trim() + "' where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'", sqlCon);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            sqlCon.Open();
                            cmd = new SqlCommand("update Khoa set MaKhoa = '" + txt_Khoa_MaKhoa.Text.Trim() + "', TenKhoa = N'" + txt_Khoa_TenKhoa.Text.Trim() + "' where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'", sqlCon);
                            cmd.ExecuteNonQuery();
                        }
                        uploadData_GridView();
                        resetControl();
                        sqlCon.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu đang rỗng, Không thể thực hiện thao tác chỉnh sửa!!!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Xóa
        private void toolStripBtn_Xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                SqlCommand cmd;
                //kiểm tra xem thông tin của khoa đang muốn cập nhật thông tin đã có trong bảng sinh viên chưa
                if (checkCode("select MaKhoa from SinhVien where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'"))
                {
                    sqlCon.Open();
                    DialogResult luachon = MessageBox.Show("Thông tin của khoa này đã đc sử dụng trong bảng sinh viên!!!\n-Nếu tiếp tục xóa dữ liệu thì dữ liệu có liên quan đến khoa này cũng sẽ đc xóa ở bảng SinhVien.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (luachon == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("delete Khoa where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'", sqlCon);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    sqlCon.Open();
                    cmd = new SqlCommand("delete Khoa where MaKhoa = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'", sqlCon);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu đang rỗng, Không thể thực hiện thao tác xóa thông tin!!!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            uploadData_GridView();
            resetControl();
            sqlCon.Close();
        }

        //lấy dữ liệu từ dataGridView lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txt_Khoa_MaKhoa.Text = dataGridView1.Rows[index].Cells[0].Value.ToString().Trim();
                txt_Khoa_TenKhoa.Text = dataGridView1.Rows[index].Cells[1].Value.ToString().Trim();
            }
        }
    }
}
