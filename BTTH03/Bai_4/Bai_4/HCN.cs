using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_4
{
    class myexception : AccessViolationException
    {
        public myexception (string s): base(s)
        {

        }
    }

    internal class HCN
    {
        double chieu_dai, chieu_rong, test;

        public void nhap()
        { 
            Console.WriteLine("- Nhap chieu dai & chieu rong: ");
            if(!Double.TryParse(Console.ReadLine(), out chieu_dai))
            {
                throw new myexception("Loi!!! Chieu dai khong co dinh dang so");
            }
            else if(!Double.TryParse(Console.ReadLine(), out chieu_rong))
            {
                throw new myexception("Loi!!! Chieu khong co dinh dang so");
            }
            else if (chieu_dai < chieu_rong)
            {
                throw new myexception("Loi!!! CHieu dai < chieu rong");
            }
            else if(chieu_rong < 0 || chieu_dai < 0)
            {
                throw new myexception("Loi!!! Ban da nhap so am");
            }
        }

        public double dien_tich()
        {
            return chieu_dai * chieu_rong;
        }
    }
}
