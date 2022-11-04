using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class program_1
    {
        static void Main(string[] args)
        {
            int a, b, c, d;
            Console.Write("Nhap a = ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap b = ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap c = ");
            c = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap d = ");
            d = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Tich a*b*c*d = " + a * b * c * d);

            Console.ReadKey();
        }
    }
}
