using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHANSO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            phanso ps1, ps2;
            ps1 = new phanso();
            ps2 = new phanso();

            Console.WriteLine("- Nhap phan so ps1:");
            ps1.input();

            Console.WriteLine("\n- Nhap phan so ps2:");
            ps2.input();

            //Cộng 2 phân số
            Console.Write("\nps1 + ps2 = "); (ps1 + ps2).output();

            Console.Write("\nps1 - ps2 = "); (ps1 - ps2).output();

            Console.Write("\nps1 * ps2 = "); (ps1 * ps2).output();

            Console.Write("\nps1 / ps2 = "); (ps1 / ps2).output();

            Console.ReadKey();
        }
    }
}
