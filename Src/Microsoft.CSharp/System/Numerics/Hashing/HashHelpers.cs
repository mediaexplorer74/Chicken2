// Decompiled with JetBrains decompiler
// Type: System.Numerics.Hashing.HashHelpers
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace System.Numerics.Hashing
{
  internal static class HashHelpers
  {
    public static int Combine(int h1, int h2) => (h1 << 5 | h1 >>> 27) + h1 ^ h2;
  }
}
