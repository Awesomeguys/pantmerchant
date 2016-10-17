using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Unit tests
using NUnit.Framework;

namespace PantMerchant
{
    [TestFixture]
    class BaseEntityTests
    {
        [Test]
        public void GridStart()
        {
            StateController.StartGame();
            Person test = new Person("UnitTestEntity", Point2D.Origin);

            // Entity starts on the correct grid
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin, "Entity does not start on the correct grid");
            Assert.IsTrue(GridCell.GetGrid(test.Position).Entity == test, "Grid does not contain correct entity upon initialisation");
        }
    }
}
