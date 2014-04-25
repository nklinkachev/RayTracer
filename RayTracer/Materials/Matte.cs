using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.BRDF;
using RayTracer.Samplers;
using RayTracer.Geometry;

namespace RayTracer.Materials
{
    public class Matte : Material
    {

        private Lambertian ambientBRDF;
        private Lambertian diffuseBRDF;
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

        public RGBColor Color
        {
            get { return ambientBRDF.CD; }
            set
            {
                ambientBRDF.CD = value;
                diffuseBRDF.CD = value;
            }
        }


        public Matte()
        {
            //TODO: hardcoded 25 samples per pixel, this should be settable from the outside
            ambientBRDF = new Lambertian(new Hammersley(1, 25));
            diffuseBRDF = new Lambertian(new Hammersley(1, 25));
        }

        public override RGBColor Shade(ShadeRec shadeRec)
        {
            Vector3d wo = -shadeRec.Ray.Direction;
            RGBColor L = ambientBRDF.Rho(shadeRec, wo)*shadeRec.World.AmbientLight.L(shadeRec);

            for(int i=0;i<shadeRec.World.Lights.Count;i++)
            {
                Vector3d wi = shadeRec.World.Lights[i].GetDirection(shadeRec);
                double NdotWI = Vector3d.Dot(shadeRec.Normal, wi);
                
                if (NdotWI>0)
                {
                    L += diffuseBRDF.F(shadeRec, wo, wi)*shadeRec.World.Lights[i].L(shadeRec)*NdotWI;
                }
            }

            return L;
        }
    }
}