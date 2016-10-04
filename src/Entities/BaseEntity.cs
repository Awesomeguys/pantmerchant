using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant 
{

    class GridPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GridPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// Base class used by all grid entities.
    /// </summary>
    abstract class BaseEntity
    {
        public GridPoint Position { get; set; }
        public List<GridPoint> FootprintList { get; set; }
    }
}