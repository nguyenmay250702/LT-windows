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

namespace De_4
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLDiem;Integrated Security=True";
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        //tải dữ liệu lên combobox
        private void uploadData_combobox(string str, ComboBox cbb, string nameDisplayMember)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb.DataSource = table;
            cbb.DisplayMember = nameDisplayMember;
            cbb.SelectedIndex = -1;
        }

        //tải dữ liệu lên dataGridView
        private void uploadData_GridView(string str, DataGridView dgv)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dgv.DataSource = table;
            dgv.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach", dataGridView1);
            uploadData_combobox("select MaSV from DanhSach", cbb_QLD_MaSV, "MaSV");
            sqlCon.Close();
        }

        //lấy dữ liệu từ dataGridView lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                cbb_QLD_MaSV.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txt_HoTen.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txt_DiemToan.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txt_DiemVan.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txt_DiemNgoaiNgu.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            }
        }

        //kiểm tra dữ liệu trong control trước khi lưu thông tin vào CSDL
        private bool checkData_Control()
        {
            try
            {
                if(cbb_QLD_MaSV.Text.Trim() == "" || txt_HoTen.Text.Trim() == "" || txt_DiemToan.Text.Trim() == "" || txt_DiemVan.Text.Trim() == "" || txt_DiemNgoaiNgu.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToSingle(txt_DiemToan.Text) <0 || Convert.ToSingle(txt_DiemToan.Text) > 10 || Convert.ToSingle(txt_DiemVan.Text) < 0 || Convert.ToSingle(txt_DiemVan.Text) > 10 || Convert.ToSingle(txt_DiemNgoaiNgu.Text) < 0 || Convert.ToSingle(txt_DiemNgoaiNgu.Text) > 10)
                {
                    MessageBox.Show("Điểm phải >=0 và <=10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Điểm phải có kiểu số thực!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //kiểm tra mã đã tồn tại chưa
        private bool check_MaSV(string str)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(str, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sqlCon.Close();
                return true;
            }
            sqlCon.Close();
            return false;
        }

        //chọn mã sinh viên -> họ tên tương ứng hiện lên trên ô textbox nhập họ tên
        private void cbb_QLD_MaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            string hoten = Convert.ToString(new SqlCommand("select TenSV from DanhSach where MaSV = '" + cbb_QLD_MaSV.Text.Trim() + "'", sqlCon).ExecuteScalar());
            txt_HoTen.Text = hoten;
            sqlCon.Close();    
        }

        //thêm dữ liệu
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkData_Control())
            {
                if(check_MaSV("select MaSV from DanhSach where MaSV = '" + cbb_QLD_MaSV.Text.Trim() + "'"))
                {
                    MessageBox.Show("Mã sinh viên bị trùng!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sqlCon.Open();
                    string sqlquery_insert = "insert into DanhSach values ('" + cbb_QLD_MaSV.Text.Trim() + "', N'" + txt_HoTen.Text.Trim() + "', " + txt_DiemToan.Text.Trim() + ", "+ txt_DiemVan.Text.Trim() + ", " + txt_DiemNgoaiNgu.Text.Trim() + ")";  
                    SqlCommand cmd = new SqlCommand(sqlquery_insert, sqlCon);
                    cmd.ExecuteNonQuery();

                    uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach", dataGridView1);
                    uploadData_combobox("select MaSV from DanhSach", cbb_QLD_MaSV, "MaSV");

                    txt_DiemToan.Clear();
                    txt_DiemVan.Clear();
                    txt_DiemNgoaiNgu.Clear();
                    sqlCon.Close();
                }
            }
        }


        //Sửa dữ liệu
        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                if (checkData_Control())
                {
                    if(check_MaSV("select MaSV from DanhSach where MaSV = '" + cbb_QLD_MaSV.Text.Trim() + "'") && cbb_QLD_MaSV.Text.Trim() != dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Mã sinh viên bị trùng!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sqlCon.Open();
                        string sqlQuery_update = "update DanhSach set MaSV = '" + cbb_QLD_MaSV.Text.Trim() + "', TenSV = N'" + txt_HoTen.Text.Trim() + "', DiemToan = " + txt_DiemToan.Text.Trim() + ", DiemVan = " + txt_DiemVan.Text.Trim() + ", DiemNgoaiNgu = " + txt_DiemNgoaiNgu.Text.Trim() + "where MaSV = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'";
                        SqlCommand cmd = new SqlCommand(sqlQuery_update,sqlCon);
                        cmd.ExecuteNonQuery();
                        uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach", dataGridView1);
                        uploadData_combobox("select MaSV from DanhSach", cbb_QLD_MaSV, "MaSV");

                        txt_DiemToan.Clear();
                        txt_DiemVan.Clear();
                        txt_DiemNgoaiNgu.Clear();
                        sqlCon.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //xóa dữ liệu
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("delete from DanhSach where MaSV = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'", sqlCon);
                cmd.ExecuteNonQuery();
                uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach", dataGridView1);
                uploadData_combobox("select MaSV from DanhSach", cbb_QLD_MaSV, "MaSV");

                txt_DiemToan.Clear();
                txt_DiemVan.Clear();
                txt_DiemNgoaiNgu.Clear();
                sqlCon.Close();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //thống kê
        private void button4_Click(object sender, EventArgs e)
        {
            if(cbb_TK_phanLoaiSV.Text != "")
            {
                if (cbb_TK_phanLoaiSV.Text.Trim() == "Giỏi")
                {
                    uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach where (DiemToan + DiemVan + DiemNgoaiNgu)/3 >=8", dataGridView2);
                }
                else if(cbb_TK_phanLoaiSV.Text.Trim() == "Khá")
                {
                    uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach where ((DiemToan + DiemVan + DiemNgoaiNgu)/3 <8) and ((DiemToan + DiemVan + DiemNgoaiNgu)/3 >=6.5)", dataGridView2);
                }
                else
                {
                    uploadData_GridView("select MaSV as 'Mã SV', TenSV as 'Tên SV', DiemToan as 'Điểm toán', DiemVan as 'Điểm văn', DiemNgoaiNgu as 'Điểm ngoại ngữ', (DiemToan + DiemVan + DiemNgoaiNgu)/3 as 'Điểm trung bình' from DanhSach where (DiemToan + DiemVan + DiemNgoaiNgu)/3 <6.5", dataGridView2);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhận tiêu chí thống kê!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
