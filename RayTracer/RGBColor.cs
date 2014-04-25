using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracer
{
    public class RGBColor
    {
        public double R;
        public double G;
        public double B;

        public RGBColor()
        {
        }

        public RGBColor(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void MaxToOne()
        {
            double d = Math.Max(R, Math.Max(G, B));
            if (d > 1)
            {
                R /= d;
                G /= d;
                B /= d;
            }
        }

        public static RGBColor operator +(RGBColor c1, RGBColor c2)
        {
            return new RGBColor(c1.R + c2.R,
                                c1.G + c2.G,
                                c1.B + c2.B);
        }

        public static RGBColor operator/(RGBColor col, double d)
        {
            return new RGBColor(col.R / d, col.G / d, col.B / d);
        }

        public static RGBColor operator *(RGBColor col, double d)
        {
            return new RGBColor(col.R*d, col.G*d, col.B*d);
        }

        public static RGBColor operator * (RGBColor col1, RGBColor col2)
        {
            return new RGBColor(col1.R*col2.R,
                                col1.G*col2.G,
                                col1.B*col2.B);
        }
    }
}
