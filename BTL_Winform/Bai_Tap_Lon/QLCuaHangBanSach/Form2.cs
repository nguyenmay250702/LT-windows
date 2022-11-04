using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCuaHangBanSach
{
    public partial class Form2 : Form
    {
        string linkConnection = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QUAN_LY_CUA_HANG_BAN_SACH;Integrated Security=True";
        SqlConnection connection;
        SqlCommand command;

        private void updateDataSQL()
        {
            //cập nhật các dữ liệu còn thiếu trong bảng hóa đơn
            new SqlCommand("UPDATE dbo.HOADON SET dbo.HOADON.tenSachBan=dbo.SACH.tenSach, dbo.HOADON.giaSachBan=dbo.SACH.giaBan FROM dbo.SACH, dbo.HOADON WHERE (dbo.SACH.maSach = dbo.HOADON.maSach AND (dbo.HOADON.tenSachBan = 'NULL' OR dbo.HOADON.giaSachBan = -1))", connection).ExecuteNonQuery();
            new SqlCommand("UPDATE dbo.HOADON SET tongGia = giaSachBan * soLuong WHERE (tongGia = -1)", connection).ExecuteNonQuery();
        }

        private void loadDataToDatagridview()
        {
            SqlDataReader data = new SqlCommand("SELECT maHoaDon AS N'Mã hóa đơn', maSach AS N'Mã sách', tenSachBan AS N'Tên sách bán', ngayBan AS N'Ngày bán', giaSachBan AS N'Giá bán', soLuong AS N'Số lượng', tongGia AS N'Tổng giá' FROM dbo.HOADON", connection).ExecuteReader();
            DataTable table = new DataTable();
            table.Load(data);
            dgvDanhSachHoaDon.DataSource = table;
            disableSort();
        }

        private void loadDataToControl()
        {
            DataGridViewRow rowSelect = dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index];
            txtMaHoaDon.Text = rowSelect.Cells[0].Value.ToString().Trim();
            txtMaSach.Text = rowSelect.Cells[1].Value.ToString().Trim();
            dtpNgayBan.Value = DateTime.ParseExact(rowSelect.Cells[3].Value.ToString(), "M/d/yyyy hh:mm:ss tt", null);
            txtSoLuong.Text = rowSelect.Cells[5].Value.ToString();
        }

        private void clearValueControl()
        {
            txtMaSach.Clear();
            txtMaHoaDon.Clear();
            dtpNgayBan.Text = "2002/1/1";
            txtSoLuong.Clear();
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(linkConnection);
            connection.Open();
            updateDataSQL();
            loadDataToDatagridview();
            dgvDanhSachHoaDon.ClearSelection();
            connection.Close();
        }

        #region kiểm tra các control có rỗng hay không.
        private bool checkEmptyValueControl()
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text) || string.IsNullOrWhiteSpace(txtMaSach.Text) || string.IsNullOrWhiteSpace(txtSoLuong.Text))
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

        #region tắt chức năng tự động sắp xếp trong datagridview
        private void disableSort()
        {
            foreach (DataGridViewColumn column in dgvDanhSachHoaDon.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion

        #region hàm trả về số lượng tồn kho của sách khi thêm một hóa đơn
        private int getTonKhoAdd()
        {
            connection.Open();
            var data = new SqlCommand("SELECT tonKho FROM dbo.SACH WHERE (maSach = '"+ txtMaSach.Text +"')", connection).ExecuteScalar();
            connection.Close();
            return Convert.ToInt32(data.ToString());
        }
        #endregion

        #region hàm trả về số lượng tồn kho của sách khi chỉnh sửa một hóa đơn
        private int getTonKhoSet()
        {
            connection.Open();
            var data = new SqlCommand("SELECT tonKho FROM dbo.SACH WHERE (maSach = '" + dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index].Cells[1].Value.ToString().Trim() + "')", connection).ExecuteScalar();
            connection.Close();
            return Convert.ToInt32(data.ToString());
        }
        #endregion

        #region hàm trả về số lượng sách bán trước khi sửa hóa đơn
        private int getSoLuongSet()
        {
            connection.Open();
            var data = new SqlCommand("SELECT soLuong FROM dbo.HOADON WHERE (maHoaDon = '" + dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "')", connection).ExecuteScalar();
            connection.Close();
            return Convert.ToInt32(data.ToString());
        }
        #endregion

        #region hàm thực thi câu truy vấn SQL (ExecuteNonQuery)
        private void executeNonQuery(string stringCommand)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("MAHOADON", txtMaHoaDon.Text);
            command.Parameters.AddWithValue("MASACH", txtMaSach.Text);
            command.Parameters.AddWithValue("NGAYBAN", DateTime.ParseExact(dtpNgayBan.Value.ToString(), "M/d/yyyy hh:mm:ss tt", null));
            command.Parameters.AddWithValue("SOLUONG", Convert.ToInt32(txtSoLuong.Text));
            command.CommandText = stringCommand;
            command.ExecuteNonQuery();
            updateDataSQL();
            loadDataToDatagridview();
            connection.Close();
        }
        #endregion

        #region hàm kiểm tra trùng lặp mã sách hoặc mã hóa đơn
        private bool checkMaSachvsMaHoaDon(string stringCommand)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.Parameters.AddWithValue("MASACH", txtMaSach.Text);
            command.Parameters.AddWithValue("MAHOADON", txtMaHoaDon.Text);
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
        private void txtMaHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaHoaDon.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Mã hóa đơn có độ dài tối đa là 10 kí tự!", "Cảnh báo dữ liệu vượt quá phạm vi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else if (!char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '-') && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Mã hóa đơn chỉ được phép chưa chữ cái, chữ số, và kí tự '-'.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

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

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Số lượng chỉ được phép chứa chữ số và không được âm.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
        #endregion

        #region bắt sự kiện để thêm hóa đơn
        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (checkEmptyValueControl())
            {
                try
                {
                    if (Convert.ToInt32(txtSoLuong.Text) == 0)
                    {
                        MessageBox.Show("Số lượng tối thiểu phải là 1!", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (checkMaSachvsMaHoaDon("SELECT maHoaDon FROM dbo.HOADON WHERE (maHoaDon = @MAHOADON)"))
                        {
                            MessageBox.Show("Mã hóa đơn bạn nhập đã tồn tại trong CSDL!", "Cảnh báo trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!checkMaSachvsMaHoaDon("SELECT maSach FROM dbo.SACH WHERE (maSach = @MASACH)"))
                        {
                            MessageBox.Show("Sản phẩm không có trong CSDL!\nVui lòng kiểm tra lại mã sản phẩm.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if(Convert.ToInt32(txtSoLuong.Text) > getTonKhoAdd())
                        {
                            MessageBox.Show("Cửa hàng hiện không có đủ số lượng theo đơn đặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        connection.Open();
                        new SqlCommand(@"INSERT INTO dbo.HOADON (maHoaDon, maSach, ngayBan, soLuong) VALUES ('"+txtMaHoaDon.Text+"', '"+txtMaSach.Text+"', '"+ DateTime.ParseExact(dtpNgayBan.Value.ToString(), "M/d/yyyy hh:mm:ss tt", null) + "', "+ txtSoLuong.Text + ")", connection).ExecuteNonQuery();
                        new SqlCommand(@"UPDATE dbo.SACH SET dbo.SACH.tonKho = dbo.SACH.tonKho - dbo.HOADON.soLuong FROM dbo.SACH, dbo.HOADON WHERE(dbo.SACH.maSach = dbo.HOADON.maSach AND dbo.HOADON.maHoaDon = '" + txtMaHoaDon.Text + "')", connection).ExecuteNonQuery();
                        updateDataSQL();
                        loadDataToDatagridview();
                        connection.Close();
                        dgvDanhSachHoaDon.ClearSelection();
                        clearValueControl();
                        MessageBox.Show("Thêm mới hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region bắt sự kiện để sửa thông tin hóa đơn
        private void btnSuaThongTinHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHoaDon.SelectedRows.Count > 0)
            {
                if (checkEmptyValueControl())
                {
                    try
                    {
                        if (Convert.ToInt32(txtSoLuong.Text) == 0)
                        {
                            MessageBox.Show("Số lượng tối thiểu phải là 1!", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            if (checkMaSachvsMaHoaDon("SELECT maHoaDon FROM dbo.HOADON WHERE (maHoaDon = @MAHOADON)") && txtMaHoaDon.Text != dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index].Cells[0].Value.ToString().Trim())
                            {
                                MessageBox.Show("Mã hóa đơn đã tồn tại trong CSDL!", "Cảnh báo trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (!checkMaSachvsMaHoaDon("SELECT maSach FROM dbo.SACH WHERE (maSach = @MASACH)"))
                            {
                                MessageBox.Show("Sản phẩm không có trong CSDL!\nVui lòng kiểm tra lại mã sản phẩm.", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            if (Convert.ToInt32(txtSoLuong.Text) > getTonKhoSet() + getSoLuongSet() || Convert.ToInt32(txtSoLuong.Text) > getTonKhoAdd())
                            {
                                MessageBox.Show("Cửa hàng hiện không có đủ số lượng theo đơn đặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin hóa đơn ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                int soLuong = getSoLuongSet();
                                connection.Open();
                                new SqlCommand(@"UPDATE dbo.SACH SET dbo.SACH.tonKho = dbo.SACH.tonKho + " + soLuong + " FROM dbo.SACH, dbo.HOADON WHERE(dbo.SACH.maSach = dbo.HOADON.maSach AND dbo.SACH.maSach = '" + dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index].Cells[1].Value.ToString().Trim() + "')", connection).ExecuteNonQuery();
                                new SqlCommand(@"UPDATE dbo.HOADON SET dbo.HOADON.maHoaDon = '"+txtMaHoaDon.Text+"', dbo.HOADON.maSach = '"+txtMaSach.Text+ "', dbo.HOADON.ngayBan = '"+DateTime.ParseExact(dtpNgayBan.Value.ToString(), "M/d/yyyy hh:mm:ss tt", null)+"', dbo.HOADON.soLuong = "+ txtSoLuong.Text + " WHERE(dbo.HOADON.maHoaDon = '" + dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentRow.Index].Cells[0].Value.ToString().Trim() + "')",connection).ExecuteNonQuery();
                                new SqlCommand(@"UPDATE dbo.SACH SET dbo.SACH.tonKho = dbo.SACH.tonKho - dbo.HOADON.soLuong FROM dbo.SACH, dbo.HOADON WHERE(dbo.SACH.maSach = dbo.HOADON.maSach AND dbo.HOADON.maHoaDon = '" + txtMaHoaDon.Text + "')", connection).ExecuteNonQuery();
                                new SqlCommand(@"UPDATE dbo.HOADON SET dbo.HOADON.tenSachBan=dbo.SACH.tenSach, dbo.HOADON.giaSachBan=dbo.SACH.giaBan FROM dbo.SACH, dbo.HOADON WHERE (dbo.SACH.maSach = dbo.HOADON.maSach AND dbo.HOADON.maHoaDon = '" + txtMaHoaDon.Text + "')", connection).ExecuteNonQuery();
                                new SqlCommand(@"UPDATE dbo.HOADON SET dbo.HOADON.tongGia = dbo.HOADON.giaSachBan * dbo.HOADON.soLuong WHERE (dbo.HOADON.maHoaDon = '" + txtMaHoaDon.Text + "')", connection).ExecuteNonQuery();
                                loadDataToDatagridview();
                                connection.Close();
                                dgvDanhSachHoaDon.ClearSelection();
                                clearValueControl();
                                MessageBox.Show("Cập nhật thông tin hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show("Số lượng đã vượt quá phạm vi!", "Cảnh báo dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Phải chọn hàng có dữ liệu thì mới sửa được", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearValueControl();
                dgvDanhSachHoaDon.ClearSelection();
                return;
            }
        }
        #endregion

        #region bắt sự kiện để xóa hóa đơn
        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachHoaDon.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string maHoaDon = dgvDanhSachHoaDon.Rows[dgvDanhSachHoaDon.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim();
                    executeNonQuery("DELETE FROM dbo.HOADON WHERE (maHoaDon = '" + maHoaDon + "')");
                    dgvDanhSachHoaDon.ClearSelection();
                    clearValueControl();
                    MessageBox.Show("Xóa hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
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

        #region bắt sự kiện để thống kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvDanhSachHoaDon.CellClick -= dgvDanhSachHoaDon_CellClick;
            btnThemHoaDon.Enabled = false;
            btnSuaThongTinHoaDon.Enabled = false;
            btnXoaHoaDon.Enabled = false;
            string commandText = "";
            if (rbtnPhanLoai.Checked)
                commandText = "SELECT phanLoai AS 'Phân Loại' , SUM(soLuong) AS 'Số Lượng sách bán được', SUM(tongGia) AS 'Tổng tiền' FROM dbo.HOADON, dbo.SACH WHERE SACH.maSach = HOADON.maSach GROUP BY phanLoai";
            else if (rbtnNgay.Checked)
                commandText = "SELECT DAY(ngayBan) AS N'Ngày', MONTH(ngayBan) AS N'Tháng', YEAR(ngayBan) AS N'Năm' , SUM(soLuong) AS N'Số Lượng sách bán được', SUM(tongGia) AS 'Tổng tiền' FROM dbo.HOADON, dbo.SACH WHERE SACH.maSach = HOADON.maSach GROUP BY DAY(ngayBan), MONTH(ngayBan), YEAR(ngayBan)";
            else if (rbtnThang.Checked)
                commandText = "SELECT MONTH(ngayBan) AS 'Tháng', YEAR(ngayBan) AS 'Năm' , SUM(soLuong) AS 'Số Lượng sách bán được', SUM(tongGia) AS 'Tổng tiền' FROM dbo.HOADON, dbo.SACH WHERE SACH.maSach = HOADON.maSach GROUP BY MONTH(ngayBan), YEAR(ngayBan)";
            else if (rbtnNam.Checked)
                commandText = "SELECT YEAR(ngayBan) AS 'Năm' , SUM(soLuong) AS 'Số Lượng sách bán được', SUM(tongGia) AS 'Tổng tiền' FROM dbo.HOADON, dbo.SACH WHERE SACH.maSach = HOADON.maSach GROUP BY YEAR(ngayBan)";
            connection.Open();
            SqlDataReader data = new SqlCommand(commandText, connection).ExecuteReader();
            DataTable table = new DataTable();
            table.Load(data);
            dgvDanhSachHoaDon.DataSource = table;
            dgvDanhSachHoaDon.ClearSelection();
            clearValueControl();
            connection.Close();
        }
        #endregion

        #region load lại dữ liệu khi người dùng kết thúc thống kê
        private void btnTaiLaiDuLieu_Click(object sender, EventArgs e)
        {
            dgvDanhSachHoaDon.CellClick += dgvDanhSachHoaDon_CellClick;
            btnThemHoaDon.Enabled = true;
            btnSuaThongTinHoaDon.Enabled = true;
            btnXoaHoaDon.Enabled = true;
            connection.Open();
            loadDataToDatagridview();
            dgvDanhSachHoaDon.ClearSelection();
            clearValueControl();
            connection.Close();
        }
        #endregion

        //bắt sự kiện khi click vào một hàng trong datagridview
        private void dgvDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                loadDataToControl();
            }
            else
            {
                dgvDanhSachHoaDon.ClearSelection();
                clearValueControl();
            }
        }
    }
}
