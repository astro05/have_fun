using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Delegate del = new Delegate();
            del.LongRunning(Callback);
        }

        static void Callback( int i )
        {
            Console.WriteLine(i);
        }

   
       
    }
}

