using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    /// <summary>
    /// This class is used to create dynamic menus, from the main menu, to in-game context menus.
    /// </summary>
    class MenuElement : UIElement, IClickable
    {
        public Action ClickAction { get; }

        /// <summary>
        /// Text displayed on the menu button
        /// </summary>
        public String Text { get; set; }

        public MenuElement (String Title, Action ClickAction, String Name, UIContainer Container)
            : this (Title, ClickAction, Name, Point2D.Origin, Point2D.Origin, Container)
        {
            if (Container.Type != MenuType.Auto)
            {
                throw new InvalidMenuTypeException();
            }
        }
        public MenuElement (String Title, Action ClickAction, String Name, Point2D Pos, Point2D Size)
            : this (Title, ClickAction, Name, Pos, Size, UIContainer.GameWindow) {}
        public MenuElement(String Title, Action ClickAction, String Name, Point2D Pos, Point2D Size, UIContainer Container)
            : base(Name, Pos, Size, Container)
        {
            this.Text = Title;
            this.ClickAction = ClickAction;

            if (! this.Container.ChildElements.Contains(this))
            {
                this.Container.ChildElements.Add(this);
            }
        }

        public override void Draw()
        {
            switch (this.Container.Type)
            {
                case MenuType.Manual:
                    DrawRectangle(Color.Black, new Rectangle() { X = this.ScreenPos.X, Y = this.ScreenPos.Y, Width = this.Size.X, Height = this.Size.Y });
                    break;
                case MenuType.Auto:
                    DrawRectangle(
                        Color.Black, 
                        new Rectangle() {
                            X = this.Container.ScreenPos.X,
                            Y = this.Container.ScreenPos.Y + ( (this.Container.Size.Y / this.Container.ChildElements.Count) * this.Container.ChildElements.FindIndex(x => x == this) ),
                            Width = this.Container.Size.X,
                            Height = this.Container.Size.Y / this.Container.ChildElements.Count
                        }
                    );
                    break;
            }

            DrawText(
                this.Text, 
                Color.Black, 
                View.Font,
                this.ScreenPos.X + (this.Container.Size.X / 2) - (View.Font.TextWidth(this.Text) / 2),
                this.Container.ScreenPos.Y + ((this.Container.Size.Y / this.Container.ChildElements.Count) * this.Container.ChildElements.FindIndex(x => x == this)) + ( this.Container.Size.Y / this.Container.ChildElements.Count / 2 ) - ( View.Font.TextHeight(this.Text) / 2) 
            );
        }

        public bool IsClicked()
        {
            return ( 
                MouseClicked(MouseButton.LeftButton) && 
                MouseX() > this.ScreenPos.X &&
                MouseX() < this.ScreenPos.X + this.ScreenSize.X &&
                MouseY() > this.ScreenPos.Y &&
                MouseY() < this.ScreenPos.Y + this.ScreenSize.Y
            );
        }
    }

    internal class InvalidMenuTypeException : InvalidOperationException
    {
        public InvalidMenuTypeException()
            : base("The MenuElement cannot be created with a MenuType of Auto and default container.") { }
    }
}