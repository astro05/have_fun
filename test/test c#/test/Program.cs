using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsWPF;
using System;
using test.DesignPattern;

namespace Preprocessor
{

    class Program
    {

        static  void Main(string[] args)
        {
            Parallel.Invoke(
                () =>
                {
                    EagerLoadingSingleton s1 = EagerLoadingSingleton.GetInstance();
                    s1.print("first");
                },
                () =>
                {
                    EagerLoadingSingleton s2 = EagerLoadingSingleton.GetInstance();
                    s2.print("second");
                }
                );

            Console.ReadKey();
        }

    }

}
