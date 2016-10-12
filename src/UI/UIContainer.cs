using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    class UIContainer : UIElement
    {
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

        static UIContainer()
        {
            UIContainer.GameWindow = new UIContainer( 
                new List<UIElement>(), 
                "GameWindow", 
                new Point2D (), 
                new Point2D ( ScreenWidth(), ScreenHeight()),
                MenuType.Manual
            );
        }

        public UIContainer(String Name, Point2D Pos, Point2D Size)
            : this(new List<UIElement>(), Name, Pos, Size) { }
        public UIContainer(String Name, Point2D Pos, Point2D Size, MenuType Type)
            : this(new List<UIElement>(), Name, Pos, Size, Type) { }
        public UIContainer(List<UIElement> ChildElements, String Name, Point2D Pos, Point2D Size)
            : this(ChildElements, Name, Pos, Size, MenuType.Manual) { }
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