using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double tong_tg = 0;

        //nhấn nút start
        private void start_Click(object sender, EventArgs e)
        {
            time_start.Text = "Time start :\t" + DateTime.Now.ToString("HH:mm:ss");
            time_end.Text = "Time end : ";

            tong_tg = 0;
            timer1.Start();

            tong_time.Text = "- Tổng thời gian sd máy tính là: ";
            tong_tien.Text = "- Tổng tiền thanh toán: ";

            shut_down.Enabled = true;
            shut_down.Cursor = Cursors.Hand;
            start.Enabled = false;
            start.Cursor = Cursors.No;
        }

        //nhấn nút shut_down
        private void shut_down_Click(object sender, EventArgs e)
        {
            time_end.Text = "Time end :\t" + DateTime.Now.ToString("HH:mm:ss");
            timer1.Stop();

            shut_down.Enabled = false;
            shut_down.Cursor = Cursors.No;
            start.Enabled = true;
            start.Cursor = Cursors.Hand;

            tong_tg = (double)tong_tg / 3600;
            tong_time.Text = "- Tổng thời gian sd máy tính là: " + tong_tg + " (giờ)";
            tong_tien.Text = "- Tổng tiền thanh toán: " + tong_tg * 5000 + " (đ)";
        }

        //timer sau 1 khoản thời gian interval sẽ thực hiện s kiện "tick"
        private void timer1_Tick(object sender, EventArgs e)
        {
            tong_tg++;
        }
    }
}
