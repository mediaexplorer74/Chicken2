// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.Error
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class Error
  {
    internal static Exception SetComObjectDataFailed()
    {
      return (Exception) new InvalidOperationException(SR.COMSetComObjectDataFailed);
    }

    internal static Exception UnexpectedVarEnum(object p0)
    {
      return (Exception) new InvalidOperationException(SR.Format(SR.COMUnexpectedVarEnum, p0));
    }

    internal static Exception DispBadParamCount(object p0)
    {
      return (Exception) new TargetParameterCountException(SR.Format(SR.COMDispatchInvokeError, p0));
    }

    internal static Exception DispMemberNotFound(object p0)
    {
      return (Exception) new MissingMemberException(SR.Format(SR.COMDispatchInvokeError, p0));
    }

    internal static Exception DispNoNamedArgs(object p0)
    {
      return (Exception) new ArgumentException(SR.Format(SR.COMDispatchInvokeErrorNoNamedArgs, p0));
    }

    internal static Exception DispOverflow(object p0)
    {
      return (Exception) new OverflowException(SR.Format(SR.COMDispatchInvokeError, p0));
    }

    internal static Exception DispTypeMismatch(object p0, object p1)
    {
      return (Exception) new ArgumentException(SR.Format(SR.COMDispatchInvokeErrorTypeMismatch, p0, p1));
    }

    internal static Exception DispParamNotOptional(object p0)
    {
      return (Exception) new ArgumentException(SR.Format(SR.COMDispatchInvokeErrorParamNotOptional, p0));
    }

    internal static Exception CannotRetrieveTypeInformation()
    {
      return (Exception) new InvalidOperationException(SR.COMCannotRetrieveTypeInfo);
    }

    internal static Exception GetIDsOfNamesInvalid(object p0)
    {
      return (Exception) new ArgumentException(SR.Format(SR.COMGetIDsOfNamesInvalid, p0));
    }

    internal static Exception UnsupportedHandlerType()
    {
      return (Exception) new InvalidOperationException(SR.COMUnsupportedEventHandlerType);
    }

    internal static Exception CouldNotGetDispId(object p0, object p1)
    {
      return (Exception) new MissingMemberException(SR.Format(SR.COMGetDispatchIdFailed, p0, p1));
    }

    internal static Exception AmbiguousConversion(object p0, object p1)
    {
      return (Exception) new AmbiguousMatchException(SR.Format(SR.COMAmbiguousConversion, p0, p1));
    }
  }
}
