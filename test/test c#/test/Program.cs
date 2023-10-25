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
            List<int> list = new List<int>() { -1, 1, 2, 3, 1 };
            int target = 2;
           int r = CountPairs(list, target);
         }



        public static int CountPairs(IList<int> nums, int target)
        {
          return Enumerable.Range(0, nums.Count).Select(i => nums.Skip(i+1).Count(x => nums[i] + x < target)).Sum();
        }


        public int CountPairs(IList<int> nums, int target)
        {
            return Enumerable.Range(0, nums.Count)  // Step 1: Create a range of indices from 0 to nums.Count.
                .Select(i => nums
                                .Skip(i + 1)          // Step 2: Skip the elements before the current index.
                                .Count(x => nums[i] + x < target))  // Step 3: Count the elements that form pairs where the sum is less than the target.
                .Sum();  // Step 4: Sum the counts to get the total number of pairs.
        }


    }
}

