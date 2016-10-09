using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    class UIContainer : UIElement
    {
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
                new Point2D { X = 0, Y = 0 }, 
                new Point2D { X = ScreenWidth(), Y = ScreenHeight() }
            );
        }

        public UIContainer (List<UIElement> ChildElements, String Name, Point2D Pos, Point2D Size)
            : base (Name, Pos, Size) 
        {
            this.ChildElements = ChildElements;
        }

        public override void Draw()
        {
            DrawRectangle(Color.Black, new Rectangle() { X = this.ScreenPos.X, Y = this.ScreenPos.Y, Width = this.Size.X, Height = this.Size.Y });
        }
    }
}