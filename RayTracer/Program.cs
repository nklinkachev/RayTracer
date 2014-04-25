using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();
            world.Build();
            world.Camera.RenderScene(world);

            Console.Out.WriteLine("All done.");
        }
    }
}
