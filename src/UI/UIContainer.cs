using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    /// <summary>
    /// UIElement which is able to contain other UIElements. 
    /// Used to create dropdown menus, etc.
    /// </summary>
    public class UIContainer : UIElement
    {
        /// <summary>
        /// Specifies how the ChildElements are drawn to the screen. If Auto, ChildElements 
        /// are drawn at automatic positions, filling up the whole x-axis and evenly split
        /// down the y axis.
        /// </summary>
        public MenuType Type;
        /// <summary>
        /// List containing the UI elements which 
        /// are contained by this UI container.
        /// </summary>
        public List<UIElement> ChildElements { get; private set; }
        
        /// <summary>
        /// Static UI container used for placing UI 
        /// elements within the "root" container, 
        /// the game window.
        /// </summary>
        public static UIContainer GameWindow { get; private set; }

        /// <summary>
        /// Initialises the static members of UIContainer.
        /// </summary>
        static UIContainer()
        {
            UIContainer.GameWindow = new UIContainer( 
                new List<UIElement>(), 
                "GameWindow", 
                Point2D.Origin, 
                new Point2D ( ScreenWidth(), ScreenHeight()),
                MenuType.Manual
            );
        }

        /// <summary>
        /// Initialises a new instance of UIContainer with the given name, position and size.
        /// </summary>
        /// <param name="Name">The name of the UI container</param>
        /// <param name="Pos">The position of the UI container</param>
        /// <param name="Size">The size of the UI container</param>
        public UIContainer(String Name, Point2D Pos, Point2D Size)
            : this(new List<UIElement>(), Name, Pos, Size) { }

        /// <summary>
        /// Initialises a new instance of UIContainer with the given name, position, size and type option.
        /// </summary>
        /// <param name="Name">The name of the UI container</param>
        /// <param name="Pos">The position of the UI container</param>
        /// <param name="Size">The size of the UI container</param>
        /// <param name="Type">Specifies whether the elements inside are automatically placed when draw, or if their position is manually specified.</param>
        public UIContainer(String Name, Point2D Pos, Point2D Size, MenuType Type)
            : this(new List<UIElement>(), Name, Pos, Size, Type) { }
        /// <summary>
        /// Initialises a new instance of UIContainer with the given name, position and size, and containing the specified UIElements
        /// </summary>
        /// <param name="ChildElements">List of UIElements this UIContainer contains</param>
        /// <param name="Name">The name of the UI container</param>
        /// <param name="Pos">The position of the UI container</param>
        /// <param name="Size">The size of the UI container</param>
        public UIContainer(List<UIElement> ChildElements, String Name, Point2D Pos, Point2D Size)
            : this(ChildElements, Name, Pos, Size, MenuType.Manual) { }
        /// <summary>
        /// Initialises a new instance of UIContainer with the given name, position, size and type options, and containing the specified UIElements
        /// </summary>
        /// <param name="ChildElements">List of UIElements this UIContainer contains</param>
        /// <param name="Name">The name of the UI container</param>
        /// <param name="Pos">The position of the UI container</param>
        /// <param name="Size">The size of the UI container</param>
        /// <param name="Type">Specifies whether the elements inside are automatically placed when draw, or if their position is manually specified.</param>
        public UIContainer(List<UIElement> ChildElements, String Name, Point2D Pos, Point2D Size, MenuType Type)
            : base(Name, Pos, Size)
        {
            this.Type = Type;
            this.ChildElements = ChildElements;

            foreach (UIElement u in ChildElements)
            {
                u.Container = this;
            }
        }

        /// <summary>
        /// Draws the UIContainer to the screen.
        /// </summary>
        public override void Draw()
        {
            DrawRectangle(Color.Black, new Rectangle() { X = this.ScreenPos.X, Y = this.ScreenPos.Y, Width = this.Size.X, Height = this.Size.Y });
        }
    }

    /// <summary>
    /// Enum defining whether the menu elements are placed manually or automatically within the UI container
    /// </summary>
    public enum MenuType {
        /// <summary>
        /// Menu elements are placed automatically, filling the container.
        /// </summary>
        Auto,
        /// <summary>
        /// Menu elements are placed manually, allowing the position and size within the UI container to be specified.
        /// </summary>
        Manual
    }
}