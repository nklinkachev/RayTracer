using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Materials;

namespace RayTracer.Objects
{
    public class GeometricObject
    {
        public Material Material;

        public virtual bool Intersect(Ray ray, out double tmin, ShadeRec shadeRec)
        {
            tmin = 0;
            return false;
        }

        //Only for chapter 3
        public RGBColor Color;

    }
}
