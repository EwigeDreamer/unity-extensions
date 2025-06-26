using System.Text;
using UnityEngine;

namespace ED.Extensions.Unity
{
    public static class GameObjectExtensions
    {
        private static readonly StringBuilder Sb = new();
        
        public static string GetFullName(this GameObject gameObject, char delimeter = '/')
        {
            lock (Sb)
            {
                Sb.Clear();
                GetFullnameRecursively(gameObject.transform, Sb, delimeter);
                return Sb.ToString();
            }
        }

        private static void GetFullnameRecursively(Transform tr, StringBuilder sb, char delimeter)
        {
            if (tr == null) return;
            GetFullnameRecursively(tr.parent, sb, delimeter);
            if (sb.Length > 0) 
                sb.Append(delimeter);
            sb.Append(tr.name);
        }
    }
}