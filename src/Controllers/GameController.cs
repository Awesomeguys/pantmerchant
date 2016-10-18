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
        /// Keeps track of the daily timed events.
        /// </summary>
        public static Timer DayTimer;

        /// <summary>
        /// Keeps track of the market timed events.
        /// </summary>
        public static Timer MarketTimer;

        public static CommerceView CommerceView;

        /// <summary>
        /// Test person
        /// </summary>
        public Person Test { get; set; }

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static GameController()
        {
            Instance.Test = new Customer("Test", Point2D.Origin);

            Finance.Money = 1000;
            Stock.Set(50);
            Stock.AmountPerDay = 1;
            //Finance.Streams.Add(new FinanceStream("Bears", 9));
            //Finance.Streams.Add(new FinanceStream("Chickens", -18));
            //Finance.Streams.Add(new FinanceStream("Uranium", 47));

            DayTimer = CreateTimer();
            MarketTimer = CreateTimer();
            DayTimer.Start();
            MarketTimer.Start();

            CommerceView = new CommerceView();
            StateController.Instance.CurrentController.IDrawableList.Add(CommerceView);
        }

        /// <summary>
        /// Handles click actions for all IClickables being 
        /// managed by the current controller, as well as 
        /// drawing all IDrawables to the screen.
        /// </summary>
        public override void DoControllerStuff()
        {
            DayTimer.Resume();
            MarketTimer.Resume();

            if (DayTimer.Ticks >= 2000)
            {
                DayTimer.Reset();
                // Console.WriteLine("TIMER!");
                Finance.UpdateMoneyFromNet();
                Stock.Update();
            }

            if (MarketTimer.Ticks >= Market.CustomerFrequency)
            {
                MarketTimer.Reset();
                POS.SellItem();
            }

            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                DayTimer.Pause();
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

