using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace test
{
    class program
    {
        
        static void Main(string[] args)
        {
            int[] denominations = { 1, 5, 10 };
            int money = 28;
            Change(money, denominations);

           
        }

        static int Change(int money, int[] denominations)
        {
            int numCoins = 0;
            int maxCoin = 0;
            string changeMoney = "Change money is : ";
            while (money > 0)
            {
                maxCoin = denominations.Max() ;
                if (money >= maxCoin)
                {
                    money = money - maxCoin;
                    numCoins++;
                    
                    changeMoney = changeMoney + maxCoin + " + ";
                }
                else
                {
                    denominations = denominations.Where(val => val != maxCoin).ToArray();
                }
                
                
               
            }
            Console.WriteLine("Number of coins is: " + numCoins);
            Console.WriteLine(changeMoney);

            return 0;
        }

       

       
    }
}

