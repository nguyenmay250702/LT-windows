using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    public class Tester
    {
        public static void Main()
        {
            uint so1 = 0;
            int so2, so3;
            so2 = -10;
            so3 = 0;

            //tính giá trị lại
            so1 -= 35;
            try
            {
                so2 = 5 / so3;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Loi !!! " +  e.Message);
            }

            //xuất kết quả
            Console.WriteLine("So1: {0}, So 2: {1}", so1, so2);
            Console.ReadKey();
        }
    }
}
