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

    #region Arithmetic
    
    public static void Add (ref Vector2D v1, ref Vector2D v2, out Vector2D res)
    {
      res.x = v1.x + v2.x;
      res.y = v1.y + v2.y;
    }
    public static Vector2D Add (Vector2D v1, Vector2D v2)
    {
      Add (ref v1, ref v2, out v1);
      return v1;
    }

    public static Vector2D Multi (Vector2D v1, float scaleF)
    {
#if SIMD
      var v4  = new Vector4f (v1.x, v1.y, 0f, 0f) * new Vector4f (scaleF);
      return Vector2D (v4.X, v4.Y);
#else
      return new Vector2D (v1.x * scaleF, v1.y * scaleF);
#endif
    }

    public static void Multi (ref Vector2D v1, float scaleF, out Vector2D res)
    {
#if SIMD
      var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) * new Vector4f (scaleF);
			res.x = v4.X;
			res.y = v4.Y;
#else
      res.x = v1.x * scaleF;
      res.y = v1.y * scaleF;
#endif
    }

    public static Vector2D Multi (Vector2D v1, Vector2D v2)
    {
#if SIMD
      var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) * new Vector4f (v2.x, v2.y, 0f, 0f);
      return new Vector2D(v4.X, v4.Y);
#else
      return new Vector2D (v1.x * v2.x, v1.y * v1.y);
#endif
    }

    public static void Multi (ref Vector2D v1, ref Vector2D v2, out Vector2D res)
    {
#if SIMD
			var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) * new Vector4f (v2.x, v2.y, 0f, 0f);
			res.x = v4.X;
			res.y = v4.Y;
#else
			res.x = v1.x * v2.x;
			res.y = v1.y * v2.y;
#endif
    }

    public static void Sub (ref Vector2D v1, ref Vector2D v2, out Vector2D res)
    {
      res.x = v1.x - v2.x; 
      res.y = v1.y - v2.y; 
    }

     public static Vector2D Sub (Vector2D v1, Vector2D v2)
    {
      Sub (ref v1,ref v2, out v1);
      return v1;
    }

    public static void Negate (ref Vector2D v, out Vector2D res)
    {
      res.x = -v.x; 
      res.y = -v.y; 
    }

    public static Vector2D Negate (Vector2D v)
    {
      Negate (ref v, out v);
      return v;
    }

    public static Vector2D Div (Vector2D v, float divider)
    {
#if SIMD
      var v4 = new Vector4f (v.x, v.y, 0f, 0f) / new Vector4f (divider);
			return new Vector2D (v4.X, v4.Y);
#else
      return new Vector2D (v.x / divider, v.y / divider);
#endif
    }

    public static void Div (ref Vector2D v, float divider, out Vector2D res)
    {
#if SIMD
      var v4 = new Vector4f (v.x, v.y, 0f, 0f) / new Vector4f (divider);
			res.x = v4.X;
			res.y = v4.Y;
#else
      res.x = v.x / divider;
			res.y = v.y / divider;
#endif     
    }

    public static Vector2D Div (Vector2D v1, Vector2D v2)
    {
#if SIMD
      var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) / new Vector4f (v2.x, v2.y, 0f, 0f);
      return new Vector2D (v4.X, v4.Y);
#else
      return new Vector2D (v1.x / v2.x, v1.y / v2.x);
#endif
    }

    public static void Div (ref Vector2D v1, ref Vector2D v2, out Vector2D res)
    {
#if SIMD
      var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) / new Vector4f (v2.x, v2.y, 0f, 0f);
      res.x = v4.X;
      res.y = v4.Y;
#else
      res.x = v1.x * v2.x;
			res.y = v1.y * v2.x;
#endif    
    }

    #endregion


    #region Equality

    public bool Equals(Vector2D other)
    {
      return x == other.x && y == other.y;
    }
  
    public override bool Equals (object? obj)
		{
			return obj is Vector2D && ((Vector2D)obj) == this;
		}

    public static bool operator == (Vector2D a, Vector2D b)
		{
			return a.x == b.x && a.y == b.y;
		}

    public static bool operator != (Vector2D a, Vector2D b)
		{
			return a.x != b.x || a.y != b.y;
		}

    public override int GetHashCode ()
		{
			return x.GetHashCode () ^ y.GetHashCode ();
		}

    #endregion

    #region Oprs Overload

    public static Vector2D operator + (Vector2D v1, Vector2D v2)
    {
      return new Vector2D (v1.x + v2.x, v1.y + v2.y);
    }

    public static Vector2D operator / (Vector2D v1, float divider)
    {
#if SIMD
			var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) / new Vector4f (divider);
			return new Vector2D (v4.X, v4.Y);
#else
			return new Vector2D (v1.x / divider, v1.y / divider);
#endif
    }

    public static Vector2D operator / (Vector2D v1, Vector2D v2)
		{
#if SIMD
			var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) / new Vector4f (v2.x, v2.y, 0f, 0f);
			return new Vector2D (v4.X, v4.Y);
#else
			return new Vector2D (v1.x / v2.x, v1.y / v2.y);
#endif
		}

		public static Vector2D operator - (Vector2D v1, Vector2D v2)
		{
			return new Vector2D (v1.x - v2.x, v1.y - v2.y);
		}
		
		public static Vector2D operator - (Vector2D v)
		{
			return new Vector2D (- v.x, - v.y);
		}

    public static Vector2D operator * (Vector2D v1, Vector2D v2)
		{
#if SIMD
			var v4 = new Vector4f (v1.x, v1.y, 0f, 0f) * new Vector4f (v2.x, v2.y, 0f, 0f);
			return new Vector2D (v4.X, v4.Y);
#else
			return new Vector2D (v1.x * v2.x, v1.y * v2.y);
#endif
		}
		
		public static Vector2D operator * (Vector2D v, float scaleFactor)
		{
#if SIMD
			var v4 = new Vector4f (v.x, v.y, 0f, 0f) * new Vector4f (scaleFactor);
			return new Vector2D (v4.X, v4.Y);	
#else
			return new Vector2D (v.x * scaleFactor, v.y * scaleFactor);
#endif
		}
		
		public static Vector2D operator * (float scaleFactor, Vector2D v)
		{
#if SIMD
			var v4 = new Vector4f (v.x, v.y, 0f, 0f) * new Vector4f (scaleFactor);
			return new Vector2D (v4.X, v4.Y);	
#else
			return new Vector2D (v.x * scaleFactor, v.y * scaleFactor);
#endif
		}

    #endregion


    #region To String

    public override string ToString ()
		{
			return string.Format ("{{X:{0} Y:{1}}}", X, Y);
		}

    #endregion

  }
}