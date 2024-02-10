﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PredefinedMembers
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class PredefinedMembers
  {
    private static readonly MethodSymbol[] _methods = new MethodSymbol[81];
    private static readonly PropertySymbol[] _properties = new PropertySymbol[1];
    private static readonly PredefinedPropertyInfo[] s_predefinedProperties = new PredefinedPropertyInfo[1]
    {
      new PredefinedPropertyInfo(PREDEFPROP.PP_G_OPTIONAL_VALUE, PredefinedName.PN_CAP_VALUE, PREDEFMETH.PM_G_OPTIONAL_GETVALUE)
    };
    private static readonly PredefinedMethodInfo[] s_predefinedMethods = new PredefinedMethodInfo[81]
    {
      new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPDECREMENT, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPDECREMENT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        6,
        1,
        6
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPINCREMENT, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPINCREMENT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        6,
        1,
        6
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPUNARYMINUS, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPUNARYMINUS, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        6,
        1,
        6
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_COMBINE, PredefinedType.PT_DELEGATE, PredefinedName.PN_COMBINE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        17,
        2,
        17,
        17
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_OPEQUALITY, PredefinedType.PT_DELEGATE, PredefinedName.PN_OPEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        8,
        2,
        17,
        17
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_OPINEQUALITY, PredefinedType.PT_DELEGATE, PredefinedName.PN_OPINEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        8,
        2,
        17,
        17
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_REMOVE, PredefinedType.PT_DELEGATE, PredefinedName.PN_REMOVE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        17,
        2,
        17,
        17
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADD, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADDCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADDCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADDCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_AND, PredefinedType.PT_EXPRESSION, PredefinedName.PN_AND, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_AND, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ANDALSO, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ANDALSO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ANDALSO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ARRAYINDEX, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ARRAYINDEX, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        37,
        2,
        31,
        53,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ASSIGN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ASSIGN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONSTANT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        34,
        2,
        15,
        20
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        20
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        33,
        3,
        31,
        20,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        20
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        33,
        3,
        31,
        20,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_DIVIDE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_DIVIDE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_DIVIDE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXCLUSIVEOR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXCLUSIVEOR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_FIELD, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CAP_FIELD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        36,
        2,
        31,
        41
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHAN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LAMBDA, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LAMBDA, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 1, new int[7]
      {
        30,
        52,
        0,
        2,
        31,
        53,
        35
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LEFTSHIFT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LEFTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LEFTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHAN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MODULO, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MODULO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MODULO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLY, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLYCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLYCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOTEQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOTEQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOTEQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        32,
        4,
        31,
        31,
        8,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_OR, PredefinedType.PT_EXPRESSION, PredefinedName.PN_OR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_OR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ORELSE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ORELSE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ORELSE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_PARAMETER, PredefinedType.PT_EXPRESSION, PredefinedName.PN_PARAMETER, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        35,
        2,
        20,
        16
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_RIGHTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_RIGHTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        32,
        2,
        31,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        32,
        3,
        31,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_PLUS, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        33,
        1,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATECHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATECHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        33,
        1,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATECHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CALL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CALL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6]
      {
        37,
        3,
        31,
        42,
        53,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEW, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEW, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        38,
        2,
        43,
        53,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEW_TYPE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEW, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        38,
        1,
        20
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_QUOTE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_QUOTE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        33,
        1,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        33,
        1,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        33,
        2,
        31,
        42
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEWARRAYINIT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        39,
        2,
        20,
        53,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_PROPERTY, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXPRESSION_PROPERTY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        36,
        2,
        31,
        44
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_INVOKE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_INVOKE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        40,
        2,
        31,
        53,
        31
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_G_OPTIONAL_CTOR, PredefinedType.PT_G_OPTIONAL, PredefinedName.PN_CTOR, MethodCallingConventionEnum.Instance, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        50,
        1,
        51,
        0
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_G_OPTIONAL_GETVALUE, PredefinedType.PT_G_OPTIONAL, PredefinedName.PN_GETVALUE, MethodCallingConventionEnum.Instance, ACCESS.ACC_PUBLIC, 0, new int[3]
      {
        51,
        0,
        0
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_OBJECT_2, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        16,
        2,
        15,
        15
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_OBJECT_3, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5]
      {
        16,
        3,
        15,
        15,
        15
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_STRING_2, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        16,
        2,
        16,
        16
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_STRING_OPEQUALITY, PredefinedType.PT_STRING, PredefinedName.PN_OPEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        8,
        2,
        16,
        16
      }),
      new PredefinedMethodInfo(PREDEFMETH.PM_STRING_OPINEQUALITY, PredefinedType.PT_STRING, PredefinedName.PN_OPINEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4]
      {
        8,
        2,
        16,
        16
      })
    };

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static PropertySymbol LoadProperty(PREDEFPROP property)
    {
      PredefinedPropertyInfo propInfo = PredefinedMembers.GetPropInfo(property);
      return PredefinedMembers.LoadProperty(property, NameManager.GetPredefinedName(propInfo.name), propInfo.getter);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static PropertySymbol LoadProperty(
      PREDEFPROP predefProp,
      Name propertyName,
      PREDEFMETH propertyGetter)
    {
      SymbolTable.AddPredefinedPropertyToSymbolTable(PredefinedMembers.GetPredefAgg(PredefinedMembers.GetPropPredefType(predefProp)), propertyName);
      MethodSymbol method = PredefinedMembers.GetMethod(propertyGetter);
      method.SetMethKind(MethodKindEnum.PropAccessor);
      return method.getProperty();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static AggregateSymbol GetPredefAgg(PredefinedType pt) => SymbolLoader.GetPredefAgg(pt);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static CType LoadTypeFromSignature(
      int[] signature,
      ref int indexIntoSignatures,
      TypeArray classTyVars)
    {
      MethodSignatureEnum pt = (MethodSignatureEnum) signature[indexIntoSignatures];
      ++indexIntoSignatures;
      switch (pt)
      {
        case (MethodSignatureEnum) 50:
          return (CType) VoidType.Instance;
        case MethodSignatureEnum.SIG_CLASS_TYVAR:
          return classTyVars[signature[indexIntoSignatures++]];
        case MethodSignatureEnum.SIG_METH_TYVAR:
          return (CType) TypeManager.GetStdMethTypeVar(signature[indexIntoSignatures++]);
        case MethodSignatureEnum.SIG_SZ_ARRAY:
          return (CType) TypeManager.GetArray(PredefinedMembers.LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars), 1, true);
        default:
          AggregateSymbol predefAgg = PredefinedMembers.GetPredefAgg((PredefinedType) pt);
          int count = predefAgg.GetTypeVars().Count;
          if (count == 0)
            return (CType) TypeManager.GetAggregate(predefAgg, TypeArray.Empty);
          CType[] ctypeArray = new CType[count];
          for (int index = 0; index < ctypeArray.Length; ++index)
            ctypeArray[index] = PredefinedMembers.LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars);
          return (CType) TypeManager.GetAggregate(predefAgg, TypeArray.Allocate(ctypeArray));
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeArray LoadTypeArrayFromSignature(
      int[] signature,
      ref int indexIntoSignatures,
      TypeArray classTyVars)
    {
      int length = signature[indexIntoSignatures];
      ++indexIntoSignatures;
      CType[] ctypeArray = new CType[length];
      for (int index = 0; index < ctypeArray.Length; ++index)
        ctypeArray[index] = PredefinedMembers.LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars);
      return TypeArray.Allocate(ctypeArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static PropertySymbol GetProperty(PREDEFPROP property)
    {
      return PredefinedMembers._properties[(int) property] ?? (PredefinedMembers._properties[(int) property] = PredefinedMembers.LoadProperty(property));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static MethodSymbol GetMethod(PREDEFMETH method)
    {
      return PredefinedMembers._methods[(int) method] ?? (PredefinedMembers._methods[(int) method] = PredefinedMembers.LoadMethod(method));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static MethodSymbol LoadMethod(
      AggregateSymbol type,
      int[] signature,
      int cMethodTyVars,
      Name methodName,
      ACCESS methodAccess,
      bool isStatic,
      bool isVirtual)
    {
      TypeArray typeVarsAll = type.GetTypeVarsAll();
      int indexIntoSignatures = 0;
      CType returnType = PredefinedMembers.LoadTypeFromSignature(signature, ref indexIntoSignatures, typeVarsAll);
      TypeArray argumentTypes = PredefinedMembers.LoadTypeArrayFromSignature(signature, ref indexIntoSignatures, typeVarsAll);
      MethodSymbol methodSymbol = PredefinedMembers.LookupMethodWhileLoading(type, cMethodTyVars, methodName, methodAccess, isStatic, isVirtual, returnType, argumentTypes);
      if (methodSymbol == null)
      {
        SymbolTable.AddPredefinedMethodToSymbolTable(type, methodName);
        methodSymbol = PredefinedMembers.LookupMethodWhileLoading(type, cMethodTyVars, methodName, methodAccess, isStatic, isVirtual, returnType, argumentTypes);
      }
      return methodSymbol;
    }

    private static MethodSymbol LookupMethodWhileLoading(
      AggregateSymbol type,
      int cMethodTyVars,
      Name methodName,
      ACCESS methodAccess,
      bool isStatic,
      bool isVirtual,
      CType returnType,
      TypeArray argumentTypes)
    {
      for (Symbol symbol = SymbolLoader.LookupAggMember(methodName, type, symbmask_t.MASK_ALL); symbol != null; symbol = symbol.LookupNext(symbmask_t.MASK_ALL))
      {
        if (symbol is MethodSymbol methodSymbol && (methodSymbol.GetAccess() == methodAccess || methodAccess == ACCESS.ACC_UNKNOWN) && methodSymbol.isStatic == isStatic && methodSymbol.isVirtual == isVirtual && methodSymbol.typeVars.Count == cMethodTyVars && TypeManager.SubstEqualTypes(methodSymbol.RetType, returnType, (TypeArray) null, methodSymbol.typeVars, true) && TypeManager.SubstEqualTypeArrays(methodSymbol.Params, argumentTypes, (TypeArray) null, methodSymbol.typeVars))
          return methodSymbol;
      }
      return (MethodSymbol) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static MethodSymbol LoadMethod(PREDEFMETH method)
    {
      PredefinedMethodInfo methInfo = PredefinedMembers.GetMethInfo(method);
      return PredefinedMembers.LoadMethod(PredefinedMembers.GetPredefAgg(methInfo.type), methInfo.signature, methInfo.cTypeVars, NameManager.GetPredefinedName(methInfo.name), methInfo.access, methInfo.callingConvention == MethodCallingConventionEnum.Static, methInfo.callingConvention == MethodCallingConventionEnum.Virtual);
    }

    private static PREDEFMETH GetPropGetter(PREDEFPROP property)
    {
      return PredefinedMembers.GetPropInfo(property).getter;
    }

    private static PredefinedType GetPropPredefType(PREDEFPROP property)
    {
      return PredefinedMembers.GetMethInfo(PredefinedMembers.GetPropGetter(property)).type;
    }

    private static PredefinedPropertyInfo GetPropInfo(PREDEFPROP property)
    {
      return PredefinedMembers.s_predefinedProperties[(int) property];
    }

    private static PredefinedMethodInfo GetMethInfo(PREDEFMETH method)
    {
      return PredefinedMembers.s_predefinedMethods[(int) method];
    }
  }
}
