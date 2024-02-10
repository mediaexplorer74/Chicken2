// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.TypeLibMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class TypeLibMetaObject : DynamicMetaObject
  {
    private readonly ComTypeLibDesc _lib;

    internal TypeLibMetaObject(Expression expression, ComTypeLibDesc lib)
      : base(expression, BindingRestrictions.Empty, (object) lib)
    {
      this._lib = lib;
    }

    private DynamicMetaObject TryBindGetMember(string name)
    {
      if (!this._lib.HasMember(name))
        return (DynamicMetaObject) null;
      BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(this.Expression, typeof (ComTypeLibDesc)).Merge(BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal((Expression) Expression.Property(Helpers.Convert(this.Expression, typeof (ComTypeLibDesc)), typeof (ComTypeLibDesc).GetProperty("Guid")), (Expression) Expression.Constant((object) this._lib.Guid))));
      return new DynamicMetaObject((Expression) Expression.Constant(((ComTypeLibDesc) this.Value).GetTypeLibObjectDesc(name)), restrictions);
    }

    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
      return this.TryBindGetMember(binder.Name) ?? base.BindGetMember(binder);
    }

    public override DynamicMetaObject BindInvokeMember(
      InvokeMemberBinder binder,
      DynamicMetaObject[] args)
    {
      DynamicMetaObject member = this.TryBindGetMember(binder.Name);
      return member != null ? binder.FallbackInvoke(member, args, (DynamicMetaObject) null) : base.BindInvokeMember(binder, args);
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
      return (IEnumerable<string>) this._lib.GetMemberNames();
    }
  }
}
