using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Samplers;
using RayTracer.Geometry;

namespace RayTracer.BRDF
{
    public class GlossySpecular : BRDF
    {
        public double KS = 1;
        public double Exp = 0;
        public RGBColor CS = new RGBColor();


        public GlossySpecular(Sampler sampler,double ks=1,double exp=0) : base(sampler)
        {
            KS = ks;
            Exp = exp;
            sampler.MapSamplesToHemisphere(exp);
        }

        public override RGBColor F(ShadeRec shadeRec, Vector3d wi, Vector3d wo)
        {
            RGBColor L = new RGBColor();
            double NdotWi = Vector3d.Dot(shadeRec.Normal, wi);
            Vector3d r = (-wi + (Vector3d)shadeRec.Normal * NdotWi * 2);
            double RdotWo = Vector3d.Dot(r, wo);
            if (RdotWo > 0)
            {
                L = CS*KS*Math.Pow(RdotWo, Exp);
            }
            return L;
        }
    }
}
