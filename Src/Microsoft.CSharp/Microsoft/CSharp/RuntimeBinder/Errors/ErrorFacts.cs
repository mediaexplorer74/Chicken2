// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Errors.ErrorFacts
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
  internal static class ErrorFacts
  {
    public static string GetMessage(ErrorCode code)
    {
      string message;
      switch (code)
      {
        case ErrorCode.ERR_BadBinaryOps:
          message = SR.BadBinaryOps;
          break;
        case ErrorCode.ERR_BadIndexLHS:
          message = SR.BadIndexLHS;
          break;
        case ErrorCode.ERR_BadIndexCount:
          message = SR.BadIndexCount;
          break;
        case ErrorCode.ERR_BadUnaryOp:
          message = SR.BadUnaryOp;
          break;
        case ErrorCode.ERR_NoImplicitConv:
          message = SR.NoImplicitConv;
          break;
        case ErrorCode.ERR_NoExplicitConv:
          message = SR.NoExplicitConv;
          break;
        case ErrorCode.ERR_ConstOutOfRange:
          message = SR.ConstOutOfRange;
          break;
        case ErrorCode.ERR_AmbigBinaryOps:
          message = SR.AmbigBinaryOps;
          break;
        case ErrorCode.ERR_AmbigUnaryOp:
          message = SR.AmbigUnaryOp;
          break;
        case ErrorCode.ERR_ValueCantBeNull:
          message = SR.ValueCantBeNull;
          break;
        case ErrorCode.ERR_NoSuchMember:
          message = SR.NoSuchMember;
          break;
        case ErrorCode.ERR_ObjectRequired:
          message = SR.ObjectRequired;
          break;
        case ErrorCode.ERR_AmbigCall:
          message = SR.AmbigCall;
          break;
        case ErrorCode.ERR_BadAccess:
          message = SR.BadAccess;
          break;
        case ErrorCode.ERR_AssgLvalueExpected:
          message = SR.AssgLvalueExpected;
          break;
        case ErrorCode.ERR_NoConstructors:
          message = SR.NoConstructors;
          break;
        case ErrorCode.ERR_PropertyLacksGet:
          message = SR.PropertyLacksGet;
          break;
        case ErrorCode.ERR_ObjectProhibited:
          message = SR.ObjectProhibited;
          break;
        case ErrorCode.ERR_AssgReadonly:
          message = SR.AssgReadonly;
          break;
        case ErrorCode.ERR_AssgReadonlyStatic:
          message = SR.AssgReadonlyStatic;
          break;
        case ErrorCode.ERR_AssgReadonlyProp:
          message = SR.AssgReadonlyProp;
          break;
        case ErrorCode.ERR_UnsafeNeeded:
          message = SR.UnsafeNeeded;
          break;
        case ErrorCode.ERR_BadBoolOp:
          message = SR.BadBoolOp;
          break;
        case ErrorCode.ERR_MustHaveOpTF:
          message = SR.MustHaveOpTF;
          break;
        case ErrorCode.ERR_ConstOutOfRangeChecked:
          message = SR.ConstOutOfRangeChecked;
          break;
        case ErrorCode.ERR_AmbigMember:
          message = SR.AmbigMember;
          break;
        case ErrorCode.ERR_NoImplicitConvCast:
          message = SR.NoImplicitConvCast;
          break;
        case ErrorCode.ERR_InaccessibleGetter:
          message = SR.InaccessibleGetter;
          break;
        case ErrorCode.ERR_InaccessibleSetter:
          message = SR.InaccessibleSetter;
          break;
        case ErrorCode.ERR_BadArity:
          message = SR.BadArity;
          break;
        case ErrorCode.ERR_TypeArgsNotAllowed:
          message = SR.TypeArgsNotAllowed;
          break;
        case ErrorCode.ERR_HasNoTypeVars:
          message = SR.HasNoTypeVars;
          break;
        case ErrorCode.ERR_NewConstraintNotSatisfied:
          message = SR.NewConstraintNotSatisfied;
          break;
        case ErrorCode.ERR_GenericConstraintNotSatisfiedRefType:
          message = SR.GenericConstraintNotSatisfiedRefType;
          break;
        case ErrorCode.ERR_GenericConstraintNotSatisfiedNullableEnum:
          message = SR.GenericConstraintNotSatisfiedNullableEnum;
          break;
        case ErrorCode.ERR_GenericConstraintNotSatisfiedNullableInterface:
          message = SR.GenericConstraintNotSatisfiedNullableInterface;
          break;
        case ErrorCode.ERR_GenericConstraintNotSatisfiedValType:
          message = SR.GenericConstraintNotSatisfiedValType;
          break;
        case ErrorCode.ERR_CantInferMethTypeArgs:
          message = SR.CantInferMethTypeArgs;
          break;
        case ErrorCode.ERR_RefConstraintNotSatisfied:
          message = SR.RefConstraintNotSatisfied;
          break;
        case ErrorCode.ERR_ValConstraintNotSatisfied:
          message = SR.ValConstraintNotSatisfied;
          break;
        case ErrorCode.ERR_AmbigUDConv:
          message = SR.AmbigUDConv;
          break;
        case ErrorCode.ERR_BindToBogus:
          message = SR.BindToBogus;
          break;
        case ErrorCode.ERR_CantCallSpecialMethod:
          message = SR.CantCallSpecialMethod;
          break;
        case ErrorCode.ERR_ConvertToStaticClass:
          message = SR.ConvertToStaticClass;
          break;
        case ErrorCode.ERR_IncrementLvalueExpected:
          message = SR.IncrementLvalueExpected;
          break;
        case ErrorCode.ERR_BadArgCount:
          message = SR.BadArgCount;
          break;
        case ErrorCode.ERR_BadArgTypes:
          message = SR.BadArgTypes;
          break;
        case ErrorCode.ERR_BadProtectedAccess:
          message = SR.BadProtectedAccess;
          break;
        case ErrorCode.ERR_BindToBogusProp2:
          message = SR.BindToBogusProp2;
          break;
        case ErrorCode.ERR_BindToBogusProp1:
          message = SR.BindToBogusProp1;
          break;
        case ErrorCode.ERR_BadDelArgCount:
          message = SR.BadDelArgCount;
          break;
        case ErrorCode.ERR_BadDelArgTypes:
          message = SR.BadDelArgTypes;
          break;
        case ErrorCode.ERR_BadCtorArgCount:
          message = SR.BadCtorArgCount;
          break;
        case ErrorCode.ERR_BadNamedArgument:
          message = SR.BadNamedArgument;
          break;
        case ErrorCode.ERR_DuplicateNamedArgument:
          message = SR.DuplicateNamedArgument;
          break;
        case ErrorCode.ERR_NamedArgumentUsedInPositional:
          message = SR.NamedArgumentUsedInPositional;
          break;
        case ErrorCode.ERR_BadNamedArgumentForDelegateInvoke:
          message = SR.BadNamedArgumentForDelegateInvoke;
          break;
        case ErrorCode.ERR_NonInvocableMemberCalled:
          message = SR.NonInvocableMemberCalled;
          break;
        case ErrorCode.ERR_BadNonTrailingNamedArgument:
          message = SR.BadNonTrailingNamedArgument;
          break;
        case ErrorCode.ERR_DynamicBindingComUnsupported:
          message = SR.DynamicBindingComUnsupported;
          break;
        default:
          message = (string) null;
          break;
      }
      return message;
    }

    public static string GetMessage(MessageID id)
    {
      string str = id.ToString();
      return SR.GetResourceString(str, str);
    }
  }
}
