using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Objects
{
    public class Plane : GeometricObject
    {
        public Point3d Point;
        public Normal Normal;

        private static double kEpsilon;

        public Plane()
        {
        }

        public Plane(Point3d point, Normal normal)
        {
            Point = point;
            Normal = normal;
        }

        public override bool Intersect(Ray ray, out double tmin, ShadeRec shadeRec)
        {
            double t = Vector3d.Dot((Point - ray.Origin), Normal)
                       / Vector3d.Dot(ray.Direction, Normal);
            if (t>kEpsilon && !double.IsInfinity(t))
            {
                tmin = t;
                shadeRec.Normal = Normal;
                shadeRec.Hitpoint = ray.Origin + t*ray.Direction;

                return true;
            }
            else
            {
                tmin = 0;
                return false;
            }
        }
    }
}
