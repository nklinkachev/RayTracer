using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Cameras;
using RayTracer.Geometry;
using RayTracer.Lights;
using RayTracer.Objects;
using RayTracer.Samplers;
using RayTracer.Tracers;
using RayTracer.Materials;

namespace RayTracer
{
    public static class BuildFunctions
    {
        public static void BuildSingleSphere(World world)
        {
            world.ViewPlane = new ViewPlane();
            world.ViewPlane.HRes = 200;
            world.ViewPlane.VRes = 200;
            world.ViewPlane.PixelSize = 1;
            world.ViewPlane.Gamma = 1;

            world.Camera=new PinholeCamera(50);
            var eye = new Vector3d(0, 0, 100);
            var lookAt = new Vector3d(0, 0, 0);
            world.Camera.SetUpCamera(eye, lookAt);
            //world.ViewPlane.SamplesCount = 64;
            world.ViewPlane.Sampler = new Hammersley(1, 25);
            world.BackgroundColor = new RGBColor(0, 0, 0);
            world.Tracer = new Normals(world);

            world.Sphere = new Sphere(new Point3d(0, 0, 0), 85);
            world.Sphere.Color = new RGBColor(1, 0, 0);
            world.AddObject(world.Sphere);
        }

        public static void BuildMultipleObjects(World world)
        {
            world.ViewPlane = new ViewPlane();
            world.ViewPlane.HRes = 200;
            world.ViewPlane.VRes = 200;
            world.ViewPlane.PixelSize = 1;
            world.ViewPlane.Gamma = 1;
            //world.ViewPlane.SamplesCount = 25;
            world.ViewPlane.Sampler = new Jittered(1, 1);
            world.BackgroundColor = new RGBColor(0, 0, 0);
            world.Tracer = new MultipleObjects(world);


            Sphere sphere = new Sphere(new Point3d(0, -25, 0), 80);
            sphere.Color = new RGBColor(1, 0, 0);
            world.AddObject(sphere);

            sphere = new Sphere(new Point3d(0, 30, 0), 60);
            sphere.Color = new RGBColor(1, 1, 0);
            world.AddObject(sphere);

            Plane plane = new Plane(new Point3d(0, 0, 0),
                                    new Normal(0, 1, 1));
            plane.Color = new RGBColor(0, 0.3f, 0);
            world.AddObject(plane);
        }

        public static void Build14_21(World world)
        {
            world.ViewPlane = new ViewPlane();
            world.ViewPlane.HRes = 400;
            world.ViewPlane.VRes = 400;
            world.ViewPlane.PixelSize = 1;
            world.ViewPlane.Gamma = 1;
            //world.ViewPlane.SamplesCount = 25;
            world.ViewPlane.Sampler = new Hammersley(1, 16);
            world.BackgroundColor = new RGBColor(0, 0, 0);
            world.Tracer = new RayCast(world);
            world.AmbientLight=new Ambient();

            PinholeCamera pinholeCamera = new PinholeCamera(850);
            
            pinholeCamera.SetUpCamera(
                new Vector3d(0, 0, 500),
                new Vector3d(5, 0, 0));
            world.Camera = pinholeCamera;

            Point pointLight = new Point();
            pointLight.Location = new Vector3d(100, 50, 150);
            pointLight.LightScale = 3;
            world.AddLight(pointLight);

            //Sphere 1
            Matte matte1 = new Matte();
            matte1.KA = 0.25;
            matte1.KD = 0.65;
            matte1.Color = new RGBColor(1, 1, 0);

            Sphere sphere1 = new Sphere(new Point3d(10,5,0), 27);
            sphere1.Material = matte1;
            world.AddObject(sphere1);

            //Sphere 2
            Matte matte2 = new Matte();
            matte2.KA = 0.15;
            matte2.KD = 0.85;
            matte2.Color = new RGBColor(0.71, 0.40, 0.16);

            Sphere sphere2 = new Sphere(new Point3d(-25, 10, -35), 27);
            sphere2.Material = matte2;
            world.AddObject(sphere2);

            //Plane
            Matte matte3 = new Matte();
            matte3.KA = 0.15;
            matte3.KD = 0.5;
            matte3.Color = new RGBColor(0, 0.4, 0.2);

            Phong phong = new Phong();
            phong.KA = 0;
            phong.KD = 0;
            phong.KS = 1;
            phong.Color = new RGBColor(0, 0.4, 0.2);

            Vector3d normal = new Vector3d(0, 1, 0);
            normal.Normalize();

            Plane plane = new Plane(new Point3d(0, -10, 0),
                                    normal);
            plane.Material = phong;
            world.AddObject(plane);


        }
    }
}
