// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComClassMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComClassMetaObject : DynamicMetaObject
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ComClassMetaObject(Expression expression, ComTypeClassDesc cls)
      : base(expression, BindingRestrictions.Empty, (object) cls)
    {
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindCreateInstance(
      CreateInstanceBinder binder,
      DynamicMetaObject[] args)
    {
      return new DynamicMetaObject((Expression) Expression.Call(Helpers.Convert(this.Expression, typeof (ComTypeClassDesc)), typeof (ComTypeClassDesc).GetMethod("CreateInstance")), BindingRestrictions.Combine((IList<DynamicMetaObject>) args).Merge(BindingRestrictions.GetTypeRestriction(this.Expression, typeof (ComTypeClassDesc))));
    }
  }
}
