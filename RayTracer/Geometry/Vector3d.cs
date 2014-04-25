using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.Geometry
{
    public struct Vector3d
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Normalize()
        {
            double length = Math.Sqrt(X*X + Y*Y + Z*Z);
            X /= length;
            Y /= length;
            Z /= length;
        }

        public static double Dot(Vector3d v1, Vector3d v2)
        {
            return v1.X*v2.X + v1.Y*v2.Y + v1.Z*v2.Z;
        }

        public static Vector3d Cross(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.Y*v2.Z - v1.Z*v2.Y,
                                v1.Z*v2.X - v1.X*v2.Z,
                                v1.X*v2.Y - v1.Y*v2.X);
        }

        public static Vector3d operator -(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3d operator -(Vector3d v)
        {
            return new Vector3d(-v.X, -v.Y, -v.Z);
        }

        public static Vector3d operator +(Vector3d v1, Vector3d v2)
        {
            return new Vector3d(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3d operator*(Vector3d v,double d)
        {
            return new Vector3d(v.X*d, v.Y*d, v.Z*d);
        }

        public static Vector3d operator*(double d, Vector3d v)
        {
            return v*d;
        }

        public static Vector3d operator /(Vector3d v, double d)
        {
            d = 1/d;
            return v*d;
        }

        public static implicit operator Normal(Vector3d v)
        {
            return new Normal(v.X, v.Y, v.Z);
        }

        public static implicit operator Point3d(Vector3d v)
        {
            return new Point3d(v.X, v.Y, v.Z);
        }
    }
}
