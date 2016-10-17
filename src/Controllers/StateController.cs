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
        public new List<UIElement> UIElementList
        {
            get
            {
                return this.CurrentController.UIElementList;
            }
        }

        /// <summary>
        /// List of all IClickables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public new List<IClickable> IClickableList
        {
            get
            {
                return this.CurrentController.IClickableList;
            }
        }

        /// <summary>
        /// List of all IDrawables instantiated. Added to whichever 
        /// controller is currently in charge
        /// </summary>
        public new List<IDrawable> IDrawableList
        {
            get
            {
                return this.CurrentController.IDrawableList;
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
        public GameState CurrentState { get; set; }

        /// <summary>
        /// The controller which is currently in charge.
        /// </summary>
        public Controller CurrentController
        {
            get
            {
                switch (StateController.Instance.CurrentState)
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
            StateController.Instance.CurrentState = GameState.MainMenu;
        }

        /// <summary>
        /// Changes the game state to InGame, and putting the 
        /// GameController in charge
        /// </summary>
        public void StartGame()
        {
            this.CurrentState = GameState.InGame;
        }

        /// <summary>
        /// Pauses the game if in game.
        /// </summary>
        public void PauseGame()
        {
            if (this.CurrentState == GameState.InGame)
            {
                // we only want to pause if we actually have a game to pause
                this.CurrentState = GameState.GamePause;
            }
        }

        /// <summary>
        /// Changes the game state to MainMenu, switching out to the main menu.
        /// </summary>
        public void QuitToMainMenu()
        {
            this.CurrentState = GameState.MainMenu;
        }

        /// <summary>
        /// Changes the game state to UserQuit, quitting the program.
        /// </summary>
        public void QuitToDesktop()
        {
            this.CurrentState = GameState.UserQuit;
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
        public void DoCurrentControllerStuff()
        {
            ProcessEvents();
            this.CurrentController.DoControllerStuff();
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
