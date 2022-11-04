using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_5
{
    class myexception : AccessViolationException
    {
        //hàm tạo
         public myexception (string s) : base(s){ }
    }
    internal class Tam_giac
    {
        double c1, c2, c3;
        
        public void nhap()
        {
            if(!Double.TryParse(Console.ReadLine(),out c1) || !Double.TryParse(Console.ReadLine(),out c2) || !Double.TryParse(Console.ReadLine(), out c3))
            {
                throw new myexception("\tLoi!!! Du lieu nhap vao khong phai la so");
            }
            else if (c1+c2 <= c3 || c1+c3 <= c2 || c2+c3 <= c1)
            {
                throw new myexception("\tLoi!!! Khong phai la 3 canh tam giac");
            }
            else if(c1<=0 || c2<=0 || c3<=0)
            {
                throw new myexception("\tLoi!!! Gia tri nhap voa am");
            }
        }

        public double dien_tich()
        {
            double p = (c1 + c2 + c3) / 2;
            return Math.Sqrt(p * (p - c1) * (p - c2) * (p - c3));
        }
        public double chu_vi()
        {
            return (c1 + c2 + c3);
        }
    }
}
