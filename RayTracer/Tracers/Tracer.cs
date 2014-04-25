using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Tracers
{
    public class Tracer
    {
        protected World world;

        public Tracer(World world)
        {
            this.world = world;
        }

        public virtual RGBColor TraceRay(Ray ray)
        {
            return new RGBColor();
        }

        public virtual RGBColor TraceRay(Ray ray,int depth)
        {
            return new RGBColor();
        }

        public virtual RGBColor TraceRay(Ray ray,double tmin,int depth)
        {
            return new RGBColor();
        }
    }
}
