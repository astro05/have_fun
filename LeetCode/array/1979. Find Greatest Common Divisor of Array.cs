// https://leetcode.com/problems/find-greatest-common-divisor-of-array/

public class Solution {
    public int FindGCD(int[] nums) {
        
            if (nums.Length == 0 || nums == null)
                return 0;

            int max, min;
            
            // Builin function 
            max = nums.Max();
            min = nums.Min();

            //user define function
              // max = ArrMax(nums);
              // min = ArrMin(nums);
        
        return  EuclidGcd(max, min);
    }
    
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
    
}