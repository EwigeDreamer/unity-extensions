using System;

namespace EwigeDreamer.Extensions.Unity
{
    public static class AudioMixerExtensions
    {
        /// <summary>
        /// Convert linear volume do decibels
        /// </summary>
        /// <param name="linear"></param>
        /// <returns></returns>
        public static float LinearToDecibel(this float linear) {
            if (linear < 1e-5f) return -144.0f;
            return 20.0f * (float)Math.Log10(linear);
        }

        /// <summary>
        /// Convert decibels to linear volume
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static float DecibelToLinear(this float db) {
            return (float) Math.Pow(10.0f, db / 20.0f);
        }
    }
}