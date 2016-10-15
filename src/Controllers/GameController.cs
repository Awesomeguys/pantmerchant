using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;
using System.Collections.Generic;

// Pantmerchant namespace
using PantMerchant;

namespace PantMerchant
{
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

        private GridCell[,] _grid { get; }

        public GridCell OriginGridCell { get; }

        private GameController()
        {
            this.OriginGridCell = new GridCell();
            this._grid = new GridCell[100, 100];    // TODO Remove hardcode
            _grid[50, 50] = this.OriginGridCell;
        }

        /// <summary>
        /// Static constructor for the current controller
        /// </summary>
        static GameController()
        {
            // Stuff goes here
        }

        public override void DoControllerStuff()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                StateController.PauseGame();
            }
            this.DoClickActions();
            View.Draw();
        }

        public GridCell GetGrid(Point2D p)
        {
            // TODO remove hard code
            if (this._grid[50 + p.X, 50 + p.Y] == null)
            {
                this._grid[50 + p.X, 50 + p.Y] = new GridCell(p);
                
            }

            return this._grid[50 + p.X, 50 + p.Y];
        }
    }
}

