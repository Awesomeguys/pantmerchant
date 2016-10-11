using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant.Controllers
{
    class MainMenuController : Controller
    {
        private static MainMenuController _instance;
        public static MainMenuController Instance {
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

        }
    }
}
