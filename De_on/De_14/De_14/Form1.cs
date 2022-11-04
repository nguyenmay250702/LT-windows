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
namespace De_14
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_14;Integrated Security=True";
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        //load dữ liệu lên combobox
        private void uploadData_combobox()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from SanPham",sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_TenSP.DataSource = table;
            cbb_TenSP.DisplayMember = "TenSP";
            cbb_TenSP.ValueMember = "DonGia";
            cbb_TenSP.SelectedIndex = -1;
        }

        //load dữ liệu lên dataGridView
        private void uploadData_GridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select MaCTHD as 'STT', ChiTietHD.tenSP as 'Tên sản phẩm', DonGia as 'Đơn giá', SoluongBan as 'Số lượng bán', ThanhTien as 'Thành tiền' from SanPham, ChiTietHD where ChiTietHD.TenSP = SanPham.TenSp", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_combobox();
            uploadData_GridView();
            txt_TongTien.Text = Convert.ToString(new SqlCommand("select sum(ThanhTien) from ChiTietHD", sqlCon).ExecuteScalar());
            sqlCon.Close();
        }

        //xóa dữ liệu trong control
        private void deleteData_Control()
        {
            cbb_TenSP.SelectedIndex = -1;
            txt_DonGia.Text = "";
            numericUpDown1.Value = 0;
        }

        //chọn tên quả trong combobox => hiểu thị giá tương ứng
        private void cbb_TenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_TenSP.SelectedIndex == -1)
            {
                txt_DonGia.Text = "";
            }
            else
            {
                txt_DonGia.Text = cbb_TenSP.SelectedValue.ToString();
            }
        }

        //thêm dữ liệu
        private void btn_Them_Click(object sender, EventArgs e)
        {
            int testSL;
            if(cbb_TenSP.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sp","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(numericUpDown1.Value <= 0 || !int.TryParse(numericUpDown1.Value.ToString(), out testSL))
            {
                MessageBox.Show("Số lượng phải có kiểu nguyên và >0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Value = 0;
            }
            else
            {
                float ThanhTien = Convert.ToInt32(numericUpDown1.Value) * Convert.ToSingle(txt_DonGia.Text);
                string sqlQuery_add = "insert into ChiTietHD(TenSp, SoLuongBan, ThanhTien) values (N'" + cbb_TenSP.Text + "', " + numericUpDown1.Value + ", " + ThanhTien + ")";
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery_add, sqlCon);
                cmd.ExecuteNonQuery();
                txt_TongTien.Text = Convert.ToString(new SqlCommand("select sum(ThanhTien) from ChiTietHD",sqlCon).ExecuteScalar());
                sqlCon.Close();

                deleteData_Control();
                uploadData_GridView();
            }
        }

        //xóa dữ liệu trong dataGridView
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string sqlQuery_delete = "delete ChiTietHD where MaCTHD = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'";
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery_delete, sqlCon);
                cmd.ExecuteNonQuery();
                txt_TongTien.Text = Convert.ToString(new SqlCommand("select sum(ThanhTien) from ChiTietHD", sqlCon).ExecuteScalar());
                sqlCon.Close();
                deleteData_Control();
                uploadData_GridView();
            }
        }

        //chỉ đc nhập phím số và phím backspace
        
        /*
        private void txt_TienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 46 || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        */

        private void txt_TienKhachDua_KeyUp(object sender, KeyEventArgs e)
        {
            float TienKhachDua, TongTien;
            TongTien = Convert.ToSingle(txt_TongTien.Text);
            if (!Single.TryParse(txt_TienKhachDua.Text, out TienKhachDua))
            {
                MessageBox.Show("Tiền khách đưa phải là kiểu dữ liệu số !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TienTraLai.Text = "";
            }
            else if (txt_TienKhachDua.Text.Trim() != "" && TienKhachDua >= TongTien)
            {
                float TienTraLai = TienKhachDua - TongTien;
                txt_TienTraLai.Text = Convert.ToString(TienTraLai);
            }
        }

        //xóa đơn hiện tại chuẩn bị đơn hàng mới
        private void btn_HoanThanh_Click(object sender, EventArgs e)
        {
            deleteData_Control();
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("delete ChiTietHD",sqlCon);
            cmd.ExecuteNonQuery();
            uploadData_GridView();
            sqlCon.Close();

            txt_TongTien.Clear();
            txt_TienKhachDua.Clear();
            txt_TienTraLai.Clear();
        }
    }
}
