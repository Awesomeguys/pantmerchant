using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
    /// <summary>
    /// Abstract base class used by all human entities
    /// </summary>
    public abstract class Person : BaseEntity, IMovable
    {
        /// <summary>
        /// Name of the person. "John Smith", etc.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Initialises a new instance of Person with 
        /// the given name at the given position.
        /// </summary>
        /// <param name="name">Name of the person. eg "John Smith"</param>
        /// <param name="position">Grid position the person currently occupies</param>
        /// <param name="resourcePath">The path containing the entity resources</param>
        public Person(string name, Point2D position, string resourcePath) 
            : base(position, new List<Point2D>() { Point2D.Origin }, resourcePath)
        {
            this.Name = name;
        }

        /// <summary>
        /// Used to move the Person one grid in the given direction
        /// </summary>
        /// <param name="d">The direction to move the Person</param>
        public void Move(Direction d)
        {
            if (d != Direction.None)
            {
                this.Facing = d;
                switch (d)
                {
                    case Direction.Up:
                        this.Grid.Entity = null;
                        this.Grid.NeighbourTop.Entity = this;
                        break;
                    case Direction.Right:
                        this.Grid.Entity = null;
                        this.Grid.NeighbourRight.Entity = this;
                        break;
                    case Direction.Down:
                        this.Grid.Entity = null;
                        this.Grid.NeighbourBottom.Entity = this;
                        break;
                    case Direction.Left:
                        this.Grid.Entity = null;
                        this.Grid.NeighbourLeft.Entity = this;
                        break;
                }
            }
        }
    }
}