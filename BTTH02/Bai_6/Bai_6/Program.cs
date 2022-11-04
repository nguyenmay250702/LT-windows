using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("meo_trang");
            Dog dog = new Dog("cho_vang");

            Console.WriteLine(cat.name);
            Console.WriteLine(dog.name);

            Console.ReadKey();
        }
    }
}
