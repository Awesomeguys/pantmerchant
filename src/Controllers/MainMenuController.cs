using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

namespace PantMerchant.Controllers
{
    class MainMenuController : Controller
    {
        private static MainMenuController _instance;
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

        private MainMenuController()
        {
            
        }

        static MainMenuController()
        {
            MainMenuController.BuildMainMenu();
        }

        public UIContainer MainMenu { get; private set; }

        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.QuitToDesktop();
            }
            this.DoClickActions();
            View.Draw();
        }

        private static void BuildMainMenu()
        {
            // Create some UIs
            UIContainer Menu = new UIContainer(
                    "Main Menu",
                    new Point2D(
                        ScreenWidth() / 2 - 100,    // TODO Remove Hardcode
                        ScreenHeight() / 2 - 100    // TODO Remove Hardcode
                    ),
                    new Point2D(200, 200),
                    MenuType.Auto
            );

            List<UIElement> MenuList = new List<UIElement>();
            MenuList.Add(
                new MenuElement(
                    "New Game",
                    new Action(() => { StateController.StartGame(); }),
                    "New Game",
                    Menu
                )
            );

            MenuList.Add(
                new MenuElement(
                    "Quit",
                    new Action(() => { StateController.QuitToDesktop(); }),
                    "Quit",
                    Menu
                )
            );
        }
    }
}
