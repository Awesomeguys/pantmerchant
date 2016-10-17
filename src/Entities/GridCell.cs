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

        /// <summary>
        /// On-screen position of the GridCell.
        /// </summary>
        public Point2D ScreenPos
        {
            get
            {
                // We gotta do some funky shit to work out the location on the isometric grid
                if (this.Pos == Point2D.Origin)
                {
                    return Point2D.ScreenMiddle;
                }
                else
                {
                    return GridCell.Origin.ScreenPos + ((GridCell.GridSize / 2) * this.Pos.X) + ((new Point2D(GridCell.GridSize.X, -GridCell.GridSize.Y) / 2) * this.Pos.Y);
                }
            }
        }

        /// <summary>
        /// Position of the GridCell
        /// </summary>
        public Point2D Pos { get; }

        /// <summary>
        /// Size of the grids on the screen (in pixels)
        /// </summary>
        public static Point2D GridSize
        {
            get
            {
                return new Point2D(50, 25);
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
        /// <summary>
        /// Grid cell at the position (0, 0)
        /// </summary>
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

    /// <summary>
    /// Thrown when an entity tries to occupy a GridCell which already contains another entity.
    /// </summary>
    public class GridOccupiedExcepion : Exception
    {
        /// <summary>
        /// Initialises a new instance of GridOccupiedException.
        /// </summary>
        public GridOccupiedExcepion() : this("There is already an entity occuping this grid.") { }
        /// <summary>
        /// Initialises a new instance of GridOccupiedException with the given message.
        /// </summary>
        /// <param name="message">Message explaining the exception.</param>
        public GridOccupiedExcepion(String message) : base(message) { }
    }
}
