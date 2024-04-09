namespace test
{
    public class Fibonacci
    {
        public static int FibonacciRecursiveMemoized(int n, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n <= 1)
            {
                memo[n] = n;
                return n;
            }

            int fib = FibonacciRecursiveMemoized(n - 1, memo) + FibonacciRecursiveMemoized(n - 2, memo);
            memo[n] = fib;
            return fib;
        }

    }
}
