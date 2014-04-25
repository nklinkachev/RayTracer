using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Lights
{
    public class Light
    {
        protected bool shadows;
        public virtual Vector3d GetDirection(ShadeRec shadeRec)
        {
            return new Vector3d();
        }

        public virtual RGBColor L (ShadeRec shadeRec)
        {
            return new RGBColor();
        }


    }
}
