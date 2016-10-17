using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

// Pantmerchant namespace
using PantMerchant;

// Unit tests
using NUnit.Framework;

namespace PantMerchant
{
    [TestFixture]
    class GridCellTests
    {
        string PositionIncorrectMessage { get { return "The position is incorrect";  } }
        string ReferenceIncorrectMessage { get { return "The grid reference is incorrect"; } }
        [Test]
        public void GetOriginCell()
        {
            // Position is correct
            Assert.IsTrue(GridCell.Origin.Pos == PantMerchant.Point2D.Origin, PositionIncorrectMessage);
            // Grid reference is correct
            Assert.IsTrue(GridCell.Origin == GridCell.GetGrid(PantMerchant.Point2D.Origin), ReferenceIncorrectMessage);
        }
        [Test]
        public void NeighbourTop() {
            // Position is correct
            Assert.IsTrue(GridCell.Origin.NeighbourTop.Pos == GridCell.Origin.Pos + new PantMerchant.Point2D(0, 1), PositionIncorrectMessage);

            // Grid reference is correct
            Assert.IsTrue(GridCell.Origin.NeighbourTop == GridCell.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, 1)), ReferenceIncorrectMessage);
        }

        [Test]
        public void NeighbourRight()
        {
            // Position is correct
            Assert.IsTrue(GridCell.Origin.NeighbourRight.Pos == GridCell.Origin.Pos + new PantMerchant.Point2D(1, 0), PositionIncorrectMessage);

            // Grid reference is correct
            Assert.IsTrue(GridCell.Origin.NeighbourRight == GridCell.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(1, 0)), ReferenceIncorrectMessage);
        }

        [Test]
        public void NeighbourBottom()
        {
            // Position is correct
            Assert.IsTrue(GridCell.Origin.NeighbourBottom.Pos == GridCell.Origin.Pos + new PantMerchant.Point2D(0, -1), PositionIncorrectMessage);

            // Grid reference is correct
            Assert.IsTrue(GridCell.Origin.NeighbourBottom == GridCell.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, -1)), ReferenceIncorrectMessage);
        }

        [Test]
        public void NeighbourLeft()
        {
            // Position is correct
            Assert.IsTrue(GridCell.Origin.NeighbourLeft.Pos == GridCell.Origin.Pos + new PantMerchant.Point2D(-1, 0), PositionIncorrectMessage);

            // Grid reference is correct
            Assert.IsTrue(GridCell.Origin.NeighbourLeft == GridCell.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(-1, 0)), ReferenceIncorrectMessage);
        }

        [Test]
        public void ScreenPos()
        {
            // Test Origin
            Assert.IsTrue(
                GridCell.Origin.ScreenPos == Point2D.ScreenMiddle,
                "On-screen location of the origin GridCell is not correct. Expected position was (400, 300), but actual position was ({0}, {1})",
                GridCell.Origin.ScreenPos.X,
                GridCell.Origin.ScreenPos.Y
            );

            Assert.IsTrue(
                GridCell.Origin.NeighbourRight.ScreenPos == Point2D.ScreenMiddle + (GridCell.GridSize/2),
                "On-screen location of the top neighbour is not correct. Expected position was ({0}, {1}), but actual position was ({2}, {3})",
                (Point2D.ScreenMiddle + (GridCell.GridSize / 2)).X,
                (Point2D.ScreenMiddle + (GridCell.GridSize / 2)).Y,
                GridCell.Origin.NeighbourRight.ScreenPos.X,
                GridCell.Origin.NeighbourRight.ScreenPos.Y
            );

            Assert.IsTrue(
                GridCell.Origin.NeighbourRight.NeighbourBottom.ScreenPos == Point2D.ScreenMiddle + new Point2D(0, GridCell.GridSize.Y),
                "On-screen location of the top neighbour is not correct. Expected position was ({0}, {1}), but actual position was ({2}, {3})",
                (Point2D.ScreenMiddle + new Point2D(0, GridCell.GridSize.Y)).X,
                (Point2D.ScreenMiddle + new Point2D(0, GridCell.GridSize.Y)).Y,
                GridCell.Origin.NeighbourRight.NeighbourBottom.ScreenPos.X,
                GridCell.Origin.NeighbourRight.NeighbourBottom.ScreenPos.Y
            );

            Assert.IsTrue(
                GridCell.Origin.NeighbourLeft.NeighbourBottom.ScreenPos == Point2D.ScreenMiddle + new Point2D(-GridCell.GridSize.X, 0),
                "On-screen location of the top neighbour is not correct. Expected position was ({0}, {1}), but actual position was ({2}, {3})",
                (Point2D.ScreenMiddle + new Point2D(GridCell.GridSize.X, 0)).X,
                (Point2D.ScreenMiddle + new Point2D(GridCell.GridSize.X, 0)).Y,
                GridCell.Origin.NeighbourLeft.NeighbourBottom.ScreenPos.X,
                GridCell.Origin.NeighbourLeft.NeighbourBottom.ScreenPos.Y
            );
        }
    }
}
