using System;

namespace test
{
    class program
    {
        public static ulong fibonacci_lastdigit(ulong n)
        {


            if (n <= 1)
                return (ulong)n;

            ulong previous = 0;
            ulong current = 1;
            ulong temp_current = 0;

            for (ulong i = 0; i < n - 1; ++i)
            {
                ulong tmp_previous = previous %10;
                previous = current % 10;
                current = tmp_previous + current;
                temp_current = current % 10;
            }

            return (ulong)(temp_current);
        }

        static void Main(string[] args)
        {
            ulong n;
           
            n = (ulong)Convert.ToInt64(Console.ReadLine());
            System.Console.WriteLine(fibonacci_lastdigit(n));
            

        }
    }
}