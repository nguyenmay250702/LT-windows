using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_GiaoThong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            pt_giaothong [] pt1 = new pt_giaothong[4];
            while (true)
            {
                int chon;
                Console.WriteLine("\n\n\t- CAC PHUONG TIEN GIAO THONG: ");
                Console.WriteLine("1. Stop");
                Console.WriteLine("2. oto");
                Console.WriteLine("3. Xe may");
                Console.WriteLine("4. Tau thuy");
                Console.Write("Ban chon phuong tien nao? (1|2|3|4): ");
                chon = Convert.ToInt32(Console.ReadLine());

                if(chon == 1)
                {
                    Console.WriteLine("\t- Ban da chon thoat khoi truong trinh");
                    break;
                }
                else if (chon == 2)
                {
                    pt1[0] = new o_to();
                    pt1[0].print();
                }
                else if(chon == 3)
                {
                    pt1[1] = new xe_may();
                    pt1[1].print();
                }
                else if(chon == 4)
                {
                    pt1[2]= new tau_thuy();
                    pt1[2].print();
                }
                else
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long kiem tra lai!!!");
                }
            }

            Console.ReadKey();
        }
    }
}
