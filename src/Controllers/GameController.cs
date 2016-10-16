using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

// Pantmerchant namespace
using PantMerchant;

namespace PantMerchant
{
    public class GameController : Controller
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

        private BaseEntity test;

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static GameController()
        {
            // Stuff goes here
            Instance.test = new TestEntity("Test", Point2D.Origin);
        }

        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.PauseGame();
            }

            if (KeyTyped(KeyCode.UpKey))
            {
                test.Position += new PantMerchant.Point2D(0, 1);
            }
            else if (KeyTyped(KeyCode.RightKey))
            {
                test.Position += new PantMerchant.Point2D(1, 0);
            }
            else if (KeyTyped(KeyCode.DownKey))
            {
                test.Position += new PantMerchant.Point2D(0, -1);
            }
            else if (KeyTyped(KeyCode.LeftKey))
            {
                test.Position += new PantMerchant.Point2D(-1, 0);
            }

            this.DoClickActions();
            View.Draw();
        }
    }
}

