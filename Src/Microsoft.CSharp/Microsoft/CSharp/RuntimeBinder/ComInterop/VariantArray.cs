// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.VariantArray
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class VariantArray
  {
    private static readonly List<Type> s_generatedTypes = new List<Type>(0);

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicFields, typeof (VariantArray1))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicFields, typeof (VariantArray2))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicFields, typeof (VariantArray4))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicFields, typeof (VariantArray8))]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Types are either dynamically created or have dynamic dependency.")]
    internal static MemberExpression GetStructField(ParameterExpression variantArray, int field)
    {
      return Expression.Field((Expression) variantArray, "Element" + field.ToString());
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2055:UnrecognizedReflectionPattern", Justification = "MakeGenericType is called on a dynamically created type that doesn't contain trimming annotations.")]
    internal static Type GetStructType(int args)
    {
      if (args <= 1)
        return typeof (VariantArray1);
      if (args <= 2)
        return typeof (VariantArray2);
      if (args <= 4)
        return typeof (VariantArray4);
      if (args <= 8)
        return typeof (VariantArray8);
      int size = 1;
      while (args > size)
        size *= 2;
      lock (VariantArray.s_generatedTypes)
      {
        foreach (Type generatedType in VariantArray.s_generatedTypes)
        {
          int num = int.Parse(generatedType.Name.AsSpan(nameof (VariantArray).Length), provider: (IFormatProvider) CultureInfo.InvariantCulture);
          if (size == num)
            return generatedType;
        }
        Type structType = VariantArray.CreateCustomType(size).MakeGenericType(typeof (Variant));
        VariantArray.s_generatedTypes.Add(structType);
        return structType;
      }
    }

    private static Type CreateCustomType(int size)
    {
      TypeAttributes attr = TypeAttributes.SequentialLayout;
      TypeBuilder typeBuilder = UnsafeMethods.DynamicModule.DefineType(nameof (VariantArray) + size.ToString(), attr, typeof (ValueType));
      GenericTypeParameterBuilder genericParameter = typeBuilder.DefineGenericParameters("T")[0];
      for (int index = 0; index < size; ++index)
        typeBuilder.DefineField("Element" + index.ToString(), (Type) genericParameter, FieldAttributes.Public);
      return typeBuilder.CreateType();
    }
  }
}
