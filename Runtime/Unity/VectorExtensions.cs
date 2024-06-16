using System;
using UnityEngine;

namespace ED.Extensions.Unity
{
    public static class VectorExtensions
    {
        public static Vector2 ToV2_xz(this Vector3 v) => new Vector2(v.x, v.z);
        public static Vector2 ToV2_xy(this Vector3 v) => new Vector2(v.x, v.y);
        public static Vector2 ToV2_zy(this Vector3 v) => new Vector2(v.z, v.y);
        public static Vector2 ToV2_yx(this Vector3 v) => new Vector2(v.y, v.x);

        public static Vector3 ToV3_0yz(this Vector3 v) { v.x = 0f; return v; }
        public static Vector3 ToV3_x0z(this Vector3 v) { v.y = 0f; return v; }
        public static Vector3 ToV3_xy0(this Vector3 v) { v.z = 0f; return v; }
        public static Vector3 ToV3_xz0(this Vector3 v) { v.y = v.z; v.z = 0f; return v; }

        public static Vector3 ToV3_xy0(this Vector2 v) => new Vector3(v.x, v.y, 0f);
        public static Vector3 ToV3_x0y(this Vector2 v) => new Vector3(v.x, 0f, v.y);
        public static Vector3 ToV3_0yx(this Vector2 v) => new Vector3(0f, v.y, v.x);
        public static Vector3 ToV3_yx0(this Vector2 v) => new Vector3(v.y, v.x, 0f);

        public static Vector3 Rotate(this Vector3 v, Quaternion rot) => rot * v;

        public static Vector2 SetX(this Vector2 v, float x) { v.x = x; return v; }
        public static Vector2 SetY(this Vector2 v, float y) { v.y = y; return v; }

        public static Vector2Int SetX(this Vector2Int v, int x) { v.x = x; return v; }
        public static Vector2Int SetY(this Vector2Int v, int y) { v.y = y; return v; }

        public static Vector3 SetX(this Vector3 v, float x) { v.x = x; return v; }
        public static Vector3 SetY(this Vector3 v, float y) { v.y = y; return v; }
        public static Vector3 SetZ(this Vector3 v, float z) { v.z = z; return v; }

        public static Vector3Int SetX(this Vector3Int v, int x) { v.x = x; return v; }
        public static Vector3Int SetY(this Vector3Int v, int y) { v.y = y; return v; }
        public static Vector3Int SetZ(this Vector3Int v, int z) { v.z = z; return v; }

        public static Vector4 SetX(this Vector4 v, float x) { v.x = x; return v; }
        public static Vector4 SetY(this Vector4 v, float y) { v.y = y; return v; }
        public static Vector4 SetZ(this Vector4 v, float z) { v.z = z; return v; }
        public static Vector4 SetW(this Vector4 v, float w) { v.w = w; return v; }

        public static float Min(this Vector2 v) => Math.Min(v.x, v.y);
        public static float Min(this Vector3 v) => Math.Min(Math.Min(v.x, v.y), v.z);
        public static float Min(this Vector4 v) => Math.Min(Math.Min(Math.Min(v.x, v.y), v.z), v.w);
        public static int Min(this Vector2Int v) => Math.Min(v.x, v.y);
        public static int Min(this Vector3Int v) => Math.Min(Math.Min(v.x, v.y), v.z);

        public static float Max(this Vector2 v) => Math.Max(v.x, v.y);
        public static float Max(this Vector3 v) => Math.Max(Math.Max(v.x, v.y), v.z);
        public static float Max(this Vector4 v) => Math.Max(Math.Max(Math.Max(v.x, v.y), v.z), v.w);
        public static int Max(this Vector2Int v) => Math.Max(v.x, v.y);
        public static int Max(this Vector3Int v) => Math.Max(Math.Max(v.x, v.y), v.z);

        public static float Sum(this Vector2 v) => v.x + v.y;
        public static float Sum(this Vector3 v) => v.x + v.y + v.z;
        public static float Sum(this Vector4 v) => v.x + v.y + v.z + v.w;
        public static int Sum(this Vector2Int v) => v.x + v.y;
        public static int Sum(this Vector3Int v) => v.x + v.y + v.z;

        public static float Average(this Vector2 v) => (v.x + v.y) / 2f;
        public static float Average(this Vector3 v) => (v.x + v.y + v.z) / 3f;
        public static float Average(this Vector4 v) => (v.x + v.y + v.z + v.w) / 4f;
        public static float Average(this Vector2Int v) => (v.x + v.y) / 2f;
        public static float Average(this Vector3Int v) => (v.x + v.y + v.z) / 3f;

        public static Vector2 Floor(this Vector2 v) => new(Mathf.Floor(v.x), Mathf.Floor(v.y));
        public static Vector2 Round(this Vector2 v) => new(Mathf.Round(v.x), Mathf.Round(v.y));
        public static Vector2 Ceil(this Vector2 v) => new(Mathf.Ceil(v.x), Mathf.Ceil(v.y));

        public static Vector3 Floor(this Vector3 v) => new(Mathf.Floor(v.x), Mathf.Floor(v.y), Mathf.Floor(v.z));
        public static Vector3 Round(this Vector3 v) => new(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
        public static Vector3 Ceil(this Vector3 v) => new(Mathf.Ceil(v.x), Mathf.Ceil(v.y), Mathf.Ceil(v.z));

        public static Vector2Int FloorToInt(this Vector2 v) => new(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));
        public static Vector2Int RoundToInt(this Vector2 v) => new(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
        public static Vector2Int CeilToInt(this Vector2 v) => new(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y));

        public static Vector3Int FloorToInt(this Vector3 v) => new(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y), Mathf.FloorToInt(v.z));
        public static Vector3Int RoundToInt(this Vector3 v) => new(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
        public static Vector3Int CeilToInt(this Vector3 v) => new(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y), Mathf.CeilToInt(v.z));

        public static Vector2 Abs(this Vector2 v) => new(Math.Abs(v.x), Math.Abs(v.y));
        public static Vector3 Abs(this Vector3 v) => new(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));
        public static Vector4 Abs(this Vector4 v) => new(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z), Math.Abs(v.w));
        public static Vector2Int Abs(this Vector2Int v) => new(Math.Abs(v.x), Math.Abs(v.y));
        public static Vector3Int Abs(this Vector3Int v) => new(Math.Abs(v.x), Math.Abs(v.y), Math.Abs(v.z));
    }
}