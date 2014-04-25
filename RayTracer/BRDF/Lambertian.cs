using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Samplers;

namespace RayTracer.BRDF
{
    public class Lambertian : BRDF
    {
        public double KD;
        public RGBColor CD;
        

        public Lambertian(Sampler sampler) : base(sampler){}

        public override RGBColor F(ShadeRec shadeRec, Geometry.Vector3d wi, Geometry.Vector3d wo)
        {
            return CD*KD*1/Math.PI;
        }

        public override RGBColor Rho(ShadeRec shadeRec, Geometry.Vector3d wo)
        {
            return CD*KD;
        }
    }
}
