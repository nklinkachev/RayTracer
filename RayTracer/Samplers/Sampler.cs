using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RayTracer.Geometry;
using RayTracer.Utils;

namespace RayTracer.Samplers
{
    public class Sampler
    {
        public int NumSamples = 0;
        public int NumSets = 0;
        protected List<Point2d> samples = new List<Point2d>();
        protected List<Point2d> discSamples = new List<Point2d>();
        protected List<Point3d> hemisphereSamples = new List<Point3d>();
 
        protected List<int> shuffledIndeces = new List<int>();
        protected int skipStep = 1;
        protected int currentInd = 0;

        public Sampler(int sets, int samples, double exponent = 1)
        {
            NumSamples = samples;
            NumSets = sets;

            GenerateSamles();
            MapSamplesToDisc();
            MapSamplesToHemisphere(1);
            SetupIndeces();

        }

        public Point2d SampleUnitSquare()
        {
            if (currentInd == 0)
                skipStep = MathUtils.RandomInt(NumSets)*NumSamples; // skip the first RandomIntSets
            int ind = skipStep + shuffledIndeces[skipStep + (currentInd++%NumSamples)]; // first sample in first non-skipped set
            return samples[ind];
        }


        public Point2d SampleUnitDisc()
        {
            if (currentInd == 0)
                skipStep = MathUtils.RandomInt(NumSets) * NumSamples; // skip the first RandomIntSets
            int ind = skipStep + shuffledIndeces[skipStep + (currentInd++ % NumSamples)]; // first sample in first non-skipped set
            return discSamples[ind];
        }

        public Point3d SampleUnitHemisphere()
        {
            if (currentInd == 0)
                skipStep = MathUtils.RandomInt(NumSets) * NumSamples; // skip the first RandomIntSets
            int ind = skipStep + shuffledIndeces[skipStep + (currentInd++ % NumSamples)]; // first sample in first non-skipped set
            return hemisphereSamples[ind];
        }

        public void MapSamplesToDisc()
        {
            double r;
            double phi;
            Point2d samplePoint;
            for (int i = 0; i < samples.Count; i++)
            {
                samplePoint.X = 2*samples[i].X - 1;
                samplePoint.Y = 2*samples[i].Y - 1;

                if (samplePoint.X > -samplePoint.Y)
                {
                    if (samplePoint.X>samplePoint.Y)
                    {
                        r = samplePoint.X;
                        phi = samplePoint.Y/samplePoint.X;
                    }
                    else
                    {
                        r = samplePoint.Y;
                        phi = 2 - samplePoint.X/samplePoint.Y;
                    }
                }
                else
                {
                    if(samplePoint.X<samplePoint.Y)
                    {
                        r = -samplePoint.X;
                        phi = 4 + samplePoint.Y/samplePoint.X;
                    }
                    else
                    {
                        r = -samplePoint.Y;
                        if (samplePoint.Y != 0)
                            phi = 6 - samplePoint.X / samplePoint.Y;
                        else
                            phi = 0;
                    }
                }

                phi *= Math.PI/4.0;
                discSamples.Add(
                    new Point2d(r*Math.Cos(phi),
                                r*Math.Sin(phi)));
            }
        }

        public void MapSamplesToHemisphere(double exp)
        {
            for (int j = 0; j < NumSamples; j++)
            {
                double PI = Math.PI;
                double cos_phi = Math.Cos(2.0 * PI * samples[j].X);
                double sin_phi = Math.Sin(2.0 * PI * samples[j].X);
                double cos_theta = Math.Pow((1.0 - samples[j].Y), 1.0 / (exp + 1.0));
                double sin_theta = Math.Sqrt(1.0 - cos_theta * cos_theta);
                double pu = sin_theta * cos_phi;
                double pv = sin_theta * sin_phi;
                double pw = cos_theta;
                hemisphereSamples.Add(new Point3d(pu, pv, pw));
            }
        }

        protected virtual void GenerateSamles()
        {
        }

        protected void SetupIndeces()
        {
            List<int> indeces = new List<int>();
            for (int i = 0; i < NumSamples; i++)
            {
                indeces.Add(i);
            }
            for (int p = 0; p < NumSets; p++)
            {
                indeces.Shuffle();
                shuffledIndeces.AddRange(indeces);
            }
        }
    }
}
