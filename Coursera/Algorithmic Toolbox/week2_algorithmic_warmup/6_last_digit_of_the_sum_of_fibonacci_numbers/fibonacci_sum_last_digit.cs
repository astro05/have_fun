using System;
using System.Diagnostics;

namespace test
{
    class program
    {
       static int Fibonacci(long num)
        {
            if (num <= 1)
            {
                return (int)num;
            }

            int prev = 0;
            int current = 1;

            int rem = (int)(num % 60); // Pisano period for %10 is 60

            if (rem == 0)
            {
                return 0;
            }

            for (int i = 2; i < rem + 3; i++)
            {
                int temp = ((prev + current) % 60);
                prev = current;
                current = temp;
                
            }

            int last_digit = (int)(current - 1);

            return last_digit; 
        }
        
        static void Main(string[] args)
        {
            long num = Convert.ToInt64( Console.ReadLine());
            
            Console.WriteLine(Fibonacci(num) % 10);

        }
    }
}