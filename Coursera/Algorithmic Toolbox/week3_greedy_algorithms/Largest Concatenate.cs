using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace test
{
    class program
    {

        static void Main(string[] args)
        {
            int[] inputSequence = { 1, 5, 10 };
           
            LargestConcatenate(inputSequence);


        }

        static int LargestConcatenate(int[] inputSequence)
        {
            StringBuilder sb = new StringBuilder();

            while ( (inputSequence?.Length > 0) )
            {
                _ = sb.Append(inputSequence.Max());
                inputSequence = inputSequence.Where(x => x != inputSequence.Max()).ToArray();
            }

            Console.WriteLine(sb.ToString());
            return 0;
        }




    }
}

