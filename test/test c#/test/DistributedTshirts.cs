namespace test
{
    public class DistributedTshirts
    {
        public static List<int> DistributeTShirts(int numTshirts, int numBags)
        {
            if (numBags == 0) return new List<int> { 0 };

            // Calculate ideal number of shirts per bag
            int idealTshirtsPerBag = numBags == 0 ? 0 : numTshirts / numBags;

            // Calculate deviation allowance based on expected error margin
            int deviationAllowance = (int)Math.Max(1, numTshirts * 0.01); // Adjust deviationAllowance as needed

            // Initialize result list with ideal distribution
            List<int> tShirtsPerBag = Enumerable.Repeat(idealTshirtsPerBag, numBags).ToList();

            // Handle situations where perfect distribution is impossible
            int remainingTshirts = numBags == 0 ? 0 : numTshirts % numBags;
            int bagsWithExtraTshirt = 0;

            // Distribute remaining shirts evenly among some bags
            while (remainingTshirts > 0)
            {
                // Find a bag that can accommodate an extra shirt without exceeding deviation allowance
                for (int i = 0; i < numBags; i++)
                {
                    if (tShirtsPerBag[i] < idealTshirtsPerBag + deviationAllowance)
                    {
                        tShirtsPerBag[i]++;
                        remainingTshirts--;
                        bagsWithExtraTshirt++;
                        break;
                    }
                }

                // If no bag can accommodate extra without exceeding allowance, stop
                if (remainingTshirts > 0 && bagsWithExtraTshirt == numBags)
                {
                    break;
                }
            }

            // Adjust remaining shirts among bags with extra to minimize deviation
            if (remainingTshirts > 0)
            {
                for (int i = 0; i < numBags && remainingTshirts > 0; i++)
                {
                    if (tShirtsPerBag[i] > idealTshirtsPerBag)
                    {
                        tShirtsPerBag[i]--;
                        remainingTshirts--;
                    }
                }
            }
            return tShirtsPerBag;
        }
    }
}
