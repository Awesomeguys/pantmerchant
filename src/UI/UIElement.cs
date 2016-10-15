using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

// Pantmerchant Libraries
using PantMerchant.Controllers;

namespace PantMerchant 
{
    /// <summary>
    /// Base class for any element of the UI. All buttons in 
    /// all menus, HUD displays, etc. Anything from a "New 
    /// Game" button on the main menu to an in-game minimap, 
    /// to a dropdown context menu should inherit from this 
    /// class. Can also act as a container for other UI 
    /// Elements.
    /// </summary>
    abstract class UIElement : IDrawable
    {
        /// <summary>
        /// Internal name given to the UI element. 
        /// </summary>
        public String Name { get; private set; }
        /// <summary>
        /// The on-screen coordinates of the UI element
        /// </summary>
        public Point2D ScreenPos
        {
            get {
                return 
                    this.Pos + (
                        (this.Container == null) 
                        ? Point2D.Zero
                        : new Point2D(this.Container.Pos.X, this.Container.Pos.Y + this.Pos.Y +  this.ScreenSize.Y * this.Container.ChildElements.FindIndex(x => x == this))
                    );
            }
        }
        /// <summary>
        /// The position of the UI element. These coordinates 
        /// are on screen. Where the UI element is a part of 
        /// a UI container, the position is relative to the 
        /// position of the container, otherwise is relative 
        /// to the program window.
        /// </summary>
        public Point2D Pos { get; private set; }
        /// <summary>
        /// The width and height of the UI element. Each 
        /// component of the Point2D refers to the distance 
        /// of that point from it's corresponding component 
        /// in the Pos property.
        /// </summary>
        public Point2D Size { get; private set; }
        /// <summary>
        /// The on-screen size of the UI element. Used when
        /// the container type is auto.
        /// </summary>
        public Point2D ScreenSize { get { return (this.Size != Point2D.Zero) ? this.Size : new Point2D(this.Container.Size.X, this.Container.Size.Y / this.Container.ChildElements.Count); } }
        /// <summary>
        /// The container of the UI element. For when UI 
        /// elements need to exist within context menus, 
        /// popup menus, etc.
        /// </summary>
        public UIContainer Container { get; internal set; }
        /// <summary>
        /// Initialises a new instance of the UIElement class.
        /// </summary>
        /// <param name="Name">Name given to the UI element</param>
        /// <param name="Pos">Position of the UI element</param>
        /// <param name="Size">Size of the UI element</param>
        public UIElement (String Name, Point2D Pos, Point2D Size) : this (Name, Pos, Size, UIContainer.GameWindow) {}
        public UIElement (String Name, Point2D Pos, Point2D Size, UIContainer Container)
        {
            this.Name = Name;
            this.Pos = Pos;
            this.Size = Size;
            this.Container = Container;

            StateController.UIElementList.Add(this);
            StateController.IDrawableList.Add(this);
            if (this is IClickable)
            {
                StateController.IClickableList.Add(this as IClickable);
            }
        }

        /// <summary>
        /// Used by the View class to draw IDrawable objects to the screen.
        /// </summary>
        public abstract void Draw();
    }
}