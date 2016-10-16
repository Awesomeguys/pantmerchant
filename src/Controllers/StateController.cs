using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// This class can be thought of as the Controller controller.
    /// The game's "state" determines which controller is in control
    /// of the input at a given time. The state controller keeps 
    /// track of whether you are on the main menu, in the middle of 
    /// the game, or about to quit.
    /// </summary>
    public class StateController : Controller
    {
        /// <summary>
        /// List of all UI elements instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public static new List<UIElement> UIElementList
        {
            get
            {
                return StateController.CurrentController.UIElementList;
            }
        }

        /// <summary>
        /// List of all IClickables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public static new List<IClickable> IClickableList
        {
            get
            {
                return StateController.CurrentController.IClickableList;
            }
        }

        /// <summary>
        /// List of all IDrawables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public static new List<IDrawable> IDrawableList
        {
            get
            {
                return StateController.CurrentController.IDrawableList;
            }
        }

        private static StateController _instance;

        /// <summary>
        /// The singleton instance of the current controller.
        /// </summary>
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

        /// <summary>
        /// The state the game is currently in
        /// </summary>
        public static GameState CurrentState { get; set; }

        /// <summary>
        /// The controller which is currently in charge.
        /// </summary>
        public static Controller CurrentController
        {
            get
            {
                switch (StateController.CurrentState)
                {
                    case GameState.MainMenu:
                        return MainMenuController.Instance;
                    case GameState.InGame:
                        return GameController.Instance;
                    default:
                        // Return to the main menu if we go to an unimplemented state
                        return MainMenuController.Instance;
                }
            }
        }

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static StateController()
        {
            // State at the main menu
            StateController.CurrentState = GameState.MainMenu;
        }

        /// <summary>
        /// Changes the game state to InGame, and putting the 
        /// GameController in charge
        /// </summary>
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

        /// <summary>
        /// Changes the game state to MainMenu, switching out to the main menu.
        /// </summary>
        public static void QuitToMainMenu()
        {
            StateController.CurrentState = GameState.MainMenu;
        }

        /// <summary>
        /// Changes the game state to UserQuit, quitting the program.
        /// </summary>
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
