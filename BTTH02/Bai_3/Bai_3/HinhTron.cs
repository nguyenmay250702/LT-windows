using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3
{
    internal class HinhTron
    {
        double ban_kinh;

        //hàm tạo
        public HinhTron()
        {
            ban_kinh = 1;
        }

        public HinhTron(double R)
        {
            ban_kinh = R;
        }

        //thuộc tính
        public double Ban_Kinh {
            get { return ban_kinh; } 
            set { ban_kinh = value;} 
        }

        public double Duong_kinh {
            get { return ban_kinh*2;}
        }

        public double Dien_Tich
        {
            get { return Math.PI * ban_kinh * ban_kinh;}
        }

        // xuat
        public void print()
        {
            Console.WriteLine("Ban kinh: " + ban_kinh);
            Console.WriteLine("Duong kinh: " + Duong_kinh);
        }
    }

    class HinhCau : HinhTron
    {
        public HinhCau(double R) : base(R) {}

        //tạo ra phiên bản mới trong lớp con sd từ khóa "new"
        public double Dien_Tich
        {
            get
            {
                return 4 * Math.PI * Math.Pow(Ban_Kinh,2);
            }
        }

        public double The_Tich
        {
            get
            {
                return 4/3 * Math.PI * Math.Pow(Ban_Kinh,3);
            }
        }
    }
}
