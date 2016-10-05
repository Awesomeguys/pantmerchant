using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    public class GameMain
    {
        ///<summary>
        /// Method which encapsulates requests to end the 
        /// program in one place.
        ///</summary>
        ///<returns>Boolean indicating whether the user has requested to close the program.</returns>
        static bool EndProgramRequested(){
            bool endGame = false;
            if  (    SwinGame.WindowCloseRequested()
                ||  SwinGame.KeyTyped(KeyCode.EscapeKey)) {
                endGame = true;
            }
            return endGame;
        }

        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            // SwinGame.ShowSwinGameSplashScreen();

            PantsStand myPantsStand = new PantsStand(
                new Point(10, 10),
                new List<Point>
                {
                    new Point(0, 10),
                    new Point(45, 6)
                }
            );
            myPantsStand.Position = new Point(0, myPantsStand.Position.Y);
            Console.WriteLine("List: " + myPantsStand.Footprint[0]);
            
            //Run the game loop
            while(!EndProgramRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);
                
                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            }
        }
    }
}