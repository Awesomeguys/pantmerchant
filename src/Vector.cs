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
			if ((p1.X == p2.X) && (p1.Y == p2.Y)){
				return true;
			} else {
				return false;
			}
		}

		public static bool operator !=(Point2D p1, Point2D p2) {
			if ((p1.X == p2.X) && (p1.Y == p2.Y)){
				return false;
			} else {
				return true;
			}
		}

		public static Point2D operator +(Point2D p1, Point2D p2) {
			return new Point2D(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point2D operator +(Point2D p, Vector v) {
			Point2D result = new Point2D();
			result.X = p.X + (float)v.X;
			result.Y = p.Y + (float)v.Y;
			return result;
		}

		public static Point2D operator -(Point2D p1, Point2D p2) {
			return new Point2D(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static Point2D operator -(Point2D p, Vector v) {
			return (Vector)p - v;
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

		public static implicit operator Point2D(SwinGameSDK.Point2D p){
            // Automatically convert between my Point2D and SwinGame's Point2D
            PantMerchant.Point2D result = new PantMerchant.Point2D ();
			result.X = p.X;
			result.Y = p.Y;
			return result;
		}

		public static implicit operator Vector(Point2D p){
			// Automatically convert between my Point2D and Vector
			return new Vector((double)p.X, (double)p.Y);
		}
	}

	public class Vector {

		public double X, Y;

		public double Mag {
			get { return Math.Sqrt((X * X) + (Y * Y)); }
		}

		public Vector UnitVector {
			get {
				if (Mag == 0) {
					return new Vector (0, 0);
				}
				return new Vector (X / Mag, Y / Mag);
			}
		}

		public Vector() : this(0, 0) {}
		public Vector(double X, double Y) {
			this.X = X;
			this.Y = Y;
		}

		public override string ToString() {
			return String.Format("{0}, {1}", X, Y);
		}

		public Vector GetRightAngle(){
			return new Vector (this.X, -this.Y);
		}

		// Overloaded operators for vector arithmetic

		public static bool operator ==(Vector v1, Vector v2) {
			if ((v1.X == v2.X) && (v1.Y == v2.Y)){
				return true;
			} else {
				return false;
			}
		}

		public static bool operator !=(Vector v1, Vector v2) {
			if ((v1.X == v2.X) && (v1.Y == v2.Y)){
				return false;
			} else {
				return true;
			}
		}

		public static Vector operator +(Vector v1, Vector v2) {
			return new Vector(v1.X + v2.X, v1.Y + v2.Y);
		}

		public static Vector operator -(Vector v1, Vector v2) {
			return new Vector(v1.X - v2.X, v1.Y - v2.Y);
		}

		public static Vector operator *(int i, Vector v) {
			return new Vector(v.X * i, v.Y * i);
		}

		public static Vector operator *(Vector v, int i) {
			return i * v;
		}

		public static Vector operator *(double i, Vector v) {
			return new Vector(v.X *(double)i, v.Y*(double)i);
		}

		public static Vector operator *(Vector v, double i) {
			return new Vector(v.X *(double)i, v.Y*(double)i);
		}

		public static Vector operator /(Vector v, double d) {
			return new Vector(v.X / d, v.Y / d);
		}

		public static Vector operator /(Vector v, int i) {
			return new Vector(v.X / i, v.Y / i);
		}

		public static implicit operator Point2D(Vector v){
			// Automatically convert between my Point2D and Vector
			return new Point2D((float)v.X, (float)v.Y);
		}
	}
}

