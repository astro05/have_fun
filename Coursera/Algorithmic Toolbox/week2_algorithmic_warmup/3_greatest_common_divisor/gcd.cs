using System;
using System.Diagnostics;

namespace test
{
    class program
    {
       public static long NaiveGcd(long a, long b)
        {
            long best = 0;
            for (long i = 1; i < a+b; i++)
            {
                if ((a%i)==0 && (b%i)==0)
                {
                    best = i;
                }
            }
            return best;
        }

        public static long EuclidGcd(long a, long b)
        {
            if (b ==0)
            {
                return (long)a;
            }
            a = a % b;
            return EuclidGcd(b,a);

        }

        static void Main(string[] args)
        {
            long n,a;
           
            System.Console.WriteLine("Enter number: ");
            n = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter 2nd number");
            a = Convert.ToInt64(Console.ReadLine());


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Naive Gcd is: " + NaiveGcd((long)n, (long)a));

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            Console.WriteLine("Euclid Gcd is: " + EuclidGcd(n,a));

            stopwatch2.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch2.ElapsedMilliseconds);


        }
    }
}