using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    public class GridCell
    {
        public BaseEntity Entity { get; private set; }

        public Point2D Pos { get; }
        public GridCell NeighbourTop {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Pos.X, this.Pos.Y + 1));
            }
        }
        public GridCell NeighbourRight
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Pos.X + 1, this.Pos.Y));
            }
        }
        public GridCell NeighbourBottom
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Pos.X, this.Pos.Y - 1));
            }
        }
        public GridCell NeighbourLeft
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Pos.X - 1, this.Pos.Y));
            }
        }

        internal GridCell() : this(Point2D.Origin) { }
        internal GridCell(Point2D p)
        {
            this.Pos = p;
        }
        //private class GridPositionTakenExcepion : Exception
        //{
        //    public GridPositionTakenExcepion() : base("There is already a grid with this position.") { }
        //}
    }
}
