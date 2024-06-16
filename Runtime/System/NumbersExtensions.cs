using System;
using UnityEngine;

namespace ED.Extensions.System
{
    public static class NumbersExtensions
    {
        public static float Floor(this float v) => Mathf.Floor(v);
        public static float Ceil(this float v) => Mathf.Ceil(v);
        public static float Round(this float v) => Mathf.Round(v);
        
        public static double Floor(this double v) => Math.Floor(v);
        public static double Ceil(this double v) => Math.Ceiling(v);
        public static double Round(this double v) => Math.Round(v);
        
        public static int FloorToInt(this float v) => Mathf.FloorToInt(v);
        public static int CeilToInt(this float v) => Mathf.CeilToInt(v);
        public static int RoundToInt(this float v) => Mathf.RoundToInt(v);
        
        public static int FloorToInt(this double v) => (int)Math.Floor(v);
        public static int CeilToInt(this double v) => (int)Math.Ceiling(v);
        public static int RoundToInt(this double v) => (int)Math.Round(v);

        public static float Min(this float a, float b) => Math.Min(a, b);
        public static float Max(this float a, float b) => Math.Max(a, b);
        public static double Min(this double a, double b) => Math.Min(a, b);
        public static double Max(this double a, double b) => Math.Max(a, b);
        public static int Min(this int a, int b) => Math.Min(a, b);
        public static int Max(this int a, int b) => Math.Max(a, b);
        
        public static float Abs(this float a) => Math.Abs(a);
        public static double Abs(this double a) => Math.Abs(a);
        public static int Abs(this int a) => Math.Abs(a);
        
        public static double Clamp(this double v, double min, double max) => Math.Clamp(v, min, max);
        public static float Clamp(this float v, float min, float max) => Mathf.Clamp(v, min, max);
        public static float Clamp01(this float v) => Mathf.Clamp01(v);
        public static int Clamp(this int v, int min, int max) => Mathf.Clamp(v, min, max);
        
        
    }
}