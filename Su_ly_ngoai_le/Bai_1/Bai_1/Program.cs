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
            int a, b;
            try
            {
                Console.Write("a = ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("b = ");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a + b = {0} + {1} = {2}",a,b,a+b);
                Console.WriteLine("a - b = {0} - {1} = {2}", a,b,a-b);
                Console.WriteLine("a * b = {0} * {1} = {2}", a, b, a * b);
                Console.WriteLine("a / b = {0} / {1} = {2}", a, b, a / b);

            }
            catch (FormatException)
            {
                Console.WriteLine("Nhap sai du lieu!");
            }
            catch(DivideByZeroException) 
            {
                Console.WriteLine("Mau khong hop le, mau so phai khac 0!");
            }
            Console.ReadKey();
        }
    }
}
