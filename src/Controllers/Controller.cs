using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant.Controllers
{
    abstract class Controller
    {
        public List<UIElement> UIElementList { get; }
        public List<IClickable> IClickableList { get; }
        public List<IDrawable> IDrawableList { get; }
        public static Controller Instance { get; }

        protected Controller()
        {
            UIElementList = new List<UIElement>();
            IClickableList = new List<IClickable>();
            IDrawableList = new List<IDrawable>();
        }
        public void DoClickActions()
        {
            foreach (IClickable c in StateController.IClickableList)
            {
                if (c.IsClicked())
                {
                    c.ClickAction();
                }
            }
        }

        /// <summary>
        /// Overridden by child class. Allows controller actions to be 
        /// performed regardless of which controller is currently in 
        /// control.
        /// </summary>
        public abstract void DoControllerStuff();
    }
}
