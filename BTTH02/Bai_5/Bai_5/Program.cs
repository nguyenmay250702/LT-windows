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
            Rectangle hcn = new Rectangle(4, 5);
            Console.WriteLine("Dien tich HCN: " + hcn.Area());
            Console.WriteLine("Chu vi HCN: " + hcn.Circumference());
            Console.WriteLine("So canh cua HCN: " + hcn.Sides());
            Console.ReadKey();
        }
    }
}
