using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace test
{
    class program
    {

        static void Main(string[] args)
        {
            // BenchmarkRunner.Run<BenchmarkExecutor>();
            string s = "abcd";
            int k = 6;
            string r = ReverseStr2(s, k);
         }

        public static string ReverseStr2(string s, int k)
        {
            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i +=2*k )
            {
                int min = Math.Min(chars.Length -i, k);
                Array.Reverse(chars, i, min);
            }

            return new string(chars);
        }


        public static string ReverseStr1(string s, int k)
        {
            char[] chars = s.ToCharArray();
            int j = 0, i =0;

            while (j + k <= chars.Length)
            {
                for (i = j; i < j+(k/2) ; i++)
                {
                    (chars[i], chars[j+k-(i-j)-1]) = (chars[j+k-(i-j)-1], chars[i]);
                }
                j = j + 2*k;
            }
            if (j < chars.Length)
            {
                for (i = j; i < j+ (chars.Length-j)/2; i++)
                {
                    (chars[i], chars[chars.Length - (i-j)-1]) = (chars[chars.Length - (i - j) - 1], chars[i]);
                }
            }
            return new string(chars);
        }

    }
}

