// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.BinderHelper
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics.Hashing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal static class BinderHelper
  {
    private static MethodInfo s_DoubleIsNaN;
    private static MethodInfo s_SingleIsNaN;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static DynamicMetaObject Bind(
      ICSharpBinder action,
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder binder,
      DynamicMetaObject[] args,
      IEnumerable<CSharpArgumentInfo> arginfos,
      DynamicMetaObject onBindingError)
    {
      Expression[] parameters = new Expression[args.Length];
      BindingRestrictions restrictions1 = BindingRestrictions.Empty;
      ICSharpInvokeOrInvokeMemberBinder callPayload = action as ICSharpInvokeOrInvokeMemberBinder;
      ParameterExpression left = (ParameterExpression) null;
      IEnumerator<CSharpArgumentInfo> enumerator = ((IEnumerable<CSharpArgumentInfo>) ((object) arginfos ?? (object) Array.Empty<CSharpArgumentInfo>())).GetEnumerator();
      for (int parameterIndex = 0; parameterIndex < args.Length; ++parameterIndex)
      {
        DynamicMetaObject dynamicMetaObject = args[parameterIndex];
        CSharpArgumentInfo current = enumerator.MoveNext() ? enumerator.Current : (CSharpArgumentInfo) null;
        if (parameterIndex == 0 && BinderHelper.IsIncrementOrDecrementActionOnLocal(action))
        {
          object obj = dynamicMetaObject.Value;
          left = Expression.Variable(obj != null ? obj.GetType() : typeof (object), "t0");
          parameters[0] = (Expression) left;
        }
        else
          parameters[parameterIndex] = dynamicMetaObject.Expression;
        BindingRestrictions restrictions2 = BinderHelper.DeduceArgumentRestriction(parameterIndex, callPayload, dynamicMetaObject, current);
        restrictions1 = restrictions1.Merge(restrictions2);
        if (current != null && current.LiteralConstant)
        {
          if (dynamicMetaObject.Value is double && double.IsNaN((double) dynamicMetaObject.Value))
          {
            MethodInfo method = BinderHelper.s_DoubleIsNaN;
            if ((object) method == null)
              method = BinderHelper.s_DoubleIsNaN = typeof (double).GetMethod("IsNaN");
            Expression expression = (Expression) Expression.Call((Expression) null, method, dynamicMetaObject.Expression);
            restrictions1 = restrictions1.Merge(BindingRestrictions.GetExpressionRestriction(expression));
          }
          else if (dynamicMetaObject.Value is float && float.IsNaN((float) dynamicMetaObject.Value))
          {
            MethodInfo method = BinderHelper.s_SingleIsNaN;
            if ((object) method == null)
              method = BinderHelper.s_SingleIsNaN = typeof (float).GetMethod("IsNaN");
            Expression expression = (Expression) Expression.Call((Expression) null, method, dynamicMetaObject.Expression);
            restrictions1 = restrictions1.Merge(BindingRestrictions.GetExpressionRestriction(expression));
          }
          else
          {
            BindingRestrictions expressionRestriction = BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal(dynamicMetaObject.Expression, (Expression) Expression.Constant(dynamicMetaObject.Value, dynamicMetaObject.Expression.Type)));
            restrictions1 = restrictions1.Merge(expressionRestriction);
          }
        }
      }
      try
      {
        DynamicMetaObject deferredBinding;
        Expression binding = binder.Bind(action, parameters, args, out deferredBinding);
        if (deferredBinding != null)
        {
          Expression expression = BinderHelper.ConvertResult(deferredBinding.Expression, action);
          restrictions1 = deferredBinding.Restrictions.Merge(restrictions1);
          return new DynamicMetaObject(expression, restrictions1);
        }
        if (left != null)
        {
          DynamicMetaObject dynamicMetaObject = args[0];
          binding = (Expression) Expression.Block((IEnumerable<ParameterExpression>) new ParameterExpression[1]
          {
            left
          }, (Expression) Expression.Assign((Expression) left, (Expression) Expression.Convert(dynamicMetaObject.Expression, dynamicMetaObject.Value.GetType())), binding, (Expression) Expression.Assign(dynamicMetaObject.Expression, (Expression) Expression.Convert((Expression) left, dynamicMetaObject.Expression.Type)));
        }
        return new DynamicMetaObject(BinderHelper.ConvertResult(binding, action), restrictions1);
      }
      catch (RuntimeBinderException ex)
      {
        if (onBindingError != null)
          return onBindingError;
        return new DynamicMetaObject((Expression) Expression.Throw((Expression) Expression.New(typeof (RuntimeBinderException).GetConstructor(new Type[1]
        {
          typeof (string)
        }), (Expression) Expression.Constant((object) ex.Message)), BinderHelper.GetTypeForErrorMetaObject(action, args)), restrictions1);
      }
    }

    public static void ValidateBindArgument(DynamicMetaObject argument, string paramName)
    {
      if (argument == null)
        throw Error.ArgumentNull(paramName);
      if (!argument.HasValue)
        throw Error.DynamicArgumentNeedsValue(paramName);
    }

    public static void ValidateBindArgument(DynamicMetaObject[] arguments, string paramName)
    {
      if (arguments == null)
        return;
      for (int index = 0; index != arguments.Length; ++index)
      {
        DynamicMetaObject dynamicMetaObject = arguments[index];
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
        interpolatedStringHandler.AppendFormatted(paramName);
        interpolatedStringHandler.AppendLiteral("[");
        interpolatedStringHandler.AppendFormatted<int>(index);
        interpolatedStringHandler.AppendLiteral("]");
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        BinderHelper.ValidateBindArgument(dynamicMetaObject, stringAndClear);
      }
    }

    private static bool IsTypeOfStaticCall(
      int parameterIndex,
      ICSharpInvokeOrInvokeMemberBinder callPayload)
    {
      return parameterIndex == 0 && callPayload != null && callPayload.StaticCall;
    }

    private static bool IsComObject(object obj) => obj != null && Marshal.IsComObject(obj);

    private static bool IsDynamicallyTypedRuntimeProxy(
      DynamicMetaObject argument,
      CSharpArgumentInfo info)
    {
      return info != null && !info.UseCompileTimeType && BinderHelper.IsComObject(argument.Value);
    }

    private static BindingRestrictions DeduceArgumentRestriction(
      int parameterIndex,
      ICSharpInvokeOrInvokeMemberBinder callPayload,
      DynamicMetaObject argument,
      CSharpArgumentInfo info)
    {
      return argument.Value != null && !BinderHelper.IsTypeOfStaticCall(parameterIndex, callPayload) && !BinderHelper.IsDynamicallyTypedRuntimeProxy(argument, info) ? BindingRestrictions.GetTypeRestriction(argument.Expression, argument.RuntimeType) : BindingRestrictions.GetInstanceRestriction(argument.Expression, argument.Value);
    }

    private static Expression ConvertResult(Expression binding, ICSharpBinder action)
    {
      if (action is CSharpInvokeConstructorBinder)
        return binding;
      if (binding.Type == typeof (void))
      {
        if (action is ICSharpInvokeOrInvokeMemberBinder invokeMemberBinder && invokeMemberBinder.ResultDiscarded)
          return (Expression) Expression.Block(binding, (Expression) Expression.Default(action.ReturnType));
        throw Error.BindToVoidMethodButExpectResult();
      }
      return binding.Type.IsValueType && !action.ReturnType.IsValueType ? (Expression) Expression.Convert(binding, action.ReturnType) : binding;
    }

    private static Type GetTypeForErrorMetaObject(ICSharpBinder action, DynamicMetaObject[] args)
    {
      return action is CSharpInvokeConstructorBinder ? args[0].Value as Type : action.ReturnType;
    }

    private static bool IsIncrementOrDecrementActionOnLocal(ICSharpBinder action)
    {
      if (!(action is CSharpUnaryOperationBinder unaryOperationBinder))
        return false;
      return unaryOperationBinder.Operation == ExpressionType.Increment || unaryOperationBinder.Operation == ExpressionType.Decrement;
    }

    internal static T[] Cons<T>(T sourceHead, T[] sourceTail)
    {
      if ((sourceTail != null ? (sourceTail.Length != 0 ? 1 : 0) : 1) != 0)
      {
        T[] objArray = new T[sourceTail.Length + 1];
        objArray[0] = sourceHead;
        sourceTail.CopyTo((Array) objArray, 1);
        return objArray;
      }
      return new T[1]{ sourceHead };
    }

    internal static T[] Cons<T>(T sourceHead, T[] sourceMiddle, T sourceLast)
    {
      if ((sourceMiddle != null ? (sourceMiddle.Length != 0 ? 1 : 0) : 1) != 0)
      {
        T[] objArray = new T[sourceMiddle.Length + 2];
        objArray[0] = sourceHead;
        objArray[objArray.Length - 1] = sourceLast;
        sourceMiddle.CopyTo((Array) objArray, 1);
        return objArray;
      }
      return new T[2]{ sourceHead, sourceLast };
    }

    internal static T[] ToArray<T>(IEnumerable<T> source)
    {
      return source != null ? source.ToArray<T>() : Array.Empty<T>();
    }

    internal static CallInfo CreateCallInfo(
      ref IEnumerable<CSharpArgumentInfo> argInfos,
      int discard)
    {
      int num = 0;
      List<string> argNames = new List<string>();
      CSharpArgumentInfo[] array = BinderHelper.ToArray<CSharpArgumentInfo>(argInfos);
      argInfos = (IEnumerable<CSharpArgumentInfo>) array;
      foreach (CSharpArgumentInfo csharpArgumentInfo in array)
      {
        if (csharpArgumentInfo.NamedArgument)
          argNames.Add(csharpArgumentInfo.Name);
        ++num;
      }
      return new CallInfo(num - discard, (IEnumerable<string>) argNames);
    }

    internal static string GetCLROperatorName(this ExpressionType p)
    {
      string clrOperatorName;
      switch (p)
      {
        case ExpressionType.Add:
          clrOperatorName = "op_Addition";
          break;
        case ExpressionType.And:
          clrOperatorName = "op_BitwiseAnd";
          break;
        case ExpressionType.Divide:
          clrOperatorName = "op_Division";
          break;
        case ExpressionType.Equal:
          clrOperatorName = "op_Equality";
          break;
        case ExpressionType.ExclusiveOr:
          clrOperatorName = "op_ExclusiveOr";
          break;
        case ExpressionType.GreaterThan:
          clrOperatorName = "op_GreaterThan";
          break;
        case ExpressionType.GreaterThanOrEqual:
          clrOperatorName = "op_GreaterThanOrEqual";
          break;
        case ExpressionType.LeftShift:
          clrOperatorName = "op_LeftShift";
          break;
        case ExpressionType.LessThan:
          clrOperatorName = "op_LessThan";
          break;
        case ExpressionType.LessThanOrEqual:
          clrOperatorName = "op_LessThanOrEqual";
          break;
        case ExpressionType.Modulo:
          clrOperatorName = "op_Modulus";
          break;
        case ExpressionType.Multiply:
          clrOperatorName = "op_Multiply";
          break;
        case ExpressionType.Negate:
          clrOperatorName = "op_UnaryNegation";
          break;
        case ExpressionType.UnaryPlus:
          clrOperatorName = "op_UnaryPlus";
          break;
        case ExpressionType.Not:
          clrOperatorName = "op_LogicalNot";
          break;
        case ExpressionType.NotEqual:
          clrOperatorName = "op_Inequality";
          break;
        case ExpressionType.Or:
          clrOperatorName = "op_BitwiseOr";
          break;
        case ExpressionType.RightShift:
          clrOperatorName = "op_RightShift";
          break;
        case ExpressionType.Subtract:
          clrOperatorName = "op_Subtraction";
          break;
        case ExpressionType.Decrement:
          clrOperatorName = "op_Decrement";
          break;
        case ExpressionType.Increment:
          clrOperatorName = "op_Increment";
          break;
        case ExpressionType.AddAssign:
          clrOperatorName = "op_Addition";
          break;
        case ExpressionType.AndAssign:
          clrOperatorName = "op_BitwiseAnd";
          break;
        case ExpressionType.DivideAssign:
          clrOperatorName = "op_Division";
          break;
        case ExpressionType.ExclusiveOrAssign:
          clrOperatorName = "op_ExclusiveOr";
          break;
        case ExpressionType.LeftShiftAssign:
          clrOperatorName = "op_LeftShift";
          break;
        case ExpressionType.ModuloAssign:
          clrOperatorName = "op_Modulus";
          break;
        case ExpressionType.MultiplyAssign:
          clrOperatorName = "op_Multiply";
          break;
        case ExpressionType.OrAssign:
          clrOperatorName = "op_BitwiseOr";
          break;
        case ExpressionType.RightShiftAssign:
          clrOperatorName = "op_RightShift";
          break;
        case ExpressionType.SubtractAssign:
          clrOperatorName = "op_Subtraction";
          break;
        case ExpressionType.OnesComplement:
          clrOperatorName = "op_OnesComplement";
          break;
        case ExpressionType.IsTrue:
          clrOperatorName = "op_True";
          break;
        case ExpressionType.IsFalse:
          clrOperatorName = "op_False";
          break;
        default:
          clrOperatorName = (string) null;
          break;
      }
      return clrOperatorName;
    }

    internal static int AddArgHashes(int hash, Type[] typeArguments, CSharpArgumentInfo[] argInfos)
    {
      foreach (Type typeArgument in typeArguments)
        hash = HashHelpers.Combine(hash, typeArgument.GetHashCode());
      return BinderHelper.AddArgHashes(hash, argInfos);
    }

    internal static int AddArgHashes(int hash, CSharpArgumentInfo[] argInfos)
    {
      foreach (CSharpArgumentInfo argInfo in argInfos)
      {
        hash = HashHelpers.Combine(hash, (int) argInfo.Flags);
        string name = argInfo.Name;
        if (!string.IsNullOrEmpty(name))
          hash = HashHelpers.Combine(hash, name.GetHashCode());
      }
      return hash;
    }

    internal static bool CompareArgInfos(
      Type[] typeArgs,
      Type[] otherTypeArgs,
      CSharpArgumentInfo[] argInfos,
      CSharpArgumentInfo[] otherArgInfos)
    {
      for (int index = 0; index < typeArgs.Length; ++index)
      {
        if (typeArgs[index] != otherTypeArgs[index])
          return false;
      }
      return BinderHelper.CompareArgInfos(argInfos, otherArgInfos);
    }

    internal static bool CompareArgInfos(
      CSharpArgumentInfo[] argInfos,
      CSharpArgumentInfo[] otherArgInfos)
    {
      for (int index = 0; index < argInfos.Length; ++index)
      {
        CSharpArgumentInfo argInfo = argInfos[index];
        CSharpArgumentInfo otherArgInfo = otherArgInfos[index];
        if (argInfo.Flags != otherArgInfo.Flags || argInfo.Name != otherArgInfo.Name)
          return false;
      }
      return true;
    }
  }
}
