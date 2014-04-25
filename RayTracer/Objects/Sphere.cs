using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Objects
{
    public class Sphere : GeometricObject
    {
        public Point3d Center;
        public double Radius;
        private static double kEpsilon;

        public Sphere()
        {
        }

        public Sphere(Point3d center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override bool Intersect(Ray ray, out double tmin, ShadeRec shadeRec)
        {
            double t = 0;
            Vector3d temp = ray.Origin - Center;
            double a = Vector3d.Dot(ray.Direction, ray.Direction);
            double b = Vector3d.Dot(temp, ray.Direction)*2;
            double c = Vector3d.Dot(temp, temp) - Radius*Radius;
            double disc = b*b - 4*a*c;
            
            tmin = 0;
            if (disc < 0)
            {
                return false;
            }
            else
            {
                //TODO: what if denom == 0?
                double e = Math.Sqrt(disc);
                double denom = 2*a;
                
                //smaller root
                t = (-b - e)/denom;
                if (t>kEpsilon)
                {
                    tmin = t;
                    shadeRec.Normal = (temp + t*ray.Direction)/Radius;
                    shadeRec.Hitpoint = ray.Origin + t*ray.Direction;
                    return true;
                }
                //larger root
                t = (-b + e) / denom;
                if (t > kEpsilon)
                {
                    tmin = t;
                    shadeRec.Normal = (temp + t * ray.Direction) / Radius;
                    shadeRec.Hitpoint = ray.Origin + t * ray.Direction;
                    return true;
                }

                //no valid intersection
                return false;
            }
        }
    }
}
