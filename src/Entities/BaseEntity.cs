using System;
using System.Collections.Generic;
using SwinGameSDK;
using static SwinGameSDK.SwinGame;

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
        public Point Position { get; set; }

        /// <summary>
        /// A list of grid points relative to the
        /// position that the entity will take up.
        /// </summary>
        public List<Point> Footprint { get; set; }

        public BaseEntity(Point Position, List<Point> Footprint)
        {
            this.Position = Position;
            this.Footprint = Footprint;
        }
    }
}