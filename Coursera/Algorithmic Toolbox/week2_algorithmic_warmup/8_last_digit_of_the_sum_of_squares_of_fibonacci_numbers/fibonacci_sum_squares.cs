using System;
using System.Diagnostics;

namespace test
{
    class program
    {
       static int Fibonacci(long num)
        {
            int pre = 0, cur = 1;
            num = num % 60;
            if (num == 0)
            {
                return 0;
            }
            else if (num == 1)
            {
                return 1;
            }
            else
            {
                for (int i = 2; i <= num; i++)
                {
                    int temp = (pre + cur) % 60;
                    pre = cur;
                    cur = temp;
                   
                }
            }

            return (cur);
        }
        
        static void Main(string[] args)
        {
            long num = Convert.ToInt64( Console.ReadLine());
            
            int a = Fibonacci(num);
            int b = Fibonacci(num+1);

            Console.WriteLine((a * b) % 10);

        }
    }
}

//the sum of squares of up to any Fibonacci numbers can be calculated without explicitly adding up the squares.

//As you can see

//F1^2+..Fn^2 = Fn*Fn+1

//Now to calculate the last digit of Fn and Fn+1, we can apply the Pisano period method

//the last digit can be calculated by %10 and the Pisano period for mod 10 is 60. so, % 60 is used in the code directly

