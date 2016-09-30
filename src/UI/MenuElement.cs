using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    class MenuElement : UIElement, IClickable
    {
        public Delegate ClickAction { get; }
        public String Title { get; set; }

        public MenuElement (String Title, Delegate ClickAction, String Name, Point2D Pos, Point2D Size)
            : this (Title, ClickAction, Name, Pos, Size, UIContainer.GameWindow) {}
        public MenuElement(String Title, Delegate ClickAction, String Name, Point2D Pos, Point2D Size, UIContainer Container)
            : base(Name, Pos, Size, Container)
        {
            this.Title = Title;
            this.ClickAction = ClickAction;
        }

        public override void Draw()
        {
            // Draw method goes here.
        }

        public bool IsClicked()
        {
            return ( 
                MouseClicked(MouseButton.LeftButton) && 
                MouseX() > this.Pos.X &&
                MouseX() < this.Pos.X + this.Size.X &&
                MouseY() > this.Pos.Y &&
                MouseY() < this.Pos.Y + this.Size.Y
            );
        }
    }
}