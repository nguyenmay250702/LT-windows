using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = "kjsdkj   h  (jkasjdh) jkahs  ";
            Console.WriteLine("Chuoi ban dau: " + a);
            for(int i=0; i< a.Length; i++)
            {
            
                if(i == 0)
                {
                    a = a.Insert(i,"(");
                }
                
                else if(i == a.Length - 1)
                {
                    Console.WriteLine(i);
                    //a = a.Insert(i,")");
                }
                
                /*
                else if(a[i] != ' ' && a[i] != '(' && a[i-1] == ' ')
                {
                    a = a.Insert(i,"(");
                }
                else if(a[i] != ' ' && a[i] != ')' && a[i+1] == ' ')
                {
                    a = a.Insert(i,")");
                }
                */
            }

            Console.WriteLine("Chuoi sau khi them () vao: " + a);
            Console.ReadKey();
        }
    }
}
