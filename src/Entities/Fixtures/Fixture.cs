using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;
using System.Runtime.Serialization;

namespace PantMerchant
{
    public class Fixture : BaseEntity
    {
        /// <summary>
        /// Type of fixture this is
        /// </summary>
        public FixtureType Type { get; }

        /// <summary>
        /// Initialises a new instance of the fixture class with the specified type, position, footprint, and resource path.
        /// </summary>
        /// <param name="Type">Type of the new fixture</param>
        /// <param name="position">Position it occupies</param>
        /// <param name="footprint">Which neighbouring cells it occupies</param>
        /// <param name="resourcePath">Path to the resources</param>
        public Fixture(FixtureType Type, Point2D position, List<Point2D> footprint, string resourcePath)
            : base(position, footprint, resourcePath)
        {
            this.Type = Type;
        }
    }

    /// <summary>
    /// Enumeration defining different types of fixtures available
    /// </summary>
    public enum FixtureType
    {
        /// <summary>
        /// Wall fixture
        /// </summary>
        Wall,
        /// <summary>
        /// Counter fixture
        /// </summary>
        Counter
    }
}
