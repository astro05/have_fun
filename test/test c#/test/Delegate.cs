using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Delegate
    {
        public delegate void CallBack(int i);
        public void LongRunning(CallBack obj)
        {
            for (int i = 0; i < 2; i++)
            {
                obj(i);

            }
        }
    }
}



//class Program
//{

//    static void Main(string[] args)
//    {
//        Delegate del = new Delegate();
//        del.LongRunning(Callback);
//    }

//    static void Callback(int i)
//    {
//        Console.WriteLine(i);
//    }



//}
