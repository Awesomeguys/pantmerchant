using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class to be used by all grid entities.
    /// </summary>
    public class TestEntity : BaseEntity
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

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public override void Draw()
        {
            DrawRectangle(Color.Black, new Rectangle() {X = this.ScreenPos.X-3, Y = this.ScreenPos.Y-5, Width = 6, Height = 10 });
        }
    }
}