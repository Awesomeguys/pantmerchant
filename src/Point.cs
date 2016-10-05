﻿using System;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "[" + this.X + "," + this.Y + "]";
        }
    }
}
