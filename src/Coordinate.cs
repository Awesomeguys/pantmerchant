namespace PantMerchant
{
    /// <summary>
    /// A 2D coordinate class.
    /// </summary>
    class Coordinate
    {
        /// <summary>
        /// The coordinates.
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Enables printing the class.
        /// </summary>
        /// <returns>[X,Y]</returns>
        public override string ToString()
        {
            return "[" + X + "," + Y + "]";
        }
    }
}
