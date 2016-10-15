using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant.Controllers
{
    class GameController : Controller
    {
        private static GameController _instance;

        /// <summary>
        /// The singleton instance of the current controller.
        /// </summary>
        public static new GameController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameController();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static GameController()
        {
            // Stuff goes here
        }

        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.PauseGame();
            }
            this.DoClickActions();
            View.Draw();
        }
    }
}
