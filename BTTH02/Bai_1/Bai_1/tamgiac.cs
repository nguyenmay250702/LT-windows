using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class tamgiac
    {
        double a, b, c;

        //hàm tạo
        public tamgiac()
        {
            a = 1;
            b = 1;
            c = 1;
        }
        public tamgiac(double c1, double c2, double c3)
        {
            a = c1;
            b = c2;
            c = c3;
        }

        //thuộc tính
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        
        public double C
        {
            get { return c; }
            set { c = value; }
        }
        
        //phương thức
        public double chu_vi()
        {
            return (a + b + c);
        }

        public double dien_tich()
        {
            double p = (a + b + c) / 2;
            return (Math.Sqrt(p * (p - a)*(p - b)*(p - c)));
        }

        public void kiem_tra_tg()
        {
            if(a+b>c && a+c>b && b+c > a)
            {
                if(a*a==b*b+c*c && b*b==a*a+c*c && c*c==a*a+b*b)
                {
                    Console.WriteLine("\n- Day la tam giac vuong");
                }
                else if(a == b && b == c)
                {
                    Console.WriteLine("\n- Day la tam giac deu");
                }
                else if(a==b || a==c || b == c)
                {
                    Console.WriteLine("\n- Day la tam giac can");
                }
                else
                {
                    Console.WriteLine("\n- Day la tam gia thuong");
                }
                Console.WriteLine("\t+ Chu vi cua tam giac: " + chu_vi());
                Console.WriteLine("\t+ Dien tich cua tam giac: " + dien_tich());

            }
            else
            {
                Console.WriteLine("\n- Day khong phai la tam giac");
            }
        }
    }
}
