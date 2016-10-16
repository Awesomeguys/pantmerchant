using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    public class GridCell : IDrawable
    {
        public BaseEntity Entity { get; private set; }

        public Point2D Coordinate { get; }
        public GridCell NeighbourTop {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X, this.Coordinate.Y + 1));
            }
        }
        public GridCell NeighbourRight
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X + 1, this.Coordinate.Y));
            }
        }
        public GridCell NeighbourBottom
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X, this.Coordinate.Y - 1));
            }
        }
        public GridCell NeighbourLeft
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X - 1, this.Coordinate.Y));
            }
        }

        internal GridCell() : this(Point2D.Origin) { }
        internal GridCell(Point2D p)
        {
            this.Coordinate = p;
        }
        //private class GridPositionTakenExcepion : Exception
        //{
        //    public GridPositionTakenExcepion() : base("There is already a grid with this position.") { }
        //}

        public void Draw()
        {
            Point2D screenMiddle = new Point2D(ScreenWidth()/2, ScreenHeight()/2);
            // TODO Remove Hardcode
            Point2D topCoord = new Point2D(screenMiddle.X + this.Coordinate.X, screenMiddle.Y + this.Coordinate.Y-5);
            Point2D rightCoord = new Point2D(screenMiddle.X + this.Coordinate.X+10, screenMiddle.Y + this.Coordinate.Y);
            Point2D bottomCoord = new Point2D(screenMiddle.X + this.Coordinate.X, screenMiddle.Y + this.Coordinate.Y+5);
            Point2D leftCoord = new Point2D(screenMiddle.X + this.Coordinate.X-10, screenMiddle.Y + this.Coordinate.Y);
            SwinGame.DrawLine(Color.Black, topCoord, rightCoord);
            SwinGame.DrawLine(Color.Black, rightCoord, bottomCoord);
            SwinGame.DrawLine(Color.Black, bottomCoord, leftCoord);
            SwinGame.DrawLine(Color.Black, leftCoord, topCoord);
        }
    }
}
