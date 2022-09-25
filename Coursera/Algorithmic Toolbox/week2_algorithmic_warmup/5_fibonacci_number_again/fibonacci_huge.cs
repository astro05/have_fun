using System;
using System.Net.NetworkInformation;

namespace test
{
    class program
    {
        public static ulong pisano(ulong m)
        {
            ulong prev = 0;
            ulong curr = 1;
            ulong res = 0;

            for (ulong i = 0; i < m * m; i++)
            {
                ulong temp = 0;
                temp = curr;
                curr = (prev + curr) % m;
                prev = temp;

                if (prev == 0 && curr == 1)
                    res = i + 1;
            }
            return res;
        }
        public static ulong fibonacci_lastdigit(ulong n, ulong m)
        {
            ulong pisanoPeriod = pisano(m);
            n = n % pisanoPeriod;

            if (n <= 1)
                return (ulong)n;

            ulong previous = 0;
            ulong current = 1;

            for (ulong i = 0; i < n - 1; ++i)
            {
                ulong tmp_previous = current;
                current = (previous + current) % m;
                previous = tmp_previous;

            }

            return (ulong)(current);
        }

        static void Main(string[] args)
        {
            ulong n,m,temp;

            string[] tokens = Console.ReadLine().Split(' ');

            n = (ulong)Convert.ToInt64(tokens[0]);
            m = (ulong)Convert.ToInt64(tokens[1]);

            System.Console.WriteLine(fibonacci_lastdigit(n,m));
            

        }
    }
}