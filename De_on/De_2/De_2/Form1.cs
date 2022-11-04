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

namespace De_2
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_2;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();

        }
        //tải dữ liệu lên combobox
        private void uploadData_Combobox()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select TenHang from Hang", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_TenHang.DataSource = table;
            cbb_TenHang.DisplayMember = "TenHang";
            cbb_TenHang.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_Combobox();
            dataGridView1.ClearSelection();
            sqlCon.Close();
        }

        //chọn tên hàng -> hiển thị giá tiền tương ứng
        private void cbb_TenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            txt_DonGia.Text = Convert.ToString(new SqlCommand("select DonGia from Hang where TenHang = N'" + cbb_TenHang.Text + "'", sqlCon).ExecuteScalar());
            sqlCon.Close();
        }

        //xóa rỗng dữ liệu trong control
        private void deleteData_Control()
        {
            cbb_TenHang.SelectedIndex = -1;
            numeric_soLuong.Value = 0;
            txt_DonGia.Clear();
            txt_TongTien.Clear();
        }

        //tạo hóa đơn
        private void btn_taoHD_Click(object sender, EventArgs e)
        {
            txt_TenKhach.Clear();
            deleteData_Control();
            dataGridView1.Rows.Clear();
        }

        //thêm 1 hàng trong dataGridView
        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_TenKhach.Text.Trim() == "" || cbb_TenHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numeric_soLuong.Value <= 0)
            {
                MessageBox.Show("Số lượng phải >0!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int stt = dataGridView1.RowCount;
                float thanhTien = Convert.ToInt32(numeric_soLuong.Value) * Convert.ToSingle(txt_DonGia.Text);
                dataGridView1.Rows.Add(stt, cbb_TenHang.Text.Trim(), numeric_soLuong.Value, txt_DonGia.Text, thanhTien);
                deleteData_Control();
                dataGridView1.ClearSelection();

            }
        }

        //xóa 1 hàng trong dataGridView
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.ClearSelection();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //thanh toán
        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            float tongTien = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                tongTien += Convert.ToSingle(row.Cells[4].Value);
            }
            txt_TongTien.Text = tongTien.ToString();
        }

        //đổi màu control
        private void changeColor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if(contextMenuStrip1.SourceControl.GetType().Name == "DataGridView")
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
