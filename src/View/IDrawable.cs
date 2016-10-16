using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    public interface IDrawable
    {
        Point2D ScreenPos { get; }
        void Draw();
    }
}