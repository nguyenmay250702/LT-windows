using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaTranVuong matrix1 = new MaTranVuong(2, 2);
            MaTranVuong matrix2 = new MaTranVuong(2, 2);
            MaTranVuong total_matrix = new MaTranVuong();
            MaTranVuong subtract_matrix = new MaTranVuong();
            try
            {
                matrix1.nhap();
                Console.WriteLine("Ma tran 1:");
                matrix1.xuat();
                matrix2.nhap();
                Console.WriteLine("Ma tran 2:");
                matrix2.xuat();

                //cộng 2 ma trận
                total_matrix = matrix1 + matrix2;
                Console.WriteLine("Tong matrix1 + matrix2 = ");
                total_matrix.xuat();

                //trừ 2 ma trận
                subtract_matrix = matrix1 + matrix2;
                Console.WriteLine("Tong matrix1 - matrix2 = ");
                subtract_matrix.xuat();


            }
            catch ( myexception ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
