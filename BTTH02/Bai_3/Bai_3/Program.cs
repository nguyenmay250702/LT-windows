using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            HinhTron htr1 = new HinhTron(3);
            Console.WriteLine("- Thong tin hinh tron: ");
            htr1.print();
            Console.WriteLine("Dien tich hinh tron: " + htr1.Dien_Tich);

            HinhCau hc1 = new HinhCau(6);
           // HinhTron hc1 = new HinhCau(4);
            Console.WriteLine("\n- Thong tin hinh cau: ");
            hc1.print();
            Console.WriteLine("Dien tich hinh cau: " + hc1.Dien_Tich);
            Console.WriteLine("The tich hinh cau: " + hc1.The_Tich);

            Console.ReadKey();
        }
    }
}
