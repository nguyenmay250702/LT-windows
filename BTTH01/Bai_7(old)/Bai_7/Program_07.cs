using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_7
{
    internal class Program_07
    {
        static void Main(string[] args)
        {
            string A = "kjsdkj   h  (jkasjdh) jkahs  ";
            Console.WriteLine("chuoi goc: {0}", A);
            if (A[0] != ' ')
            {
                A = A.Insert(0,"(");
            }
            for (int i = 1; i < A.Length-1; i++)
            {
                if (A[i] != ' ' && A[i - 1] == ' ' && A[i] != '(')
                {
                    A = A.Insert(i, "(");
                }
                else if (A[i] == ' ' && A[i - 1] != ' ' && A[i - 1] != ')')
                {
                    A = A.Insert(i, ")");
                }
            }
            if (A[A.Length-1] != ' ')
            {
                A = A.Insert(A.Length, ")");
            }
            Console.WriteLine("chuoi sau khi them (): {0}", A);
            Console.ReadKey();
        }
    }
}
