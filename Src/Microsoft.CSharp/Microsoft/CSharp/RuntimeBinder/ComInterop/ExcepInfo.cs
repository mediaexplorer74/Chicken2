// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ExcepInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal struct ExcepInfo
  {
    private short wCode;
    private short wReserved;
    private IntPtr bstrSource;
    private IntPtr bstrDescription;
    private IntPtr bstrHelpFile;
    private int dwHelpContext;
    private IntPtr pvReserved;
    private IntPtr pfnDeferredFillIn;
    private int scode;

    private static string ConvertAndFreeBstr(ref IntPtr bstr)
    {
      if (bstr == IntPtr.Zero)
        return (string) null;
      string stringBstr = Marshal.PtrToStringBSTR(bstr);
      Marshal.FreeBSTR(bstr);
      bstr = IntPtr.Zero;
      return stringBstr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Exception GetException()
    {
      int errorCode = this.scode != 0 ? this.scode : (int) this.wCode;
      Exception exception = Marshal.GetExceptionForHR(errorCode);
      string message = ExcepInfo.ConvertAndFreeBstr(ref this.bstrDescription);
      if (message != null)
      {
        if (exception is COMException)
        {
          exception = (Exception) new COMException(message, errorCode);
        }
        else
        {
          ConstructorInfo constructor = exception.GetType().GetConstructor(new Type[1]
          {
            typeof (string)
          });
          if (constructor != (ConstructorInfo) null)
            exception = (Exception) constructor.Invoke(new object[1]
            {
              (object) message
            });
        }
      }
      exception.Source = ExcepInfo.ConvertAndFreeBstr(ref this.bstrSource);
      string str = ExcepInfo.ConvertAndFreeBstr(ref this.bstrHelpFile);
      if (str != null && this.dwHelpContext != 0)
        str = str + "#" + this.dwHelpContext.ToString();
      exception.HelpLink = str;
      return exception;
    }
  }
}
