using BenchmarkDotNet.Running;
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
            BenchmarkRunner.Run<BenchmarkExecutor>();

        }

        public static void TwoSum(char[] s)
        {
            for (int i = 1; i <= s.Length/2; i++)
            {
                (s[i-1], s[^i]) = (s[^i], s[i-1]);
            }
        }

        public  void te()
        {

        }
    }
}

