using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant.Controllers
{
    abstract class Controller
    {
        public void DoClickActions()
        {
            foreach (IClickable c in Registry.IClickableList)
            {
                if (c.IsClicked())
                {
                    c.ClickAction();
                }
            }
        }
    }
}
