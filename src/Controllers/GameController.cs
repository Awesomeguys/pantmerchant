using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

// Pantmerchant namespace
using PantMerchant;

namespace PantMerchant
{
    /// <summary>
    /// Controller handling actions when in-game.
    /// </summary>
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

        /// <summary>
        /// Test person
        /// </summary>
        public Person Test;

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static GameController()
        {
            Instance.Test = new Customer("Test", Point2D.Origin);
        }

        /// <summary>
        /// Handles click actions for all IClickables being 
        /// managed by the current controller, as well as 
        /// drawing all IDrawables to the screen.
        /// </summary>
        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.Instance.PauseGame();
            }

            // Code to test entities moving around
            Direction moveDir = Direction.None;
            if (KeyTyped(KeyCode.UpKey))
            {
                moveDir = Direction.Up;
            }
            else if (KeyTyped(KeyCode.RightKey))
            {
                moveDir = Direction.Right;
            }
            else if (KeyTyped(KeyCode.DownKey))
            {
                moveDir = Direction.Down;
            }
            else if (KeyTyped(KeyCode.LeftKey))
            {
                moveDir = Direction.Left;
            }
            Test.Move(moveDir);

            this.DoClickActions();
            View.Draw();
        }
    }
}

