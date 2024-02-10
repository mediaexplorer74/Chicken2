// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComInvokeAction
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComInvokeAction : InvokeBinder
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ComInvokeAction(CallInfo callInfo)
      : base(callInfo)
    {
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject FallbackInvoke(
      DynamicMetaObject target,
      DynamicMetaObject[] args,
      DynamicMetaObject errorSuggestion)
    {
      DynamicMetaObject result;
      if (ComBinder.TryBindInvoke((InvokeBinder) this, target, args, out result))
        return result;
      DynamicMetaObject dynamicMetaObject = errorSuggestion;
      if (dynamicMetaObject != null)
        return dynamicMetaObject;
      return new DynamicMetaObject((Expression) Expression.Throw((Expression) Expression.New(typeof (NotSupportedException).GetConstructor(new Type[1]
      {
        typeof (string)
      }), (Expression) Expression.Constant((object) SR.COMCannotPerformCall)), typeof (object)), target.Restrictions.Merge(BindingRestrictions.Combine((IList<DynamicMetaObject>) args)));
    }
  }
}
