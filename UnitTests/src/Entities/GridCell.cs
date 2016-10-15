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
            Assert.IsTrue(GameController.Instance.OriginGridCell.Pos == PantMerchant.Point2D.Origin);
            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin));
        }
        [Test]
        public void NeighbourTop() {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourTop.Pos == GameController.Instance.OriginGridCell.Pos + new PantMerchant.Point2D(0, 1));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourTop == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, 1)));
        }

        [Test]
        public void NeighbourRight()
        {
            // Position is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourRight.Pos == GameController.Instance.OriginGridCell.Pos + new PantMerchant.Point2D(1, 0));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourRight == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(1, 0)));
        }

        [Test]
        public void NeighbourBottom()
        {
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourBottom.Pos == GameController.Instance.OriginGridCell.Pos + new PantMerchant.Point2D(0, -1));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourBottom == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(0, -1)));
        }

        [Test]
        public void NeighbourLeft()
        {
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourLeft.Pos == GameController.Instance.OriginGridCell.Pos + new PantMerchant.Point2D(-1, 0));

            // Grid reference is correct
            Assert.IsTrue(GameController.Instance.OriginGridCell.NeighbourLeft == GameController.Instance.GetGrid(PantMerchant.Point2D.Origin + new PantMerchant.Point2D(-1, 0)));
        }
    }
}
