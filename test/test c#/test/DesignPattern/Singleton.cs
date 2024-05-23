using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace test.DesignPattern
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class NiveSingleton 
    {
        private static NiveSingleton _instance;
        private NiveSingleton() { }

        public static NiveSingleton GetInstance()
        {
            if( _instance == null)
            {
                _instance = new NiveSingleton();
            }
            return _instance;
        }
    }
    /* NiveSingleton
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        if (s1 == s2)
        {
            Console.WriteLine("Singleton Working");
        }
        else
        {
            Console.WriteLine("Singleton Not Working");
        }
        Console.ReadKey();
    }
    */

    /// <summary>
    /// 
    /// </summary>
    public sealed class NiveSingleton2
    {
        private static int count = 0;
        private static NiveSingleton2 instance = null;
        private NiveSingleton2() 
        {
            count++;
            Console.WriteLine("Instance count: " + count);
        }

        public static NiveSingleton2 GetInstance()
        {
            if( instance == null )
            {
                instance = new NiveSingleton2();
            }
            return instance;
        }

        public void print(string message)
        {
            Console.WriteLine("Instance:" + count + " Message: " + message);
        }
    }
    /*
      static  void Main(string[] args)
        {
           NiveSingleton2 s1 = NiveSingleton2.GetInstance();
           NiveSingleton2 s2 = NiveSingleton2.GetInstance();

            s1.print("first");
            s2.print("second");

            Console.ReadKey();
        }
     */

    /// <summary>
    /// Single Lock
    /// </summary>
    public sealed class SingleLockSingleton 
    {
        private static int count = 0;
        private static readonly object _lock = new object();
        private static SingleLockSingleton instance = null;
        private SingleLockSingleton() 
        { 
            count++;
            Console.WriteLine("Instance count: " + count);
        }

        public static SingleLockSingleton GetInstance()
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new SingleLockSingleton();
                }
            }
            return instance;
        }

        public void print(string message)
        {
            Console.WriteLine("Instance:" + count + " Message: " + message);
        }
    }
    /*
        static  void Main(string[] args)
        {
            Parallel.Invoke(
                () =>
                {
                    SingleLockSingleton s1 = SingleLockSingleton.GetInstance();
                    s1.print("first");
                },
                () =>
                {
                    SingleLockSingleton s2 = SingleLockSingleton.GetInstance();
                    s2.print("second");
                }
                );

            Console.ReadKey();
        }
     */


    /// <summary>
    /// Double lock
    /// </summary>
    public sealed class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance = null;
        private static readonly object _lock = new object();

        public string? Value { get; set; }

        private ThreadSafeSingleton() { }
        public static ThreadSafeSingleton GetInstance(string value)
        {
            if ( _instance == null )
            {
                lock ( _lock )
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
    }
    /* ThreadSafeSingleton
      static  void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                ThreadSafeSingleton s1 = ThreadSafeSingleton.GetInstance("Foo");
                Console.WriteLine(s1.Value);
            });

            Thread t2 = new Thread(() =>
            {
               ThreadSafeSingleton s2 = ThreadSafeSingleton.GetInstance("Bar");
                Console.WriteLine(s2.Value);
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
           

            Console.ReadKey();
        }
     */

    /// <summary>
    /// not quite as lazy, but thread-safe without using locks
    /// </summary>
    public sealed class ThreadSafeSingletonWithoutLock
    {
        // The single instance of the class, created eagerly
        private static readonly ThreadSafeSingletonWithoutLock threadSafeSingletonWithoutLock = new ThreadSafeSingletonWithoutLock();

        // Static constructor
        static ThreadSafeSingletonWithoutLock() { }

        // Private constructor to prevent direct instantiation
        private ThreadSafeSingletonWithoutLock() { }

        // Public static property to access the single instance
        public static ThreadSafeSingletonWithoutLock TSSingletonWithoutLock
        {
            get
            {
                return threadSafeSingletonWithoutLock;
            }
        }
    }
    /*
       static  void Main(string[] args)
        {
            ThreadSafeSingletonWithoutLock s1 = null, s2 = null;

            Thread t1 = new Thread(() =>
            {
                 s1 = ThreadSafeSingletonWithoutLock.TSSingletonWithoutLock;
            });

            Thread t2 = new Thread(() =>
            {
                s2 = ThreadSafeSingletonWithoutLock.TSSingletonWithoutLock;
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
     */


    /// <summary>
    /// fully lazy instantiatio
    /// </summary>
    public sealed class SingletonLazy 
    {
        private SingletonLazy()
        {
            
        }

        public static SingletonLazy Instance
        {
            get
            {
                return Nested.Instance;
            }
        }
        private class Nested
        {
            private Nested() { }
            internal static readonly SingletonLazy Instance = new SingletonLazy();
        }
    }
    /*
      static  void Main(string[] args)
        {
            SingletonLazy s1 = null, s2 = null;

            Thread t1 = new Thread(() =>
            {
                s1 = SingletonLazy.Instance;
            });

            Thread t2 = new Thread(() =>
            {
                s2 = SingletonLazy.Instance;
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
     */

    /// <summary>
    /// using .NET 4's Lazy<T> type
    /// </summary>
    public sealed class SingletonLazy2
    {
        private SingletonLazy2() { }
        private static readonly Lazy<SingletonLazy2> lazy = new Lazy<SingletonLazy2>(() => new SingletonLazy2());
        public static SingletonLazy2 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
    /*
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
     */

    /// <summary>
    /// Non-Lazy or Eager Loading
    /// </summary>
    public sealed class EagerLoadingSingleton 
    {
        private static int count = 0;
        private static readonly EagerLoadingSingleton instance = new EagerLoadingSingleton();
        private EagerLoadingSingleton()
        {
            count++;
            Console.WriteLine("Instance: " + count);
        }

        public static EagerLoadingSingleton GetInstance()
        {
            return instance;
        }

        public void print(string message)
        {
            Console.WriteLine("Instance: "+ count + " message: "+ message);
        }
    }
    /*
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
     */

}
