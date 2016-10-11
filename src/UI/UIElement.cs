using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

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
        public Point2D ScreenPos { get { return this.Pos + ((this.Container != null) ? this.Container.Pos : new Point2D()); } }
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
        public Point2D ScreenSize { get { return (this.Size != new Point2D()) ? this.Size : new Point2D(this.Container.Size.X, this.Container.Size.Y / this.Container.ChildElements.Count); } }
        /// <summary>
        /// The container of the UI element. For when UI 
        /// elements need to exist within context menus, 
        /// popup menus, etc.
        /// </summary>
        public UIContainer Container { get; internal set; }

        /// <summary>
        /// Initialises a new instance of the UIElement class with the given name, position and size.
        /// </summary>
        /// <param name="Name">The name given to the UIElement</param>
        /// <param name="Pos">The position of the UIElement</param>
        /// <param name="Size">The size of the UIElement</param>
        public UIElement (String Name, Point2D Pos, Point2D Size) : this (Name, Pos, Size, UIContainer.GameWindow) {}

        /// <summary>
        /// Initialises a new instance of the UIElement class with the given name, position, size and container.
        /// </summary>
        /// <param name="Name">The name given to the UIElement</param>
        /// <param name="Pos">The position of the UIElement</param>
        /// <param name="Size">The size of the UIElement</param>
        /// <param name="Container">The UIContainer this element resides in</param>
        public UIElement (String Name, Point2D Pos, Point2D Size, UIContainer Container)
        {
            this.Name = Name;
            this.Pos = Pos;
            this.Size = Size;
            this.Container = Container;

            Registry.UIElementList.Add(this);
            Registry.IDrawableList.Add(this);
            if (this is IClickable)
            {
                Registry.IClickableList.Add(this as IClickable);
            }
        }
        /// <summary>
        /// Renders the UIElement to the screen.
        /// </summary>
        public abstract void Draw();
    }
}