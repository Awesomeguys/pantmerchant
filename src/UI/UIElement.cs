using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    abstract class UIElement
    {
        public String Name { get; private set; }
        public Point2D Pos { get; private set; }
        public Point2D Size { get; private set; }
        public UIContainer Container { get; private set; }

        public static List<UIElement> UIElementList { get; private set; }
        public static List<IClickable> IClickableList { get; private set; }

        static UIElement()
        {
            UIElementList = new List<UIElement>();
            IClickableList = new List<IClickable>();
        }

        public UIElement (String Name, Point2D Pos, Point2D Size) : this (Name, Pos, Size, UIContainer.GameWindow) {}
        public UIElement (String Name, Point2D Pos, Point2D Size, UIContainer Container)
        {
            this.Name = Name;
            this.Pos = Pos;
            this.Size = Size;
            this.Container = Container;

            UIElement.UIElementList.Add(this);
            if (this is IClickable)
            {
                UIElement.IClickableList.Add(this as IClickable);
            }
        }

        public abstract void Draw();
    }
}