using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// Static class that handles the market system.
    /// </summary>
    public static class Market
    {
        public static int RegularRetailPrice { get; private set; }
        public static int StockPrice { get; private set; }
        public static int StorePrice { get; set; }
        public static int CustomerFrequency { get; private set; }

        static Market()
        {
            RegularRetailPrice = 50;
            StockPrice = 20;
            StorePrice = RegularRetailPrice;
            CustomerFrequency = 1000;
        }
    }
}
