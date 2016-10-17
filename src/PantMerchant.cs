using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// Main class
    /// </summary>
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
                ||  StateController.Instance.CurrentState == GameState.UserQuit
                ) {
                endGame = true;
            }
            return endGame;
        }

        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            View.Initialise();

            while (!EndProgramRequested())
            {
                StateController.Instance.DoCurrentControllerStuff();
            }
        }
    }
}