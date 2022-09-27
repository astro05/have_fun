using System;
using System.Diagnostics;

namespace test
{
    class program
    {
       static int Fibonacci(long from , long to)
        {
            long sum = 0;

            // Simplify the input arguments, as the last digit pattern repeats with a period of 60, 
            // and the sum of 60 such consecutive numbers is 0 mod 10
            int m = (int)(from % 60); // pisanoLength(10) = 60
            int n = (int)(to % 60);

            // make sure n is greater than m
            if (n < m)
                n += 60;

            long current = 0;
            long next = 1;

            for (int i = 0; i <= n; ++i)
            {
                if (i >= m)
                {
                    sum += current;
                }

                long newCurrent = next;
                next = next + current;
                current = newCurrent;
            }

            return (int)(sum % 10);
        }
        
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');
            long num1 = Convert.ToInt64(tokens[0]);
            long num2 = Convert.ToInt64(tokens[1]);

           // int result = (int)Math.Abs(Fibonacci(num2) - Fibonacci(num1 - 1)) ;
            Console.WriteLine(Fibonacci(num1, num2));

        }
    }
}