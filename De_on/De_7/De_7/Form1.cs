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

namespace De_7
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_7;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        //tải dữ liệu lên combobox
        private void uploadData_GridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select SoBan as 'Số Bàn', DoUong as 'Tên Đồ Uống', SoLuong as 'Số lượng', Gia as 'Giá' from DATHANG where SoBan = N'" + comboBox1.Text + "'", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select SoBan from DATHANG group by SoBan", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "SoBan";
            comboBox1.SelectedIndex = -1;
            sqlCon.Close(); 
        }

        //chọn số bàn => hiển thị đồ uống của số bàn đó, hiển thị tiền cần thanh toán
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int thanhTien = 0;
            uploadData_GridView();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                thanhTien += Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);
            }
            textBox1.Text = thanhTien.ToString();
        }
    }
}
