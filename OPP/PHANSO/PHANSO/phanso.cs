using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHANSO
{
    internal class phanso
    {
        //không chỉ rõ quyền truy cập thì mặc đinh là private
        int tu_so, mau_so;

        //hàm tạo không tham số
        public phanso()
        {
            tu_so = 0;
            mau_so = 1;
        }

        //hàm tạo 2 tham số
        public phanso(int tu_so_new, int mau_so_new)
        {
            tu_so = tu_so_new;
            mau_so = mau_so_new;
        }

        //hàm rút gọn
        public void rutgon()
        {
            int UCLN = 1;
            int length = (Math.Abs(tu_so) < Math.Abs(mau_so))? Math.Abs(tu_so) : Math.Abs(mau_so);
            for(int i=1; i<=length; i++)
            {
                if(tu_so%i == 0 && mau_so%i == 0)
                {
                    UCLN = i;
                }
            }
            tu_so = tu_so/UCLN;
            mau_so = mau_so/UCLN;
        }

        public void input()
        {
            Console.Write("\tNhap Tu so = ");
            tu_so = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tNhap Mau so = ");
            mau_so = Convert.ToInt32(Console.ReadLine());
        }

        public void output()
        {
            if(tu_so == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                rutgon();
                Console.WriteLine(tu_so + "/" + mau_so);
            }
        }

        public static phanso operator +(phanso a, phanso b)
        {
            phanso kq = new phanso();
            kq.tu_so = a.tu_so * b.mau_so + b.tu_so * a.mau_so;
            kq.mau_so = a.mau_so*b.mau_so;
            return kq;
        }

        public static phanso operator -(phanso a, phanso b)
        {
            phanso kq = new phanso();
            kq.tu_so = a.tu_so*b.mau_so - b.tu_so * a.mau_so;
            kq.mau_so = a.mau_so * b.mau_so;
            return kq;
        }

        public static phanso operator *(phanso a, phanso b)
        {
            phanso kq = new phanso();
            kq.tu_so = a.tu_so * b.tu_so;
            kq.mau_so = a.mau_so * b.mau_so;
            return kq;
        }

        public static phanso operator /(phanso a, phanso b)
        {
            phanso kq = new phanso();
            kq.tu_so = a.tu_so * b.mau_so;
            kq.mau_so = a.mau_so * b.tu_so;
            return kq;
        }

    }
}
