using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult lua_chon = MessageBox.Show("Ten dang nhap: " + txtUser.Text + "\n" + "Mat khau: "+ txtPass.Text,"Luu mat khau ?", MessageBoxButtons.YesNo);
            if(lua_chon == DialogResult.Yes)
            {
                chkNho.Checked = true;
            }
            else
            {
                chkNho.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtUser.Text = "";
            txtUser.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
