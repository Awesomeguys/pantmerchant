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
        private BaseEntity _entity;
        /// <summary>
        /// The entity which occupies this GridCell
        /// </summary>
        public BaseEntity Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                if (_entity != null && value != null)
                {
                    throw new GridOccupiedExcepion();
                }

                _entity = value;

                if (value != null)
                {
                    _entity.Position = this.Pos;
                }
                
            }
        }

        public Point2D ScreenPos
        {
            get
            {
                return new Point2D(this.Pos.X * GridCell.GridSize.X, this.Pos.Y * GridCell.GridSize.Y) + Point2D.ScreenMiddle;
            }
        }

        /// <summary>
        /// Position of the GridCell
        /// </summary>
        public Point2D Pos { get; }

        public static Point2D GridSize
        {
            get
            {
                return new Point2D(20, 10);
            }
        }

        /// <summary>
        /// The GridCell to the top (top-right) of this one.
        /// </summary>
        public GridCell NeighbourTop {
            get
            {
                return GridCell.GetGrid(new Point2D(this.Pos.X, this.Pos.Y + 1));
            }
        }

        /// <summary>
        /// The GridCell to the right (bottom-right) of this one.
        /// </summary>
        public GridCell NeighbourRight
        {
            get
            {
                return GridCell.GetGrid(new Point2D(this.Pos.X + 1, this.Pos.Y));
            }
        }

        /// <summary>
        /// The GridCell to the bottom (bottom-left) of this one.
        /// </summary>
        public GridCell NeighbourBottom
        {
            get
            {
                return GridCell.GetGrid(new Point2D(this.Pos.X, this.Pos.Y - 1));
            }
        }

        /// <summary>
        /// The GridCell to the left (top-left) of this one.
        /// </summary>
        public GridCell NeighbourLeft
        {
            get
            {
                return GridCell.GetGrid(new Point2D(this.Pos.X - 1, this.Pos.Y));
            }
        }

        private static GridCell _origin;
        public static GridCell Origin
        {
            get
            {
                if (GridCell._origin == null)
                {
                    _origin = new GridCell(Point2D.Origin);
                }
                return _origin;
            }
        }

        private static GridCell[,] _grid { get; }

        /// <summary>
        /// Initialises a new GridCell instance
        /// with the position set to p
        /// </summary>
        /// <param name="p">The position of the Gridcell</param>
        private GridCell(Point2D p)
        {
            this.Pos = p;
        }

        /// <summary>
        /// Static constructor for GridCell type
        /// </summary>
        static GridCell()
        {
            _grid = new GridCell[100, 100];    // TODO Remove hardcode
            _grid[50, 50] = GridCell.Origin;
        }

        /// <summary>
        /// Retrieves the GridCell with the specified position
        /// </summary>
        /// <param name="p">The position of the GridCell you'd like</param>
        /// <returns>A GridCell with the specified position</returns>
        public static GridCell GetGrid(Point2D p)
        {
            if (p == Point2D.Origin)
            {
                return GridCell.Origin;
            }
            // TODO remove hard code
            if (_grid[50 + p.X, 50 + p.Y] == null)
            {
                _grid[50 + p.X, 50 + p.Y] = new GridCell(p);
            }

            return _grid[50 + p.X, 50 + p.Y];
        }

        /// <summary>
        /// Highlights the GridCell by drawing a black line around the edges.
        /// </summary>
        public void Draw()
        {
            // TODO Remove Hardcode
            Point2D topCoord = new Point2D(this.ScreenPos.X, this.ScreenPos.Y-(GridCell.GridSize.Y/2));
            Point2D rightCoord = new Point2D(this.ScreenPos.X+(GridCell.GridSize.X/2), this.ScreenPos.Y);
            Point2D bottomCoord = new Point2D(this.ScreenPos.X, this.ScreenPos.Y+(GridCell.GridSize.Y/2));
            Point2D leftCoord = new Point2D(this.ScreenPos.X-(GridCell.GridSize.X/2), this.ScreenPos.Y);
            SwinGame.DrawLine(Color.Black, topCoord, rightCoord);
            SwinGame.DrawLine(Color.Black, rightCoord, bottomCoord);
            SwinGame.DrawLine(Color.Black, bottomCoord, leftCoord);
            SwinGame.DrawLine(Color.Black, leftCoord, topCoord);
        }
    }

    public class GridOccupiedExcepion : Exception
    {
        public GridOccupiedExcepion() : this("There is already an entity occuping this grid.") { }
        public GridOccupiedExcepion(String message) : base(message) { }
    }
}
