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
        public Point2D Position { get; set; }

        /// <summary>
        /// A list of grid points relative to the
        /// position that the entity will take up.
        /// </summary>
        public List<Point2D> Footprint { get; set; }

        public BaseEntity(Point2D position, List<Point2D> footprint)
        {
            Position = position;
            Footprint = footprint;
        }
    }
}