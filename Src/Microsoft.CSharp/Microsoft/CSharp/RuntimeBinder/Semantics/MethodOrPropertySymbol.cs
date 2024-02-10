// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.MethodOrPropertySymbol
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal abstract class MethodOrPropertySymbol : ParentSymbol
  {
    public uint modOptCount;
    public bool isStatic;
    public bool isOverride;
    public bool isOperator;
    public bool isParamArray;
    public bool isHideByName;
    private bool[] _optionalParameterIndex;
    private bool[] _defaultParameterIndex;
    private ConstVal[] _defaultParameters;
    private CType[] _defaultParameterConstValTypes;
    private bool[] _marshalAsIndex;
    private UnmanagedType[] _marshalAsBuffer;
    public SymWithType swtSlot;
    public CType RetType;
    private TypeArray _Params;

    public List<Name> ParameterNames { get; private set; }

    public TypeArray Params
    {
      get => this._Params;
      set
      {
        this._Params = value;
        int count = value.Count;
        if (count == 0)
        {
          this._optionalParameterIndex = this._defaultParameterIndex = this._marshalAsIndex = Array.Empty<bool>();
          this._defaultParameters = Array.Empty<ConstVal>();
          this._defaultParameterConstValTypes = Array.Empty<CType>();
          this._marshalAsBuffer = Array.Empty<UnmanagedType>();
        }
        else
        {
          this._optionalParameterIndex = new bool[count];
          this._defaultParameterIndex = new bool[count];
          this._defaultParameters = new ConstVal[count];
          this._defaultParameterConstValTypes = new CType[count];
          this._marshalAsIndex = new bool[count];
          this._marshalAsBuffer = new UnmanagedType[count];
        }
      }
    }

    public MethodOrPropertySymbol() => this.ParameterNames = new List<Name>();

    public bool IsParameterOptional(int index)
    {
      return this._optionalParameterIndex != null && this._optionalParameterIndex[index];
    }

    public void SetOptionalParameter(int index) => this._optionalParameterIndex[index] = true;

    public bool HasOptionalParameters()
    {
      if (this._optionalParameterIndex == null)
        return false;
      foreach (bool flag in this._optionalParameterIndex)
      {
        if (flag)
          return true;
      }
      return false;
    }

    public bool HasDefaultParameterValue(int index) => this._defaultParameterIndex[index];

    public void SetDefaultParameterValue(int index, CType type, ConstVal cv)
    {
      this._defaultParameterIndex[index] = true;
      this._defaultParameters[index] = cv;
      this._defaultParameterConstValTypes[index] = type;
    }

    public ConstVal GetDefaultParameterValue(int index) => this._defaultParameters[index];

    public CType GetDefaultParameterValueConstValType(int index)
    {
      return this._defaultParameterConstValTypes[index];
    }

    private bool IsMarshalAsParameter(int index) => this._marshalAsIndex[index];

    public void SetMarshalAsParameter(int index, UnmanagedType umt)
    {
      this._marshalAsIndex[index] = true;
      this._marshalAsBuffer[index] = umt;
    }

    private UnmanagedType GetMarshalAsParameterValue(int index) => this._marshalAsBuffer[index];

    public bool MarshalAsObject(int index)
    {
      if (!this.IsMarshalAsParameter(index))
        return false;
      UnmanagedType asParameterValue = this.GetMarshalAsParameterValue(index);
      switch (asParameterValue)
      {
        case UnmanagedType.IUnknown:
        case UnmanagedType.Interface:
          return true;
        default:
          return asParameterValue == UnmanagedType.IDispatch;
      }
    }

    public AggregateSymbol getClass() => this.parent as AggregateSymbol;

    public bool IsExpImpl() => this.name == null;
  }
}
