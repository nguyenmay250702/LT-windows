using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_2_sd_danhSach_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Kiểm tra dữ liệu trong control
        private bool test_data_control()
        {
            int test_msv;
            if(txt_msv.Text == "" || txt_hoten.Text =="" || comboBox_quequan.Text == "" || comboBox_lop.Text == "" || comboBox_khoa.Text == "" || (!radioButton_nam.Checked && !radioButton_nu.Checked))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(txt_msv.Text, out test_msv))
            {
                MessageBox.Show("Mã sinh viên chỉ chứa các chữ số!!!\nVui lòng kiểm tra lại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }


        //xóa rỗng dữ liệu trong control
        private void delete_data_control()
        {
            txt_msv.Clear();
            txt_hoten.Clear();
            dateTimePicker1.Text = "";
            radioButton_nam.Checked = false;
            radioButton_nu.Checked = false;
            comboBox_quequan.Text = null;
            comboBox_lop.Text = null;
            comboBox_khoa.Text = null;

            dataGridView1.ClearSelection();     //xóa sự lựa chọn hiện tại(bằng cách bỏ các ô đã chọn)
            dataGridView1.CurrentCell = null;   //đặt lại ô được chọn bằng null
        }


        //lấy data từ dataGridView lên control tương ứng
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //test.Text = e.RowIndex + " ; " + e.ColumnIndex;
            if(e.RowIndex != -1)
            {
                txt_msv.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_hoten.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                radioButton_nam.Checked = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nam")? true : false;
                radioButton_nu.Checked = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() == "Nữ") ? true : false;
                comboBox_quequan.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                comboBox_lop.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox_khoa.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
        }

        //Thêm data vào DataGridView
        private void btn_them_Click(object sender, EventArgs e)
        {   
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (txt_msv.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Mã sinh viên này đã tồn tại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_msv.Focus();
                        return;
                    }
                }
            }
            string Value_gioiTinh = (radioButton_nam.Checked)? "Nam":"Nữ";
            if (test_data_control())
            {
                dataGridView1.Rows.Add(txt_msv.Text, txt_hoten.Text, dateTimePicker1.Text, Value_gioiTinh, comboBox_quequan.Text, comboBox_lop.Text, comboBox_khoa.Text);
                delete_data_control();
            }
        }

        //sửa lại thông tin data có trong dataGridView
        private void btn_sua_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang rỗng!!!\nKhông thể thực hiện thao tác 'Chỉnh sửa' dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //kiểm tra xem đã chọn dữ liệu chưa
            //dataGridView1.CurrentCell: (lấy ra ô hiện tại đang hoạt động) trả về ColumnIndex và RowIndex của cell đc chọn (DataGridView TextBoxCell{ColumnIndex = ?, RowIndex = ?}), nếu không thì trả về null
            if (dataGridView1.CurrentCell != null)
            {
                if (test_data_control())
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (txt_msv.Text == dataGridView1.Rows[i].Cells[0].Value.ToString() && i!=dataGridView1.CurrentCell.RowIndex)
                            {
                                MessageBox.Show("Mã sinh viên này đã tồn tại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt_msv.Focus();
                                return;
                            }
                        }
                    }
                    //test.Text = dataGridView1.CurrentCell.ToString();

                    DataGridViewRow row_update = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];
                    row_update.Cells[0].Value = txt_msv.Text;
                    row_update.Cells[1].Value = txt_hoten.Text;
                    row_update.Cells[2].Value = dateTimePicker1.Text;
                    row_update.Cells[3].Value = (radioButton_nam.Checked == true) ? "Nam" : "Nữ";
                    row_update.Cells[4].Value = comboBox_quequan.Text;
                    row_update.Cells[5].Value = comboBox_lop.Text;
                    row_update.Cells[6].Value = comboBox_khoa.Text;
                    delete_data_control();
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện thao tác 'Sửa'!!!\nVui lòng chọn dữ liệu trong dataGridView để chỉnh 'Sửa'!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang rỗng!!!\nKhông thể thực hiện thao tác 'Xóa' dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView1.CurrentCell != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
                delete_data_control();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để thực hiện thao tác 'Xóa'!!!\nVui lòng chọn dữ liệu trong dataGridView để thực hiện 'Xóa'!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
