using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT5_QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private int rowSelected = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void resetForm()
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            dateTimePickerDob.Text = "";
            radioButtonGenderMale.Checked = false;
            radioButtonGenderFemale.Checked = false;
            comboBoxPlaceOrigin.SelectedItem = null;
            comboBoxClass.SelectedItem = null;
            comboBoxMajor.SelectedItem = null;
        }

        private string isInvalidData()
        {
            if (textBoxId.Text.Length == 0)
            {
                return "Mã sinh viên không được để trống";
            }
            if (textBoxName.Text.Length == 0)
            {
                return "Tên sinh viên không được để trống";
            }
            if (!radioButtonGenderFemale.Checked && !radioButtonGenderMale.Checked)
            {
                return "Phải chọn giới tính cho sinh viên";
            }
            if (comboBoxPlaceOrigin.SelectedItem.ToString() == null)
            {
                return "Phải chọn quê quán cho sinh viên";
            }
            if (comboBoxClass.SelectedItem.ToString() == null)
            {
                return "Phải chọn lớp cho sinh viên";
            }
            if (comboBoxMajor.SelectedItem.ToString() == null)
            {
                return "Phải chọn khoa cho sinh viên";
            }
            return "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string invalidMsg = isInvalidData();
            if (invalidMsg != "")
            {
                MessageBox.Show(invalidMsg);
                return;
            }
            string[] dataToAdd =
            {
                textBoxId.Text,
                textBoxName.Text,
                dateTimePickerDob.Text,
                radioButtonGenderMale.Checked ? "Nam" : "Nữ",
                comboBoxPlaceOrigin.SelectedItem.ToString(),
                comboBoxClass.SelectedItem.ToString(),
                comboBoxMajor.SelectedItem.ToString(),
            };
            dataGridView1.Rows.Add(dataToAdd);
            resetForm();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected = e.RowIndex;
            if (rowSelected == dataGridView1.Rows.Count - 1)
            {
                resetForm();
                buttonAdd.Visible = true;
                buttonUpdate.Visible = false;
                buttonDelete.Visible = false;
                return;
            }
            DataGridViewCellCollection rowData = dataGridView1.Rows[rowSelected].Cells;
            textBoxId.Text = (string)rowData[0].Value;
            textBoxName.Text = (string)rowData[1].Value;
            dateTimePickerDob.Text = (string)rowData[2].Value;
            if ((string)rowData[3].Value == "Nam")
            {
                radioButtonGenderMale.Checked = true;
            }
            else
            {
                radioButtonGenderFemale.Checked = true;
            }
            comboBoxPlaceOrigin.Text = (string)rowData[4].Value;
            comboBoxClass.Text = (string)rowData[5].Value;
            comboBoxMajor.Text = (string)rowData[6].Value;

            buttonAdd.Visible = false;
            buttonUpdate.Visible = true;
            buttonDelete.Visible = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string invalidMsg = isInvalidData();
            if (invalidMsg != "")
            {
                MessageBox.Show(invalidMsg);
                return;
            }
            dataGridView1.Rows[rowSelected].Cells[0].Value = textBoxId.Text;
            dataGridView1.Rows[rowSelected].Cells[1].Value = textBoxName.Text;
            dataGridView1.Rows[rowSelected].Cells[2].Value = dateTimePickerDob.Text;
            dataGridView1.Rows[rowSelected].Cells[3].Value = radioButtonGenderMale.Checked ? "Nam" : "Nữ";
            dataGridView1.Rows[rowSelected].Cells[4].Value = comboBoxPlaceOrigin.SelectedItem.ToString();
            dataGridView1.Rows[rowSelected].Cells[5].Value = comboBoxClass.SelectedItem.ToString();
            dataGridView1.Rows[rowSelected].Cells[6].Value = comboBoxMajor.SelectedItem.ToString();

            resetForm();
            buttonAdd.Visible = true;
            buttonUpdate.Visible = false;
            buttonDelete.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(rowSelected);
            resetForm();
            buttonAdd.Visible = true;
            buttonUpdate.Visible = false;
            buttonDelete.Visible = false;
        }
    }
}
