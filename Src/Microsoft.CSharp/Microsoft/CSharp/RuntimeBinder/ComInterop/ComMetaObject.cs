// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class ComMetaObject : DynamicMetaObject
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ComMetaObject(Expression expression, BindingRestrictions restrictions, object arg)
      : base(expression, restrictions, arg)
    {
    }

    public override DynamicMetaObject BindInvokeMember(
      InvokeMemberBinder binder,
      DynamicMetaObject[] args)
    {
      return binder.Defer(((IList<DynamicMetaObject>) args).AddFirst<DynamicMetaObject>(this.WrapSelf()));
    }

    public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
    {
      return binder.Defer(((IList<DynamicMetaObject>) args).AddFirst<DynamicMetaObject>(this.WrapSelf()));
    }

    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
      return binder.Defer(this.WrapSelf());
    }

    public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
    {
      return binder.Defer(this.WrapSelf(), value);
    }

    public override DynamicMetaObject BindGetIndex(
      GetIndexBinder binder,
      DynamicMetaObject[] indexes)
    {
      return binder.Defer(this.WrapSelf(), indexes);
    }

    public override DynamicMetaObject BindSetIndex(
      SetIndexBinder binder,
      DynamicMetaObject[] indexes,
      DynamicMetaObject value)
    {
      return binder.Defer(this.WrapSelf(), ((IList<DynamicMetaObject>) indexes).AddLast<DynamicMetaObject>(value));
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    private DynamicMetaObject WrapSelf()
    {
      return new DynamicMetaObject((Expression) ComObject.RcwToComObject(this.Expression), BindingRestrictions.GetExpressionRestriction((Expression) Expression.Call(typeof (ComBinder).GetMethod("IsComObject", BindingFlags.Static | BindingFlags.Public), Helpers.Convert(this.Expression, typeof (object)))));
    }
  }
}
