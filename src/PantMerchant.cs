using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

using System.Collections.Generic;

namespace PantMerchant
{
    public class PantMerchantMain
    {
        ///<summary>
        /// Method which encapsulates requests to end the 
        /// program in one place.
        ///</summary>
        ///<returns>Boolean indicating whether the user has requested to close the program.</returns>
        static bool EndProgramRequested(){
            bool endGame = false;
            if  (   SwinGame.WindowCloseRequested()
                ||  SwinGame.KeyTyped(KeyCode.EscapeKey)) {
                endGame = true;
            }
            return endGame;
        }

        public static void Main()
        {
            View.Initialise();

            // Create some UIs
            UIContainer Menu = new UIContainer(
                    "Main Menu", 
                    new Point2D(
                        ScreenWidth() / 2 - 100,    // TODO Remove Hardcode
                        ScreenHeight() / 2 - 100    // TODO Remove Hardcode
                    ), 
                    new Point2D(200, 200), 
                    MenuType.Auto
            );

            List<UIElement> MenuList = new List<UIElement>();
            MenuList.Add(
                new MenuElement(
                    "New Game",
                    new Action(() => { Console.WriteLine("Test 1"); }),
                    "New Game",
                    Menu
                )
            );

            //Run the game loop
            while (!EndProgramRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                // Draw stuff on the screen
                View.Draw();
            }
        }
    }
}