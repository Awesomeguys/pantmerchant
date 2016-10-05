using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    class PantsStand : BaseEntity
    {
        public PantsStand(Point Position, List<Point> Footprint) : base(Position, Footprint) { }
    }
}
