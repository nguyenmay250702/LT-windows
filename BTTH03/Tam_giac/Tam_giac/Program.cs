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
                Tam_giac [] tg = new Tam_giac[3];
            try
            {
                for (int i = 0; i < tg.Length; i++)
                {
                    tg[i] = new Tam_giac();
                    Console.WriteLine("\n- Nhap thong tin tam giac thu : " + (i + 1));
                    tg[i].nhap();
                    Console.WriteLine("\t+ Chu vi = " + tg[i].chu_vi());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
