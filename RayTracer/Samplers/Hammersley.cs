using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Utils;

namespace RayTracer.Samplers
{
    public class Hammersley : Sampler
    {
        public Hammersley(int sets, int samples) : base(sets, samples)
        {
        }

        protected override void GenerateSamles()
        {
            int N = (int) Math.Sqrt(NumSamples);
            NumSamples = N*N;

            for (int p = 0; p < NumSets; p++)
            {
                for (int i = 0; i < NumSamples; i++)
                {
                    samples.Add(
                        new Point2d(i/(double) NumSamples,
                                    MathUtils.BinaryRadicalInverse(i)));
                }
            }
        }
    }
}