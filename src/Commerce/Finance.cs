using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// Static class that handles the financial system.
    /// </summary>
    public static class Finance
    {
        /// <summary>
        /// dat cash money.
        /// </summary>
        public static int Money;

        /// <summary>
        /// A list of income/outgoing streams.
        /// </summary>
        public static List<FinanceStream> Streams;

        /// <summary>
        /// Initialises the finance system.
        /// </summary>
        static Finance()
        {
            Money = 0;
            Streams = new List<FinanceStream>();
        }

        /// <summary>
        /// Returns the net amount from all streams.
        /// Adds up all the amount values of each stream 
        /// in the list to obtain the net amount.
        /// </summary>
        /// <returns>Net amount.</returns>
        public static int CalculateNetAmount()
        {
            int netAmount = 0;
            Streams.ForEach(delegate (FinanceStream stream)
            {
                netAmount += stream.Amount;
            });
            return netAmount;
        }

        /// <summary>
        /// Adds the current net amount to the money.
        /// </summary>
        public static void UpdateMoneyFromNet()
        {
            Money += CalculateNetAmount();
        }
    }
}
