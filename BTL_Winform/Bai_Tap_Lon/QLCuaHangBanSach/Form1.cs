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

namespace QLCuaHangBanSach
{
    public partial class Form1 : Form
    {
        //chuỗi kết nối
        string linkConnection = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QUAN_LY_CUA_HANG_BAN_SACH;Integrated Security=True";

        //khai báo đối tượng kết nối
        SqlConnection connection = null;

        //khai báo đối tượng command để thực thi truy vấn
        SqlCommand command;

        private void updateDataSQL()
        {
            //cập nhật tên tác giả thành 'N/A' nếu người dùng không nhập tên tác giả
            new SqlCommand("UPDATE dbo.SACH SET dbo.SACH.tacGia = 'N/A' FROM dbo.SACH WHERE (dbo.SACH.tacGia = '')", connection).ExecuteNonQuery();
        }

        private void loadDataToDatagridview()
        {
            //tạo đối tượng data reader để lưu tất cả kết quả có được khi truy vấn
            SqlDataReader data = new SqlCommand("SELECT maSach AS N'Mã sách', tenSach AS N'Tên sách', tacGia AS N'Tác giả', nhaXuatBan AS N'Nhà xuất bản', phanLoai AS N'Phân loại', tonKho AS N'Kho', giaBan AS N'Giá bán'  FROM dbo.SACH", connection).ExecuteReader();
            
            //tạo một bảng sau đó nạp dữ liệu truy vấn vào bảng
            DataTable table = new DataTable();
            table.Load(data);

            //tải dữ liệu vào datagridview
            dgvDanhSachSanPham.DataSource = table;
            disableSort();
        }

        private void loadDataToControl()
        {
            //tạo một đối tượng DataGridViewRow để lấy dữ liệu từ hàng đang được chọn trong datagridview
            DataGridViewRow rowSelect = dgvDanhSachSanPham.Rows[dgvDanhSachSanPham.CurrentRow.Index];
            //truyền các dữ liệu đã nhận được lên các control tương ứng
            txtMaSach.Text = rowSelect.Cells[0].Value.ToString().Trim();
            txtTenSach.Text = rowSelect.Cells[1].Value.ToString();
            txtTacGia.Text = rowSelect.Cells[2].Value.ToString();
            txtNhaXuatBan.Text = rowSelect.Cells[3].Value.ToString();
            cbbPhanLoai.Text = rowSelect.Cells[4].Value.ToString();
            txtSoLuong.Text = rowSelect.Cells[5].Value.ToString();
            txtGiaBan.Text = rowSelect.Cells[6].Value.ToString();
        }

        private void clearValueControl()
        {
            //xóa hết các giá trị trong control
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtNhaXuatBan.Clear();
            cbbPhanLoai.SelectedItem = null;
            txtSoLuong.Clear();
            txtGiaBan.Clear();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(linkConnection);
            connection.Open();
            updateDataSQL();
            loadDataToDatagridview();
            dgvDanhSachSanPham.ClearSelection();
            connection.Close();
        }

        #region kiểm tra các control có rỗng hay không.
        private bool checkEmptyValueControl()
        {
            if (string.IsNullOrWhiteSpace(txtMaSach.Text) || string.IsNullOrWhiteSpace(txtTenSach.Text) || string.IsNullOrWhiteSpace(txtNhaXuatBan.Text) || string.IsNullOrWhiteSpace(cbbPhanLoai.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ dữ liệu trước khi thêm!", "Cảnh báo nhập thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region hàm chuẩn hóa xâu kí tự
        private string standardizeName(string fullName)
        {
            fullName = fullName.Trim();
            while (fullName.IndexOf("  ") != -1)
            {
                fullName = fullName.Replace("  ", " ");
            }
            if (fullName.Length > 0)
            {
                string[] subName = fullName.Split(' ');
                fullName = "";
                for (int index = 0; index < subName.Length; index++)
                {
                    string firstCharacter = subName[index].Substring(0, 1);
                    string otherCharacter = subName[index].Substring(1);
                    subName[index] = firstCharacter.ToUpper() + otherCharacter.ToLower();
                    fullName += subName[index] + " ";
                }
                fullName = fullName.Remove(fullName.Length - 1);
            }
            return fullName;
        }
        #endregion

        #region tắt chức năng tự động sắp xếp trong datagridview
        private void disableSort()
        {
            foreach (DataGridViewColumn column in dgvDanhSachSanPham.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion

        #region hàm thực thi câu truy vấn SQL (ExecuteNonQuery)
        private void executeNonQuery(string stringCommand)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("MASACH", txtMaSach.Text);
            command.Parameters.AddWithValue("TENSACH", standardizeName(txtTenSach.Text));
            command.Parameters.AddWithValue("TACGIA", standardizeName(txtTacGia.Text));
            command.Parameters.AddWithValue("NXB", standardizeName(txtNhaXuatBan.Text));
            command.Parameters.AddWithValue("PHANLOAI", cbbPhanLoai.Text);
            command.Parameters.AddWithValue("SOLUONG", Convert.ToInt32(txtSoLuong.Text));
            command.Parameters.AddWithValue("GIABAN", Convert.ToInt32(txtGiaBan.Text));
            command.CommandText = stringCommand;
            command.ExecuteNonQuery();
            updateDataSQL();
            loadDataToDatagridview();
            connection.Close();
        }
        #endregion

        #region hàm kiểm tra trùng lặp mã sách
        private bool checkMaSach(string stringCommand)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("MASACH", txtMaSach.Text);
            command.CommandText = stringCommand;
            var resultExecute = command.ExecuteScalar();
            if (resultExecute != null)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        #endregion

        #region một số sự kiên KeyPress để kiểm tra nhập liệu trên các control
        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaSach.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Mã sách có độ dài tối đa là 10 kí tự!", "Cảnh báo dữ liệu vượt quá phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if (!char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-') && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Mã sách chỉ được phép chưa chữ cái, chữ số, và kí tự '-'.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtTenSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTenSach.Text.Length >= 100 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Tên sách có độ dài tối đa là 100 kí tự!", "Cảnh báo dữ liệu vượt quá phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtTacGia.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Tên tác giả có độ dài tối đa là 50 kí tự!", "Cảnh báo dữ liệu vượt quá phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Tên tác giả chỉ được phép chưa chữ cái.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtNhaXuatBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNhaXuatBan.Text.Length >= 50 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Tên nhà xuất bản có độ dài tối đa là 50 kí tự!", "Cảnh báo dữ liệu vượt quá phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Số lượng chỉ được phép chứa chữ số và không được âm.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Giá bán chỉ được phép chứa chữ số và không được âm.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
        #endregion

        #region bắt sự kiện để thêm sách
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (checkEmptyValueControl())
            {
                try
                {
                    if (Convert.ToInt32(txtSoLuong.Text) == 0 || Convert.ToInt32(txtGiaBan.Text) == 0)
                    {
                        MessageBox.Show("Sản phẩm thêm mới phải có số lượng tối thiểu là 1 và giá bán phải lớn hơn 0", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (checkMaSach("SELECT maSach FROM dbo.SACH WHERE (maSach = @MASACH)"))
                        {
                            MessageBox.Show("Mã sách bạn nhập đã tồn tại trong CSDL!", "Cảnh báo trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            executeNonQuery(@"INSERT INTO dbo.SACH VALUES (@MASACH, @TENSACH, @TACGIA, @NXB, @PHANLOAI, @SOLUONG, @GIABAN)");
                            dgvDanhSachSanPham.ClearSelection();
                            clearValueControl();
                            MessageBox.Show("Thêm mới sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Số lượng hoặc giá bán đã vượt quá phạm vi!", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        #endregion

        #region bắt sự kiện để sửa thông tin sách
        private void btnSuaThongTinSach_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.SelectedRows.Count > 0)
            {
                if (checkEmptyValueControl())
                {
                    try
                    {
                        if (Convert.ToInt32(txtGiaBan.Text) == 0)
                        {
                            MessageBox.Show("Giá bán phải lớn hơn 0", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            if (checkMaSach("SELECT maSach FROM dbo.SACH WHERE (maSach = @MASACH)") && txtMaSach.Text.Trim() != dgvDanhSachSanPham.Rows[dgvDanhSachSanPham.CurrentRow.Index].Cells[0].Value.ToString().Trim())
                            {
                                MessageBox.Show("Mã sách mới đã tồn tại trong CSDL!", "Cảnh báo trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin sản phẩm ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    try
                                    {
                                        executeNonQuery(@"UPDATE dbo.SACH SET dbo.SACH.maSach = @MASACH, dbo.SACH.tenSach = @TENSACH, dbo.SACH.tacGia = @TACGIA, dbo.SACH.nhaXuatBan = @NXB, dbo.SACH.phanLoai = @PHANLOAI, dbo.SACH.tonKho = @SOLUONG, dbo.SACH.giaBan = @GIABAN FROM dbo.SACH WHERE(dbo.SACH.maSach = '" + dgvDanhSachSanPham.Rows[dgvDanhSachSanPham.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "')");
                                        executeNonQuery(@"UPDATE dbo.SACH SET dbo.SACH.tacGia = 'N/A' FROM dbo.SACH WHERE dbo.SACH.tacGia = ''");
                                        dgvDanhSachSanPham.ClearSelection();
                                        clearValueControl();
                                        MessageBox.Show("Cập nhật thông tin sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    catch (Exception)
                                    {
                                        connection.Close();
                                        MessageBox.Show("Bạn không thể thay đổi mã sản phẩm vì\nSản phẩm này có liên kết với một số hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Số lượng hoặc giá bán đã vượt quá phạm vi!", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Phải chọn hàng có dữ liệu thì mới sửa được", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearValueControl();
                dgvDanhSachSanPham.ClearSelection();
                return;
            }
        }
        #endregion

        #region bắt sự kiện để xóa sách
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.SelectedRows.Count > 0)
            {
                DialogResult resultDeleteBook = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDeleteBook == DialogResult.Yes)
                {
                    string maSach = dgvDanhSachSanPham.Rows[dgvDanhSachSanPham.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
                    try
                    {
                        executeNonQuery("DELETE FROM dbo.SACH WHERE (maSach = '" + maSach + "')");
                        dgvDanhSachSanPham.ClearSelection();
                        clearValueControl();
                        MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException)
                    {
                        connection.Close();
                        DialogResult resultDeleteReceipt = MessageBox.Show("Sản phẩm này có liên kết với một số hóa đơn.\nNếu bạn xóa đi thì các hóa đơn được liên kết với sản phẩm cũng sẽ bị xóa\nBạn có chắc chắn muốn xóa sản phẩm?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultDeleteReceipt == DialogResult.Yes)
                        {
                            executeNonQuery("DELETE FROM dbo.HOADON WHERE (maSach = '" + maSach + "')");
                            executeNonQuery("DELETE FROM dbo.SACH WHERE (maSach = '" + maSach + "')");
                            dgvDanhSachSanPham.ClearSelection();
                            clearValueControl();
                            MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng muốn xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region bắt sự kiện để tìm kiếm sách
        private void btnTimKiemSach_Click(object sender, EventArgs e)
        {
            if (standardizeName(txtTimKiem.Text) != "")
            {
                string commandText = "";
                if (rbtnMaSach.Checked)
                    commandText = "select * from dbo.SACH where (dbo.SACH.maSach = '" + txtTimKiem.Text + "')";
                else if (rbtnTenSach.Checked)
                    commandText = "select * from dbo.SACH where (dbo.SACH.tenSach = N'" + txtTimKiem.Text + "')";
                else if (rbtnTacGia.Checked)
                    commandText = "select * from dbo.SACH where (dbo.SACH.tacGia = N'" + txtTimKiem.Text + "')";
                else if (rbtnNXB.Checked)
                    commandText = "select * from dbo.SACH where (dbo.SACH.nhaXuatBan = N'" + txtTimKiem.Text + "')";
                else if (rbtnPhanLoai.Checked)
                    commandText = "select * from dbo.SACH where (dbo.SACH.phanLoai = N'" + txtTimKiem.Text + "')";
                connection.Open();
                SqlDataReader data = new SqlCommand(commandText, connection).ExecuteReader();
                DataTable table = new DataTable();
                table.Load(data);
                dgvDanhSachSanPham.DataSource = table;
                dgvDanhSachSanPham.ClearSelection();
                clearValueControl();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Vui nhập đủ dữ liệu để tìm kiếm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        #endregion

        #region bắt sự kiện để hiện thị form quản lý hóa đơn
        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.FormClosed += new FormClosedEventHandler(form2EventClosed);
            this.Visible = false;
            form2.Show();
        }
        #endregion

        #region cập nhật lại thông tin khi form quản lý hóa đơn đóng
        private void form2EventClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
            connection.Open();
            loadDataToDatagridview();
            dgvDanhSachSanPham.ClearSelection();
            clearValueControl();
            connection.Close();
        }
        #endregion

        #region load lại dữ liệu khi người dùng kết thúc tìm kiếm
        private void btnTaiLaiDuLieu_Click(object sender, EventArgs e)
        {
            connection.Open();
            loadDataToDatagridview();
            dgvDanhSachSanPham.ClearSelection();
            clearValueControl();
            connection.Close();
        }
        #endregion

        #region bắt sự kiện để thoát chương trình
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
        #endregion

        //bắt sự kiện khi click vào một hàng trong datagridview
        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                loadDataToControl();
            }
            else
            {
                dgvDanhSachSanPham.ClearSelection();
                clearValueControl();
            }
        }
    }
}
