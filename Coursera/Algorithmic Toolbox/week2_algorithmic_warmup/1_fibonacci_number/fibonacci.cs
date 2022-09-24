using System;
using System.Diagnostics;

namespace test
{
    class program
    {
        public static int fibonacci_slow(int n)
        {
            if (n <= 1)
                return n;
            else
            {
                return fibonacci_slow(n - 1) + fibonacci_slow(n - 2);
            }

        }

        public static ulong fibonacci_fast(int n)
        {
            ulong[] fib = new ulong[n+1];
            
            if (n <= 1)
                return (ulong)n;
            else
            {
                fib[0] = 1;
                fib[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }

                long v = (long)fib[n-1];
                return (ulong)v;
            
            }
        }
        static void Main(string[] args)
        {
            int n;
           
            System.Console.WriteLine("Enter number: ");
           
            n = Convert.ToInt32(Console.ReadLine());

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Console.WriteLine(fibonacci_fast(n));
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            System.Console.WriteLine(fibonacci_slow(n));
            stopwatch2.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch2.ElapsedMilliseconds);


        }
    }
}