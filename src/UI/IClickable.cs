using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    /// <summary>
    /// Interface used by clickable objects.
    /// </summary>
    interface IClickable
    {
        /// <summary>
        /// Action performed when the implementing object has been "clicked" on.
        /// </summary>
        Action ClickAction { get; }

        /// <summary>
        /// Method to determine whether the object has been clicked on or not.
        /// </summary>
        /// <returns>True if object has been clicked, false if object has not been clicked.</returns>
        bool IsClicked();
    }
}