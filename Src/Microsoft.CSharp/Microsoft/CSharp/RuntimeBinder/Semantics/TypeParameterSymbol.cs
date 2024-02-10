// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.TypeParameterSymbol
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class TypeParameterSymbol : Symbol
  {
    private bool _bIsMethodTypeParameter;
    private SpecCons _constraints;
    private TypeParameterType _pTypeParameterType;
    private int _nIndexInOwnParameters;
    private int _nIndexInTotalParameters;
    private TypeArray _pBounds;
    public bool Covariant;
    public bool Contravariant;

    public bool Invariant => !this.Covariant && !this.Contravariant;

    public void SetTypeParameterType(TypeParameterType pType) => this._pTypeParameterType = pType;

    public TypeParameterType GetTypeParameterType() => this._pTypeParameterType;

    public bool IsMethodTypeParameter() => this._bIsMethodTypeParameter;

    public void SetIsMethodTypeParameter(bool b) => this._bIsMethodTypeParameter = b;

    public int GetIndexInOwnParameters() => this._nIndexInOwnParameters;

    public void SetIndexInOwnParameters(int index) => this._nIndexInOwnParameters = index;

    public int GetIndexInTotalParameters() => this._nIndexInTotalParameters;

    public void SetIndexInTotalParameters(int index) => this._nIndexInTotalParameters = index;

    public void SetBounds(TypeArray pBounds) => this._pBounds = pBounds;

    public TypeArray GetBounds() => this._pBounds;

    public void SetConstraints(SpecCons constraints) => this._constraints = constraints;

    public bool IsValueType() => (this._constraints & SpecCons.Val) > SpecCons.None;

    public bool IsReferenceType() => (this._constraints & SpecCons.Ref) > SpecCons.None;

    public bool IsNonNullableValueType() => (this._constraints & SpecCons.Val) > SpecCons.None;

    public bool HasNewConstraint() => (this._constraints & SpecCons.New) > SpecCons.None;

    public bool HasRefConstraint() => (this._constraints & SpecCons.Ref) > SpecCons.None;

    public bool HasValConstraint() => (this._constraints & SpecCons.Val) > SpecCons.None;
  }
}
