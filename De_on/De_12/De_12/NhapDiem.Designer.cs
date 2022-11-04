namespace De_12
{
    partial class NhapDiem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbb_TenMon = new System.Windows.Forms.ComboBox();
            this.cbb_MaMon = new System.Windows.Forms.ComboBox();
            this.cbb_HoTen = new System.Windows.Forms.ComboBox();
            this.txt_MaSo = new System.Windows.Forms.Label();
            this.txt_HoTen = new System.Windows.Forms.Label();
            this.txt_MaMon = new System.Windows.Forms.Label();
            this.txt_TenMon = new System.Windows.Forms.Label();
            this.txt_Diem = new System.Windows.Forms.Label();
            this.cbb_MaSo = new System.Windows.Forms.ComboBox();
            this.cbb_Diem = new System.Windows.Forms.TextBox();
            this.btn_Nhap = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.33117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.66883F));
            this.tableLayoutPanel1.Controls.Add(this.cbb_TenMon, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbb_MaMon, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbb_HoTen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_MaSo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_HoTen, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_MaMon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_TenMon, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txt_Diem, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbb_MaSo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbb_Diem, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(93, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbb_TenMon
            // 
            this.cbb_TenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_TenMon.FormattingEnabled = true;
            this.cbb_TenMon.Location = new System.Drawing.Point(192, 223);
            this.cbb_TenMon.Name = "cbb_TenMon";
            this.cbb_TenMon.Size = new System.Drawing.Size(411, 24);
            this.cbb_TenMon.TabIndex = 8;
            // 
            // cbb_MaMon
            // 
            this.cbb_MaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_MaMon.FormattingEnabled = true;
            this.cbb_MaMon.Location = new System.Drawing.Point(192, 152);
            this.cbb_MaMon.Name = "cbb_MaMon";
            this.cbb_MaMon.Size = new System.Drawing.Size(411, 24);
            this.cbb_MaMon.TabIndex = 7;
            // 
            // cbb_HoTen
            // 
            this.cbb_HoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_HoTen.FormattingEnabled = true;
            this.cbb_HoTen.Location = new System.Drawing.Point(192, 85);
            this.cbb_HoTen.Name = "cbb_HoTen";
            this.cbb_HoTen.Size = new System.Drawing.Size(411, 24);
            this.cbb_HoTen.TabIndex = 6;
            // 
            // txt_MaSo
            // 
            this.txt_MaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MaSo.AutoSize = true;
            this.txt_MaSo.Location = new System.Drawing.Point(3, 24);
            this.txt_MaSo.Name = "txt_MaSo";
            this.txt_MaSo.Size = new System.Drawing.Size(183, 16);
            this.txt_MaSo.TabIndex = 0;
            this.txt_MaSo.Text = "Mã số";
            // 
            // txt_HoTen
            // 
            this.txt_HoTen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_HoTen.AutoSize = true;
            this.txt_HoTen.Location = new System.Drawing.Point(3, 89);
            this.txt_HoTen.Name = "txt_HoTen";
            this.txt_HoTen.Size = new System.Drawing.Size(183, 16);
            this.txt_HoTen.TabIndex = 1;
            this.txt_HoTen.Text = "Họ tên";
            // 
            // txt_MaMon
            // 
            this.txt_MaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_MaMon.AutoSize = true;
            this.txt_MaMon.Location = new System.Drawing.Point(3, 156);
            this.txt_MaMon.Name = "txt_MaMon";
            this.txt_MaMon.Size = new System.Drawing.Size(183, 16);
            this.txt_MaMon.TabIndex = 2;
            this.txt_MaMon.Text = "Mã môn";
            // 
            // txt_TenMon
            // 
            this.txt_TenMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TenMon.AutoSize = true;
            this.txt_TenMon.Location = new System.Drawing.Point(3, 227);
            this.txt_TenMon.Name = "txt_TenMon";
            this.txt_TenMon.Size = new System.Drawing.Size(183, 16);
            this.txt_TenMon.TabIndex = 3;
            this.txt_TenMon.Text = "Tên môn";
            // 
            // txt_Diem
            // 
            this.txt_Diem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Diem.AutoSize = true;
            this.txt_Diem.Location = new System.Drawing.Point(3, 303);
            this.txt_Diem.Name = "txt_Diem";
            this.txt_Diem.Size = new System.Drawing.Size(183, 16);
            this.txt_Diem.TabIndex = 4;
            this.txt_Diem.Text = "Điểm";
            // 
            // cbb_MaSo
            // 
            this.cbb_MaSo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_MaSo.FormattingEnabled = true;
            this.cbb_MaSo.Location = new System.Drawing.Point(192, 20);
            this.cbb_MaSo.Name = "cbb_MaSo";
            this.cbb_MaSo.Size = new System.Drawing.Size(411, 24);
            this.cbb_MaSo.TabIndex = 5;
            // 
            // cbb_Diem
            // 
            this.cbb_Diem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_Diem.Location = new System.Drawing.Point(192, 300);
            this.cbb_Diem.Name = "cbb_Diem";
            this.cbb_Diem.Size = new System.Drawing.Size(411, 22);
            this.cbb_Diem.TabIndex = 9;
            // 
            // btn_Nhap
            // 
            this.btn_Nhap.Location = new System.Drawing.Point(562, 429);
            this.btn_Nhap.Name = "btn_Nhap";
            this.btn_Nhap.Size = new System.Drawing.Size(96, 33);
            this.btn_Nhap.TabIndex = 1;
            this.btn_Nhap.Text = "Nhập";
            this.btn_Nhap.UseVisualStyleBackColor = true;
            this.btn_Nhap.Click += new System.EventHandler(this.btn_Nhap_Click);
            // 
            // NhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.btn_Nhap);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NhapDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NhapDiem";
            this.Load += new System.EventHandler(this.NhapDiem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbb_TenMon;
        private System.Windows.Forms.ComboBox cbb_MaMon;
        private System.Windows.Forms.ComboBox cbb_HoTen;
        private System.Windows.Forms.Label txt_MaSo;
        private System.Windows.Forms.Label txt_HoTen;
        private System.Windows.Forms.Label txt_MaMon;
        private System.Windows.Forms.Label txt_TenMon;
        private System.Windows.Forms.Label txt_Diem;
        private System.Windows.Forms.ComboBox cbb_MaSo;
        private System.Windows.Forms.TextBox cbb_Diem;
        private System.Windows.Forms.Button btn_Nhap;
    }
}