using System;

namespace EwigeDreamer.Extensions.Unity
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns real null if native object of this cs-wrapper is not exist
        /// </summary>
        public static T ToActual<T>(this T obj) where T : UnityEngine.Object
        {
            return obj ? obj : null;
        }
        
        /// <summary>
        /// Returns a disposable wrapper of the <see cref="UnityEngine.Object"/>.
        /// If the wrapper is disposed, the <see cref="UnityEngine.Object"/> will be destroyed.
        /// </summary>
        /// <param name="source">Object to destroy</param>
        /// <returns>Disposable wrapper</returns>
        public static IDisposable ToDisposable<T>(this T source) where T : UnityEngine.Object
        {
            return new DisposableUnityObject(source);
        }
        
        /// <summary>
        /// Returns a disposable wrapper of the <see cref="UnityEngine.Object"/>.
        /// If the wrapper is disposed, the <see cref="UnityEngine.Object"/> will be immediately destroyed.
        /// </summary>
        /// <param name="source">Object to destroy immediate</param>
        /// <returns>Disposable wrapper</returns>
        public static IDisposable ToDisposableImmediate<T>(this T source) where T : UnityEngine.Object
        {
            return new DisposableUnityObjectImmediate(source);
        }
    }

    internal class DisposableUnityObject : IDisposable
    {
        private UnityEngine.Object _source;
        public DisposableUnityObject(UnityEngine.Object source) => _source = source;
        public void Dispose()
        {
            if (_source != null)
            {
                UnityEngine.Object.Destroy(_source);
                _source = null;
            }
        }
    }

    internal class DisposableUnityObjectImmediate : IDisposable
    {
        private UnityEngine.Object _source;
        public DisposableUnityObjectImmediate(UnityEngine.Object source) => _source = source;
        public void Dispose()
        {
            if (_source != null)
            {
                UnityEngine.Object.DestroyImmediate(_source);
                _source = null;
            }
        }
    }
}