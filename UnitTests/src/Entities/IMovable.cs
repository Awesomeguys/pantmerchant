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
    class IMovableTests
    {
        [Test]
        public void Move()
        {
            StateController.StartGame();
            TestEntity test;

            GridCell.Origin.Entity = null;
            test = new TestEntity("UnitTestEntity", Point2D.Origin);
            
            // Moving sets the grid to the correct neighbour
            test.Move(Direction.Up);
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin.NeighbourTop, "Entity does not move to the correct grid");
            Assert.IsTrue(GridCell.Origin.NeighbourTop.Entity == test, "Grid does not contain correct entity after move");

            GridCell.Origin.Entity = null;
            test = new TestEntity("UnitTestEntity", Point2D.Origin);

            // Moving sets the grid to the correct neighbour
            test.Move(Direction.Right);
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin.NeighbourRight, "Entity does not move to the correct grid");
            Assert.IsTrue(GridCell.Origin.NeighbourRight.Entity == test, "Grid does not contain correct entity after move");

            GridCell.Origin.Entity = null;
            test = new TestEntity("UnitTestEntity", Point2D.Origin);

            // Moving sets the grid to the correct neighbour
            test.Move(Direction.Down);
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin.NeighbourBottom, "Entity does not move to the correct grid");
            Assert.IsTrue(GridCell.Origin.NeighbourBottom.Entity == test, "Grid does not contain correct entity after move");

            GridCell.Origin.Entity = null;
            test = new TestEntity("UnitTestEntity", Point2D.Origin);

            // Moving sets the grid to the correct neighbour
            test.Move(Direction.Left);
            Assert.IsTrue(GridCell.GetGrid(test.Position) == GridCell.Origin.NeighbourLeft, "Entity does not move to the correct grid");
            Assert.IsTrue(GridCell.Origin.NeighbourLeft.Entity == test, "Grid does not contain correct entity after move");
        }
    }
}
