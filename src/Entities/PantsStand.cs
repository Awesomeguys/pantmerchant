using System.Collections.Generic;

namespace PantMerchant
{
    class PantsStand : BaseEntity
    {
        public PantsStand(Point Position, List<Point> Footprint) : base(Position, Footprint) { }
    }
}
