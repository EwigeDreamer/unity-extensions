using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

namespace ED.Extensions.Unity
{
    public static class SceneExtensions
    {
        public static T[] FindObjectsOfType<T>(this Scene scene) where T : UnityEngine.Object => scene.FindObjectsOfType<T>(false);
        
        public static T[] FindObjectsOfType<T>(this Scene scene, bool includeInactive) where T : UnityEngine.Object
        {
            using var h = ListPool<T>.Get(out var results);
            scene.FindObjectsOfType(includeInactive, results);
            return results.ToArray();
        }
        
        public static void FindObjectsOfType<T>(this Scene scene, List<T> results) where T : UnityEngine.Object => FindObjectsOfType<T>(scene, false, results);
        
        public static void FindObjectsOfType<T>(this Scene scene, bool includeInactive, List<T> results) where T : UnityEngine.Object
        {
            if (results == null) throw new ArgumentNullException(nameof(results));
            results.Clear();
            using var h1 = ListPool<GameObject>.Get(out var rootObjects);
            scene.GetRootGameObjects(rootObjects);
            using var h2 = ListPool<T>.Get(out var components);
            foreach (var obj in rootObjects)
            {
                obj.GetComponentsInChildren(includeInactive, components);
                results.AddRange(components);
            }
        }
    }
}