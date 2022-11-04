using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //xóa rỗng giá trị trong control
        private void empty_control()
        {
            txt_hoten.Clear();
            dateTimePicker1.Text = "";
            txt_diachi.Clear();
            txt_dienthoai.Clear();

        }

        //kiểm tra xem trong listview đã có dữ liệu chưa
        private bool test_data_listview()
        {
            if(listView1.Items.Count > 0)
            {
                return true;
            }
            return false;
        }

        //kiểm tra thông tin control
        private bool test_value_control()
        {
            int sdt;
            if(txt_hoten.Text.Trim() == "" || txt_dienthoai.Text.Trim() =="" || txt_diachi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa điền đủ thông tin", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else if(!int.TryParse(txt_dienthoai.Text, out sdt))
            {
                MessageBox.Show("Số điện thoại chỉ gồm các chữ số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }


        //lấy thông tin từ listview lên control
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* if(listView1.SelectedItems.Count > 0)
             {
                  txt_hoten.Text = listView1.SelectedItems[0].SubItems[0].Text;
                  dateTimePicker1.Value = Convert.ToDateTime(listView1.SelectedItems[0].SubItems[1].Text);
                  txt_diachi.Text = listView1.SelectedItems[0].SubItems[2].Text;
                  txt_dienthoai.Text = listView1.SelectedItems[0].SubItems[3].Text;
             }
             */

            //listView1.FocusedItem.Index lấy ra chỉ số dòng được chọn
            //nếu không có điều kiện thì khi nhấn nút xóa dữ liệu => dữ liệu đc xóa => dòng đc chọn đc xóa theo
            //=> lệnh "listView1.FocusedItem.Index" lấy ra chỉ số dòng đc chọn sẽ trả về -1 => lỗi (không còn dòng đc chọn -> thể lấy chỉ số dòng đc chọn)
            if (listView1.FocusedItem.Index != -1)
            {
                txt_hoten.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text;
                dateTimePicker1.Value = Convert.ToDateTime(listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text);
                txt_diachi.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text;
                txt_dienthoai.Text = listView1.Items[listView1.FocusedItem.Index].SubItems[3].Text;

            }
        }


        //sự kiện xóa dữ liệu trong listview
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (test_data_listview()==false)
            {
                MessageBox.Show("CSDL đang rỗng.\nHiện tại chưa có dữ liệu để xóa thông tin!!!\nVui lòng thêm dữ liệu trước khi thực hiện xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Ban chưa chọn dữ liệu để xóa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listView1.Items.RemoveAt(listView1.FocusedItem.Index);
                empty_control();
            }
        }


        //sự kiện nhấn nút thêm thông tin
        private void btn_them_click(object sender, EventArgs e)
        {
            //kiểm tra xem số điện thoại đã có chưa
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(txt_dienthoai.Text == listView1.Items[i].SubItems[3].Text)
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (test_value_control())
            {
                
                ListViewItem item = listView1.Items.Add(txt_hoten.Text.Trim());
                item.SubItems.Add(dateTimePicker1.Value.ToShortDateString());
                item.SubItems.Add(txt_diachi.Text.Trim());
                item.SubItems.Add(txt_dienthoai.Text.Trim());
                
                empty_control();
            }
        }


        //sự kiện click nút sửa thông tin
        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (test_data_listview() == false)
            {
                MessageBox.Show("CSDL đang rỗng.\nHiện tại chưa có dữ liệu để chỉnh sửa thông tin!!!\nVui lòng thêm dữ liệu trước khi chỉnh sửa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (listView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Ban chưa chọn dữ liệu để sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (test_value_control())
            {
                //listView1.FocusedItem.Index lấy ra số lượng item được chọn
                listView1.Items[listView1.FocusedItem.Index].SubItems[0].Text = txt_hoten.Text;
                listView1.Items[listView1.FocusedItem.Index].SubItems[1].Text = dateTimePicker1.Text;
                listView1.Items[listView1.FocusedItem.Index].SubItems[2].Text = txt_diachi.Text;
                listView1.Items[listView1.FocusedItem.Index].SubItems[3].Text = txt_dienthoai.Text;

                empty_control();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
