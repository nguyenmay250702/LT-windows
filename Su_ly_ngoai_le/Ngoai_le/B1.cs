using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngoai_le
{
    class B1
    {
        public void b1()
        {
            int a = new Int32();
            int b = new Int32();
            try
            {
                Console.Write("Nhập a: ");
                a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhập b: ");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("a + b = {0}", a + b);
                Console.WriteLine("a + b = {0}", a - b);
                Console.WriteLine("a + b = {0}", a * b);
                Console.WriteLine("a + b = {0}", a / b);
            }
            catch (FormatException)
            {
                Console.WriteLine("Dữ liệu nhập vào không hợp lệ");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Không thể chia cho 0");
            }
        }
    }
}
