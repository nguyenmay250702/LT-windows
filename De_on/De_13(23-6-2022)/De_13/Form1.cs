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

namespace De_13
{
    public partial class Form1 : Form
    {
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=De_13;Integrated Security=True";
        SqlConnection sqlCon = null;
        public Form1()
        {
            InitializeComponent();
        }

        //load dữ liệu lên combobox
        private void uploadData_combobox()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Truyen", sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_TenTruyen.DataSource = table;
            cbb_TenTruyen.DisplayMember = "TenTruyen";
            cbb_TenTruyen.ValueMember = "DonGiaNgay";
            cbb_TenTruyen.SelectedIndex = -1;
        }

        //load dữ liệu lên dataGridView
        private void uploadData_GridView()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select MaPM as 'STT', TenKhach as 'Tên khách', SoDT as 'Số điện thoại', TenTruyenPM as 'Tên truyện', NgayMuon as 'Ngày mượn', NgayTra as 'Ngày trả', ThanhTien as 'Thành tiền', GhiChu as 'Ghi chú' from PhieuMuon",sqlCon);
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
            sqlCon.Close();
        }


        //chỉ đc nhấp phím số và phím backspace
        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Số điện thoại chỉ đc nhập số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //chọn tên truyện hiển thị đơn giá ngày tương ứng
        private void cbb_TenTruyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbb_TenTruyen.SelectedIndex != -1)
            {
                txt_DonGiaNgay.Text = cbb_TenTruyen.SelectedValue.ToString();
            }
            else
            {
                txt_DonGiaNgay.Text = "";
            }
        }

        //mượn truyện
        private void btn_Muon_Click(object sender, EventArgs e)
        {
            if(txt_tenKhach.Text.Trim() == "" || txt_sdt.Text.Trim() == "" || cbb_TenTruyen.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sqlCon.Open();
                int stt = dataGridView1.RowCount;
                string sqlquery_add = "insert into PhieuMuon (TenKhach, SoDT, TenTruyenPM, NgayMuon, GhiChu) values (N'" + txt_tenKhach.Text.Trim() + "', " + txt_sdt.Text.Trim() + ", N'" + cbb_TenTruyen.Text + "', '"+ dateTimePicker1.Text + "', N'Chưa trả')";
                SqlCommand cmd = new SqlCommand(sqlquery_add, sqlCon);
                cmd.ExecuteNonQuery();
                uploadData_GridView();
                sqlCon.Close();
            }
        }

        //trả truyện
        private void btn_Tra_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count != 0)
            {
                //tính sô ngày đã mượn
                TimeSpan day = dateTimePicker2.Value - dateTimePicker1.Value;
                int time = day.Days;
                
                //tính tiền phải trả
                float thanhTien = time * Convert.ToSingle(txt_DonGiaNgay.Text);

                sqlCon.Open();
                string sqlQuery_update = "update PhieuMuon set NgayTra = '" + dateTimePicker2.Text + "', ThanhTien = " + thanhTien + ", GhiChu = null where MaPM = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery_update, sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                uploadData_GridView();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn thông tin Truyện muốn trả!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //lấy dữ liệu từ dataGridView lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                txt_tenKhach.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbb_TenTruyen.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt_DonGiaNgay.Text = cbb_TenTruyen.SelectedValue.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
