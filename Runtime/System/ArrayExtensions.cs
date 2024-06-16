using System;
using System.Collections.Generic;

namespace ED.Extensions.System
{
    public static class ArrayExtensions
    {
        public static T[] Fill<T>(this T[] source, T value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            Array.Fill(source, value);
            return source;
        }

        public static T[,] Fill<T>(this T[,] source, T value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            for (var i = 0; i < source.GetLength(0); ++i)
            for (var j = 0; j < source.GetLength(1); ++j)
                source[i, j] = value;
            return source;
        }

        public static void CopyTo<T>(this T[] source, T[] destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var count = Math.Min(source.Length, destination.Length);
            for (var i = 0; i < count; ++i)
                destination[i] = source[i];
        }

        public static void CopyTo<T>(this T[,] source, T[,] destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));
            var width = Math.Min(source.Width(), destination.Width());
            var height = Math.Min(source.Height(), destination.Height());
            for (var i = 0; i < height; ++i)
            for (var j = 0; j < width; ++j)
                destination[i, j] = source[i, j];
        }

        public static TTarget[,] Convert<TSource, TTarget>(this TSource[,] source, Func<TSource, TTarget> select)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (select == null) throw new ArgumentNullException(nameof(select));
            var width = source.Width();
            var height = source.Height();
            var result = new TTarget[height, width];
            for (var i = 0; i < height; ++i)
            for (var j = 0; j < width; ++j)
                result[i, j] = select(source[i, j]);
            return result;
        }

        public static int Width<T>(this T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.GetLength(1);
        }

        public static int Height<T>(this T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.GetLength(0);
        }

        public static (int i, int j) IndexesOf<T>(this T[,] source, T item)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return IndexesOf(source, item, EqualityComparer<T>.Default);
        }

        public static (int i, int j) IndexesOf<T>(this T[,] source, T item, EqualityComparer<T> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            comparer ??= EqualityComparer<T>.Default;
            for (var i = 0; i < source.GetLength(0); ++i)
            for (var j = 0; j < source.GetLength(1); ++j)
                if (comparer.Equals(source[i, j], item))
                    return (i, j);
            return (-1, -1);
        }

        /// <summary>
        ///     0 Dimension
        /// </summary>
        public static IEnumerable<T> SelectRow<T>(this T[,] map, int row)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            for (var i = 0; i < map.GetLength(1); ++i) yield return map[row, i];
        }

        /// <summary>
        ///     1 Dimension
        /// </summary>
        public static IEnumerable<T> SelectColumn<T>(this T[,] map, int col)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            for (var i = 0; i < map.GetLength(0); ++i) yield return map[i, col];
        }

        /// <summary>
        ///     0 Dimension
        /// </summary>
        public static IEnumerable<IEnumerable<T>> GetRows<T>(this T[,] map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            for (var i = 0; i < map.GetLength(0); ++i) yield return map.SelectRow(i);
        }

        /// <summary>
        ///     1 Dimension
        /// </summary>
        public static IEnumerable<IEnumerable<T>> GetColumns<T>(this T[,] map)
        {
            if (map == null) throw new ArgumentNullException(nameof(map));
            for (var i = 0; i < map.GetLength(1); ++i) yield return map.SelectColumn(i);
        }

        public static IEnumerable<T2> Select<T1, T2>(this T1[,] source, Func<T1, T2> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            for (var i = 0; i < source.GetLength(0); ++i)
            for (var j = 0; j < source.GetLength(1); ++j)
                yield return selector(source[i, j]);
        }

        public static IEnumerable<T2> Select<T1, T2>(this T1[,] source, Func<T1, int, int, T2> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            for (var i = 0; i < source.GetLength(0); ++i)
            for (var j = 0; j < source.GetLength(1); ++j)
                yield return selector(source[i, j], i, j);
        }

        public static IEnumerable<T> ToEnumerable<T>(this T[,] source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            for (var i = 0; i < source.GetLength(0); ++i)
            for (var j = 0; j < source.GetLength(1); ++j)
                yield return source[i, j];
        }
    }
}