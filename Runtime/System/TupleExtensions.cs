using System;

namespace ED.Extensions.System
{
    public static class TupleExtensions
    {
        public static float Min(this (float a, float b) t) => Math.Min(t.a, t.b);
        public static float Min(this (float a, float b, float c) t) => Math.Min(Math.Min(t.a, t.b), t.c);
        
        public static float Max(this (float a, float b) t) => Math.Max(t.a, t.b);
        public static float Max(this (float a, float b, float c) t) => Math.Max(Math.Max(t.a, t.b), t.c);
        
        public static float Average(this (float a, float b) t) => (t.a + t.b) / 2f;
        public static float Average(this (float a, float b, float c) t) => (t.a + t.b + t.c) / 3f;
    }
}