using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bai_5
{
    public interface IDimensions
    {
        //chỉ có các nguyên mẫu phương thức, thuộc tính, chỉ mục được khai báo trong giao diện.
        //long width;   (lỗi do đây là biến thành viên và không đc khai báo trong giao diện)
        //long height;
        double Area();
        double Circumference();
        int Sides();
    }

    public class Rectangle : IDimensions
    {
        double width;
        double height;
        public Rectangle()
        {
            width = 1;
            height = 1;
        }
        public Rectangle(double newWidth, double newHeight)
        {
            width = newWidth;
            height = newHeight;
        }

        //diện tích hình chữ nhật
        public double Area()
        {
            return width * height;
        }

        //chu vi hình chữ nhật
        public double Circumference()
        {
            return (height + width) * 2;
        }

        //số mặt của hình chữ nhật
        public int Sides()
        {
            return (4);
        }
    }
}
