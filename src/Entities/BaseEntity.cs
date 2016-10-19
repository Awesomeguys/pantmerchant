using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;
using System.Runtime.Serialization;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class to be used by all grid entities.
    /// </summary>
    public abstract class BaseEntity : IDrawable
    {
        private string resourcePath;

        /// <summary>
        /// The path containing the entity resources
        /// </summary>
        protected string ResourcePath { get; }

        private Bitmap[] _img = new Bitmap[4];

        /// <summary>
        /// Returns the appropriate image based on the direction the entity is facing.
        /// </summary>
        public Bitmap Image
        {
            get
            {
                switch (this.Facing)
                {
                    case Direction.Up:
                        return _img[0];
                    case Direction.Right:
                        return _img[1];
                    case Direction.Down:
                        return _img[2];
                    case Direction.Left:
                        return _img[3];
                    default:
                        return null;
                }
            }
        }

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
                return GridCell.GetGrid(this.Position).ScreenPos;
            }
        }
        /// <summary>
        /// The position on the grid.
        /// </summary>
        public Point2D Position { get; set; }
        private Direction _facing;
        /// <summary>
        /// The direction the entity is facing.
        /// </summary>
        public Direction Facing
        {
            get
            {
                if (_facing != Direction.None)
                {
                    return _facing;
                }
                else
                {
                    return Direction.Up;
                }
            }
            protected set
            {

                if (value != Direction.None)
                {
                    _facing = value;
                }
                else
                {
                    throw new DirectionNotAllowedException();
                }
            }
        }
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
        /// <param name="footprint">The footprint of the entity</param>
        /// <param name="resourcePath">The path containing the entity resources</param>
        public BaseEntity(Point2D position, List<Point2D> footprint, string resourcePath)
        {
            Position = position;
            Footprint = footprint;

            this.Facing = Direction.Up;

            this.Grid.Entity = this;

            StateController.Instance.CurrentController.IDrawableList.Add(this);
            this.ResourcePath = resourcePath;

            if (this.ResourcePath != null)
            {
                try
                {
                    _img[0] = LoadBitmap(this.ResourcePath + "up.png");
                    _img[1] = LoadBitmap(this.ResourcePath + "right.png");
                    _img[2] = LoadBitmap(this.ResourcePath + "down.png");
                    _img[3] = LoadBitmap(this.ResourcePath + "left.png");
                }
                catch (TypeInitializationException e)
                {
                    for (int i = 0; i < _img.Length; i++)
                    {
                        _img[i] = null;
                    }
                }
            }
        }

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public virtual void Draw()
        {
            // TODO Find a way to scale the image dynamically
            //float scaleFactor = GridCell.GridSize.X / ( (float)2 * ( this.Image.Width ) ) ;

            this.Image.Draw(this.ScreenPos.X - this.Image.Width / 2, this.ScreenPos.Y - this.Image.Height + GridCell.GridSize.Y / 2);
        }
    }

    /// <summary>
    /// Thrown if Facing is set as Direction.None
    /// </summary>
    [Serializable]
    internal class DirectionNotAllowedException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the DirectionNotAllowedException class.
        /// </summary>
        public DirectionNotAllowedException() : this("The specified direction is not allowed for this object")
        {
        }

        /// <summary>
        /// Initialises a new instance of the DirectionNotAllowedException class with the given message.
        /// </summary>
        /// <param name="message">Message describing the exception</param>
        public DirectionNotAllowedException(string message) : base(message)
        {
        }
    }
}