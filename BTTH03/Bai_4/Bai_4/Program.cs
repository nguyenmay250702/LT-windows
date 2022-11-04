using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HCN hcn1 = new HCN();
            try
            {
                hcn1.nhap();
                Console.WriteLine("Dien tich HCN : " + hcn1.dien_tich());
            }
            catch (myexception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
