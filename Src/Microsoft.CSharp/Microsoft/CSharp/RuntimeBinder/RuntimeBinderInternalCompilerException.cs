// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Runtime.Serialization;

#nullable enable
namespace Microsoft.CSharp.RuntimeBinder
{
  /// <summary>Represents an error that occurs when a dynamic bind in the C# runtime binder is processed.</summary>
  [Serializable]
  public class RuntimeBinderInternalCompilerException : Exception
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException" /> class with a system-supplied message that describes the error.</summary>
    public RuntimeBinderInternalCompilerException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException" /> class with a specified message that describes the error.</summary>
    /// <param name="message">The message that describes the exception. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
    public RuntimeBinderInternalCompilerException(string? message)
      : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException" /> class that has a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
    public RuntimeBinderInternalCompilerException(string? message, Exception? innerException)
      : base(message, innerException)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.RuntimeBinderInternalCompilerException" /> class with serialized data.</summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
    protected RuntimeBinderInternalCompilerException(
      SerializationInfo info,
      StreamingContext context)
      : base(info, context)
    {
    }
  }
}
