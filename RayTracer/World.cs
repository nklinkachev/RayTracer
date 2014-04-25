using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using RayTracer.Geometry;
using RayTracer.Objects;
using RayTracer.Tracers;
using RayTracer.Utils;
using System.Diagnostics;
using RayTracer.Samplers;
using RayTracer.Cameras;
using RayTracer.Lights;

namespace RayTracer
{
    public class World
    {
        public ViewPlane ViewPlane=new ViewPlane();
        public RGBColor BackgroundColor=new RGBColor();
        //Chapter 3 only
        public Sphere Sphere=new Sphere();
        public List<GeometricObject> Objects = new List<GeometricObject>();
        public Light AmbientLight;
        public List<Light> Lights = new List<Light>(); 
        public Tracer Tracer;
        public Camera Camera;

        public World()
        {
            Camera = null;
            BackgroundColor = new RGBColor();
            Tracer = null;
            AmbientLight=new Ambient();
        }

        public void Build()
        {
            BuildFunctions.Build14_21(this);
        }

        public void AddObject(GeometricObject geometricObject)
        {
            Objects.Add(geometricObject);
        }

        public void AddLight(Light light)
        {
            Lights.Add(light);
        }

        public ShadeRec IntersectAllObjects(Ray ray)
        {
            ShadeRec shadeRec = new ShadeRec(this);
            double t;
            Normal normal = new Normal();
            Point3d localHitPoint=new Point3d();

            double tmin = double.PositiveInfinity;
            
            for (int i = 0;i<Objects.Count;i++)
            {
                if (Objects[i].Intersect(ray,out t,shadeRec) && t < tmin)
                {
                    tmin = t;
                    shadeRec.HasHitObject = true;
                    shadeRec.Material = Objects[i].Material;
                    shadeRec.Hitpoint = ray.Origin + t*ray.Direction;
                    normal = shadeRec.Normal;
                    localHitPoint = shadeRec.LocalHitPoint;
                }
            }

            if (shadeRec.HasHitObject)
            {
                shadeRec.T = tmin;
                shadeRec.Normal = normal;
                shadeRec.LocalHitPoint = localHitPoint;
                shadeRec.Hitpoint = ray.Origin + tmin*ray.Direction;

            }

            return shadeRec;
        }
        
        public void OpenWindow(int hres, int vres)
        {
            throw new NotImplementedException();
        }

        public void DisplayPixel(int row, int col, RGBColor color)
        {
            throw new NotImplementedException();
        }
    }
}
