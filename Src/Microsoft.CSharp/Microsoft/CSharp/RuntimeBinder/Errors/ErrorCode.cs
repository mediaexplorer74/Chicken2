// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Errors.ErrorCode
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
  internal enum ErrorCode
  {
    ERR_BadBinaryOps = 19, // 0x00000013
    ERR_BadIndexLHS = 21, // 0x00000015
    ERR_BadIndexCount = 22, // 0x00000016
    ERR_BadUnaryOp = 23, // 0x00000017
    ERR_NoImplicitConv = 29, // 0x0000001D
    ERR_NoExplicitConv = 30, // 0x0000001E
    ERR_ConstOutOfRange = 31, // 0x0000001F
    ERR_AmbigBinaryOps = 34, // 0x00000022
    ERR_AmbigUnaryOp = 35, // 0x00000023
    ERR_ValueCantBeNull = 37, // 0x00000025
    ERR_NoSuchMember = 117, // 0x00000075
    ERR_ObjectRequired = 120, // 0x00000078
    ERR_AmbigCall = 121, // 0x00000079
    ERR_BadAccess = 122, // 0x0000007A
    ERR_AssgLvalueExpected = 131, // 0x00000083
    ERR_NoConstructors = 143, // 0x0000008F
    ERR_PropertyLacksGet = 154, // 0x0000009A
    ERR_ObjectProhibited = 176, // 0x000000B0
    ERR_AssgReadonly = 191, // 0x000000BF
    ERR_AssgReadonlyStatic = 198, // 0x000000C6
    ERR_AssgReadonlyProp = 200, // 0x000000C8
    ERR_UnsafeNeeded = 214, // 0x000000D6
    ERR_BadBoolOp = 217, // 0x000000D9
    ERR_MustHaveOpTF = 218, // 0x000000DA
    ERR_ConstOutOfRangeChecked = 221, // 0x000000DD
    ERR_AmbigMember = 229, // 0x000000E5
    ERR_NoImplicitConvCast = 266, // 0x0000010A
    ERR_InaccessibleGetter = 271, // 0x0000010F
    ERR_InaccessibleSetter = 272, // 0x00000110
    ERR_BadArity = 305, // 0x00000131
    ERR_TypeArgsNotAllowed = 307, // 0x00000133
    ERR_HasNoTypeVars = 308, // 0x00000134
    ERR_NewConstraintNotSatisfied = 310, // 0x00000136
    ERR_GenericConstraintNotSatisfiedRefType = 311, // 0x00000137
    ERR_GenericConstraintNotSatisfiedNullableEnum = 312, // 0x00000138
    ERR_GenericConstraintNotSatisfiedNullableInterface = 313, // 0x00000139
    ERR_GenericConstraintNotSatisfiedValType = 315, // 0x0000013B
    ERR_CantInferMethTypeArgs = 411, // 0x0000019B
    ERR_RefConstraintNotSatisfied = 452, // 0x000001C4
    ERR_ValConstraintNotSatisfied = 453, // 0x000001C5
    ERR_AmbigUDConv = 457, // 0x000001C9
    ERR_BindToBogus = 570, // 0x0000023A
    ERR_CantCallSpecialMethod = 571, // 0x0000023B
    ERR_ConvertToStaticClass = 716, // 0x000002CC
    ERR_IncrementLvalueExpected = 1059, // 0x00000423
    ERR_BadArgCount = 1501, // 0x000005DD
    ERR_BadArgTypes = 1502, // 0x000005DE
    ERR_BadProtectedAccess = 1540, // 0x00000604
    ERR_BindToBogusProp2 = 1545, // 0x00000609
    ERR_BindToBogusProp1 = 1546, // 0x0000060A
    ERR_BadDelArgCount = 1593, // 0x00000639
    ERR_BadDelArgTypes = 1594, // 0x0000063A
    ERR_BadCtorArgCount = 1729, // 0x000006C1
    ERR_BadNamedArgument = 1739, // 0x000006CB
    ERR_DuplicateNamedArgument = 1740, // 0x000006CC
    ERR_NamedArgumentUsedInPositional = 1744, // 0x000006D0
    ERR_BadNamedArgumentForDelegateInvoke = 1746, // 0x000006D2
    ERR_NonInvocableMemberCalled = 1955, // 0x000007A3
    ERR_BadNonTrailingNamedArgument = 8323, // 0x00002083
    ERR_DynamicBindingComUnsupported = 8365, // 0x000020AD
  }
}
