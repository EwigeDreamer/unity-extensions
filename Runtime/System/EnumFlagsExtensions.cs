using System;
using System.Collections.Generic;

namespace EwigeDreamer.Extensions.System
{
    public static class EnumFlagsExtensions
    {
        public static IEnumerable<T> GetFlags<T>() where T : Enum
        {
            if (!typeof(T).IsDefined(typeof(FlagsAttribute), false))
                throw new InvalidOperationException($"{typeof(T).FullName} has no {nameof(FlagsAttribute)}");
            var items = (T[])Enum.GetValues(typeof(T));
            foreach (var item in items) {
                if (IsEqual(item, -1)) continue;
                if (IsEqual(item, 0)) continue;
                yield return item;
            }
        }

        public static IEnumerable<T> GetFlags<T>(this T source) where T : Enum {
            if (!typeof(T).IsDefined(typeof(FlagsAttribute), false))
                throw new InvalidOperationException($"{typeof(T).FullName} has no {nameof(FlagsAttribute)}");
            var items = (T[])Enum.GetValues(typeof(T));
            foreach (var item in items) {
                if (IsEqual(item, -1)) continue;
                if (IsEqual(item, 0)) continue;
                if (source.HasFlag(item)) yield return item;
            }
        }

        private static bool IsEqual<T>(T en, int val) where T : Enum {
            var type = Enum.GetUnderlyingType(typeof(T));
            if (type == typeof(int)) return (int)(object)en == (int)val;
            if (type == typeof(byte)) return (byte)(object)en == (byte)val;
            if (type == typeof(short)) return (short)(object)en == (short)val;
            if (type == typeof(sbyte)) return (sbyte)(object)en == (sbyte)val;
            if (type == typeof(ushort)) return (ushort)(object)en == (ushort)val;
            if (type == typeof(uint)) return (uint)(object)en == (uint)val;
            if (type == typeof(long)) return (long)(object)en == (long)val;
            if (type == typeof(ulong)) return (ulong)(object)en == (ulong)val;
            if (type == typeof(nint)) return (nint)(object)en == (nint)val;
            if (type == typeof(nuint)) return (nuint)(object)en == (nuint)val;
            throw new InvalidOperationException($"Underlying type of enum {typeof(T).FullName} is not integer!");
        }
    }
}