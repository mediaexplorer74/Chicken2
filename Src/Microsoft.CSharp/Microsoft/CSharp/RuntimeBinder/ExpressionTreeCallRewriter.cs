// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ExpressionTreeCallRewriter
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class ExpressionTreeCallRewriter : ExprVisitorBase
  {
    private readonly Dictionary<ExprCall, Expression> _DictionaryOfParameters;
    private readonly Expression[] _ListOfParameters;
    private int _currentParameterIndex;

    private ExpressionTreeCallRewriter(Expression[] listOfParameters)
    {
      this._DictionaryOfParameters = new Dictionary<ExprCall, Expression>();
      this._ListOfParameters = listOfParameters;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static Expression Rewrite(ExprBinOp binOp, Expression[] listOfParameters)
    {
      ExpressionTreeCallRewriter treeCallRewriter = new ExpressionTreeCallRewriter(listOfParameters);
      treeCallRewriter.Visit(binOp.OptionalLeftChild);
      ExprCall optionalRightChild = (ExprCall) binOp.OptionalRightChild;
      return (treeCallRewriter.Visit((Expr) optionalRightChild) as ExpressionTreeCallRewriter.ExpressionExpr).Expression;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitSAVE(ExprBinOp pExpr)
    {
      this._DictionaryOfParameters.Add((ExprCall) pExpr.OptionalLeftChild, this._ListOfParameters[this._currentParameterIndex++]);
      return (Expr) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitCALL(ExprCall pExpr)
    {
      if (pExpr.PredefinedMethod == PREDEFMETH.PM_COUNT)
        return (Expr) pExpr;
      Expression e;
      switch (pExpr.PredefinedMethod)
      {
        case PREDEFMETH.PM_EXPRESSION_ADD:
        case PREDEFMETH.PM_EXPRESSION_ADDCHECKED:
        case PREDEFMETH.PM_EXPRESSION_AND:
        case PREDEFMETH.PM_EXPRESSION_ANDALSO:
        case PREDEFMETH.PM_EXPRESSION_DIVIDE:
        case PREDEFMETH.PM_EXPRESSION_EQUAL:
        case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR:
        case PREDEFMETH.PM_EXPRESSION_GREATERTHAN:
        case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL:
        case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT:
        case PREDEFMETH.PM_EXPRESSION_LESSTHAN:
        case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL:
        case PREDEFMETH.PM_EXPRESSION_MODULO:
        case PREDEFMETH.PM_EXPRESSION_MULTIPLY:
        case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED:
        case PREDEFMETH.PM_EXPRESSION_NOTEQUAL:
        case PREDEFMETH.PM_EXPRESSION_OR:
        case PREDEFMETH.PM_EXPRESSION_ORELSE:
        case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT:
        case PREDEFMETH.PM_EXPRESSION_SUBTRACT:
        case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED:
          e = this.GenerateBinaryOperator(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED:
          e = this.GenerateUserDefinedBinaryOperator(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX:
        case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2:
          e = this.GenerateArrayIndex(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_ASSIGN:
          e = this.GenerateAssignment(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE:
          e = ExpressionTreeCallRewriter.GenerateConstantType(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_CONVERT:
        case PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED:
        case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED:
          e = this.GenerateConvert(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_FIELD:
          e = this.GenerateField(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_LAMBDA:
          return this.GenerateLambda(pExpr);
        case PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED:
          e = this.GenerateUserDefinedUnaryOperator(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_NEGATE:
        case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED:
        case PREDEFMETH.PM_EXPRESSION_NOT:
          e = this.GenerateUnaryOperator(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_CALL:
          e = this.GenerateCall(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_NEW:
          e = this.GenerateNew(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_PROPERTY:
          e = this.GenerateProperty(pExpr);
          break;
        case PREDEFMETH.PM_EXPRESSION_INVOKE:
          e = this.GenerateInvoke(pExpr);
          break;
        default:
          throw Error.InternalCompilerError();
      }
      return (Expr) new ExpressionTreeCallRewriter.ExpressionExpr(e);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitWRAP(ExprWrap pExpr)
    {
      return (Expr) new ExpressionTreeCallRewriter.ExpressionExpr(this.GetExpression((Expr) pExpr));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateLambda(ExprCall pExpr)
    {
      return this.Visit(((ExprList) pExpr.OptionalArguments).OptionalElement);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateCall(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      ExprMethodInfo exprMethodInfo;
      ExprArrayInit arrinit;
      if (optionalArguments.OptionalNextListNode is ExprList optionalNextListNode)
      {
        exprMethodInfo = (ExprMethodInfo) optionalNextListNode.OptionalElement;
        arrinit = (ExprArrayInit) optionalNextListNode.OptionalNextListNode;
      }
      else
      {
        exprMethodInfo = (ExprMethodInfo) optionalArguments.OptionalNextListNode;
        arrinit = (ExprArrayInit) null;
      }
      Expression instance = (Expression) null;
      MethodInfo methodInfo = exprMethodInfo.MethodInfo;
      Expression[] argumentsFromArrayInit = this.GetArgumentsFromArrayInit(arrinit);
      if (methodInfo == (MethodInfo) null)
        throw Error.InternalCompilerError();
      if (!methodInfo.IsStatic)
        instance = this.GetExpression(((ExprList) pExpr.OptionalArguments).OptionalElement);
      return (Expression) Expression.Call(instance, methodInfo, argumentsFromArrayInit);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateArrayIndex(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      Expression expression = this.GetExpression(optionalArguments.OptionalElement);
      Expression[] expressionArray;
      if (pExpr.PredefinedMethod == PREDEFMETH.PM_EXPRESSION_ARRAYINDEX)
        expressionArray = new Expression[1]
        {
          this.GetExpression(optionalArguments.OptionalNextListNode)
        };
      else
        expressionArray = this.GetArgumentsFromArrayInit((ExprArrayInit) optionalArguments.OptionalNextListNode);
      return (Expression) Expression.ArrayAccess(expression, expressionArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateConvert(ExprCall pExpr)
    {
      PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
      switch (predefinedMethod)
      {
        case PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED:
        case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED:
          ExprList optionalArguments1 = (ExprList) pExpr.OptionalArguments;
          ExprList optionalNextListNode = (ExprList) optionalArguments1.OptionalNextListNode;
          Expression expression1 = this.GetExpression(optionalArguments1.OptionalElement);
          Type associatedSystemType1 = ((ExprTypeOf) optionalNextListNode.OptionalElement).SourceType.AssociatedSystemType;
          if (expression1.Type.MakeByRefType() == associatedSystemType1)
            return expression1;
          MethodInfo methodInfo = ((ExprMethodInfo) optionalNextListNode.OptionalNextListNode).MethodInfo;
          return predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED ? (Expression) Expression.Convert(expression1, associatedSystemType1, methodInfo) : (Expression) Expression.ConvertChecked(expression1, associatedSystemType1, methodInfo);
        default:
          ExprList optionalArguments2 = (ExprList) pExpr.OptionalArguments;
          Expression expression2 = this.GetExpression(optionalArguments2.OptionalElement);
          Type associatedSystemType2 = ((ExprTypeOf) optionalArguments2.OptionalNextListNode).SourceType.AssociatedSystemType;
          if (expression2.Type.MakeByRefType() == associatedSystemType2)
            return expression2;
          if ((pExpr.Flags & EXPRFLAG.EXF_USERCALLABLE) != (EXPRFLAG) 0)
            return (Expression) Expression.Unbox(expression2, associatedSystemType2);
          return predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERT ? (Expression) Expression.Convert(expression2, associatedSystemType2) : (Expression) Expression.ConvertChecked(expression2, associatedSystemType2);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateProperty(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      Expr optionalElement = optionalArguments.OptionalElement;
      Expr optionalNextListNode = optionalArguments.OptionalNextListNode;
      ExprPropertyInfo exprPropertyInfo;
      ExprArrayInit arrinit;
      if (optionalNextListNode is ExprList exprList)
      {
        exprPropertyInfo = exprList.OptionalElement as ExprPropertyInfo;
        arrinit = exprList.OptionalNextListNode as ExprArrayInit;
      }
      else
      {
        exprPropertyInfo = optionalNextListNode as ExprPropertyInfo;
        arrinit = (ExprArrayInit) null;
      }
      PropertyInfo propertyInfo = exprPropertyInfo.PropertyInfo;
      if (propertyInfo == (PropertyInfo) null)
        throw Error.InternalCompilerError();
      return arrinit == null ? (Expression) Expression.Property(this.GetExpression(optionalElement), propertyInfo) : (Expression) Expression.Property(this.GetExpression(optionalElement), propertyInfo, this.GetArgumentsFromArrayInit(arrinit));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateField(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      ExprFieldInfo optionalNextListNode = (ExprFieldInfo) optionalArguments.OptionalNextListNode;
      Type type = optionalNextListNode.FieldType.AssociatedSystemType;
      FieldInfo field = optionalNextListNode.Field.AssociatedFieldInfo;
      if (!type.IsGenericType && !type.IsNested)
        type = field.DeclaringType;
      if (type.IsGenericType)
        field = type.GetField(field.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
      return (Expression) Expression.Field(this.GetExpression(optionalArguments.OptionalElement), field);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateInvoke(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      return (Expression) Expression.Invoke(this.GetExpression(optionalArguments.OptionalElement), this.GetArgumentsFromArrayInit(optionalArguments.OptionalNextListNode as ExprArrayInit));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateNew(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      return (Expression) Expression.New(((ExprMethodInfo) optionalArguments.OptionalElement).ConstructorInfo, this.GetArgumentsFromArrayInit(optionalArguments.OptionalNextListNode as ExprArrayInit));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expression GenerateConstantType(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      return (Expression) Expression.Constant(optionalArguments.OptionalElement.Object, ((ExprTypeOf) optionalArguments.OptionalNextListNode).SourceType.AssociatedSystemType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateAssignment(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      return (Expression) Expression.Assign(this.GetExpression(optionalArguments.OptionalElement), this.GetExpression(optionalArguments.OptionalNextListNode));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateBinaryOperator(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      Expression expression1 = this.GetExpression(optionalArguments.OptionalElement);
      Expression expression2 = this.GetExpression(optionalArguments.OptionalNextListNode);
      switch (pExpr.PredefinedMethod)
      {
        case PREDEFMETH.PM_EXPRESSION_ADD:
          return (Expression) Expression.Add(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_ADDCHECKED:
          return (Expression) Expression.AddChecked(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_AND:
          return (Expression) Expression.And(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_ANDALSO:
          return (Expression) Expression.AndAlso(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_DIVIDE:
          return (Expression) Expression.Divide(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_EQUAL:
          return (Expression) Expression.Equal(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR:
          return (Expression) Expression.ExclusiveOr(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_GREATERTHAN:
          return (Expression) Expression.GreaterThan(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL:
          return (Expression) Expression.GreaterThanOrEqual(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT:
          return (Expression) Expression.LeftShift(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_LESSTHAN:
          return (Expression) Expression.LessThan(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL:
          return (Expression) Expression.LessThanOrEqual(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_MODULO:
          return (Expression) Expression.Modulo(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_MULTIPLY:
          return (Expression) Expression.Multiply(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED:
          return (Expression) Expression.MultiplyChecked(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_NOTEQUAL:
          return (Expression) Expression.NotEqual(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_OR:
          return (Expression) Expression.Or(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_ORELSE:
          return (Expression) Expression.OrElse(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT:
          return (Expression) Expression.RightShift(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_SUBTRACT:
          return (Expression) Expression.Subtract(expression1, expression2);
        case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED:
          return (Expression) Expression.SubtractChecked(expression1, expression2);
        default:
          throw Error.InternalCompilerError();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateUserDefinedBinaryOperator(ExprCall pExpr)
    {
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      Expression expression1 = this.GetExpression(optionalArguments.OptionalElement);
      Expression expression2 = this.GetExpression(((ExprList) optionalArguments.OptionalNextListNode).OptionalElement);
      ExprList optionalNextListNode1 = (ExprList) optionalArguments.OptionalNextListNode;
      bool liftToNull = false;
      MethodInfo methodInfo;
      if (optionalNextListNode1.OptionalNextListNode is ExprList optionalNextListNode2)
      {
        liftToNull = ((ExprConstant) optionalNextListNode2.OptionalElement).Val.Int32Val == 1;
        methodInfo = ((ExprMethodInfo) optionalNextListNode2.OptionalNextListNode).MethodInfo;
      }
      else
        methodInfo = ((ExprMethodInfo) optionalNextListNode1.OptionalNextListNode).MethodInfo;
      switch (pExpr.PredefinedMethod)
      {
        case PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED:
          return (Expression) Expression.Add(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED:
          return (Expression) Expression.AddChecked(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED:
          return (Expression) Expression.And(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED:
          return (Expression) Expression.AndAlso(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED:
          return (Expression) Expression.Divide(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED:
          return (Expression) Expression.Equal(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED:
          return (Expression) Expression.ExclusiveOr(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED:
          return (Expression) Expression.GreaterThan(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED:
          return (Expression) Expression.GreaterThanOrEqual(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED:
          return (Expression) Expression.LeftShift(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED:
          return (Expression) Expression.LessThan(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED:
          return (Expression) Expression.LessThanOrEqual(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED:
          return (Expression) Expression.Modulo(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED:
          return (Expression) Expression.Multiply(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED:
          return (Expression) Expression.MultiplyChecked(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED:
          return (Expression) Expression.NotEqual(expression1, expression2, liftToNull, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED:
          return (Expression) Expression.Or(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED:
          return (Expression) Expression.OrElse(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED:
          return (Expression) Expression.RightShift(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED:
          return (Expression) Expression.Subtract(expression1, expression2, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED:
          return (Expression) Expression.SubtractChecked(expression1, expression2, methodInfo);
        default:
          throw Error.InternalCompilerError();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateUnaryOperator(ExprCall pExpr)
    {
      PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
      Expression expression = this.GetExpression(pExpr.OptionalArguments);
      if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_NEGATE)
        return (Expression) Expression.Negate(expression);
      if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_NEGATECHECKED)
        return (Expression) Expression.NegateChecked(expression);
      if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_NOT)
        return (Expression) Expression.Not(expression);
      throw Error.InternalCompilerError();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GenerateUserDefinedUnaryOperator(ExprCall pExpr)
    {
      PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
      ExprList optionalArguments = (ExprList) pExpr.OptionalArguments;
      Expression expression = this.GetExpression(optionalArguments.OptionalElement);
      MethodInfo methodInfo = ((ExprMethodInfo) optionalArguments.OptionalNextListNode).MethodInfo;
      switch (predefinedMethod)
      {
        case PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED:
          return (Expression) Expression.UnaryPlus(expression, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED:
          return (Expression) Expression.Negate(expression, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED:
          return (Expression) Expression.NegateChecked(expression, methodInfo);
        case PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED:
          return (Expression) Expression.Not(expression, methodInfo);
        default:
          throw Error.InternalCompilerError();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression GetExpression(Expr pExpr)
    {
      switch (pExpr)
      {
        case ExprWrap exprWrap:
          return this._DictionaryOfParameters[(ExprCall) exprWrap.OptionalExpression];
        case ExprConstant _:
          return (Expression) null;
        default:
          ExprCall pExpr1 = (ExprCall) pExpr;
          switch (pExpr1.PredefinedMethod)
          {
            case PREDEFMETH.PM_EXPRESSION_ADD:
            case PREDEFMETH.PM_EXPRESSION_ADDCHECKED:
            case PREDEFMETH.PM_EXPRESSION_AND:
            case PREDEFMETH.PM_EXPRESSION_ANDALSO:
            case PREDEFMETH.PM_EXPRESSION_DIVIDE:
            case PREDEFMETH.PM_EXPRESSION_EQUAL:
            case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR:
            case PREDEFMETH.PM_EXPRESSION_GREATERTHAN:
            case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL:
            case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT:
            case PREDEFMETH.PM_EXPRESSION_LESSTHAN:
            case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL:
            case PREDEFMETH.PM_EXPRESSION_MODULO:
            case PREDEFMETH.PM_EXPRESSION_MULTIPLY:
            case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED:
            case PREDEFMETH.PM_EXPRESSION_NOTEQUAL:
            case PREDEFMETH.PM_EXPRESSION_OR:
            case PREDEFMETH.PM_EXPRESSION_ORELSE:
            case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT:
            case PREDEFMETH.PM_EXPRESSION_SUBTRACT:
            case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED:
              return this.GenerateBinaryOperator(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED:
              return this.GenerateUserDefinedBinaryOperator(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX:
            case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2:
              return this.GenerateArrayIndex(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_ASSIGN:
              return this.GenerateAssignment(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE:
              return ExpressionTreeCallRewriter.GenerateConstantType(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_CONVERT:
            case PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED:
            case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED:
              return this.GenerateConvert(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_FIELD:
              return this.GenerateField(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED:
            case PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED:
              return this.GenerateUserDefinedUnaryOperator(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_NEGATE:
            case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED:
            case PREDEFMETH.PM_EXPRESSION_NOT:
              return this.GenerateUnaryOperator(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_CALL:
              return this.GenerateCall(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_NEW:
              return this.GenerateNew(pExpr1);
            case PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT:
              ExprList optionalArguments = (ExprList) pExpr1.OptionalArguments;
              return (Expression) Expression.NewArrayInit(((ExprTypeOf) optionalArguments.OptionalElement).SourceType.AssociatedSystemType, this.GetArgumentsFromArrayInit((ExprArrayInit) optionalArguments.OptionalNextListNode));
            case PREDEFMETH.PM_EXPRESSION_PROPERTY:
              return this.GenerateProperty(pExpr1);
            default:
              throw Error.InternalCompilerError();
          }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression[] GetArgumentsFromArrayInit(ExprArrayInit arrinit)
    {
      List<Expression> expressionList = new List<Expression>();
      if (arrinit != null)
      {
        Expr expr = arrinit.OptionalArguments;
        while (expr != null)
        {
          Expr pExpr;
          if (expr is ExprList exprList)
          {
            pExpr = exprList.OptionalElement;
            expr = exprList.OptionalNextListNode;
          }
          else
          {
            pExpr = expr;
            expr = (Expr) null;
          }
          expressionList.Add(this.GetExpression(pExpr));
        }
      }
      return expressionList.ToArray();
    }

    private sealed class ExpressionExpr : Expr
    {
      public readonly Expression Expression;

      public ExpressionExpr(Expression e)
        : base(ExpressionKind.NoOp)
      {
        this.Expression = e;
      }
    }
  }
}
