using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_6
{
    internal class Program_06
    {
        static void Main(string[] args)
        {
            string a;
            Console.Write("Nhap vao chuoi a = ");
            a = Console.ReadLine();
            Console.WriteLine("Chuoi ban dau a = " + a);

            Console.WriteLine("Chuoi sau khi thay the a = " + a.Replace("no", "yes"));
            Console.ReadKey();
        }
    }
}
