using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_2_sd_List_luuDuLieu_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //khai báo: ds là danh sách (kiểu list), mỗi phần tử trong danh sách có kiểu dữ liệu là sinh viên
        private List<SinhVien> ds;

        private void Form1_Load(object sender, EventArgs e)
        { 
            //khởi tạo ds(cấp phát bộ nhớ cho danh sách ds)
            ds = new List<SinhVien>();
            SinhVien sv1 = new SinhVien("002", "NV Hải", new DateTime(2001,11,23), true, "Hà Nam","62TH3", "Xây Dựng");
            SinhVien sv2 = new SinhVien("003", "NT Vân", new DateTime(2000, 3, 21), false, "Hà Nội", "62TH1", "CNTT");

            ds.Add(sv1);
            ds.Add(sv2);

            //hiển thị dữ liệu khi chạy trương trình
            print();
        }

        
        //Làm rỗng dữ liệu trong control
        private void delete_data_control()
        {
            txt_msv.Clear();
            txt_hoten.Clear();
            dateTimePicker1.Value = DateTime.Now;
            radioButton_nam.Checked = false;
            radioButton_nu.Checked = false;
            comboBox_quequan.SelectedIndex = -1;
            comboBox_lop.SelectedIndex = -1;
            comboBox_khoa.SelectedIndex = -1;
        }

        //Kiểm tra dữ liệu nhận vào
        private bool test_data_control()
        {
            int test_msv;
            if(txt_msv.Text == "" || txt_hoten.Text == "" || comboBox_quequan.Text == "" || comboBox_lop.Text == "" || comboBox_khoa.Text == "" ||(!radioButton_nam.Checked && !radioButton_nu.Checked))
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(!int.TryParse(txt_msv.Text, out test_msv))
            {
                MessageBox.Show("Mã sinh viên chỉ chứa các chữ số!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        //Hiển thị
        private void print()
        {
            //hiển thị danh sách các sv khi chạy chương trình
            foreach (SinhVien sv in ds)
            {
                dataGridView1.Rows.Add(sv.MaSV, sv.HoTen, sv.NgaySinh.ToShortDateString(), (sv.GioiTinh)? "Nam" : "Nữ", sv.QueQuan, sv.Lop, sv.Khoa);
            }

            dataGridView1.ClearSelection();
        }


        //lấy dữ liệu từ dataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index != -1)
            {
                txt_msv.Text = ds[index].MaSV;
                txt_hoten.Text = ds[index].HoTen;
                dateTimePicker1.Value = ds[index].NgaySinh;
                radioButton_nam.Checked = ds[index].GioiTinh? true : false;
                radioButton_nu.Checked = ds[index].GioiTinh? false : true;
                comboBox_quequan.Text = ds[index].QueQuan;
                comboBox_lop.Text = ds[index].Lop;
                comboBox_khoa.Text = ds[index].Khoa;
            }
            else
            {
                //reset lại control
                delete_data_control();
            }
        }


        //thêm dữ liệu
        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach(SinhVien sv in ds)
            {
                if(txt_msv.Text == sv.MaSV)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (test_data_control())
            {
                bool gioitinh = radioButton_nam.Checked ? true:false;
                SinhVien sv_add = new SinhVien(txt_msv.Text, txt_hoten.Text, dateTimePicker1.Value, gioitinh, comboBox_quequan.Text, comboBox_lop.Text, comboBox_khoa.Text);
                ds.Add(sv_add);

                //xóa dữ liệu trên control
                delete_data_control();

                //xóa hết hàng trong dataGridView
                dataGridView1.Rows.Clear();

                //in lạ dữ liệu mới trong danh sách ds(gồm cả sinh viên vừa thêm) lên dataGridView
                print();
            }
        }


        //sửa dữ liệu
        private void btn_sua_Click(object sender, EventArgs e)
        {
            int index;
            try
            {
                index = dataGridView1.SelectedCells[0].RowIndex;
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (test_data_control())
            {
                ds[index].MaSV = txt_msv.Text;
                ds[index].Lop = txt_hoten.Text;
                ds[index].NgaySinh = dateTimePicker1.Value;
                ds[index].GioiTinh = (radioButton_nam.Checked) ? true:false;
                ds[index].QueQuan = comboBox_quequan.Text;
                ds[index].Lop = comboBox_lop.Text;
                ds[index].Khoa = comboBox_quequan.Text;

                //xóa dữ liệu trên control
                delete_data_control();

                //xóa hết hàng trong dataGridView
                dataGridView1.Rows.Clear();

                //in lạ dữ liệu mới trong danh sách ds(gồm cả sinh viên vừa thêm) lên dataGridView
                print();
            }
        }

        //xóa dữ liệu
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int index;

            try
            {
                index = dataGridView1.SelectedCells[0].RowIndex;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ds.RemoveAt(index);

            //xóa dữ liệu trên control
            delete_data_control();

            //xóa hết hàng trong dataGridView
            dataGridView1.Rows.Clear();

            //in lạ dữ liệu mới trong danh sách ds(gồm cả sinh viên vừa thêm) lên dataGridView
            print();
        }
    }
}
