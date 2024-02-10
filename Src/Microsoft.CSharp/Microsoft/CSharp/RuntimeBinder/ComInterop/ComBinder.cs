// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class ComBinder
  {
    public static bool IsComObject(object value) => value != null && Marshal.IsComObject(value);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindGetMember(
      GetMemberBinder binder,
      DynamicMetaObject instance,
      out DynamicMetaObject result,
      bool delayInvocation)
    {
      if (ComBinder.TryGetMetaObject(ref instance))
      {
        ComBinder.ComGetMemberBinder binder1 = new ComBinder.ComGetMemberBinder(binder, delayInvocation);
        result = instance.BindGetMember((GetMemberBinder) binder1);
        if (result.Expression.Type.IsValueType)
          result = new DynamicMetaObject((Expression) Expression.Convert(result.Expression, typeof (object)), result.Restrictions);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindSetMember(
      SetMemberBinder binder,
      DynamicMetaObject instance,
      DynamicMetaObject value,
      out DynamicMetaObject result)
    {
      if (ComBinder.TryGetMetaObject(ref instance))
      {
        result = instance.BindSetMember(binder, value);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindInvoke(
      InvokeBinder binder,
      DynamicMetaObject instance,
      DynamicMetaObject[] args,
      out DynamicMetaObject result)
    {
      if (ComBinder.TryGetMetaObjectInvoke(ref instance))
      {
        result = instance.BindInvoke(binder, args);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindInvokeMember(
      InvokeMemberBinder binder,
      DynamicMetaObject instance,
      DynamicMetaObject[] args,
      out DynamicMetaObject result)
    {
      if (ComBinder.TryGetMetaObject(ref instance))
      {
        result = instance.BindInvokeMember(binder, args);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindGetIndex(
      GetIndexBinder binder,
      DynamicMetaObject instance,
      DynamicMetaObject[] args,
      out DynamicMetaObject result)
    {
      if (ComBinder.TryGetMetaObjectInvoke(ref instance))
      {
        result = instance.BindGetIndex(binder, args);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static bool TryBindSetIndex(
      SetIndexBinder binder,
      DynamicMetaObject instance,
      DynamicMetaObject[] args,
      DynamicMetaObject value,
      out DynamicMetaObject result)
    {
      if (ComBinder.TryGetMetaObjectInvoke(ref instance))
      {
        result = instance.BindSetIndex(binder, args, value);
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    public static bool TryConvert(
      ConvertBinder binder,
      DynamicMetaObject instance,
      out DynamicMetaObject result)
    {
      if (ComBinder.IsComObject(instance.Value) && binder.Type.IsInterface)
      {
        result = new DynamicMetaObject((Expression) Expression.Convert(instance.Expression, binder.Type), BindingRestrictions.GetExpressionRestriction((Expression) Expression.Call(typeof (ComBinder).GetMethod("IsComObject", BindingFlags.Static | BindingFlags.Public), Helpers.Convert(instance.Expression, typeof (object)))));
        return true;
      }
      result = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static IList<string> GetDynamicDataMemberNames(object value)
    {
      return ComObject.ObjectToComObject(value).GetMemberNames(true);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static IList<KeyValuePair<string, object>> GetDynamicDataMembers(
      object value,
      IEnumerable<string> names)
    {
      return ComObject.ObjectToComObject(value).GetMembers(names);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool TryGetMetaObject(ref DynamicMetaObject instance)
    {
      if (instance is ComUnwrappedMetaObject || !ComBinder.IsComObject(instance.Value))
        return false;
      instance = (DynamicMetaObject) new ComMetaObject(instance.Expression, instance.Restrictions, instance.Value);
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool TryGetMetaObjectInvoke(ref DynamicMetaObject instance)
    {
      if (ComBinder.TryGetMetaObject(ref instance))
        return true;
      if (!(instance.Value is IPseudoComObject pseudoComObject))
        return false;
      instance = pseudoComObject.GetMetaObject(instance.Expression);
      return true;
    }

    internal sealed class ComGetMemberBinder : GetMemberBinder
    {
      private readonly GetMemberBinder _originalBinder;
      internal bool _canReturnCallables;

      internal ComGetMemberBinder(GetMemberBinder originalBinder, bool canReturnCallables)
        : base(originalBinder.Name, originalBinder.IgnoreCase)
      {
        this._originalBinder = originalBinder;
        this._canReturnCallables = canReturnCallables;
      }

      public override DynamicMetaObject FallbackGetMember(
        DynamicMetaObject target,
        DynamicMetaObject errorSuggestion)
      {
        return this._originalBinder.FallbackGetMember(target, errorSuggestion);
      }

      public override int GetHashCode()
      {
        return this._originalBinder.GetHashCode() ^ (this._canReturnCallables ? 1 : 0);
      }

      public override bool Equals(object obj)
      {
        return obj is ComBinder.ComGetMemberBinder comGetMemberBinder && this._canReturnCallables == comGetMemberBinder._canReturnCallables && this._originalBinder.Equals((object) comGetMemberBinder._originalBinder);
      }
    }
  }
}
