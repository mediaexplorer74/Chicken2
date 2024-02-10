// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Error
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal static class Error
  {
    internal static Exception InternalCompilerError()
    {
      return (Exception) new RuntimeBinderInternalCompilerException(SR.InternalCompilerError);
    }

    internal static Exception BindPropertyFailedMethodGroup(object p0)
    {
      return (Exception) new RuntimeBinderException(SR.Format(SR.BindPropertyFailedMethodGroup, p0));
    }

    internal static Exception BindPropertyFailedEvent(object p0)
    {
      return (Exception) new RuntimeBinderException(SR.Format(SR.BindPropertyFailedEvent, p0));
    }

    internal static Exception BindInvokeFailedNonDelegate()
    {
      return (Exception) new RuntimeBinderException(SR.BindInvokeFailedNonDelegate);
    }

    internal static Exception BindStaticRequiresType(string paramName)
    {
      return (Exception) new ArgumentException(SR.TypeArgumentRequiredForStaticCall, paramName);
    }

    internal static Exception NullReferenceOnMemberException()
    {
      return (Exception) new RuntimeBinderException(SR.NullReferenceOnMemberException);
    }

    internal static Exception BindCallToConditionalMethod(object p0)
    {
      return (Exception) new RuntimeBinderException(SR.Format(SR.BindCallToConditionalMethod, p0));
    }

    internal static Exception BindToVoidMethodButExpectResult()
    {
      return (Exception) new RuntimeBinderException(SR.BindToVoidMethodButExpectResult);
    }

    internal static Exception ArgumentNull(string paramName)
    {
      return (Exception) new ArgumentNullException(paramName);
    }

    internal static Exception DynamicArgumentNeedsValue(string paramName)
    {
      return (Exception) new ArgumentException(SR.DynamicArgumentNeedsValue, paramName);
    }
  }
}
