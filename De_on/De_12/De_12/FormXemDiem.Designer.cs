namespace De_12
{
    partial class FormXemDiem
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbb_XemDiem_MaSo = new System.Windows.Forms.ComboBox();
            this.txt_XemDiem_Khoa = new System.Windows.Forms.TextBox();
            this.btn_xem = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_XemDiem_HoTen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên SV :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khoa :";
            // 
            // cbb_XemDiem_MaSo
            // 
            this.cbb_XemDiem_MaSo.FormattingEnabled = true;
            this.cbb_XemDiem_MaSo.Location = new System.Drawing.Point(136, 23);
            this.cbb_XemDiem_MaSo.Name = "cbb_XemDiem_MaSo";
            this.cbb_XemDiem_MaSo.Size = new System.Drawing.Size(202, 24);
            this.cbb_XemDiem_MaSo.TabIndex = 3;
            this.cbb_XemDiem_MaSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbb_XemDiem_MaSo_KeyPress);
            this.cbb_XemDiem_MaSo.MouseLeave += new System.EventHandler(this.cbb_XemDiem_MaSo_MouseLeave);
            // 
            // txt_XemDiem_Khoa
            // 
            this.txt_XemDiem_Khoa.Location = new System.Drawing.Point(136, 158);
            this.txt_XemDiem_Khoa.Name = "txt_XemDiem_Khoa";
            this.txt_XemDiem_Khoa.ReadOnly = true;
            this.txt_XemDiem_Khoa.Size = new System.Drawing.Size(202, 22);
            this.txt_XemDiem_Khoa.TabIndex = 5;
            // 
            // btn_xem
            // 
            this.btn_xem.Location = new System.Drawing.Point(495, 83);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(94, 41);
            this.btn_xem.TabIndex = 6;
            this.btn_xem.Text = "Xem";
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 227);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(775, 211);
            this.dataGridView1.TabIndex = 7;
            // 
            // txt_XemDiem_HoTen
            // 
            this.txt_XemDiem_HoTen.Location = new System.Drawing.Point(136, 95);
            this.txt_XemDiem_HoTen.Name = "txt_XemDiem_HoTen";
            this.txt_XemDiem_HoTen.ReadOnly = true;
            this.txt_XemDiem_HoTen.Size = new System.Drawing.Size(202, 22);
            this.txt_XemDiem_HoTen.TabIndex = 8;
            // 
            // FormXemDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_XemDiem_HoTen);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_xem);
            this.Controls.Add(this.txt_XemDiem_Khoa);
            this.Controls.Add(this.cbb_XemDiem_MaSo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormXemDiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xem Điểm";
            this.Load += new System.EventHandler(this.FormXemDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb_XemDiem_MaSo;
        private System.Windows.Forms.TextBox txt_XemDiem_Khoa;
        private System.Windows.Forms.Button btn_xem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_XemDiem_HoTen;
    }
}