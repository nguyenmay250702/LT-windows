using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaTranVuong a = new MaTranVuong (10,10);
            int [,] b = new int[5,5];
            int [,] c = new int[5,5];

            a.input(b);
            //a.input(c);

            Console.WriteLine("- Ma tran nhap vao: ");
            a.print(b);
           // a.input(c);

            a[1,1];

            //Console.Write("- Tong 2 ma tran: "); Console.Write(b); Console.Write("+"); Console.Write(c);
            //Console.WriteLine(b+c);
            
            
            



            Console.ReadKey();

        }
    }
}
