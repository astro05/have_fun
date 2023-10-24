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
            uint n = 5;
            reverseBits(n);
         }



        public static uint reverseBits(uint n)
        {
            uint reverse = 0; 
            for (int i=0; i< 32; i++)
            {
                uint r = n & 1;
                reverse = reverse << 1;
                reverse = reverse | r;
                n = n >> 1;
            }

            return reverse;
        }

    }
}

