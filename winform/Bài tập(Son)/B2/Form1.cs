using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void resetValue()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            comboBox4.SelectedItem = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add("maSV", "Mã SV");
            dataGridView1.Columns.Add("hoTen", "Họ tên");
            dataGridView1.Columns.Add("ngaySinh", "Ngày sinh");
            dataGridView1.Columns.Add("gioiTinh", "Giới tính");
            dataGridView1.Columns.Add("queQuan", "Quê quán");
            dataGridView1.Columns.Add("lop", "Lớp");
            dataGridView1.Columns.Add("khoa", "Khoa");
        }

        private bool checkMsvAdd()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        MessageBox.Show("Trùng mã sinh viên kìa");
                        return false;
                    }
                }
                catch (NullReferenceException) { return true; }
            }
            return true;
        }

        private bool checkMsvEdit()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text && textBox1.Text != dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["maSV"].Value.ToString())
                    {
                        MessageBox.Show("Trùng mã sinh viên kìa");
                        return false;
                    }
                }
                catch (NullReferenceException) { return true; }
            }
            return true;
        }

        private bool checkEmpty()
        {
            try
            {
                return (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value == null) ? true : false;
            }
            catch (NullReferenceException) { return true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Nhập đủ dữ liệu đê");
            }
            else if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Không có giới tính à bạn ey");
            }
            else
            {
                if (checkMsvAdd())
                {
                    string gioiTinh = (radioButton1.Checked) ? "Nam" : "Nữ";
                    dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, dateTimePicker1.Text, gioiTinh, comboBox2.Text, comboBox3.Text, comboBox4.Text);
                    resetValue();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            try
            {
                DataGridViewRow rowSelect = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = rowSelect.Cells["maSV"].Value.ToString();
                textBox2.Text = rowSelect.Cells["hoTen"].Value.ToString();
                dateTimePicker1.Value = DateTime.ParseExact(rowSelect.Cells["ngaySinh"].Value.ToString(), "dd/MM/yyyy", null);
                comboBox2.Text = rowSelect.Cells["queQuan"].Value.ToString();
                comboBox3.Text = rowSelect.Cells["lop"].Value.ToString();
                comboBox4.Text = rowSelect.Cells["khoa"].Value.ToString();
                if (rowSelect.Cells["gioiTinh"].Value.ToString() == "Nam")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
            catch (NullReferenceException) { resetValue(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkEmpty())
            {
                MessageBox.Show("Phải chọn hàng có dữ liệu thì mới sửa được");
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
                {
                    MessageBox.Show("Nhập đủ dữ liệu đê");
                }
                else
                {
                    if (checkMsvEdit())
                    {
                        DataGridViewRow rowEdit = dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                        string gioiTinh = (radioButton1.Checked) ? "Nam" : "Nữ";
                        rowEdit.Cells["maSV"].Value = textBox1.Text;
                        rowEdit.Cells["hoTen"].Value = textBox2.Text;
                        rowEdit.Cells["ngaySinh"].Value = dateTimePicker1.Text;
                        rowEdit.Cells["queQuan"].Value = comboBox2.Text;
                        rowEdit.Cells["lop"].Value = comboBox3.Text;
                        rowEdit.Cells["khoa"].Value = comboBox4.Text;
                        rowEdit.Cells["gioiTinh"].Value = gioiTinh;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
                    resetValue();
                }
            }
            catch (InvalidOperationException) { return; }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
