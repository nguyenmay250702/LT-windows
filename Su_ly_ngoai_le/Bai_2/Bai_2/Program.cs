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
            Test[] nguoi = new Test[2];
            try
            {
                nguoi[0] = new Test();
                nguoi[0].nhap();
               // nguoi[4].nhap();
            }
            catch (myexception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
