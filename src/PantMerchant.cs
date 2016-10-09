using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

using System.Collections.Generic;

namespace PantMerchant
{
    public class PantMerchant
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

            // Create some UIs
            List<UIElement> MenuList = new List<UIElement>();
            MenuList.Add(
                new MenuElement(
                    "Test 1",
                    (Action)delegate { Console.WriteLine("Test 1"); },
                    "Test 1",
                    new Point2D() { X = 10, Y = 10 },
                    new Point2D() { X = 50, Y = 10 }
                )
            );

            MenuList.Add(
                new MenuElement(
                    "Test 2",
                    (Action)delegate { Console.WriteLine("Test 2"); },
                    "Test 2",
                    new Point2D() { X = 10, Y = 10 },
                    new Point2D() { X = 50, Y = 10 }
                )
            );

            UIContainer Menu = new UIContainer(
                    MenuList, "Test Menu", new Point2D() { X = 200, Y = 200 }, new Point2D() { X = 200, Y = 200 }
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