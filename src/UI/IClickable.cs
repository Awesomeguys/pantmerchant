using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    interface IClickable
    {
        Delegate ClickAction { get; }

        bool IsClicked();
    }
}