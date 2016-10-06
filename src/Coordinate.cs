namespace PantMerchant
{
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return "[" + this.X + "," + this.Y + "]";
        }
    }
}
