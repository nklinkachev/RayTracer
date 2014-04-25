using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Lights
{
    public class Point : Light
    {
        public float LightScale = 1;
        public RGBColor Color = new RGBColor(1, 1, 1);
        public Vector3d Location;

        public override Vector3d GetDirection(ShadeRec shadeRec)
        {
            Vector3d dir = Location - (Vector3d) shadeRec.Hitpoint;
            dir.Normalize();
            return dir;
        }

        public override RGBColor L(ShadeRec shadeRec)
        {
            return Color*LightScale;
        }

    }
}
