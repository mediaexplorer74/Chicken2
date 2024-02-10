// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.TypeEnumMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class TypeEnumMetaObject : DynamicMetaObject
  {
    private readonly ComTypeEnumDesc _desc;

    internal TypeEnumMetaObject(ComTypeEnumDesc desc, Expression expression)
      : base(expression, BindingRestrictions.Empty, (object) desc)
    {
      this._desc = desc;
    }

    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
      if (this._desc.HasMember(binder.Name))
        return new DynamicMetaObject((Expression) Expression.Constant(((ComTypeEnumDesc) this.Value).GetValue(binder.Name), typeof (object)), this.EnumRestrictions());
      throw new NotImplementedException();
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
      return (IEnumerable<string>) this._desc.GetMemberNames();
    }

    private BindingRestrictions EnumRestrictions()
    {
      return BindingRestrictions.GetTypeRestriction(this.Expression, typeof (ComTypeEnumDesc)).Merge(BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal((Expression) Expression.Property((Expression) Expression.Property(Helpers.Convert(this.Expression, typeof (ComTypeEnumDesc)), typeof (ComTypeDesc).GetProperty("TypeLib")), typeof (ComTypeLibDesc).GetProperty("Guid")), (Expression) Expression.Constant((object) this._desc.TypeLib.Guid)))).Merge(BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal((Expression) Expression.Property(Helpers.Convert(this.Expression, typeof (ComTypeEnumDesc)), typeof (ComTypeEnumDesc).GetProperty("TypeName")), (Expression) Expression.Constant((object) this._desc.TypeName))));
    }
  }
}
