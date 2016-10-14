using NUnit.Framework;
using PantMerchant;

namespace NUnit.Tests
{
    [TestFixture]
    public class StockTests
    {
        [Test]
        public void AddTest()
        {
            // Arrange
            Stock.Set(0);
            int expected = 100;

            // Act
            Stock.Add(100);
            int actual = Stock.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReduceTest()
        {
            // Arrange
            Stock.Set(100);
            int expected = 0;

            // Act
            Stock.Reduce(100);
            int actual = Stock.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetTest()
        {
            // Arrange
            Stock.Set(0);
            int expected = 100;

            // Act
            Stock.Set(100);
            int actual = Stock.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ClearTest()
        {
            // Arrange
            Stock.Set(100);
            int expected = 0;

            // Act
            Stock.Clear();
            int actual = Stock.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateTest()
        {
            // Arrange
            Stock.Set(0);
            Stock.AmountPerDay = 100;
            int expected = 100;

            // Act
            Stock.Update();
            int actual = Stock.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}