using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    class MaTranVuong
    {
        int row;      
        int col;
        
        //hàm tạo
        public MaTranVuong()
        {
            row = 0;
            col = 0;
        }
        public MaTranVuong(int r, int c)
        {
            row = r;
            col = c;
        }

        //nhập
       // public void input()



        
        public void input(int [,] a)
        {
            Console.Write("Nhap co ma tran row = ");
            row = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap co ma tran col = ");
            col = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("\nNhap hang thu {0}: ", i);
                for(int j = 0; j < col; j++)
                {
                    Console.Write("\ta[{0}][{1}] = ", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("\n");
            }
        }

        //xuất
        public void print(int [,] a)
        {
            for(int i = 0; i < row; i++)
            {
                for(int j=0; j < col; j++)
                {
                    Console.Write("\t{0}", a[i,j]);
                }
                Console.Write("\n");
            }
        }

        //Định thức ma trận
        /*public void dinh_thuc(int [,] a)
        {
            for(int i=0; i<row; i++)
            {
                double det = 0;
                det = det + (a[0, i] * (a[1, (i + 1) % row] * a[2, (i + 2) % row] - a[1, (i + 2) % row] * a[2, (i + 1) % row]));
            }
        }*/

        //Cộng 2 ma trận
       /*
        public static MaTranVuong operator +(int[,] a,  int[,] b)
        {
            MaTranVuong d = new MaTranVuong(row, col);
            int [,] c;
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    c[i,j] = a[i,j] + b[i,j];
                }
            }
            return d;
        }
       */

        //Trừ 2 ma trận
        /*
        public static MaTranVuong operator -(MaTranVuong [,] a , MaTranVuong [,] b)
        {
            double [,] c;
            for(int i = 0; i<n ; i++)
            {
                for(int j=0; j<n ; j++)
                {
                    c[i,j] = a[i,j] - b[i,j];
                }
            }
            return c;
        }

        */
    }
}
