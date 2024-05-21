using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using System;
using test.DesignPattern;

namespace Preprocessor
{

    class Program
    {

        static  void Main(string[] args)
        {
            SingletonLazy2 s1 = null, s2 = null;

            Thread t1 = new Thread(() =>
            {
                s1 = SingletonLazy2.Instance;
            });

            Thread t2 = new Thread(() =>
            {
                s2 = SingletonLazy2.Instance;
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            if (s1 == s2)
            {
                Console.WriteLine("Thread Safe");
            }
           
            else
            {
                Console.WriteLine("Not thread safe");
                
            }

            Console.ReadKey();
        }

    }

}
