using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Interface used by view class to draw entities to the screen.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Position on the screen to draw the object
        /// </summary>
        Point2D ScreenPos { get; }

        /// <summary>
        /// Image to draw to the screen.
        /// </summary>
        Bitmap Image { get;  }

        /// <summary>
        /// Draws the entity to the screen.
        /// </summary>
        void Draw();
    }
}