using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2_2_
{
    internal class MaTranVuong
    {
        int row;
        int col;
        int [,] matrix;

        //Hàm tạo
        public MaTranVuong()
        {
            row = 0;
            col = 0;
            matrix = new int[2, 2];
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        public MaTranVuong(int r, int c)
        {
            row = r;
            col = c;
            matrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        //Thuoc tinh
        
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }

        //nhap
        public void nhap()
        {
            Console.WriteLine("- Nhap thong tin ma tran: ");
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("\nNhap hang thu {0}: ", i);
                for (int j = 0; j < col; j++)
                {
                    Console.Write("\ta[{0}][{1}] = ", i, j);
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("\n");
            }
        }

        //xuat
        public void xuat()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("\t{0}", matrix[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        //thay doi 1 gia tri tỏng ma tran
        public void setValueMatrix(int index_row, int index_col, int new_value)
        {
            matrix[index_row, index_col] = new_value;
        }

        //lấy ra giá trị bất kì theo chỉ số của ma trận
        public int get_value_matrix(int index_row, int index_col)
        {
            return matrix[index_row,  index_col];
        }

        //Cộng 2 ma trận
        public static MaTranVuong operator +(MaTranVuong mt1, MaTranVuong mt2)
        {
            if(mt1.row == mt2.row && mt1.col == mt2.col)
            {
                MaTranVuong total_matrix = new MaTranVuong(mt1.row, mt1.col);
                for (int i = 0; i < total_matrix.row; i++)
                {
                    for (int j = 0; j < total_matrix.col; j++)
                    {
                        total_matrix.setValueMatrix(i, j, mt1.get_value_matrix(i, j) + mt2.get_value_matrix(i, j));
                    }
                }
                return total_matrix;
            }
            else
            {
                throw new myexception("Khong the cong 2 ma tran. Do khong cung kich co");
            }
        }

        //Trừ 2 ma trận
        public static MaTranVuong operator -(MaTranVuong mt1, MaTranVuong mt2)
        {
            if (mt1.row == mt2.row && mt1.col == mt2.col)
            {
                MaTranVuong total_matrix = new MaTranVuong(mt1.row, mt1.col);
                for (int i = 0; i < total_matrix.row; i++)
                {
                    for (int j = 0; j < total_matrix.col; j++)
                    {
                        total_matrix.setValueMatrix(i, j, mt1.get_value_matrix(i, j) - mt2.get_value_matrix(i, j));
                    }
                }
                return total_matrix;
            }
            else
            {
                throw new myexception("Khong the tru 2 ma tran. Do khong cung kich co");
            }
        }

    }

    public class myexception: ApplicationException
    {
        public myexception(string s):base(s) { }
    }



}
