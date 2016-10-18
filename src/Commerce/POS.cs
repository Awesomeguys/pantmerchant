namespace PantMerchant
{
    /// <summary>
    /// Static class for Point Of Sale system.
    /// </summary>
    public static class POS
    {
        /// <summary>
        /// Sells a single item. Calculates the cost 
        /// of the item then completes the transaction.
        /// </summary>
        /// <returns>Cost of transaction, or -1 if failed.</returns>
        public static int SellItem()
        {
            return SellItems(1);
        }

        /// <summary>
        /// Sells multiple items. Calculates the cost 
        /// of the items then completes the transaction.
        /// </summary>
        /// <param name="amount">The number of stock items to be sold.</param>
        /// <returns>Cost of transaction, or -1 if failed.</returns>
        public static int SellItems(int amount)
        {
            if (amount <= 0) return -1;

            int cost = amount * Market.StorePrice;
            if (Stock.Reduce(amount))
            {
                Finance.Money += cost;
                return cost;
            }

            return -1;
        }
    }
}
