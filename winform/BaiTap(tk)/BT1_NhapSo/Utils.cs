using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1_NhapSo
{
    public static class Utils
    {
        public static bool isPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static bool isPerfectSquare(int number)
        {
            return (int)Math.Sqrt(number) == Math.Sqrt(number);
        }

        public static bool isPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum == number;
        }
    }
}
