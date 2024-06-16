using UnityEngine;

namespace ED.Extensions.Unity
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Returns an existing component. If it doesn't exist, creates a new one.
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T AddMissingComponent<T>(this GameObject source) where T : Component
        {
            var c = source.GetComponent<T>();
            return c != null ? c : source.AddComponent<T>();
        }

        /// <summary>
        /// Returns an existing component. If it doesn't exist, creates a new one.
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T AddMissingComponent<T>(this Component source) where T : Component
        {
            var c = source.GetComponent<T>();
            return c != null ? c : source.gameObject.AddComponent<T>();
        }
    }
}