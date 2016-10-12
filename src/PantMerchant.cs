using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

using System.Collections.Generic;

// Pantmerchant Libraries
using PantMerchant.Controllers;

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
                ||  SwinGame.KeyTyped(KeyCode.EscapeKey)
                ||  StateController.CurrentState == GameState.UserQuit
                ) {
                endGame = true;
            }
            return endGame;
        }

        public static void Main()
        {
            View.Initialise();

            while (!EndProgramRequested())
            {
                StateController.DoCurrentControllerStuff();
            }
        }
    }
}