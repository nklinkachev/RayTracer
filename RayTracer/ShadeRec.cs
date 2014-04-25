using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Materials;

namespace RayTracer
{
    public class ShadeRec
    {
        public bool HasHitObject;
        public Material Material;
        public Point3d Hitpoint;
        public Point3d LocalHitPoint;
        public Normal Normal;
        public Ray Ray;
        public int Depth;
        public Vector3d Direction;
        public double T;

        
        //Chapter 3 only
        public RGBColor Color;

        public World World;

        public ShadeRec(World world)
        {
            HasHitObject = false;
            Hitpoint = new Point3d();
            Normal = new Normal();
            LocalHitPoint = new Point3d();
            Ray=new Ray();
            Depth = 0;
            Direction = new Vector3d();
            T = 0;

            //Chapter 3 only
            Color = new RGBColor(0, 0, 0); //Black

            World = world;
        }
    }
}
