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

namespace De_9
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_9;Integrated Security=True";
        SqlConnection sqlCon = null;
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

            //cập nhật lại stt
            /*
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = row.Index;
            }*/
        }

        //tải dữ liệu lên combobox
        private void uploadData_Combobox()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select LoaiPhong from KhachHang group by LoaiPhong", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_LoaiPhong.DataSource = table;
            cbb_LoaiPhong.DisplayMember = "LoaiPhong";
            cbb_LoaiPhong.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_GridView("select MaKH as 'STT', HoTen as 'Tên khách hàng', GioiTinh as 'Giới tính', LoaiPhong as 'Loại phòng', SoPhongThue as 'Số phòng thuê' from KhachHang");
            uploadData_Combobox();
            sqlCon.Close();
        }

        //lấy dữ liệu từ dataGridView lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                txt_TenKhach.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                cbb_LoaiPhong.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_SoPhong.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                radioButton_nam.Checked = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nam")? true : false;
                radioButton_nu.Checked = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nữ") ? true : false;
            }
        }

        //kiểm tra dữ liệu trên control
        private bool checkData_Control()
        {
            int testSoPhong;
            if(txt_TenKhach.Text.Trim() == "" || cbb_LoaiPhong.Text.Trim() == "" || txt_SoPhong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (radioButton_nam.Checked == false && radioButton_nu.Checked == false)
            {
                MessageBox.Show("Bạn chưa nhập giới tính của khách!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(txt_SoPhong.Text, out testSoPhong))
            {
                MessageBox.Show("Số phòng phải có kiểu là số nguyên!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        //xóa dữ liệu
        private void deleteData_Control()
        {
            txt_TenKhach.Clear();
            radioButton_nam.Checked = false;
            radioButton_nu.Checked = false;
            cbb_LoaiPhong.SelectedIndex = -1;
            txt_SoPhong.Clear();
        }

        //Thêm
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (checkData_Control())
            {
                sqlCon.Open();
                int stt = dataGridView1.Rows.Count;
                string GioiTinh = (radioButton_nam.Checked == true) ? "Nam" : "Nữ";
                string sqlInsert = "insert into KhachHang values (" + stt + ", N'" + txt_TenKhach.Text.Trim() + "', N'" + GioiTinh + "', N'" + cbb_LoaiPhong.Text + "', " + txt_SoPhong.Text.Trim() + ")";
                SqlCommand cmd = new SqlCommand(sqlInsert, sqlCon);
                cmd.ExecuteNonQuery();
                uploadData_GridView("select MaKH as 'STT', HoTen as 'Tên khách hàng', GioiTinh as 'Giới tính', LoaiPhong as 'Loại phòng', SoPhongThue as 'Số phòng thuê' from KhachHang");
                deleteData_Control();
                sqlCon.Close();
            }
        }

        //tìm kiếm
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if(txt_TenTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu để tìm kiếm!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                uploadData_GridView("select MaKH as 'STT', HoTen as 'Tên khách hàng', GioiTinh as 'Giới tính', LoaiPhong as 'Loại phòng', SoPhongThue as 'Số phòng thuê' from KhachHang where HoTen = N'" + txt_TenTimKiem.Text.Trim() + "'");
            }
        }

        //sửa
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                if (checkData_Control())
                {
                    sqlCon.Open();
                    string GioiTinh = (radioButton_nam.Checked == true) ? "Nam" : "Nữ";
                    string sqlUpdate = "update KhachHang set HoTen = N'" + txt_TenKhach.Text.Trim() + "', GioiTinh = N'" + GioiTinh + "', LoaiPhong = N'" + cbb_LoaiPhong.Text + "', SoPhongThue = " + txt_SoPhong.Text.Trim() + " where MaKH = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                    SqlCommand cmd = new SqlCommand(sqlUpdate, sqlCon);
                    cmd.ExecuteNonQuery();
                    uploadData_GridView("select MaKH as 'STT', HoTen as 'Tên khách hàng', GioiTinh as 'Giới tính', LoaiPhong as 'Loại phòng', SoPhongThue as 'Số phòng thuê' from KhachHang");
                    deleteData_Control();
                    sqlCon.Close();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //đổi màu nền của các control
        private void ChangeBackColor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(contextMenuStrip1.SourceControl.Name, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                //contextMenuStrip1.SourceControl: lấy ra control cuối cùng khiến contextMenuStrip mở ra
                //contextMenuStrip1.SourceControl.GetType().Name: lấy ra tên kiểu dữ liệu của control
                
                if (contextMenuStrip1.SourceControl.GetType().Name == "DataGridView")
                {
                    dataGridView1.BackgroundColor = colorDialog1.Color;
                }
                else
                {
                    contextMenuStrip1.SourceControl.BackColor = colorDialog1.Color;
                }
                
            }
        }
    }
}
