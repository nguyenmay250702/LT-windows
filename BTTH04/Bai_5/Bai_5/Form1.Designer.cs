namespace Bai_5
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
            this.components = new System.ComponentModel.Container();
            this.time_end = new System.Windows.Forms.Label();
            this.time_start = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.shut_down = new System.Windows.Forms.Button();
            this.tong_time = new System.Windows.Forms.Label();
            this.tong_tien = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // time_end
            // 
            this.time_end.AutoSize = true;
            this.time_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_end.Location = new System.Drawing.Point(86, 125);
            this.time_end.Name = "time_end";
            this.time_end.Size = new System.Drawing.Size(95, 22);
            this.time_end.TabIndex = 2;
            this.time_end.Text = "Time end :";
            // 
            // time_start
            // 
            this.time_start.AutoSize = true;
            this.time_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_start.Location = new System.Drawing.Point(86, 51);
            this.time_start.Name = "time_start";
            this.time_start.Size = new System.Drawing.Size(100, 22);
            this.time_start.TabIndex = 3;
            this.time_start.Text = "Time start :";
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(397, 39);
            this.start.MaximumSize = new System.Drawing.Size(126, 46);
            this.start.MinimumSize = new System.Drawing.Size(126, 46);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(126, 46);
            this.start.TabIndex = 4;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // shut_down
            // 
            this.shut_down.BackColor = System.Drawing.Color.IndianRed;
            this.shut_down.Enabled = false;
            this.shut_down.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shut_down.Location = new System.Drawing.Point(397, 113);
            this.shut_down.MaximumSize = new System.Drawing.Size(126, 46);
            this.shut_down.MinimumSize = new System.Drawing.Size(126, 46);
            this.shut_down.Name = "shut_down";
            this.shut_down.Size = new System.Drawing.Size(126, 46);
            this.shut_down.TabIndex = 5;
            this.shut_down.Text = "SHUT DOWN";
            this.shut_down.UseVisualStyleBackColor = false;
            this.shut_down.Click += new System.EventHandler(this.shut_down_Click);
            // 
            // tong_time
            // 
            this.tong_time.AutoSize = true;
            this.tong_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong_time.Location = new System.Drawing.Point(86, 213);
            this.tong_time.Name = "tong_time";
            this.tong_time.Size = new System.Drawing.Size(234, 22);
            this.tong_time.TabIndex = 6;
            this.tong_time.Text = "- Tổng thời gian sử dụng mt:";
            // 
            // tong_tien
            // 
            this.tong_tien.AutoSize = true;
            this.tong_tien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tong_tien.Location = new System.Drawing.Point(86, 263);
            this.tong_tien.Name = "tong_tien";
            this.tong_tien.Size = new System.Drawing.Size(107, 22);
            this.tong_tien.TabIndex = 7;
            this.tong_tien.Text = "- Tổng tiền: ";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(623, 327);
            this.Controls.Add(this.tong_tien);
            this.Controls.Add(this.tong_time);
            this.Controls.Add(this.shut_down);
            this.Controls.Add(this.start);
            this.Controls.Add(this.time_start);
            this.Controls.Add(this.time_end);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(641, 374);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính tiền sử dụng mt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label time_end;
        private System.Windows.Forms.Label time_start;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button shut_down;
        private System.Windows.Forms.Label tong_time;
        private System.Windows.Forms.Label tong_tien;
        private System.Windows.Forms.Timer timer1;
    }
}

