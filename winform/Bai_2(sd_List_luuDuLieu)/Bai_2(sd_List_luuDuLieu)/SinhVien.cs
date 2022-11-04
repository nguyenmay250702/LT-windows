using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2_sd_List_luuDuLieu_
{
    internal class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public SinhVien()
        {
            MaSV = "001";
            HoTen = "Mặc Định";
            NgaySinh = new DateTime(2002,25,7);
            GioiTinh = true;    //nam
            QueQuan = "Hà Nội";
            Lop = "62TH1";
            Khoa = "CNTT";
        }
        
        public SinhVien(string msv,string ten, DateTime ngaysinh, bool gioitinh, string quequan, string lop, string khoa)
        {
            MaSV = msv;
            HoTen = ten;
            NgaySinh = ngaysinh;
            GioiTinh = gioitinh;
            QueQuan = quequan;
            Lop = lop;
            Khoa = khoa;
        }
    }
}
