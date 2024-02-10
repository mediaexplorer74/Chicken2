// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExpressionBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Errors;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal readonly struct ExpressionBinder
  {
    private static readonly byte[][] s_betterConversionTable = new byte[16][]
    {
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      }
    };
    private static readonly byte[][] s_simpleTypeConversions = new byte[13][]
    {
      new byte[13]
      {
        (byte) 1,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 1,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 2,
        (byte) 67,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 67,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 67,
        (byte) 67,
        (byte) 67,
        (byte) 67,
        (byte) 67,
        (byte) 67,
        (byte) 1,
        (byte) 67,
        (byte) 5,
        (byte) 67,
        (byte) 67,
        (byte) 67,
        (byte) 67
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 1,
        (byte) 5,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2
      },
      new byte[13]
      {
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 1,
        (byte) 5,
        (byte) 5,
        (byte) 5,
        (byte) 5
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 3
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 1,
        (byte) 2,
        (byte) 2
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 2
      },
      new byte[13]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 66,
        (byte) 3,
        (byte) 5,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1
      }
    };
    private static readonly byte[][] s_simpleTypeBetter = new byte[16][]
    {
      new byte[16]
      {
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 3,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 0,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 0,
        (byte) 3,
        (byte) 3,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 0,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 1,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 1,
        (byte) 1,
        (byte) 1,
        (byte) 2,
        (byte) 3,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 0,
        (byte) 3,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 0,
        (byte) 3,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 3,
        (byte) 0,
        (byte) 1
      },
      new byte[16]
      {
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 2,
        (byte) 0
      }
    };
    private static readonly PredefinedType[] s_rgptIntOp = new PredefinedType[4]
    {
      PredefinedType.PT_INT,
      PredefinedType.PT_UINT,
      PredefinedType.PT_LONG,
      PredefinedType.PT_ULONG
    };
    private static readonly PredefinedName[] s_EK2NAME = new PredefinedName[26]
    {
      PredefinedName.PN_OPEQUALS,
      PredefinedName.PN_OPCOMPARE,
      PredefinedName.PN_OPTRUE,
      PredefinedName.PN_OPFALSE,
      PredefinedName.PN_OPINCREMENT,
      PredefinedName.PN_OPDECREMENT,
      PredefinedName.PN_OPNEGATION,
      PredefinedName.PN_OPEQUALITY,
      PredefinedName.PN_OPINEQUALITY,
      PredefinedName.PN_OPLESSTHAN,
      PredefinedName.PN_OPLESSTHANOREQUAL,
      PredefinedName.PN_OPGREATERTHAN,
      PredefinedName.PN_OPGREATERTHANOREQUAL,
      PredefinedName.PN_OPPLUS,
      PredefinedName.PN_OPMINUS,
      PredefinedName.PN_OPMULTIPLY,
      PredefinedName.PN_OPDIVISION,
      PredefinedName.PN_OPMODULUS,
      PredefinedName.PN_OPUNARYMINUS,
      PredefinedName.PN_OPUNARYPLUS,
      PredefinedName.PN_OPBITWISEAND,
      PredefinedName.PN_OPBITWISEOR,
      PredefinedName.PN_OPXOR,
      PredefinedName.PN_OPCOMPLEMENT,
      PredefinedName.PN_OPLEFTSHIFT,
      PredefinedName.PN_OPRIGHTSHIFT
    };
    private static readonly ExpressionBinder.BinOpSig[] s_binopSignatures = new ExpressionBinder.BinOpSig[20]
    {
      new ExpressionBinder.BinOpSig(PredefinedType.PT_INT, PredefinedType.PT_INT, BinOpMask.Integer, 8, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindIntBinOp), OpSigFlags.Value, BinOpFuncKind.IntBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_UINT, PredefinedType.PT_UINT, BinOpMask.Integer, 7, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindIntBinOp), OpSigFlags.Value, BinOpFuncKind.IntBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_LONG, BinOpMask.Integer, 6, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindIntBinOp), OpSigFlags.Value, BinOpFuncKind.IntBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_ULONG, BinOpMask.Integer, 5, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindIntBinOp), OpSigFlags.Value, BinOpFuncKind.IntBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_LONG, BinOpMask.Integer, 4, (ExpressionBinder.PfnBindBinOp) null, OpSigFlags.Value, BinOpFuncKind.None),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_ULONG, BinOpMask.Integer, 3, (ExpressionBinder.PfnBindBinOp) null, OpSigFlags.Value, BinOpFuncKind.None),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_FLOAT, PredefinedType.PT_FLOAT, BinOpMask.Real, 1, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindRealBinOp), OpSigFlags.Value, BinOpFuncKind.RealBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_DOUBLE, PredefinedType.PT_DOUBLE, BinOpMask.Real, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindRealBinOp), OpSigFlags.Value, BinOpFuncKind.RealBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_DECIMAL, PredefinedType.PT_DECIMAL, BinOpMask.Real, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindDecBinOp), OpSigFlags.Value, BinOpFuncKind.DecBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_STRING, BinOpMask.Equal, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindStrCmpOp), OpSigFlags.Convert, BinOpFuncKind.StrCmpOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_STRING, BinOpMask.Add, 2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindStrBinOp), OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_OBJECT, BinOpMask.Add, 1, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindStrBinOp), OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_OBJECT, PredefinedType.PT_STRING, BinOpMask.Add, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindStrBinOp), OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_INT, PredefinedType.PT_INT, BinOpMask.Shift, 3, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindShiftOp), OpSigFlags.Value, BinOpFuncKind.ShiftOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_UINT, PredefinedType.PT_INT, BinOpMask.Shift, 2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindShiftOp), OpSigFlags.Value, BinOpFuncKind.ShiftOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_INT, BinOpMask.Shift, 1, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindShiftOp), OpSigFlags.Value, BinOpFuncKind.ShiftOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_INT, BinOpMask.Shift, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindShiftOp), OpSigFlags.Value, BinOpFuncKind.ShiftOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.BoolNorm, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindBoolBinOp), OpSigFlags.Value, BinOpFuncKind.BoolBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.Logical, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindBoolBinOp), OpSigFlags.BoolBit, BinOpFuncKind.BoolBinOp),
      new ExpressionBinder.BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.Bitwise, 0, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindLiftedBoolBitwiseOp), OpSigFlags.BoolBit, BinOpFuncKind.BoolBitwiseOp)
    };
    private static readonly ExpressionBinder.UnaOpSig[] s_rguos = new ExpressionBinder.UnaOpSig[16]
    {
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_INT, UnaOpMask.Signed, 7, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindIntUnaOp), UnaOpFuncKind.IntUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_UINT, UnaOpMask.Unsigned, 6, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindIntUnaOp), UnaOpFuncKind.IntUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_LONG, UnaOpMask.Signed, 5, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindIntUnaOp), UnaOpFuncKind.IntUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.Unsigned, 4, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindIntUnaOp), UnaOpFuncKind.IntUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.Minus, 3, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_FLOAT, UnaOpMask.Real, 1, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindRealUnaOp), UnaOpFuncKind.RealUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_DOUBLE, UnaOpMask.Real, 0, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindRealUnaOp), UnaOpFuncKind.RealUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_DECIMAL, UnaOpMask.Real, 0, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindDecUnaOp), UnaOpFuncKind.DecUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_BOOL, UnaOpMask.Bang, 0, new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindBoolUnaOp), UnaOpFuncKind.BoolUnaOp),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_INT, UnaOpMask.IncDec, 6, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_UINT, UnaOpMask.IncDec, 5, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_LONG, UnaOpMask.IncDec, 4, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.IncDec, 3, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_FLOAT, UnaOpMask.IncDec, 1, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_DOUBLE, UnaOpMask.IncDec, 0, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None),
      new ExpressionBinder.UnaOpSig(PredefinedType.PT_DECIMAL, UnaOpMask.IncDec, 0, (ExpressionBinder.PfnBindUnaOp) null, UnaOpFuncKind.None)
    };

    private static BetterType WhichMethodIsBetterTieBreaker(
      CandidateFunctionMember node1,
      CandidateFunctionMember node2,
      CType pTypeThrough,
      ArgInfos args)
    {
      MethPropWithInst mpwi1 = node1.mpwi;
      MethPropWithInst mpwi2 = node2.mpwi;
      if ((int) node1.ctypeLift != (int) node2.ctypeLift)
        return (int) node1.ctypeLift >= (int) node2.ctypeLift ? BetterType.Right : BetterType.Left;
      if (mpwi1.TypeArgs.Count != 0)
      {
        if (mpwi2.TypeArgs.Count == 0)
          return BetterType.Right;
      }
      else if (mpwi2.TypeArgs.Count != 0)
        return BetterType.Left;
      if (node1.fExpanded)
      {
        if (!node2.fExpanded)
          return BetterType.Right;
      }
      else if (node2.fExpanded)
        return BetterType.Left;
      BetterType betterType = ExpressionBinder.CompareTypes(ExpressionBinder.RearrangeNamedArguments(mpwi1.MethProp().Params, mpwi1, pTypeThrough, args), ExpressionBinder.RearrangeNamedArguments(mpwi2.MethProp().Params, mpwi2, pTypeThrough, args));
      switch (betterType)
      {
        case BetterType.Left:
        case BetterType.Right:
          return betterType;
        default:
          if ((int) mpwi1.MethProp().modOptCount == (int) mpwi2.MethProp().modOptCount)
            return BetterType.Neither;
          return mpwi1.MethProp().modOptCount >= mpwi2.MethProp().modOptCount ? BetterType.Right : BetterType.Left;
      }
    }

    private static BetterType CompareTypes(TypeArray ta1, TypeArray ta2)
    {
      if (ta1 == ta2)
        return BetterType.Same;
      if (ta1.Count != ta2.Count)
        return ta1.Count <= ta2.Count ? BetterType.Right : BetterType.Left;
      BetterType betterType1 = BetterType.Neither;
      for (int i = 0; i < ta1.Count; ++i)
      {
        CType parameterOrElementType1 = ta1[i];
        CType parameterOrElementType2 = ta2[i];
        BetterType betterType2 = BetterType.Neither;
        for (; parameterOrElementType1.TypeKind == parameterOrElementType2.TypeKind; parameterOrElementType2 = parameterOrElementType2.BaseOrParameterOrElementType)
        {
          switch (parameterOrElementType1.TypeKind)
          {
            case TypeKind.TK_AggregateType:
              betterType2 = ExpressionBinder.CompareTypes(((AggregateType) parameterOrElementType1).TypeArgsAll, ((AggregateType) parameterOrElementType2).TypeArgsAll);
              goto label_16;
            case TypeKind.TK_ArrayType:
            case TypeKind.TK_PointerType:
            case TypeKind.TK_ParameterModifierType:
            case TypeKind.TK_NullableType:
              parameterOrElementType1 = parameterOrElementType1.BaseOrParameterOrElementType;
              continue;
            default:
              goto label_16;
          }
        }
        if (parameterOrElementType1 is TypeParameterType)
          betterType2 = BetterType.Right;
        else if (parameterOrElementType2 is TypeParameterType)
          betterType2 = BetterType.Left;
label_16:
        if (betterType2 == BetterType.Right || betterType2 == BetterType.Left)
        {
          if (betterType1 == BetterType.Same || betterType1 == BetterType.Neither)
            betterType1 = betterType2;
          else if (betterType2 != betterType1)
            return BetterType.Neither;
        }
      }
      return betterType1;
    }

    private static int FindName(List<Name> names, Name name) => names.IndexOf(name);

    private static TypeArray RearrangeNamedArguments(
      TypeArray pta,
      MethPropWithInst mpwi,
      CType pTypeThrough,
      ArgInfos args)
    {
      if (args.carg == 0 || !(args.prgexpr[args.carg - 1] is ExprNamedArgumentSpecification))
        return pta;
      CType pType = pTypeThrough != null ? pTypeThrough : (CType) mpwi.GetType();
      CType[] ctypeArray = new CType[pta.Count];
      MethodOrPropertySymbol mostDerivedMethod = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(mpwi.MethProp(), pType);
      for (int i = 0; i < pta.Count; ++i)
        ctypeArray[i] = pta[i];
      List<Expr> prgexpr = args.prgexpr;
      for (int index1 = 0; index1 < args.carg; ++index1)
      {
        if (prgexpr[index1] is ExprNamedArgumentSpecification argumentSpecification)
        {
          int name = ExpressionBinder.FindName(mostDerivedMethod.ParameterNames, argumentSpecification.Name);
          CType ctype = pta[name];
          for (int index2 = index1; index2 < name; ++index2)
            ctypeArray[index2 + 1] = ctypeArray[index2];
          ctypeArray[index1] = ctype;
        }
      }
      return TypeArray.Allocate(ctypeArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BetterType WhichMethodIsBetter(
      CandidateFunctionMember node1,
      CandidateFunctionMember node2,
      CType pTypeThrough,
      ArgInfos args)
    {
      MethPropWithInst mpwi1 = node1.mpwi;
      MethPropWithInst mpwi2 = node2.mpwi;
      TypeArray typeArray1 = ExpressionBinder.RearrangeNamedArguments(node1.@params, mpwi1, pTypeThrough, args);
      TypeArray typeArray2 = ExpressionBinder.RearrangeNamedArguments(node2.@params, mpwi2, pTypeThrough, args);
      if (typeArray1 == typeArray2)
        return ExpressionBinder.WhichMethodIsBetterTieBreaker(node1, node2, pTypeThrough, args);
      BetterType betterType1 = BetterType.Neither;
      int carg = args.carg;
      for (int index = 0; index < carg; ++index)
      {
        Expr expr = args.prgexpr[index];
        CType p1 = typeArray1[index];
        CType p2 = typeArray2[index];
        BetterType betterType2 = this.WhichConversionIsBetter(expr?.RuntimeObjectActualType ?? args.types[index], p1, p2);
        switch (betterType1)
        {
          case BetterType.Left:
            if (betterType2 == BetterType.Right)
            {
              betterType1 = BetterType.Neither;
              goto label_12;
            }
            else
              break;
          case BetterType.Right:
            if (betterType2 == BetterType.Left)
            {
              betterType1 = BetterType.Neither;
              goto label_12;
            }
            else
              break;
          default:
            if (betterType2 == BetterType.Right || betterType2 == BetterType.Left)
            {
              betterType1 = betterType2;
              break;
            }
            break;
        }
      }
label_12:
      if (typeArray1.Count == typeArray2.Count || betterType1 != BetterType.Neither)
        return betterType1;
      if (node1.fExpanded)
      {
        if (!node2.fExpanded)
          return BetterType.Right;
      }
      else if (node2.fExpanded)
        return BetterType.Left;
      if (typeArray1.Count == carg)
        return BetterType.Left;
      return typeArray2.Count == carg ? BetterType.Right : BetterType.Neither;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BetterType WhichConversionIsBetter(CType argType, CType p1, CType p2)
    {
      if (p1 == p2)
        return BetterType.Same;
      if (argType == p1)
        return BetterType.Left;
      if (argType == p2)
        return BetterType.Right;
      bool flag1 = this.canConvert(p1, p2);
      bool flag2 = this.canConvert(p2, p1);
      if (flag1 != flag2)
        return !flag1 ? BetterType.Right : BetterType.Left;
      if (p1.IsPredefined && p2.IsPredefined)
      {
        PredefinedType predefinedType1 = p1.PredefinedType;
        if (predefinedType1 <= PredefinedType.PT_OBJECT)
        {
          PredefinedType predefinedType2 = p2.PredefinedType;
          if (predefinedType2 <= PredefinedType.PT_OBJECT)
            return (BetterType) ExpressionBinder.s_betterConversionTable[(int) predefinedType1][(int) predefinedType2];
        }
      }
      return BetterType.Neither;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private CandidateFunctionMember FindBestMethod(
      List<CandidateFunctionMember> list,
      CType pTypeThrough,
      ArgInfos args,
      out CandidateFunctionMember methAmbig1,
      out CandidateFunctionMember methAmbig2)
    {
      CandidateFunctionMember candidateFunctionMember1 = (CandidateFunctionMember) null;
      CandidateFunctionMember candidateFunctionMember2 = (CandidateFunctionMember) null;
      bool flag = false;
      CandidateFunctionMember bestMethod = list[0];
      for (int index = 1; index < list.Count; ++index)
      {
        CandidateFunctionMember node2 = list[index];
        switch (this.WhichMethodIsBetter(bestMethod, node2, pTypeThrough, args))
        {
          case BetterType.Left:
            flag = false;
            break;
          case BetterType.Right:
            flag = false;
            bestMethod = node2;
            break;
          default:
            candidateFunctionMember1 = bestMethod;
            candidateFunctionMember2 = node2;
            ++index;
            if (index < list.Count)
            {
              bestMethod = list[index];
              break;
            }
            flag = true;
            break;
        }
      }
      if (!flag)
      {
        foreach (CandidateFunctionMember node1 in list)
        {
          if (node1 == bestMethod)
          {
            methAmbig1 = (CandidateFunctionMember) null;
            methAmbig2 = (CandidateFunctionMember) null;
            return bestMethod;
          }
          switch (this.WhichMethodIsBetter(node1, bestMethod, pTypeThrough, args))
          {
            case BetterType.Same:
            case BetterType.Neither:
              candidateFunctionMember1 = bestMethod;
              candidateFunctionMember2 = node1;
              goto label_18;
            case BetterType.Right:
              continue;
            default:
              goto label_18;
          }
        }
      }
label_18:
      if (candidateFunctionMember1 != null & candidateFunctionMember2 != null)
      {
        methAmbig1 = candidateFunctionMember1;
        methAmbig2 = candidateFunctionMember2;
      }
      else
      {
        methAmbig1 = list[0];
        methAmbig2 = list[1];
      }
      return (CandidateFunctionMember) null;
    }

    private static void RoundToFloat(double d, out float f) => f = (float) d;

    private static long I64(long x) => x;

    private static long I64(ulong x) => (long) x;

    private static ConvKind GetConvKind(PredefinedType ptSrc, PredefinedType ptDst)
    {
      if ((int) ptSrc < 13 && (int) ptDst < 13)
        return (ConvKind) ((int) ExpressionBinder.s_simpleTypeConversions[(int) ptSrc][(int) ptDst] & 15);
      if (ptSrc == ptDst || ptDst == PredefinedType.PT_OBJECT && ptSrc < PredefinedType.PT_COUNT)
        return ConvKind.Implicit;
      return ptSrc == PredefinedType.PT_OBJECT && ptDst < PredefinedType.PT_COUNT ? ConvKind.Explicit : ConvKind.Unknown;
    }

    private static bool isUserDefinedConversion(PredefinedType ptSrc, PredefinedType ptDst)
    {
      return (int) ptSrc < 13 && (int) ptDst < 13 && ((uint) ExpressionBinder.s_simpleTypeConversions[(int) ptSrc][(int) ptDst] & 64U) > 0U;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BetterType WhichSimpleConversionIsBetter(PredefinedType pt1, PredefinedType pt2)
    {
      return (BetterType) ExpressionBinder.s_simpleTypeBetter[(int) pt1][(int) pt2];
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BetterType WhichTypeIsBetter(PredefinedType pt1, PredefinedType pt2, CType typeGiven)
    {
      if (pt1 == pt2)
        return BetterType.Same;
      if (typeGiven.IsPredefType(pt1))
        return BetterType.Left;
      if (typeGiven.IsPredefType(pt2))
        return BetterType.Right;
      if ((int) pt1 < 16 && (int) pt2 < 16)
        return this.WhichSimpleConversionIsBetter(pt1, pt2);
      if (pt2 == PredefinedType.PT_OBJECT && pt1 < PredefinedType.PT_COUNT)
        return BetterType.Left;
      return pt1 == PredefinedType.PT_OBJECT && pt2 < PredefinedType.PT_COUNT ? BetterType.Right : this.WhichTypeIsBetter((CType) ExpressionBinder.GetPredefindType(pt1), (CType) ExpressionBinder.GetPredefindType(pt2), typeGiven);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BetterType WhichTypeIsBetter(CType type1, CType type2, CType typeGiven)
    {
      if (type1 == type2)
        return BetterType.Same;
      if (typeGiven == type1)
        return BetterType.Left;
      if (typeGiven == type2)
        return BetterType.Right;
      bool flag1 = this.canConvert(type1, type2);
      bool flag2 = this.canConvert(type2, type1);
      if (flag1 != flag2)
        return !flag1 ? BetterType.Right : BetterType.Left;
      if (!(type1 is NullableType nullableType1) || !(type2 is NullableType nullableType2) || !nullableType1.UnderlyingType.IsPredefined || !nullableType2.UnderlyingType.IsPredefined)
        return BetterType.Neither;
      PredefinedType predefinedType1 = (type1 as NullableType).UnderlyingType.PredefinedType;
      PredefinedType predefinedType2 = (type2 as NullableType).UnderlyingType.PredefinedType;
      return (int) predefinedType1 < 16 && (int) predefinedType2 < 16 ? this.WhichSimpleConversionIsBetter(predefinedType1, predefinedType2) : BetterType.Neither;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool canConvert(CType src, CType dest, CONVERTTYPE flags)
    {
      return this.BindImplicitConversion((Expr) null, src, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public bool canConvert(CType src, CType dest) => this.canConvert(src, dest, (CONVERTTYPE) 0);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool canConvert(Expr expr, CType dest) => this.canConvert(expr, dest, (CONVERTTYPE) 0);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool canConvert(Expr expr, CType dest, CONVERTTYPE flags)
    {
      return this.BindImplicitConversion(expr, expr.Type, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr mustConvertCore(Expr expr, CType destExpr)
    {
      return this.mustConvertCore(expr, destExpr, (CONVERTTYPE) 0);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr mustConvertCore(Expr expr, CType dest, CONVERTTYPE flags)
    {
      Expr ppDestinationExpr;
      if (this.BindImplicitConversion(expr, expr.Type, dest, out ppDestinationExpr, flags))
      {
        ExpressionBinder.CheckUnsafe(expr.Type);
        ExpressionBinder.CheckUnsafe(dest);
        return ppDestinationExpr;
      }
      FUNDTYPE fundamentalType1 = expr.Type.FundamentalType;
      FUNDTYPE fundamentalType2 = dest.FundamentalType;
      if (expr is ExprConstant exprConstant && expr.Type.IsSimpleType && dest.IsSimpleType && (fundamentalType1 == FUNDTYPE.FT_I4 && (fundamentalType2 <= FUNDTYPE.FT_U4 || fundamentalType2 == FUNDTYPE.FT_U8) || fundamentalType1 == FUNDTYPE.FT_I8 && fundamentalType2 == FUNDTYPE.FT_U8))
        throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRange, (ErrArg) exprConstant.Int64Value.ToString((IFormatProvider) CultureInfo.InvariantCulture), (ErrArg) dest);
      if (expr.Type is NullType && dest.FundamentalType != FUNDTYPE.FT_REF)
        throw ErrorHandling.Error(ErrorCode.ERR_ValueCantBeNull, (ErrArg) dest);
      throw ErrorHandling.Error((ErrorCode) (this.canCast(expr.Type, dest, flags) ? 266 : 29), new ErrArg(expr.Type, ErrArgFlags.Unique), new ErrArg(dest, ErrArgFlags.Unique));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr tryConvert(Expr expr, CType dest) => this.tryConvert(expr, dest, (CONVERTTYPE) 0);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr tryConvert(Expr expr, CType dest, CONVERTTYPE flags)
    {
      Expr ppDestinationExpr;
      if (!this.BindImplicitConversion(expr, expr.Type, dest, out ppDestinationExpr, flags))
        return (Expr) null;
      ExpressionBinder.CheckUnsafe(expr.Type);
      ExpressionBinder.CheckUnsafe(dest);
      return ppDestinationExpr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr mustConvert(Expr expr, CType dest) => this.mustConvert(expr, dest, (CONVERTTYPE) 0);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr mustConvert(Expr expr, CType dest, CONVERTTYPE flags)
    {
      return this.mustConvertCore(expr, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr mustCastCore(Expr expr, CType dest, CONVERTTYPE flags)
    {
      CSemanticChecker.CheckForStaticClass(dest);
      Expr ppDestinationExpr;
      if (this.BindExplicitConversion(expr, expr.Type, dest, out ppDestinationExpr, flags))
      {
        ExpressionBinder.CheckUnsafe(expr.Type);
        ExpressionBinder.CheckUnsafe(dest);
        return ppDestinationExpr;
      }
      Expr expr1 = expr.GetConst();
      if (expr1 != null && expr.Type.IsSimpleOrEnum && dest.IsSimpleOrEnum)
      {
        FUNDTYPE fundamentalType = expr.Type.FundamentalType;
        if (fundamentalType == FUNDTYPE.FT_STRUCT)
          throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRange, (ErrArg) ((ExprConstant) expr1).Val.DecimalVal.ToString((IFormatProvider) CultureInfo.InvariantCulture), (ErrArg) dest);
        if (this.Context.Checked)
        {
          if (!this.CanExplicitConversionBeBoundInUncheckedContext(expr, expr.Type, dest, flags | CONVERTTYPE.NOUDC))
            throw ExpressionBinder.CantConvert(expr, dest);
          string str;
          switch (fundamentalType)
          {
            case FUNDTYPE.FT_I1:
            case FUNDTYPE.FT_I2:
            case FUNDTYPE.FT_I4:
            case FUNDTYPE.FT_I8:
              str = ((ExprConstant) expr1).Int64Value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
              break;
            case FUNDTYPE.FT_U1:
            case FUNDTYPE.FT_U2:
            case FUNDTYPE.FT_U4:
            case FUNDTYPE.FT_U8:
              str = ((ulong) ((ExprConstant) expr1).Int64Value).ToString((IFormatProvider) CultureInfo.InvariantCulture);
              break;
            default:
              str = ((ExprConstant) expr1).Val.DoubleVal.ToString((IFormatProvider) CultureInfo.InvariantCulture);
              break;
          }
          throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRangeChecked, (ErrArg) str, (ErrArg) dest);
        }
      }
      if (expr.Type is NullType && dest.FundamentalType != FUNDTYPE.FT_REF)
        throw ErrorHandling.Error(ErrorCode.ERR_ValueCantBeNull, (ErrArg) dest);
      throw ExpressionBinder.CantConvert(expr, dest);
    }

    private static RuntimeBinderException CantConvert(Expr expr, CType dest)
    {
      return ErrorHandling.Error(ErrorCode.ERR_NoExplicitConv, new ErrArg(expr.Type, ErrArgFlags.Unique), new ErrArg(dest, ErrArgFlags.Unique));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr mustCast(Expr expr, CType dest) => this.mustCast(expr, dest, (CONVERTTYPE) 0);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr mustCast(Expr expr, CType dest, CONVERTTYPE flags)
    {
      return this.mustCastCore(expr, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr MustCastInUncheckedContext(Expr expr, CType dest, CONVERTTYPE flags)
    {
      return new ExpressionBinder(new BindingContext(this.Context)).mustCast(expr, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool canCast(CType src, CType dest, CONVERTTYPE flags)
    {
      return this.BindExplicitConversion((Expr) null, src, dest, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindImplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      CONVERTTYPE flags)
    {
      return new ExpressionBinder.ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, false, flags).Bind();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindImplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      out Expr ppDestinationExpr,
      CONVERTTYPE flags)
    {
      ExpressionBinder.ImplicitConversion implicitConversion = new ExpressionBinder.ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, true, flags);
      bool flag = implicitConversion.Bind();
      ppDestinationExpr = implicitConversion.ExprDest;
      return flag;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindImplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      bool needsExprDest,
      out Expr ppDestinationExpr,
      CONVERTTYPE flags)
    {
      ExpressionBinder.ImplicitConversion implicitConversion = new ExpressionBinder.ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest, flags);
      bool flag = implicitConversion.Bind();
      ppDestinationExpr = needsExprDest ? implicitConversion.ExprDest : (Expr) null;
      return flag;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindExplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      bool needsExprDest,
      out Expr ppDestinationExpr,
      CONVERTTYPE flags)
    {
      ExpressionBinder.ExplicitConversion explicitConversion = new ExpressionBinder.ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest, flags);
      bool flag = explicitConversion.Bind();
      ppDestinationExpr = needsExprDest ? explicitConversion.ExprDest : (Expr) null;
      return flag;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindExplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      out Expr ppDestinationExpr,
      CONVERTTYPE flags)
    {
      ExpressionBinder.ExplicitConversion explicitConversion = new ExpressionBinder.ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, true, flags);
      bool flag = explicitConversion.Bind();
      ppDestinationExpr = explicitConversion.ExprDest;
      return flag;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool BindExplicitConversion(
      Expr pSourceExpr,
      CType pSourceType,
      CType destinationType,
      CONVERTTYPE flags)
    {
      return new ExpressionBinder.ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, false, flags).Bind();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool bindUserDefinedConversion(
      Expr exprSrc,
      CType typeSrc,
      CType typeDst,
      bool needExprDest,
      out Expr pexprDst,
      bool fImplicitOnly)
    {
      pexprDst = (Expr) null;
      if (typeSrc == null || typeDst == null || typeSrc.IsInterfaceType || typeDst.IsInterfaceType)
        return false;
      CType ctype1 = typeSrc.StripNubs();
      CType ctype2 = typeDst.StripNubs();
      bool flag1 = ctype1 != typeSrc;
      bool flag2 = ctype2 != typeDst;
      bool flag3 = flag2 || typeDst.IsReferenceType || typeDst is PointerType;
      AggregateType[] aggregateTypeArray = new AggregateType[2];
      int num1 = 0;
      bool flag4 = fImplicitOnly;
      bool flag5 = false;
      if (ctype1 is AggregateType aggregateType1 && aggregateType1.OwningAggregate.HasConversion())
      {
        aggregateTypeArray[num1++] = aggregateType1;
        flag5 = aggregateType1.IsPredefType(PredefinedType.FirstNonSimpleType) || aggregateType1.IsPredefType(PredefinedType.PT_UINTPTR);
      }
      if (ctype2 is AggregateType aggregateType2)
      {
        if (aggregateType2.OwningAggregate.HasConversion())
          aggregateTypeArray[num1++] = aggregateType2;
        if (flag5 && !ctype2.IsPredefType(PredefinedType.PT_LONG) && !ctype2.IsPredefType(PredefinedType.PT_ULONG))
          flag5 = false;
      }
      else
        flag5 = false;
      if (num1 == 0)
        return false;
      List<UdConvInfo> udConvInfoList = new List<UdConvInfo>();
      CType type1_1 = (CType) null;
      CType type1_2 = (CType) null;
      bool flag6 = false;
      bool flag7 = false;
      int num2 = -1;
      int num3 = -1;
      for (int index = 0; index < num1; ++index)
      {
        for (AggregateType baseClass = aggregateTypeArray[index]; baseClass != null && baseClass.OwningAggregate.HasConversion(); baseClass = baseClass.BaseClass)
        {
          AggregateSymbol owningAggregate = baseClass.OwningAggregate;
          PredefinedType predefType = owningAggregate.GetPredefType();
          bool flag8 = owningAggregate.IsPredefined() && (predefType == PredefinedType.FirstNonSimpleType || predefType == PredefinedType.PT_UINTPTR || predefType == PredefinedType.PT_DECIMAL);
          for (MethodSymbol meth = owningAggregate.GetFirstUDConversion(); meth != null; meth = meth.ConvNext())
          {
            if (meth.Params.Count == 1 && (!fImplicitOnly || meth.isImplicit()))
            {
              CType ctype3 = TypeManager.SubstType(meth.Params[0], baseClass);
              CType ctype4 = TypeManager.SubstType(meth.RetType, baseClass);
              bool flag9 = fImplicitOnly;
              if (flag4 && !flag9 && ctype3.StripNubs() != ctype1)
              {
                if (meth.isImplicit())
                  flag9 = true;
                else
                  continue;
              }
              FUNDTYPE fundamentalType1;
              FUNDTYPE fundamentalType2;
              if (((fundamentalType1 = ctype4.FundamentalType) > FUNDTYPE.FT_R8 || fundamentalType1 <= FUNDTYPE.FT_NONE || (fundamentalType2 = ctype3.FundamentalType) > FUNDTYPE.FT_R8 || fundamentalType2 <= FUNDTYPE.FT_NONE) && (!flag5 || !ctype4.IsPredefType(PredefinedType.PT_INT) && !ctype4.IsPredefType(PredefinedType.PT_UINT)))
              {
                if (flag1 && (flag3 || !flag9) && ctype3.IsNonNullableValueType)
                  ctype3 = (CType) TypeManager.GetNullable(ctype3);
                if (flag2 && ctype4.IsNonNullableValueType)
                  ctype4 = (CType) TypeManager.GetNullable(ctype4);
                bool flag10 = exprSrc != null ? this.canConvert(exprSrc, ctype3, CONVERTTYPE.STANDARDANDNOUDC) : this.canConvert(typeSrc, ctype3, CONVERTTYPE.STANDARDANDNOUDC);
                if (flag10 || !flag9 && (this.canConvert(ctype3, typeSrc, CONVERTTYPE.STANDARDANDNOUDC) || flag8 && !(typeSrc is PointerType) && !(ctype3 is PointerType) && this.canCast(typeSrc, ctype3, CONVERTTYPE.NOUDC)))
                {
                  bool flag11 = this.canConvert(ctype4, typeDst, CONVERTTYPE.STANDARDANDNOUDC);
                  if ((flag11 || !flag9 && (this.canConvert(typeDst, ctype4, CONVERTTYPE.STANDARDANDNOUDC) || flag8 && !(typeDst is PointerType) && !(ctype4 is PointerType) && this.canCast(ctype4, typeDst, CONVERTTYPE.NOUDC))) && !ExpressionBinder.IsConvInTable(udConvInfoList, meth, baseClass, flag10, flag11))
                  {
                    udConvInfoList.Add(new UdConvInfo(new MethWithType(meth, baseClass), flag10, flag11));
                    if (!flag6)
                    {
                      if (ctype3 == typeSrc)
                      {
                        type1_1 = ctype3;
                        num2 = udConvInfoList.Count - 1;
                        flag6 = true;
                      }
                      else if (type1_1 == null)
                      {
                        type1_1 = ctype3;
                        num2 = udConvInfoList.Count - 1;
                      }
                      else if (type1_1 != ctype3 && this.CompareSrcTypesBased(type1_1, udConvInfoList[num2].SrcImplicit, ctype3, flag10) > 0)
                      {
                        type1_1 = ctype3;
                        num2 = udConvInfoList.Count - 1;
                      }
                    }
                    if (!flag7)
                    {
                      if (ctype4 == typeDst)
                      {
                        type1_2 = ctype4;
                        num3 = udConvInfoList.Count - 1;
                        flag7 = true;
                      }
                      else if (type1_2 == null)
                      {
                        type1_2 = ctype4;
                        num3 = udConvInfoList.Count - 1;
                      }
                      else if (type1_2 != ctype4 && this.CompareDstTypesBased(type1_2, udConvInfoList[num3].DstImplicit, ctype4, flag11) > 0)
                      {
                        type1_2 = ctype4;
                        num3 = udConvInfoList.Count - 1;
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      if (type1_1 == null)
        return false;
      int num4 = 3;
      int num5 = -1;
      int iuciBestDst = -1;
      for (int index = 0; index < udConvInfoList.Count; ++index)
      {
        UdConvInfo udConvInfo = udConvInfoList[index];
        CType ctype5 = TypeManager.SubstType(udConvInfo.Meth.Meth().Params[0], udConvInfo.Meth.GetType());
        CType ctype6 = TypeManager.SubstType(udConvInfo.Meth.Meth().RetType, udConvInfo.Meth.GetType());
        int num6 = 0;
        if (flag1 && ctype5.IsNonNullableValueType)
        {
          ctype5 = (CType) TypeManager.GetNullable(ctype5);
          ++num6;
        }
        if (flag2 && ctype6.IsNonNullableValueType)
        {
          ctype6 = (CType) TypeManager.GetNullable(ctype6);
          ++num6;
        }
        if (ctype5 == type1_1 && ctype6 == type1_2)
        {
          if (num4 > num6)
          {
            num5 = index;
            iuciBestDst = -1;
            num4 = num6;
          }
          else if (num4 >= num6 && iuciBestDst < 0)
          {
            iuciBestDst = index;
            if (num6 == 0)
              break;
          }
        }
        else
        {
          if (!flag6 && ctype5 != type1_1 && this.CompareSrcTypesBased(type1_1, udConvInfoList[num2].SrcImplicit, ctype5, udConvInfo.SrcImplicit) >= 0)
          {
            if (needExprDest)
              throw ExpressionBinder.HandleAmbiguity(typeSrc, typeDst, udConvInfoList, num2, index);
            return true;
          }
          if (!flag7 && ctype6 != type1_2 && this.CompareDstTypesBased(type1_2, udConvInfoList[num3].DstImplicit, ctype6, udConvInfo.DstImplicit) >= 0)
          {
            if (needExprDest)
              throw ExpressionBinder.HandleAmbiguity(typeSrc, typeDst, udConvInfoList, num2, index);
            return true;
          }
        }
      }
      if (!needExprDest)
        return true;
      if (num5 < 0)
        throw ExpressionBinder.HandleAmbiguity(typeSrc, typeDst, udConvInfoList, num2, num3);
      if (iuciBestDst >= 0)
        throw ExpressionBinder.HandleAmbiguity(typeSrc, typeDst, udConvInfoList, num5, iuciBestDst);
      MethWithInst methWithInst = new MethWithInst(udConvInfoList[num5].Meth.Meth(), udConvInfoList[num5].Meth.GetType(), (TypeArray) null);
      CType ctype7 = TypeManager.SubstType(methWithInst.Meth().Params[0], methWithInst.GetType());
      CType pTypeTo = TypeManager.SubstType(methWithInst.Meth().RetType, methWithInst.GetType());
      Expr ppTransformedArgument = exprSrc;
      Expr call1;
      if (((num4 <= 0 ? 0 : (!(ctype7 is NullableType) ? 1 : 0)) & (flag3 ? 1 : 0)) != 0)
      {
        ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) methWithInst);
        ExprCall call2 = ExprFactory.CreateCall((EXPRFLAG) 0, typeDst, exprSrc, memGroup, methWithInst);
        call1 = (Expr) call2;
        Expr expr1 = this.mustCast(exprSrc, ctype7);
        ExpressionBinder.MarkAsIntermediateConversion(expr1);
        Expr expr2 = this.BindUDConversionCore(expr1, ctype7, pTypeTo, typeDst, methWithInst);
        call2.CastOfNonLiftedResultToLiftedType = this.mustCast(expr2, typeDst);
        call2.NullableCallLiftKind = NullableCallLiftKind.UserDefinedConversion;
        if (flag1)
        {
          Expr expr3;
          if (ctype7 != ctype1)
          {
            NullableType nullable = TypeManager.GetNullable(ctype7);
            expr3 = this.mustCast(exprSrc, (CType) nullable);
            ExpressionBinder.MarkAsIntermediateConversion(expr3);
          }
          else
            expr3 = !(pTypeTo is NullableType) ? exprSrc : this.mustCast(exprSrc, ctype7);
          ExprCall call3 = ExprFactory.CreateCall((EXPRFLAG) 0, typeDst, expr3, memGroup, methWithInst);
          call3.NullableCallLiftKind = NullableCallLiftKind.NotLiftedIntermediateConversion;
          call2.PConversions = (Expr) call3;
        }
        else
        {
          Expr pExpr = this.BindUDConversionCore(expr1, ctype7, pTypeTo, typeDst, methWithInst);
          ExpressionBinder.MarkAsIntermediateConversion(pExpr);
          call2.PConversions = pExpr;
        }
      }
      else
        call1 = this.BindUDConversionCore(exprSrc, ctype7, pTypeTo, typeDst, methWithInst, out ppTransformedArgument);
      pexprDst = (Expr) ExprFactory.CreateUserDefinedConversion(ppTransformedArgument, call1, methWithInst);
      return true;
    }

    private static RuntimeBinderException HandleAmbiguity(
      CType typeSrc,
      CType typeDst,
      List<UdConvInfo> prguci,
      int iuciBestSrc,
      int iuciBestDst)
    {
      return ErrorHandling.Error(ErrorCode.ERR_AmbigUDConv, (ErrArg) (SymWithType) prguci[iuciBestSrc].Meth, (ErrArg) (SymWithType) prguci[iuciBestDst].Meth, (ErrArg) typeSrc, (ErrArg) typeDst);
    }

    private static void MarkAsIntermediateConversion(Expr pExpr)
    {
      while (true)
      {
        switch (pExpr)
        {
          case ExprCall exprCall:
            switch (exprCall.NullableCallLiftKind)
            {
              case NullableCallLiftKind.NotLifted:
                goto label_3;
              case NullableCallLiftKind.NullableConversion:
                goto label_4;
              case NullableCallLiftKind.NullableConversionConstructor:
                pExpr = exprCall.OptionalArguments;
                continue;
              default:
                goto label_7;
            }
          case ExprUserDefinedConversion definedConversion:
            pExpr = definedConversion.UserDefinedCall;
            continue;
          default:
            goto label_2;
        }
      }
label_7:
      return;
label_3:
      exprCall.NullableCallLiftKind = NullableCallLiftKind.NotLiftedIntermediateConversion;
      return;
label_4:
      exprCall.NullableCallLiftKind = NullableCallLiftKind.NullableIntermediateConversion;
      return;
label_2:;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindUDConversionCore(
      Expr pFrom,
      CType pTypeFrom,
      CType pTypeTo,
      CType pTypeDestination,
      MethWithInst mwiBest)
    {
      return this.BindUDConversionCore(pFrom, pTypeFrom, pTypeTo, pTypeDestination, mwiBest, out Expr _);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindUDConversionCore(
      Expr pFrom,
      CType pTypeFrom,
      CType pTypeTo,
      CType pTypeDestination,
      MethWithInst mwiBest,
      out Expr ppTransformedArgument)
    {
      Expr arguments = this.mustCastCore(pFrom, pTypeFrom, CONVERTTYPE.NOUDC);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) mwiBest);
      Expr expr = this.mustCastCore((Expr) ExprFactory.CreateCall((EXPRFLAG) 0, pTypeTo, arguments, memGroup, mwiBest), pTypeDestination, CONVERTTYPE.NOUDC);
      ppTransformedArgument = arguments;
      return expr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ConstCastResult bindConstantCast(
      Expr exprSrc,
      CType typeDest,
      bool needExprDest,
      out Expr pexprDest,
      bool explicitConversion)
    {
      pexprDest = (Expr) null;
      long num = 0;
      double d = 0.0;
      FUNDTYPE fundamentalType1 = exprSrc.Type.FundamentalType;
      FUNDTYPE fundamentalType2 = typeDest.FundamentalType;
      bool flag1 = fundamentalType1 <= FUNDTYPE.FT_U8;
      bool flag2 = fundamentalType1 <= FUNDTYPE.FT_R8;
      ExprConstant exprConstant = (ExprConstant) exprSrc.GetConst();
      if (fundamentalType1 == FUNDTYPE.FT_STRUCT || fundamentalType2 == FUNDTYPE.FT_STRUCT)
      {
        Expr expr = ExpressionBinder.BindDecimalConstCast(typeDest, exprSrc.Type, exprConstant);
        if (expr == null)
          return explicitConversion ? ConstCastResult.CheckFailure : ConstCastResult.Failure;
        if (needExprDest)
          pexprDest = expr;
        return ConstCastResult.Success;
      }
      if (explicitConversion && this.Context.Checked && !ExpressionBinder.isConstantInRange(exprConstant, typeDest, true))
        return ConstCastResult.CheckFailure;
      if (!needExprDest)
        return ConstCastResult.Success;
      if (flag1)
      {
        if (exprConstant.Type.FundamentalType == FUNDTYPE.FT_U8)
        {
          if (fundamentalType2 == FUNDTYPE.FT_U8)
          {
            ConstVal constVal = ConstVal.Get(exprConstant.UInt64Value);
            pexprDest = (Expr) ExprFactory.CreateConstant(typeDest, constVal);
            return ConstCastResult.Success;
          }
          num = (long) exprConstant.UInt64Value & -1L;
        }
        else
          num = exprConstant.Int64Value;
      }
      else
      {
        if (!flag2)
          return ConstCastResult.Failure;
        d = exprConstant.Val.DoubleVal;
      }
      switch (fundamentalType2)
      {
        case FUNDTYPE.FT_I1:
          if (!flag1)
            num = (long) d;
          num = (long) (sbyte) (num & (long) byte.MaxValue);
          break;
        case FUNDTYPE.FT_I2:
          if (!flag1)
            num = (long) d;
          num = (long) (short) (num & (long) ushort.MaxValue);
          break;
        case FUNDTYPE.FT_I4:
          if (!flag1)
            num = (long) d;
          num = (long) (int) (num & (long) uint.MaxValue);
          break;
        case FUNDTYPE.FT_U1:
          if (!flag1)
            num = (long) d;
          num = (long) (byte) ((ulong) num & (ulong) byte.MaxValue);
          break;
        case FUNDTYPE.FT_U2:
          if (!flag1)
            num = (long) d;
          num = (long) (ushort) ((ulong) num & (ulong) ushort.MaxValue);
          break;
        case FUNDTYPE.FT_U4:
          if (!flag1)
            num = (long) d;
          num = (long) (uint) ((ulong) num & (ulong) uint.MaxValue);
          break;
        case FUNDTYPE.FT_I8:
          if (!flag1)
          {
            num = (long) d;
            break;
          }
          break;
        case FUNDTYPE.FT_U8:
          if (!flag1)
          {
            num = d >= (double) long.MaxValue ? (long) (d - (double) long.MaxValue) + ExpressionBinder.I64(9223372036854775808UL) : (long) d;
            break;
          }
          break;
        case FUNDTYPE.FT_R4:
        case FUNDTYPE.FT_R8:
          if (flag1)
            d = fundamentalType1 != FUNDTYPE.FT_U8 ? (double) num : (double) (ulong) num;
          if (fundamentalType2 == FUNDTYPE.FT_R4)
          {
            float f;
            ExpressionBinder.RoundToFloat(d, out f);
            d = (double) f;
            break;
          }
          break;
      }
      ConstVal constVal1 = fundamentalType2 != FUNDTYPE.FT_U4 ? (fundamentalType2 > FUNDTYPE.FT_U4 ? (fundamentalType2 > FUNDTYPE.FT_U8 ? ConstVal.Get(d) : ConstVal.Get(num)) : ConstVal.Get((int) num)) : ConstVal.Get((uint) num);
      ExprConstant constant = ExprFactory.CreateConstant(typeDest, constVal1);
      pexprDest = (Expr) constant;
      return ConstCastResult.Success;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private int CompareSrcTypesBased(CType type1, bool fImplicit1, CType type2, bool fImplicit2)
    {
      if (fImplicit1 != fImplicit2)
        return !fImplicit1 ? 1 : -1;
      bool flag1 = this.canConvert(type1, type2, CONVERTTYPE.NOUDC);
      bool flag2 = this.canConvert(type2, type1, CONVERTTYPE.NOUDC);
      if (flag1 == flag2)
        return 0;
      return fImplicit1 != flag1 ? 1 : -1;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private int CompareDstTypesBased(CType type1, bool fImplicit1, CType type2, bool fImplicit2)
    {
      if (fImplicit1 != fImplicit2)
        return !fImplicit1 ? 1 : -1;
      bool flag1 = this.canConvert(type1, type2, CONVERTTYPE.NOUDC);
      bool flag2 = this.canConvert(type2, type1, CONVERTTYPE.NOUDC);
      if (flag1 == flag2)
        return 0;
      return fImplicit1 != flag1 ? -1 : 1;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr BindDecimalConstCast(CType destType, CType srcType, ExprConstant src)
    {
      CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_DECIMAL);
      if (predefindType == null)
        return (Expr) null;
      if (destType == predefindType)
      {
        Decimal num;
        switch (srcType.FundamentalType)
        {
          case FUNDTYPE.FT_I1:
          case FUNDTYPE.FT_I2:
          case FUNDTYPE.FT_I4:
            num = Convert.ToDecimal(src.Val.Int32Val);
            break;
          case FUNDTYPE.FT_U1:
          case FUNDTYPE.FT_U2:
          case FUNDTYPE.FT_U4:
            num = Convert.ToDecimal(src.Val.UInt32Val);
            break;
          case FUNDTYPE.FT_I8:
            num = Convert.ToDecimal(src.Val.Int64Val);
            break;
          case FUNDTYPE.FT_U8:
            num = Convert.ToDecimal((ulong) src.Val.Int64Val);
            break;
          case FUNDTYPE.FT_R4:
            num = Convert.ToDecimal((float) src.Val.DoubleVal);
            break;
          case FUNDTYPE.FT_R8:
            num = Convert.ToDecimal(src.Val.DoubleVal);
            break;
          default:
            return (Expr) null;
        }
        ConstVal constVal = ConstVal.Get(num);
        return (Expr) ExprFactory.CreateConstant(predefindType, constVal);
      }
      if (srcType != predefindType)
        return (Expr) null;
      Decimal num1 = 0M;
      FUNDTYPE fundamentalType = destType.FundamentalType;
      ConstVal constVal1;
      try
      {
        if (fundamentalType != FUNDTYPE.FT_R4 && fundamentalType != FUNDTYPE.FT_R8)
          num1 = Decimal.Truncate(src.Val.DecimalVal);
        switch (fundamentalType)
        {
          case FUNDTYPE.FT_I1:
            constVal1 = ConstVal.Get((int) Convert.ToSByte(num1));
            break;
          case FUNDTYPE.FT_I2:
            constVal1 = ConstVal.Get((int) Convert.ToInt16(num1));
            break;
          case FUNDTYPE.FT_I4:
            constVal1 = ConstVal.Get(Convert.ToInt32(num1));
            break;
          case FUNDTYPE.FT_U1:
            constVal1 = ConstVal.Get((uint) Convert.ToByte(num1));
            break;
          case FUNDTYPE.FT_U2:
            constVal1 = ConstVal.Get((uint) Convert.ToUInt16(num1));
            break;
          case FUNDTYPE.FT_U4:
            constVal1 = ConstVal.Get(Convert.ToUInt32(num1));
            break;
          case FUNDTYPE.FT_I8:
            constVal1 = ConstVal.Get(Convert.ToInt64(num1));
            break;
          case FUNDTYPE.FT_U8:
            constVal1 = ConstVal.Get(Convert.ToUInt64(num1));
            break;
          case FUNDTYPE.FT_R4:
            constVal1 = ConstVal.Get(Convert.ToSingle(src.Val.DecimalVal));
            break;
          case FUNDTYPE.FT_R8:
            constVal1 = ConstVal.Get(Convert.ToDouble(src.Val.DecimalVal));
            break;
          default:
            return (Expr) null;
        }
      }
      catch (OverflowException ex)
      {
        return (Expr) null;
      }
      return (Expr) ExprFactory.CreateConstant(destType, constVal1);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool CanExplicitConversionBeBoundInUncheckedContext(
      Expr exprSrc,
      CType typeSrc,
      CType typeDest,
      CONVERTTYPE flags)
    {
      return new ExpressionBinder(new BindingContext(this.Context)).BindExplicitConversion(exprSrc, typeSrc, typeDest, flags);
    }

    public BindingContext Context { get; }

    public ExpressionBinder(BindingContext context) => this.Context = context;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static AggregateType GetPredefindType(PredefinedType pt)
    {
      return SymbolLoader.GetPredefindType(pt);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateAssignmentConversion(Expr op1, Expr op2, bool allowExplicit)
    {
      return !allowExplicit ? this.mustConvertCore(op2, op1.Type) : this.mustCastCore(op2, op1.Type, (CONVERTTYPE) 0);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr BindAssignment(Expr op1, Expr op2, bool allowExplicit)
    {
      this.CheckLvalue(op1, CheckLvalueKind.Assignment);
      op2 = this.GenerateAssignmentConversion(op1, op2, allowExplicit);
      return (Expr) ExpressionBinder.GenerateOptimizedAssignment(op1, op2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindArrayIndexCore(Expr pOp1, Expr pOp2)
    {
      CType pIntType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_INT);
      CType elementType = (pOp1.Type as ArrayType).ElementType;
      ExpressionBinder.CheckUnsafe(elementType);
      CType pDestType = this.ChooseArrayIndexType(pOp2);
      ExpressionBinder binder = this;
      Expr index = pOp2.Map((Func<Expr, Expr>) (x =>
      {
        Expr expr = binder.MustConvertWithSuppressedMessage(x, pDestType);
        return pDestType != pIntType ? (Expr) ExpressionBinder.ExprFactoryCreateCastWithSuppressedMessage(EXPRFLAG.EXF_LITERALCONST, pDestType, expr) : expr;
      }));
      return (Expr) ExprFactory.CreateArrayIndex(elementType, pOp1, index);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Workarounds https://github.com/mono/linker/issues/1416. All usages are marked as unsafe.")]
    private Expr MustConvertWithSuppressedMessage(Expr x, CType pDestType)
    {
      return this.mustConvert(x, pDestType);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Workarounds https://github.com/mono/linker/issues/1416. All usages are marked as unsafe.")]
    private static ExprCast ExprFactoryCreateCastWithSuppressedMessage(
      EXPRFLAG flags,
      CType type,
      Expr argument)
    {
      return ExprFactory.CreateCast(flags, type, argument);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void bindSimpleCast(Expr exprSrc, CType typeDest, out Expr pexprDest)
    {
      this.bindSimpleCast(exprSrc, typeDest, out pexprDest, (EXPRFLAG) 0);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void bindSimpleCast(
      Expr exprSrc,
      CType typeDest,
      out Expr pexprDest,
      EXPRFLAG exprFlags)
    {
      Expr expr = exprSrc.GetConst();
      ExprCast cast = ExprFactory.CreateCast(exprFlags, typeDest, exprSrc);
      if (this.Context.Checked)
        cast.Flags |= EXPRFLAG.EXF_CHECKOVERFLOW;
      if (expr is ExprConstant exprConstant && exprFlags == (EXPRFLAG) 0 && exprSrc.Type.FundamentalType == typeDest.FundamentalType && (!exprSrc.Type.IsPredefType(PredefinedType.PT_STRING) || exprConstant.Val.IsNullRef))
      {
        ExprConstant constant = ExprFactory.CreateConstant(typeDest, exprConstant.Val);
        pexprDest = (Expr) constant;
      }
      else
        pexprDest = (Expr) cast;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindToMethod(
      MethWithInst mwi,
      Expr pArguments,
      ExprMemberGroup pMemGroup,
      MemLookFlags flags)
    {
      Expr optionalObject = pMemGroup.OptionalObject;
      CType type = optionalObject?.Type;
      ExpressionBinder.PostBindMethod(mwi);
      Expr expr = this.AdjustMemberObject((SymWithType) mwi, optionalObject);
      pMemGroup.OptionalObject = expr;
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, (flags & (MemLookFlags.Ctor | MemLookFlags.NewObj)) != (MemLookFlags.Ctor | MemLookFlags.NewObj) ? TypeManager.SubstType(mwi.Meth().RetType, mwi.GetType(), mwi.TypeArgs) : (CType) mwi.Ats, pArguments, pMemGroup, mwi);
      if ((flags & MemLookFlags.Ctor) != MemLookFlags.None && (flags & MemLookFlags.NewObj) != MemLookFlags.None)
        call.Flags |= EXPRFLAG.EXF_LITERALCONST | EXPRFLAG.EXF_CANTBENULL;
      this.verifyMethodArgs((ExprWithArgs) call, type);
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindToField(Expr pOptionalObject, FieldWithType fwt, BindingFlag bindFlags)
    {
      CType type = TypeManager.SubstType(fwt.Field().GetType(), fwt.GetType());
      pOptionalObject = this.AdjustMemberObject((SymWithType) fwt, pOptionalObject);
      ExpressionBinder.CheckUnsafe(type);
      ExprField field = ExprFactory.CreateField(type, pOptionalObject, fwt);
      field.Flags |= (EXPRFLAG) (bindFlags & BindingFlag.BIND_MEMBERSET);
      return (Expr) field;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ExprProperty BindToProperty(
      Expr pObject,
      PropWithType pwt,
      BindingFlag bindFlags,
      Expr args,
      ExprMemberGroup pMemGroup)
    {
      Expr optionalObjectThrough = pObject;
      MethWithType pmwtGet;
      MethWithType pmwtSet;
      ExpressionBinder.PostBindProperty(pwt, out pmwtGet, out pmwtSet);
      pObject = !(bool) (SymWithType) pmwtGet || (bool) (SymWithType) pmwtSet && pmwtSet.GetType() != pmwtGet.GetType() && !SymbolLoader.HasBaseConversion((CType) pmwtGet.GetType(), (CType) pmwtSet.GetType()) ? (!(bool) (SymWithType) pmwtSet ? this.AdjustMemberObject((SymWithType) pwt, pObject) : this.AdjustMemberObject((SymWithType) pmwtSet, pObject)) : this.AdjustMemberObject((SymWithType) pmwtGet, pObject);
      pMemGroup.OptionalObject = pObject;
      CType type = TypeManager.SubstType(pwt.Prop().RetType, pwt.GetType());
      if ((bindFlags & BindingFlag.BIND_RVALUEREQUIRED) != (BindingFlag) 0)
      {
        if (!(bool) (SymWithType) pmwtGet)
          throw ErrorHandling.Error(ErrorCode.ERR_PropertyLacksGet, (ErrArg) (SymWithType) pwt);
        CType typeThru = (CType) null;
        if (optionalObjectThrough != null)
          typeThru = optionalObjectThrough.Type;
        switch (CSemanticChecker.CheckAccess2((Symbol) pmwtGet.Meth(), pmwtGet.GetType(), (Symbol) this.ContextForMemberLookup, typeThru))
        {
          case ACCESSERROR.ACCESSERROR_NOACCESSTHRU:
            throw ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, (ErrArg) (SymWithType) pwt, (ErrArg) typeThru, (ErrArg) (Symbol) this.ContextForMemberLookup);
          case ACCESSERROR.ACCESSERROR_NOERROR:
            break;
          default:
            throw ErrorHandling.Error(ErrorCode.ERR_InaccessibleGetter, (ErrArg) (SymWithType) pwt);
        }
      }
      ExprProperty property = ExprFactory.CreateProperty(type, optionalObjectThrough, args, pMemGroup, pwt, pmwtSet);
      if (property.OptionalArguments != null)
        this.verifyMethodArgs((ExprWithArgs) property, optionalObjectThrough?.Type);
      return property;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr bindUDUnop(ExpressionKind ek, Expr arg)
    {
      Name name = ExpressionBinder.ExpressionKindName(ek);
      CType ctype1 = arg.Type;
      while (true)
      {
        switch (ctype1.TypeKind)
        {
          case TypeKind.TK_AggregateType:
            goto label_3;
          case TypeKind.TK_NullableType:
            ctype1 = ctype1.StripNubs();
            continue;
          default:
            goto label_5;
        }
      }
label_3:
      if (!ctype1.IsClassType && !ctype1.IsStructType || ((AggregateType) ctype1).OwningAggregate.IsSkipUDOps())
        return (Expr) null;
      ArgInfos argInfos = new ArgInfos();
      argInfos.carg = 1;
      ExpressionBinder.FillInArgInfoFromArgList(argInfos, arg);
      List<CandidateFunctionMember> list = new List<CandidateFunctionMember>();
      mps = (MethodSymbol) null;
      AggregateType aggregateType = (AggregateType) ctype1;
      do
      {
        while ((mps == null ? SymbolLoader.LookupAggMember(name, aggregateType.OwningAggregate, symbmask_t.MASK_MethodSymbol) : mps.LookupNext(symbmask_t.MASK_MethodSymbol)) is MethodSymbol mps)
        {
          if (mps.isOperator && mps.Params.Count == 1)
          {
            TypeArray @params = TypeManager.SubstTypeArray(mps.Params, aggregateType);
            CType ctype2 = @params[0];
            if (this.canConvert(arg, ctype2))
            {
              list.Add(new CandidateFunctionMember(new MethPropWithInst((MethodOrPropertySymbol) mps, aggregateType, TypeArray.Empty), @params, (byte) 0, false));
            }
            else
            {
              NullableType nullable;
              if (ctype2.IsNonNullableValueType && TypeManager.SubstType(mps.RetType, aggregateType).IsNonNullableValueType && this.canConvert(arg, (CType) (nullable = TypeManager.GetNullable(ctype2))))
                list.Add(new CandidateFunctionMember(new MethPropWithInst((MethodOrPropertySymbol) mps, aggregateType, TypeArray.Empty), TypeArray.Allocate((CType) nullable), (byte) 1, false));
            }
          }
        }
        if (list.IsEmpty<CandidateFunctionMember>())
          aggregateType = aggregateType.BaseClass;
        else
          break;
      }
      while (aggregateType != null);
      if (list.IsEmpty<CandidateFunctionMember>())
        return (Expr) null;
      CandidateFunctionMember methAmbig1;
      CandidateFunctionMember methAmbig2;
      CandidateFunctionMember bestMethod = this.FindBestMethod(list, (CType) null, argInfos, out methAmbig1, out methAmbig2);
      if (bestMethod == null)
        throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, (ErrArg) methAmbig1.mpwi, (ErrArg) methAmbig2.mpwi);
      ExprCall call = bestMethod.ctypeLift == (byte) 0 ? this.BindUDUnopCall(arg, bestMethod.@params[0], bestMethod.mpwi) : this.BindLiftedUDUnop(arg, bestMethod.@params[0], bestMethod.mpwi);
      return (Expr) ExprFactory.CreateUserDefinedUnaryOperator(ek, call.Type, arg, call, bestMethod.mpwi);
label_5:
      return (Expr) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindLiftedUDUnop(Expr arg, CType typeArg, MethPropWithInst mpwi)
    {
      CType ctype1 = typeArg.StripNubs();
      if (!(arg.Type is NullableType) || !this.canConvert(arg.Type.StripNubs(), ctype1, CONVERTTYPE.NOUDC))
        arg = this.mustConvert(arg, typeArg);
      CType ctype2 = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
      if (!(ctype2 is NullableType))
        ctype2 = (CType) TypeManager.GetNullable(ctype2);
      ExprCall exprCall = this.BindUDUnopCall(this.mustCast(arg, ctype1), ctype1, mpwi);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, mpwi);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, ctype2, arg, memGroup, (MethWithInst) null);
      call.MethWithInst = new MethWithInst(mpwi);
      call.CastOfNonLiftedResultToLiftedType = this.mustCast((Expr) exprCall, ctype2, (CONVERTTYPE) 0);
      call.NullableCallLiftKind = NullableCallLiftKind.Operator;
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindUDUnopCall(Expr arg, CType typeArg, MethPropWithInst mpwi)
    {
      CType type = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
      ExpressionBinder.CheckUnsafe(type);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, mpwi);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, type, this.mustConvert(arg, typeArg), memGroup, (MethWithInst) null);
      call.MethWithInst = new MethWithInst(mpwi);
      this.verifyMethodArgs((ExprWithArgs) call, (CType) mpwi.GetType());
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExpressionBinder.GroupToArgsBinderResult BindMethodGroupToArgumentsCore(
      BindingFlag bindFlags,
      ExprMemberGroup grp,
      Expr args,
      int carg,
      ExpressionBinder.NamedArgumentsKind namedArgumentsKind)
    {
      ArgInfos argInfos1 = new ArgInfos() { carg = carg };
      ExpressionBinder.FillInArgInfoFromArgList(argInfos1, args);
      ArgInfos argInfos2 = new ArgInfos() { carg = carg };
      ExpressionBinder.FillInArgInfoFromArgList(argInfos2, args);
      ExpressionBinder.GroupToArgsBinder groupToArgsBinder = new ExpressionBinder.GroupToArgsBinder(this, bindFlags, grp, argInfos1, argInfos2, namedArgumentsKind);
      groupToArgsBinder.Bind();
      return groupToArgsBinder.GetResultsOfBind();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ExprWithArgs BindMethodGroupToArguments(
      BindingFlag bindFlags,
      ExprMemberGroup grp,
      Expr args)
    {
      int carg = ExpressionBinder.CountArguments(args);
      ExpressionBinder.NamedArgumentsKind namedArgumentsType = ExpressionBinder.FindNamedArgumentsType(args);
      MethPropWithInst bestResult = this.BindMethodGroupToArgumentsCore(bindFlags, grp, args, carg, namedArgumentsType).BestResult;
      return grp.SymKind == SYMKIND.SK_PropertySymbol ? (ExprWithArgs) this.BindToProperty(grp.OptionalObject, new PropWithType((SymWithType) bestResult), bindFlags, args, grp) : (ExprWithArgs) this.BindToMethod(new MethWithInst(bestResult), args, grp, (MemLookFlags) grp.Flags);
    }

    private static ExpressionBinder.NamedArgumentsKind FindNamedArgumentsType(Expr args)
    {
      Expr expr1 = args;
      while (expr1 != null)
      {
        Expr expr2;
        if (expr1 is ExprList exprList1)
        {
          expr2 = exprList1.OptionalElement;
          expr1 = exprList1.OptionalNextListNode;
        }
        else
        {
          expr2 = expr1;
          expr1 = (Expr) null;
        }
        if (expr2 is ExprNamedArgumentSpecification)
        {
          while (expr1 != null)
          {
            Expr expr3;
            if (expr1 is ExprList exprList2)
            {
              expr3 = exprList2.OptionalElement;
              expr1 = exprList2.OptionalNextListNode;
            }
            else
            {
              expr3 = expr1;
              expr1 = (Expr) null;
            }
            if (!(expr3 is ExprNamedArgumentSpecification))
              return ExpressionBinder.NamedArgumentsKind.NonTrailing;
          }
          return ExpressionBinder.NamedArgumentsKind.Positioning;
        }
      }
      return ExpressionBinder.NamedArgumentsKind.None;
    }

    private static RuntimeBinderException BadOperatorTypesError(Expr pOperand1, Expr pOperand2)
    {
      string errorString = pOperand1.ErrorString;
      return pOperand2 != null ? ErrorHandling.Error(ErrorCode.ERR_BadBinaryOps, (ErrArg) errorString, (ErrArg) pOperand1.Type, (ErrArg) pOperand2.Type) : ErrorHandling.Error(ErrorCode.ERR_BadUnaryOp, (ErrArg) errorString, (ErrArg) pOperand1.Type);
    }

    private static ErrorCode GetStandardLvalueError(CheckLvalueKind kind)
    {
      return kind != CheckLvalueKind.Increment ? ErrorCode.ERR_AssgLvalueExpected : ErrorCode.ERR_IncrementLvalueExpected;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void CheckLvalueProp(ExprProperty prop)
    {
      CType type = (CType) null;
      if (prop.OptionalObjectThrough != null)
        type = prop.OptionalObjectThrough.Type;
      this.CheckPropertyAccess(prop.MethWithTypeSet, prop.PropWithTypeSlot, type);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void CheckPropertyAccess(MethWithType mwt, PropWithType pwtSlot, CType type)
    {
      switch (CSemanticChecker.CheckAccess2((Symbol) mwt.Meth(), mwt.GetType(), (Symbol) this.ContextForMemberLookup, type))
      {
        case ACCESSERROR.ACCESSERROR_NOACCESS:
          throw ErrorHandling.Error((ErrorCode) (mwt.Meth().isSetAccessor() ? 272 : 271), (ErrArg) (SymWithType) pwtSlot);
        case ACCESSERROR.ACCESSERROR_NOACCESSTHRU:
          throw ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, (ErrArg) (SymWithType) pwtSlot, (ErrArg) type, (ErrArg) (Symbol) this.ContextForMemberLookup);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void CheckLvalue(Expr expr, CheckLvalueKind kind)
    {
      if (expr.isLvalue())
      {
        if (!(expr is ExprProperty prop))
          return;
        this.CheckLvalueProp(prop);
      }
      else
      {
        switch (expr.Kind)
        {
          case ExpressionKind.Field:
            throw ErrorHandling.Error(((ExprField) expr).FieldWithType.Field().isStatic ? ErrorCode.ERR_AssgReadonlyStatic : ErrorCode.ERR_AssgReadonly);
          case ExpressionKind.Property:
            throw ErrorHandling.Error(ErrorCode.ERR_AssgReadonlyProp, (ErrArg) (SymWithType) ((ExprProperty) expr).PropWithTypeSlot);
          default:
            throw ErrorHandling.Error(ExpressionBinder.GetStandardLvalueError(kind));
        }
      }
    }

    private static void PostBindMethod(MethWithInst pMWI)
    {
      MethodSymbol methodSymbol = pMWI.Meth();
      if (methodSymbol.RetType == null)
        return;
      ExpressionBinder.CheckUnsafe(methodSymbol.RetType);
      foreach (CType type in methodSymbol.Params.Items)
        ExpressionBinder.CheckUnsafe(type);
    }

    private static void PostBindProperty(
      PropWithType pwt,
      out MethWithType pmwtGet,
      out MethWithType pmwtSet)
    {
      PropertySymbol propertySymbol = pwt.Prop();
      pmwtGet = propertySymbol.GetterMethod != null ? new MethWithType(propertySymbol.GetterMethod, pwt.GetType()) : new MethWithType();
      pmwtSet = propertySymbol.SetterMethod != null ? new MethWithType(propertySymbol.SetterMethod, pwt.GetType()) : new MethWithType();
      if (propertySymbol.RetType == null)
        return;
      ExpressionBinder.CheckUnsafe(propertySymbol.RetType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr AdjustMemberObject(SymWithType swt, Expr pObject)
    {
      bool flag = ExpressionBinder.IsMatchingStatic(swt, pObject);
      bool isStatic = swt.Sym.isStatic;
      if (!flag)
      {
        if (isStatic)
        {
          if ((pObject.Flags & EXPRFLAG.EXF_UNREALIZEDGOTO) != (EXPRFLAG) 0)
            return (Expr) null;
          throw ErrorHandling.Error(ErrorCode.ERR_ObjectProhibited, (ErrArg) swt);
        }
        throw ErrorHandling.Error(ErrorCode.ERR_ObjectRequired, (ErrArg) swt);
      }
      if (isStatic)
        return (Expr) null;
      if (swt.Sym is MethodSymbol && swt.Meth().IsConstructor())
        return pObject;
      if (pObject == null)
        return (Expr) null;
      CType ctype = pObject.Type;
      CType ats;
      if (ctype is NullableType nullableType && (AggregateType) (ats = (CType) nullableType.GetAts()) != swt.GetType())
        ctype = ats;
      if (ctype is TypeParameterType || ctype is AggregateType)
      {
        AggregateSymbol parent = swt.Sym.parent as AggregateSymbol;
        pObject = this.tryConvert(pObject, (CType) swt.GetType(), CONVERTTYPE.NOUDC);
      }
      return pObject;
    }

    private static bool IsMatchingStatic(SymWithType swt, Expr pObject)
    {
      if (swt.Sym is MethodSymbol sym && sym.IsConstructor())
        return !sym.isStatic;
      return swt.Sym.isStatic ? pObject == null || (pObject.Flags & EXPRFLAG.EXF_SAMENAMETYPE) != (EXPRFLAG) 0 : pObject != null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void verifyMethodArgs(ExprWithArgs call, CType callingObjectType)
    {
      Expr optionalArguments = call.OptionalArguments;
      SymWithType symWithType = call.GetSymWithType();
      MethodOrPropertySymbol sym = symWithType.Sym as MethodOrPropertySymbol;
      TypeArray typeArgs = call is ExprCall exprCall ? exprCall.MethWithInst.TypeArgs : (TypeArray) null;
      Expr newArgs;
      this.AdjustCallArgumentsForParams(callingObjectType, (CType) symWithType.GetType(), sym, typeArgs, optionalArguments, out newArgs);
      call.OptionalArguments = newArgs;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void AdjustCallArgumentsForParams(
      CType callingObjectType,
      CType type,
      MethodOrPropertySymbol mp,
      TypeArray pTypeArgs,
      Expr argsPtr,
      out Expr newArgs)
    {
      newArgs = (Expr) null;
      Expr last1 = (Expr) null;
      MethodOrPropertySymbol mostDerivedMethod = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(mp, callingObjectType);
      int count = mp.Params.Count;
      TypeArray typeArray = mp.Params;
      int i1 = 0;
      int num1 = ExpressionIterator.Count(argsPtr);
      bool flag = false;
      ExpressionIterator expressionIterator = new ExpressionIterator(argsPtr);
      if (argsPtr == null)
      {
        if (!mp.isParamArray)
          return;
      }
      else
      {
        while (!expressionIterator.AtEnd())
        {
          Expr expr1 = expressionIterator.Current();
          Expr expr2;
          if (expr1.Type is ParameterModifierType)
          {
            if (count != 0)
              --count;
            ExprFactory.AppendItemToList(expr1, ref newArgs, ref last1);
          }
          else
          {
            switch (count)
            {
              case 0:
                goto label_26;
              case 1:
                if (!mp.isParamArray || num1 <= mp.Params.Count)
                  break;
                goto label_31;
            }
            Expr expr3 = expr1;
            Expr newItem;
            if (expr3 is ExprNamedArgumentSpecification argumentSpecification)
            {
              int i2 = 0;
              foreach (Name parameterName in mostDerivedMethod.ParameterNames)
              {
                if (parameterName != argumentSpecification.Name)
                  ++i2;
                else
                  break;
              }
              CType dest = TypeManager.SubstType(typeArray[i2], type, pTypeArgs);
              if (!this.canConvert(argumentSpecification.Value, dest) && mp.isParamArray && i2 == mp.Params.Count - 1)
              {
                ExprArrayInit arrayInit = ExprFactory.CreateArrayInit(TypeManager.SubstType(mp.Params[mp.Params.Count - 1], type, pTypeArgs), (Expr) null, (Expr) null, new int[1]);
                arrayInit.GeneratedForParamArray = true;
                arrayInit.OptionalArguments = argumentSpecification.Value;
                argumentSpecification.Value = (Expr) arrayInit;
                flag = true;
              }
              else
                argumentSpecification.Value = this.tryConvert(argumentSpecification.Value, dest);
              newItem = expr3;
            }
            else
            {
              CType dest = TypeManager.SubstType(typeArray[i1], type, pTypeArgs);
              newItem = this.tryConvert(expr1, dest);
            }
            if (newItem == null)
            {
              if (!mp.isParamArray || count != 1 || num1 < mp.Params.Count)
                break;
              goto label_31;
            }
            else
            {
              expr2 = newItem;
              ExprFactory.AppendItemToList(newItem, ref newArgs, ref last1);
              --count;
            }
          }
label_26:
          ++i1;
          if (count != 0 && mp.isParamArray && i1 == num1)
          {
            expr2 = (Expr) null;
            expressionIterator.MoveNext();
            goto label_31;
          }
          else
            expressionIterator.MoveNext();
        }
        return;
      }
label_31:
      if (flag)
        return;
      CType type1 = TypeManager.SubstType(mp.Params[mp.Params.Count - 1], type, pTypeArgs);
      if (!(type1 is ArrayType arrayType) || !arrayType.IsSZArray)
        return;
      CType elementType = arrayType.ElementType;
      ExprArrayInit arrayInit1 = ExprFactory.CreateArrayInit(type1, (Expr) null, (Expr) null, new int[1]);
      arrayInit1.GeneratedForParamArray = true;
      if (expressionIterator.AtEnd())
      {
        arrayInit1.DimensionSizes[0] = 0;
        arrayInit1.OptionalArguments = (Expr) null;
        argsPtr = argsPtr != null ? (Expr) ExprFactory.CreateList(argsPtr, (Expr) arrayInit1) : (Expr) arrayInit1;
        ExprFactory.AppendItemToList((Expr) arrayInit1, ref newArgs, ref last1);
      }
      else
      {
        Expr first = (Expr) null;
        Expr last2 = (Expr) null;
        int num2 = 0;
        while (!expressionIterator.AtEnd())
        {
          Expr expr = expressionIterator.Current();
          ++num2;
          if (expr is ExprNamedArgumentSpecification argumentSpecification)
            argumentSpecification.Value = this.tryConvert(argumentSpecification.Value, elementType);
          else
            expr = this.tryConvert(expr, elementType);
          ExprFactory.AppendItemToList(expr, ref first, ref last2);
          expressionIterator.MoveNext();
        }
        arrayInit1.DimensionSizes[0] = num2;
        arrayInit1.OptionalArguments = first;
        ExprFactory.AppendItemToList((Expr) arrayInit1, ref newArgs, ref last1);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal CType ChooseArrayIndexType(Expr args)
    {
      foreach (PredefinedType pt in ExpressionBinder.s_rgptIntOp)
      {
        CType predefindType = (CType) ExpressionBinder.GetPredefindType(pt);
        using (IEnumerator<Expr> enumerator = args.ToEnumerable().GetEnumerator())
        {
          do
          {
            if (!enumerator.MoveNext())
              goto label_8;
          }
          while (this.canConvert(enumerator.Current, predefindType));
          continue;
        }
label_8:
        return predefindType;
      }
      return (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_INT);
    }

    internal static void FillInArgInfoFromArgList(ArgInfos argInfo, Expr args)
    {
      CType[] ctypeArray = new CType[argInfo.carg];
      argInfo.prgexpr = new List<Expr>();
      int index = 0;
      Expr expr1 = args;
      while (expr1 != null)
      {
        Expr expr2;
        if (expr1 is ExprList exprList)
        {
          expr2 = exprList.OptionalElement;
          expr1 = exprList.OptionalNextListNode;
        }
        else
        {
          expr2 = expr1;
          expr1 = (Expr) null;
        }
        ctypeArray[index] = expr2.Type;
        argInfo.prgexpr.Add(expr2);
        ++index;
      }
      argInfo.types = TypeArray.Allocate(ctypeArray);
    }

    private static bool TryGetExpandedParams(
      TypeArray @params,
      int count,
      out TypeArray ppExpandedParams)
    {
      if (count < @params.Count - 1)
      {
        CType[] dest = new CType[@params.Count - 1];
        @params.CopyItems(0, @params.Count - 1, dest);
        ppExpandedParams = TypeArray.Allocate(dest);
        return true;
      }
      CType[] dest1 = new CType[count];
      @params.CopyItems(0, @params.Count - 1, dest1);
      if (!(@params[@params.Count - 1] is ArrayType arrayType))
      {
        ppExpandedParams = (TypeArray) null;
        return false;
      }
      CType elementType = arrayType.ElementType;
      for (int index = @params.Count - 1; index < count; ++index)
        dest1[index] = elementType;
      ppExpandedParams = TypeArray.Allocate(dest1);
      return true;
    }

    public static bool IsMethPropCallable(MethodOrPropertySymbol sym, bool requireUC)
    {
      if (sym.isOverride && !sym.isHideByName)
        return false;
      return !requireUC || sym.isUserCallable();
    }

    private static bool IsConvInTable(
      List<UdConvInfo> convTable,
      MethodSymbol meth,
      AggregateType ats,
      bool fSrc,
      bool fDst)
    {
      foreach (UdConvInfo udConvInfo in convTable)
      {
        if (udConvInfo.Meth.Meth() == meth && udConvInfo.Meth.GetType() == ats && udConvInfo.SrcImplicit == fSrc && udConvInfo.DstImplicit == fDst)
          return true;
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool isConstantInRange(ExprConstant exprSrc, CType typeDest)
    {
      return ExpressionBinder.isConstantInRange(exprSrc, typeDest, false);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static bool isConstantInRange(ExprConstant exprSrc, CType typeDest, bool realsOk)
    {
      FUNDTYPE fundamentalType1 = exprSrc.Type.FundamentalType;
      FUNDTYPE fundamentalType2 = typeDest.FundamentalType;
      if ((fundamentalType1 > FUNDTYPE.FT_U8 || fundamentalType2 > FUNDTYPE.FT_U8) && (!realsOk || fundamentalType1 > FUNDTYPE.FT_R8 || fundamentalType2 > FUNDTYPE.FT_R8))
        return false;
      if (fundamentalType2 > FUNDTYPE.FT_U8)
        return true;
      if (fundamentalType1 > FUNDTYPE.FT_U8)
      {
        double doubleVal = exprSrc.Val.DoubleVal;
        switch (fundamentalType2)
        {
          case FUNDTYPE.FT_I1:
            if (doubleVal > -129.0 && doubleVal < 128.0)
              return true;
            break;
          case FUNDTYPE.FT_I2:
            if (doubleVal > -32769.0 && doubleVal < 32768.0)
              return true;
            break;
          case FUNDTYPE.FT_I4:
            if (doubleVal > (double) ExpressionBinder.I64(-2147483649L) && doubleVal < (double) ExpressionBinder.I64(2147483648L))
              return true;
            break;
          case FUNDTYPE.FT_U1:
            if (doubleVal > -1.0 && doubleVal < 256.0)
              return true;
            break;
          case FUNDTYPE.FT_U2:
            if (doubleVal > -1.0 && doubleVal < 65536.0)
              return true;
            break;
          case FUNDTYPE.FT_U4:
            if (doubleVal > -1.0 && doubleVal < (double) ExpressionBinder.I64(4294967296L))
              return true;
            break;
          case FUNDTYPE.FT_I8:
            if (doubleVal >= (double) long.MinValue && doubleVal < (double) long.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U8:
            if (doubleVal > -1.0 && doubleVal < 1.8446744073709552E+19)
              return true;
            break;
        }
        return false;
      }
      if (fundamentalType1 == FUNDTYPE.FT_U8)
      {
        ulong uint64Value = exprSrc.UInt64Value;
        switch (fundamentalType2)
        {
          case FUNDTYPE.FT_I1:
            if (uint64Value <= (ulong) sbyte.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_I2:
            if (uint64Value <= (ulong) short.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_I4:
            if (uint64Value <= (ulong) int.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U1:
            if (uint64Value <= (ulong) byte.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U2:
            if (uint64Value <= (ulong) ushort.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U4:
            if (uint64Value <= (ulong) uint.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_I8:
            if (uint64Value <= (ulong) long.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U8:
            return true;
        }
      }
      else
      {
        long int64Value = exprSrc.Int64Value;
        switch (fundamentalType2)
        {
          case FUNDTYPE.FT_I1:
            if (int64Value >= (long) sbyte.MinValue && int64Value <= (long) sbyte.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_I2:
            if (int64Value >= (long) short.MinValue && int64Value <= (long) short.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_I4:
            if (int64Value >= ExpressionBinder.I64((long) int.MinValue) && int64Value <= ExpressionBinder.I64((long) int.MaxValue))
              return true;
            break;
          case FUNDTYPE.FT_U1:
            if (int64Value >= 0L && int64Value <= (long) byte.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U2:
            if (int64Value >= 0L && int64Value <= (long) ushort.MaxValue)
              return true;
            break;
          case FUNDTYPE.FT_U4:
            if (int64Value >= 0L && int64Value <= ExpressionBinder.I64((long) uint.MaxValue))
              return true;
            break;
          case FUNDTYPE.FT_I8:
            return true;
          case FUNDTYPE.FT_U8:
            if (int64Value >= 0L)
              return true;
            break;
        }
      }
      return false;
    }

    private static Name ExpressionKindName(ExpressionKind ek)
    {
      return NameManager.GetPredefinedName(ExpressionBinder.s_EK2NAME[(int) (ek - 29)]);
    }

    private static void CheckUnsafe(CType type)
    {
      if (type == null || type.IsUnsafe())
        throw ErrorHandling.Error(ErrorCode.ERR_UnsafeNeeded);
    }

    private AggregateSymbol ContextForMemberLookup => this.Context.ContextForMemberLookup;

    private static ExprWrap WrapShortLivedExpression(Expr expr) => ExprFactory.CreateWrap(expr);

    private static ExprAssignment GenerateOptimizedAssignment(Expr op1, Expr op2)
    {
      return ExprFactory.CreateAssignment(op1, op2);
    }

    internal static int CountArguments(Expr args)
    {
      int num = 0;
      Expr expr1 = args;
      while (expr1 != null)
      {
        Expr expr2;
        if (expr1 is ExprList exprList)
        {
          expr2 = exprList.OptionalElement;
          expr1 = exprList.OptionalNextListNode;
        }
        else
        {
          expr2 = expr1;
          expr1 = (Expr) null;
        }
        ++num;
      }
      return num;
    }

    private static bool IsNullableConstructor(Expr expr, out ExprCall call)
    {
      if (expr is ExprCall exprCall && exprCall.MemberGroup.OptionalObject == null)
      {
        MethWithInst methWithInst = exprCall.MethWithInst;
        if ((methWithInst != null ? (methWithInst.Meth().IsNullableConstructor() ? 1 : 0) : 0) != 0)
        {
          call = exprCall;
          return true;
        }
      }
      call = (ExprCall) null;
      return false;
    }

    private static Expr StripNullableConstructor(Expr pExpr)
    {
      ExprCall call;
      while (ExpressionBinder.IsNullableConstructor(pExpr, out call))
        pExpr = call.OptionalArguments;
      return pExpr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr BindNubValue(Expr exprSrc)
    {
      ExprCall call;
      if (ExpressionBinder.IsNullableConstructor(exprSrc, out call))
        return call.OptionalArguments;
      NullableType type = (NullableType) exprSrc.Type;
      CType underlyingType = type.UnderlyingType;
      AggregateType ats = type.GetAts();
      PropertySymbol property1 = PredefinedMembers.GetProperty(PREDEFPROP.PP_G_OPTIONAL_VALUE);
      PropWithType property2 = new PropWithType(property1, ats);
      MethPropWithInst method = new MethPropWithInst((MethodOrPropertySymbol) property1, ats);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup(exprSrc, method);
      return (Expr) ExprFactory.CreateProperty(underlyingType, (Expr) null, (Expr) null, memGroup, property2, (MethWithType) null);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprCall BindNubNew(Expr exprSrc)
    {
      NullableType nullable = TypeManager.GetNullable(exprSrc.Type);
      AggregateType ats = nullable.GetAts();
      MethWithInst method = new MethWithInst(PredefinedMembers.GetMethod(PREDEFMETH.PM_G_OPTIONAL_CTOR), ats, TypeArray.Empty);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      return ExprFactory.CreateCall(EXPRFLAG.EXF_LITERALCONST | EXPRFLAG.EXF_CANTBENULL, (CType) nullable, exprSrc, memGroup, method);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprBinOp BindUserDefinedBinOp(ExpressionKind ek, ExpressionBinder.BinOpArgInfo info)
    {
      if (info.pt1 <= PredefinedType.PT_ULONG && info.pt2 <= PredefinedType.PT_ULONG)
        return (ExprBinOp) null;
      MethPropWithInst ppmpwi;
      Expr call;
      if (info.binopKind == BinOpKind.Logical)
      {
        ExprCall pCall = this.BindUDBinop(ek - 55 + 49, info.arg1, info.arg2, true, out ppmpwi);
        if (pCall == null)
          return (ExprBinOp) null;
        call = this.BindUserBoolOp(ek, pCall);
      }
      else
        call = (Expr) this.BindUDBinop(ek, info.arg1, info.arg2, false, out ppmpwi);
      return call == null ? (ExprBinOp) null : ExprFactory.CreateUserDefinedBinop(ek, call.Type, info.arg1, info.arg2, call, ppmpwi);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetSpecialBinopSignatures(
      List<ExpressionBinder.BinOpFullSig> prgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      if (info.pt1 <= PredefinedType.PT_ULONG && info.pt2 <= PredefinedType.PT_ULONG)
        return false;
      return this.GetDelBinOpSigs(prgbofs, info) || this.GetEnumBinOpSigs(prgbofs, info) || this.GetRefEqualSigs(prgbofs, info);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetStandardAndLiftedBinopSignatures(
      List<ExpressionBinder.BinOpFullSig> rgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      int num = 0;
      for (int index = 0; index < ExpressionBinder.s_binopSignatures.Length; ++index)
      {
        ExpressionBinder.BinOpSig binopSignature = ExpressionBinder.s_binopSignatures[index];
        if ((binopSignature.mask & info.mask) != BinOpMask.None)
        {
          CType ctype1 = (CType) ExpressionBinder.GetPredefindType(binopSignature.pt1);
          CType ctype2 = (CType) ExpressionBinder.GetPredefindType(binopSignature.pt2);
          if (ctype1 != null && ctype2 != null)
          {
            ConvKind convKind1 = ExpressionBinder.GetConvKind(info.pt1, binopSignature.pt1);
            ConvKind convKind2 = ExpressionBinder.GetConvKind(info.pt2, binopSignature.pt2);
            LiftFlags grflt = LiftFlags.None;
            switch (convKind1)
            {
              case ConvKind.Identity:
                if (convKind2 == ConvKind.Identity)
                {
                  ExpressionBinder.BinOpFullSig binOpFullSig = new ExpressionBinder.BinOpFullSig(this, binopSignature);
                  if (binOpFullSig.Type1() != null && binOpFullSig.Type2() != null)
                  {
                    rgbofs.Add(binOpFullSig);
                    return true;
                  }
                  goto case ConvKind.Implicit;
                }
                else
                  goto case ConvKind.Implicit;
              case ConvKind.Implicit:
label_20:
                switch (convKind2 - 1)
                {
                  case (ConvKind) 0:
                  case ConvKind.Identity:
label_34:
                    if (grflt != LiftFlags.None)
                    {
                      rgbofs.Add(new ExpressionBinder.BinOpFullSig(ctype1, ctype2, binopSignature.pfn, binopSignature.grfos, grflt, binopSignature.fnkind));
                      num = index + binopSignature.cbosSkip + 1;
                      continue;
                    }
                    rgbofs.Add(new ExpressionBinder.BinOpFullSig(this, binopSignature));
                    index += binopSignature.cbosSkip;
                    continue;
                  case ConvKind.Implicit:
                    if (info.arg2 is ExprConstant exprConstant1)
                    {
                      if (!this.canConvert((Expr) exprConstant1, ctype2))
                      {
                        if (index >= num && binopSignature.CanLift())
                        {
                          ctype2 = (CType) TypeManager.GetNullable(ctype2);
                          if (this.canConvert((Expr) exprConstant1, ctype2))
                          {
                            switch (ExpressionBinder.GetConvKind(info.ptRaw2, binopSignature.pt2))
                            {
                              case ConvKind.Identity:
                              case ConvKind.Implicit:
                                grflt |= LiftFlags.Lift2;
                                goto label_34;
                              default:
                                grflt |= LiftFlags.Convert2;
                                goto label_34;
                            }
                          }
                          else
                            continue;
                        }
                        else
                          continue;
                      }
                      else
                        goto case (ConvKind) 0;
                    }
                    else
                      continue;
                  case ConvKind.Explicit:
                    if (!this.canConvert(info.arg2, ctype2))
                    {
                      if (index >= num && binopSignature.CanLift())
                      {
                        ctype2 = (CType) TypeManager.GetNullable(ctype2);
                        if (this.canConvert(info.arg2, ctype2))
                        {
                          switch (ExpressionBinder.GetConvKind(info.ptRaw2, binopSignature.pt2))
                          {
                            case ConvKind.Identity:
                            case ConvKind.Implicit:
                              grflt |= LiftFlags.Lift2;
                              goto label_34;
                            default:
                              grflt |= LiftFlags.Convert2;
                              goto label_34;
                          }
                        }
                        else
                          continue;
                      }
                      else
                        continue;
                    }
                    else
                      goto case (ConvKind) 0;
                  default:
                    continue;
                }
              case ConvKind.Explicit:
                if (info.arg1 is ExprConstant exprConstant2)
                {
                  if (!this.canConvert((Expr) exprConstant2, ctype1))
                  {
                    if (index >= num && binopSignature.CanLift())
                    {
                      ctype1 = (CType) TypeManager.GetNullable(ctype1);
                      if (this.canConvert((Expr) exprConstant2, ctype1))
                      {
                        switch (ExpressionBinder.GetConvKind(info.ptRaw1, binopSignature.pt1))
                        {
                          case ConvKind.Identity:
                          case ConvKind.Implicit:
                            grflt |= LiftFlags.Lift1;
                            goto label_20;
                          default:
                            grflt |= LiftFlags.Convert1;
                            goto label_20;
                        }
                      }
                      else
                        continue;
                    }
                    else
                      continue;
                  }
                  else
                    goto case ConvKind.Implicit;
                }
                else
                  continue;
              case ConvKind.Unknown:
                if (!this.canConvert(info.arg1, ctype1))
                {
                  if (index >= num && binopSignature.CanLift())
                  {
                    ctype1 = (CType) TypeManager.GetNullable(ctype1);
                    if (this.canConvert(info.arg1, ctype1))
                    {
                      switch (ExpressionBinder.GetConvKind(info.ptRaw1, binopSignature.pt1))
                      {
                        case ConvKind.Identity:
                        case ConvKind.Implicit:
                          grflt |= LiftFlags.Lift1;
                          goto label_20;
                        default:
                          grflt |= LiftFlags.Convert1;
                          goto label_20;
                      }
                    }
                    else
                      continue;
                  }
                  else
                    continue;
                }
                else
                  goto case ConvKind.Implicit;
              default:
                continue;
            }
          }
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private int FindBestSignatureInList(
      List<ExpressionBinder.BinOpFullSig> binopSignatures,
      ExpressionBinder.BinOpArgInfo info)
    {
      if (binopSignatures.Count == 1)
        return 0;
      int index1 = 0;
      for (int index2 = 1; index2 < binopSignatures.Count; ++index2)
      {
        if (index1 < 0)
        {
          index1 = index2;
        }
        else
        {
          int num = this.WhichBofsIsBetter(binopSignatures[index1], binopSignatures[index2], info.type1, info.type2);
          if (num == 0)
            index1 = -1;
          else if (num > 0)
            index1 = index2;
        }
      }
      if (index1 == -1)
        return -1;
      for (int index3 = 0; index3 < binopSignatures.Count; ++index3)
      {
        if (index3 != index1 && this.WhichBofsIsBetter(binopSignatures[index1], binopSignatures[index3], info.type1, info.type2) >= 0)
          return -1;
      }
      return index1;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprBinOp BindNullEqualityComparison(
      ExpressionKind ek,
      ExpressionBinder.BinOpArgInfo info)
    {
      Expr left = info.arg1;
      Expr zeroInit1 = info.arg2;
      if (info.binopKind == BinOpKind.Equal)
      {
        CType predefindType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
        ExprBinOp exprBinOp = (ExprBinOp) null;
        if (info.type1 is NullableType && info.type2 is NullType)
        {
          zeroInit1 = ExprFactory.CreateZeroInit(info.type1);
          exprBinOp = ExprFactory.CreateBinop(ek, predefindType, left, zeroInit1);
        }
        if (info.type1 is NullType && info.type2 is NullableType)
        {
          Expr zeroInit2 = ExprFactory.CreateZeroInit(info.type2);
          exprBinOp = ExprFactory.CreateBinop(ek, predefindType, zeroInit2, zeroInit1);
        }
        if (exprBinOp != null)
        {
          exprBinOp.IsLifted = true;
          return exprBinOp;
        }
      }
      throw ExpressionBinder.BadOperatorTypesError(info.arg1, info.arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr BindStandardBinop(ExpressionKind ek, Expr arg1, Expr arg2)
    {
      (BinOpKind binOpKind, EXPRFLAG flags) = this.GetBinopKindAndFlags(ek);
      ExpressionBinder.BinOpArgInfo info = new ExpressionBinder.BinOpArgInfo(arg1, arg2)
      {
        binopKind = binOpKind
      };
      info.mask = (BinOpMask) (1 << (int) (info.binopKind & (BinOpKind) 31));
      List<ExpressionBinder.BinOpFullSig> binOpFullSigList = new List<ExpressionBinder.BinOpFullSig>();
      ExprBinOp exprBinOp = this.BindUserDefinedBinOp(ek, info);
      if (exprBinOp != null)
        return (Expr) exprBinOp;
      bool flag = this.GetSpecialBinopSignatures(binOpFullSigList, info);
      if (!flag)
        flag = this.GetStandardAndLiftedBinopSignatures(binOpFullSigList, info);
      int index;
      if (flag)
      {
        index = binOpFullSigList.Count - 1;
      }
      else
      {
        if (binOpFullSigList.Count == 0)
          return (Expr) ExpressionBinder.BindNullEqualityComparison(ek, info);
        index = this.FindBestSignatureInList(binOpFullSigList, info);
        if (index < 0)
          throw ExpressionBinder.AmbiguousOperatorError(arg1, arg2);
      }
      return this.BindStandardBinopCore(info, binOpFullSigList[index], ek, flags);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindStandardBinopCore(
      ExpressionBinder.BinOpArgInfo info,
      ExpressionBinder.BinOpFullSig bofs,
      ExpressionKind ek,
      EXPRFLAG flags)
    {
      if (bofs.pfn == null)
        throw ExpressionBinder.BadOperatorTypesError(info.arg1, info.arg2);
      if (!bofs.isLifted() || !bofs.AutoLift())
      {
        Expr expr1 = info.arg1;
        Expr expr2 = info.arg2;
        if (bofs.ConvertOperandsBeforeBinding())
        {
          expr1 = this.mustConvert(expr1, bofs.Type1());
          expr2 = this.mustConvert(expr2, bofs.Type2());
        }
        return bofs.fnkind == BinOpFuncKind.BoolBitwiseOp ? (Expr) this.BindBoolBitwiseOp(ek, flags, expr1, expr2) : bofs.pfn(this, ek, flags, expr1, expr2);
      }
      if (!ExpressionBinder.IsEnumArithmeticBinOp(ek, info))
        return (Expr) this.BindLiftedStandardBinOp(info, bofs, ek, flags);
      Expr expr3 = info.arg1;
      Expr expr4 = info.arg2;
      if (bofs.ConvertOperandsBeforeBinding())
      {
        expr3 = this.mustConvert(expr3, bofs.Type1());
        expr4 = this.mustConvert(expr4, bofs.Type2());
      }
      return this.BindLiftedEnumArithmeticBinOp(ek, flags, expr3, expr4);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprBinOp BindLiftedStandardBinOp(
      ExpressionBinder.BinOpArgInfo info,
      ExpressionBinder.BinOpFullSig bofs,
      ExpressionKind ek,
      EXPRFLAG flags)
    {
      Expr pArgument1 = info.arg1;
      Expr pArgument2 = info.arg2;
      Expr expr = (Expr) null;
      Expr ppLiftedArgument1;
      Expr ppNonLiftedArgument1;
      this.LiftArgument(pArgument1, bofs.Type1(), bofs.ConvertFirst(), out ppLiftedArgument1, out ppNonLiftedArgument1);
      Expr ppLiftedArgument2;
      Expr ppNonLiftedArgument2;
      this.LiftArgument(pArgument2, bofs.Type2(), bofs.ConvertSecond(), out ppLiftedArgument2, out ppNonLiftedArgument2);
      if (!ppNonLiftedArgument1.isNull() && !ppNonLiftedArgument2.isNull())
        expr = bofs.pfn(this, ek, flags, ppNonLiftedArgument1, ppNonLiftedArgument2);
      CType ctype;
      if (info.binopKind == BinOpKind.Compare || info.binopKind == BinOpKind.Equal)
      {
        ctype = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
      }
      else
      {
        ctype = bofs.fnkind == BinOpFuncKind.EnumBinOp ? (CType) ExpressionBinder.GetEnumBinOpType(ek, ppNonLiftedArgument1.Type, ppNonLiftedArgument2.Type, out AggregateType _) : ppLiftedArgument1.Type;
        if (!(ctype is NullableType))
          ctype = (CType) TypeManager.GetNullable(ctype);
      }
      ExprBinOp binop = ExprFactory.CreateBinop(ek, ctype, ppLiftedArgument1, ppLiftedArgument2);
      this.mustCast(expr, ctype, (CONVERTTYPE) 0);
      binop.IsLifted = true;
      binop.Flags |= flags;
      return binop;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void LiftArgument(
      Expr pArgument,
      CType pParameterType,
      bool bConvertBeforeLift,
      out Expr ppLiftedArgument,
      out Expr ppNonLiftedArgument)
    {
      Expr pExpr1 = this.mustConvert(pArgument, pParameterType);
      if (pExpr1 != pArgument)
        ExpressionBinder.MarkAsIntermediateConversion(pExpr1);
      Expr expr = pArgument;
      Expr pExpr2;
      if (pParameterType is NullableType nullableType)
      {
        if (expr.isNull())
          expr = this.mustCast(expr, pParameterType);
        pExpr2 = this.mustCast(expr, nullableType.UnderlyingType);
        if (bConvertBeforeLift)
          ExpressionBinder.MarkAsIntermediateConversion(pExpr2);
      }
      else
        pExpr2 = pExpr1;
      ppLiftedArgument = pExpr1;
      ppNonLiftedArgument = pExpr2;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetDelBinOpSigs(
      List<ExpressionBinder.BinOpFullSig> prgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      if (!info.ValidForDelegate() || !info.type1.IsDelegateType && !info.type2.IsDelegateType)
        return false;
      if (info.type1 == info.type2)
      {
        prgbofs.Add(new ExpressionBinder.BinOpFullSig(info.type1, info.type2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindDelBinOp), OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
        return true;
      }
      bool flag1 = info.type2.IsDelegateType && this.canConvert(info.arg1, info.type2);
      bool flag2 = info.type1.IsDelegateType && this.canConvert(info.arg2, info.type1);
      if (flag1)
        prgbofs.Add(new ExpressionBinder.BinOpFullSig(info.type2, info.type2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindDelBinOp), OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
      if (flag2)
        prgbofs.Add(new ExpressionBinder.BinOpFullSig(info.type1, info.type1, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindDelBinOp), OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool CanConvertArg1(
      ExpressionBinder.BinOpArgInfo info,
      CType typeDst,
      out LiftFlags pgrflt,
      out CType ptypeSig1,
      out CType ptypeSig2)
    {
      ptypeSig1 = (CType) null;
      ptypeSig2 = (CType) null;
      if (this.canConvert(info.arg1, typeDst))
      {
        pgrflt = LiftFlags.None;
      }
      else
      {
        pgrflt = LiftFlags.None;
        typeDst = (CType) TypeManager.GetNullable(typeDst);
        if (!this.canConvert(info.arg1, typeDst))
          return false;
        pgrflt = LiftFlags.Convert1;
      }
      ptypeSig1 = typeDst;
      if (info.type2 is NullableType)
      {
        pgrflt |= LiftFlags.Lift2;
        ptypeSig2 = (CType) TypeManager.GetNullable(info.typeRaw2);
      }
      else
        ptypeSig2 = info.typeRaw2;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool CanConvertArg2(
      ExpressionBinder.BinOpArgInfo info,
      CType typeDst,
      out LiftFlags pgrflt,
      out CType ptypeSig1,
      out CType ptypeSig2)
    {
      ptypeSig1 = (CType) null;
      ptypeSig2 = (CType) null;
      if (this.canConvert(info.arg2, typeDst))
      {
        pgrflt = LiftFlags.None;
      }
      else
      {
        pgrflt = LiftFlags.None;
        typeDst = (CType) TypeManager.GetNullable(typeDst);
        if (!this.canConvert(info.arg2, typeDst))
          return false;
        pgrflt = LiftFlags.Convert2;
      }
      ptypeSig2 = typeDst;
      if (info.type1 is NullableType)
      {
        pgrflt |= LiftFlags.Lift1;
        ptypeSig1 = (CType) TypeManager.GetNullable(info.typeRaw1);
      }
      else
        ptypeSig1 = info.typeRaw1;
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void RecordBinOpSigFromArgs(
      List<ExpressionBinder.BinOpFullSig> prgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      LiftFlags grflt = LiftFlags.None;
      CType type1;
      if (info.type1 != info.typeRaw1)
      {
        grflt |= LiftFlags.Lift1;
        type1 = (CType) TypeManager.GetNullable(info.typeRaw1);
      }
      else
        type1 = info.typeRaw1;
      CType type2;
      if (info.type2 != info.typeRaw2)
      {
        grflt |= LiftFlags.Lift2;
        type2 = (CType) TypeManager.GetNullable(info.typeRaw2);
      }
      else
        type2 = info.typeRaw2;
      prgbofs.Add(new ExpressionBinder.BinOpFullSig(type1, type2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindEnumBinOp), OpSigFlags.Value, grflt, BinOpFuncKind.EnumBinOp));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetEnumBinOpSigs(
      List<ExpressionBinder.BinOpFullSig> prgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      if (!info.typeRaw1.IsEnumType && !info.typeRaw2.IsEnumType)
        return false;
      CType ptypeSig1 = (CType) null;
      CType ptypeSig2 = (CType) null;
      LiftFlags pgrflt = LiftFlags.None;
      if (info.typeRaw1 == info.typeRaw2)
      {
        if (!info.ValidForEnum())
          return false;
        ExpressionBinder.RecordBinOpSigFromArgs(prgbofs, info);
        return true;
      }
      if (info.typeRaw1.IsEnumType ? info.typeRaw2 == info.typeRaw1.UnderlyingEnumType && info.ValidForEnumAndUnderlyingType() : info.typeRaw1 == info.typeRaw2.UnderlyingEnumType && info.ValidForUnderlyingTypeAndEnum())
      {
        ExpressionBinder.RecordBinOpSigFromArgs(prgbofs, info);
        return true;
      }
      if (!info.typeRaw1.IsEnumType ? info.ValidForEnum() && this.CanConvertArg1(info, info.typeRaw2, out pgrflt, out ptypeSig1, out ptypeSig2) || info.ValidForEnumAndUnderlyingType() && this.CanConvertArg1(info, (CType) info.typeRaw2.UnderlyingEnumType, out pgrflt, out ptypeSig1, out ptypeSig2) : info.ValidForEnum() && this.CanConvertArg2(info, info.typeRaw1, out pgrflt, out ptypeSig1, out ptypeSig2) || info.ValidForEnumAndUnderlyingType() && this.CanConvertArg2(info, (CType) info.typeRaw1.UnderlyingEnumType, out pgrflt, out ptypeSig1, out ptypeSig2))
        prgbofs.Add(new ExpressionBinder.BinOpFullSig(ptypeSig1, ptypeSig2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindEnumBinOp), OpSigFlags.Value, pgrflt, BinOpFuncKind.EnumBinOp));
      return false;
    }

    private static bool IsEnumArithmeticBinOp(ExpressionKind ek, ExpressionBinder.BinOpArgInfo info)
    {
      bool flag;
      switch (ek)
      {
        case ExpressionKind.Add:
          flag = info.typeRaw1.IsEnumType ^ info.typeRaw2.IsEnumType;
          break;
        case ExpressionKind.Subtract:
          flag = info.typeRaw1.IsEnumType | info.typeRaw2.IsEnumType;
          break;
        default:
          flag = false;
          break;
      }
      return flag;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetRefEqualSigs(
      List<ExpressionBinder.BinOpFullSig> prgbofs,
      ExpressionBinder.BinOpArgInfo info)
    {
      if (info.mask != BinOpMask.Equal || info.type1 != info.typeRaw1 || info.type2 != info.typeRaw2)
        return false;
      bool refEqualSigs = false;
      CType ctype1 = info.type1;
      CType ctype2 = info.type2;
      CType predefindType1 = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_OBJECT);
      CType ctype3 = (CType) null;
      if (ctype1 is NullType && ctype2 is NullType)
      {
        ctype3 = predefindType1;
        refEqualSigs = true;
      }
      else
      {
        CType predefindType2 = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_DELEGATE);
        if (this.canConvert(info.arg1, predefindType2) && this.canConvert(info.arg2, predefindType2) && !ctype1.IsDelegateType && !ctype2.IsDelegateType)
          prgbofs.Add(new ExpressionBinder.BinOpFullSig(predefindType2, predefindType2, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindDelBinOp), OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
        if (ctype1.FundamentalType != FUNDTYPE.FT_REF)
          return false;
        if (ctype2 is NullType)
        {
          refEqualSigs = true;
          ctype3 = predefindType1;
        }
        else
        {
          if (ctype2.FundamentalType != FUNDTYPE.FT_REF)
            return false;
          if (ctype1 is NullType)
          {
            refEqualSigs = true;
            ctype3 = predefindType1;
          }
          else
          {
            if (!this.canCast(ctype1, ctype2, CONVERTTYPE.NOUDC) && !this.canCast(ctype2, ctype1, CONVERTTYPE.NOUDC))
              return false;
            if (ctype1.IsInterfaceType || ctype1.IsPredefType(PredefinedType.PT_STRING) || SymbolLoader.HasBaseConversion(ctype1, predefindType2))
              ctype1 = predefindType1;
            else if (ctype1 is ArrayType)
              ctype1 = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_ARRAY);
            else if (!ctype1.IsClassType)
              return false;
            if (ctype2.IsInterfaceType || ctype2.IsPredefType(PredefinedType.PT_STRING) || SymbolLoader.HasBaseConversion(ctype2, predefindType2))
              ctype2 = predefindType1;
            else if (ctype2 is ArrayType)
              ctype2 = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_ARRAY);
            else if (!ctype2.IsClassType)
              return false;
            if (SymbolLoader.HasBaseConversion(ctype2, ctype1))
              ctype3 = ctype1;
            else if (SymbolLoader.HasBaseConversion(ctype1, ctype2))
              ctype3 = ctype2;
          }
        }
      }
      prgbofs.Add(new ExpressionBinder.BinOpFullSig(ctype3, ctype3, new ExpressionBinder.PfnBindBinOp(ExpressionBinder.BindRefCmpOp), OpSigFlags.None, LiftFlags.None, BinOpFuncKind.RefCmpOp));
      return refEqualSigs;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private int WhichBofsIsBetter(
      ExpressionBinder.BinOpFullSig bofs1,
      ExpressionBinder.BinOpFullSig bofs2,
      CType type1,
      CType type2)
    {
      BetterType betterType1;
      BetterType betterType2;
      if (bofs1.FPreDef() && bofs2.FPreDef())
      {
        betterType1 = this.WhichTypeIsBetter(bofs1.pt1, bofs2.pt1, type1);
        betterType2 = this.WhichTypeIsBetter(bofs1.pt2, bofs2.pt2, type2);
      }
      else
      {
        betterType1 = this.WhichTypeIsBetter(bofs1.Type1(), bofs2.Type1(), type1);
        betterType2 = this.WhichTypeIsBetter(bofs1.Type2(), bofs2.Type2(), type2);
      }
      int num1;
      switch (betterType1)
      {
        case BetterType.Left:
          num1 = -1;
          break;
        case BetterType.Right:
          num1 = 1;
          break;
        default:
          num1 = 0;
          break;
      }
      int num2 = num1;
      switch (betterType2)
      {
        case BetterType.Left:
          --num2;
          break;
        case BetterType.Right:
          ++num2;
          break;
      }
      return num2;
    }

    private static (ExpressionKind, UnaOpKind, EXPRFLAG) CalculateExprAndUnaryOpKinds(
      OperatorKind op,
      bool bChecked)
    {
      EXPRFLAG exprflag = (EXPRFLAG) 0;
      UnaOpKind unaOpKind;
      ExpressionKind expressionKind;
      switch (op)
      {
        case OperatorKind.OP_UPLUS:
          unaOpKind = UnaOpKind.Plus;
          expressionKind = ExpressionKind.UnaryPlus;
          break;
        case OperatorKind.OP_NEG:
          if (bChecked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          unaOpKind = UnaOpKind.Minus;
          expressionKind = ExpressionKind.Negate;
          break;
        case OperatorKind.OP_BITNOT:
          unaOpKind = UnaOpKind.Tilde;
          expressionKind = ExpressionKind.BitwiseNot;
          break;
        case OperatorKind.OP_LOGNOT:
          unaOpKind = UnaOpKind.Bang;
          expressionKind = ExpressionKind.LogicalNot;
          break;
        case OperatorKind.OP_PREINC:
          if (bChecked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          unaOpKind = UnaOpKind.IncDec;
          expressionKind = ExpressionKind.Add;
          break;
        case OperatorKind.OP_PREDEC:
          if (bChecked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          unaOpKind = UnaOpKind.IncDec;
          expressionKind = ExpressionKind.Subtract;
          break;
        case OperatorKind.OP_POSTINC:
          exprflag = EXPRFLAG.EXF_OPERATOR;
          if (bChecked)
            exprflag |= EXPRFLAG.EXF_CHECKOVERFLOW;
          unaOpKind = UnaOpKind.IncDec;
          expressionKind = ExpressionKind.Add;
          break;
        case OperatorKind.OP_POSTDEC:
          exprflag = EXPRFLAG.EXF_OPERATOR;
          if (bChecked)
            exprflag |= EXPRFLAG.EXF_CHECKOVERFLOW;
          unaOpKind = UnaOpKind.IncDec;
          expressionKind = ExpressionKind.Subtract;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      return (expressionKind, unaOpKind, exprflag);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expr BindStandardUnaryOperator(OperatorKind op, Expr pArgument)
    {
      CType type = pArgument.Type;
      if (type is NullableType dest)
      {
        CType underlyingType = dest.UnderlyingType;
        if (underlyingType.IsEnumType)
        {
          PredefinedType predefinedType;
          switch (underlyingType.FundamentalType)
          {
            case FUNDTYPE.FT_U4:
              predefinedType = PredefinedType.PT_UINT;
              break;
            case FUNDTYPE.FT_I8:
              predefinedType = PredefinedType.PT_LONG;
              break;
            case FUNDTYPE.FT_U8:
              predefinedType = PredefinedType.PT_ULONG;
              break;
            default:
              predefinedType = PredefinedType.PT_INT;
              break;
          }
          PredefinedType pt = predefinedType;
          return this.mustCast(this.BindStandardUnaryOperator(op, this.mustCast(pArgument, (CType) TypeManager.GetNullable((CType) ExpressionBinder.GetPredefindType(pt)))), (CType) dest);
        }
      }
      (ExpressionKind expressionKind, UnaOpKind unaryOpKind, EXPRFLAG flags) = ExpressionBinder.CalculateExprAndUnaryOpKinds(op, this.Context.Checked);
      UnaOpMask unaryOpMask = (UnaOpMask) (1 << (int) (unaryOpKind & (UnaOpKind) 31));
      List<ExpressionBinder.UnaOpFullSig> pSignatures = new List<ExpressionBinder.UnaOpFullSig>();
      Expr ppResult;
      UnaryOperatorSignatureFindResult signatureFindResult = this.PopulateSignatureList(pArgument, unaryOpKind, unaryOpMask, expressionKind, flags, pSignatures, out ppResult);
      int index1 = pSignatures.Count - 1;
      switch (signatureFindResult)
      {
        case UnaryOperatorSignatureFindResult.Match:
          ExpressionBinder.UnaOpFullSig uofs = pSignatures[index1];
          if (uofs.pfn == null)
          {
            if (unaryOpKind == UnaOpKind.IncDec)
              return this.BindIncOp(expressionKind, flags, pArgument, uofs);
            throw ExpressionBinder.BadOperatorTypesError(pArgument, (Expr) null);
          }
          if (uofs.isLifted())
            return (Expr) this.BindLiftedStandardUnop(expressionKind, flags, pArgument, uofs);
          if (pArgument is ExprConstant)
            pArgument = (Expr) ExprFactory.CreateCast(pArgument.Type, pArgument);
          Expr op1 = this.tryConvert(pArgument, uofs.GetType()) ?? this.mustCast(pArgument, uofs.GetType(), CONVERTTYPE.NOUDC);
          return uofs.pfn(this, expressionKind, flags, op1);
        case UnaryOperatorSignatureFindResult.Return:
          return ppResult;
        default:
          if (!this.FindApplicableSignatures(pArgument, unaryOpMask, pSignatures))
          {
            if (pSignatures.Count == 0)
              throw ExpressionBinder.BadOperatorTypesError(pArgument, (Expr) null);
            index1 = 0;
            if (pSignatures.Count != 1)
            {
              for (int index2 = 1; index2 < pSignatures.Count; ++index2)
              {
                if (index1 < 0)
                {
                  index1 = index2;
                }
                else
                {
                  int num = this.WhichUofsIsBetter(pSignatures[index1], pSignatures[index2], type);
                  if (num == 0)
                    index1 = -1;
                  else if (num > 0)
                    index1 = index2;
                }
              }
              if (index1 < 0)
                throw ExpressionBinder.AmbiguousOperatorError(pArgument, (Expr) null);
              for (int index3 = 0; index3 < pSignatures.Count; ++index3)
              {
                if (index3 != index1 && this.WhichUofsIsBetter(pSignatures[index1], pSignatures[index3], type) >= 0)
                  throw ExpressionBinder.AmbiguousOperatorError(pArgument, (Expr) null);
              }
              goto case UnaryOperatorSignatureFindResult.Match;
            }
            else
              goto case UnaryOperatorSignatureFindResult.Match;
          }
          else
          {
            index1 = pSignatures.Count - 1;
            goto case UnaryOperatorSignatureFindResult.Match;
          }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private UnaryOperatorSignatureFindResult PopulateSignatureList(
      Expr pArgument,
      UnaOpKind unaryOpKind,
      UnaOpMask unaryOpMask,
      ExpressionKind exprKind,
      EXPRFLAG flags,
      List<ExpressionBinder.UnaOpFullSig> pSignatures,
      out Expr ppResult)
    {
      ppResult = (Expr) null;
      CType type = pArgument.Type;
      CType ctype = type.StripNubs();
      if ((ctype.IsPredefined ? (uint) ctype.PredefinedType : 49U) > 12U)
      {
        if (ctype.IsEnumType)
        {
          if ((unaryOpMask & (UnaOpMask.Tilde | UnaOpMask.IncDec)) != UnaOpMask.None)
          {
            if (unaryOpKind == UnaOpKind.Tilde)
              pSignatures.Add(new ExpressionBinder.UnaOpFullSig((CType) ((AggregateType) type).OwningAggregate.GetUnderlyingType(), new ExpressionBinder.PfnBindUnaOp(ExpressionBinder.BindEnumUnaOp), LiftFlags.None, UnaOpFuncKind.EnumUnaOp));
            else
              pSignatures.Add(new ExpressionBinder.UnaOpFullSig((CType) ((AggregateType) type).OwningAggregate.GetUnderlyingType(), (ExpressionBinder.PfnBindUnaOp) null, LiftFlags.None, UnaOpFuncKind.None));
            return UnaryOperatorSignatureFindResult.Match;
          }
        }
        else if (unaryOpKind == UnaOpKind.IncDec)
        {
          ExprMultiGet multiGet = ExprFactory.CreateMultiGet((EXPRFLAG) 0, type, (ExprMulti) null);
          Expr expr = this.bindUDUnop(exprKind - 42 + 33, (Expr) multiGet);
          if (expr != null)
          {
            if (expr.Type != null && expr.Type != type)
              expr = this.mustConvert(expr, type);
            ExprMulti multi = ExprFactory.CreateMulti(EXPRFLAG.EXF_ASSGOP | flags, type, pArgument, expr);
            multiGet.OptionalMulti = multi;
            this.CheckLvalue(pArgument, CheckLvalueKind.Increment);
            ppResult = (Expr) multi;
            return UnaryOperatorSignatureFindResult.Return;
          }
        }
        else
        {
          Expr expr = this.bindUDUnop(exprKind, pArgument);
          if (expr != null)
          {
            ppResult = expr;
            return UnaryOperatorSignatureFindResult.Return;
          }
        }
      }
      return UnaryOperatorSignatureFindResult.Continue;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool FindApplicableSignatures(
      Expr pArgument,
      UnaOpMask unaryOpMask,
      List<ExpressionBinder.UnaOpFullSig> pSignatures)
    {
      long num = 0;
      CType type = pArgument.Type;
      CType ctype1 = type.StripNubs();
      PredefinedType ptSrc1 = type.IsPredefined ? type.PredefinedType : PredefinedType.PT_COUNT;
      PredefinedType ptSrc2 = ctype1.IsPredefined ? ctype1.PredefinedType : PredefinedType.PT_COUNT;
      for (int index = 0; index < ExpressionBinder.s_rguos.Length; ++index)
      {
        ExpressionBinder.UnaOpSig rguo = ExpressionBinder.s_rguos[index];
        if ((rguo.grfuom & unaryOpMask) != UnaOpMask.None)
        {
          ConvKind convKind = ExpressionBinder.GetConvKind(ptSrc1, ExpressionBinder.s_rguos[index].pt);
          CType ctype2 = (CType) null;
          switch (convKind)
          {
            case ConvKind.Identity:
              ExpressionBinder.UnaOpFullSig unaOpFullSig1 = new ExpressionBinder.UnaOpFullSig(this, rguo);
              if (unaOpFullSig1.GetType() != null)
              {
                pSignatures.Add(unaOpFullSig1);
                return true;
              }
              goto case ConvKind.Implicit;
            case ConvKind.Implicit:
              if (ctype2 is NullableType)
              {
                LiftFlags liftFlags = LiftFlags.None;
                LiftFlags grflt;
                switch (ExpressionBinder.GetConvKind(ptSrc2, rguo.pt))
                {
                  case ConvKind.Identity:
                  case ConvKind.Implicit:
                    grflt = liftFlags | LiftFlags.Lift1;
                    break;
                  default:
                    grflt = liftFlags | LiftFlags.Convert1;
                    break;
                }
                pSignatures.Add(new ExpressionBinder.UnaOpFullSig(ctype2, rguo.pfn, grflt, rguo.fnkind));
                num = (long) (index + rguo.cuosSkip + 1);
                continue;
              }
              ExpressionBinder.UnaOpFullSig unaOpFullSig2 = new ExpressionBinder.UnaOpFullSig(this, rguo);
              if (unaOpFullSig2.GetType() != null)
                pSignatures.Add(unaOpFullSig2);
              index += rguo.cuosSkip;
              continue;
            case ConvKind.Explicit:
              if (pArgument is ExprConstant)
              {
                if (!this.canConvert(pArgument, ctype2 = (CType) ExpressionBinder.GetPredefindType(rguo.pt)))
                {
                  if ((long) index >= num)
                  {
                    ctype2 = (CType) TypeManager.GetNullable(ctype2);
                    if (this.canConvert(pArgument, ctype2))
                      goto case ConvKind.Implicit;
                    else
                      continue;
                  }
                  else
                    continue;
                }
                else
                  goto case ConvKind.Implicit;
              }
              else
                continue;
            case ConvKind.Unknown:
              if (!this.canConvert(pArgument, ctype2 = (CType) ExpressionBinder.GetPredefindType(rguo.pt)))
              {
                if ((long) index >= num)
                {
                  ctype2 = (CType) TypeManager.GetNullable(ctype2);
                  if (this.canConvert(pArgument, ctype2))
                    goto case ConvKind.Implicit;
                  else
                    continue;
                }
                else
                  continue;
              }
              else
                goto case ConvKind.Implicit;
            default:
              continue;
          }
        }
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprOperator BindLiftedStandardUnop(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg,
      ExpressionBinder.UnaOpFullSig uofs)
    {
      NullableType type = uofs.GetType() as NullableType;
      if (arg.Type is NullType)
        throw ExpressionBinder.BadOperatorTypesError(arg, (Expr) null);
      Expr ppLiftedArgument;
      Expr ppNonLiftedArgument;
      this.LiftArgument(arg, uofs.GetType(), uofs.Convert(), out ppLiftedArgument, out ppNonLiftedArgument);
      Expr expr = uofs.pfn(this, ek, flags, ppNonLiftedArgument);
      ExprUnaryOp unaryOp = ExprFactory.CreateUnaryOp(ek, (CType) type, ppLiftedArgument);
      this.mustCast(expr, (CType) type, (CONVERTTYPE) 0);
      unaryOp.Flags |= flags;
      return (ExprOperator) unaryOp;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private int WhichUofsIsBetter(
      ExpressionBinder.UnaOpFullSig uofs1,
      ExpressionBinder.UnaOpFullSig uofs2,
      CType typeArg)
    {
      int num;
      switch (!uofs1.FPreDef() || !uofs2.FPreDef() ? this.WhichTypeIsBetter(uofs1.GetType(), uofs2.GetType(), typeArg) : this.WhichTypeIsBetter(uofs1.pt, uofs2.pt, typeArg))
      {
        case BetterType.Left:
          num = -1;
          break;
        case BetterType.Right:
          num = 1;
          break;
        default:
          num = 0;
          break;
      }
      return num;
    }

    private static ExprOperator BindIntBinOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      return binder.BindIntOp(ek, flags, arg1, arg2, arg1.Type.PredefinedType);
    }

    private static ExprOperator BindIntUnaOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg)
    {
      return binder.BindIntOp(ek, flags, arg, (Expr) null, arg.Type.PredefinedType);
    }

    private static ExprOperator BindRealBinOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG _,
      Expr arg1,
      Expr arg2)
    {
      return ExpressionBinder.BindFloatOp(ek, arg1, arg2);
    }

    private static ExprOperator BindRealUnaOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG _,
      Expr arg)
    {
      return ExpressionBinder.BindFloatOp(ek, arg, (Expr) null);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindIncOp(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg,
      ExpressionBinder.UnaOpFullSig uofs)
    {
      this.CheckLvalue(arg, CheckLvalueKind.Increment);
      switch (uofs.GetType().StripNubs().FundamentalType)
      {
        case FUNDTYPE.FT_R4:
        case FUNDTYPE.FT_R8:
          flags &= ~EXPRFLAG.EXF_CHECKOVERFLOW;
          break;
      }
      return uofs.isLifted() ? (Expr) this.BindLiftedIncOp(ek, flags, arg, uofs) : (Expr) this.BindNonliftedIncOp(ek, flags, arg, uofs);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindIncOpCore(ExpressionKind ek, EXPRFLAG flags, Expr exprVal, CType type)
    {
      if (type.IsEnumType && type.FundamentalType > FUNDTYPE.FT_U8)
        type = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_INT);
      ConstVal cv;
      switch (type.FundamentalType)
      {
        case FUNDTYPE.FT_I1:
        case FUNDTYPE.FT_I2:
        case FUNDTYPE.FT_U1:
        case FUNDTYPE.FT_U2:
          type = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_INT);
          cv = ConstVal.Get(1);
          break;
        case FUNDTYPE.FT_I4:
        case FUNDTYPE.FT_U4:
          cv = ConstVal.Get(1);
          break;
        case FUNDTYPE.FT_I8:
        case FUNDTYPE.FT_U8:
          cv = ConstVal.Get(1L);
          break;
        case FUNDTYPE.FT_R4:
        case FUNDTYPE.FT_R8:
          cv = ConstVal.Get(1.0);
          break;
        default:
          PREDEFMETH predefMeth;
          if (ek == ExpressionKind.Add)
          {
            ek = ExpressionKind.DecimalInc;
            predefMeth = PREDEFMETH.PM_DECIMAL_OPINCREMENT;
          }
          else
          {
            ek = ExpressionKind.DecimalDec;
            predefMeth = PREDEFMETH.PM_DECIMAL_OPDECREMENT;
          }
          return (Expr) ExpressionBinder.CreateUnaryOpForPredefMethodCall(ek, predefMeth, type, exprVal);
      }
      return this.LScalar(ek, flags, exprVal, type, cv, type);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr LScalar(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr exprVal,
      CType type,
      ConstVal cv,
      CType typeTmp)
    {
      CType type1 = type;
      if (type1.IsEnumType)
        type1 = (CType) type1.UnderlyingEnumType;
      ExprBinOp binop = ExprFactory.CreateBinop(ek, typeTmp, exprVal, (Expr) ExprFactory.CreateConstant(type1, cv));
      binop.Flags |= flags;
      return typeTmp == type ? (Expr) binop : this.mustCast((Expr) binop, type, CONVERTTYPE.NOUDC);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprMulti BindNonliftedIncOp(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg,
      ExpressionBinder.UnaOpFullSig uofs)
    {
      ExprMultiGet multiGet = ExprFactory.CreateMultiGet(EXPRFLAG.EXF_ASSGOP, arg.Type, (ExprMulti) null);
      Expr expr = (Expr) multiGet;
      CType type = uofs.GetType();
      Expr exprVal = this.mustCast(expr, type);
      Expr op = this.mustCast(this.BindIncOpCore(ek, flags, exprVal, type), arg.Type, CONVERTTYPE.NOUDC);
      ExprMulti multi = ExprFactory.CreateMulti(EXPRFLAG.EXF_ASSGOP | flags, arg.Type, arg, op);
      multiGet.OptionalMulti = multi;
      return multi;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprMulti BindLiftedIncOp(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg,
      ExpressionBinder.UnaOpFullSig uofs)
    {
      NullableType type = uofs.GetType() as NullableType;
      ExprMultiGet multiGet = ExprFactory.CreateMultiGet(EXPRFLAG.EXF_ASSGOP, arg.Type, (ExprMulti) null);
      Expr expr1 = (Expr) multiGet;
      Expr exprVal = this.mustCast(expr1, type.UnderlyingType);
      Expr expr2 = this.BindIncOpCore(ek, flags, exprVal, type.UnderlyingType);
      Expr operand = this.mustCast(expr1, (CType) type);
      ExprUnaryOp unaryOp = ExprFactory.CreateUnaryOp(ek == ExpressionKind.Add ? ExpressionKind.Inc : ExpressionKind.Dec, arg.Type, operand);
      this.mustCast(this.mustCast(expr2, (CType) type), arg.Type);
      unaryOp.Flags |= flags;
      ExprMulti multi = ExprFactory.CreateMulti(EXPRFLAG.EXF_ASSGOP | flags, arg.Type, arg, (Expr) unaryOp);
      multiGet.OptionalMulti = multi;
      return multi;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprBinOp BindDecBinOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_DECIMAL);
      CType type;
      switch (ek)
      {
        case ExpressionKind.Eq:
        case ExpressionKind.NotEq:
        case ExpressionKind.LessThan:
        case ExpressionKind.LessThanOrEqual:
        case ExpressionKind.GreaterThan:
        case ExpressionKind.GreaterThanOrEqual:
          type = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
          break;
        case ExpressionKind.Add:
        case ExpressionKind.Subtract:
        case ExpressionKind.Multiply:
        case ExpressionKind.Divide:
        case ExpressionKind.Modulo:
          type = predefindType;
          break;
        default:
          type = (CType) null;
          break;
      }
      return ExprFactory.CreateBinop(ek, type, arg1, arg2);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprUnaryOp BindDecUnaOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg)
    {
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_DECIMAL);
      return ek == ExpressionKind.Negate ? ExpressionBinder.CreateUnaryOpForPredefMethodCall(ExpressionKind.DecimalNegate, PREDEFMETH.PM_DECIMAL_OPUNARYMINUS, predefindType, arg) : ExprFactory.CreateUnaryOp(ExpressionKind.UnaryPlus, predefindType, arg);
    }

    private static Expr BindStrBinOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      return (Expr) ExpressionBinder.BindStringConcat(arg1, arg2);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprBinOp BindShiftOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      PredefinedType predefinedType = arg1.Type.PredefinedType;
      return ExprFactory.CreateBinop(ek, arg1.Type, arg1, arg2);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprBinOp BindBoolBinOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      return ExprFactory.CreateBinop(ek, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprOperator BindBoolBitwiseOp(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr expr1,
      Expr expr2)
    {
      if (!(expr1.Type is NullableType) && !(expr2.Type is NullableType))
        return (ExprOperator) ExpressionBinder.BindBoolBinOp(this, ek, flags, expr1, expr2);
      CType nullable = (CType) TypeManager.GetNullable((CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL));
      Expr expr3 = ExpressionBinder.StripNullableConstructor(expr1);
      Expr expr4 = ExpressionBinder.StripNullableConstructor(expr2);
      Expr expr5 = (Expr) null;
      if (!(expr3.Type is NullableType) && !(expr4.Type is NullableType))
        expr5 = (Expr) ExpressionBinder.BindBoolBinOp(this, ek, flags, expr3, expr4);
      ExprBinOp binop = ExprFactory.CreateBinop(ek, nullable, expr1, expr2);
      if (expr5 != null)
        this.mustCast(expr5, nullable, (CONVERTTYPE) 0);
      binop.IsLifted = true;
      binop.Flags |= flags;
      return (ExprOperator) binop;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static Expr BindLiftedBoolBitwiseOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr expr1,
      Expr expr2)
    {
      return (Expr) null;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static Expr BindBoolUnaOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg)
    {
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
      Expr expr = arg.GetConst();
      return expr == null ? (Expr) ExprFactory.CreateUnaryOp(ExpressionKind.LogicalNot, predefindType, arg) : (Expr) ExprFactory.CreateConstant(predefindType, ConstVal.Get(((ExprConstant) expr).Val.Int32Val == 0));
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprBinOp BindStrCmpOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      PREDEFMETH predefMeth = ek == ExpressionKind.Eq ? PREDEFMETH.PM_STRING_OPEQUALITY : PREDEFMETH.PM_STRING_OPINEQUALITY;
      ek = ek == ExpressionKind.Eq ? ExpressionKind.StringEq : ExpressionKind.StringNotEq;
      return ExpressionBinder.CreateBinopForPredefMethodCall(ek, predefMeth, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprBinOp BindRefCmpOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      arg1 = binder.mustConvert(arg1, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_OBJECT), CONVERTTYPE.NOUDC);
      arg2 = binder.mustConvert(arg2, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_OBJECT), CONVERTTYPE.NOUDC);
      return ExprFactory.CreateBinop(ek, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr BindDelBinOp(
      ExpressionBinder _,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      PREDEFMETH predefMeth = PREDEFMETH.PM_DECIMAL_OPDECREMENT;
      CType RetType = (CType) null;
      switch (ek)
      {
        case ExpressionKind.Eq:
          predefMeth = PREDEFMETH.PM_DELEGATE_OPEQUALITY;
          RetType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
          ek = ExpressionKind.DelegateEq;
          break;
        case ExpressionKind.NotEq:
          predefMeth = PREDEFMETH.PM_DELEGATE_OPINEQUALITY;
          RetType = (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
          ek = ExpressionKind.DelegateNotEq;
          break;
        case ExpressionKind.Add:
          predefMeth = PREDEFMETH.PM_DELEGATE_COMBINE;
          RetType = arg1.Type;
          ek = ExpressionKind.DelegateAdd;
          break;
        case ExpressionKind.Subtract:
          predefMeth = PREDEFMETH.PM_DELEGATE_REMOVE;
          RetType = arg1.Type;
          ek = ExpressionKind.DelegateSubtract;
          break;
      }
      return (Expr) ExpressionBinder.CreateBinopForPredefMethodCall(ek, predefMeth, RetType, arg1, arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr BindEnumBinOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      AggregateType ppEnumType;
      AggregateType enumBinOpType = ExpressionBinder.GetEnumBinOpType(ek, arg1.Type, arg2.Type, out ppEnumType);
      PredefinedType predefinedType1;
      switch (ppEnumType.FundamentalType)
      {
        case FUNDTYPE.FT_U4:
          predefinedType1 = PredefinedType.PT_UINT;
          break;
        case FUNDTYPE.FT_I8:
          predefinedType1 = PredefinedType.PT_LONG;
          break;
        case FUNDTYPE.FT_U8:
          predefinedType1 = PredefinedType.PT_ULONG;
          break;
        default:
          predefinedType1 = PredefinedType.PT_INT;
          break;
      }
      PredefinedType predefinedType2 = predefinedType1;
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(predefinedType2);
      arg1 = binder.mustCast(arg1, predefindType, CONVERTTYPE.NOUDC);
      arg2 = binder.mustCast(arg2, predefindType, CONVERTTYPE.NOUDC);
      Expr expr = (Expr) binder.BindIntOp(ek, flags, arg1, arg2, predefinedType2);
      if (expr.Type != enumBinOpType)
        expr = binder.mustCast(expr, (CType) enumBinOpType, CONVERTTYPE.NOUDC);
      return expr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindLiftedEnumArithmeticBinOp(
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg1,
      Expr arg2)
    {
      CType argType1 = arg1.Type is NullableType type1 ? type1.UnderlyingType : arg1.Type;
      CType argType2 = arg2.Type is NullableType type2 ? type2.UnderlyingType : arg2.Type;
      if (argType1 is NullType)
        argType1 = (CType) argType2.UnderlyingEnumType;
      else if (argType2 is NullType)
        argType2 = (CType) argType1.UnderlyingEnumType;
      AggregateType ppEnumType;
      NullableType nullable1 = TypeManager.GetNullable((CType) ExpressionBinder.GetEnumBinOpType(ek, argType1, argType2, out ppEnumType));
      PredefinedType pt;
      switch (ppEnumType.FundamentalType)
      {
        case FUNDTYPE.FT_U4:
          pt = PredefinedType.PT_UINT;
          break;
        case FUNDTYPE.FT_I8:
          pt = PredefinedType.PT_LONG;
          break;
        case FUNDTYPE.FT_U8:
          pt = PredefinedType.PT_ULONG;
          break;
        default:
          pt = PredefinedType.PT_INT;
          break;
      }
      NullableType nullable2 = TypeManager.GetNullable((CType) ExpressionBinder.GetPredefindType(pt));
      arg1 = this.mustCast(arg1, (CType) nullable2, CONVERTTYPE.NOUDC);
      arg2 = this.mustCast(arg2, (CType) nullable2, CONVERTTYPE.NOUDC);
      ExprBinOp binop = ExprFactory.CreateBinop(ek, (CType) nullable2, arg1, arg2);
      binop.IsLifted = true;
      binop.Flags |= flags;
      return binop.Type != nullable1 ? this.mustCast((Expr) binop, (CType) nullable1, CONVERTTYPE.NOUDC) : (Expr) binop;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr BindEnumUnaOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr arg)
    {
      CType type = ((ExprCast) arg).Argument.Type;
      PredefinedType predefinedType1;
      switch (type.FundamentalType)
      {
        case FUNDTYPE.FT_U4:
          predefinedType1 = PredefinedType.PT_UINT;
          break;
        case FUNDTYPE.FT_I8:
          predefinedType1 = PredefinedType.PT_LONG;
          break;
        case FUNDTYPE.FT_U8:
          predefinedType1 = PredefinedType.PT_ULONG;
          break;
        default:
          predefinedType1 = PredefinedType.PT_INT;
          break;
      }
      PredefinedType predefinedType2 = predefinedType1;
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(predefinedType2);
      arg = binder.mustCast(arg, predefindType, CONVERTTYPE.NOUDC);
      Expr expr = (Expr) binder.BindIntOp(ek, flags, arg, (Expr) null, predefinedType2);
      return binder.MustCastInUncheckedContext(expr, type, CONVERTTYPE.NOUDC);
    }

    private (BinOpKind, EXPRFLAG) GetBinopKindAndFlags(ExpressionKind ek)
    {
      EXPRFLAG exprflag = (EXPRFLAG) 0;
      BinOpKind binOpKind;
      switch (ek)
      {
        case ExpressionKind.Eq:
        case ExpressionKind.NotEq:
          binOpKind = BinOpKind.Equal;
          break;
        case ExpressionKind.LessThan:
        case ExpressionKind.LessThanOrEqual:
        case ExpressionKind.GreaterThan:
        case ExpressionKind.GreaterThanOrEqual:
          binOpKind = BinOpKind.Compare;
          break;
        case ExpressionKind.Add:
          if (this.Context.Checked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          binOpKind = BinOpKind.Add;
          break;
        case ExpressionKind.Subtract:
          if (this.Context.Checked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          binOpKind = BinOpKind.Sub;
          break;
        case ExpressionKind.Multiply:
          if (this.Context.Checked)
            exprflag = EXPRFLAG.EXF_CHECKOVERFLOW;
          binOpKind = BinOpKind.Mul;
          break;
        case ExpressionKind.Divide:
        case ExpressionKind.Modulo:
          exprflag = EXPRFLAG.EXF_ASSGOP;
          if (this.Context.Checked)
            exprflag |= EXPRFLAG.EXF_CHECKOVERFLOW;
          binOpKind = BinOpKind.Mul;
          break;
        case ExpressionKind.BitwiseAnd:
        case ExpressionKind.BitwiseOr:
          binOpKind = BinOpKind.Bitwise;
          break;
        case ExpressionKind.BitwiseExclusiveOr:
          binOpKind = BinOpKind.BitXor;
          break;
        case ExpressionKind.LeftShirt:
        case ExpressionKind.RightShift:
          binOpKind = BinOpKind.Shift;
          break;
        case ExpressionKind.LogicalAnd:
        case ExpressionKind.LogicalOr:
          binOpKind = BinOpKind.Logical;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      return (binOpKind, exprflag);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private ExprOperator BindIntOp(
      ExpressionKind kind,
      EXPRFLAG flags,
      Expr op1,
      Expr op2,
      PredefinedType ptOp)
    {
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(ptOp);
      if (kind == ExpressionKind.Negate)
        return this.BindIntegerNeg(flags, op1, ptOp);
      CType type = kind.IsRelational() ? (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL) : predefindType;
      ExprOperator exprOperator = ExprFactory.CreateOperator(kind, type, op1, op2);
      exprOperator.Flags |= flags;
      return exprOperator;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private ExprOperator BindIntegerNeg(EXPRFLAG flags, Expr op, PredefinedType ptOp)
    {
      CType predefindType = (CType) ExpressionBinder.GetPredefindType(ptOp);
      if (ptOp == PredefinedType.PT_ULONG)
        throw ExpressionBinder.BadOperatorTypesError(op, (Expr) null);
      if (ptOp == PredefinedType.PT_UINT && op.Type.FundamentalType == FUNDTYPE.FT_U4)
        op = this.mustConvertCore(op, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_LONG), CONVERTTYPE.NOUDC);
      return (ExprOperator) ExprFactory.CreateNeg(flags, op);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprOperator BindFloatOp(ExpressionKind kind, Expr op1, Expr op2)
    {
      CType type = kind.IsRelational() ? (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL) : op1.Type;
      ExprOperator exprOperator = ExprFactory.CreateOperator(kind, type, op1, op2);
      exprOperator.Flags &= ~EXPRFLAG.EXF_CHECKOVERFLOW;
      return exprOperator;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "All types used here are builtin and will not be trimmed.")]
    private static ExprConcat BindStringConcat(Expr op1, Expr op2)
    {
      return ExprFactory.CreateConcat(op1, op2);
    }

    private static RuntimeBinderException AmbiguousOperatorError(Expr op1, Expr op2)
    {
      string errorString = op1.ErrorString;
      return op2 == null ? ErrorHandling.Error(ErrorCode.ERR_AmbigUnaryOp, (ErrArg) errorString, (ErrArg) op1.Type) : ErrorHandling.Error(ErrorCode.ERR_AmbigBinaryOps, (ErrArg) errorString, (ErrArg) op1.Type, (ErrArg) op2.Type);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr BindUserBoolOp(ExpressionKind kind, ExprCall pCall)
    {
      CType type = pCall.Type;
      if (!TypeManager.SubstEqualTypes(type, pCall.MethWithInst.Meth().Params[0], type) || !TypeManager.SubstEqualTypes(type, pCall.MethWithInst.Meth().Params[1], type))
        throw ErrorHandling.Error(ErrorCode.ERR_BadBoolOp, (ErrArg) (MethPropWithInst) pCall.MethWithInst);
      ExprList optionalArguments = (ExprList) pCall.OptionalArguments;
      ExprWrap exprWrap = ExpressionBinder.WrapShortLivedExpression(optionalArguments.OptionalElement);
      optionalArguments.OptionalElement = (Expr) exprWrap;
      SymbolTable.PopulateSymbolTableWithName("op_True", (IEnumerable<Type>) null, exprWrap.Type.AssociatedSystemType);
      SymbolTable.PopulateSymbolTableWithName("op_False", (IEnumerable<Type>) null, exprWrap.Type.AssociatedSystemType);
      Expr expr1 = this.bindUDUnop(ExpressionKind.True, (Expr) exprWrap);
      Expr expr2 = this.bindUDUnop(ExpressionKind.False, (Expr) exprWrap);
      if (expr1 == null || expr2 == null)
        throw ErrorHandling.Error(ErrorCode.ERR_MustHaveOpTF, (ErrArg) type);
      Expr expr3 = this.mustConvert(expr1, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL));
      Expr expr4 = this.mustConvert(expr2, (CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL));
      return (Expr) ExprFactory.CreateUserLogOp(type, kind == ExpressionKind.LogicalAnd ? expr4 : expr3, pCall);
    }

    private static AggregateType GetUserDefinedBinopArgumentType(CType type)
    {
      if (type is NullableType nullableType)
        type = nullableType.UnderlyingType;
      return type is AggregateType aggregateType && (aggregateType.IsClassType || aggregateType.IsStructType) && !aggregateType.OwningAggregate.IsSkipUDOps() ? aggregateType : (AggregateType) null;
    }

    private static int GetUserDefinedBinopArgumentTypes(
      CType type1,
      CType type2,
      AggregateType[] rgats)
    {
      int binopArgumentTypes = 0;
      rgats[0] = ExpressionBinder.GetUserDefinedBinopArgumentType(type1);
      if (rgats[0] != null)
        ++binopArgumentTypes;
      rgats[binopArgumentTypes] = ExpressionBinder.GetUserDefinedBinopArgumentType(type2);
      if (rgats[binopArgumentTypes] != null)
        ++binopArgumentTypes;
      if (binopArgumentTypes == 2 && rgats[0] == rgats[1])
        binopArgumentTypes = 1;
      return binopArgumentTypes;
    }

    private static bool UserDefinedBinaryOperatorCanBeLifted(
      ExpressionKind ek,
      MethodSymbol method,
      AggregateType ats,
      TypeArray Params)
    {
      if (!Params[0].IsNonNullableValueType || !Params[1].IsNonNullableValueType)
        return false;
      CType ctype = TypeManager.SubstType(method.RetType, ats);
      if (!ctype.IsNonNullableValueType)
        return false;
      switch (ek)
      {
        case ExpressionKind.Eq:
        case ExpressionKind.NotEq:
          return ctype.IsPredefType(PredefinedType.PT_BOOL) && Params[0] == Params[1];
        case ExpressionKind.LessThan:
        case ExpressionKind.LessThanOrEqual:
        case ExpressionKind.GreaterThan:
        case ExpressionKind.GreaterThanOrEqual:
          return ctype.IsPredefType(PredefinedType.PT_BOOL);
        default:
          return true;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool UserDefinedBinaryOperatorIsApplicable(
      List<CandidateFunctionMember> candidateList,
      ExpressionKind ek,
      MethodSymbol method,
      AggregateType ats,
      Expr arg1,
      Expr arg2,
      bool fDontLift)
    {
      if (!method.isOperator || method.Params.Count != 2)
        return false;
      TypeArray typeArray = TypeManager.SubstTypeArray(method.Params, ats);
      if (this.canConvert(arg1, typeArray[0]) && this.canConvert(arg2, typeArray[1]))
      {
        candidateList.Add(new CandidateFunctionMember(new MethPropWithInst((MethodOrPropertySymbol) method, ats, TypeArray.Empty), typeArray, (byte) 0, false));
        return true;
      }
      if (fDontLift || !ExpressionBinder.UserDefinedBinaryOperatorCanBeLifted(ek, method, ats, typeArray))
        return false;
      CType[] ctypeArray = new CType[2]
      {
        (CType) TypeManager.GetNullable(typeArray[0]),
        (CType) TypeManager.GetNullable(typeArray[1])
      };
      if (!this.canConvert(arg1, ctypeArray[0]) || !this.canConvert(arg2, ctypeArray[1]))
        return false;
      candidateList.Add(new CandidateFunctionMember(new MethPropWithInst((MethodOrPropertySymbol) method, ats, TypeArray.Empty), TypeArray.Allocate(ctypeArray), (byte) 2, false));
      return true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool GetApplicableUserDefinedBinaryOperatorCandidates(
      List<CandidateFunctionMember> candidateList,
      ExpressionKind ek,
      AggregateType type,
      Expr arg1,
      Expr arg2,
      bool fDontLift)
    {
      Name name = ExpressionBinder.ExpressionKindName(ek);
      bool operatorCandidates = false;
      for (MethodSymbol method = SymbolLoader.LookupAggMember(name, type.OwningAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol; method != null; method = method.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol)
      {
        if (this.UserDefinedBinaryOperatorIsApplicable(candidateList, ek, method, type, arg1, arg2, fDontLift))
          operatorCandidates = true;
      }
      return operatorCandidates;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private AggregateType GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(
      List<CandidateFunctionMember> candidateList,
      ExpressionKind ek,
      AggregateType type,
      Expr arg1,
      Expr arg2,
      bool fDontLift,
      AggregateType atsStop)
    {
      for (AggregateType type1 = type; type1 != null && type1 != atsStop; type1 = type1.BaseClass)
      {
        if (this.GetApplicableUserDefinedBinaryOperatorCandidates(candidateList, ek, type1, arg1, arg2, fDontLift))
          return type1;
      }
      return (AggregateType) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindUDBinop(
      ExpressionKind ek,
      Expr arg1,
      Expr arg2,
      bool fDontLift,
      out MethPropWithInst ppmpwi)
    {
      List<CandidateFunctionMember> candidateFunctionMemberList = new List<CandidateFunctionMember>();
      ppmpwi = (MethPropWithInst) null;
      AggregateType[] rgats = new AggregateType[2];
      switch (ExpressionBinder.GetUserDefinedBinopArgumentTypes(arg1.Type, arg2.Type, rgats))
      {
        case 0:
          return (ExprCall) null;
        case 1:
          this.GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(candidateFunctionMemberList, ek, rgats[0], arg1, arg2, fDontLift, (AggregateType) null);
          break;
        default:
          AggregateType candidatesInBaseTypes = this.GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(candidateFunctionMemberList, ek, rgats[0], arg1, arg2, fDontLift, (AggregateType) null);
          this.GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(candidateFunctionMemberList, ek, rgats[1], arg1, arg2, fDontLift, candidatesInBaseTypes);
          break;
      }
      if (candidateFunctionMemberList.IsEmpty<CandidateFunctionMember>())
        return (ExprCall) null;
      ExprList list = ExprFactory.CreateList(arg1, arg2);
      ArgInfos argInfos = new ArgInfos();
      argInfos.carg = 2;
      ExpressionBinder.FillInArgInfoFromArgList(argInfos, (Expr) list);
      CandidateFunctionMember methAmbig1;
      CandidateFunctionMember methAmbig2;
      CandidateFunctionMember bestMethod = this.FindBestMethod(candidateFunctionMemberList, (CType) null, argInfos, out methAmbig1, out methAmbig2);
      ppmpwi = bestMethod != null ? bestMethod.mpwi : throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, (ErrArg) methAmbig1.mpwi, (ErrArg) methAmbig2.mpwi);
      if (bestMethod.ctypeLift != (byte) 0)
        return this.BindLiftedUDBinop(ek, arg1, arg2, bestMethod.@params, bestMethod.mpwi);
      CType typeRet = TypeManager.SubstType(bestMethod.mpwi.Meth().RetType, bestMethod.mpwi.GetType());
      return this.BindUDBinopCall(arg1, arg2, bestMethod.@params, typeRet, bestMethod.mpwi);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindUDBinopCall(
      Expr arg1,
      Expr arg2,
      TypeArray Params,
      CType typeRet,
      MethPropWithInst mpwi)
    {
      arg1 = this.mustConvert(arg1, Params[0]);
      arg2 = this.mustConvert(arg2, Params[1]);
      ExprList list = ExprFactory.CreateList(arg1, arg2);
      ExpressionBinder.CheckUnsafe(arg1.Type);
      ExpressionBinder.CheckUnsafe(arg2.Type);
      ExpressionBinder.CheckUnsafe(typeRet);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, mpwi);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, typeRet, (Expr) list, memGroup, (MethWithInst) null);
      call.MethWithInst = new MethWithInst(mpwi);
      this.verifyMethodArgs((ExprWithArgs) call, (CType) mpwi.GetType());
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprCall BindLiftedUDBinop(
      ExpressionKind ek,
      Expr arg1,
      Expr arg2,
      TypeArray Params,
      MethPropWithInst mpwi)
    {
      Expr expr1 = arg1;
      Expr expr2 = arg2;
      CType ctype1 = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
      TypeArray Params1 = TypeManager.SubstTypeArray(mpwi.Meth().Params, mpwi.GetType());
      if (!this.canConvert(arg1.Type.StripNubs(), Params1[0], CONVERTTYPE.NOUDC))
        expr1 = this.mustConvert(arg1, Params[0]);
      if (!this.canConvert(arg2.Type.StripNubs(), Params1[1], CONVERTTYPE.NOUDC))
        expr2 = this.mustConvert(arg2, Params[1]);
      Expr expr3 = this.mustCast(expr1, Params1[0]);
      Expr expr4 = this.mustCast(expr2, Params1[1]);
      CType ctype2;
      switch (ek)
      {
        case ExpressionKind.Eq:
        case ExpressionKind.NotEq:
          ctype2 = ctype1;
          break;
        case ExpressionKind.LessThan:
        case ExpressionKind.LessThanOrEqual:
        case ExpressionKind.GreaterThan:
        case ExpressionKind.GreaterThanOrEqual:
          ctype2 = ctype1;
          break;
        default:
          ctype2 = (CType) TypeManager.GetNullable(ctype1);
          break;
      }
      ExprCall exprCall1 = this.BindUDBinopCall(expr3, expr4, Params1, ctype1, mpwi);
      ExprList list = ExprFactory.CreateList(expr1, expr2);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, mpwi);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, ctype2, (Expr) list, memGroup, (MethWithInst) null);
      call.MethWithInst = new MethWithInst(mpwi);
      ExprCall exprCall2 = call;
      NullableCallLiftKind nullableCallLiftKind;
      switch (ek)
      {
        case ExpressionKind.Eq:
          nullableCallLiftKind = NullableCallLiftKind.EqualityOperator;
          break;
        case ExpressionKind.NotEq:
          nullableCallLiftKind = NullableCallLiftKind.InequalityOperator;
          break;
        default:
          nullableCallLiftKind = NullableCallLiftKind.Operator;
          break;
      }
      exprCall2.NullableCallLiftKind = nullableCallLiftKind;
      call.CastOfNonLiftedResultToLiftedType = this.mustCast((Expr) exprCall1, ctype2, (CONVERTTYPE) 0);
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static AggregateType GetEnumBinOpType(
      ExpressionKind ek,
      CType argType1,
      CType argType2,
      out AggregateType ppEnumType)
    {
      AggregateType aggregateType1 = argType1 as AggregateType;
      AggregateType aggregateType2 = argType2 as AggregateType;
      AggregateType aggregateType3 = aggregateType1.IsEnumType ? aggregateType1 : aggregateType2;
      AggregateType enumBinOpType = aggregateType3;
      switch (ek)
      {
        case ExpressionKind.Add:
        case ExpressionKind.BitwiseAnd:
        case ExpressionKind.BitwiseOr:
        case ExpressionKind.BitwiseExclusiveOr:
          ppEnumType = aggregateType3;
          return enumBinOpType;
        case ExpressionKind.Subtract:
          if (aggregateType1 == aggregateType2)
          {
            enumBinOpType = aggregateType3.UnderlyingEnumType;
            goto case ExpressionKind.Add;
          }
          else
            goto case ExpressionKind.Add;
        default:
          enumBinOpType = ExpressionBinder.GetPredefindType(PredefinedType.PT_BOOL);
          goto case ExpressionKind.Add;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprBinOp CreateBinopForPredefMethodCall(
      ExpressionKind ek,
      PREDEFMETH predefMeth,
      CType RetType,
      Expr arg1,
      Expr arg2)
    {
      MethodSymbol method = PredefinedMembers.GetMethod(predefMeth);
      ExprBinOp binop = ExprFactory.CreateBinop(ek, RetType, arg1, arg2);
      AggregateType aggregate = TypeManager.GetAggregate(method.getClass(), TypeArray.Empty);
      binop.PredefinedMethodToCall = new MethWithInst(method, aggregate, (TypeArray) null);
      binop.UserDefinedCallMethod = (MethPropWithInst) binop.PredefinedMethodToCall;
      return binop;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprUnaryOp CreateUnaryOpForPredefMethodCall(
      ExpressionKind ek,
      PREDEFMETH predefMeth,
      CType pRetType,
      Expr pArg)
    {
      MethodSymbol method = PredefinedMembers.GetMethod(predefMeth);
      ExprUnaryOp unaryOp = ExprFactory.CreateUnaryOp(ek, pRetType, pArg);
      AggregateType aggregate = TypeManager.GetAggregate(method.getClass(), TypeArray.Empty);
      unaryOp.PredefinedMethodToCall = new MethWithInst(method, aggregate, (TypeArray) null);
      unaryOp.UserDefinedCallMethod = (MethPropWithInst) unaryOp.PredefinedMethodToCall;
      return unaryOp;
    }

    private sealed class BinOpArgInfo
    {
      public Expr arg1;
      public Expr arg2;
      public PredefinedType pt1;
      public PredefinedType pt2;
      public PredefinedType ptRaw1;
      public PredefinedType ptRaw2;
      public CType type1;
      public CType type2;
      public CType typeRaw1;
      public CType typeRaw2;
      public BinOpKind binopKind;
      public BinOpMask mask;

      public BinOpArgInfo(Expr op1, Expr op2)
      {
        this.arg1 = op1;
        this.arg2 = op2;
        this.type1 = this.arg1.Type;
        this.type2 = this.arg2.Type;
        this.typeRaw1 = this.type1.StripNubs();
        this.typeRaw2 = this.type2.StripNubs();
        this.pt1 = this.type1.IsPredefined ? this.type1.PredefinedType : PredefinedType.PT_COUNT;
        this.pt2 = this.type2.IsPredefined ? this.type2.PredefinedType : PredefinedType.PT_COUNT;
        this.ptRaw1 = this.typeRaw1.IsPredefined ? this.typeRaw1.PredefinedType : PredefinedType.PT_COUNT;
        this.ptRaw2 = this.typeRaw2.IsPredefined ? this.typeRaw2.PredefinedType : PredefinedType.PT_COUNT;
      }

      public bool ValidForDelegate() => (this.mask & BinOpMask.Delegate) != 0;

      public bool ValidForEnumAndUnderlyingType() => (this.mask & BinOpMask.EnumUnder) != 0;

      public bool ValidForUnderlyingTypeAndEnum() => (this.mask & BinOpMask.Add) != 0;

      public bool ValidForEnum() => (this.mask & BinOpMask.Enum) != 0;
    }

    private class BinOpSig
    {
      public PredefinedType pt1;
      public PredefinedType pt2;
      public BinOpMask mask;
      public int cbosSkip;
      public ExpressionBinder.PfnBindBinOp pfn;
      public OpSigFlags grfos;
      public BinOpFuncKind fnkind;

      protected BinOpSig()
      {
      }

      public BinOpSig(
        PredefinedType pt1,
        PredefinedType pt2,
        BinOpMask mask,
        int cbosSkip,
        ExpressionBinder.PfnBindBinOp pfn,
        OpSigFlags grfos,
        BinOpFuncKind fnkind)
      {
        this.pt1 = pt1;
        this.pt2 = pt2;
        this.mask = mask;
        this.cbosSkip = cbosSkip;
        this.pfn = pfn;
        this.grfos = grfos;
        this.fnkind = fnkind;
      }

      public bool ConvertOperandsBeforeBinding() => (this.grfos & OpSigFlags.Convert) != 0;

      public bool CanLift() => (this.grfos & OpSigFlags.CanLift) != 0;

      public bool AutoLift() => (this.grfos & OpSigFlags.AutoLift) != 0;
    }

    private sealed class BinOpFullSig : ExpressionBinder.BinOpSig
    {
      private readonly LiftFlags _grflt;
      private readonly CType _type1;
      private readonly CType _type2;

      public BinOpFullSig(
        CType type1,
        CType type2,
        ExpressionBinder.PfnBindBinOp pfn,
        OpSigFlags grfos,
        LiftFlags grflt,
        BinOpFuncKind fnkind)
      {
        this.pt1 = PredefinedType.PT_UNDEFINEDINDEX;
        this.pt2 = PredefinedType.PT_UNDEFINEDINDEX;
        this.mask = BinOpMask.None;
        this.cbosSkip = 0;
        this.pfn = pfn;
        this.grfos = grfos;
        this._type1 = type1;
        this._type2 = type2;
        this._grflt = grflt;
        this.fnkind = fnkind;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      public BinOpFullSig(ExpressionBinder fnc, ExpressionBinder.BinOpSig bos)
      {
        this.pt1 = bos.pt1;
        this.pt2 = bos.pt2;
        this.mask = bos.mask;
        this.cbosSkip = bos.cbosSkip;
        this.pfn = bos.pfn;
        this.grfos = bos.grfos;
        this.fnkind = bos.fnkind;
        this._type1 = this.pt1 != PredefinedType.PT_UNDEFINEDINDEX ? (CType) ExpressionBinder.GetPredefindType(this.pt1) : (CType) null;
        this._type2 = this.pt2 != PredefinedType.PT_UNDEFINEDINDEX ? (CType) ExpressionBinder.GetPredefindType(this.pt2) : (CType) null;
        this._grflt = LiftFlags.None;
      }

      public bool FPreDef() => this.pt1 != PredefinedType.PT_UNDEFINEDINDEX;

      public bool isLifted() => this._grflt != LiftFlags.None;

      public bool ConvertFirst() => (this._grflt & LiftFlags.Convert1) != 0;

      public bool ConvertSecond() => (this._grflt & LiftFlags.Convert2) != 0;

      public CType Type1() => this._type1;

      public CType Type2() => this._type2;
    }

    private delegate bool ConversionFunc(
      Expr pSourceExpr,
      CType pSourceType,
      CType pDestinationType,
      bool needsExprDest,
      out Expr ppDestinationExpr,
      CONVERTTYPE flags);

    private sealed class ExplicitConversion
    {
      private readonly ExpressionBinder _binder;
      private readonly Expr _exprSrc;
      private readonly CType _typeSrc;
      private readonly CType _typeDest;
      private Expr _exprDest;
      private readonly bool _needsExprDest;
      private readonly CONVERTTYPE _flags;

      public ExplicitConversion(
        ExpressionBinder binder,
        Expr exprSrc,
        CType typeSrc,
        CType typeDest,
        bool needsExprDest,
        CONVERTTYPE flags)
      {
        this._binder = binder;
        this._exprSrc = exprSrc;
        this._typeSrc = typeSrc;
        this._typeDest = typeDest;
        this._needsExprDest = needsExprDest;
        this._flags = flags;
        this._exprDest = (Expr) null;
      }

      public Expr ExprDest => this._exprDest;

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      public bool Bind()
      {
        if (this._binder.BindImplicitConversion(this._exprSrc, this._typeSrc, this._typeDest, this._needsExprDest, out this._exprDest, this._flags | CONVERTTYPE.ISEXPLICIT))
          return true;
        if (this._typeSrc == null || this._typeDest == null || this._typeDest is MethodGroupType || this._typeDest is NullableType)
          return false;
        if (this._typeSrc is NullableType)
          return this.bindExplicitConversionFromNub();
        if (this.bindExplicitConversionFromArrayToIList())
          return true;
        switch (this._typeDest.TypeKind)
        {
          case TypeKind.TK_AggregateType:
            switch (this.bindExplicitConversionToAggregate(this._typeDest as AggregateType))
            {
              case AggCastResult.Success:
                return true;
              case AggCastResult.Abort:
                return false;
            }
            break;
          case TypeKind.TK_VoidType:
            return false;
          case TypeKind.TK_NullType:
            return false;
          case TypeKind.TK_ArrayType:
            if (this.bindExplicitConversionToArray((ArrayType) this._typeDest))
              return true;
            break;
          case TypeKind.TK_PointerType:
            if (this.bindExplicitConversionToPointer())
              return true;
            break;
          default:
            return false;
        }
        return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, this._typeDest, this._needsExprDest, out this._exprDest, false);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionFromNub()
      {
        if (this._typeDest.IsValueType && this._binder.BindExplicitConversion((Expr) null, this._typeSrc.StripNubs(), this._typeDest, this._flags | CONVERTTYPE.NOUDC))
        {
          if (this._needsExprDest)
          {
            Expr expr = this._exprSrc;
            if (expr.Type is NullableType)
              expr = ExpressionBinder.BindNubValue(expr);
            if (!this._binder.BindExplicitConversion(expr, expr.Type, this._typeDest, this._needsExprDest, out this._exprDest, this._flags | CONVERTTYPE.NOUDC))
              return false;
            if (this._exprDest is ExprUserDefinedConversion exprDest)
              exprDest.Argument = this._exprSrc;
          }
          return true;
        }
        return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, this._typeDest, this._needsExprDest, out this._exprDest, false);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionFromArrayToIList()
      {
        if (!(this._typeSrc is ArrayType typeSrc) || !typeSrc.IsSZArray || !(this._typeDest is AggregateType typeDest) || !typeDest.IsInterfaceType || typeDest.TypeArgsAll.Count != 1)
          return false;
        AggregateSymbol predefAgg1 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
        AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
        if ((predefAgg1 == null || !SymbolLoader.IsBaseAggregate(predefAgg1, typeDest.OwningAggregate)) && (predefAgg2 == null || !SymbolLoader.IsBaseAggregate(predefAgg2, typeDest.OwningAggregate)) || !CConversions.FExpRefConv(typeSrc.ElementType, typeDest.TypeArgsAll[0]))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_OPERATOR);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionFromIListToArray(ArrayType arrayDest)
      {
        if (!arrayDest.IsSZArray || !(this._typeSrc is AggregateType typeSrc) || !typeSrc.IsInterfaceType || typeSrc.TypeArgsAll.Count != 1)
          return false;
        AggregateSymbol predefAgg1 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
        AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
        if ((predefAgg1 == null || !SymbolLoader.IsBaseAggregate(predefAgg1, typeSrc.OwningAggregate)) && (predefAgg2 == null || !SymbolLoader.IsBaseAggregate(predefAgg2, typeSrc.OwningAggregate)))
          return false;
        CType elementType = arrayDest.ElementType;
        CType typeDst = typeSrc.TypeArgsAll[0];
        if (elementType != typeDst && !CConversions.FExpRefConv(elementType, typeDst))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_OPERATOR);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionFromArrayToArray(ArrayType arraySrc, ArrayType arrayDest)
      {
        if (arraySrc.Rank != arrayDest.Rank || arraySrc.IsSZArray != arrayDest.IsSZArray || !CConversions.FExpRefConv(arraySrc.ElementType, arrayDest.ElementType))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_OPERATOR);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionToArray(ArrayType arrayDest)
      {
        if (this._typeSrc is ArrayType typeSrc)
          return this.bindExplicitConversionFromArrayToArray(typeSrc, arrayDest);
        if (this.bindExplicitConversionFromIListToArray(arrayDest))
          return true;
        if (!this._binder.canConvert((CType) ExpressionBinder.GetPredefindType(PredefinedType.PT_ARRAY), this._typeSrc, CONVERTTYPE.NOUDC))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_OPERATOR);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindExplicitConversionToPointer()
      {
        if (!(this._typeSrc is PointerType) && (this._typeSrc.FundamentalType > FUNDTYPE.FT_U8 || !this._typeSrc.IsNumericType))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionFromEnumToAggregate(AggregateType aggTypeDest)
      {
        if (!this._typeSrc.IsEnumType)
          return AggCastResult.Failure;
        AggregateSymbol owningAggregate = aggTypeDest.OwningAggregate;
        if (owningAggregate.isPredefAgg(PredefinedType.PT_DECIMAL))
          return this.bindExplicitConversionFromEnumToDecimal(aggTypeDest);
        if (!owningAggregate.getThisType().IsNumericType && !owningAggregate.IsEnum() && (!owningAggregate.IsPredefined() || owningAggregate.GetPredefType() != PredefinedType.PT_CHAR))
          return AggCastResult.Failure;
        if (this._exprSrc.GetConst() != null)
        {
          switch (this._binder.bindConstantCast(this._exprSrc, this._typeDest, this._needsExprDest, out this._exprDest, true))
          {
            case ConstCastResult.Success:
              return AggCastResult.Success;
            case ConstCastResult.CheckFailure:
              return AggCastResult.Abort;
          }
        }
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
        return AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionFromDecimalToEnum(AggregateType aggTypeDest)
      {
        if (this._exprSrc.GetConst() != null)
        {
          switch (this._binder.bindConstantCast(this._exprSrc, this._typeDest, this._needsExprDest, out this._exprDest, true))
          {
            case ConstCastResult.Success:
              return AggCastResult.Success;
            case ConstCastResult.CheckFailure:
              if ((this._flags & CONVERTTYPE.CHECKOVERFLOW) == (CONVERTTYPE) 0)
                return AggCastResult.Abort;
              break;
          }
        }
        bool flag = true;
        if (this._needsExprDest)
        {
          flag = this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, (CType) aggTypeDest.UnderlyingEnumType, this._needsExprDest, out this._exprDest, false);
          if (flag)
            this._binder.bindSimpleCast(this._exprDest, this._typeDest, out this._exprDest);
        }
        return !flag ? AggCastResult.Failure : AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionFromEnumToDecimal(AggregateType aggTypeDest)
      {
        AggregateType underlyingEnumType = this._typeSrc.UnderlyingEnumType;
        Expr pexprDest;
        if (this._exprSrc == null)
          pexprDest = (Expr) null;
        else
          this._binder.bindSimpleCast(this._exprSrc, (CType) underlyingEnumType, out pexprDest);
        if (pexprDest.GetConst() != null)
        {
          switch (this._binder.bindConstantCast(pexprDest, this._typeDest, this._needsExprDest, out this._exprDest, true))
          {
            case ConstCastResult.Success:
              return AggCastResult.Success;
            case ConstCastResult.CheckFailure:
              if ((this._flags & CONVERTTYPE.CHECKOVERFLOW) == (CONVERTTYPE) 0)
                return AggCastResult.Abort;
              break;
          }
        }
        if (this._needsExprDest)
          this._binder.bindUserDefinedConversion(pexprDest, (CType) underlyingEnumType, (CType) aggTypeDest, this._needsExprDest, out this._exprDest, false);
        return AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionToEnum(AggregateType aggTypeDest)
      {
        if (!aggTypeDest.OwningAggregate.IsEnum())
          return AggCastResult.Failure;
        if (this._typeSrc.IsPredefType(PredefinedType.PT_DECIMAL))
          return this.bindExplicitConversionFromDecimalToEnum(aggTypeDest);
        if (this._typeSrc.IsNumericType || this._typeSrc.IsPredefined && this._typeSrc.PredefinedType == PredefinedType.PT_CHAR)
        {
          if (this._exprSrc.GetConst() != null)
          {
            switch (this._binder.bindConstantCast(this._exprSrc, this._typeDest, this._needsExprDest, out this._exprDest, true))
            {
              case ConstCastResult.Success:
                return AggCastResult.Success;
              case ConstCastResult.CheckFailure:
                return AggCastResult.Abort;
            }
          }
          if (this._needsExprDest)
            this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
          return AggCastResult.Success;
        }
        if (!this._typeSrc.IsPredefined || !this._typeSrc.IsPredefType(PredefinedType.PT_OBJECT) && !this._typeSrc.IsPredefType(PredefinedType.PT_VALUE) && !this._typeSrc.IsPredefType(PredefinedType.PT_ENUM))
          return AggCastResult.Failure;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_INDEXER);
        return AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionBetweenSimpleTypes(AggregateType aggTypeDest)
      {
        if (!this._typeSrc.IsSimpleType || !aggTypeDest.IsSimpleType)
          return AggCastResult.Failure;
        AggregateSymbol owningAggregate = aggTypeDest.OwningAggregate;
        PredefinedType predefinedType = this._typeSrc.PredefinedType;
        PredefinedType predefType = owningAggregate.GetPredefType();
        if (ExpressionBinder.GetConvKind(predefinedType, predefType) != ConvKind.Explicit)
          return AggCastResult.Failure;
        if (this._exprSrc.GetConst() != null)
        {
          switch (this._binder.bindConstantCast(this._exprSrc, this._typeDest, this._needsExprDest, out this._exprDest, true))
          {
            case ConstCastResult.Success:
              return AggCastResult.Success;
            case ConstCastResult.CheckFailure:
              if ((this._flags & CONVERTTYPE.CHECKOVERFLOW) == (CONVERTTYPE) 0)
                return AggCastResult.Abort;
              break;
          }
        }
        bool flag = true;
        if (this._needsExprDest)
        {
          if (ExpressionBinder.isUserDefinedConversion(predefinedType, predefType))
            flag = this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, (CType) aggTypeDest, this._needsExprDest, out this._exprDest, false);
          else
            this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, (this._flags & CONVERTTYPE.CHECKOVERFLOW) != (CONVERTTYPE) 0 ? EXPRFLAG.EXF_CHECKOVERFLOW : (EXPRFLAG) 0);
        }
        return !flag ? AggCastResult.Failure : AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionBetweenAggregates(AggregateType aggTypeDest)
      {
        if (!(this._typeSrc is AggregateType typeSrc))
          return AggCastResult.Failure;
        AggregateSymbol owningAggregate1 = typeSrc.OwningAggregate;
        AggregateSymbol owningAggregate2 = aggTypeDest.OwningAggregate;
        if (SymbolLoader.HasBaseConversion((CType) aggTypeDest, (CType) typeSrc))
        {
          if (this._needsExprDest)
          {
            ref readonly ExpressionBinder local1 = ref this._binder;
            Expr exprSrc1 = this._exprSrc;
            CType typeDest = this._typeDest;
            ref Expr local2 = ref this._exprDest;
            int exprFlags;
            if (!owningAggregate2.IsValueType() || owningAggregate1.getThisType().FundamentalType != FUNDTYPE.FT_REF)
            {
              Expr exprSrc2 = this._exprSrc;
              exprFlags = 8 | (exprSrc2 != null ? (int) (exprSrc2.Flags & EXPRFLAG.EXF_CANTBENULL) : 0);
            }
            else
              exprFlags = 4;
            local1.bindSimpleCast(exprSrc1, typeDest, out local2, (EXPRFLAG) exprFlags);
          }
          return AggCastResult.Success;
        }
        if ((!owningAggregate1.IsClass() || owningAggregate1.IsSealed() || !owningAggregate2.IsInterface()) && (!owningAggregate1.IsInterface() || !owningAggregate2.IsClass() || owningAggregate2.IsSealed()) && (!owningAggregate1.IsInterface() || !owningAggregate2.IsInterface()) && !CConversions.HasGenericDelegateExplicitReferenceConversion(this._typeSrc, aggTypeDest))
          return AggCastResult.Failure;
        if (this._needsExprDest)
        {
          ref readonly ExpressionBinder local3 = ref this._binder;
          Expr exprSrc3 = this._exprSrc;
          CType typeDest = this._typeDest;
          ref Expr local4 = ref this._exprDest;
          Expr exprSrc4 = this._exprSrc;
          int exprFlags = 8 | (exprSrc4 != null ? (int) (exprSrc4.Flags & EXPRFLAG.EXF_CANTBENULL) : 0);
          local3.bindSimpleCast(exprSrc3, typeDest, out local4, (EXPRFLAG) exprFlags);
        }
        return AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionFromPointerToInt(AggregateType aggTypeDest)
      {
        if (!(this._typeSrc is PointerType) || aggTypeDest.FundamentalType > FUNDTYPE.FT_U8 || !aggTypeDest.IsNumericType)
          return AggCastResult.Failure;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
        return AggCastResult.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private AggCastResult bindExplicitConversionToAggregate(AggregateType aggTypeDest)
      {
        AggCastResult aggregate1 = this.bindExplicitConversionFromEnumToAggregate(aggTypeDest);
        if (aggregate1 != AggCastResult.Failure)
          return aggregate1;
        AggCastResult aggregate2 = this.bindExplicitConversionToEnum(aggTypeDest);
        if (aggregate2 != AggCastResult.Failure)
          return aggregate2;
        AggCastResult aggregate3 = this.bindExplicitConversionBetweenSimpleTypes(aggTypeDest);
        if (aggregate3 != AggCastResult.Failure)
          return aggregate3;
        AggCastResult aggregate4 = this.bindExplicitConversionBetweenAggregates(aggTypeDest);
        if (aggregate4 != AggCastResult.Failure)
          return aggregate4;
        AggCastResult aggregate5 = this.bindExplicitConversionFromPointerToInt(aggTypeDest);
        if (aggregate5 != AggCastResult.Failure)
          return aggregate5;
        return this._typeSrc is VoidType ? AggCastResult.Abort : AggCastResult.Failure;
      }
    }

    private delegate Expr PfnBindBinOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr op1,
      Expr op2);

    private delegate Expr PfnBindUnaOp(
      ExpressionBinder binder,
      ExpressionKind ek,
      EXPRFLAG flags,
      Expr op);

    public enum NamedArgumentsKind
    {
      None,
      Positioning,
      NonTrailing,
    }

    internal sealed class GroupToArgsBinder
    {
      private readonly ExpressionBinder _pExprBinder;
      private bool _fCandidatesUnsupported;
      private readonly BindingFlag _fBindFlags;
      private readonly ExprMemberGroup _pGroup;
      private readonly ArgInfos _pArguments;
      private readonly ArgInfos _pOriginalArguments;
      private readonly ExpressionBinder.NamedArgumentsKind _namedArgumentsKind;
      private AggregateType _pCurrentType;
      private MethodOrPropertySymbol _pCurrentSym;
      private TypeArray _pCurrentTypeArgs;
      private TypeArray _pCurrentParameters;
      private int _nArgBest;
      private readonly ExpressionBinder.GroupToArgsBinderResult _results;
      private readonly List<CandidateFunctionMember> _methList;
      private readonly MethPropWithInst _mpwiParamTypeConstraints;
      private readonly MethPropWithInst _mpwiBogus;
      private readonly MethPropWithInst _misnamed;
      private readonly MethPropWithInst _mpwiCantInferInstArg;
      private readonly MethWithType _mwtBadArity;
      private Name _pInvalidSpecifiedName;
      private Name _pNameUsedInPositionalArgument;
      private Name _pDuplicateSpecifiedName;
      private readonly List<CType> _HiddenTypes;
      private bool _bArgumentsChangedForNamedOrOptionalArguments;

      public GroupToArgsBinder(
        ExpressionBinder exprBinder,
        BindingFlag bindFlags,
        ExprMemberGroup grp,
        ArgInfos args,
        ArgInfos originalArgs,
        ExpressionBinder.NamedArgumentsKind namedArgumentsKind)
      {
        this._pExprBinder = exprBinder;
        this._fCandidatesUnsupported = false;
        this._fBindFlags = bindFlags;
        this._pGroup = grp;
        this._pArguments = args;
        this._pOriginalArguments = originalArgs;
        this._namedArgumentsKind = namedArgumentsKind;
        this._pCurrentType = (AggregateType) null;
        this._pCurrentSym = (MethodOrPropertySymbol) null;
        this._pCurrentTypeArgs = (TypeArray) null;
        this._pCurrentParameters = (TypeArray) null;
        this._nArgBest = -1;
        this._results = new ExpressionBinder.GroupToArgsBinderResult();
        this._methList = new List<CandidateFunctionMember>();
        this._mpwiParamTypeConstraints = new MethPropWithInst();
        this._mpwiBogus = new MethPropWithInst();
        this._misnamed = new MethPropWithInst();
        this._mpwiCantInferInstArg = new MethPropWithInst();
        this._mwtBadArity = new MethWithType();
        this._HiddenTypes = new List<CType>();
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      public void Bind()
      {
        this.LookForCandidates();
        if (!this.GetResultOfBind())
          throw this.ReportErrorsOnFailure();
      }

      public ExpressionBinder.GroupToArgsBinderResult GetResultsOfBind() => this._results;

      private static CType GetTypeQualifier(ExprMemberGroup pGroup)
      {
        if ((pGroup.Flags & EXPRFLAG.EXF_CTOR) != (EXPRFLAG) 0)
          return pGroup.ParentType;
        return pGroup.OptionalObject?.Type;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private void LookForCandidates()
      {
        bool fExpanded = false;
        bool flag1 = true;
        bool flag2 = true;
        bool flag3 = false;
        symbmask_t mask = (symbmask_t) (1 << (int) (this._pGroup.SymKind & (SYMKIND) 31));
        CMemberLookupResults.CMethodIterator methodIterator = this._pGroup.MemberLookupResults.GetMethodIterator(ExpressionBinder.GroupToArgsBinder.GetTypeQualifier(this._pGroup), this._pExprBinder.ContextForMemberLookup, this._pGroup.TypeArgs.Count, this._pGroup.Flags, mask, this._namedArgumentsKind == ExpressionBinder.NamedArgumentsKind.NonTrailing ? this._pOriginalArguments : (ArgInfos) null);
        while (true)
        {
          do
          {
            bool flag4 = false;
            if (flag1 && !fExpanded)
              flag4 = fExpanded = this.ConstructExpandedParameters();
            if (!flag4)
            {
              fExpanded = false;
              if (this.GetNextSym(methodIterator))
              {
                this._pCurrentParameters = this._pCurrentSym.Params;
                flag1 = true;
              }
              else
                goto label_38;
            }
            if (this._bArgumentsChangedForNamedOrOptionalArguments)
            {
              this._bArgumentsChangedForNamedOrOptionalArguments = false;
              ExpressionBinder.GroupToArgsBinder.CopyArgInfos(this._pOriginalArguments, this._pArguments);
            }
            if (this._namedArgumentsKind == ExpressionBinder.NamedArgumentsKind.Positioning)
            {
              if (!this.ReOrderArgsForNamedArguments())
                continue;
            }
            else if (this.HasOptionalParameters() && !this.AddArgumentsForOptionalParameters())
              continue;
            if (!flag4)
            {
              flag3 = true;
              flag2 &= CSemanticChecker.CheckBogus((Symbol) this._pCurrentSym);
              if (this._pCurrentParameters.Count != this._pArguments.carg)
                flag1 = true;
            }
          }
          while (!methodIterator.CanUseCurrentSymbol);
          ExpressionBinder.GroupToArgsBinder.Result currentTypeArgs = this.DetermineCurrentTypeArgs();
          if (currentTypeArgs != ExpressionBinder.GroupToArgsBinder.Result.Success)
          {
            flag1 = currentTypeArgs == ExpressionBinder.GroupToArgsBinder.Result.Failure_SearchForExpanded;
          }
          else
          {
            bool flag5 = !methodIterator.IsCurrentSymbolInaccessible;
            if (!flag5 && (!this._methList.IsEmpty<CandidateFunctionMember>() || (bool) (SymWithType) this._results.InaccessibleResult))
            {
              flag1 = false;
            }
            else
            {
              bool flag6 = flag5 && methodIterator.IsCurrentSymbolMisnamed;
              if (flag6 && (!this._methList.IsEmpty<CandidateFunctionMember>() || (bool) (SymWithType) this._results.InaccessibleResult || (bool) (SymWithType) this._misnamed))
              {
                flag1 = false;
              }
              else
              {
                bool flag7 = flag5 && !flag6 && methodIterator.IsCurrentSymbolBogus;
                if (flag7 && (!this._methList.IsEmpty<CandidateFunctionMember>() || (bool) (SymWithType) this._results.InaccessibleResult || (bool) (SymWithType) this._mpwiBogus || (bool) (SymWithType) this._misnamed))
                  flag1 = false;
                else if (!this.ArgumentsAreConvertible())
                {
                  flag1 = true;
                }
                else
                {
                  if (!flag5)
                    this._results.InaccessibleResult.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
                  else if (flag6)
                    this._misnamed.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
                  else if (flag7)
                  {
                    this._mpwiBogus.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
                  }
                  else
                  {
                    this._methList.Add(new CandidateFunctionMember(new MethPropWithInst(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs), this._pCurrentParameters, (byte) 0, fExpanded));
                    if (this._pCurrentType.IsInterfaceType)
                    {
                      foreach (CType ctype in this._pCurrentType.IfacesAll.Items)
                        this._HiddenTypes.Add(ctype);
                      this._HiddenTypes.Add((CType) SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT));
                    }
                  }
                  flag1 = false;
                }
              }
            }
          }
        }
label_38:
        this._fCandidatesUnsupported = flag2 & flag3;
        if (!this._bArgumentsChangedForNamedOrOptionalArguments)
          return;
        ExpressionBinder.GroupToArgsBinder.CopyArgInfos(this._pOriginalArguments, this._pArguments);
      }

      private static void CopyArgInfos(ArgInfos src, ArgInfos dst)
      {
        dst.carg = src.carg;
        dst.types = src.types;
        dst.prgexpr.Clear();
        for (int index = 0; index < src.prgexpr.Count; ++index)
          dst.prgexpr.Add(src.prgexpr[index]);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool GetResultOfBind()
      {
        if (this._methList.IsEmpty<CandidateFunctionMember>())
          return false;
        CandidateFunctionMember candidateFunctionMember;
        if (this._methList.Count == 1)
        {
          candidateFunctionMember = this._methList.Head<CandidateFunctionMember>();
        }
        else
        {
          CandidateFunctionMember methAmbig1;
          CandidateFunctionMember methAmbig2;
          candidateFunctionMember = this._pExprBinder.FindBestMethod(this._methList, this._pGroup.OptionalObject?.Type, this._pArguments, out methAmbig1, out methAmbig2);
          if (candidateFunctionMember == null)
          {
            if (methAmbig1.@params != methAmbig2.@params || methAmbig1.mpwi.MethProp().Params.Count != methAmbig2.mpwi.MethProp().Params.Count || methAmbig1.mpwi.TypeArgs != methAmbig2.mpwi.TypeArgs || methAmbig1.mpwi.GetType() != methAmbig2.mpwi.GetType() || methAmbig1.mpwi.MethProp().Params == methAmbig2.mpwi.MethProp().Params)
              throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, (ErrArg) methAmbig1.mpwi, (ErrArg) methAmbig2.mpwi);
            throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, (ErrArg) (Symbol) methAmbig1.mpwi.MethProp(), (ErrArg) (Symbol) methAmbig2.mpwi.MethProp());
          }
        }
        this._results.BestResult = candidateFunctionMember.mpwi;
        this.ReportErrorsOnSuccess();
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool ReOrderArgsForNamedArguments()
      {
        MethodOrPropertySymbol mostDerivedMethod = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this._pCurrentSym, this._pGroup.OptionalObject);
        if (mostDerivedMethod == null)
          return false;
        int count = this._pCurrentParameters.Count;
        if (count == 0 || count < this._pArguments.carg || !this.NamedArgumentNamesAppearInParameterList(mostDerivedMethod))
          return false;
        this._bArgumentsChangedForNamedOrOptionalArguments = ExpressionBinder.GroupToArgsBinder.ReOrderArgsForNamedArguments(mostDerivedMethod, this._pCurrentParameters, this._pCurrentType, this._pGroup, this._pArguments);
        return this._bArgumentsChangedForNamedOrOptionalArguments;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      internal static bool ReOrderArgsForNamedArguments(
        MethodOrPropertySymbol methprop,
        TypeArray pCurrentParameters,
        AggregateType pCurrentType,
        ExprMemberGroup pGroup,
        ArgInfos pArguments)
      {
        int count = pCurrentParameters.Count;
        Expr[] exprArray = new Expr[count];
        int index1 = 0;
        Expr expr1 = (Expr) null;
        TypeArray typeArray = TypeManager.SubstTypeArray(pCurrentParameters, pCurrentType, pGroup.TypeArgs);
        foreach (Name parameterName in methprop.ParameterNames)
        {
          if (index1 < pCurrentParameters.Count)
          {
            if (methprop.isParamArray && index1 < pArguments.carg && pArguments.prgexpr[index1] is ExprArrayInit exprArrayInit1 && exprArrayInit1.GeneratedForParamArray)
              expr1 = pArguments.prgexpr[index1];
            if (index1 < pArguments.carg && !(pArguments.prgexpr[index1] is ExprNamedArgumentSpecification) && (!(pArguments.prgexpr[index1] is ExprArrayInit exprArrayInit2) || !exprArrayInit2.GeneratedForParamArray))
            {
              exprArray[index1] = pArguments.prgexpr[index1++];
            }
            else
            {
              Expr expr2 = ExpressionBinder.GroupToArgsBinder.FindArgumentWithName(pArguments, parameterName);
              if (expr2 == null)
              {
                if (methprop.IsParameterOptional(index1))
                {
                  expr2 = ExpressionBinder.GroupToArgsBinder.GenerateOptionalArgument(methprop, typeArray[index1], index1);
                }
                else
                {
                  if (expr1 == null || index1 != methprop.Params.Count - 1)
                    return false;
                  expr2 = expr1;
                }
              }
              exprArray[index1++] = expr2;
            }
          }
          else
            break;
        }
        CType[] ctypeArray = new CType[pCurrentParameters.Count];
        for (int index2 = 0; index2 < count; ++index2)
        {
          if (index2 < pArguments.prgexpr.Count)
            pArguments.prgexpr[index2] = exprArray[index2];
          else
            pArguments.prgexpr.Add(exprArray[index2]);
          ctypeArray[index2] = pArguments.prgexpr[index2].Type;
        }
        pArguments.carg = pCurrentParameters.Count;
        pArguments.types = TypeArray.Allocate(ctypeArray);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private static Expr GenerateOptionalArgument(
        MethodOrPropertySymbol methprop,
        CType type,
        int index)
      {
        CType type1 = type;
        CType ctype = type.StripNubs();
        Expr optionalArgument;
        if (methprop.HasDefaultParameterValue(index))
        {
          CType valueConstValType = methprop.GetDefaultParameterValueConstValType(index);
          ConstVal defaultParameterValue = methprop.GetDefaultParameterValue(index);
          optionalArgument = !valueConstValType.IsPredefType(PredefinedType.PT_DATETIME) || !ctype.IsPredefType(PredefinedType.PT_DATETIME) && !ctype.IsPredefType(PredefinedType.PT_OBJECT) && !ctype.IsPredefType(PredefinedType.PT_VALUE) ? (!valueConstValType.IsSimpleOrEnumOrString ? (!type1.IsReferenceType && !(type1 is NullableType) || !defaultParameterValue.IsNullRef ? ExprFactory.CreateZeroInit(type1) : (Expr) ExprFactory.CreateNull()) : (Expr) ExprFactory.CreateConstant(!ctype.IsEnumType || valueConstValType != ctype.UnderlyingEnumType ? valueConstValType : ctype, defaultParameterValue)) : (Expr) ExprFactory.CreateConstant((CType) SymbolLoader.GetPredefindType(PredefinedType.PT_DATETIME), ConstVal.Get((object) DateTime.FromBinary(defaultParameterValue.Int64Val)));
        }
        else if (type1.IsPredefType(PredefinedType.PT_OBJECT))
        {
          if (methprop.MarshalAsObject(index))
          {
            optionalArgument = (Expr) ExprFactory.CreateNull();
          }
          else
          {
            AggregateSymbol predefAgg = SymbolLoader.GetPredefAgg(PredefinedType.PT_MISSING);
            FieldWithType field1 = new FieldWithType(SymbolLoader.LookupAggMember(NameManager.GetPredefinedName(PredefinedName.PN_CAP_VALUE), predefAgg, symbmask_t.MASK_FieldSymbol) as FieldSymbol, predefAgg.getThisType());
            ExprField field2 = ExprFactory.CreateField((CType) predefAgg.getThisType(), (Expr) null, field1);
            optionalArgument = (Expr) ExprFactory.CreateCast(type, (Expr) field2);
          }
        }
        else
          optionalArgument = ExprFactory.CreateZeroInit(type1);
        optionalArgument.IsOptionalArgument = true;
        return optionalArgument;
      }

      private static MethodOrPropertySymbol FindMostDerivedMethod(
        MethodOrPropertySymbol pMethProp,
        Expr pObject)
      {
        return ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(pMethProp, pObject?.Type);
      }

      public static MethodOrPropertySymbol FindMostDerivedMethod(
        MethodOrPropertySymbol pMethProp,
        CType pType)
      {
        bool flag = false;
        if (!(pMethProp is MethodSymbol mostDerivedMethod))
        {
          PropertySymbol propertySymbol = (PropertySymbol) pMethProp;
          mostDerivedMethod = propertySymbol.GetterMethod ?? propertySymbol.SetterMethod;
          if (mostDerivedMethod == null)
            return (MethodOrPropertySymbol) null;
          flag = propertySymbol is IndexerSymbol;
        }
        if (!mostDerivedMethod.isVirtual || pType == null)
          return (MethodOrPropertySymbol) mostDerivedMethod;
        MethodSymbol methodSymbol = mostDerivedMethod.swtSlot?.Meth();
        if (methodSymbol != null)
          mostDerivedMethod = methodSymbol;
        if (!(pType is AggregateType aggregateType))
          return (MethodOrPropertySymbol) mostDerivedMethod;
        for (AggregateSymbol agg = aggregateType.OwningAggregate; agg?.GetBaseAgg() != null; agg = agg.GetBaseAgg())
        {
          for (MethodOrPropertySymbol orPropertySymbol = SymbolLoader.LookupAggMember(mostDerivedMethod.name, agg, symbmask_t.MASK_MethodSymbol | symbmask_t.MASK_PropertySymbol) as MethodOrPropertySymbol; orPropertySymbol != null; orPropertySymbol = orPropertySymbol.LookupNext(symbmask_t.MASK_MethodSymbol | symbmask_t.MASK_PropertySymbol) as MethodOrPropertySymbol)
          {
            if (orPropertySymbol.isOverride && orPropertySymbol.swtSlot.Sym != null && orPropertySymbol.swtSlot.Sym == mostDerivedMethod)
              return flag ? (MethodOrPropertySymbol) ((MethodSymbol) orPropertySymbol).getProperty() : orPropertySymbol;
          }
        }
        return (MethodOrPropertySymbol) mostDerivedMethod;
      }

      private bool HasOptionalParameters()
      {
        MethodOrPropertySymbol mostDerivedMethod = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this._pCurrentSym, this._pGroup.OptionalObject);
        return mostDerivedMethod != null && mostDerivedMethod.HasOptionalParameters();
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool AddArgumentsForOptionalParameters()
      {
        if (this._pCurrentParameters.Count <= this._pArguments.carg)
          return true;
        MethodOrPropertySymbol mostDerivedMethod = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this._pCurrentSym, this._pGroup.OptionalObject);
        if (mostDerivedMethod == null)
          return false;
        int carg = this._pArguments.carg;
        int index1 = 0;
        TypeArray typeArray = TypeManager.SubstTypeArray(this._pCurrentParameters, this._pCurrentType, this._pGroup.TypeArgs);
        Expr[] exprArray = new Expr[this._pCurrentParameters.Count - carg];
        while (carg < typeArray.Count)
        {
          if (!mostDerivedMethod.IsParameterOptional(carg))
            return false;
          exprArray[index1] = ExpressionBinder.GroupToArgsBinder.GenerateOptionalArgument(mostDerivedMethod, typeArray[carg], carg);
          ++carg;
          ++index1;
        }
        for (int index2 = 0; index2 < index1; ++index2)
          this._pArguments.prgexpr.Add(exprArray[index2]);
        CType[] ctypeArray = new CType[typeArray.Count];
        for (int index3 = 0; index3 < typeArray.Count; ++index3)
          ctypeArray[index3] = this._pArguments.prgexpr[index3].Type;
        this._pArguments.types = TypeArray.Allocate(ctypeArray);
        this._pArguments.carg = typeArray.Count;
        this._bArgumentsChangedForNamedOrOptionalArguments = true;
        return true;
      }

      private static Expr FindArgumentWithName(ArgInfos pArguments, Name pName)
      {
        List<Expr> prgexpr = pArguments.prgexpr;
        for (int index = 0; index < pArguments.carg; ++index)
        {
          Expr argumentWithName = prgexpr[index];
          if (argumentWithName is ExprNamedArgumentSpecification argumentSpecification && argumentSpecification.Name == pName)
            return argumentWithName;
        }
        return (Expr) null;
      }

      private bool NamedArgumentNamesAppearInParameterList(MethodOrPropertySymbol methprop)
      {
        List<Name> list = methprop.ParameterNames;
        HashSet<Name> nameSet = new HashSet<Name>();
        for (int index = 0; index < this._pArguments.carg; ++index)
        {
          if (!(this._pArguments.prgexpr[index] is ExprNamedArgumentSpecification argumentSpecification))
          {
            if (!list.IsEmpty<Name>())
              list = list.Tail<Name>();
          }
          else
          {
            Name name = argumentSpecification.Name;
            if (!methprop.ParameterNames.Contains(name))
            {
              if (this._pInvalidSpecifiedName == null)
                this._pInvalidSpecifiedName = name;
              return false;
            }
            if (!list.Contains(name))
            {
              if (this._pNameUsedInPositionalArgument == null)
                this._pNameUsedInPositionalArgument = name;
              return false;
            }
            if (!nameSet.Add(name))
            {
              if (this._pDuplicateSpecifiedName == null)
                this._pDuplicateSpecifiedName = name;
              return false;
            }
          }
        }
        return true;
      }

      private bool GetNextSym(CMemberLookupResults.CMethodIterator iterator)
      {
        if (!iterator.MoveNext())
          return false;
        this._pCurrentSym = iterator.CurrentSymbol;
        AggregateType currentType = iterator.CurrentType;
        if (this._pCurrentType != currentType && this._pCurrentType != null && !this._methList.IsEmpty<CandidateFunctionMember>() && !this._methList.Head<CandidateFunctionMember>().mpwi.GetType().IsInterfaceType)
          return false;
        this._pCurrentType = currentType;
        while (this._HiddenTypes.Contains((CType) this._pCurrentType))
        {
          while (iterator.CurrentType == this._pCurrentType)
            iterator.MoveNext();
          this._pCurrentSym = iterator.CurrentSymbol;
          this._pCurrentType = iterator.CurrentType;
          if (iterator.AtEnd)
            return false;
        }
        return true;
      }

      private bool ConstructExpandedParameters()
      {
        if (this._pCurrentSym == null || this._pArguments == null || this._pCurrentParameters == null || (this._fBindFlags & BindingFlag.BIND_NOPARAMS) != (BindingFlag) 0 || !this._pCurrentSym.isParamArray)
          return false;
        int num = 0;
        for (int carg = this._pArguments.carg; carg < this._pCurrentSym.Params.Count; ++carg)
        {
          if (this._pCurrentSym.IsParameterOptional(carg))
            ++num;
        }
        return this._pArguments.carg + num >= this._pCurrentParameters.Count - 1 && ExpressionBinder.TryGetExpandedParams(this._pCurrentSym.Params, this._pArguments.carg, out this._pCurrentParameters);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private ExpressionBinder.GroupToArgsBinder.Result DetermineCurrentTypeArgs()
      {
        TypeArray typeArgs = this._pGroup.TypeArgs;
        if (this._pCurrentSym is MethodSymbol pCurrentSym && pCurrentSym.typeVars.Count != typeArgs.Count)
        {
          if (typeArgs.Count > 0)
          {
            if (!(bool) (SymWithType) this._mwtBadArity)
              this._mwtBadArity.Set((Symbol) pCurrentSym, this._pCurrentType);
            return ExpressionBinder.GroupToArgsBinder.Result.Failure_NoSearchForExpanded;
          }
          if (!MethodTypeInferrer.Infer(this._pExprBinder, pCurrentSym, this._pCurrentParameters, this._pArguments, out this._pCurrentTypeArgs))
          {
            if (this._results.IsBetterUninferableResult(this._pCurrentTypeArgs))
            {
              TypeArray typeVars = pCurrentSym.typeVars;
              if (typeVars != null && this._pCurrentTypeArgs != null && typeVars.Count == this._pCurrentTypeArgs.Count)
                this._mpwiCantInferInstArg.Set((MethodOrPropertySymbol) pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
              else
                this._mpwiCantInferInstArg.Set((MethodOrPropertySymbol) pCurrentSym, this._pCurrentType, typeVars);
            }
            return ExpressionBinder.GroupToArgsBinder.Result.Failure_SearchForExpanded;
          }
        }
        else
          this._pCurrentTypeArgs = typeArgs;
        return ExpressionBinder.GroupToArgsBinder.Result.Success;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool ArgumentsAreConvertible()
      {
        bool flag = false;
        if (this._pArguments.carg != 0)
        {
          this.UpdateArguments();
          for (int i = 0; i < this._pArguments.carg; ++i)
          {
            CType currentParameter = this._pCurrentParameters[i];
            if (!TypeBind.CheckConstraints(currentParameter, CheckConstraintsFlags.NoErrors) && !ExpressionBinder.GroupToArgsBinder.DoesTypeArgumentsContainErrorSym(currentParameter))
            {
              this._mpwiParamTypeConstraints.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
              return false;
            }
          }
          for (int index = 0; index < this._pArguments.carg; ++index)
          {
            CType currentParameter = this._pCurrentParameters[index];
            flag |= ExpressionBinder.GroupToArgsBinder.DoesTypeArgumentsContainErrorSym(currentParameter);
            Expr expr = this._pArguments.prgexpr[index];
            if (expr is ExprNamedArgumentSpecification argumentSpecification)
              expr = argumentSpecification.Value;
            if (!this._pExprBinder.canConvert(expr, currentParameter) && !flag)
            {
              if (index > this._nArgBest)
              {
                this._nArgBest = index;
                if (!(bool) (SymWithType) this._results.BestResult)
                  this._results.BestResult.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
              }
              else if (index == this._nArgBest && this._pArguments.types[index] != currentParameter && (this._pArguments.types[index] is ParameterModifierType type ? type.ParameterType : this._pArguments.types[index]) == (currentParameter is ParameterModifierType parameterModifierType ? parameterModifierType.ParameterType : currentParameter) && !(bool) (SymWithType) this._results.BestResult)
                this._results.BestResult.Set(this._pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
              return false;
            }
          }
        }
        if (!flag)
          return true;
        if (this._results.IsBetterUninferableResult(this._pCurrentTypeArgs) && this._pCurrentSym is MethodSymbol pCurrentSym)
          this._results.UninferableResult.Set((MethodOrPropertySymbol) pCurrentSym, this._pCurrentType, this._pCurrentTypeArgs);
        return false;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private void UpdateArguments()
      {
        this._pCurrentParameters = TypeManager.SubstTypeArray(this._pCurrentParameters, this._pCurrentType, this._pCurrentTypeArgs);
        if (this._pArguments.prgexpr == null || this._pArguments.prgexpr.Count == 0)
          return;
        MethodOrPropertySymbol methprop = (MethodOrPropertySymbol) null;
        for (int index = 0; index < this._pCurrentParameters.Count; ++index)
        {
          Expr expr = this._pArguments.prgexpr[index];
          if (expr.IsOptionalArgument && this._pCurrentParameters[index] != expr.Type)
          {
            if (methprop == null)
              methprop = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this._pCurrentSym, this._pGroup.OptionalObject);
            Expr optionalArgument = ExpressionBinder.GroupToArgsBinder.GenerateOptionalArgument(methprop, this._pCurrentParameters[index], index);
            this._pArguments.prgexpr[index] = optionalArgument;
          }
        }
      }

      private static bool DoesTypeArgumentsContainErrorSym(CType var)
      {
        if (!(var is AggregateType aggregateType))
          return false;
        TypeArray typeArgsAll = aggregateType.TypeArgsAll;
        for (int i = 0; i < typeArgsAll.Count; ++i)
        {
          CType var1 = typeArgsAll[i];
          if (var1 == null || var1 is AggregateType && ExpressionBinder.GroupToArgsBinder.DoesTypeArgumentsContainErrorSym(var1))
            return true;
        }
        return false;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private void ReportErrorsOnSuccess()
      {
        if (this._pGroup.SymKind != SYMKIND.SK_MethodSymbol || this._results.BestResult.TypeArgs.Count <= 0)
          return;
        TypeBind.CheckMethConstraints(new MethWithInst(this._results.BestResult));
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private RuntimeBinderException ReportErrorsOnFailure()
      {
        if (this._pDuplicateSpecifiedName != null)
          return ErrorHandling.Error(ErrorCode.ERR_DuplicateNamedArgument, (ErrArg) this._pDuplicateSpecifiedName);
        if ((bool) (SymWithType) this._results.InaccessibleResult)
          return CSemanticChecker.ReportAccessError((SymWithType) this._results.InaccessibleResult, (Symbol) this._pExprBinder.ContextForMemberLookup, ExpressionBinder.GroupToArgsBinder.GetTypeQualifier(this._pGroup));
        if ((bool) (SymWithType) this._misnamed)
        {
          List<Name> parameterNames = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(this._misnamed.MethProp(), this._pGroup.OptionalObject).ParameterNames;
          for (int index = 0; index != this._pOriginalArguments.carg; ++index)
          {
            if (this._pOriginalArguments.prgexpr[index] is ExprNamedArgumentSpecification argumentSpecification)
            {
              Name name = argumentSpecification.Name;
              if (parameterNames[index] != name)
              {
                if (parameterNames.Contains(name))
                  return ErrorHandling.Error(ErrorCode.ERR_BadNonTrailingNamedArgument, (ErrArg) name);
                this._pInvalidSpecifiedName = name;
                break;
              }
            }
          }
        }
        else if ((bool) (SymWithType) this._mpwiBogus)
          return ErrorHandling.Error(ErrorCode.ERR_BindToBogus, (ErrArg) this._mpwiBogus);
        bool bUseDelegateErrors = false;
        Name name1 = this._pGroup.Name;
        if (this._pGroup.OptionalObject?.Type != null && this._pGroup.OptionalObject.Type.IsDelegateType && this._pGroup.Name == NameManager.GetPredefinedName(PredefinedName.PN_INVOKE))
        {
          bUseDelegateErrors = true;
          name1 = ((AggregateType) this._pGroup.OptionalObject.Type).OwningAggregate.name;
        }
        if ((bool) (SymWithType) this._results.BestResult)
          return this.ReportErrorsForBestMatching(bUseDelegateErrors);
        if ((bool) (SymWithType) this._results.UninferableResult || (bool) (SymWithType) this._mpwiCantInferInstArg)
        {
          if (!(bool) (SymWithType) this._results.UninferableResult)
            this._results.UninferableResult.Set((MethodOrPropertySymbol) (this._mpwiCantInferInstArg.Sym as MethodSymbol), this._mpwiCantInferInstArg.GetType(), this._mpwiCantInferInstArg.TypeArgs);
          return ErrorHandling.Error(ErrorCode.ERR_CantInferMethTypeArgs, (ErrArg) (SymWithType) new MethWithType(this._results.UninferableResult.Meth(), this._results.UninferableResult.GetType()));
        }
        if ((bool) (SymWithType) this._mwtBadArity)
          return ErrorHandling.Error((ErrorCode) (this._mwtBadArity.Meth().typeVars.Count > 0 ? 305 : 308), (ErrArg) (SymWithType) this._mwtBadArity, (ErrArg) new ErrArgSymKind((Symbol) this._mwtBadArity.Meth()), (ErrArg) this._pArguments.carg);
        if ((bool) (SymWithType) this._mpwiParamTypeConstraints)
        {
          TypeBind.CheckMethConstraints(new MethWithInst(this._mpwiParamTypeConstraints));
          return (RuntimeBinderException) null;
        }
        return this._pInvalidSpecifiedName != null ? (!(this._pGroup.OptionalObject?.Type is AggregateType type) || !type.OwningAggregate.IsDelegate() ? ErrorHandling.Error(ErrorCode.ERR_BadNamedArgument, (ErrArg) this._pGroup.Name, (ErrArg) this._pInvalidSpecifiedName) : ErrorHandling.Error(ErrorCode.ERR_BadNamedArgumentForDelegateInvoke, (ErrArg) type.OwningAggregate.name, (ErrArg) this._pInvalidSpecifiedName)) : (this._pNameUsedInPositionalArgument != null ? ErrorHandling.Error(ErrorCode.ERR_NamedArgumentUsedInPositional, (ErrArg) this._pNameUsedInPositionalArgument) : (this._fCandidatesUnsupported ? ErrorHandling.Error(ErrorCode.ERR_BindToBogus, (ErrArg) name1) : (bUseDelegateErrors ? ErrorHandling.Error(ErrorCode.ERR_BadDelArgCount, (ErrArg) name1, (ErrArg) this._pArguments.carg) : ((this._pGroup.Flags & EXPRFLAG.EXF_CTOR) != (EXPRFLAG) 0 ? ErrorHandling.Error(ErrorCode.ERR_BadCtorArgCount, (ErrArg) this._pGroup.ParentType, (ErrArg) this._pArguments.carg) : ErrorHandling.Error(ErrorCode.ERR_BadArgCount, (ErrArg) name1, (ErrArg) this._pArguments.carg)))));
      }

      private RuntimeBinderException ReportErrorsForBestMatching(bool bUseDelegateErrors)
      {
        return bUseDelegateErrors ? ErrorHandling.Error(ErrorCode.ERR_BadDelArgTypes, (ErrArg) (CType) this._results.BestResult.GetType()) : ErrorHandling.Error(ErrorCode.ERR_BadArgTypes, (ErrArg) this._results.BestResult);
      }

      private enum Result
      {
        Success,
        Failure_SearchForExpanded,
        Failure_NoSearchForExpanded,
      }
    }

    internal sealed class GroupToArgsBinderResult
    {
      public MethPropWithInst BestResult { get; set; }

      public MethPropWithInst InaccessibleResult { get; }

      public MethPropWithInst UninferableResult { get; }

      public GroupToArgsBinderResult()
      {
        this.BestResult = new MethPropWithInst();
        this.InaccessibleResult = new MethPropWithInst();
        this.UninferableResult = new MethPropWithInst();
      }

      private static int NumberOfErrorTypes(TypeArray pTypeArgs)
      {
        int num = 0;
        for (int i = 0; i < pTypeArgs.Count; ++i)
        {
          if (pTypeArgs[i] == null)
            ++num;
        }
        return num;
      }

      private static bool IsBetterThanCurrent(TypeArray pTypeArgs1, TypeArray pTypeArgs2)
      {
        int num1 = ExpressionBinder.GroupToArgsBinderResult.NumberOfErrorTypes(pTypeArgs1);
        int num2 = ExpressionBinder.GroupToArgsBinderResult.NumberOfErrorTypes(pTypeArgs2);
        if (num1 == num2)
        {
          int num3 = pTypeArgs1.Count > pTypeArgs2.Count ? pTypeArgs2.Count : pTypeArgs1.Count;
          for (int i = 0; i < num3; ++i)
          {
            if (pTypeArgs1[i] is AggregateType aggregateType1)
              num1 += ExpressionBinder.GroupToArgsBinderResult.NumberOfErrorTypes(aggregateType1.TypeArgsAll);
            if (pTypeArgs2[i] is AggregateType aggregateType2)
              num2 += ExpressionBinder.GroupToArgsBinderResult.NumberOfErrorTypes(aggregateType2.TypeArgsAll);
          }
        }
        return num2 < num1;
      }

      public bool IsBetterUninferableResult(TypeArray pTypeArguments)
      {
        if (this.UninferableResult.Sym == null)
          return true;
        return pTypeArguments != null && ExpressionBinder.GroupToArgsBinderResult.IsBetterThanCurrent(this.UninferableResult.TypeArgs, pTypeArguments);
      }
    }

    private sealed class ImplicitConversion
    {
      private Expr _exprDest;
      private readonly ExpressionBinder _binder;
      private readonly Expr _exprSrc;
      private readonly CType _typeSrc;
      private readonly CType _typeDest;
      private readonly bool _needsExprDest;
      private CONVERTTYPE _flags;

      public ImplicitConversion(
        ExpressionBinder binder,
        Expr exprSrc,
        CType typeSrc,
        CType typeDest,
        bool needsExprDest,
        CONVERTTYPE flags)
      {
        this._binder = binder;
        this._exprSrc = exprSrc;
        this._typeSrc = typeSrc;
        this._typeDest = typeDest;
        this._needsExprDest = needsExprDest;
        this._flags = flags;
        this._exprDest = (Expr) null;
      }

      public Expr ExprDest => this._exprDest;

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      public bool Bind()
      {
        if (this._typeSrc == null || this._typeDest == null || this._typeDest is MethodGroupType)
          return false;
        switch (this._typeDest.TypeKind)
        {
          case TypeKind.TK_VoidType:
            return false;
          case TypeKind.TK_NullType:
            if (!(this._typeSrc is NullType))
              return false;
            if (this._needsExprDest)
              this._exprDest = this._exprSrc;
            return true;
          case TypeKind.TK_ArgumentListType:
            return this._typeSrc == this._typeDest;
          default:
            if (this._typeSrc == this._typeDest && ((this._flags & CONVERTTYPE.ISEXPLICIT) == (CONVERTTYPE) 0 || !this._typeSrc.IsPredefType(PredefinedType.PT_FLOAT) && !this._typeSrc.IsPredefType(PredefinedType.PT_DOUBLE)))
            {
              if (this._needsExprDest)
                this._exprDest = this._exprSrc;
              return true;
            }
            if (this._typeDest is NullableType typeDest)
              return this.BindNubConversion(typeDest);
            if (this._typeSrc is NullableType typeSrc)
              return this.bindImplicitConversionFromNullable(typeSrc);
            if ((this._flags & CONVERTTYPE.ISEXPLICIT) != (CONVERTTYPE) 0)
              this._flags |= CONVERTTYPE.NOUDC;
            FUNDTYPE fundamentalType = this._typeDest.FundamentalType;
            switch (this._typeSrc.TypeKind)
            {
              case TypeKind.TK_AggregateType:
                if (this.bindImplicitConversionFromAgg(this._typeSrc as AggregateType))
                  return true;
                break;
              case TypeKind.TK_VoidType:
              case TypeKind.TK_ArgumentListType:
              case TypeKind.TK_ParameterModifierType:
                return false;
              case TypeKind.TK_NullType:
                if (this.bindImplicitConversionFromNull())
                  return true;
                break;
              case TypeKind.TK_ArrayType:
                if (this.bindImplicitConversionFromArray())
                  return true;
                break;
              case TypeKind.TK_PointerType:
                if (this.bindImplicitConversionFromPointer())
                  return true;
                break;
            }
            object runtimeObject = this._exprSrc?.RuntimeObject;
            if (runtimeObject != null && this._typeDest.AssociatedSystemType.IsInstanceOfType(runtimeObject) && CSemanticChecker.CheckTypeAccess(this._typeDest, (Symbol) this._binder.Context.ContextForMemberLookup))
            {
              if (this._needsExprDest)
                this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, this._exprSrc.Flags & EXPRFLAG.EXF_CANTBENULL);
              return true;
            }
            return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, this._typeDest, this._needsExprDest, out this._exprDest, true);
        }
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool BindNubConversion(NullableType nubDst)
      {
        nubDst.GetAts();
        if (SymbolLoader.HasBaseConversion(nubDst.UnderlyingType, this._typeSrc) && !CConversions.FWrappingConv(this._typeSrc, (CType) nubDst))
        {
          if ((this._flags & CONVERTTYPE.ISEXPLICIT) == (CONVERTTYPE) 0)
            return false;
          if (this._needsExprDest)
            this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_INDEXER);
          return true;
        }
        bool wasNullable1;
        CType ctype1 = nubDst.StripNubs(out wasNullable1);
        bool wasNullable2;
        CType ctype2 = this._typeSrc.StripNubs(out wasNullable2);
        ExpressionBinder.ConversionFunc conversionFunc = (this._flags & CONVERTTYPE.ISEXPLICIT) != (CONVERTTYPE) 0 ? new ExpressionBinder.ConversionFunc(this._binder.BindExplicitConversion) : new ExpressionBinder.ConversionFunc(this._binder.BindImplicitConversion);
        if (!wasNullable2)
        {
          if (this._typeSrc is NullType)
          {
            if (this._needsExprDest)
              this._exprDest = this._exprSrc is ExprConstant ? ExprFactory.CreateZeroInit((CType) nubDst) : (Expr) ExprFactory.CreateCast(this._typeDest, this._exprSrc);
            return true;
          }
          Expr ppDestinationExpr = this._exprSrc;
          if (this._typeSrc == ctype1 || conversionFunc(this._exprSrc, this._typeSrc, ctype1, this._needsExprDest, out ppDestinationExpr, this._flags | CONVERTTYPE.NOUDC))
          {
            if (this._needsExprDest)
            {
              if (ppDestinationExpr is ExprUserDefinedConversion definedConversion)
                ppDestinationExpr = definedConversion.UserDefinedCall;
              if (wasNullable1)
              {
                ExprCall exprCall = ExpressionBinder.BindNubNew(ppDestinationExpr);
                ppDestinationExpr = (Expr) exprCall;
                exprCall.NullableCallLiftKind = NullableCallLiftKind.NullableConversionConstructor;
              }
              if (definedConversion != null)
              {
                definedConversion.UserDefinedCall = ppDestinationExpr;
                ppDestinationExpr = (Expr) definedConversion;
              }
              this._exprDest = ppDestinationExpr;
            }
            return true;
          }
          return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, (CType) nubDst, this._needsExprDest, out this._exprDest, (this._flags & CONVERTTYPE.ISEXPLICIT) == (CONVERTTYPE) 0);
        }
        if (ctype2 != ctype1 && !conversionFunc((Expr) null, ctype2, ctype1, false, out this._exprDest, this._flags | CONVERTTYPE.NOUDC))
          return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, this._typeSrc, (CType) nubDst, this._needsExprDest, out this._exprDest, (this._flags & CONVERTTYPE.ISEXPLICIT) == (CONVERTTYPE) 0);
        if (this._needsExprDest)
        {
          ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) new MethWithInst((MethodSymbol) null, (AggregateType) null));
          ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, (CType) nubDst, this._exprSrc, memGroup, (MethWithInst) null);
          Expr ppDestinationExpr = this._binder.mustCast(this._exprSrc, ctype2);
          if (!((this._flags & CONVERTTYPE.ISEXPLICIT) != (CONVERTTYPE) 0 ? this._binder.BindExplicitConversion(ppDestinationExpr, ppDestinationExpr.Type, ctype1, out ppDestinationExpr, this._flags | CONVERTTYPE.NOUDC) : this._binder.BindImplicitConversion(ppDestinationExpr, ppDestinationExpr.Type, ctype1, out ppDestinationExpr, this._flags | CONVERTTYPE.NOUDC)))
            return false;
          call.CastOfNonLiftedResultToLiftedType = this._binder.mustCast(ppDestinationExpr, (CType) nubDst, (CONVERTTYPE) 0);
          call.NullableCallLiftKind = NullableCallLiftKind.NullableConversion;
          call.PConversions = call.CastOfNonLiftedResultToLiftedType;
          this._exprDest = (Expr) call;
        }
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromNull()
      {
        switch (this._typeDest.FundamentalType)
        {
          case FUNDTYPE.FT_REF:
          case FUNDTYPE.FT_PTR:
            if (this._needsExprDest)
              this._exprDest = this._exprSrc is ExprConstant ? ExprFactory.CreateZeroInit(this._typeDest) : (Expr) ExprFactory.CreateCast(this._typeDest, this._exprSrc);
            return true;
          default:
            if (!this._typeDest.IsPredefType(PredefinedType.PT_G_OPTIONAL))
              return false;
            goto case FUNDTYPE.FT_REF;
        }
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromNullable(NullableType nubSrc)
      {
        if (nubSrc.GetAts() == this._typeDest)
        {
          if (this._needsExprDest)
            this._exprDest = this._exprSrc;
          return true;
        }
        if (SymbolLoader.HasBaseConversion(nubSrc.UnderlyingType, this._typeDest) && !CConversions.FUnwrappingConv((CType) nubSrc, this._typeDest))
        {
          if (this._needsExprDest)
          {
            this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_CTOR);
            if (!this._typeDest.IsPredefType(PredefinedType.PT_OBJECT))
              this._binder.bindSimpleCast(this._exprDest, this._typeDest, out this._exprDest, EXPRFLAG.EXF_ASFINALLYLEAVE);
          }
          return true;
        }
        return (this._flags & CONVERTTYPE.NOUDC) == (CONVERTTYPE) 0 && this._binder.bindUserDefinedConversion(this._exprSrc, (CType) nubSrc, this._typeDest, this._needsExprDest, out this._exprDest, true);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromArray()
      {
        if (!SymbolLoader.HasBaseConversion(this._typeSrc, this._typeDest))
          return false;
        EXPRFLAG exprFlags = (EXPRFLAG) 0;
        if ((this._typeDest is ArrayType || this._typeDest is AggregateType typeDest && typeDest.IsInterfaceType && typeDest.TypeArgsAll.Count == 1 && (typeDest.TypeArgsAll[0] != ((ArrayType) this._typeSrc).ElementType || (this._flags & CONVERTTYPE.FORCECAST) != (CONVERTTYPE) 0)) && ((this._flags & CONVERTTYPE.FORCECAST) != (CONVERTTYPE) 0 || TypeManager.TypeContainsTyVars(this._typeSrc, (TypeArray) null) || TypeManager.TypeContainsTyVars(this._typeDest, (TypeArray) null)))
          exprFlags = EXPRFLAG.EXF_OPERATOR;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, exprFlags);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromPointer()
      {
        if (!(this._typeDest is PointerType typeDest) || typeDest.ReferentType != VoidType.Instance)
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromAgg(AggregateType aggTypeSrc)
      {
        AggregateSymbol owningAggregate = aggTypeSrc.OwningAggregate;
        if (owningAggregate.IsEnum())
          return this.bindImplicitConversionFromEnum(aggTypeSrc);
        if (this._typeDest.IsEnumType)
        {
          if (this.bindImplicitConversionToEnum(aggTypeSrc))
            return true;
        }
        else if (owningAggregate.getThisType().IsSimpleType && this._typeDest.IsSimpleType && this.bindImplicitConversionBetweenSimpleTypes(aggTypeSrc))
          return true;
        return this.bindImplicitConversionToBase(aggTypeSrc);
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionToBase(AggregateType pSource)
      {
        if (!(this._typeDest is AggregateType) || !SymbolLoader.HasBaseConversion((CType) pSource, this._typeDest))
          return false;
        EXPRFLAG exprFlags = (EXPRFLAG) 0;
        if (pSource.OwningAggregate.IsStruct() && this._typeDest.FundamentalType == FUNDTYPE.FT_REF)
          exprFlags = EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_CANTBENULL;
        else if (this._exprSrc != null)
          exprFlags = this._exprSrc.Flags & EXPRFLAG.EXF_CANTBENULL;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, exprFlags);
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionFromEnum(AggregateType aggTypeSrc)
      {
        if (!(this._typeDest is AggregateType typeDest) || !SymbolLoader.HasBaseConversion((CType) aggTypeSrc, (CType) typeDest))
          return false;
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest, EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_CANTBENULL);
        return true;
      }

      private bool bindImplicitConversionToEnum(AggregateType aggTypeSrc)
      {
        if (aggTypeSrc.OwningAggregate.GetPredefType() == PredefinedType.PT_BOOL || this._exprSrc == null || !this._exprSrc.IsZero() || !this._exprSrc.Type.IsNumericType || (this._flags & CONVERTTYPE.STANDARD) != (CONVERTTYPE) 0)
          return false;
        if (this._needsExprDest)
          this._exprDest = (Expr) ExprFactory.CreateConstant(this._typeDest, ConstVal.GetDefaultValue(this._typeDest.ConstValKind));
        return true;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      private bool bindImplicitConversionBetweenSimpleTypes(AggregateType aggTypeSrc)
      {
        PredefinedType predefType = aggTypeSrc.OwningAggregate.GetPredefType();
        PredefinedType predefinedType = this._typeDest.PredefinedType;
        if ((!(this._exprSrc is ExprConstant exprSrc) || (predefType != PredefinedType.PT_INT || predefinedType == PredefinedType.PT_BOOL || predefinedType == PredefinedType.PT_CHAR) && (predefType != PredefinedType.PT_LONG || predefinedType != PredefinedType.PT_ULONG) || !ExpressionBinder.isConstantInRange(exprSrc, this._typeDest) ? (predefType != predefinedType ? ExpressionBinder.GetConvKind(predefType, predefinedType) : ConvKind.Implicit) : ConvKind.Implicit) != ConvKind.Implicit)
          return false;
        if (this._exprSrc.GetConst() != null && this._binder.bindConstantCast(this._exprSrc, this._typeDest, this._needsExprDest, out this._exprDest, false) == ConstCastResult.Success)
          return true;
        if (ExpressionBinder.isUserDefinedConversion(predefType, predefinedType))
          return !this._needsExprDest || this._binder.bindUserDefinedConversion(this._exprSrc, (CType) aggTypeSrc, this._typeDest, this._needsExprDest, out this._exprDest, true);
        if (this._needsExprDest)
          this._binder.bindSimpleCast(this._exprSrc, this._typeDest, out this._exprDest);
        return true;
      }
    }

    private class UnaOpSig
    {
      public PredefinedType pt;
      public UnaOpMask grfuom;
      public int cuosSkip;
      public ExpressionBinder.PfnBindUnaOp pfn;
      public UnaOpFuncKind fnkind;

      protected UnaOpSig()
      {
      }

      public UnaOpSig(
        PredefinedType pt,
        UnaOpMask grfuom,
        int cuosSkip,
        ExpressionBinder.PfnBindUnaOp pfn,
        UnaOpFuncKind fnkind)
      {
        this.pt = pt;
        this.grfuom = grfuom;
        this.cuosSkip = cuosSkip;
        this.pfn = pfn;
        this.fnkind = fnkind;
      }
    }

    private sealed class UnaOpFullSig : ExpressionBinder.UnaOpSig
    {
      private readonly LiftFlags _grflt;
      private readonly CType _type;

      public UnaOpFullSig(
        CType type,
        ExpressionBinder.PfnBindUnaOp pfn,
        LiftFlags grflt,
        UnaOpFuncKind fnkind)
      {
        this.pt = PredefinedType.PT_UNDEFINEDINDEX;
        this.grfuom = UnaOpMask.None;
        this.cuosSkip = 0;
        this.pfn = pfn;
        this._type = type;
        this._grflt = grflt;
        this.fnkind = fnkind;
      }

      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
      public UnaOpFullSig(ExpressionBinder fnc, ExpressionBinder.UnaOpSig uos)
      {
        this.pt = uos.pt;
        this.grfuom = uos.grfuom;
        this.cuosSkip = uos.cuosSkip;
        this.pfn = uos.pfn;
        this.fnkind = uos.fnkind;
        this._type = this.pt != PredefinedType.PT_UNDEFINEDINDEX ? (CType) ExpressionBinder.GetPredefindType(this.pt) : (CType) null;
        this._grflt = LiftFlags.None;
      }

      public bool FPreDef() => this.pt != PredefinedType.PT_UNDEFINEDINDEX;

      public bool isLifted() => this._grflt != LiftFlags.None;

      public bool Convert() => (this._grflt & LiftFlags.Convert1) != 0;

      public CType GetType() => this._type;
    }
  }
}
