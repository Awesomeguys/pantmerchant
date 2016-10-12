using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant.Controllers
{
    class StateController : Controller
    {
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

        public GameState CurrentState { get; set; }

        private StateController()
        {
            // State at the main menu
            this.CurrentState = GameState.MainMenu;
        }
        public void StartGame()
        {
            this.CurrentState = GameState.InGame;
        }

        public void PauseGame()
        {
            if (this.CurrentState == GameState.InGame)
            {
                // we only want to pause if we actually have a game to pause
                this.CurrentState = GameState.GamePause;
            }
        }

        public void QuitToMainMenu()
        {
            this.CurrentState = GameState.MainMenu;
        }

        public void QuitToDesktop()
        {
            this.CurrentState = GameState.UserQuit;
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
