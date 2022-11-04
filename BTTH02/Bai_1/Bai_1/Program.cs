using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tamgiac tg1 = new tamgiac(3,3,3);
            tamgiac tg2 = new tamgiac(3,1,2);

            tg1.kiem_tra_tg();

            tg2.kiem_tra_tg();
            tg2.A = 2;
            tg2.kiem_tra_tg();

            Console.ReadKey();
        }
    }
}
