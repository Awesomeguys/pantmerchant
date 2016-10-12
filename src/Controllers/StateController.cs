using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant.Controllers
{
    class StateController : Controller
    {
        public static new List<UIElement> UIElementList
        {
            get
            {
                return StateController.CurrentController.UIElementList;
            }
        }
        public static new List<IClickable> IClickableList
        {
            get
            {
                return StateController.CurrentController.IClickableList;
            }
        }
        public static new List<IDrawable> IDrawableList
        {
            get
            {
                return StateController.CurrentController.IDrawableList;
            }
        }

        private static StateController _instance;
        public static new StateController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StateController();
                }
                return _instance;
            }
        }

        public static GameState CurrentState { get; set; }
        public static Controller CurrentController
        {
            get
            {
                switch (StateController.CurrentState)
                {
                    case GameState.MainMenu:
                        return MainMenuController.Instance;
                    case GameState.InGame:
                    //return GameController.Instance;
                    default:
                        return MainMenuController.Instance;
                }
            }
        }

        static StateController()
        {
            // State at the main menu
            StateController.CurrentState = GameState.MainMenu;
        }
        public static void StartGame()
        {
            StateController.CurrentState = GameState.InGame;
        }

        /// <summary>
        /// Pauses the game if in game.
        /// </summary>
        public static void PauseGame()
        {
            if (StateController.CurrentState == GameState.InGame)
            {
                // we only want to pause if we actually have a game to pause
                StateController.CurrentState = GameState.GamePause;
            }
        }

        public static void QuitToMainMenu()
        {
            StateController.CurrentState = GameState.MainMenu;
        }

        public static void QuitToDesktop()
        {
            StateController.CurrentState = GameState.UserQuit;
        }
        
        /// <summary>
        /// Calls the DoControllerStuff method on the current controller
        /// </summary>
        public override void DoControllerStuff()
        {
            throw new InvalidOperationException("The instance method 'DoControllerStuff' should never be called on the StateController. Call the static method 'DoCurrentControllerStuff' instead.");
        }

        /// <summary>
        /// Calls the DoControllerStuff method on the current controller
        /// </summary>
        public static void DoCurrentControllerStuff()
        {
            ProcessEvents();
            StateController.CurrentController.DoControllerStuff();
        }
    }

    /// <summary>
    /// Enumeration defining different program states
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Main Menu
        /// </summary>
        MainMenu,
        /// <summary>
        /// In Game
        /// </summary>
        InGame,
        /// <summary>
        /// Paused Game - show the pause menu
        /// </summary>
        GamePause,
        /// <summary>
        /// User has quit the game
        /// </summary>
        UserQuit
    }
}
