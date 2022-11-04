using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B9
{
    public partial class Form1 : Form
    {
        private void resetValue()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private bool checkRowEmpty()
        {
            try
            {
                return (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value == null) ? true : false;
            }
            catch (NullReferenceException) { return true; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            try
            {
                DataGridViewRow rowSelect = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = rowSelect.Cells["Column1"].Value.ToString();
                dateTimePicker1.Value = DateTime.ParseExact(rowSelect.Cells["Column2"].Value.ToString(), "dd-MM-yyyy", null);
                textBox2.Text = rowSelect.Cells["Column4"].Value.ToString();
                textBox3.Text = rowSelect.Cells["Column3"].Value.ToString();
            }
            catch (NullReferenceException) { resetValue(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Nhập đủ dữ liệu đê");
            }
            else
            {
                dataGridView1.Rows.Add(textBox1.Text, dateTimePicker1.Text, textBox3.Text, textBox2.Text);
                resetValue();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkRowEmpty())
            {
                MessageBox.Show("Phải chọn hàng có dữ liệu thì mới sửa được");
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Nhập đủ dữ liệu đê");
                }
                else
                {
                    DataGridViewRow rowEdit = dataGridView1.Rows[dataGridView1.CurrentRow.Index];
                    rowEdit.Cells["Column1"].Value = textBox1.Text;
                    rowEdit.Cells["Column2"].Value = dateTimePicker1.Text;
                    rowEdit.Cells["Column4"].Value = textBox2.Text;
                    rowEdit.Cells["Column3"].Value = textBox3.Text;
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
                else
                {
                    MessageBox.Show("Phải chọn hàng có dữ liệu thì mới xóa được");
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Phải chọn hàng có dữ liệu thì mới xóa được");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
