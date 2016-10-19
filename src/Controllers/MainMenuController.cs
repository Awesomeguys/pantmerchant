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
        public static new MainMenuController Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainMenuController();
                }
                return _instance;
            }
        }
        
        private static Music _Music;

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static MainMenuController()
        {
            MainMenuController.BuildMainMenu();
            _Music = GameResources.GameMusic("MainMenu");
        }

        /// <summary>
        /// The main menu to draw.
        /// </summary>
        public UIContainer MainMenu { get; private set; }

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
            // Create some UIs
            UIContainer Menu = new UIContainer(
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
                    Menu
                )
            );

            MenuList.Add(
                new MenuElement(
                    "Quit",
                    new Action(() => { StateController.Instance.QuitToDesktop(); }),
                    "Quit",
                    Menu
                )
            );
        }
    }
}
