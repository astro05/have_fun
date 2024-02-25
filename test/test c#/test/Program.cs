using System;
namespace OCPDemo
{
    //Create an interface for the discount strategy
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double price);
    }

    //Implement this interface for each discount type
    public class RegularDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.1;
        }
    }

    public class PremiumDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.3;
        }
    }

    public class NewbieDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.05;
        }
    }

    //Modify the DiscountCalculator class to accept an IDiscountStrategy
    public class DiscountCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;

        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public double CalculateDiscount(double price)
        {
            return _discountStrategy.CalculateDiscount(price);
        }
    }

    //Testing the Open-Closed Principle
    public class Program
    {
        public static void Main()
        {
            var regularDiscount = new RegularDiscount();
            var calculator = new DiscountCalculator(regularDiscount);
            double discountedPrice = calculator.CalculateDiscount(100); // 10% discount applied

            var premiumDiscount = new PremiumDiscount();
            calculator = new DiscountCalculator(premiumDiscount);
            discountedPrice = calculator.CalculateDiscount(100); // 30% discount applied

            Console.ReadKey();
        }
    }
}