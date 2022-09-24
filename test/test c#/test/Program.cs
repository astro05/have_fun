﻿using System;

namespace test
{
    class program
    {
        public static ulong fibonacci_lastdigit(ulong n, ulong m)
        {


            if (n <= 1)
                return (ulong)n;

            ulong previous = 0;
            ulong current = 1;
            ulong temp_current = 0;

            for (ulong i = 0; i < n - 1; ++i)
            {
                ulong tmp_previous = previous % m;
                previous = current % m;
                current = tmp_previous + current;
                temp_current = current % m;
            }

            return (ulong)(temp_current);
        }

        static void Main(string[] args)
        {
            ulong n,m,temp;

            string[] tokens = Console.ReadLine().Split(' ');

            n = (ulong)Convert.ToInt64(tokens[0]);
            m = (ulong)Convert.ToInt64(tokens[1]);

            temp = n % (m * m - 1);
            Console.WriteLine(temp + " " + m);
            System.Console.WriteLine(fibonacci_lastdigit(temp,m));
            

        }
    }
}