using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Basic in-game positional unit. Manages the entity 
    /// which in contains, as well as references to it's
    /// neighbours.
    /// </summary>
    public class GridCell : IDrawable
    {
        /// <summary>
        /// The entity which occupies this GridCell
        /// </summary>
        public BaseEntity Entity { get; private set; }

        /// <summary>
        /// Position of the GridCell
        /// </summary>
        public Point2D Coordinate { get; }

        /// <summary>
        /// The GridCell to the top (top-right) of this one.
        /// </summary>
        public GridCell NeighbourTop {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X, this.Coordinate.Y + 1));
            }
        }

        /// <summary>
        /// The GridCell to the right (bottom-right) of this one.
        /// </summary>
        public GridCell NeighbourRight
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X + 1, this.Coordinate.Y));
            }
        }

        /// <summary>
        /// The GridCell to the bottom (bottom-left) of this one.
        /// </summary>
        public GridCell NeighbourBottom
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X, this.Coordinate.Y - 1));
            }
        }

        /// <summary>
        /// The GridCell to the left (top-left) of this one.
        /// </summary>
        public GridCell NeighbourLeft
        {
            get
            {
                return GameController.Instance.GetGrid(new Point2D(this.Coordinate.X - 1, this.Coordinate.Y));
            }
        }

        /// <summary>
        /// Initialises a new GridCell instance 
        /// with the position set to the origin.
        /// </summary>
        internal GridCell() : this(Point2D.Origin) { }

        /// <summary>
        /// Initialises a new GridCell instance
        /// with the position set to p
        /// </summary>
        /// <param name="p">The position of the Gridcell</param>
        internal GridCell(Point2D p)
        {
            this.Coordinate = p;
        }
        //private class GridPositionTakenExcepion : Exception
        //{
        //    public GridPositionTakenExcepion() : base("There is already a grid with this position.") { }
        //}

        /// <summary>
        /// Highlights the GridCell by drawing a black line around the edges.
        /// </summary>
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
