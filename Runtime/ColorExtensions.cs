using UnityEngine;

namespace EwigeDreamer.Extensions.Unity
{
    public static class ColorExtensions
    {
        public static Color SetRed(this Color c, float r) => new Color(r, c.g, c.b, c.a);
        public static Color SetGreen(this Color c, float g) => new Color(c.r, g, c.b, c.a);
        public static Color SetBlue(this Color c, float b) => new Color(c.r, c.g, b, c.a);
        public static Color SetAlpha(this Color c, float a) => new Color(c.r, c.g, c.b, a);
        
        public static Color32 SetRed(this Color32 c, byte r) => new Color32(r, c.g, c.b, c.a);
        public static Color32 SetGreen(this Color32 c, byte g) => new Color32(c.r, g, c.b, c.a);
        public static Color32 SetBlue(this Color32 c, byte b) => new Color32(c.r, c.g, b, c.a);
        public static Color32 SetAlpha(this Color32 c, byte a) => new Color32(c.r, c.g, c.b, a);
    }
}