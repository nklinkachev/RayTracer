using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace RayTracer.Cameras
{
    public class PinholeCamera : Camera
    {
        private double distToViewPlane;
        private double zoom;

        public PinholeCamera(double distToViewPlane, double zoom = 1)
        {
            this.distToViewPlane = distToViewPlane;
            this.zoom = zoom;
        }

        public Vector3d GetRayDirection(Point2d point)
        {
            Vector3d dir = point.X*u + point.Y*v - distToViewPlane*w;
            dir.Normalize();
            return dir;
        }

        public override void RenderScene(World world)
        {
            //Stopwatch sw = Stopwatch.StartNew();
            //while (true)
            //{
            //    sw.Restart();
            RGBColor L = new RGBColor();

            ViewPlane viewPlane = (ViewPlane) world.ViewPlane.Clone();

            Ray ray = new Ray();
            int depth = 0;
            Point2d samplePoint = new Point2d();
            Point2d pixelPoint = new Point2d();

            viewPlane.PixelSize /= zoom;
            ray.Origin = Eye;

            Bitmap bitmap = new Bitmap(viewPlane.HRes, viewPlane.VRes);

            for (int r = 0; r < viewPlane.VRes; r++)
            {
                for (int c = 0; c < viewPlane.HRes; c++)
                {
                    L = new RGBColor(0, 0, 0);
                    for (int i = 0; i < viewPlane.Sampler.NumSamples; i++)
                    {
                        samplePoint = viewPlane.Sampler.SampleUnitSquare();

                        pixelPoint.X = viewPlane.PixelSize*(c - 0.5*viewPlane.HRes + samplePoint.X);
                        pixelPoint.Y = viewPlane.PixelSize*(r - 0.5*viewPlane.VRes + samplePoint.Y);

                        ray.Direction = GetRayDirection(pixelPoint);
                        L += world.Tracer.TraceRay(ray, depth);
                    }

                    L /= viewPlane.Sampler.NumSamples;
                    L *= eposureTime;

                    L.MaxToOne();
                    bitmap.SetPixel(c, viewPlane.VRes - r - 1,
                                    Color.FromArgb((int) (L.R*255),
                                                   (int) (L.G*255),
                                                   (int) (L.B*255)));

                }
                Console.Out.WriteLine("r = {0}", r);
            }

            bitmap.Save("TracedImage.bmp", ImageFormat.Bmp);
            //Console.Out.WriteLine("sw = {0}", sw.ElapsedMilliseconds);
        }
    }

    //}
}