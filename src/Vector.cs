using System;
using SwinGameSDK;
using System.Collections.Generic;
using static SwinGameSDK.SwinGame;

namespace PantMerchant
{
	public class Point2D {

		public float X, Y;

		public Point2D() : this(0, 0) {}

		public Point2D(float X, float Y) {
			this.X = X;
			this.Y = Y;
		}

		public override string ToString() {
			return String.Format("{0}, {1}", X, Y);
		}	

        public Point2D GetRelativePosition(Point2D p){
            return p - this;
        }

		// Overloaded operators for vector arithmetic

		public static bool operator ==(Point2D p1, Point2D p2) {
            return (p1.X == p2.X) && (p1.Y == p2.Y);
        }

		public static bool operator !=(Point2D p1, Point2D p2) {
            return !((p1.X == p2.X) && (p1.Y == p2.Y));

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

