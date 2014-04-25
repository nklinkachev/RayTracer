using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Tracers
{
    public class Normals : Tracer
    {
        public Normals(World world) : base(world)
        {
        }

        public override RGBColor TraceRay(Ray ray, int depth)
        {
            ShadeRec shadeRec = new ShadeRec(world); //not used
            double t; // not used

            if (world.Sphere.Intersect(ray, out t, shadeRec))
            {
                return new RGBColor((float) (shadeRec.Normal.X + 1)/2,
                                    (float) (shadeRec.Normal.Y + 1)/2,
                                    (float) (shadeRec.Normal.Z + 1)/2);
            }
            else
            {
                return new RGBColor(0, 0, 0);
            }
        }
    }
}