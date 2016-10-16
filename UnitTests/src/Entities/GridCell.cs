using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

// Pantmerchant namespace
using PantMerchant;

// Unit tests
using NUnit.Framework;

namespace PantMerchantTests
{
    [TestFixture]
    class GridCellTests
    {
        [Test]
        public void GetOriginCell()
        {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.Coordinate == PantMerchant.Point2D.Origin);
            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin));
        }
        [Test]
        public void NeighbourTop() {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourTop.Coordinate == GameController.Instance.OriginGridCell.Coordinate + new PantMerchant.Point2D(0, 1));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourTop == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, 1)));
        }

        [Test]
        public void NeighbourRight()
        {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourRight.Coordinate == GameController.Instance.OriginGridCell.Coordinate + new PantMerchant.Point2D(1, 0));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourRight == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(1, 0)));
        }

        [Test]
        public void NeighbourBottom()
        {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourBottom.Coordinate == GameController.Instance.OriginGridCell.Coordinate + new PantMerchant.Point2D(0, -1));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourBottom == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, -1)));
        }

        [Test]
        public void NeighbourLeft()
        {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourLeft.Coordinate == GameController.Instance.OriginGridCell.Coordinate + new PantMerchant.Point2D(-1, 0));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourLeft == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(-1, 0)));
        }
    }
}
