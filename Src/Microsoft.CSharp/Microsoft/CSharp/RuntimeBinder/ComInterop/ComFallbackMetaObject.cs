// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComFallbackMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal class ComFallbackMetaObject : DynamicMetaObject
  {
    internal ComFallbackMetaObject(
      Expression expression,
      BindingRestrictions restrictions,
      object arg)
      : base(expression, restrictions, arg)
    {
    }

    public override DynamicMetaObject BindGetIndex(
      GetIndexBinder binder,
      DynamicMetaObject[] indexes)
    {
      return binder.FallbackGetIndex((DynamicMetaObject) this.UnwrapSelf(), indexes);
    }

    public override DynamicMetaObject BindSetIndex(
      SetIndexBinder binder,
      DynamicMetaObject[] indexes,
      DynamicMetaObject value)
    {
      return binder.FallbackSetIndex((DynamicMetaObject) this.UnwrapSelf(), indexes, value);
    }

    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
      return binder.FallbackGetMember((DynamicMetaObject) this.UnwrapSelf());
    }

    public override DynamicMetaObject BindInvokeMember(
      InvokeMemberBinder binder,
      DynamicMetaObject[] args)
    {
      return binder.FallbackInvokeMember((DynamicMetaObject) this.UnwrapSelf(), args);
    }

    public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
    {
      return binder.FallbackSetMember((DynamicMetaObject) this.UnwrapSelf(), value);
    }

    protected virtual ComUnwrappedMetaObject UnwrapSelf()
    {
      return new ComUnwrappedMetaObject((Expression) ComObject.RcwFromComObject(this.Expression), this.Restrictions.Merge(ComBinderHelpers.GetTypeRestrictionForDynamicMetaObject((DynamicMetaObject) this)), ((ComObject) this.Value).RuntimeCallableWrapper);
    }
  }
}
