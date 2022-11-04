using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a;
            Console.Write("Nhap chuoi a = ");
            a = Console.ReadLine();
            Console.WriteLine("Chuoi truoc khi dao nguoc: " + a);

            Console.Write("Chuoi sau khi dao nguoc: ");
            for (int i = a.Length-1; i>=0; i--)
            {
                Console.Write(a[i]);
            }
            Console.ReadKey();
        }
    }
}
