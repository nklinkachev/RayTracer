using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.Geometry
{
    public struct Point3d
    {
        public double X;
        public double Y;
        public double Z;

        //public Point3d(){}

        public Point3d(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3d operator- (Point3d p, Vector3d v)
        {
            return new Point3d(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
        }

        public static Point3d operator -(Point3d p1, Point3d p2)
        {
            return new Point3d(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static Point3d operator+ (Point3d p, Vector3d v)
        {
            return new Point3d(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }

        public static implicit operator Vector3d (Point3d p)
        {
            return new Vector3d(p.X, p.Y, p.Z);
        }
    }
}
