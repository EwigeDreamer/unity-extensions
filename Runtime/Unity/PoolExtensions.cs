using UnityEngine.Pool;

namespace ED.Extensions.Unity
{
    public static class PoolExtensions
    {
        public static void Prewarm<T>(this ObjectPool<T> pool, int count) where T : class
        {
            var list = ListPool<T>.Get();
            for (int i = 0; i < count; ++i)
                list.Add(pool.Get());
            for (int i = 0; i < count; ++i)
                pool.Release(list[i]);
            ListPool<T>.Release(list);
        }
    }
}