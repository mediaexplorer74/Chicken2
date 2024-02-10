// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeArray
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class TypeArray
  {
    private static readonly Dictionary<TypeArray.TypeArrayKey, TypeArray> s_tableTypeArrays = new Dictionary<TypeArray.TypeArrayKey, TypeArray>();
    public static readonly TypeArray Empty = new TypeArray(Array.Empty<CType>());

    private TypeArray(CType[] types) => this.Items = types;

    public int Count => this.Items.Length;

    public CType[] Items { get; }

    public CType this[int i] => this.Items[i];

    public void CopyItems(int i, int c, CType[] dest)
    {
      Array.Copy((Array) this.Items, i, (Array) dest, 0, c);
    }

    public static TypeArray Allocate(int ctype, TypeArray array, int offset)
    {
      if (ctype == 0)
        return TypeArray.Empty;
      if (ctype == array.Count)
        return array;
      CType[] items = array.Items;
      CType[] destinationArray = new CType[ctype];
      Array.ConstrainedCopy((Array) items, offset, (Array) destinationArray, 0, ctype);
      return TypeArray.Allocate(destinationArray);
    }

    public static TypeArray Allocate(params CType[] types)
    {
      if (types == null || types.Length == 0)
        return TypeArray.Empty;
      TypeArray.TypeArrayKey key = new TypeArray.TypeArrayKey(types);
      TypeArray typeArray;
      if (!TypeArray.s_tableTypeArrays.TryGetValue(key, out typeArray))
      {
        typeArray = new TypeArray(types);
        TypeArray.s_tableTypeArrays.Add(key, typeArray);
      }
      return typeArray;
    }

    public static TypeArray Concat(TypeArray pta1, TypeArray pta2)
    {
      CType[] items1 = pta1.Items;
      if (items1.Length == 0)
        return pta2;
      CType[] items2 = pta2.Items;
      if (items2.Length == 0)
        return pta1;
      CType[] destinationArray = new CType[items1.Length + items2.Length];
      Array.Copy((Array) items1, (Array) destinationArray, items1.Length);
      Array.Copy((Array) items2, 0, (Array) destinationArray, items1.Length, items2.Length);
      return TypeArray.Allocate(destinationArray);
    }

    private readonly struct TypeArrayKey : IEquatable<TypeArray.TypeArrayKey>
    {
      private readonly CType[] _types;
      private readonly int _hashCode;

      public TypeArrayKey(CType[] types)
      {
        this._types = types;
        int num = 371857150;
        foreach (CType type in types)
        {
          num = (num << 5) - num;
          if (type != null)
            num ^= type.GetHashCode();
        }
        this._hashCode = num;
      }

      public bool Equals(TypeArray.TypeArrayKey other)
      {
        CType[] types1 = this._types;
        CType[] types2 = other._types;
        if (types2 == types1)
          return true;
        if (other._hashCode != this._hashCode || types2.Length != types1.Length)
          return false;
        for (int index = 0; index < types1.Length; ++index)
        {
          if (types1[index] != types2[index])
            return false;
        }
        return true;
      }

      [ExcludeFromCodeCoverage(Justification = "Typed overload should always be the method called")]
      public override bool Equals(object obj)
      {
        return obj is TypeArray.TypeArrayKey other && this.Equals(other);
      }

      public override int GetHashCode() => this._hashCode;
    }
  }
}
