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
                new Point2D ( ScreenWidth(), ScreenHeight())
            );
        }

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

    public enum MenuType {
        Auto,
        Manual
    }
}