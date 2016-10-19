using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// Controller handling actions when the main-menu is open.
    /// </summary>
    public class MainMenuController : Controller
    {
        private static MainMenuController _instance;

        /// <summary>
        /// The singleton instance of the current controller.
        /// </summary>
        public static new MainMenuController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainMenuController();
                }
                return _instance;
            }
        }

        /// <summary>
        /// The music to play on the main menu
        /// </summary>
        private Music _Music;

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static MainMenuController()
        {
            MainMenuController.BuildMainMenu();
            MainMenuController.BuildSettingsMenu();
        }

        /// <summary>
        /// Initialises a new instance of the MainMenuController class
        /// </summary>
        private MainMenuController()
        {
            if (MainMenuController._instance != null)
            {
                throw new ControllerAlreadyInitialisedException();
            }
            this._Music = GameResources.GameMusic("MainMenu");
        }


        /// <summary>
        /// The main menu
        /// </summary>
        public UIContainer MainMenu { get; private set; }

        /// <summary>
        /// The settings menu
        /// </summary>
        public UIContainer Settings { get; private set; }

        /// <summary>
        /// Handles click actions for all IClickables being 
        /// managed by the current controller, as well as 
        /// drawing all IDrawables to the screen.
        /// </summary>
        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.Instance.QuitToDesktop();
            }

            if (!MusicPlaying())
            {
                PlayMusic(_Music);
            }

            this.DoClickActions();
            View.Draw();
        }

        /// <summary>
        /// Initialises the main menu.
        /// </summary>
        private static void BuildMainMenu()
        {
            Instance.MainMenu = new UIContainer(
                    "Main Menu",
                    Point2D.ScreenMiddle - new Point2D(100, 100),
                    new Point2D(200, 200),
                    MenuType.Auto
            );

            List<UIElement> MenuList = new List<UIElement>();
            MenuList.Add(
                new MenuElement(
                    "New Game",
                    new Action(() => { StateController.Instance.StartGame(); }),
                    "New Game",
                    Instance.MainMenu
                )
            );

            MenuList.Add(
                new MenuElement(
                    "Settings",
                    new Action(() => { MainMenuController.Instance.OpenSettingsMenu(); }),
                    "Settings",
                    Instance.MainMenu
                )
            );


            MenuList.Add(
                new MenuElement(
                    "Quit",
                    new Action(() => { StateController.Instance.QuitToDesktop(); }),
                    "Quit",
                    Instance.MainMenu
                )
            );
        }

        /// <summary>
        /// Initialises the settings menu.
        /// </summary>
        private static void BuildSettingsMenu()
        {
            // Create some UIs
            Instance.Settings = new UIContainer(
                    "Settings",
                    Point2D.ScreenMiddle - new Point2D(100, 100),
                    new Point2D(200, 200),
                    MenuType.Auto
            );

            Instance.Settings.Hide();

            List<UIElement> MenuList = new List<UIElement>();
            MenuList.Add(
                new MenuElement(
                    "Back to Main Menu",
                    new Action(() => { if (MusicPlaying()) { PauseMusic(); } else { ResumeMusic(); } }),
                    "Back to Main Menu",
                    Instance.Settings
                )
            );

            MenuList.Add(
                new MenuElement(
                    "Toggle Sound",
                    new Action(() => { if (MusicPlaying()) { PauseMusic(); } else { ResumeMusic(); } }),
                    "Toggle Sound",
                    Instance.Settings
                )
            );
        }

        private void OpenSettingsMenu()
        {
            if (!this.MainMenu.IsHidden)
            {
                this.MainMenu.Hide();
                this.Settings.Show();
            }
        }
    }
}
