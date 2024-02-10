﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.ComponentModel;

#nullable enable
namespace Microsoft.CSharp.RuntimeBinder
{
  /// <summary>Represents information about C# dynamic operations that are specific to particular arguments at a call site. Instances of this class are generated by the C# compiler.</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public sealed class CSharpArgumentInfo
  {
    #nullable disable
    internal static readonly CSharpArgumentInfo None = new CSharpArgumentInfo(CSharpArgumentInfoFlags.None, (string) null);

    internal CSharpArgumentInfoFlags Flags { get; }

    #nullable enable
    internal string Name { get; }

    #nullable disable
    private CSharpArgumentInfo(CSharpArgumentInfoFlags flags, string name)
    {
      this.Flags = flags;
      this.Name = name;
    }

    #nullable enable
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> class.</summary>
    /// <param name="flags">The flags for the argument.</param>
    /// <param name="name">The name of the argument, if named; otherwise null.</param>
    /// <returns>A new instance of the <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> class.</returns>
    public static CSharpArgumentInfo Create(CSharpArgumentInfoFlags flags, string? name)
    {
      return new CSharpArgumentInfo(flags, name);
    }

    internal bool UseCompileTimeType
    {
      get => (this.Flags & CSharpArgumentInfoFlags.UseCompileTimeType) != 0;
    }

    internal bool LiteralConstant => (this.Flags & CSharpArgumentInfoFlags.Constant) != 0;

    internal bool NamedArgument => (this.Flags & CSharpArgumentInfoFlags.NamedArgument) != 0;

    internal bool IsByRefOrOut
    {
      get => (this.Flags & (CSharpArgumentInfoFlags.IsRef | CSharpArgumentInfoFlags.IsOut)) != 0;
    }

    internal bool IsOut => (this.Flags & CSharpArgumentInfoFlags.IsOut) != 0;

    internal bool IsStaticType => (this.Flags & CSharpArgumentInfoFlags.IsStaticType) != 0;
  }
}