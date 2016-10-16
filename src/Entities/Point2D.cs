using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
	public class Point2D {

		public int X, Y;

        /// <summary>
        /// A Point2D with coordinates (0, 0)
        /// </summary>
        public static Point2D Origin { get; }

        /// <summary>
        /// A Point2D which represents the middle of the game window (in pixels).
        /// </summary>
        public static Point2D ScreenMiddle
        {
            get
            {
                try
                {
                    return new Point2D(Round(ScreenWidth() / 2), Round(ScreenHeight() / 2));
                }
                catch (TypeInitializationException e)
                {
                    return new Point2D(400, 300);
                }
            }
        }

        private Point2D() : this(0, 0) {}

		public Point2D(int X, int Y) {
			this.X = X;
			this.Y = Y;
		}

        static Point2D()
        {
            Point2D.Origin = new Point2D();            
        }

        /// <summary>
        /// Enables printing the class.
        /// </summary>
        /// <returns>[X,Y]</returns>
        public override string ToString()
        {
            return "[" + X + "," + Y + "]";
        }

        /// <summary>
        /// Returns the displacement of the provided Point2D from the 
        /// current one. How many X units and how many Y units to travel 
        /// to go from this one to the provided one.
        /// </summary>
        /// <param name="p">Point2D to compare with this one.</param>
        /// <returns>Point2D representing the displacement between the provided one and the current one.</returns>
        public Point2D GetRelativePosition(Point2D p){
            return p - this;
        }

		// Overloaded operators for vector arithmetic

        /// <summary>
        /// Determines if the coordinates are equal. Returns true if X and Y components are respectively equal.
        /// </summary>
        /// <param name="p1">First Point2D</param>
        /// <param name="p2">Second Point2D</param>
        /// <returns>True if Point2Ds refer to the same coordinate</returns>
		public static bool operator ==(Point2D p1, Point2D p2) {
            return (p1.X == p2.X) && (p1.Y == p2.Y);
        }

        /// <summary>
        /// Determines if the coordinates are not equal. Returns true if X and Y components are respectively not equal.
        /// </summary>
        /// <param name="p1">First Point2D</param>
        /// <param name="p2">Second Point2D</param>
        /// <returns>False if Point2Ds refer to the same coordinate</returns>
		public static bool operator !=(Point2D p1, Point2D p2) {
            return !((p1.X == p2.X) && (p1.Y == p2.Y));
        }

        /// <summary>
        /// Determines if the object is equal to the current Point2D. Returns true if obj is a Point2D and X and Y components are respectively equal.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if obj is a Point2D and refers to the same coordinate as current Point2D</returns>
        public override bool Equals(object obj)
        {
            var p2 = obj as Point2D;
            return (p2 != null) ? this == p2 : false;
        }

        /// <summary>
        /// Gets hash code based on the sum of the X and Y coordinates.
        /// </summary>
        /// <returns>Hash code based on sum of components</returns>
        public override int GetHashCode()
        {
            float sum = this.X + this.Y;
            return sum.GetHashCode();
        }

        /// <summary>
        /// Performs vector addition on two Point2Ds
        /// </summary>
        /// <param name="p1">Point2D to sum</param>
        /// <param name="p2">Point2D to sum</param>
        /// <returns>Returns the vector sum of p1 and p2</returns>
        public static Point2D operator +(Point2D p1, Point2D p2) {
			return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
		}

        /// <summary>
        /// Performs vector subtraction on two Point2Ds
        /// </summary>
        /// <param name="p1">Point2D to perform subtraction on</param>
        /// <param name="p2">Point2D to subtract from p1</param>
        /// <returns>Returns the vector sum of p1 and -(p2)</returns>
		public static Point2D operator -(Point2D p1, Point2D p2) {
			return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
		}

        /// <summary>
        /// Performs scalar multiplication on a vector p with d
        /// </summary>
        /// <param name="p">The vector to multiply</param>
        /// <param name="d">The scalar to multiply the p by</param>
        /// <returns>The product of p and d</returns>
		public static Point2D operator *(Point2D p, double d) {
			return new Point2D(Point2D.Round(p.X * d), Point2D.Round(p.Y * d));
		}

        /// <summary>
        /// Performs scalar division on a vector p with i, 
        /// rounding the components of p to the nearest integer.
        /// Equivalent to multiplying p by the reciprocal of i
        /// </summary>
        /// <param name="p">The vector to perform the division on</param>
        /// <param name="d">The scalar to divide p by</param>
        /// <returns>The quotient of p by d</returns>
		public static Point2D operator /(Point2D p, double d) {
            return p * (1 / d);
		}
        
        /// <summary>
        /// Performs implicit conversion between PantMerchant's Point2D and 
        /// SwinGame's in-built Point2D class.
        /// </summary>
        /// <param name="p">PantMerchant Point2D to convert</param>
        /// <returns>SwinGame Point2D</returns>
		public static implicit operator SwinGameSDK.Point2D(PantMerchant.Point2D p){
			return new SwinGameSDK.Point2D() { X = p.X, Y = p.Y };
		}

        /// <summary>
        /// Performs implicit conversion between PantMerchant's Point2D and 
        /// SwinGame's in-built Point2D class.
        /// </summary>
        /// <param name="p">SwinGame Point2D to convert</param>
        /// <returns>PantMerchant Point2D</returns>
		public static implicit operator PantMerchant.Point2D(SwinGameSDK.Point2D p){
			return new PantMerchant.Point2D(Point2D.Round(p.X), Point2D.Round(p.Y));
		}

        /// <summary>
        /// Rounds a double to the nearest int
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static int Round(double d)
        {
            if (d < 0)
            {
                return (int)(d - 0.5);
            }
            return (int)(d + 0.5);
        }
	}
}

