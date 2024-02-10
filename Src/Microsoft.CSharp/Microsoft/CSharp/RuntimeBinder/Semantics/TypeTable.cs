// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeTable
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class TypeTable
  {
    private static readonly Dictionary<TypeTable.KeyPair<AggregateSymbol, TypeTable.KeyPair<AggregateType, TypeArray>>, AggregateType> s_aggregateTable = new Dictionary<TypeTable.KeyPair<AggregateSymbol, TypeTable.KeyPair<AggregateType, TypeArray>>, AggregateType>();
    private static readonly Dictionary<TypeTable.KeyPair<CType, int>, ArrayType> s_arrayTable = new Dictionary<TypeTable.KeyPair<CType, int>, ArrayType>();
    private static readonly Dictionary<TypeTable.KeyPair<CType, bool>, ParameterModifierType> s_parameterModifierTable = new Dictionary<TypeTable.KeyPair<CType, bool>, ParameterModifierType>();
    private static readonly Dictionary<CType, PointerType> s_pointerTable = new Dictionary<CType, PointerType>();
    private static readonly Dictionary<CType, NullableType> s_nullableTable = new Dictionary<CType, NullableType>();

    private static TypeTable.KeyPair<TKey1, TKey2> MakeKey<TKey1, TKey2>(TKey1 key1, TKey2 key2)
    {
      return new TypeTable.KeyPair<TKey1, TKey2>(key1, key2);
    }

    public static AggregateType LookupAggregate(
      AggregateSymbol aggregate,
      AggregateType outer,
      TypeArray args)
    {
      AggregateType aggregateType;
      TypeTable.s_aggregateTable.TryGetValue(TypeTable.MakeKey<AggregateSymbol, TypeTable.KeyPair<AggregateType, TypeArray>>(aggregate, TypeTable.MakeKey<AggregateType, TypeArray>(outer, args)), out aggregateType);
      return aggregateType;
    }

    public static void InsertAggregate(
      AggregateSymbol aggregate,
      AggregateType outer,
      TypeArray args,
      AggregateType ats)
    {
      TypeTable.s_aggregateTable.Add(TypeTable.MakeKey<AggregateSymbol, TypeTable.KeyPair<AggregateType, TypeArray>>(aggregate, TypeTable.MakeKey<AggregateType, TypeArray>(outer, args)), ats);
    }

    public static ArrayType LookupArray(CType elementType, int rankNum)
    {
      ArrayType arrayType;
      TypeTable.s_arrayTable.TryGetValue(new TypeTable.KeyPair<CType, int>(elementType, rankNum), out arrayType);
      return arrayType;
    }

    public static void InsertArray(CType elementType, int rankNum, ArrayType pArray)
    {
      TypeTable.s_arrayTable.Add(new TypeTable.KeyPair<CType, int>(elementType, rankNum), pArray);
    }

    public static ParameterModifierType LookupParameterModifier(CType elementType, bool isOut)
    {
      ParameterModifierType parameterModifierType;
      TypeTable.s_parameterModifierTable.TryGetValue(new TypeTable.KeyPair<CType, bool>(elementType, isOut), out parameterModifierType);
      return parameterModifierType;
    }

    public static void InsertParameterModifier(
      CType elementType,
      bool isOut,
      ParameterModifierType parameterModifier)
    {
      TypeTable.s_parameterModifierTable.Add(new TypeTable.KeyPair<CType, bool>(elementType, isOut), parameterModifier);
    }

    public static PointerType LookupPointer(CType elementType)
    {
      PointerType pointerType;
      TypeTable.s_pointerTable.TryGetValue(elementType, out pointerType);
      return pointerType;
    }

    public static void InsertPointer(CType elementType, PointerType pointer)
    {
      TypeTable.s_pointerTable.Add(elementType, pointer);
    }

    public static NullableType LookupNullable(CType underlyingType)
    {
      NullableType nullableType;
      TypeTable.s_nullableTable.TryGetValue(underlyingType, out nullableType);
      return nullableType;
    }

    public static void InsertNullable(CType underlyingType, NullableType nullable)
    {
      TypeTable.s_nullableTable.Add(underlyingType, nullable);
    }

    private readonly struct KeyPair<TKey1, TKey2> : IEquatable<TypeTable.KeyPair<TKey1, TKey2>>
    {
      private readonly TKey1 _pKey1;
      private readonly TKey2 _pKey2;

      public KeyPair(TKey1 pKey1, TKey2 pKey2)
      {
        this._pKey1 = pKey1;
        this._pKey2 = pKey2;
      }

      public bool Equals(TypeTable.KeyPair<TKey1, TKey2> other)
      {
        return EqualityComparer<TKey1>.Default.Equals(this._pKey1, other._pKey1) && EqualityComparer<TKey2>.Default.Equals(this._pKey2, other._pKey2);
      }

      public override bool Equals(object obj)
      {
        return obj is TypeTable.KeyPair<TKey1, TKey2> other && this.Equals(other);
      }

      public override int GetHashCode()
      {
        int hashCode = (object) this._pKey1 == null ? 0 : this._pKey1.GetHashCode();
        return (hashCode << 5) - hashCode + ((object) this._pKey2 == null ? 0 : this._pKey2.GetHashCode());
      }
    }
  }
}
