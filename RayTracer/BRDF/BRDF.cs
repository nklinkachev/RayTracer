using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Samplers;
using RayTracer.Geometry;

namespace RayTracer.BRDF
{
    public class BRDF
    {
        public Normal Normal;
        protected Sampler Sampler;
        
        public BRDF(Sampler sampler)
        {
            this.Sampler = sampler;
        }

        public virtual RGBColor F(ShadeRec shadeRec, Vector3d wi, Vector3d wo)
        {
            return new RGBColor();
        }

        public virtual RGBColor SampleF(ShadeRec shadeRec, Vector3d wi, Vector3d wo)
        {
            return new RGBColor();
        }

        public virtual RGBColor Rho(ShadeRec shadeRec,Vector3d wo)
        {
            return new RGBColor();
        }

    }
}
