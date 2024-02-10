// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprConstant
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprConstant : ExprWithType
  {
    public ExprConstant(CType type, ConstVal value)
      : base(ExpressionKind.Constant, type)
    {
      this.Val = value;
    }

    public Expr OptionalConstructorCall { get; set; }

    public bool IsZero => this.Val.IsZero(this.Type.ConstValKind);

    public ConstVal Val { get; }

    public ulong UInt64Value => this.Val.UInt64Val;

    public long Int64Value
    {
      get
      {
        switch (this.Type.FundamentalType)
        {
          case FUNDTYPE.FT_U4:
            return (long) this.Val.UInt32Val;
          case FUNDTYPE.FT_I8:
          case FUNDTYPE.FT_U8:
            return this.Val.Int64Val;
          default:
            return (long) this.Val.Int32Val;
        }
      }
    }

    public override object Object
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        if (this.Type is NullType)
          return (object) null;
        object obj1;
        switch (System.Type.GetTypeCode(this.Type.AssociatedSystemType))
        {
          case TypeCode.Boolean:
            obj1 = (object) this.Val.BooleanVal;
            break;
          case TypeCode.Char:
            obj1 = (object) this.Val.CharVal;
            break;
          case TypeCode.SByte:
            obj1 = (object) this.Val.SByteVal;
            break;
          case TypeCode.Byte:
            obj1 = (object) this.Val.ByteVal;
            break;
          case TypeCode.Int16:
            obj1 = (object) this.Val.Int16Val;
            break;
          case TypeCode.UInt16:
            obj1 = (object) this.Val.UInt16Val;
            break;
          case TypeCode.Int32:
            obj1 = (object) this.Val.Int32Val;
            break;
          case TypeCode.UInt32:
            obj1 = (object) this.Val.UInt32Val;
            break;
          case TypeCode.Int64:
            obj1 = (object) this.Val.Int64Val;
            break;
          case TypeCode.UInt64:
            obj1 = (object) this.Val.UInt64Val;
            break;
          case TypeCode.Single:
            obj1 = (object) this.Val.SingleVal;
            break;
          case TypeCode.Double:
            obj1 = (object) this.Val.DoubleVal;
            break;
          case TypeCode.Decimal:
            obj1 = (object) this.Val.DecimalVal;
            break;
          case TypeCode.String:
            obj1 = (object) this.Val.StringVal;
            break;
          default:
            obj1 = this.Val.ObjectVal;
            break;
        }
        object obj2 = obj1;
        return !this.Type.IsEnumType ? obj2 : Enum.ToObject(this.Type.AssociatedSystemType, obj2);
      }
    }
  }
}
