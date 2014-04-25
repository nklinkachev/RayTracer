using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Tracers
{
    public class SingleSphere : Tracer
    {
        public SingleSphere(World world) : base(world){}

        public override RGBColor TraceRay(Ray ray, int depth)
        {
            ShadeRec shadeRec = new ShadeRec(world); //not used
            double t; // not used

            if (world.Sphere.Intersect(ray, out t, shadeRec))
            {
                return new RGBColor(1, 0, 0);
            }
            else
            {
                return new RGBColor(0, 0, 0);
            }
        }
    }
}
