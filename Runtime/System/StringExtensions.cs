using UnityEngine;

namespace EwigeDreamer.Extensions.System
{
    public static class StringExtensions
    {
        public static string Bold(this string text) => $"<b>{text}</b>";
        public static string Italic(this string text) => $"<i>{text}</i>";
        public static string Color(this string text, Color color) => $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{text}</color>";
        public static string Color(this string text, string hex) => $"<color=#{hex}>{text}</color>";
        public static string Size(this string text, int size) => $"<size={size}>{text}</size>";
    }
}