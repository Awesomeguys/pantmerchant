using NUnit.Framework;
using PantMerchant;

namespace NUnit.Tests
{
    [TestFixture]
    public class FinanceTests
    {
        [Test]
        public void CalculateNetAmountTest()
        {
            // Arrange
            Finance.Money = 0;
            Finance.Streams.Clear();
            Finance.Streams.Add(new FinanceStream("Bears", 900));
            Finance.Streams.Add(new FinanceStream("Horses", -800));
            int expected = 100;

            // Act
            int actual = Finance.CalculateNetAmount();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateMoneyFromNetTest()
        {
            // Arrange
            Finance.Money = 0;
            Finance.Streams.Clear();
            Finance.Streams.Add(new FinanceStream("Bears", 900));
            Finance.Streams.Add(new FinanceStream("Horses", -800));
            int expected = 100;

            // Act
            Finance.UpdateMoneyFromNet();
            int actual = Finance.Money;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}