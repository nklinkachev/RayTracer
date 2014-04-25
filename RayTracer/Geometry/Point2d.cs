using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.Geometry
{
    public struct Point2d
    {
        public double X;
        public double Y;

        //public Point2d(){}

        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}