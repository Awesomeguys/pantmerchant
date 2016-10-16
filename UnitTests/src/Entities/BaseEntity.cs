using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Pantmerchant namespace
using PantMerchant;

// Unit tests
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class BaseEntityTests
    {
        [Test]
        public void GridStart()
        {
            StateController.StartGame();
            TestEntity test = new TestEntity("UnitTestEntity", Point2D.Origin);

            // Entity starts on the correct grid
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin, "Entity does not start on the correct grid");
            Assert.IsTrue(GridCell.GetGrid(test.Position).Entity == test, "Grid does not contain correct entity upon initialisation");
        }
    }
}
