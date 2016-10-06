using System.Collections.Generic;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class to be used by all grid entities.
    /// </summary>
    abstract class BaseEntity
    {
        /// <summary>
        /// The position on the grid.
        /// </summary>
        public Coordinate Position { get; set; }

        /// <summary>
        /// A list of grid points relative to the
        /// position that the entity will take up.
        /// </summary>
        public List<Coordinate> Footprint { get; set; }

        public BaseEntity(Coordinate position, List<Coordinate> footprint)
        {
            Position = position;
            Footprint = footprint;
        }
    }
}