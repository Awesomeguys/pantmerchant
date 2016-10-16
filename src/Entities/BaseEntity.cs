using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class to be used by all grid entities.
    /// </summary>
    public abstract class BaseEntity : IDrawable
    {
        /// <summary>
        /// The on-screen coordinates of the entity
        /// </summary>
        public Point2D ScreenPos
        {
            get
            {
                return
                    this.Position + new Point2D(ScreenWidth() / 2, ScreenHeight() / 2);
            }
        }

        /// <summary>
        /// The position on the grid.
        /// </summary>
        public Point2D Position { get; set; }

        /// <summary>
        /// A list of grid points relative to the
        /// position that the entity will take up.
        /// </summary>
        public List<Point2D> Footprint { get; set; }

        public BaseEntity(Point2D position, List<Point2D> footprint)
        {
            Position = position;
            Footprint = footprint;

            GridCell.GetGrid(position).Entity = this;

            StateController.CurrentController.IDrawableList.Add(this);
        }

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public abstract void Draw();
    }
}