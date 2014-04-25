using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.Geometry
{
    public struct Normal
    {
        public double X;
        public double Y;
        public double Z;

        //public Normal(){}

        public Normal(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static implicit operator Vector3d (Normal n)
        {
            return new Vector3d(n.X, n.Y, n.Z);
        }
    }
}
