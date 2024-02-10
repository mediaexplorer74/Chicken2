// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComBinderHelpers
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class ComBinderHelpers
  {
    internal static bool PreferPut(Type type, bool holdsNull)
    {
      return ((type.IsValueType || type.IsArray || type == typeof (string) ? 1 : (type == typeof (DBNull) ? 1 : 0)) | (holdsNull ? 1 : 0)) != 0 || type == typeof (Missing) || type == typeof (CurrencyWrapper);
    }

    internal static bool IsByRef(DynamicMetaObject mo)
    {
      return mo.Expression is ParameterExpression expression && expression.IsByRef;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static bool IsStrongBoxArg(DynamicMetaObject o)
    {
      Type limitType = o.LimitType;
      return limitType.IsGenericType && limitType.GetGenericTypeDefinition() == typeof (StrongBox<>);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static bool[] ProcessArgumentsForCom(ref DynamicMetaObject[] args)
    {
      DynamicMetaObject[] dynamicMetaObjectArray = new DynamicMetaObject[args.Length];
      bool[] flagArray = new bool[args.Length];
      for (int index = 0; index < args.Length; ++index)
      {
        DynamicMetaObject dynamicMetaObject = args[index];
        if (ComBinderHelpers.IsByRef(dynamicMetaObject))
        {
          dynamicMetaObjectArray[index] = dynamicMetaObject;
          flagArray[index] = true;
        }
        else if (ComBinderHelpers.IsStrongBoxArg(dynamicMetaObject))
        {
          BindingRestrictions restrictions = dynamicMetaObject.Restrictions.Merge(ComBinderHelpers.GetTypeRestrictionForDynamicMetaObject(dynamicMetaObject));
          Expression expression = (Expression) Expression.Field(Helpers.Convert(dynamicMetaObject.Expression, dynamicMetaObject.LimitType), dynamicMetaObject.LimitType.GetField("Value"));
          object obj = dynamicMetaObject.Value is IStrongBox strongBox ? strongBox.Value : (object) null;
          dynamicMetaObjectArray[index] = new DynamicMetaObject(expression, restrictions, obj);
          flagArray[index] = true;
        }
        else
        {
          dynamicMetaObjectArray[index] = dynamicMetaObject;
          flagArray[index] = false;
        }
      }
      args = dynamicMetaObjectArray;
      return flagArray;
    }

    internal static BindingRestrictions GetTypeRestrictionForDynamicMetaObject(DynamicMetaObject obj)
    {
      return obj.Value == null && obj.HasValue ? BindingRestrictions.GetInstanceRestriction(obj.Expression, (object) null) : BindingRestrictions.GetTypeRestriction(obj.Expression, obj.LimitType);
    }
  }
}
