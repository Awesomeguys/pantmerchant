using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    class UIContainer : UIElement
    {
        public List<UIElement> ChildElements { get; private set; }

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
            // Draw method goes here.
        }
    }
}