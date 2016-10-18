namespace PantMerchant
{
    /// <summary>
    /// Static class for stock management.
    /// </summary>
    public static class Stock
    {
        /// <summary>
        /// The amount of stock available.
        /// </summary>
        private static int _Amount;

        /// <summary>
        /// The amount of stock available. Read-only.
        /// </summary>
        public static int Amount { get { return _Amount; } }

        /// <summary>
        /// The amount of stock to automatically purchase each day.
        /// </summary>
        private static int _AmountPerDay;

        /// <summary>
        /// The amount of stock to automatically purchase each day.
        /// get: Returns AmountPerDay.
        /// set: Sets AmountPerDay to value. Updates the stock finance stream.
        /// </summary>
        public static int AmountPerDay
        {
            get
            {
                return _AmountPerDay;
            }
            set
            {
                _AmountPerDay = value;
                _FinanceStream.Amount = -(AmountPerDay * Market.StockPrice);
            }
        }
        
        /// <summary>
        /// Finance stream for managing stock amount per day.
        /// </summary>
        private static FinanceStream _FinanceStream;

        /// <summary>
        /// Initialises the stock management system.
        /// Adds stock finance stream.
        /// </summary>
        static Stock()
        {
            _Amount = 0;
            _FinanceStream = new FinanceStream("Stock", 0);
            _AmountPerDay = 0;
            Finance.Streams.Add(_FinanceStream);
        }

        /// <summary>
        /// Adds the amount of stock.
        /// </summary>
        /// <param name="amount">The number of stock items to be added.</param>
        /// <returns>True is successful.</returns>
        public static bool Add(int amount)
        {
            if (amount > 0)
            {
                _Amount += amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reduces the amount of stock.
        /// </summary>
        /// <param name="amount">The number of stock items to be reduced.</param>
        /// <returns>True is successful.</returns>
        public static bool Reduce(int amount)
        {
            if (amount > 0 && _Amount - amount >= 0)
            {
                _Amount -= amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the amount of stock.
        /// </summary>
        /// <param name="amount">The number of stock items to set.</param>
        /// <returns>True is successful.</returns>
        public static bool Set(int amount)
        {
            if (amount >= 0)
            {
                _Amount = amount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes all stock.
        /// </summary>
        public static void Clear()
        {
            _Amount = 0;
        }

        /// <summary>
        /// Adds the amount per day to the stockpile.
        /// </summary>
        public static void Update()
        {
            Add(AmountPerDay);
        }
    }
}
