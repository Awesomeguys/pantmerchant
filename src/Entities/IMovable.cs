using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantMerchant
{
    interface IMovable
    {
        /// <summary>
        /// Used to move the IMovable one grid in the 
        /// given direction
        /// </summary>
        /// <param name="d">The direction to move the IMovable</param>
        void Move(Direction d);
    }

    /// <summary>
    /// Enumeration specifying valid directions for the 
    /// Move() method of IMovable
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Up direction. Corresponds to top-right on the grid.
        /// </summary>
        Up,
        /// <summary>
        /// Right direcetion. Corresponds to bottom-right on the grid.
        /// </summary>
        Right,
        /// <summary>
        /// Down direction. Corresponds to bottom-left on the grid.
        /// </summary>
        Down,
        /// <summary>
        /// Left direction. Corresponds to top-left on the grid.
        /// </summary>
        Left,
        /// <summary>
        /// No direction. Used as the default value when a direction is instantiated.
        /// </summary>
        None = 0
    }
}
