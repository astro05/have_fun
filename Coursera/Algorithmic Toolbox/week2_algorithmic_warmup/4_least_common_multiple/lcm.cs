using System;
using System.Diagnostics;

namespace test
{
    class program
    {
        public static long EuclidGcd(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }
            a = a % b;
            return EuclidGcd(b, a);

        }

        public static long LCD(long num1, long num2)
        {
            return (num1 * num2) / EuclidGcd(num1, num2);
        }
        
        static void Main(string[] args)
        {
            long num1, num2;

            string[] tokens = Console.ReadLine().Split(' ');
            
            num1 = Convert.ToInt64(tokens[0]);
            num2 = Convert.ToInt64(tokens[1]);

            Console.WriteLine(LCD(num1,num2));

        }
    }
}