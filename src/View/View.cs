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
        public static Font Font { get; set; }
        static View()
        {
            View.Font = new Font("Arial", 11);
            //Open the game window
            SwinGame.OpenGraphicsWindow("PantMerchant", 800, 600);
            //SwinGame.ShowSwinGameSplashScreen();
        }
        /// <summary>
        /// Used to draw all IDrawable objects to the screen.
        /// </summary>
        public static void Draw()
        {
            //Clear the screen and draw the framerate
            SwinGame.ClearScreen(Color.White);
            SwinGame.DrawFramerate(0, 0);

            foreach (IDrawable d in StateController.IDrawableList)
            {
                d.Draw();
            }

            //Draw onto the screen
            SwinGame.RefreshScreen(60);
        }

        public static void Initialise()
        {
            // Doesn't do anything. Used for calling the constructor.
        }
    }
}