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

namespace De_12
{
    public partial class NhapDiem : Form
    {
        SqlConnection sqlCon = null;
        public NhapDiem()
        {
            InitializeComponent();
        }

        //load dữ liệu lên combobox
        private void uploadData_Combobox(string str, ComboBox cbb, string nameDisplayMember)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(str, sqlCon);
            DataTable table = new DataTable();
            adapter.Fill(table);
            cbb.DataSource = table;
            cbb.DisplayMember = nameDisplayMember;
            cbb.SelectedIndex = -1;
        }

        private void NhapDiem_Load(object sender, EventArgs e)
        {
            sqlCon = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True");
            sqlCon.Open();
            uploadData_Combobox("select MaSo from SinhVien", cbb_MaSo, "MaSo");
            uploadData_Combobox("select HoTen from SinhVien group by HoTen", cbb_HoTen, "HoTen");
            uploadData_Combobox("select MaMH from Mon", cbb_MaMon, "MaMH");
            uploadData_Combobox("select TenMH from Mon", cbb_TenMon, "TenMH");
            sqlCon.Close();
        }

        //nhập dữ liệu
        private void btn_Nhap_Click(object sender, EventArgs e)
        {

        }
    }
}
