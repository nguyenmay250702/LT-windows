namespace De_12
{
    partial class FormKhoa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Khoa_MaKhoa = new System.Windows.Forms.TextBox();
            this.txt_Khoa_TenKhoa = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtn_Them = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Sua = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtn_Xoa = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(476, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khoa :";
            // 
            // txt_Khoa_MaKhoa
            // 
            this.txt_Khoa_MaKhoa.Location = new System.Drawing.Point(139, 101);
            this.txt_Khoa_MaKhoa.Name = "txt_Khoa_MaKhoa";
            this.txt_Khoa_MaKhoa.Size = new System.Drawing.Size(188, 22);
            this.txt_Khoa_MaKhoa.TabIndex = 2;
            // 
            // txt_Khoa_TenKhoa
            // 
            this.txt_Khoa_TenKhoa.Location = new System.Drawing.Point(569, 101);
            this.txt_Khoa_TenKhoa.Name = "txt_Khoa_TenKhoa";
            this.txt_Khoa_TenKhoa.Size = new System.Drawing.Size(188, 22);
            this.txt_Khoa_TenKhoa.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(794, 269);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtn_Them,
            this.toolStripBtn_Sua,
            this.toolStripBtn_Xoa});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(819, 56);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtn_Them
            // 
            this.toolStripBtn_Them.Image = global::De_12.Properties.Resources.thêm;
            this.toolStripBtn_Them.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Them.Name = "toolStripBtn_Them";
            this.toolStripBtn_Them.Size = new System.Drawing.Size(67, 53);
            this.toolStripBtn_Them.Text = "thêm";
            this.toolStripBtn_Them.Click += new System.EventHandler(this.toolStripBtn_Them_Click);
            // 
            // toolStripBtn_Sua
            // 
            this.toolStripBtn_Sua.Image = global::De_12.Properties.Resources.lưu;
            this.toolStripBtn_Sua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Sua.Name = "toolStripBtn_Sua";
            this.toolStripBtn_Sua.Size = new System.Drawing.Size(58, 53);
            this.toolStripBtn_Sua.Text = "Sửa";
            this.toolStripBtn_Sua.Click += new System.EventHandler(this.toolStripBtn_Sua_Click);
            // 
            // toolStripBtn_Xoa
            // 
            this.toolStripBtn_Xoa.Image = global::De_12.Properties.Resources.xóa;
            this.toolStripBtn_Xoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtn_Xoa.Name = "toolStripBtn_Xoa";
            this.toolStripBtn_Xoa.Size = new System.Drawing.Size(59, 53);
            this.toolStripBtn_Xoa.Text = "Xóa";
            this.toolStripBtn_Xoa.Click += new System.EventHandler(this.toolStripBtn_Xoa_Click);
            // 
            // FormKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 494);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txt_Khoa_TenKhoa);
            this.Controls.Add(this.txt_Khoa_MaKhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormKhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Mục Khoa";
            this.Load += new System.EventHandler(this.FormKhoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Khoa_MaKhoa;
        private System.Windows.Forms.TextBox txt_Khoa_TenKhoa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Them;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Sua;
        private System.Windows.Forms.ToolStripButton toolStripBtn_Xoa;
    }
}