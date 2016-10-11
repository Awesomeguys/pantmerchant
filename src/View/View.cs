using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{
    /// <summary>
    /// Global class used to manage drawing to 
    /// the screen.
    /// </summary>
    static class View
    {
        static View()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("PantMerchant", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
        }
        /// <summary>
        /// Used to draw all IDrawable objects to the screen.
        /// </summary>
        public static void Draw()
        {
            //Clear the screen and draw the framerate
            SwinGame.ClearScreen(Color.White);
            SwinGame.DrawFramerate(0, 0);

            foreach (IDrawable d in Registry.IDrawableList)
            {
                d.Draw();
            }

            //Draw onto the screen
            SwinGame.RefreshScreen(60);
        }
    }
}