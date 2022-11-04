using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    internal class program_2
    {
        static void Main(string[] args)
        {
            int a, b;
            do
            {
                Console.Write("Nhap a = ");
                a = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nhap b = ");
                b = Convert.ToInt32(Console.ReadLine());
            }
            while (a > 10 && b > 10);

            Console.WriteLine("Gia tri a = {0}; b = {1}", a, b);
            Console.ReadKey();
        }
    }
}
