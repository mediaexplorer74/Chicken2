// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Binder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

#nullable enable
namespace Microsoft.CSharp.RuntimeBinder
{
  /// <summary>Contains factory methods to create dynamic call site binders for CSharp.</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public static class Binder
  {
    /// <summary>Initializes a new CSharp binary operation binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="operation">The binary operation kind.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp binary operation binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder BinaryOperation(
      CSharpBinderFlags flags,
      ExpressionType operation,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
      bool flag = (flags & CSharpBinderFlags.BinaryOperationLogical) != 0;
      CSharpBinaryOperationFlags binaryOperationFlags = CSharpBinaryOperationFlags.None;
      if (flag)
        binaryOperationFlags |= CSharpBinaryOperationFlags.LogicalOperation;
      return (CallSiteBinder) new CSharpBinaryOperationBinder(operation, isChecked, binaryOperationFlags, context, argumentInfo).TryGetExisting<CSharpBinaryOperationBinder>();
    }

    /// <summary>Initializes a new CSharp convert binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="type">The type to convert to.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <returns>A new CSharp convert binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder Convert(CSharpBinderFlags flags, Type type, Type? context)
    {
      CSharpConversionKind conversionKind = (flags & CSharpBinderFlags.ConvertExplicit) != CSharpBinderFlags.None ? CSharpConversionKind.ExplicitConversion : ((flags & CSharpBinderFlags.ConvertArrayIndex) != CSharpBinderFlags.None ? CSharpConversionKind.ArrayCreationConversion : CSharpConversionKind.ImplicitConversion);
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
      return (CallSiteBinder) new CSharpConvertBinder(type, conversionKind, isChecked, context).TryGetExisting<CSharpConvertBinder>();
    }

    /// <summary>Initializes a new CSharp get index binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp get index binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder GetIndex(
      CSharpBinderFlags flags,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      return (CallSiteBinder) new CSharpGetIndexBinder(context, argumentInfo).TryGetExisting<CSharpGetIndexBinder>();
    }

    /// <summary>Initializes a new CSharp get member binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="name">The name of the member to get.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp get member binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder GetMember(
      CSharpBinderFlags flags,
      string name,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool resultIndexed = (flags & CSharpBinderFlags.ResultIndexed) != 0;
      return (CallSiteBinder) new CSharpGetMemberBinder(name, resultIndexed, context, argumentInfo).TryGetExisting<CSharpGetMemberBinder>();
    }

    /// <summary>Initializes a new CSharp invoke binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp invoke binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder Invoke(
      CSharpBinderFlags flags,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool flag = (flags & CSharpBinderFlags.ResultDiscarded) != 0;
      CSharpCallFlags flags1 = CSharpCallFlags.None;
      if (flag)
        flags1 |= CSharpCallFlags.ResultDiscarded;
      return (CallSiteBinder) new CSharpInvokeBinder(flags1, context, argumentInfo).TryGetExisting<CSharpInvokeBinder>();
    }

    /// <summary>Initializes a new CSharp invoke member binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="name">The name of the member to invoke.</param>
    /// <param name="typeArguments">The list of type arguments specified for this invoke.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp invoke member binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder InvokeMember(
      CSharpBinderFlags flags,
      string name,
      IEnumerable<Type>? typeArguments,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool flag1 = (flags & CSharpBinderFlags.InvokeSimpleName) != 0;
      bool flag2 = (flags & CSharpBinderFlags.InvokeSpecialName) != 0;
      bool flag3 = (flags & CSharpBinderFlags.ResultDiscarded) != 0;
      CSharpCallFlags flags1 = CSharpCallFlags.None;
      if (flag1)
        flags1 |= CSharpCallFlags.SimpleNameCall;
      if (flag2)
        flags1 |= CSharpCallFlags.EventHookup;
      if (flag3)
        flags1 |= CSharpCallFlags.ResultDiscarded;
      return (CallSiteBinder) new CSharpInvokeMemberBinder(flags1, name, context, typeArguments, argumentInfo).TryGetExisting<CSharpInvokeMemberBinder>();
    }

    /// <summary>Initializes a new CSharp invoke constructor binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp invoke constructor binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder InvokeConstructor(
      CSharpBinderFlags flags,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      return (CallSiteBinder) new CSharpInvokeConstructorBinder(CSharpCallFlags.None, context, argumentInfo).TryGetExisting<CSharpInvokeConstructorBinder>();
    }

    /// <summary>Initializes a new CSharp is event binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="name">The name of the event to look for.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <returns>A new CSharp is event binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder IsEvent(CSharpBinderFlags flags, string name, Type? context)
    {
      return (CallSiteBinder) new CSharpIsEventBinder(name, context).TryGetExisting<CSharpIsEventBinder>();
    }

    /// <summary>Initializes a new CSharp set index binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp set index binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder SetIndex(
      CSharpBinderFlags flags,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      return (CallSiteBinder) new CSharpSetIndexBinder((flags & CSharpBinderFlags.ValueFromCompoundAssignment) != 0, (flags & CSharpBinderFlags.CheckedContext) != 0, context, argumentInfo).TryGetExisting<CSharpSetIndexBinder>();
    }

    /// <summary>Initializes a new CSharp set member binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="name">The name of the member to set.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp set member binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder SetMember(
      CSharpBinderFlags flags,
      string name,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool isCompoundAssignment = (flags & CSharpBinderFlags.ValueFromCompoundAssignment) != 0;
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
      return (CallSiteBinder) new CSharpSetMemberBinder(name, isCompoundAssignment, isChecked, context, argumentInfo).TryGetExisting<CSharpSetMemberBinder>();
    }

    /// <summary>Initializes a new CSharp unary operation binder.</summary>
    /// <param name="flags">The flags with which to initialize the binder.</param>
    /// <param name="operation">The unary operation kind.</param>
    /// <param name="context">The <see cref="T:System.Type" /> that indicates where this operation is used.</param>
    /// <param name="argumentInfo">The sequence of <see cref="T:Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo" /> instances for the arguments to this operation.</param>
    /// <returns>A new CSharp unary operation binder.</returns>
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static CallSiteBinder UnaryOperation(
      CSharpBinderFlags flags,
      ExpressionType operation,
      Type? context,
      IEnumerable<CSharpArgumentInfo>? argumentInfo)
    {
      bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
      return (CallSiteBinder) new CSharpUnaryOperationBinder(operation, isChecked, context, argumentInfo).TryGetExisting<CSharpUnaryOperationBinder>();
    }
  }
}
