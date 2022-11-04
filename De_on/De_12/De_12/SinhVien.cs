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
    public partial class SinhVien : Form
    {
        SqlConnection sqlCon = null;
        public SinhVien()
        {
            InitializeComponent();
        }

        //tải dữ liệu lên dataGridView
        private void uploadData_GridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from SinhVien", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        //tải dữ liệu lên combobox
        private void uploadData_Combobox()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");
            sqlCon.Open();
            uploadData_GridView();
            sqlCon.Close();
        }

        //thêm
        private void them_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string GioiTinh = (checkBox1.Checked) ? "1" : "0";
            new SqlCommand("insert into SinhVien values ("+ txt_MaSV.Text + ",'" + txt_MaKhoa.Text + "', N'" + txt_HoTen.Text + "', '" + dateTime_NgaySinh.Text + "', " + GioiTinh + ", N'" + txt_DiaChi.Text + "', " + txt_DienThoai.Text + ")" ,sqlCon).ExecuteNonQuery();
            uploadData_GridView();
            sqlCon.Close();
        }

        //sửa
        private void sua_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            string GioiTinh = (checkBox1.Checked) ? "1" : "0";
            new SqlCommand("update SinhVien set MaSo = " + txt_MaSV.Text + ", MaKhoa = '" + txt_MaKhoa.Text + "', HoTen = N'" + txt_HoTen.Text + "', NgaySinh = '" + dateTime_NgaySinh.Text + "', GioiTinh = " + GioiTinh + ", DiaChi = N'" + txt_DiaChi.Text + "', DienThoai = " + txt_DienThoai.Text + "where MaSo = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value, sqlCon).ExecuteNonQuery();
            uploadData_GridView();
            sqlCon.Close();
        }

        //xóa
        private void xoa_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            new SqlCommand("delete SinhVien where MaSo = "+ dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value, sqlCon).ExecuteNonQuery();
            uploadData_GridView();
            sqlCon.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                txt_MaSV.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_HoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTime_NgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_DiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_DienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt_MaKhoa.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                checkBox1.Checked = (dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() == "True")? true:false;
            }
        }
    }
}
