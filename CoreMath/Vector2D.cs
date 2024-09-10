using System;

#if SIMD
using Mono.Simd;
#endif

namespace MGL.CoreMath
{
    /// <summary>
    /// 2D Vector class.
    /// </summary>
    [Serializable]
    public struct Vector2D : IEquatable<Vector2D>
    {
        float x, y;

        public float X { get { return x; } }
        public float Y { get { return y; } }

        public Vector2D(float value)
        {
            x = y = value;
        }

        public Vector2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        #region Static properties

        public static Vector2D UnitX {
            get {
                return new Vector2D(1f, 0f);
            }
        }

        public static Vector2D UnitY {
            get {
                return new Vector2D(0f, 1f);
            }
        }

        public static Vector2D One {
            get {
                return new Vector2D(1f);
            }
        }

        public static Vector2D NgOne {
            get {
                return new Vector2D(-1f);
            }
        }

        public static Vector2D Zero {
            get {
                return new Vector2D(0f);
            }
        }

        #endregion


        public bool Equals(Vector2D other)
        {
            throw new NotImplementedException();
        }
    }
}