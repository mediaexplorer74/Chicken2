// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.CollectionExtensions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class CollectionExtensions
  {
    internal static T[] RemoveFirst<T>(this T[] array)
    {
      T[] destinationArray = new T[array.Length - 1];
      Array.Copy((Array) array, 1, (Array) destinationArray, 0, destinationArray.Length);
      return destinationArray;
    }

    internal static T[] AddFirst<T>(this IList<T> list, T item)
    {
      T[] array = new T[list.Count + 1];
      array[0] = item;
      list.CopyTo(array, 1);
      return array;
    }

    internal static T[] ToArray<T>(this IList<T> list)
    {
      T[] array = new T[list.Count];
      list.CopyTo(array, 0);
      return array;
    }

    internal static T[] AddLast<T>(this IList<T> list, T item)
    {
      T[] array = new T[list.Count + 1];
      list.CopyTo(array, 0);
      array[list.Count] = item;
      return array;
    }
  }
}
