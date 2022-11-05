// https://leetcode.com/problems/two-sum/

using System;
using System.Diagnostics;

namespace test
{
    class program
    {
        
        static void Main(string[] args)
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 18;

            // int[] result = twoSum(nums, target);
            //int[] result = twoSum_findIndex(nums, target);
            int[] result = twoSum_dictionary(nums, target);
            foreach (var item in result)
            {
                Console.WriteLine( item);
            }
        }


        static int[] twoSum_dictionary(int[] nums, int target)
        {
            Dictionary<int, int> dict = new();
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dict.ContainsKey(diff))
                {
                    return new int[] { dict[diff], i };

                }
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }

            return new int[2] {0,0};
        }



        static int[] twoSum_findIndex(int[] nums, int target)
        {
            int max = nums.Length;
            int index;

            for (int i = 0; i < max; i++)
            {
                int diff = target - nums[i];
                index = Array.FindIndex(nums, i+1, x => x == diff);

                if (index != -1)
                {
                    return new int[2] { i, index };
                }
            }

            return new int[2] {0, 0};
        }


        static int[] twoSum_array(int[] nums, int target)
        {
            int max = nums.Length;
            for (int i = 0; i < max; i++)
            {
                int diff = target - nums[i];

                for (int j = i+1; j < max ; j++)
                {
                    if (diff == nums[j])
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return new int[2] {0,0};
        }

       
    }
}

