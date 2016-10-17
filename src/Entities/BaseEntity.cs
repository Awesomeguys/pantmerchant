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
        private string resourcePath;

        protected string _resourcePath { get; }
        /// <summary>
        /// Returns a reference to the grid containing this entity.
        /// </summary>
        public GridCell Grid
        {
            get
            {
                return GridCell.GetGrid(this.Position);
            }
        }
        /// <summary>
        /// The on-screen coordinates of the entity
        /// </summary>
        public Point2D ScreenPos
        {
            get
            {
                return
                    GridCell.GetGrid(this.Position).ScreenPos;
            }
        }
        /// <summary>
        /// The position on the grid.
        /// </summary>
        public Point2D Position { get; set; }
        /// <summary>
        /// The direction the entity is facing.
        /// </summary>
        public Direction Facing { get; protected set; }
        /// <summary>
        /// A list of grid points relative to the
        /// position that the entity will take up.
        /// </summary>
        public List<Point2D> Footprint { get; set; }
        
        /// <summary>
        /// Initialises a new instance of BaseEntity with the 
        /// given position and footprint.
        /// </summary>
        /// <param name="position">The position of the entity on the grid</param>
        /// <param name="footprint">The footprint of the </param>
        public BaseEntity(Point2D position, List<Point2D> footprint)
            : this(position, footprint, null) { }

        /// <summary>
        /// Initialises a new instance of BaseEntity with the 
        /// given position, footprint, and resource path.
        /// </summary>
        /// <param name="position">The position of the entity on the grid</param>
        /// <param name="footprint">The footprint of the </param>
        /// <param name="resourcePath">The path containing the entity resources</param>
        public BaseEntity(Point2D position, List<Point2D> footprint, string resourcePath)
        {
            Position = position;
            Footprint = footprint;

            this.Grid.Entity = this;

            StateController.CurrentController.IDrawableList.Add(this);
            this._resourcePath = resourcePath;
        }

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public abstract void Draw();
    }
}