using System;
using UnityEngine;
using Random = System.Random;

namespace ED.Extensions.System
{
    public static class RandomExtensions
    {
        public static float RangeFloat(this Random random, float min, float max)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return (float) random.RangeDouble(min, max);
        }
        
        public static double RangeDouble(this Random random, double min, double max)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return random.NextDouble() * (max - min) + min;
        }

        public static float RangeFloat01(this Random random)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return (float) random.NextDouble();
        }

        public static Vector2 RangeVector2(this Random random, Vector2 min, Vector2 max)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return new Vector2(
                random.RangeFloat(min.x, max.x),
                random.RangeFloat(min.y, max.y));
        }

        public static Vector3 RangeVector3(this Random random, Vector3 min, Vector3 max)
        {
            if (random == null) throw new ArgumentNullException(nameof(random));
            return new Vector3(
                random.RangeFloat(min.x, max.x),
                random.RangeFloat(min.y, max.y),
                random.RangeFloat(min.z, max.z));
        }
    }
}