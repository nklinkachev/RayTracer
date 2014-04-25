using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer.Materials
{
    public class Material
    {
        protected World world;

        public virtual RGBColor Shade(ShadeRec shadeRec)
        {
            return new RGBColor();
        }

        public virtual RGBColor AreaLightShade(ShadeRec shadeRec)
        {
            return new RGBColor();
        }

        public virtual RGBColor PathShade(ShadeRec shadeRec)
        {
            return new RGBColor();
        }
    }
}
