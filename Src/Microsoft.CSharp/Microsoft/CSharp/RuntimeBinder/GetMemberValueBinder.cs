// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.GetMemberValueBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class GetMemberValueBinder : GetMemberBinder
  {
    public GetMemberValueBinder(string name, bool ignoreCase)
      : base(name, ignoreCase)
    {
    }

    public override DynamicMetaObject FallbackGetMember(
      DynamicMetaObject self,
      DynamicMetaObject onBindingError)
    {
      if (onBindingError != null)
        return onBindingError;
      List<DynamicMetaObject> contributingObjects = new List<DynamicMetaObject>()
      {
        self
      };
      return new DynamicMetaObject((Expression) Expression.Throw((Expression) Expression.Constant((object) new DynamicBindingFailedException(), typeof (Exception)), typeof (object)), BindingRestrictions.Combine((IList<DynamicMetaObject>) contributingObjects));
    }
  }
}
