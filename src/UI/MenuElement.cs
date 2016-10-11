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
        public Delegate ClickAction { get; }

        /// <summary>
        /// Text displayed on the menu button
        /// </summary>
        public String Title { get; set; }

        public MenuElement (String Title, Delegate ClickAction, String Name, UIContainer Container)
            : this (Title, ClickAction, Name, new Point2D(), new Point2D())
        {
            if (this.Container.Type != MenuType.Auto)
            {
                throw new InvalidMenuTypeException();
            }
        }
        public MenuElement (String Title, Delegate ClickAction, String Name, Point2D Pos, Point2D Size)
            : this (Title, ClickAction, Name, Pos, Size, UIContainer.GameWindow) {}
        public MenuElement(String Title, Delegate ClickAction, String Name, Point2D Pos, Point2D Size, UIContainer Container)
            : base(Name, Pos, Size, Container)
        {
            this.Title = Title;
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
                            Y = this.Container.ScreenPos.Y,
                            Width = this.Container.Size.X,
                            Height = this.Container.Size.Y
                        }
                    );
                    break;
            }
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

    internal class InvalidMenuTypeException : InvalidOperationException
    {
        public InvalidMenuTypeException()
            : base("The MenuElement cannot be created with a MenuType of Auto and default container.") { }
    }
}