using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Lights
{
    class Ambient:Light
    {
        private float ls;
        private RGBColor color;

        public Ambient() : base()
        {
            ls = 1;
            color = new RGBColor(1, 1, 1);
        }

        public override Vector3d GetDirection(ShadeRec shadeRec)
        {
            return new Vector3d();
        }

        public override RGBColor L(ShadeRec shadeRec)
        {
            return color*ls;
        }
    }
}
