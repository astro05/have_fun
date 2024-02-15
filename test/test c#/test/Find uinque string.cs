using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Find_uinque_string
    {
        public static void FindUniqueString()
        {
            string[] a = { "joy", "joy", "toy" };
            StringBuilder sb = new StringBuilder();

            for (int c = 0; c < a[0].Length; c++)
            {
                var temp = 0;
                for (int r = 0; r < a.Length; r++)
                {
                    temp ^= a[r][c];
                }
                sb.Append(Convert.ToChar(temp));
            }
        }
    }
}
