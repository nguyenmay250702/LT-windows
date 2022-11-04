using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_GiaoThong
{
    abstract class pt_giaothong
    {
        public abstract void print();
    }

    class o_to : pt_giaothong
    {
        public override void print()
        {
            Console.WriteLine("\t- Phuong thuc di chuyen oto");
        }
    }
    
    class tau_thuy : pt_giaothong
    {
        public override void print()
        {
            Console.WriteLine("\t- Phuong thuc di chuyen cua tau thuy");
        }
    }

    class xe_may : pt_giaothong
    {
        public override void print()
        {
            Console.WriteLine("\t- Phuong thuc van chuyen cua xe may");
        }
    }
}
