using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.IIS_Trace;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

namespace test
{
    class program
    {
        static void Main(string[] args)
        {
            //var add = Memorizer.Memoize<int, int>(Factorial);
            //var add = Memorizer.Memoize_concise<int, int>(Factorial);
            var add = Memorizer.ThreadSafeMomoize<int, int>(Factorial);
            Console.WriteLine(add(10));
            Console.WriteLine("---------");
            Console.WriteLine(add(25));
            Console.WriteLine("---------");
            Console.WriteLine(add(25));
            Console.WriteLine("---------");
            Console.Read();

        }

        static int Factorial(int i)
        {
            Console.WriteLine("Factorial {0}", i);
            if (i == 0)
                return 1;
            return Factorial(i - 1) * i;
        }

    }

    public static class Memorizer
    {
        public static Func<TInput, TResult> Memoize<TInput, TResult>(Func<TInput, TResult> func)
        where TInput : IComparable
        {
            Dictionary<TInput, TResult> cache = new Dictionary<TInput, TResult>();

            Func<TInput, TResult> retval = delegate (TInput arg)
            {
                TResult retval;

                if (cache.ContainsKey(arg))
                {
                    retval = cache[arg];
                }
                else
                {
                    retval = cache[arg] = func(arg);
                }
                return retval;
            };
            return retval;
        }

        public static Func<TInput, TResult> Memoize_concise<TInput, TResult>(Func<TInput, TResult> func)
        where TInput : IComparable
        {
            Dictionary<TInput, TResult> cache = new Dictionary<TInput, TResult>();
            return (arg) =>
            {
                if (cache.ContainsKey(arg))
                    return cache[arg];
                return cache[arg] = func(arg);
            };
        }

        public static Func<TInput, TResult> ThreadSafeMomoize<TInput, TResult>(Func<TInput, TResult> func)
        where TInput : IComparable
        {
            ConcurrentDictionary<TInput, TResult> cache = new ConcurrentDictionary<TInput, TResult>();
            return (arg) =>
            {
                return cache.GetOrAdd(arg, func);
            };
        }


    }
}


