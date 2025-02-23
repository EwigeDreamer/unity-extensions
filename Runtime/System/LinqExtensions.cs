using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ED.Extensions.System
{
    public static class LinqExtensions
    {
        private static readonly Random RandomInternal = new();

        public static T Random<T>(this IEnumerable<T> source, Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            if (list.Count == 0) throw new InvalidOperationException($"Collection is empty: {nameof(source)}");
            random ??= RandomInternal;
            return list[random.Next(list.Count)];
        }

        public static T RandomOrDefault<T>(this IEnumerable<T> source, Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            if (list.Count == 0) return default;
            random ??= RandomInternal;
            return list[random.Next(list.Count)];
        }

        public static T RandomByWeight<T>(this IEnumerable<T> source, Func<T, int> getWeight, Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) throw new InvalidOperationException($"Collection is empty: {nameof(source)}");
            random ??= RandomInternal;
            var sum = 0;
            for (var i = 0; i < list.Count; ++i) sum += getWeight(list[i]);
            var rnd = random.Next(1, sum + 1);
            for (var i = 0; i < list.Count; ++i)
            {
                sum -= getWeight(list[i]);
                if (rnd > sum) return list[i];
            }
            return list[0];
        }

        public static T RandomByWeight<T>(this IEnumerable<T> source, Func<T, float> getWeight, Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) throw new InvalidOperationException($"Collection is empty: {nameof(source)}");
            random ??= RandomInternal;
            var sum = 0f;
            for (var i = 0; i < list.Count; ++i) sum += getWeight(list[i]);
            var rnd = random.RangeFloat(0f, sum);
            for (var i = 0; i < list.Count; ++i)
            {
                sum -= getWeight(list[i]);
                if (rnd > sum) return list[i];
            }
            return list[0];
        }

        public static T RandomByWeightOrDefault<T>(this IEnumerable<T> source, Func<T, int> getWeight,
            Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) return default;
            random ??= RandomInternal;
            var sum = 0;
            for (var i = 0; i < list.Count; ++i) sum += getWeight(list[i]);
            var rnd = random.Next(1, sum + 1);
            for (var i = 0; i < list.Count; ++i)
            {
                sum -= getWeight(list[i]);
                if (rnd > sum) return list[i];
            }
            return list[0];
        }

        public static T RandomByWeightOrDefault<T>(this IEnumerable<T> source, Func<T, float> getWeight,
            Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) return default;
            random ??= RandomInternal;
            var sum = 0f;
            for (var i = 0; i < list.Count; ++i) sum += getWeight(list[i]);
            var rnd = random.RangeFloat(0f, sum);
            for (var i = 0; i < list.Count; ++i)
            {
                sum -= getWeight(list[i]);
                if (rnd > sum) return list[i];
            }
            return list[0];
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count, Random random = null,
            bool allowRepeating = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            if (list.Count == 0) yield break;
            random ??= RandomInternal;
            for (var i = 0; i < count; ++i)
            {
                if (list.Count == 0) yield break;
                var index = random.Next(list.Count);
                var item = list[index];
                if (!allowRepeating) list.RemoveAt(index);
                yield return item;
            }
        }

        public static IEnumerable<T> TakeRandomByWeight<T>(this IEnumerable<T> source, Func<T, int> getWeight,
            int count, Random random = null, bool allowRepeating = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) yield break;
            random ??= RandomInternal;
            for (var i = 0; i < count; ++i)
            {
                if (list.Count == 0) yield break;
                yield return Next();
            }

            T Next()
            {
                var sum = 0;
                for (var j = 0; j < list.Count; ++j) sum += getWeight(list[j]);
                var rnd = random.Next(1, sum + 1);
                for (var j = 0; j < list.Count; ++j)
                {
                    sum -= getWeight(list[j]);
                    if (rnd > sum)
                    {
                        var item = list[j];
                        if (!allowRepeating) list.RemoveAt(j);
                        return item;
                    }
                }
                return list[0];
            }
        }

        public static IEnumerable<T> TakeRandomByWeight<T>(this IEnumerable<T> source, Func<T, float> getWeight, int count, Random random = null, bool allowRepeating = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (getWeight == null) throw new ArgumentNullException(nameof(getWeight));
            var list = source.ToList();
            if (list.Count == 0) yield break;
            random ??= RandomInternal;
            for (var i = 0; i < count; ++i)
            {
                if (list.Count == 0) yield break;
                yield return Next();
            }

            T Next()
            {
                var sum = 0f;
                for (var j = 0; j < list.Count; ++j) sum += getWeight(list[j]);
                var rnd = random.RangeFloat(0f, sum);
                for (var j = 0; j < list.Count; ++j)
                {
                    sum -= getWeight(list[j]);
                    if (rnd > sum)
                    {
                        var item = list[j];
                        if (!allowRepeating) list.RemoveAt(j);
                        return item;
                    }
                }

                return list[0];
            }
        }

        public static IEnumerable<T> SetDefault<T>(this IEnumerable<T> source, T value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            if (list.Count > 0) return list;
            return new[] { value };
        }

        public static IEnumerable<T> ForEachNonLazy<T>(this IEnumerable<T> source, Action<T> action)
        {
            return source.ForEach(action).ToList();
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            foreach (var obj in source)
            {
                action(obj);
                yield return obj;
            }
        }

        public static IEnumerable<T> ForEachNonLazy<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            return source.ForEach(action).ToList();
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var index = 0;
            foreach (var obj in source)
            {
                action(obj, index++);
                yield return obj;
            }
        }

        public static string ToString<T>(this IEnumerable<T> source, string separator)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) return string.Empty;
                var sb = new StringBuilder();
                sb.Append(e.Current);
                while (e.MoveNext())
                {
                    sb.Append(separator);
                    sb.Append(e.Current);
                }
                return sb.ToString();
            }
        }

        public static string ToString<T>(this IEnumerable<T> source, char separator)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using (var e = source.GetEnumerator())
            {
                if (!e.MoveNext()) return string.Empty;
                var sb = new StringBuilder();
                sb.Append(e.Current);
                while (e.MoveNext())
                {
                    sb.Append(separator);
                    sb.Append(e.Current);
                }
                return sb.ToString();
            }
        }

        public static IEnumerable<T> ToEnumerable<T>(this IEnumerable<T> source)
        {
            return source;
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            random ??= RandomInternal;
            var n = list.Count;
            while (n-- > 1)
            {
                var k = random.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }

        public static int FindIndex<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var index = 0;
            foreach (var item in source)
            {
                if (predicate(item)) return index;
                index++;
            }
            return -1;
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int times)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            while (times-- > 0)
                foreach (var item in list)
                    yield return item;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : defaultValue;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate, T defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (var item in source)
                if (predicate(item)) return item;
            return defaultValue;
        }

        /// <summary>
        ///     It's infinity! Use carefully!
        /// </summary>
        public static IEnumerable<T> ToInfinityLoop<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var list = source.ToList();
            while (true)
                foreach (var item in list)
                    yield return item;
        }
    }
}