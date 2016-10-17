using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant
{
    public abstract class Controller
    {
        /// <summary>
        /// List of all UI elements instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public List<UIElement> UIElementList { get; }

        /// <summary>
        /// List of all IClickables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public List<IClickable> IClickableList { get; }

        /// <summary>
        /// List of all IDrawables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public List<IDrawable> IDrawableList { get; }

        /// <summary>
        /// The singleton instance of the current controller.
        /// </summary>
        public static Controller Instance { get; }

        /// <summary>
        /// Initialises the base Controller class.
        /// </summary>
        protected Controller()
        {
            UIElementList = new List<UIElement>();
            IClickableList = new List<IClickable>();
            IDrawableList = new List<IDrawable>();
        }


        /// <summary>
        /// Handles click actions for all IClickables being 
        /// managed by the current controller
        /// </summary>
        public void DoClickActions()
        {
            foreach (IClickable c in this.IClickableList)
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
