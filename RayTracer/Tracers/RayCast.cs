using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Tracers
{
    public class RayCast : Tracer
    {
        public RayCast(World world) : base(world){}

        public override RGBColor TraceRay(Ray ray, int depth)
        {
            ShadeRec shadeRec = world.IntersectAllObjects(ray);

            if (shadeRec.HasHitObject)
            {
                shadeRec.Ray = ray;
                return shadeRec.Material.Shade(shadeRec);
            }
            else
            {
                return world.BackgroundColor;
            }
        }
    }
}
