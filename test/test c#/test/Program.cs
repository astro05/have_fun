using System;
using System.Diagnostics;

namespace test
{
    class program
    {
       static long Fibonacci(long num)
        {
            if (num <= 1)
            {
                return num;
            }

            long prev = 0;
            long current = 1;
            long temp = 0;

            long rem = num % 60;

            if (rem ==0)
            {
                return 0;
            }

            for (long i = 2; i <= rem+3; i++)
            {
                temp = ((prev + current) % 60);
                prev = current;
                current = temp;
                
            }

            int last_digit = (int)(current - 1);

            return last_digit; 
        }
        
        static void Main(string[] args)
        {
            long num = Convert.ToInt64( Console.ReadLine());
            
            Console.WriteLine(Fibonacci(num));

        }
    }
}