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
        public Point2D ScreenPos { get { return this.Pos; } }
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
        /// The container of the UI element. For when UI 
        /// elements need to exist within context menus, 
        /// popup menus, etc.
        /// </summary>
        public UIContainer Container { get; private set; }

        public UIElement (String Name, Point2D Pos, Point2D Size) : this (Name, Pos, Size, UIContainer.GameWindow) {}
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

        public abstract void Draw();
    }
}