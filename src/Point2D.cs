using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
	public class Point2D {

		public float X, Y;

        /// <summary>
        /// A Point2D with coordinates (0, 0)
        /// </summary>
        public static Point2D Zero { get; }

		private Point2D() : this(0, 0) {}

		public Point2D(float X, float Y) {
			this.X = X;
			this.Y = Y;
		}

        static Point2D()
        {
            Point2D.Zero = new Point2D();
        }

        /// <summary>
        /// Enables printing the class.
        /// </summary>
        /// <returns>[X,Y]</returns>
        public override string ToString()
        {
            return "[" + X + "," + Y + "]";
        }

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

        public static Point2D operator +(Point2D p1, Point2D p2) {
			return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point2D operator -(Point2D p1, Point2D p2) {
			return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static Point2D operator *(Point2D p, float i) {
			return new Point2D(p.X *i, p.Y*i);
		}

		public static Point2D operator /(Point2D p, int i) {
			return new Point2D(p.X / i, p.Y / i);
		}

		public static Point2D operator /(Point2D p, double d) {
			return new Point2D((float)((double)p.X / d), (float)((double)p.Y / d));
		}

		public static implicit operator SwinGameSDK.Point2D(PantMerchant.Point2D p){
		// Automatically convert between my Point2D and SwinGame's Point2D
			SwinGameSDK.Point2D result = new SwinGameSDK.Point2D ();
			result.X = p.X;
			result.Y = p.Y;
			return result;
		}

		public static implicit operator PantMerchant.Point2D(SwinGameSDK.Point2D p){
            // Automatically convert between my Point2D and SwinGame's Point2D
            PantMerchant.Point2D result = new PantMerchant.Point2D ();
			result.X = p.X;
			result.Y = p.Y;
			return result;
		}
	}
}

