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
    public partial class Form2 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_3;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            uploadData_combobox("select * from SINHVIEN",cbb_MaSV, "MaSV");
            uploadData_combobox("select NoiSinh from SINHVIEN group by NoiSinh", cbb_NoiSinh, "NoiSinh");
            uploadData_combobox("select GioiTinh from SINHVIEN group by GioiTinh", cbb_GioiTinh, "GioiTinh");
            sqlCon.Close();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                uploadData_GridView("select * from SINHVIEN where MaSV = '" + cbb_MaSV.Text + "'");
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false)
            {
                uploadData_GridView("select * from SINHVIEN where NoiSinh = N'" + cbb_NoiSinh.Text + "'");
            }
            else if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true)
            {
                uploadData_GridView("select * from SINHVIEN where GioiTinh = N'" + cbb_GioiTinh.Text + "'");
            }
            else if(checkBox1.Checked && checkBox2.Checked && checkBox3.Checked == false)
            {
                uploadData_GridView("select * from SINHVIEN where (MaSV = '" + cbb_MaSV.Text + "') and (NoiSinh = N'" + cbb_NoiSinh.Text + "')");
            }
            else if (checkBox1.Checked && checkBox2.Checked == false && checkBox3.Checked)
            {
                uploadData_GridView("select * from SINHVIEN where (MaSV = '" + cbb_MaSV.Text + "') and (GioiTinh = N'" + cbb_GioiTinh.Text + "')");
            }
            else if (checkBox1.Checked == false && checkBox2.Checked && checkBox3.Checked)
            {
                uploadData_GridView("select * from SINHVIEN where (GioiTinh = N'" + cbb_GioiTinh.Text + "') and (NoiSinh = N'" + cbb_NoiSinh.Text + "')");
            }
            else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                uploadData_GridView("select * from SINHVIEN where (MaSV = '" + cbb_MaSV.Text + "') and (NoiSinh = N'" + cbb_NoiSinh.Text + "') and (GioiTinh = N'" + cbb_GioiTinh.Text + "')");
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để tìm kiếm!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
