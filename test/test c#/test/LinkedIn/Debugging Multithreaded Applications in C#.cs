using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.LinkedIn
{
    public class Program
    {
        static int count = 0;
        public static void CountMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                int data = count++;
                Thread.Sleep(2000);
            }
        }

        //public static void Main()
        //{
        //    Thread thread1 = new Thread(CountMethod)
        //    {
        //        Name = "Thread 1"
        //    };

        //    Thread thread2 = new Thread(CountMethod)
        //    {
        //        Name = "Thread 2"
        //    };

        //    thread1.Start();
        //    thread2.Start();

        //    Console.ReadKey();
        //}

    }
}
