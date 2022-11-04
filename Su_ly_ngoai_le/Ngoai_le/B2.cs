using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ngoai_le
{
    class B2
    {
        public void b2()
        {
            int lastNumber = new Int32();
            Console.Write("Nhập vào số có độ dài = 7: ");
            string firstNumber = Console.ReadLine();
            try
            {
                lastNumber = Convert.ToInt32(firstNumber);
                if (firstNumber.Length != 7)
                {
                    Console.WriteLine("Số nhập vào có độ dài không bằng 7");
                }
                else
                {
                    Console.WriteLine("Done");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Dữ liệu nhập vào không hợp lệ");
            }
        }
    }
}
