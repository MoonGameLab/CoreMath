using System;
using System.Reflection;
using System.Runtime.CompilerServices;


[assembly: AssemblyTitle ("MGL.CoreMath")]


[assembly: AssemblyVersion ("0.0.0.1")]
[assembly: CLSCompliant (true)]

#if SIMD
/// https://github.com/dotnet/docs/blob/main/docs/standard/simd.md
[assembly: AssemblyDescription ("Core Math for Games (SIMD)")]
#elif UNSAFE
[assembly: AssemblyDescription ("Core Math for Games (Unsafe)")]
#elif SAFE
[assembly: AssemblyDescription ("Core Math for Games (Safe)")]
#else
[assembly: AssemblyDescription ("Core Math for Games (Unknown)")]
#endif
