using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class to be used by all grid entities.
    /// </summary>
    public class TestEntity : BaseEntity, IMovable
    {
        string Name { get; }
        public TestEntity(string Name, Point2D position) : base(position, new List<Point2D>() { Point2D.Origin })
        {
            this.Name = Name;
        }
        public TestEntity(string Name, Point2D position, List<Point2D> footprint) : base(position, footprint)
        {
            this.Name = Name;
        }

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