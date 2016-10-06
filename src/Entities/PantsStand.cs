using System.Collections.Generic;

namespace PantMerchant
{
    class PantsStand : BaseEntity
    {
        public PantsStand(Coordinate Position, List<Coordinate> Footprint) : base(Position, Footprint) { }
    }
}
