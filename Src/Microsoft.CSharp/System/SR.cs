// Decompiled with JetBrains decompiler
// Type: System.SR
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Resources;

#nullable disable
namespace System
{
  internal static class SR
  {
    private static readonly bool s_usingResourceKeys;
    private static ResourceManager s_resourceManager;

    private static bool UsingResourceKeys() => SR.s_usingResourceKeys;

    internal static string GetResourceString(string resourceKey)
    {
      if (SR.UsingResourceKeys())
        return resourceKey;
      string resourceString = (string) null;
      try
      {
        resourceString = SR.ResourceManager.GetString(resourceKey);
      }
      catch (MissingManifestResourceException ex)
      {
      }
      return resourceString;
    }

    internal static string GetResourceString(string resourceKey, string defaultString)
    {
      string resourceString = SR.GetResourceString(resourceKey);
      return !(resourceKey == resourceString) && resourceString != null ? resourceString : defaultString;
    }

    internal static string Format(string resourceFormat, object p1)
    {
      if (!SR.UsingResourceKeys())
        return string.Format(resourceFormat, p1);
      return string.Join(", ", (object) resourceFormat, p1);
    }

    internal static string Format(string resourceFormat, object p1, object p2)
    {
      if (!SR.UsingResourceKeys())
        return string.Format(resourceFormat, p1, p2);
      return string.Join(", ", (object) resourceFormat, p1, p2);
    }

    internal static ResourceManager ResourceManager
    {
      get => SR.s_resourceManager ?? (SR.s_resourceManager = new ResourceManager(typeof (FxResources.Microsoft.CSharp.SR)));
    }

    internal static string InternalCompilerError
    {
      get => SR.GetResourceString(nameof (InternalCompilerError));
    }

    internal static string BindPropertyFailedMethodGroup
    {
      get => SR.GetResourceString(nameof (BindPropertyFailedMethodGroup));
    }

    internal static string BindPropertyFailedEvent
    {
      get => SR.GetResourceString(nameof (BindPropertyFailedEvent));
    }

    internal static string BindInvokeFailedNonDelegate
    {
      get => SR.GetResourceString(nameof (BindInvokeFailedNonDelegate));
    }

    internal static string NullReferenceOnMemberException
    {
      get => SR.GetResourceString(nameof (NullReferenceOnMemberException));
    }

    internal static string BindCallToConditionalMethod
    {
      get => SR.GetResourceString(nameof (BindCallToConditionalMethod));
    }

    internal static string BindToVoidMethodButExpectResult
    {
      get => SR.GetResourceString(nameof (BindToVoidMethodButExpectResult));
    }

    internal static string EmptyDynamicView => SR.GetResourceString(nameof (EmptyDynamicView));

    internal static string GetValueonWriteOnlyProperty
    {
      get => SR.GetResourceString(nameof (GetValueonWriteOnlyProperty));
    }

    internal static string BadBinaryOps => SR.GetResourceString(nameof (BadBinaryOps));

    internal static string BadIndexLHS => SR.GetResourceString(nameof (BadIndexLHS));

    internal static string BadIndexCount => SR.GetResourceString(nameof (BadIndexCount));

    internal static string BadUnaryOp => SR.GetResourceString(nameof (BadUnaryOp));

    internal static string NoImplicitConv => SR.GetResourceString(nameof (NoImplicitConv));

    internal static string NoExplicitConv => SR.GetResourceString(nameof (NoExplicitConv));

    internal static string ConstOutOfRange => SR.GetResourceString(nameof (ConstOutOfRange));

    internal static string AmbigBinaryOps => SR.GetResourceString(nameof (AmbigBinaryOps));

    internal static string AmbigUnaryOp => SR.GetResourceString(nameof (AmbigUnaryOp));

    internal static string ValueCantBeNull => SR.GetResourceString(nameof (ValueCantBeNull));

    internal static string NoSuchMember => SR.GetResourceString(nameof (NoSuchMember));

    internal static string ObjectRequired => SR.GetResourceString(nameof (ObjectRequired));

    internal static string AmbigCall => SR.GetResourceString(nameof (AmbigCall));

    internal static string BadAccess => SR.GetResourceString(nameof (BadAccess));

    internal static string AssgLvalueExpected => SR.GetResourceString(nameof (AssgLvalueExpected));

    internal static string NoConstructors => SR.GetResourceString(nameof (NoConstructors));

    internal static string PropertyLacksGet => SR.GetResourceString(nameof (PropertyLacksGet));

    internal static string ObjectProhibited => SR.GetResourceString(nameof (ObjectProhibited));

    internal static string AssgReadonly => SR.GetResourceString(nameof (AssgReadonly));

    internal static string AssgReadonlyStatic => SR.GetResourceString(nameof (AssgReadonlyStatic));

    internal static string AssgReadonlyProp => SR.GetResourceString(nameof (AssgReadonlyProp));

    internal static string UnsafeNeeded => SR.GetResourceString(nameof (UnsafeNeeded));

    internal static string BadBoolOp => SR.GetResourceString(nameof (BadBoolOp));

    internal static string MustHaveOpTF => SR.GetResourceString(nameof (MustHaveOpTF));

    internal static string ConstOutOfRangeChecked
    {
      get => SR.GetResourceString(nameof (ConstOutOfRangeChecked));
    }

    internal static string AmbigMember => SR.GetResourceString(nameof (AmbigMember));

    internal static string NoImplicitConvCast => SR.GetResourceString(nameof (NoImplicitConvCast));

    internal static string InaccessibleGetter => SR.GetResourceString(nameof (InaccessibleGetter));

    internal static string InaccessibleSetter => SR.GetResourceString(nameof (InaccessibleSetter));

    internal static string BadArity => SR.GetResourceString(nameof (BadArity));

    internal static string TypeArgsNotAllowed => SR.GetResourceString(nameof (TypeArgsNotAllowed));

    internal static string HasNoTypeVars => SR.GetResourceString(nameof (HasNoTypeVars));

    internal static string NewConstraintNotSatisfied
    {
      get => SR.GetResourceString(nameof (NewConstraintNotSatisfied));
    }

    internal static string GenericConstraintNotSatisfiedRefType
    {
      get => SR.GetResourceString(nameof (GenericConstraintNotSatisfiedRefType));
    }

    internal static string GenericConstraintNotSatisfiedNullableEnum
    {
      get => SR.GetResourceString(nameof (GenericConstraintNotSatisfiedNullableEnum));
    }

    internal static string GenericConstraintNotSatisfiedNullableInterface
    {
      get => SR.GetResourceString(nameof (GenericConstraintNotSatisfiedNullableInterface));
    }

    internal static string GenericConstraintNotSatisfiedValType
    {
      get => SR.GetResourceString(nameof (GenericConstraintNotSatisfiedValType));
    }

    internal static string CantInferMethTypeArgs
    {
      get => SR.GetResourceString(nameof (CantInferMethTypeArgs));
    }

    internal static string RefConstraintNotSatisfied
    {
      get => SR.GetResourceString(nameof (RefConstraintNotSatisfied));
    }

    internal static string ValConstraintNotSatisfied
    {
      get => SR.GetResourceString(nameof (ValConstraintNotSatisfied));
    }

    internal static string AmbigUDConv => SR.GetResourceString(nameof (AmbigUDConv));

    internal static string BindToBogus => SR.GetResourceString(nameof (BindToBogus));

    internal static string CantCallSpecialMethod
    {
      get => SR.GetResourceString(nameof (CantCallSpecialMethod));
    }

    internal static string ConvertToStaticClass
    {
      get => SR.GetResourceString(nameof (ConvertToStaticClass));
    }

    internal static string IncrementLvalueExpected
    {
      get => SR.GetResourceString(nameof (IncrementLvalueExpected));
    }

    internal static string BadArgCount => SR.GetResourceString(nameof (BadArgCount));

    internal static string BadArgTypes => SR.GetResourceString(nameof (BadArgTypes));

    internal static string BadProtectedAccess => SR.GetResourceString(nameof (BadProtectedAccess));

    internal static string BindToBogusProp2 => SR.GetResourceString(nameof (BindToBogusProp2));

    internal static string BindToBogusProp1 => SR.GetResourceString(nameof (BindToBogusProp1));

    internal static string BadDelArgCount => SR.GetResourceString(nameof (BadDelArgCount));

    internal static string BadDelArgTypes => SR.GetResourceString(nameof (BadDelArgTypes));

    internal static string BadCtorArgCount => SR.GetResourceString(nameof (BadCtorArgCount));

    internal static string NonInvocableMemberCalled
    {
      get => SR.GetResourceString(nameof (NonInvocableMemberCalled));
    }

    internal static string BadNamedArgument => SR.GetResourceString(nameof (BadNamedArgument));

    internal static string BadNamedArgumentForDelegateInvoke
    {
      get => SR.GetResourceString(nameof (BadNamedArgumentForDelegateInvoke));
    }

    internal static string DuplicateNamedArgument
    {
      get => SR.GetResourceString(nameof (DuplicateNamedArgument));
    }

    internal static string NamedArgumentUsedInPositional
    {
      get => SR.GetResourceString(nameof (NamedArgumentUsedInPositional));
    }

    internal static string TypeArgumentRequiredForStaticCall
    {
      get => SR.GetResourceString(nameof (TypeArgumentRequiredForStaticCall));
    }

    internal static string DynamicArgumentNeedsValue
    {
      get => SR.GetResourceString(nameof (DynamicArgumentNeedsValue));
    }

    internal static string BadNonTrailingNamedArgument
    {
      get => SR.GetResourceString(nameof (BadNonTrailingNamedArgument));
    }

    internal static string DynamicBindingComUnsupported
    {
      get => SR.GetResourceString(nameof (DynamicBindingComUnsupported));
    }

    internal static string COMAmbiguousConversion
    {
      get => SR.GetResourceString(nameof (COMAmbiguousConversion));
    }

    internal static string COMCannotPerformCall
    {
      get => SR.GetResourceString(nameof (COMCannotPerformCall));
    }

    internal static string COMCannotRetrieveTypeInfo
    {
      get => SR.GetResourceString(nameof (COMCannotRetrieveTypeInfo));
    }

    internal static string COMDispatchInvokeError
    {
      get => SR.GetResourceString(nameof (COMDispatchInvokeError));
    }

    internal static string COMDispatchInvokeErrorNoNamedArgs
    {
      get => SR.GetResourceString(nameof (COMDispatchInvokeErrorNoNamedArgs));
    }

    internal static string COMDispatchInvokeErrorParamNotOptional
    {
      get => SR.GetResourceString(nameof (COMDispatchInvokeErrorParamNotOptional));
    }

    internal static string COMDispatchInvokeErrorTypeMismatch
    {
      get => SR.GetResourceString(nameof (COMDispatchInvokeErrorTypeMismatch));
    }

    internal static string COMGetDispatchIdFailed
    {
      get => SR.GetResourceString(nameof (COMGetDispatchIdFailed));
    }

    internal static string COMGetIDsOfNamesInvalid
    {
      get => SR.GetResourceString(nameof (COMGetIDsOfNamesInvalid));
    }

    internal static string COMSetComObjectDataFailed
    {
      get => SR.GetResourceString(nameof (COMSetComObjectDataFailed));
    }

    internal static string COMUnexpectedVarEnum
    {
      get => SR.GetResourceString(nameof (COMUnexpectedVarEnum));
    }

    internal static string COMUnsupportedEventHandlerType
    {
      get => SR.GetResourceString(nameof (COMUnsupportedEventHandlerType));
    }

    internal static string UnsupportedEnum => SR.GetResourceString(nameof (UnsupportedEnum));

    static SR()
    {
      bool isEnabled;
      SR.s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out isEnabled) && isEnabled;
    }
  }
}
