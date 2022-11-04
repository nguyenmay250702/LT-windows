using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    internal class Test
    {
        double tuoi;
        public void nhap()
        {
            Console.Write("Nhap tuoi: ");
            if(!Double.TryParse(Console.ReadLine(), out tuoi))
            {
                throw new myexception("Du lieu khong hop le!!!");
            }
            else if(tuoi < 18)
            {
                throw new myexception("Qua tre");
            }
            else if (tuoi > 40)
            {
                throw new myexception("Qua gia");
            }
            else
            {
                Console.WriteLine("Dat yeu cau");
            }
        }
    }

    class myexception : ApplicationException
    {
        public myexception (string s) : base(s) { }
    }
}
