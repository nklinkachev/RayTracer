using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Samplers;

namespace RayTracer
{
    public class ViewPlane : ICloneable
    {
        public int VRes;
        public int HRes;
        public double PixelSize;
        //public int SamplesCount = 1; // no antialliasing by default

        private double gamma;
        public double Gamma
        {
            get { return gamma; }
            set
            {
                gamma = value;
                InvGamma = 1/gamma;
            }
        }
        public double InvGamma;

        public Sampler Sampler;

        public object Clone()
        {
            ViewPlane vp = new ViewPlane();
            vp.VRes = VRes;
            vp.HRes = HRes;
            vp.PixelSize = PixelSize;
            vp.gamma = gamma;
            vp.InvGamma = InvGamma;
            vp.Sampler = Sampler;

            return vp;
        }
    }
}
