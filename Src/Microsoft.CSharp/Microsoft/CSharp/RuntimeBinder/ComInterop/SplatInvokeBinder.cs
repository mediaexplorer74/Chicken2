// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.SplatInvokeBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class SplatInvokeBinder : CallSiteBinder
  {
    private static readonly SplatInvokeBinder s_instance = new SplatInvokeBinder();

    internal static SplatInvokeBinder Instance
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return SplatInvokeBinder.s_instance;
      }
    }

    private SplatInvokeBinder()
    {
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. The only entry-point to this class is through Instance property which is marked as unsafe.")]
    public override Expression Bind(
      object[] args,
      ReadOnlyCollection<ParameterExpression> parameters,
      LabelTarget returnLabel)
    {
      int length = ((object[]) args[1]).Length;
      ParameterExpression parameter = parameters[1];
      ReadOnlyCollectionBuilder<Expression> arguments = new ReadOnlyCollectionBuilder<Expression>(length + 1);
      Type[] typeArray = new Type[length + 3];
      arguments.Add((Expression) parameters[0]);
      typeArray[0] = typeof (CallSite);
      typeArray[1] = typeof (object);
      for (int index = 0; index < length; ++index)
      {
        arguments.Add((Expression) Expression.ArrayAccess((Expression) parameter, (Expression) Expression.Constant((object) index)));
        typeArray[index + 2] = typeof (object).MakeByRefType();
      }
      typeArray[typeArray.Length - 1] = typeof (object);
      return (Expression) Expression.IfThen((Expression) Expression.Equal((Expression) Expression.ArrayLength((Expression) parameter), (Expression) Expression.Constant((object) length)), (Expression) Expression.Return(returnLabel, (Expression) Expression.MakeDynamic(Expression.GetDelegateType(typeArray), (CallSiteBinder) new ComInvokeAction(new CallInfo(length, Array.Empty<string>())), (IEnumerable<Expression>) arguments)));
    }
  }
}
