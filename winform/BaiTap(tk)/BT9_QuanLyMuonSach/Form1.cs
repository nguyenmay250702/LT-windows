using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateTimePickerDueDate.Value = DateTime.Now.AddDays(40);
        }

        private void buttonBookAdd_Click(object sender, EventArgs e)
        {
            if (textBoxBookId.Text.Length == 0)
            {
                MessageBox.Show("Mã sách không được bỏ trống");
                return;
            }
            if (textBoxBookName.Text.Length == 0)
            {
                MessageBox.Show("Tên sách không được bỏ trống");
                return;
            }
            string[] bookToAdd =
            {
                textBoxBookId.Text,
                textBoxBookName.Text
            };
            dataGridViewBook.Rows.Add(bookToAdd);
            comboBoxBookName.Items.Add(textBoxBookName.Text);
            textBoxBookId.Text = "";
            textBoxBookName.Text = "";
        }

        private void buttonLoanBook_Click(object sender, EventArgs e)
        {
            if (comboBoxStudentName.SelectedItem == null)
            {
                MessageBox.Show("Phải chọn tên sinh viên trước");
                return;
            }
            if (comboBoxBookName.SelectedItem == null)
            {
                MessageBox.Show("Phải chọn tên sách trước");
                return;
            }
            string[] dataToAdd =
            {
                dataGridView1.Rows.Count.ToString(),
                comboBoxStudentName.SelectedItem.ToString(),
                comboBoxBookName.SelectedItem.ToString(),
                dateTimePickerStartDate.Value.ToShortDateString(),
                dateTimePickerStartDate.Value.AddDays(40).ToShortDateString(),
                "0"
            };
            dataGridView1.Rows.Add(dataToAdd);
            comboBoxStudentName.SelectedItem = null;
            comboBoxBookName.SelectedItem = null;
            dateTimePickerStartDate.Value = DateTime.Now;
            dateTimePickerDueDate.Value = DateTime.Now.AddDays(40);
        }

        private void buttonReturnBook_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1)
            {
                MessageBox.Show("abc");
                return;
            }
            DateTime startDate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            int numsOfDay = (int) dateTimePickerDueDate.Value.Subtract(startDate).TotalDays;
            if (numsOfDay < 0)
            {
                MessageBox.Show("Ngày trả không thể nhỏ hơn ngày mượn");
                return;
            }
            dataGridView1.CurrentRow.Cells[4].Value = dateTimePickerDueDate.Value.ToShortDateString();
            dataGridView1.CurrentRow.Cells[5].Value = Math.Max(0, 2000*(numsOfDay-40)).ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { 
                return; 
            }
            if (e.RowIndex == dataGridView1.Rows.Count - 1)
            {
                comboBoxStudentName.SelectedItem = null;
                comboBoxBookName.SelectedItem = null;
                dateTimePickerStartDate.Value = DateTime.Now;
                dateTimePickerDueDate.Value = DateTime.Now.AddDays(40);
                return;
            }
            DataGridViewCellCollection rowData = dataGridView1.Rows[e.RowIndex].Cells;
            comboBoxStudentName.SelectedItem = rowData[1].Value;
            comboBoxBookName.SelectedItem = rowData[2].Value;
            dateTimePickerStartDate.Value = Convert.ToDateTime(rowData[3].Value);
            dateTimePickerDueDate.Value = Convert.ToDateTime(rowData[4].Value);
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {
                List<string> studentsName = new List<string>();
                for (int i = 0; i< dataGridView1.Rows.Count - 1; i++)
                {
                    DataGridViewCellCollection rowData = dataGridView1.Rows[i].Cells;
                    string studentName = rowData[1].Value.ToString();
                    int money = Convert.ToInt32(rowData[5].Value.ToString());
                    if (studentsName.Contains(studentName) || money == 0)
                    {
                        continue;
                    }
                    studentsName.Add(studentName);
                }
                labelOverdue.Text = String.Join("\n", studentsName);

                Dictionary<string, int> books = new Dictionary<string, int>();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DataGridViewCellCollection rowData = dataGridView1.Rows[i].Cells;
                    string bookName = rowData[2].Value.ToString();
                    if (books.ContainsKey(bookName))
                    {
                        books[bookName]++;
                    }
                    else
                    {
                        books.Add(bookName, 1);
                    }
                }
                dataGridView2.Rows.Clear();
                foreach(KeyValuePair<string, int> item in books)
                {
                    dataGridView2.Rows.Add(item.Key, item.Value);
                }
            }
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            double numsOfDay = dateTimePickerDueDate.Value.Subtract(dateTimePickerStartDate.Value).TotalDays;
            labelNumsOfDay.Text = "Số ngày mượn: " + ((int)numsOfDay).ToString() + " ngày";
        }
    }
}
