using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Utils;

namespace RayTracer.Samplers
{
    class Jittered: Sampler
    {
        public Jittered(int sets,int samples) :base(sets,samples){}

        protected override void GenerateSamles()
        {
            int N = (int) Math.Sqrt(NumSamples);
            NumSamples = N*N;

            for (int p = 0; p < NumSets; p++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        double rx, ry;
                        if (NumSamples==1)
                        {
                            rx = 0.5;
                            ry = 0.5;
                        }
                        else
                        {
                            rx = MathUtils.RandomDouble();
                            ry = MathUtils.RandomDouble();
                        }
                        Point2d sp = new Point2d((j + rx)/N, (i + ry)/N);
                        samples.Add(sp);
                    }
                }
            }

        }

    }
}
