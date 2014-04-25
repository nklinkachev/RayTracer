using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer.Utils
{
    public static class MathUtils
    {
        private static Random rand = new Random(0);

        public static double RandomDouble()
        {
            return rand.NextDouble();
        }

        public static double RandomDouble(double maxVal)
        {
            return rand.NextDouble()*maxVal;
        }

        public static int RandomInt()
        {
            return rand.Next();
        }

        public static int RandomInt(int maxVal)
        {
            return rand.Next(maxVal);
        }

        public static double BinaryRadicalInverse(int n)
        {
            double sum = 0;
            double coef = 0.5;
            while (n>0)
            {
                sum += (n & 0x1)*coef;
                n >>= 1;
                coef *= 0.5;
            }
            return sum;
        }
    }
}
