﻿using System;
using System.Collections.Generic;
using System.Text;
using RayTracer.Utils;

namespace RayTracer
{
    public static class ExtensionMethods
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = MathUtils.RandomInt(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
