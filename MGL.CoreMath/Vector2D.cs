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

    #region  Vec Math

    public float LengthSquared ()
    {
      return x * x + y * y;
    }
    
    public static void Clamp (ref Vector2D val1, ref Vector2D min, ref Vector2D max, out Vector2D res)
    {
      res.x = MathHelper.Clamp(val1.x, min.x, max.x);
      res.y = MathHelper.Clamp(val1.y, min.y, max.y);
    }

    public static Vector2D Clamp (Vector2D val1, Vector2D min, Vector2D max)
    {
      Clamp (ref val1, ref min, ref max, out val1);
      return val1;
    }

    public static void DistanceSquared (ref Vector2D val1, ref Vector2D val2, out float res)
    {
      Vector2D val;
      Sub (ref val1, ref val2, out val);
      res = val.LengthSquared();
    }

    public static float DistanceSquared (Vector2D val1, Vector2D val2)
    {
      float res;
      DistanceSquared(ref val1, ref val2, out res);
      return res;
    }

    public static void Distance (ref Vector2D val1, ref Vector2D val2, out float res)
    {
#if SIMD
      Vector4f r0 = new Vector4f (val2.x - val1.x, val2.y - val1.y, 0f, 0f);
      r0 = r0 * r0;
      r0 = r0 + r0.Shuffle (ShuffleSel.Swap);
      r0 = r0 + r0.Shuffle (ShuffleSel.RotateLeft);
      res = r0.Sqrt ().X;
#else
      DistanceSquared (ref val1, ref val2, out res);
      res = (float) System.Math.Sqrt (res);
#endif
    }

    public static float Distance (Vector2D val1, Vector2D val2)
    {
      float res;
      Distance (ref val1, ref val2, out res);
      return res;
    }

    public static void Dot (ref Vector2D val1, ref Vector2D val2, out float res)
    {
      res = val1.x * val2.x + val1.y * val2.y;
    }

    public static float Dot (Vector2D val1, Vector2D val2)
    {
      float res;
      Dot (ref val1, ref val2, out res);
      return res;
    }

    public float Length ()
    {
      return (float) System.Math.Sqrt (LengthSquared ());
    }

    public static void Max (ref Vector2D val1, ref Vector2D val2, out Vector2D res)   
    {
      res.x = System.Math.Max (val1.x, val2.x);
      res.y = System.Math.Max (val1.y, val2.y);
    }

    public static Vector2D Max (Vector2D val1, Vector2D val2)
    {
      Max (ref val1, ref val2, out val1);
      return val1;
    }

    public static void Min (ref Vector2D val1, ref Vector2D val2, out Vector2D res)   
    {
      res.x = System.Math.Min (val1.x, val2.x);
      res.y = System.Math.Min (val1.y, val2.y);
    }

    public static Vector2D Min (Vector2D val1, Vector2D val2)
    {
      Min (ref val1, ref val2, out val1);
      return val1;
    }

    public static void Normalize (ref Vector2D val, out Vector2D res)
    {
      var l = val.Length();
      res.x = val.x / l;
      res.y = val.y / l;
    }

    public void Normalize ()
    {
      Normalize (ref this, out this);
    }
    public static Vector2D Normalize (Vector2D val)
    {
      val.Normalize ();
      return val;
    }

    public static void Reflect (ref Vector2D vec, ref Vector2D normal, out Vector2D res)
    {
      float d2 = (float) System.Math.Sqrt (normal.x * vec.x + normal.y * vec.y);
      d2 += d2;
      //subtract faster than negate and add
      res.x = d2 * normal.x - vec.x;
      res.y = d2 * normal.y - vec.y;
    }

    public static Vector2D Reflect (Vector2D vec, Vector2D normal)
    {
      Vector2D res;
      Reflect (ref vec, ref normal, out res);
      return res;
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