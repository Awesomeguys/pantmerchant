using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    static class Registry
    {
        public static List<UIElement> UIElementList { get; }
        public static List<IClickable> IClickableList { get; }
        public static List<IDrawable> IDrawableList { get; }
        static Registry()
        {
            Registry.UIElementList = new List<UIElement>();
            Registry.IClickableList = new List<IClickable>();
            Registry.IDrawableList = new List<IDrawable>();
        }
    }
}