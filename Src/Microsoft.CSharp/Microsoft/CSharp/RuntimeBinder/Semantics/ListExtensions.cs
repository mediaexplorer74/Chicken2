// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ListExtensions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class ListExtensions
  {
    public static bool IsEmpty<T>(this List<T> list) => list == null || list.Count == 0;

    public static T Head<T>(this List<T> list) => list[0];

    public static List<T> Tail<T>(this List<T> list)
    {
      T[] objArray = new T[list.Count];
      list.CopyTo(objArray, 0);
      List<T> objList = new List<T>((IEnumerable<T>) objArray);
      objList.RemoveAt(0);
      return objList;
    }
  }
}
