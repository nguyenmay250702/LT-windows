namespace Bai_1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_tinh = new System.Windows.Forms.Button();
            this.txt_tong = new System.Windows.Forms.Label();
            this.txt_thuong = new System.Windows.Forms.Label();
            this.txt_tich = new System.Windows.Forms.Label();
            this.txt_hieu = new System.Windows.Forms.Label();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số a:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số b:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(152, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(152, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 22);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btn_tinh
            // 
            this.btn_tinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_tinh.Location = new System.Drawing.Point(396, 15);
            this.btn_tinh.Name = "btn_tinh";
            this.btn_tinh.Size = new System.Drawing.Size(94, 50);
            this.btn_tinh.TabIndex = 4;
            this.btn_tinh.Text = "Tính";
            this.btn_tinh.UseVisualStyleBackColor = true;
            this.btn_tinh.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_tong
            // 
            this.txt_tong.AutoSize = true;
            this.txt_tong.Location = new System.Drawing.Point(12, 105);
            this.txt_tong.Name = "txt_tong";
            this.txt_tong.Size = new System.Drawing.Size(84, 16);
            this.txt_tong.TabIndex = 5;
            this.txt_tong.Text = "Tổng a + b = ";
            // 
            // txt_thuong
            // 
            this.txt_thuong.AutoSize = true;
            this.txt_thuong.Location = new System.Drawing.Point(12, 227);
            this.txt_thuong.Name = "txt_thuong";
            this.txt_thuong.Size = new System.Drawing.Size(95, 16);
            this.txt_thuong.TabIndex = 6;
            this.txt_thuong.Text = "Thương a / b = ";
            // 
            // txt_tich
            // 
            this.txt_tich.AutoSize = true;
            this.txt_tich.Location = new System.Drawing.Point(12, 193);
            this.txt_tich.Name = "txt_tich";
            this.txt_tich.Size = new System.Drawing.Size(76, 16);
            this.txt_tich.TabIndex = 7;
            this.txt_tich.Text = "Tích a * b = ";
            // 
            // txt_hieu
            // 
            this.txt_hieu.AutoSize = true;
            this.txt_hieu.Location = new System.Drawing.Point(12, 149);
            this.txt_hieu.Name = "txt_hieu";
            this.txt_hieu.Size = new System.Drawing.Size(77, 16);
            this.txt_hieu.TabIndex = 8;
            this.txt_hieu.Text = "Hiệu a - b = ";
            // 
            // btn_thoat
            // 
            this.btn_thoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_thoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_thoat.Location = new System.Drawing.Point(396, 193);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(94, 50);
            this.btn_thoat.TabIndex = 5;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_tinh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btn_thoat;
            this.ClientSize = new System.Drawing.Size(502, 273);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.txt_hieu);
            this.Controls.Add(this.txt_tich);
            this.Controls.Add(this.txt_thuong);
            this.Controls.Add(this.txt_tong);
            this.Controls.Add(this.btn_tinh);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 320);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_tinh;
        private System.Windows.Forms.Label txt_tong;
        private System.Windows.Forms.Label txt_thuong;
        private System.Windows.Forms.Label txt_tich;
        private System.Windows.Forms.Label txt_hieu;
        private System.Windows.Forms.Button btn_thoat;
    }
}

