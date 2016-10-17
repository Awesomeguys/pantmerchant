using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class used by all human entities
    /// </summary>
    public abstract class Person : BaseEntity, IMovable
    {
        /// <summary>
        /// Name of the person. "John Smith", etc.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initialises a new instance of Person with 
        /// the given name at the given position.
        /// </summary>
        /// <param name="Name">Name of the person. eg "John Smith"</param>
        /// <param name="position">Grid position the person currently occupies</param>
        public Person(string Name, Point2D position) : base(position, new List<Point2D>() { Point2D.Origin })
        {
            this.Name = Name;
        }

        /// <summary>
        /// Used to move the Person one grid in the given direction
        /// </summary>
        /// <param name="d">The direction to move the Person</param>
        public void Move(Direction d)
        {
            switch (d)
            {
                case Direction.Up:
                    GridCell.GetGrid(this.Position).Entity = null;
                    GridCell.GetGrid(this.Position).NeighbourTop.Entity = this;
                    break;
                case Direction.Right:
                    GridCell.GetGrid(this.Position).Entity = null;
                    GridCell.GetGrid(this.Position).NeighbourRight.Entity = this;
                    break;
                case Direction.Down:
                    GridCell.GetGrid(this.Position).Entity = null;
                    GridCell.GetGrid(this.Position).NeighbourBottom.Entity = this;
                    break;
                case Direction.Left:
                    GridCell.GetGrid(this.Position).Entity = null;
                    GridCell.GetGrid(this.Position).NeighbourLeft.Entity = this;
                    break;
            }
        }

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public override void Draw()
        {
            DrawRectangle(Color.Black, new Rectangle() {X = this.ScreenPos.X-3, Y = this.ScreenPos.Y-5, Width = 6, Height = 10 });
            GridCell.GetGrid(this.Position).Draw();
        }
    }
}