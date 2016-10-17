using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Concrete customer class
    /// </summary>
    public class Customer : Person
    {

        /// <summary>
        /// Initialises a new instance of Person with 
        /// the given name at the given position.
        /// </summary>
        /// <param name="Name">Name of the person. eg "John Smith"</param>
        /// <param name="position">Grid position the person currently occupies</param>
        public Customer(string Name, Point2D position) : base(Name, position)
        {
        }
        
        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public override void Draw()
        {
            DrawRectangle(Color.Black, new Rectangle() { X = this.ScreenPos.X - 3, Y = this.ScreenPos.Y - 5, Width = 6, Height = 10 });
            GridCell.GetGrid(this.Position).Draw();
        }
    }
}