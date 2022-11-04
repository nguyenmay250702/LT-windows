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

namespace De_8
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_8;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select DoUong from DATHANG group by DoUong", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "DoUong";
            comboBox1.SelectedIndex = -1;
            sqlCon.Close();
        }

        //hiển thị dữ liệu lên dataGridView
        private void uploadData_GridView(string str)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ClearSelection();
        }

        //tính tiền cần thanh toán
        private int TongTien()
        {
            int thanhTien = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                thanhTien += Convert.ToInt32(row.Cells[2].Value) * Convert.ToInt32(row.Cells[3].Value);
            }
            return thanhTien;
        }

        //Thống kê
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked == false)
            {
                string sqlQuery = "select SoBan as 'Số bàn', DoUong as 'Tên đồ uống', SoLuong as 'Số Lượng', Gia as 'Giá', ngay as 'Ngày' from DATHANG where DoUong = N'" + comboBox1.Text + "'";
                uploadData_GridView(sqlQuery);
                txt_DoanhThu.Text = TongTien().ToString();
            }
            else if (checkBox2.Checked && checkBox1.Checked == false)
            {
                string sqlQuery = "select SoBan as 'Số bàn', DoUong as 'Tên đồ uống', SoLuong as 'Số Lượng', Gia as 'Giá', ngay as 'Ngày' from DATHANG where ngay between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
                uploadData_GridView(sqlQuery);
                txt_DoanhThu.Text = TongTien().ToString();
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                string sqlQuery = "select SoBan as 'Số bàn', DoUong as 'Tên đồ uống', SoLuong as 'Số Lượng', Gia as 'Giá', ngay as 'Ngày' from DATHANG where (DoUong = N'" + comboBox1.Text + "') and (ngay between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "')";
                uploadData_GridView(sqlQuery);
                txt_DoanhThu.Text = TongTien().ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn điều kiện thống kê", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
