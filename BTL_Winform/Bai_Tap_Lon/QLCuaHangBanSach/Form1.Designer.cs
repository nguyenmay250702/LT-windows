namespace QLCuaHangBanSach
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDanhSachSanPham = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.btnTimKiemSach = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rbtnMaSach = new System.Windows.Forms.RadioButton();
            this.rbtnTenSach = new System.Windows.Forms.RadioButton();
            this.rbtnTacGia = new System.Windows.Forms.RadioButton();
            this.rbtnNXB = new System.Windows.Forms.RadioButton();
            this.rbtnPhanLoai = new System.Windows.Forms.RadioButton();
            this.btnTaiLaiDuLieu = new System.Windows.Forms.Button();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.btnSuaThongTinSach = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblTacGIa = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblNhaXuatBan = new System.Windows.Forms.Label();
            this.txtNhaXuatBan = new System.Windows.Forms.TextBox();
            this.lblPhanLoai = new System.Windows.Forms.Label();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.cbbPhanLoai = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.btnQuanLyHoaDon = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbDanhSachSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbTimKiem.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDanhSachSanPham
            // 
            this.gbDanhSachSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDanhSachSanPham.Controls.Add(this.dgvDanhSachSanPham);
            this.gbDanhSachSanPham.Location = new System.Drawing.Point(3, 3);
            this.gbDanhSachSanPham.Name = "gbDanhSachSanPham";
            this.tableLayoutPanel2.SetRowSpan(this.gbDanhSachSanPham, 3);
            this.gbDanhSachSanPham.Size = new System.Drawing.Size(782, 567);
            this.gbDanhSachSanPham.TabIndex = 3;
            this.gbDanhSachSanPham.TabStop = false;
            this.gbDanhSachSanPham.Text = "Danh sách sản phẩm";
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.AllowUserToAddRows = false;
            this.dgvDanhSachSanPham.AllowUserToDeleteRows = false;
            this.dgvDanhSachSanPham.AllowUserToResizeRows = false;
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(3, 18);
            this.dgvDanhSachSanPham.MultiSelect = false;
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.ReadOnly = true;
            this.dgvDanhSachSanPham.RowHeadersVisible = false;
            this.dgvDanhSachSanPham.RowTemplate.Height = 24;
            this.dgvDanhSachSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(776, 546);
            this.dgvDanhSachSanPham.TabIndex = 19;
            this.dgvDanhSachSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachSanPham_CellClick);
            // 
            // btnTimKiemSach
            // 
            this.btnTimKiemSach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTimKiemSach.Location = new System.Drawing.Point(18, 75);
            this.btnTimKiemSach.Name = "btnTimKiemSach";
            this.tableLayoutPanel3.SetRowSpan(this.btnTimKiemSach, 3);
            this.btnTimKiemSach.Size = new System.Drawing.Size(102, 48);
            this.btnTimKiemSach.TabIndex = 17;
            this.btnTimKiemSach.Text = "Tìm Kiếm Sách";
            this.btnTimKiemSach.UseVisualStyleBackColor = true;
            this.btnTimKiemSach.Click += new System.EventHandler(this.btnTimKiemSach_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanel2.Controls.Add(this.gbDanhSachSanPham, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.gbTimKiem, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.gbThongTin, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 339F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1232, 573);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTimKiem.Controls.Add(this.tableLayoutPanel3);
            this.gbTimKiem.Location = new System.Drawing.Point(791, 342);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(438, 164);
            this.gbTimKiem.TabIndex = 1;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btnTimKiemSach, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtTimKiem, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtnMaSach, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.rbtnTenSach, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.rbtnTacGia, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.rbtnNXB, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.rbtnPhanLoai, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.btnTaiLaiDuLieu, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(432, 143);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.txtTimKiem, 2);
            this.txtTimKiem.Location = new System.Drawing.Point(3, 17);
            this.txtTimKiem.Name = "txtTimKiem";
            this.tableLayoutPanel3.SetRowSpan(this.txtTimKiem, 2);
            this.txtTimKiem.Size = new System.Drawing.Size(272, 22);
            this.txtTimKiem.TabIndex = 11;
            // 
            // rbtnMaSach
            // 
            this.rbtnMaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnMaSach.AutoSize = true;
            this.rbtnMaSach.Checked = true;
            this.rbtnMaSach.Location = new System.Drawing.Point(281, 3);
            this.rbtnMaSach.Name = "rbtnMaSach";
            this.rbtnMaSach.Size = new System.Drawing.Size(148, 21);
            this.rbtnMaSach.TabIndex = 12;
            this.rbtnMaSach.TabStop = true;
            this.rbtnMaSach.Text = "Theo mã sách";
            this.rbtnMaSach.UseVisualStyleBackColor = true;
            // 
            // rbtnTenSach
            // 
            this.rbtnTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnTenSach.AutoSize = true;
            this.rbtnTenSach.Location = new System.Drawing.Point(281, 31);
            this.rbtnTenSach.Name = "rbtnTenSach";
            this.rbtnTenSach.Size = new System.Drawing.Size(148, 21);
            this.rbtnTenSach.TabIndex = 13;
            this.rbtnTenSach.Text = "Theo tên sách";
            this.rbtnTenSach.UseVisualStyleBackColor = true;
            // 
            // rbtnTacGia
            // 
            this.rbtnTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnTacGia.AutoSize = true;
            this.rbtnTacGia.Location = new System.Drawing.Point(281, 59);
            this.rbtnTacGia.Name = "rbtnTacGia";
            this.rbtnTacGia.Size = new System.Drawing.Size(148, 21);
            this.rbtnTacGia.TabIndex = 14;
            this.rbtnTacGia.Text = "Theo tác giả";
            this.rbtnTacGia.UseVisualStyleBackColor = true;
            // 
            // rbtnNXB
            // 
            this.rbtnNXB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnNXB.AutoSize = true;
            this.rbtnNXB.Location = new System.Drawing.Point(281, 87);
            this.rbtnNXB.Name = "rbtnNXB";
            this.rbtnNXB.Size = new System.Drawing.Size(148, 21);
            this.rbtnNXB.TabIndex = 15;
            this.rbtnNXB.Text = "Theo nhà xuất bản";
            this.rbtnNXB.UseVisualStyleBackColor = true;
            // 
            // rbtnPhanLoai
            // 
            this.rbtnPhanLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnPhanLoai.AutoSize = true;
            this.rbtnPhanLoai.Location = new System.Drawing.Point(281, 117);
            this.rbtnPhanLoai.Name = "rbtnPhanLoai";
            this.rbtnPhanLoai.Size = new System.Drawing.Size(148, 21);
            this.rbtnPhanLoai.TabIndex = 16;
            this.rbtnPhanLoai.Text = "Theo phân loại";
            this.rbtnPhanLoai.UseVisualStyleBackColor = true;
            // 
            // btnTaiLaiDuLieu
            // 
            this.btnTaiLaiDuLieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTaiLaiDuLieu.Location = new System.Drawing.Point(157, 75);
            this.btnTaiLaiDuLieu.Name = "btnTaiLaiDuLieu";
            this.tableLayoutPanel3.SetRowSpan(this.btnTaiLaiDuLieu, 3);
            this.btnTaiLaiDuLieu.Size = new System.Drawing.Size(102, 48);
            this.btnTaiLaiDuLieu.TabIndex = 18;
            this.btnTaiLaiDuLieu.Text = "Tải Lại Dữ Liệu";
            this.btnTaiLaiDuLieu.UseVisualStyleBackColor = true;
            this.btnTaiLaiDuLieu.Click += new System.EventHandler(this.btnTaiLaiDuLieu_Click);
            // 
            // gbThongTin
            // 
            this.gbThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThongTin.Controls.Add(this.tableLayoutPanel1);
            this.gbThongTin.Location = new System.Drawing.Point(791, 3);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(438, 333);
            this.gbThongTin.TabIndex = 0;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.btnThemSach, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSuaThongTinSach, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnXoaSach, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMaSach, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMaSach, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenSach, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenSach, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTacGIa, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTacGia, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNhaXuatBan, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNhaXuatBan, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPhanLoai, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblSoLuong, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblGiaBan, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbbPhanLoai, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSoLuong, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtGiaBan, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 312);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnThemSach
            // 
            this.btnThemSach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemSach.Location = new System.Drawing.Point(3, 3);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(137, 33);
            this.btnThemSach.TabIndex = 0;
            this.btnThemSach.Text = "Thêm";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // btnSuaThongTinSach
            // 
            this.btnSuaThongTinSach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuaThongTinSach.Location = new System.Drawing.Point(146, 3);
            this.btnSuaThongTinSach.Name = "btnSuaThongTinSach";
            this.btnSuaThongTinSach.Size = new System.Drawing.Size(138, 33);
            this.btnSuaThongTinSach.TabIndex = 1;
            this.btnSuaThongTinSach.Text = "Sửa";
            this.btnSuaThongTinSach.UseVisualStyleBackColor = true;
            this.btnSuaThongTinSach.Click += new System.EventHandler(this.btnSuaThongTinSach_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoaSach.Location = new System.Drawing.Point(290, 3);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(139, 33);
            this.btnXoaSach.TabIndex = 2;
            this.btnXoaSach.Text = "Xóa";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // lblMaSach
            // 
            this.lblMaSach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Location = new System.Drawing.Point(3, 50);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(67, 17);
            this.lblMaSach.TabIndex = 6;
            this.lblMaSach.Text = "Mã Sách:";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtMaSach, 2);
            this.txtMaSach.Location = new System.Drawing.Point(146, 47);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(283, 22);
            this.txtMaSach.TabIndex = 3;
            this.txtMaSach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaSach_KeyPress);
            // 
            // lblTenSach
            // 
            this.lblTenSach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(3, 89);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(73, 17);
            this.lblTenSach.TabIndex = 7;
            this.lblTenSach.Text = "Tên Sách:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtTenSach, 2);
            this.txtTenSach.Location = new System.Drawing.Point(146, 86);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(283, 22);
            this.txtTenSach.TabIndex = 4;
            this.txtTenSach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenSach_KeyPress);
            // 
            // lblTacGIa
            // 
            this.lblTacGIa.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTacGIa.AutoSize = true;
            this.lblTacGIa.Location = new System.Drawing.Point(3, 128);
            this.lblTacGIa.Name = "lblTacGIa";
            this.lblTacGIa.Size = new System.Drawing.Size(62, 17);
            this.lblTacGIa.TabIndex = 8;
            this.lblTacGIa.Text = "Tác Giả:";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtTacGia, 2);
            this.txtTacGia.Location = new System.Drawing.Point(146, 125);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(283, 22);
            this.txtTacGia.TabIndex = 5;
            this.txtTacGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTacGia_KeyPress);
            // 
            // lblNhaXuatBan
            // 
            this.lblNhaXuatBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNhaXuatBan.AutoSize = true;
            this.lblNhaXuatBan.Location = new System.Drawing.Point(3, 167);
            this.lblNhaXuatBan.Name = "lblNhaXuatBan";
            this.lblNhaXuatBan.Size = new System.Drawing.Size(100, 17);
            this.lblNhaXuatBan.TabIndex = 9;
            this.lblNhaXuatBan.Text = "Nhà Xuất Bản:";
            // 
            // txtNhaXuatBan
            // 
            this.txtNhaXuatBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtNhaXuatBan, 2);
            this.txtNhaXuatBan.Location = new System.Drawing.Point(146, 164);
            this.txtNhaXuatBan.Name = "txtNhaXuatBan";
            this.txtNhaXuatBan.Size = new System.Drawing.Size(283, 22);
            this.txtNhaXuatBan.TabIndex = 6;
            this.txtNhaXuatBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNhaXuatBan_KeyPress);
            // 
            // lblPhanLoai
            // 
            this.lblPhanLoai.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPhanLoai.AutoSize = true;
            this.lblPhanLoai.Location = new System.Drawing.Point(3, 206);
            this.lblPhanLoai.Name = "lblPhanLoai";
            this.lblPhanLoai.Size = new System.Drawing.Size(76, 17);
            this.lblPhanLoai.TabIndex = 10;
            this.lblPhanLoai.Text = "Phân Loại:";
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(3, 245);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(73, 17);
            this.lblSoLuong.TabIndex = 12;
            this.lblSoLuong.Text = "Số Lượng:";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(3, 284);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(63, 17);
            this.lblGiaBan.TabIndex = 13;
            this.lblGiaBan.Text = "Giá Bán:";
            // 
            // cbbPhanLoai
            // 
            this.cbbPhanLoai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cbbPhanLoai, 2);
            this.cbbPhanLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPhanLoai.FormattingEnabled = true;
            this.cbbPhanLoai.Items.AddRange(new object[] {
            "Chính trị",
            "Khoa học công nghệ",
            "Văn học nghệ thuật",
            "Giáo trình",
            "Tiểu thuyết"});
            this.cbbPhanLoai.Location = new System.Drawing.Point(146, 202);
            this.cbbPhanLoai.Name = "cbbPhanLoai";
            this.cbbPhanLoai.Size = new System.Drawing.Size(283, 24);
            this.cbbPhanLoai.TabIndex = 7;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtSoLuong, 2);
            this.txtSoLuong.Location = new System.Drawing.Point(146, 242);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(283, 22);
            this.txtSoLuong.TabIndex = 8;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtGiaBan, 2);
            this.txtGiaBan.Location = new System.Drawing.Point(146, 281);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(283, 22);
            this.txtGiaBan.TabIndex = 9;
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBan_KeyPress);
            // 
            // btnQuanLyHoaDon
            // 
            this.btnQuanLyHoaDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(42, 12);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(135, 33);
            this.btnQuanLyHoaDon.TabIndex = 10;
            this.btnQuanLyHoaDon.Text = "Quản Lý Hóa Đơn";
            this.btnQuanLyHoaDon.UseVisualStyleBackColor = true;
            this.btnQuanLyHoaDon.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnQuanLyHoaDon, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnThoat, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(791, 512);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(438, 58);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.Location = new System.Drawing.Point(261, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 33);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 573);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(1250, 620);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng bán sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDanhSachSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbTimKiem.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDanhSachSanPham;
        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.Button btnTimKiemSach;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rbtnMaSach;
        private System.Windows.Forms.RadioButton rbtnTenSach;
        private System.Windows.Forms.RadioButton rbtnTacGia;
        private System.Windows.Forms.RadioButton rbtnNXB;
        private System.Windows.Forms.RadioButton rbtnPhanLoai;
        private System.Windows.Forms.Button btnTaiLaiDuLieu;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnSuaThongTinSach;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblTacGIa;
        private System.Windows.Forms.Label lblNhaXuatBan;
        private System.Windows.Forms.Label lblPhanLoai;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtNhaXuatBan;
        private System.Windows.Forms.ComboBox cbbPhanLoai;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Button btnQuanLyHoaDon;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnThoat;
    }
}

