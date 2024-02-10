// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MethodSymbol
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class MethodSymbol : MethodOrPropertySymbol
  {
    private MethodKindEnum _methKind;
    private bool _inferenceMustFail;
    private bool _checkedInfMustFail;
    private MethodSymbol _convNext;
    private PropertySymbol _prop;
    private EventSymbol _evt;
    public bool isVirtual;
    public MemberInfo AssociatedMemberInfo;
    public TypeArray typeVars;

    public bool InferenceMustFail()
    {
      if (this._checkedInfMustFail)
        return this._inferenceMustFail;
      this._checkedInfMustFail = true;
label_9:
      for (int i1 = 0; i1 < this.typeVars.Count; ++i1)
      {
        TypeParameterType typeVar = (TypeParameterType) this.typeVars[i1];
        for (int i2 = 0; i2 < this.Params.Count; ++i2)
        {
          if (TypeManager.TypeContainsType(this.Params[i2], (CType) typeVar))
            goto label_9;
        }
        this._inferenceMustFail = true;
        return true;
      }
      return false;
    }

    public MethodKindEnum MethKind => this._methKind;

    public bool IsConstructor() => this._methKind == MethodKindEnum.Constructor;

    public bool IsNullableConstructor()
    {
      return this.getClass().isPredefAgg(PredefinedType.PT_G_OPTIONAL) && this.Params.Count == 1 && this.Params[0] is TypeParameterType && this.IsConstructor();
    }

    public bool isPropertyAccessor() => this._methKind == MethodKindEnum.PropAccessor;

    public bool isEventAccessor() => this._methKind == MethodKindEnum.EventAccessor;

    public bool isImplicit() => this._methKind == MethodKindEnum.ImplicitConv;

    public void SetMethKind(MethodKindEnum mk) => this._methKind = mk;

    public MethodSymbol ConvNext() => this._convNext;

    public void SetConvNext(MethodSymbol conv) => this._convNext = conv;

    public PropertySymbol getProperty() => this._prop;

    public void SetProperty(PropertySymbol prop) => this._prop = prop;

    public EventSymbol getEvent() => this._evt;

    public void SetEvent(EventSymbol evt) => this._evt = evt;

    public new bool isUserCallable() => !this.isOperator && !this.isAnyAccessor();

    private bool isAnyAccessor() => this.isPropertyAccessor() || this.isEventAccessor();

    public bool isSetAccessor()
    {
      if (!this.isPropertyAccessor())
        return false;
      PropertySymbol property = this.getProperty();
      return property != null && this == property.SetterMethod;
    }
  }
}
