using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_6
{
    internal class Program
    {
        public void ReadNumber(int start, int end, ref int value)
        {
            if(!int.TryParse(Console.ReadLine(), out value))
            {
                throw new myexception("So nhap vao khong thuoc kieu du lieu 'int'");
            }
            else if(value <= start || value >= end)
            {
                throw new myexception("gia tri nhap vao vuot qua gia han");
            }
        }

        //nhập 10 số
        public void input(int start, int end)
        {
            int[] array = new int[10];

            Console.WriteLine("- Nhap 10 gia tri: ");
            for(int i = 0; i < 10; i++)
            {
                Console.Write("\ta{0} = ",i+1);
                ReadNumber(start, end, ref array[i]);

                if (i!=0)
                {
                   if(array[i] < array[i - 1])
                   {
                        throw new myexception("Loi!!! gia tri sau < gia tri truoc");
                   }
                }
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //int n = new int();
            try
            {
                //p.ReadNumber(3, 7, n);
                p.input(1, 100);
            }
            catch(myexception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }
    }

    class myexception : ApplicationException
    {
        public myexception(string s) : base(s) { }
    }
}
