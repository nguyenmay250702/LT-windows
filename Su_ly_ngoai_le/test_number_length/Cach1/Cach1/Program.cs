using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_number_length
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            try
            {
                Console.Write("Nhap so = ");
                number = Convert.ToInt32(Console.ReadLine());
                if (number.ToString().Length != 7)
                {
                    Console.WriteLine("Loi!!! So nhap vao co do dai khac 7");
                }
                else
                {
                    Console.WriteLine("Hop le. So nhap vao gom 7 chu so");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Du lieu nhap vao khong hop le!!!");
            }

            Console.ReadKey();
        }
    }
}
