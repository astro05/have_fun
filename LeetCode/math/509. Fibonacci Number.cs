// https://leetcode.com/problems/fibonacci-number/

// solution 1
public class Solution {
    public int Fib(int n) {
       int[] fib = new int[n+1];
            
            if (n <= 1)
                return n;
            else
            {
                fib[0] = 1;
                fib[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    fib[i] = fib[i - 1] + fib[i - 2];
                }

                int v = fib[n-1];
                return v;
            
            }
    }
}

//solution 2

public class Solution {
    public int Fib(int n) {
        if (n <= 1)
                return n;

            int previous = 0;
            int current = 1;
            int temp_current = 0;

            for (int i = 0; i < n - 1; ++i)
            {
                int tmp_previous = previous;
                previous = current;
                current = tmp_previous + current;
            }

            return current;
    }
}