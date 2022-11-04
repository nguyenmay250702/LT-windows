using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //xóa dữ liệu trong form nhập dữ liệu
        private void delete_data()
        {
            /*
            textBox_msv.Text = "";
            textBox_hoten.Text = "";*/

            dateTimePicker1.Text = "";
            textBox_msv.Clear();
            textBox_hoten.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox_QueQuan.Text = null;
            comboBox_Lop.Text = null;
            comboBox_Khoa.Text = null;
        }


        //kiểm tra thông tin trong control
        private bool test_input_data()
        {
            int test_msv;
            if (textBox_msv.Text == "" || textBox_hoten.Text == "" || comboBox_QueQuan.Text == "" || comboBox_Lop.Text == "" || comboBox_Khoa.Text == "")
            {
                MessageBox.Show("Chua nhap du thong tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Gioi tinh chua xac dinh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(textBox_msv.Text, out test_msv))
            {
                MessageBox.Show("Ma sinh vien chi chua cac chu so", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }

            /*
            else
            {
                int test_msv;
                if (!int.TryParse(textBox_msv.Text, out test_msv))
                {
                    MessageBox.Show("Ma sinh vien chi chua cac chu so", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //kiểm tra xem nếu đã có dữ liệu trong bảng thì kiểm tra tiếp xem msv đó đã tồn tại hay chưa
                        if (dataGridView1.Rows[i].Cells[0].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == textBox_msv.Text)
                            {
                                MessageBox.Show("Ma sinh vien da ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
            */
        }

        //sự kiện click thêm dữ liệu
        private void button1_Click(object sender, EventArgs e)
        {
            if (test_input_data())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //kiểm tra xem nếu đã có dữ liệu trong bảng thì kiểm tra tiếp xem msv đó đã tồn tại hay chưa
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == textBox_msv.Text)
                        {
                            MessageBox.Show("Ma sinh vien da ton tai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string gioi_tinh = (radioButton1.Checked) ? "Nam" : "Nữ";
                dataGridView1.Rows.Add(textBox_msv.Text, textBox_hoten.Text, dateTimePicker1.Text, gioi_tinh, comboBox_QueQuan.Text, comboBox_Lop.Text, comboBox_Khoa.Text);
                delete_data();
            }
        }

        //lấy dữ liệu từ dataGridView lên textbox
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count-1)
            {
                //lưu lại dòng dữ liệu vừa click chọn
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                //đưa dữ liệu vào textbox
                textBox_msv.Text = row.Cells[0].Value.ToString();
                textBox_hoten.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                radioButton1.Checked = (row.Cells[3].Value.ToString() == "Nam") ? true : false;
                radioButton2.Checked = (row.Cells[3].Value.ToString() == "Nữ") ? true : false;
                comboBox_QueQuan.Text = row.Cells[4].Value.ToString();
                comboBox_Lop.Text = row.Cells[5].Value.ToString();
                comboBox_Khoa.Text = row.Cells[6].Value.ToString();

                btn_Sua.Enabled =  true;
                btn_Xoa.Enabled = true;
            }
            else
            {
                delete_data();
                MessageBox.Show("Không thể truy xuất dữ liệu của trường này!!!\nBạn sẽ không thể thay đổi trên trường này", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
                return;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {

            //kiểm tra xem đã chọn dữ liệu để thay đổi chưa, nếu chọn rồi thì thực thiện update dữ liệu trong control vào dattaGridView
            try
            {
                DataGridViewRow rowEdit = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];

                if (test_input_data() && dataGridView1.CurrentCell.RowIndex != dataGridView1.Rows.Count -1)
                {
                    string gio_tinh = (radioButton1.Checked) ? "Nam" : "Nữ";

                    rowEdit.Cells[0].Value = textBox_msv.Text;
                    rowEdit.Cells[1].Value = textBox_hoten.Text;
                    rowEdit.Cells[2].Value = dateTimePicker1.Text;
                    rowEdit.Cells[3].Value = gio_tinh;
                    rowEdit.Cells[4].Value = comboBox_QueQuan.Text;
                    rowEdit.Cells[5].Value = comboBox_Lop.Text;
                    rowEdit.Cells[6].Value = comboBox_Khoa.Text;
                    delete_data();
                    btn_Sua.Enabled=false;
                }
                else if(dataGridView1.CurrentCell.RowIndex == dataGridView1.Rows.Count - 1)
                {
                    MessageBox.Show("Vi tri click chon khong the update du lieu!!!\nHay chon lai vi tri khac", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ban chua chon du lieu de update!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sự kiện nhấn nút xóa dữ liệu
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
                delete_data();
                btn_Xoa.Enabled=false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Khong the xoa truong nay!!!\nHay chon lai truong khac de thuc hien xoa du lieu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Ban chua lua chon du lieu de delete!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
