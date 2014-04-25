using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Tracers
{
    public class MultipleObjects : Tracer
    {
        public MultipleObjects(World world) : base(world)
        {
        }

        public override RGBColor TraceRay(Ray ray, int depth)
        {
            ShadeRec shadeRec = world.IntersectAllObjects(ray);
            if (shadeRec.HasHitObject)
                return shadeRec.Color;
            return world.BackgroundColor;
        }
    }
}