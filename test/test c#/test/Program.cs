﻿using System;
using System.Diagnostics;

namespace test
{
    class program
    {
        public static int EuclidGcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            a = a % b;
            return EuclidGcd(b, a);

        }

        public static int ArrMax(int[] arr)
        {
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        public static int ArrMin(int[] arr)
        {
            int min = arr[0];
            foreach (int num in arr)
            {
                if (num < min)
                    min = num;
            }
            return min;
        }

        static void Main(string[] args)
        {
            int max, min;
            int[] nums = { 3};

           // max = nums.Max();
           // min = nums.Min();

            max = ArrMax(nums);
            min = ArrMin(nums);

            Console.WriteLine(EuclidGcd(max, min));

        }
    }
}