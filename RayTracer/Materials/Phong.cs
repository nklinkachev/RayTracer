using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.BRDF;
using RayTracer.Geometry;
using RayTracer.Samplers;

namespace RayTracer.Materials
{
    public class Phong : Material
    {
        protected Lambertian ambientBRDF=new Lambertian(new Hammersley(1,25));
        protected Lambertian diffuseBRDF = new Lambertian(new Hammersley(1, 25));

        protected GlossySpecular glossySpecularBRDF =
            new GlossySpecular(new Hammersley(1, 25), 1, 5);

        public double KA
        {
            get { return ambientBRDF.KD; }
            set { ambientBRDF.KD = value; }
        }
        public double KD
        {
            get { return diffuseBRDF.KD; }
            set { diffuseBRDF.KD = value; }
        }
        public double KS
        {
            get { return glossySpecularBRDF.KS; }
            set { glossySpecularBRDF.KS = value; }
        }

        public RGBColor Color
        {
            get { return ambientBRDF.CD; }
            set
            {
                ambientBRDF.CD = value;
                diffuseBRDF.CD = value;
                glossySpecularBRDF.CS = value;
            }
        }

        public override RGBColor Shade(ShadeRec shadeRec)
        {
            Vector3d wo = -shadeRec.Ray.Direction;
            RGBColor L = ambientBRDF.Rho(shadeRec, wo)*shadeRec.World.AmbientLight.L((shadeRec));
            for (int i = 0; i < shadeRec.World.Lights.Count; i++)
            {
                Vector3d wi = shadeRec.World.Lights[i].GetDirection(shadeRec);
                double NdotWi = Vector3d.Dot(shadeRec.Normal, wi);
                if (NdotWi>0)
                {
                    L = L + diffuseBRDF.F(shadeRec, wo, wi) +
                        glossySpecularBRDF.F(shadeRec, wo, wi)*shadeRec.World.Lights[i].L(shadeRec)*NdotWi;
                }
            }
            return L;
        }
    }
}
