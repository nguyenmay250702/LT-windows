using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngoai_le
{
    class B3
    {
        public void b3()
        {
            TAMGIAC[] tamgiac = new TAMGIAC[3];

            try
            {
                Console.WriteLine("nhập giá trị cho 3 tam giác");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("tam giác {0}", i+1);
                    tamgiac[i] = new TAMGIAC();
                    tamgiac[i].input();
                }

                Console.WriteLine("chu vi của 3 tam giác");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("tam giác {0}: ",i+1);
                    Console.WriteLine(tamgiac[i].chuVi());
                }
            }
            catch (B3Exeception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class TAMGIAC
    {
        double canh1, canh2, canh3;
        public TAMGIAC()
        {
            canh1 = 1;
            canh2 = 1;
            canh3 = 1;
        }
        public TAMGIAC(double newCanh1, double newCanh2, double newCanh3)
        {
            canh1 = newCanh1;
            canh2 = newCanh2;
            canh3 = newCanh3;
        }

        public void input()
        {
            if (!Double.TryParse(Console.ReadLine(), out canh1) || !Double.TryParse(Console.ReadLine(), out canh2) || !Double.TryParse(Console.ReadLine(), out canh3))
            {
                throw new B3Exeception("không thể gán chữ cái hoặc kí tự đặc biệt cho độ dài của cạnh");
            }
            else if (canh1 <= 0 || canh2 <= 0 || canh3 <= 0)
            {
                throw new B3Exeception("độ dài của cạnh phải lớn hơn 0");
            }
            else if (canh1 + canh2 <= canh3 || canh1 + canh3 <= canh2 || canh3 + canh2 <= canh1) 
            {
                throw new B3Exeception("tam giác không hợp lệ");
            }
        }

        public double chuVi()
        {
            return (canh1 + canh2 + canh3);
        }
    }

    class B3Exeception : Exception
    {
        public B3Exeception(string ex) : base(ex) { }
    }
}
