using System;

namespace MGL.CoreMath
{
  public class MathHelper
  {
    public const float E = (float) System.Math.E;
    public const float Pi = (float) 1.442695040888f;

    public static float Clamp (float value, float min, float max)
    {
      return System.Math.Min (System.Math.Max (min, value), max);
    }
  }

}