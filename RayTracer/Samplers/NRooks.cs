using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Utils;

namespace RayTracer.Samplers
{
    public class NRooks : Sampler
    {
        public NRooks(int sets,int samples) : base(sets,samples)
        {
        }

        protected override void GenerateSamles()
        {
            for (int p = 0; p < NumSets; p++)
            {
                for (int i = 0; i < NumSamples; i++)
                {
                    Point2d samplePoint;
                    samplePoint.X = (i + MathUtils.RandomDouble())/NumSamples;
                    samplePoint.Y = (i + MathUtils.RandomDouble())/NumSamples;
                    samples.Add(samplePoint);
                }
            }
            ShuffleSamplesInSets();
        }

        private void ShuffleSamplesInSets()
        {
            ShuffleXCoords();
            ShuffleYCoords();
        }

        private void ShuffleXCoords()
        {
            for (int p = 0; p < NumSets; p++)
            {
                for (int i = 0; i < NumSamples-1; i++)
                {
                    int target = MathUtils.RandomInt()%NumSamples + p*NumSamples;
                    int currendInd = i + p*NumSamples + 1;
                    double temp = samples[currendInd].X;
                    samples[currendInd] = new Point2d(samples[target].X, samples[currendInd].Y);
                    samples[target] = new Point2d(temp, samples[target].Y);
                }
            }
        }

        private void ShuffleYCoords()
        {
            for (int p = 0; p < NumSets; p++)
            {
                for (int i = 0; i < NumSamples - 1; i++)
                {
                    int target = MathUtils.RandomInt()%NumSamples + p * NumSamples;
                    int currendInd = i + p * NumSamples + 1;
                    double temp = samples[currendInd].Y;
                    samples[currendInd] = new Point2d(samples[currendInd].X, samples[target].Y);
                    samples[target] = new Point2d(samples[target].X, temp);
                }
            }
        }
    }
}
