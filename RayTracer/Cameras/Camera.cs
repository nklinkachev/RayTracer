using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;

namespace RayTracer.Cameras
{
    public class Camera
    {
        public Point3d Eye;
        public Point3d LookAt;
        public Vector3d Up;

        protected Vector3d u;
        protected Vector3d v;
        protected Vector3d w;
        protected double eposureTime = 1;

        public Camera()
        {
        }

        public void SetUpCamera(Vector3d eye, Vector3d lookAt, Vector3d up)
        {
            Eye = eye;
            LookAt = lookAt;
            Up = up;

            ComputeUVW();
        }

        public void SetUpCamera(Vector3d eye,Vector3d lookAt)
        {
            SetUpCamera(eye, lookAt, new Vector3d(0, 1, 0));
        }

        public void ComputeUVW()
        {
            w = Eye - LookAt;
            w.Normalize();
            u = Vector3d.Cross(Up, w);
            v = Vector3d.Cross(w, u);

            if (Eye.X == LookAt.X && Eye.Z == LookAt.Z && Eye.Y > LookAt.Y)
            { // camera looking vertically down
                u = new Vector3d(0, 0, 1);
                v = new Vector3d(1, 0, 0);
                w = new Vector3d(0, 1, 0);
            }

            if (Eye.X == LookAt.X && Eye.Z == LookAt.Z && Eye.Y < LookAt.Y)
            { // camera looking vertically up
                u = new Vector3d(1, 0, 0);
                v = new Vector3d(0, 0, 1);
                w = new Vector3d(0, -1, 0);
            }
        }

        public virtual void RenderScene(World world)
        {
            
        }

    }
}
