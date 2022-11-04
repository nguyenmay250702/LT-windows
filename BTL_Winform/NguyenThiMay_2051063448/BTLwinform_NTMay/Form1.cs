
//Họ tên: Nguyễn Thị Mây
//Lớp   : 62TH1
//MSV   : 2051063448

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

namespace BTLwinform_NTMay
{
    public partial class Form1 : Form
    {

        //chuỗi kết nối
        string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLCuaHangSach;Integrated Security=True";

        //Đối tượng kết nối
        SqlConnection sqlCon = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Khởi tạo ra đối tượng kết nối và chuyền vào 1 chuỗi kết nối(kết nối tới CSDL)
            sqlCon = new SqlConnection(strCon);
            sqlCon.Open();

            //tải dữ liệu lên dataGridView tương ứng
            UploadData_To_DataGridView("select * from Sach", dataGridView1);
            UploadData_To_DataGridView("select maHD as 'Mã hóa đơn', maSach as 'Mã sách', soLuongBan as 'Số lượng bán', ngayBan as 'Ngày bán', thanhTien as 'Thành tiền' from HoaDon", dataGridView3);

            //đặt lại tên tiêu đề của các cột của dataGridView1(Danh sách sản phẩm) sau khi đã lấy dữ liệu từ CSDL
            rename_column(dataGridView1);

            disableSort(dataGridView1);
            disableSort(dataGridView3);

            sqlCon.Close();
        }

        //tải dữ liệu lên dataGridView
        private void UploadData_To_DataGridView(string queryCommand, DataGridView dataGridView_n)
        {
            //khởi tạo dataAdapter lấy dữ liệu truy vấn từ dataBase                                                                         
            SqlDataAdapter adapter = new SqlDataAdapter(queryCommand, sqlCon);

            // khởi tạo 1 bảng "dtSach" trong dataSet () (khởi tại bảng để chứa dữ liệu)
            DataTable table = new DataTable();

            // đổ dữ liệu truy vấn được vào bảng(thêm các dòng trong dataSet sao cho khớp với các hàng trong dataGridView1)
            adapter.Fill(table);

            // hiển thị dữ liệu từ bảng lên giao diện (hiểu thị vào dataGridView) thông qua dataTable
            dataGridView_n.DataSource = table;     
            dataGridView_n.ClearSelection();
        }

        //tải dữ liệu lên combobox
        private void upLoadData_combobox(string queryCommand, ComboBox cbb_n, string name_displayMember)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(queryCommand,sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb_n.DataSource = table;

            //thiết lập trường dữ liệu trong danh sách sổ xuống là cột phân loại sách;
            cbb_n.DisplayMember = name_displayMember;
            cbb_n.SelectedIndex = -1;
        }

        //vô hiệu hóa không làm thay đổi thứ tự dữ liệu khi click vào tiêu đề
        private void disableSort(DataGridView dataGridView_n)
        {
            foreach (DataGridViewColumn column in dataGridView_n.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        //xóa dữ liệu trong control (trong quản lý kho sách)
        private void delete_data_control_ks()
        {
            txt_ks_maSach.Clear();
            txt_ks_tenSach.Clear();
            txt_ks_tacGia.Clear();
            txt_ks_nhaXuatBan.Clear();
            txt_ks_phanLoai.Clear();
            txt_ks_giaBan.Clear();
            txt_ks_soLuong.Clear();

            dataGridView1.ClearSelection();
        }


        //Kiểm tra dữ liệu trong control (trogn quản lý kho sách)
        private bool checkData_Control_ks()
        {
            try
            {
                if (txt_ks_maSach.Text.Trim() == "" || txt_ks_tenSach.Text.Trim() == "" || txt_ks_tacGia.Text.Trim() == "" || txt_ks_nhaXuatBan.Text.Trim() == "" || txt_ks_phanLoai.Text.Trim() == "" || txt_ks_giaBan.Text.Trim() == "" || txt_ks_soLuong.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin của sách!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txt_ks_maSach.Text.Trim().Length > 10)
                {
                    MessageBox.Show("Mã sách chỉ bao gồm 10 kí tự!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txt_ks_tenSach.Text.Trim().Length > 100)
                {
                    MessageBox.Show("Tên sách chỉ gồm 100 kí tự!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txt_ks_tacGia.Text.Trim().Length > 100)
                {
                    MessageBox.Show("Tên tác giả chỉ bao gồm 100 kí tự!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txt_ks_nhaXuatBan.Text.Trim().Length > 100)
                {
                    MessageBox.Show("Tên nhà xuất bản chỉ bao gồm 100 kí tự!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToSingle(txt_ks_giaBan.Text) <= 0)
                {
                    MessageBox.Show("Giá bán sách phải >0 !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToInt32(txt_ks_soLuong.Text) < 0)
                {
                    MessageBox.Show("Số lượng sách phải >=0 !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("-Số lượng sản phẩn phải là số nguyên >=0\n-Giá bán phải có kiểu float và >0!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        //đổi tên column cho bảng danh sách sp và Kết quả tìm kiếm
        private void rename_column(DataGridView dataGridView_n)
        {
            dataGridView_n.Columns[0].HeaderText = "Mã sách";
            dataGridView_n.Columns[1].HeaderText = "Tên sách";
            dataGridView_n.Columns[2].HeaderText = "Tác giả";
            dataGridView_n.Columns[3].HeaderText = "Nhà xuất bản";
            dataGridView_n.Columns[4].HeaderText = "Phân loại";
            dataGridView_n.Columns[5].HeaderText = "Giá bán";
            dataGridView_n.Columns[6].HeaderText = "Số lượng";
        }


        //kiểm tra dữ liệu có tồn tại hay không(vd: mã sách, mã hóa đơn,...)
        private bool check_for_duplicate_information(string sqlquery_command)
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(sqlquery_command, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                sqlCon.Close();
                return true;
            }
            else
            {
                sqlCon.Close();
                return false;
            }
        }




        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ QL KHO SÁCH ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        
        //lấy dữ liệu trong dataGridView1 lên control(lấy thông tin sách trong bảng danh sách sp lên các control tương ứng)
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index != -1)
            {
                txt_ks_maSach.Text = dataGridView1.Rows[index].Cells[0].Value.ToString().Trim();
                txt_ks_tenSach.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txt_ks_tacGia.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txt_ks_nhaXuatBan.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txt_ks_phanLoai.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                txt_ks_giaBan.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                txt_ks_soLuong.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            }
            else
            {
                delete_data_control_ks();
            }
        }


        //thêm sách
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkData_Control_ks())
            {
                //Kiểm tra mã sách có bị trùng hay không
                string sqlquery_command = "select* from Sach where (maSach = '" + txt_ks_maSach.Text + "')";

                if (check_for_duplicate_information(sqlquery_command) == false)     //nếu mã sách chưa có thì thực hiện thêm dữ liệu sách mới vào CSDL
                {
                    //thêm dữ liệu
                    sqlCon.Open();
                    string giaBan = txt_ks_giaBan.Text.Trim().Replace(",", ".");
                    string data_insert = "insert into Sach values('" + txt_ks_maSach.Text.Trim() + "', N'" + txt_ks_tenSach.Text.Trim() + "', N'" + txt_ks_tacGia.Text.Trim() +
                                                                  "', N'" + txt_ks_nhaXuatBan.Text.Trim() + "', N'" + txt_ks_phanLoai.Text.Trim() + "'," + giaBan +
                                                                  ", " + txt_ks_soLuong.Text.Trim() + ")";
                    SqlCommand cmd = new SqlCommand(data_insert, sqlCon);
                    cmd.ExecuteNonQuery();    

                    UploadData_To_DataGridView("select * from Sach", dataGridView1);
                    delete_data_control_ks();
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Mã sách đã tồn tại!!!\nVui lòng chọn mã sách khác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //sửa thông tin sách
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hệ thống đang rỗng!!!\n- Không có dữ liệu để thực hiện thao tác chỉnh sửa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView1.SelectedRows.Count >0)
            {
                if (checkData_Control_ks())
                {
                    string sqlquery_command, bookcode_value_selectCell, giaBan, data_update_Sach;

                    //kiểm tra mã sách sau khi sửa có bị trùng hay không
                    sqlquery_command = "select* from Sach where (maSach = '" + txt_ks_maSach.Text + "')";
                    bookcode_value_selectCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();

                    if (check_for_duplicate_information(sqlquery_command) && txt_ks_maSach.Text.Trim() != bookcode_value_selectCell)
                    {
                        MessageBox.Show("Mã sách đã tồn tại!!!\nVui lòng chọn mã sách khác", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        sqlquery_command = "select * from HoaDon where (maSach = '" + bookcode_value_selectCell + "')";
                        giaBan = txt_ks_giaBan.Text.Trim().Replace(",", ".");
                        data_update_Sach = "update Sach " +
                                           "set maSach = '" + txt_ks_maSach.Text.Trim() + "', tenSach = N'" + txt_ks_tenSach.Text.Trim() + "', tacGia = N'" + txt_ks_tacGia.Text.Trim() +
                                                         "', nhaXuatBan = N'" + txt_ks_nhaXuatBan.Text.Trim() + "', phanLoai = N'" + txt_ks_phanLoai.Text.Trim() +
                                                         "', giaBan = " + giaBan + ", soLuong = " + txt_ks_soLuong.Text +
                                           "where( maSach = '" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString() + "')";
                        
                        //kiểm tra xem vị trí cần sửa mã sách có trong bảng hóa đơn không nếu có -> sửa cả mã sách trong bảng hóa đơn
                        if (check_for_duplicate_information(sqlquery_command))          
                        {
                            DialogResult luaChon = MessageBox.Show("Sản phẩm đang thực hiện thao tác cập nhật thông tin có 'mã sách' nằm trong bảng hóa đơn\n- Nếu bạn cập nhật thông tin thì mã sách trong bảng hóa đơn cũng sẽ thay đổi theo", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (luaChon == DialogResult.Yes)
                            {
                                sqlCon.Open();
                                SqlCommand cmd = new SqlCommand(data_update_Sach, sqlCon);
                                cmd.ExecuteNonQuery();
                                sqlCon.Close();
                            }
                        }
                        else
                        {
                            sqlCon.Open();
                            SqlCommand cmd = new SqlCommand(data_update_Sach, sqlCon);
                            cmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        UploadData_To_DataGridView("select * from Sach", dataGridView1);
                        UploadData_To_DataGridView("select * from HoaDon", dataGridView3);
                        delete_data_control_ks();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //xóa sách
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hệ thống đang rỗng!!!\n- Không có dữ liệu để thực hiện thao tác xóa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dataGridView1.SelectedRows.Count > 0)
            {
                //lấy ra mã sách  của sách đang muốn xóa
                string code_delete = txt_ks_maSach.Text;

                //kiểm tra xem sách muốn xóa có trong hóa đơn không
                if (check_for_duplicate_information("select * from HoaDon where (maSach = '" + code_delete + "')"))
                {
                    DialogResult luachon = MessageBox.Show("Sách bạn muốn xóa có trong bảng hóa đơn!!!\nNếu vẫn tiếp tục xóa thì hóa đơn chứa sách này cũng sẽ bị xóa theo", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if(luachon == DialogResult.Yes)
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand("delete Sach where maSach = '" + code_delete + "'", sqlCon);
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
                else
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand("delete Sach where maSach = '" + code_delete + "'", sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                
                UploadData_To_DataGridView("select * from Sach", dataGridView1);
                UploadData_To_DataGridView("select * from HoaDon", dataGridView3);
                delete_data_control_ks();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ QL BÁN SÁCH ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView3.ClearSelection();

            //upload dữ liệu lên cbb
            upLoadData_combobox("select phanLoai from Sach group by phanLoai", cbb_bs_phanLoai, "phanLoai");
            upLoadData_combobox("select tacGia from Sach group by tacGia", cbb_bs_tacGia, "tacGia");
            upLoadData_combobox("select nhaXuatBan from Sach group by nhaXuatBan", cbb_bs_nhaXuatBan, "nhaXuatBan");
        }

        //tìm kiếm sản phẩm

        //C1 Nhấn button
        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            /*
            string queryCommand;

            if (cbb_bs_phanLoai.Text.Trim() != "" && cbb_bs_tacGia.Text.Trim() == "" && cbb_bs_nhaXuatBan.Text.Trim() == "")
            {
                queryCommand = "select * " +
                               "from Sach " +
                               "where (phanLoai = N'" + cbb_bs_phanLoai.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() == "" && cbb_bs_tacGia.Text.Trim() != "" && cbb_bs_nhaXuatBan.Text.Trim() == "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (tacGia = N'" + cbb_bs_tacGia.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() == "" && cbb_bs_tacGia.Text.Trim() == "" && cbb_bs_nhaXuatBan.Text.Trim() != "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (nhaXuatBan = N'" + cbb_bs_nhaXuatBan.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() != "" && cbb_bs_tacGia.Text.Trim() != "" && cbb_bs_nhaXuatBan.Text.Trim() == "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (phanLoai = N'" + cbb_bs_phanLoai.Text.Trim() + "') and (tacGia = N'" + cbb_bs_tacGia.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() != "" && cbb_bs_tacGia.Text.Trim() == "" && cbb_bs_nhaXuatBan.Text.Trim() != "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (phanLoai = N'" + cbb_bs_phanLoai.Text.Trim() + "') and (nhaXuatBan = N'" + cbb_bs_nhaXuatBan.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() == "" && cbb_bs_tacGia.Text.Trim() != "" && cbb_bs_nhaXuatBan.Text.Trim() != "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (tacGia = N'" + cbb_bs_tacGia.Text.Trim() + "') and (nhaXuatBan = N'" + cbb_bs_nhaXuatBan.Text.Trim() + "')";
            }
            else if (cbb_bs_phanLoai.Text.Trim() != "" && cbb_bs_tacGia.Text.Trim() != "" && cbb_bs_nhaXuatBan.Text.Trim() != "")
            {
                queryCommand =  "select * " +
                                "from Sach " +
                                "where (phanLoai = N'" + cbb_bs_phanLoai.Text.Trim() + "') and (tacGia = N'" + cbb_bs_tacGia.Text.Trim() + "') and (nhaXuatBan = N'" + cbb_bs_nhaXuatBan.Text.Trim() + "')";
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UploadData_To_DataGridView(queryCommand, dataGridView2);
            rename_column(dataGridView2);
            */
        }

        //C2


        //xóa dữ liệu trong control (quản lý bán sách)
        private void delete_data_control_bs()
        {
            txt_bs_maHoaDon.Clear();
            txt_bs_maSach.Clear();
            txt_bs_soLuongBan.Clear();
            date_bs_ngayBan.Text = DateTime.Now.ToShortDateString();

            dataGridView3.ClearSelection();
        }


        //Kiểm tra dữ liệu trong control(quản lý bán sách)
        private bool checkData_Control_bs()
        {
            try
            {
                if (txt_bs_maHoaDon.Text.Trim() == "" || txt_bs_maSach.Text.Trim() == "" || txt_bs_soLuongBan.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin cho hóa đơn!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (txt_bs_maHoaDon.Text.Trim().Length > 10 || txt_bs_maHoaDon.Text.Trim().Length > 10)
                {
                    MessageBox.Show("Mã hóa đơn và mã sách chỉ chứa <=10 kí tự!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToInt32(txt_bs_soLuongBan.Text.Trim()) <= 0)
                {
                    MessageBox.Show("Số lượng cần thanh toán phải >0!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Số lượng cần thanh toán phải là số nguyên!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //lấy dữ liệu trong dataGridView3 lên control trong quản lý bán sách
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index != -1)
            {
                txt_bs_maHoaDon.Text = dataGridView3.Rows[index].Cells[0].Value.ToString().Trim();
                txt_bs_maSach.Text = dataGridView3.Rows[index].Cells[1].Value.ToString().Trim();
                txt_bs_soLuongBan.Text = dataGridView3.Rows[index].Cells[2].Value.ToString();
                date_bs_ngayBan.Text = dataGridView3.Rows[index].Cells[3].Value.ToString();
            }
        }


        //tạo hóa đơn
        private void btn_taoHD_Click(object sender, EventArgs e)
        {
            if (checkData_Control_bs())
            {
                    //Kiểm tra mã hóa đơn đã có trong bảng hóa đơn chưa
                    if (check_for_duplicate_information("select maHD from HoaDon where (maHD = '" + txt_bs_maHoaDon.Text + "')"))
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại!!!\nVui lòng chọn mã hóa đơn khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //giá bán của sản phẩm cần thanh toán và số lượng tồn kho của sp trc và sau khi bán
                        float giaBan;
                        int soLuongTon_cu, soLuongTon_moi;

                        //kiểm tra xem mã sản phẩm cần thanh toán có tồn tại hay không
                        sqlCon.Open();
                        SqlCommand sqlCommand_maSach = new SqlCommand("select * from Sach where (maSach = '" + txt_bs_maSach.Text.Trim() + "')", sqlCon);
                        SqlDataReader reader_maSach = sqlCommand_maSach.ExecuteReader();
                        if (reader_maSach.Read() == false)
                        {
                            MessageBox.Show("Mã sách cần thanh toán không tồn tại!!!\nVui lòng chọn mã sách khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            sqlCon.Close();
                        }
                        else
                        {
                            giaBan = Convert.ToSingle(reader_maSach["giaBan"]);
                            soLuongTon_cu = Convert.ToInt32(reader_maSach["soLuong"]);
                            sqlCon.Close();

                            //kiểm tra xem số lượng sản phẩm cần thanh toán có đủ không
                            if (check_for_duplicate_information("select * from Sach where (soLuong >= " + Convert.ToInt32(txt_bs_soLuongBan.Text) + ") and (maSach = '" + txt_bs_maSach.Text + "')"))
                            {
                                SqlCommand cmd;

                                //thêm hóa đơn mới vào CSDL
                                sqlCon.Open();
                                
                                float thanhTien = Convert.ToInt32(txt_bs_soLuongBan.Text) * giaBan;
                                string sql_insert_HD = "insert into HoaDon values ('" + txt_bs_maHoaDon.Text.Trim() + "', '" + txt_bs_maSach.Text.Trim() + "', '" + txt_bs_soLuongBan.Text + "','" + date_bs_ngayBan.Text + "','" + thanhTien + "')";
                                cmd = new SqlCommand(sql_insert_HD, sqlCon);
                                cmd.ExecuteNonQuery();
                                UploadData_To_DataGridView("select maHD as 'Mã hóa đơn', maSach as 'Mã sách', soLuongBan as 'Số lượng bán', ngayBan as 'Ngày bán', thanhTien as 'Thành tiền' from HoaDon", dataGridView3);


                                //Cập nhật lại số lượng sách tồn kho trong CSDL
                                soLuongTon_moi = soLuongTon_cu - Convert.ToInt32(txt_bs_soLuongBan.Text);
                                string sql_update_soLuongTon = "update Sach set soLuong = " + soLuongTon_moi + " where (maSach = '" + txt_bs_maSach.Text + "')";
                                cmd = new SqlCommand(sql_update_soLuongTon, sqlCon);
                                cmd.ExecuteNonQuery();
                                UploadData_To_DataGridView("select * from Sach", dataGridView1);
                                sqlCon.Close();

                                //reset lai dữ liệu của control
                                delete_data_control_bs();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng sách tồn kho của sản phẩm hiện tại không đủ để thực hiện thanh toán!!!\nVui lòng chọn lại số lượng cần thanh toán", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
            }
        }


        //sửa hóa đơn
        private void btn_suaHD_Click(object sender, EventArgs e)
        {
            //string sqlcommand_update_HD = "update HoaDon set maHD = '" + txt_bs_maHoaDon.Text + "', maSach = '" + txt_bs_maSach.Text + "', soLuongBan = " + txt_bs_soLuongBan.Text + ", ngayBan = " + date_bs_ngayBan.Value + ", thanhTien = " +
            if(dataGridView3.SelectedRows.Count > 0)
            {
                if (checkData_Control_bs())
                {
                    //Kiểm tra mã hóa đơn đã có trong bảng hóa đơn chưa
                    if (check_for_duplicate_information("select maHD from HoaDon where (maHD = '" + txt_bs_maHoaDon.Text.Trim() + "')") && txt_bs_maHoaDon.Text.Trim() != dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim())
                    {
                        MessageBox.Show("Mã hóa đơn đã tồn tại!!!\nVui lòng chọn mã hóa đơn khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_bs_maHoaDon.Focus();
                    }
                    else
                    {
                        //giá bán của sản phẩm cần thanh toán và số lượng tồn kho của sp trc và sau khi bán
                        float giaBan;
                        int soLuongTon_cu, soLuongTon_moi;

                        //kiểm tra xem mã sách cần thanh toán có tồn tại hay không
                        sqlCon.Open();
                        SqlCommand sqlCommand_maSach = new SqlCommand("select * from Sach where (maSach = '" + txt_bs_maSach.Text + "')", sqlCon);
                        SqlDataReader reader_maSach = sqlCommand_maSach.ExecuteReader();
                        if (reader_maSach.Read() == false)
                        {
                            txt_bs_maSach.Focus();
                            MessageBox.Show("Mã sách cần thanh toán không tồn tại!!!\nVui lòng chọn mã sách khác.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            sqlCon.Close();
                        }
                        else
                        {
                            giaBan = Convert.ToSingle(reader_maSach["giaBan"]);
                            soLuongTon_cu = Convert.ToInt32(reader_maSach["soLuong"]) + Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[2].Value);
                            sqlCon.Close();

                            //kiểm tra xem số lượng sản phẩm cần thanh toán có đủ không
                            if (soLuongTon_cu >= Convert.ToInt32(txt_bs_soLuongBan.Text))
                            {
                                DialogResult luachon = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin hóa đơn không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if(luachon == DialogResult.Yes)
                                {
                                    SqlCommand cmd;

                                    //thêm hóa đơn mới vào CSDL
                                    sqlCon.Open();
                                    float thanhTien = Convert.ToInt32(txt_bs_soLuongBan.Text) * giaBan;
                                    string maHD_cu = dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString();
                                    string sql_update_HD = "update HoaDon " +
                                                           "set maHD = '" + txt_bs_maHoaDon.Text.Trim() + "', maSach = '" + txt_bs_maSach.Text.Trim() + "', soLuongBan = " + txt_bs_soLuongBan.Text + ", ngayBan = '" + date_bs_ngayBan.Text + "', thanhTien = " + thanhTien + 
                                                           " where (maHD = '"+ maHD_cu + "')";
                                    cmd = new SqlCommand(sql_update_HD, sqlCon);
                                    cmd.ExecuteNonQuery();
                                    UploadData_To_DataGridView("select maHD as 'Mã hóa đơn', maSach as 'Mã sách', soLuongBan as 'Số lượng bán', ngayBan as 'Ngày bán', thanhTien as 'Thành tiền' from HoaDon", dataGridView3);


                                    //Cập nhật lại số lượng sách tồn kho trong CSDL
                                    soLuongTon_moi = soLuongTon_cu - Convert.ToInt32(txt_bs_soLuongBan.Text);
                                    string sql_update_soLuongTon = "update Sach set soLuong = " + soLuongTon_moi + " where (maSach = '" + txt_bs_maSach.Text + "')";
                                    cmd = new SqlCommand(sql_update_soLuongTon, sqlCon);
                                    cmd.ExecuteNonQuery();
                                    UploadData_To_DataGridView("select * from Sach", dataGridView1);
                                    sqlCon.Close();

                                }
                                //reset data control
                                delete_data_control_bs();
                            
                            }
                            else
                            {
                                txt_bs_soLuongBan.Focus();
                                MessageBox.Show("Số lượng sách tồn kho của sản phẩm hiện tại không đủ để thực hiện thanh toán!!!\nVui lòng chọn lại số lượng cần thanh toán", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn để thực hiện thao tác chỉnh sửa !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //xóa hóa đơn
        private void btn_xoaHD_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count >0)
            {
                DialogResult luachon = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này đi không?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (luachon == DialogResult.Yes)
                {
                    sqlCon.Open();
                    var soLuongTon_old = new SqlCommand("select soLuong from Sach where maSach = '" + dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[1].Value + "'", sqlCon).ExecuteScalar();
                    sqlCon.Close();

                    int soLuongTon_new = Convert.ToInt32(soLuongTon_old) + Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[2].Value);

                    string sqlCommand_deleteHD = "delete HoaDon where maHD = '" + dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value + "'";
                    string sqlCommand_updateSach = "update Sach set soLuong = " + soLuongTon_new + "where maSach = '" + dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[1].Value + "'";
                    SqlCommand cmd;

                    sqlCon.Open();

                    //xóa hóa đơn
                    cmd = new SqlCommand(sqlCommand_deleteHD, sqlCon);
                    cmd.ExecuteNonQuery();

                    //update lại số lượng của sách trong bảng Sach
                    cmd = new SqlCommand(sqlCommand_updateSach, sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();

                    //xóa dữ liệu trong control
                    delete_data_control_bs();

                    //hiển thị lại dữ liệu mới của Hóa Đơn và Sách ra màn hình
                    UploadData_To_DataGridView("select * from HoaDon", dataGridView3);
                    UploadData_To_DataGridView("select * from Sach", dataGridView1);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hóa đơn để thực hiện thao tác chỉnh sửa !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ QL THỐNG KÊ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        //click radio loại bỏ dữ liệu trên textbox và combobox
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbb_tk_phanLoai.SelectedIndex = -1;
            cbb_tk_ngayBan.Text = "";
            cbb_tk_thangBan.Text = "";
            cbb_tk_namBan.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cbb_tk_phanLoai.SelectedIndex = -1;
            cbb_tk_ngayBan.Text = "";
            cbb_tk_thangBan.Text = "";
            cbb_tk_namBan.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cbb_tk_phanLoai.SelectedIndex = -1;
            cbb_tk_ngayBan.Text = "";
            cbb_tk_thangBan.Text = "";
            cbb_tk_namBan.Text = "";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cbb_tk_phanLoai.SelectedIndex = -1;
            cbb_tk_ngayBan.Text = "";
            cbb_tk_thangBan.Text = "";
            cbb_tk_namBan.Text = "";
        }


        //click vào các textBox và combobox -> loại bỏ tích chọn của các radioButton

        private void cbb_tk_phanLoai_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            cbb_tk_ngayBan.Text = "";
            cbb_tk_thangBan.Text = "";
            cbb_tk_namBan.Text = "";
        }

        private void cbb_tk_ngayBan_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            cbb_tk_phanLoai.SelectedIndex = -1;
        }

        private void cbb_tk_thangBan_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            cbb_tk_phanLoai.SelectedIndex = -1;
        }

        private void cbb_tk_namBan_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            cbb_tk_phanLoai.SelectedIndex = -1;
        }


        //phím nhập vào ô combobox chỉ nhận backspace
        private void cbb_tk_ngayBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                cbb_tk_ngayBan.Text = "";
                //e.Handled = false;
            }
            e.Handled = true;
        }
        private void cbb_tk_thangBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                cbb_tk_thangBan.Text = "";
                //e.Handled = false;
            }
            e.Handled = true;
        }

        private void cbb_tk_namBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                cbb_tk_namBan.Text = "";
                //e.Handled = false;
            }
            e.Handled = true;
        }

        
        //Thống kê
        private void btn_thongKe_Click(object sender, EventArgs e)
        {
            string sqlCommand_statistical = "";
            if (cbb_tk_phanLoai.Text != "" && cbb_tk_ngayBan.Text == "" && cbb_tk_thangBan.Text == "" && cbb_tk_namBan.Text == "")
            {
                sqlCommand_statistical = "select Sach.phanLoai as 'Loại Sách', sum(HoaDon.thanhTien) as 'Tổng tiền'" +
                                         " from Sach, HoaDon" +
                                         " where (Sach.phanLoai = N'" + cbb_tk_phanLoai.Text.Trim() + "') and (Sach.maSach = HoaDon.maSach)" +
                                         " group by phanLoai";
            }
            else if (cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text != "" && cbb_tk_thangBan.Text == "" && cbb_tk_namBan.Text == "")
            {
                sqlCommand_statistical = "select day(ngayBan) as 'Ngày', month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(HoaDon.thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon" +
                                         " where day(ngayBan) = " + cbb_tk_ngayBan.Text +
                                         " group by day(ngayBan), month(ngayBan), year(ngayBan)";
            }
            else if(cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text == "" && cbb_tk_thangBan.Text != "" && cbb_tk_namBan.Text == "")
            {
                sqlCommand_statistical = "select month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon " +
                                         " where month(ngayBan) = " + cbb_tk_thangBan.Text +
                                         " group by month(ngayBan), year(ngayBan)";
            }
            else if (cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text == "" && cbb_tk_thangBan.Text == "" && cbb_tk_namBan.Text != "")
            {
                sqlCommand_statistical = "select year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon " +
                                         " where year(ngayBan) = " + cbb_tk_namBan.Text +
                                         " group by year(ngayBan)";
            }
            else if(cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text != "" && cbb_tk_thangBan.Text != "" && cbb_tk_namBan.Text == "")
            {
                sqlCommand_statistical =    "select day(ngayBan) as 'Ngày', month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền' " +
                                            "from HoaDon " +
                                            "where (day(ngayBan) = " + cbb_tk_ngayBan.Text + ") and (month(ngayBan) = " + cbb_tk_thangBan.Text + ") " +
                                            "group by day(ngayBan), month(ngayBan), year(ngayBan)";
            }
            else if (cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text != "" && cbb_tk_thangBan.Text == "" && cbb_tk_namBan.Text != "")
            {
                sqlCommand_statistical =    "select day(ngayBan) as 'Ngày', month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                            " from HoaDon" +
                                            " where (day(ngayBan) = " + cbb_tk_ngayBan.Text + ") and (year(ngayBan) = " + cbb_tk_namBan.Text + ")" +
                                            " group by day(ngayBan), month(ngayBan), year(ngayBan)";
            }
            else if (cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text == "" && cbb_tk_thangBan.Text != "" && cbb_tk_namBan.Text != "")
            {
                sqlCommand_statistical =    "select month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                            " from HoaDon" +
                                            " where (month(ngayBan) = " + cbb_tk_thangBan.Text + ") and (year(ngayBan) = " + cbb_tk_namBan.Text + ")" +
                                            " group by month(ngayBan), year(ngayBan)";
            }
            else if (cbb_tk_phanLoai.Text == "" && cbb_tk_ngayBan.Text != "" && cbb_tk_thangBan.Text != "" && cbb_tk_namBan.Text != "")
            {
                sqlCommand_statistical =    "select day(ngayBan) as 'Ngày', month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                            " from HoaDon" +
                                            " where (day(ngayBan) = " + cbb_tk_ngayBan.Text + ") and (month(ngayBan) = " + cbb_tk_thangBan.Text + ") and (year(ngayBan) = " + cbb_tk_namBan.Text + ")" +
                                            " group by day(ngayBan), month(ngayBan), year(ngayBan)";
            }
            else if (radioButton1.Checked)
            {
                sqlCommand_statistical = "select Sach.phanLoai as 'Loại Sách', sum(HoaDon.thanhTien) as 'Tổng tiền'" +
                                         " from Sach, HoaDon" +
                                         " where Sach.maSach = HoaDon.maSach" +
                                         " group by phanLoai";
            }
            else if (radioButton2.Checked)
            {
                sqlCommand_statistical = "select day(ngayBan) as 'Ngày', month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(HoaDon.thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon" +
                                         " group by day(ngayBan), month(ngayBan), year(ngayBan)";
            }
            else if (radioButton3.Checked)
            {
                sqlCommand_statistical = "select month(ngayBan) as 'Tháng', year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon " +
                                         " group by month(ngayBan), year(ngayBan)";
            }
            else if (radioButton4.Checked)
            {
                sqlCommand_statistical = "select year(ngayBan) as 'Năm', sum(thanhTien) as 'Tổng tiền'" +
                                         " from HoaDon " +
                                         " group by year(ngayBan)";
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin thống kê!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            disableSort(dataGridView4);
            UploadData_To_DataGridView(sqlCommand_statistical, dataGridView4);
        }
    }
}
