namespace PantMerchant
{
    /// <summary>
    /// Class that models an income or outgoing finance stream.
    /// </summary>
    public class FinanceStream
    {
        /// <summary>
        /// The name of the stream.
        /// </summary>
        public string Name;

        /// <summary>
        /// The monetary amount of the stream.
        /// Positive number for income.
        /// Negative number for outgoings.
        /// </summary>
        public int Amount;

        /// <summary>
        /// Initialises a FinanceStream with the provided values.
        /// </summary>
        /// <param name="name">The name of the stream.</param>
        /// <param name="amount">
        /// The monetary amount of the stream.
        /// Positive number for income.
        /// Negative number for outgoings.
        /// </param>
        public FinanceStream(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
