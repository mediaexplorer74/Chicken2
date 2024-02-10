// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.TypeUtils
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class TypeUtils
  {
    internal static Type GetNonNullableType(Type type)
    {
      return type.IsNullableType() ? type.GetGenericArguments()[0] : type;
    }

    internal static bool IsNullableType(this Type type)
    {
      return type.IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>);
    }

    internal static bool AreReferenceAssignable(Type dest, Type src)
    {
      return dest == src || !dest.IsValueType && !src.IsValueType && TypeUtils.AreAssignable(dest, src);
    }

    internal static bool AreAssignable(Type dest, Type src)
    {
      return dest == src || dest.IsAssignableFrom(src) || dest.IsArray && src.IsArray && dest.GetArrayRank() == src.GetArrayRank() && TypeUtils.AreReferenceAssignable(dest.GetElementType(), src.GetElementType()) || src.IsArray && dest.IsGenericType && (dest.GetGenericTypeDefinition() == typeof (IEnumerable<>) || dest.GetGenericTypeDefinition() == typeof (IList<>) || dest.GetGenericTypeDefinition() == typeof (ICollection<>)) && dest.GetGenericArguments()[0] == src.GetElementType();
    }

    internal static bool IsImplicitlyConvertible(Type source, Type destination)
    {
      return TypeUtils.IsIdentityConversion(source, destination) || TypeUtils.IsImplicitNumericConversion(source, destination) || TypeUtils.IsImplicitReferenceConversion(source, destination) || TypeUtils.IsImplicitBoxingConversion(source, destination);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static bool IsImplicitlyConvertible(
      Type source,
      Type destination,
      bool considerUserDefined)
    {
      if (TypeUtils.IsImplicitlyConvertible(source, destination))
        return true;
      return considerUserDefined && TypeUtils.GetUserDefinedCoercionMethod(source, destination, true) != (MethodInfo) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static MethodInfo GetUserDefinedCoercionMethod(
      Type convertFrom,
      Type convertToType,
      bool implicitOnly)
    {
      Type nonNullableType1 = TypeUtils.GetNonNullableType(convertFrom);
      Type nonNullableType2 = TypeUtils.GetNonNullableType(convertToType);
      MethodInfo[] methods1 = nonNullableType1.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      MethodInfo conversionOperator1 = TypeUtils.FindConversionOperator(methods1, convertFrom, convertToType, implicitOnly);
      if (conversionOperator1 != (MethodInfo) null)
        return conversionOperator1;
      MethodInfo[] methods2 = nonNullableType2.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      MethodInfo conversionOperator2 = TypeUtils.FindConversionOperator(methods2, convertFrom, convertToType, implicitOnly);
      if (conversionOperator2 != (MethodInfo) null)
        return conversionOperator2;
      if (nonNullableType1 != convertFrom || nonNullableType2 != convertToType)
      {
        MethodInfo conversionOperator3 = TypeUtils.FindConversionOperator(methods1, nonNullableType1, nonNullableType2, implicitOnly);
        if (conversionOperator3 == (MethodInfo) null)
          conversionOperator3 = TypeUtils.FindConversionOperator(methods2, nonNullableType1, nonNullableType2, implicitOnly);
        if (conversionOperator3 != (MethodInfo) null)
          return conversionOperator3;
      }
      return (MethodInfo) null;
    }

    internal static MethodInfo FindConversionOperator(
      MethodInfo[] methods,
      Type typeFrom,
      Type typeTo,
      bool implicitOnly)
    {
      foreach (MethodInfo method in methods)
      {
        if ((!(method.Name != "op_Implicit") || !implicitOnly && !(method.Name != "op_Explicit")) && !(method.ReturnType != typeTo) && !(method.GetParameters()[0].ParameterType != typeFrom))
          return method;
      }
      return (MethodInfo) null;
    }

    private static bool IsIdentityConversion(Type source, Type destination)
    {
      return source == destination;
    }

    private static bool IsImplicitNumericConversion(Type source, Type destination)
    {
      TypeCode typeCode1 = Type.GetTypeCode(source);
      TypeCode typeCode2 = Type.GetTypeCode(destination);
      switch (typeCode1)
      {
        case TypeCode.Char:
          switch (typeCode2)
          {
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.SByte:
          switch (typeCode2)
          {
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.Byte:
          switch (typeCode2)
          {
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.Int16:
          switch (typeCode2)
          {
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.UInt16:
          switch (typeCode2)
          {
            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.Int32:
          switch (typeCode2)
          {
            case TypeCode.Int64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.UInt32:
          switch (typeCode2)
          {
            case TypeCode.UInt32:
            case TypeCode.UInt64:
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.Int64:
        case TypeCode.UInt64:
          switch (typeCode2)
          {
            case TypeCode.Single:
            case TypeCode.Double:
            case TypeCode.Decimal:
              return true;
            default:
              return false;
          }
        case TypeCode.Single:
          return typeCode2 == TypeCode.Double;
        default:
          return false;
      }
    }

    private static bool IsImplicitReferenceConversion(Type source, Type destination)
    {
      return TypeUtils.AreAssignable(destination, source);
    }

    private static bool IsImplicitBoxingConversion(Type source, Type destination)
    {
      return source.IsValueType && (destination == typeof (object) || destination == typeof (ValueType)) || source.IsEnum && destination == typeof (Enum);
    }
  }
}
