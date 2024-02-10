// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExpressionTreeRewriter
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExpressionTreeRewriter : ExprVisitorBase
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprBinOp Rewrite(ExprBoundLambda expr)
    {
      return new ExpressionTreeRewriter().VisitBoundLambda(expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr Dispatch(Expr expr)
    {
      Expr expr1 = base.Dispatch(expr);
      return expr1 != expr ? expr1 : throw Error.InternalCompilerError();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitASSIGNMENT(ExprAssignment assignment)
    {
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_ASSIGN, !(assignment.LHS is ExprProperty lhs) ? this.Visit(assignment.LHS) : (lhs.OptionalArguments != null ? (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, this.Visit(lhs.MemberGroup.OptionalObject), (Expr) ExprFactory.CreatePropertyInfo(lhs.PropWithTypeSlot.Prop(), lhs.PropWithTypeSlot.Ats), (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(lhs.OptionalArguments), PredefinedType.PT_EXPRESSION)) : this.Visit((Expr) lhs)), this.Visit(assignment.RHS));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitMULTIGET(ExprMultiGet pExpr)
    {
      return this.Visit(pExpr.OptionalMulti.Left);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitMULTI(ExprMulti pExpr)
    {
      Expr expr = this.Visit(pExpr.Operator);
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_ASSIGN, this.Visit(pExpr.Left), expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprBinOp VisitBoundLambda(ExprBoundLambda anonmeth)
    {
      MethodSymbol preDefMethod = ExpressionTreeRewriter.GetPreDefMethod(PREDEFMETH.PM_EXPRESSION_LAMBDA);
      TypeArray typeArgs = TypeArray.Allocate((CType) anonmeth.DelegateType);
      AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
      MethWithInst method = new MethWithInst(preDefMethod, predefindType, typeArgs);
      Expr wraps = ExpressionTreeRewriter.CreateWraps(anonmeth);
      Expr list = (Expr) ExprFactory.CreateList(this.Visit(anonmeth.Expression), (Expr) ExpressionTreeRewriter.GenerateParamsArray((Expr) null, PredefinedType.PT_PARAMETEREXPRESSION));
      CType type = TypeManager.SubstType(method.Meth().RetType, method.GetType(), method.TypeArgs);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, type, list, memGroup, method);
      call.PredefinedMethod = PREDEFMETH.PM_EXPRESSION_LAMBDA;
      return ExprFactory.CreateSequence(wraps, (Expr) call);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitCONSTANT(ExprConstant expr)
    {
      return ExpressionTreeRewriter.GenerateConstant((Expr) expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitLOCAL(ExprLocal local) => (Expr) local.Local.wrap;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitFIELD(ExprField expr)
    {
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_FIELD, expr.OptionalObject != null ? this.Visit(expr.OptionalObject) : (Expr) ExprFactory.CreateNull(), (Expr) ExprFactory.CreateFieldInfo(expr.FieldWithType.Field(), expr.FieldWithType.GetType()));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitUSERDEFINEDCONVERSION(ExprUserDefinedConversion expr)
    {
      return this.GenerateUserDefinedConversion(expr, expr.Argument);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitCAST(ExprCast pExpr)
    {
      Expr pExpr1 = pExpr.Argument;
      if (pExpr1.Type == pExpr.Type || SymbolLoader.IsBaseClassOfClass(pExpr1.Type, pExpr.Type) || CConversions.FImpRefConv(pExpr1.Type, pExpr.Type))
        return this.Visit(pExpr1);
      if (pExpr.Type != null && pExpr.Type.IsPredefType(PredefinedType.PT_G_EXPRESSION) && pExpr1 is ExprBoundLambda)
        return this.Visit(pExpr1);
      Expr conversion = this.GenerateConversion(pExpr1, pExpr.Type, pExpr.isChecked());
      if ((pExpr.Flags & EXPRFLAG.EXF_USERCALLABLE) != (EXPRFLAG) 0)
        conversion.Flags |= EXPRFLAG.EXF_USERCALLABLE;
      return conversion;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitCONCAT(ExprConcat expr)
    {
      PREDEFMETH pdm = !expr.FirstArgument.Type.IsPredefType(PredefinedType.PT_STRING) || !expr.SecondArgument.Type.IsPredefType(PredefinedType.PT_STRING) ? PREDEFMETH.PM_STRING_CONCAT_OBJECT_2 : PREDEFMETH.PM_STRING_CONCAT_STRING_2;
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED, this.Visit(expr.FirstArgument), this.Visit(expr.SecondArgument), (Expr) ExprFactory.CreateMethodInfo(ExpressionTreeRewriter.GetPreDefMethod(pdm), SymbolLoader.GetPredefindType(PredefinedType.PT_STRING), (TypeArray) null));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitBINOP(ExprBinOp expr)
    {
      return (SymWithType) expr.UserDefinedCallMethod != (SymWithType) null ? this.GenerateUserDefinedBinaryOperator(expr) : this.GenerateBuiltInBinaryOperator(expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitUNARYOP(ExprUnaryOp pExpr)
    {
      return (SymWithType) pExpr.UserDefinedCallMethod != (SymWithType) null ? this.GenerateUserDefinedUnaryOperator(pExpr) : this.GenerateBuiltInUnaryOperator(pExpr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitARRAYINDEX(ExprArrayIndex pExpr)
    {
      Expr expr = this.Visit(pExpr.Array);
      Expr indexList = this.GenerateIndexList(pExpr.Index);
      if (!(indexList is ExprList))
        return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX, expr, indexList);
      Expr paramsArray = (Expr) ExpressionTreeRewriter.GenerateParamsArray(indexList, PredefinedType.PT_EXPRESSION);
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2, expr, paramsArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitCALL(ExprCall expr)
    {
      switch (expr.NullableCallLiftKind)
      {
        case NullableCallLiftKind.UserDefinedConversion:
        case NullableCallLiftKind.NotLiftedIntermediateConversion:
          return this.GenerateUserDefinedConversion(expr.OptionalArguments, expr.Type, expr.MethWithInst);
        case NullableCallLiftKind.NullableConversion:
        case NullableCallLiftKind.NullableConversionConstructor:
        case NullableCallLiftKind.NullableIntermediateConversion:
          return this.GenerateConversion(expr.OptionalArguments, expr.Type, expr.isChecked());
        default:
          if (expr.MethWithInst.Meth().IsConstructor())
            return this.GenerateConstructor(expr);
          if (expr.MemberGroup.IsDelegate)
            return this.GenerateDelegateInvoke(expr);
          Expr expr1;
          if (expr.MethWithInst.Meth().isStatic || expr.MemberGroup.OptionalObject == null)
          {
            expr1 = (Expr) ExprFactory.CreateNull();
          }
          else
          {
            Expr optionalObject = expr.MemberGroup.OptionalObject;
            if (optionalObject != null && optionalObject is ExprCast exprCast && exprCast.IsBoxingCast)
              optionalObject = exprCast.Argument;
            expr1 = this.Visit(optionalObject);
          }
          Expr methodInfo = (Expr) ExprFactory.CreateMethodInfo((MethPropWithInst) expr.MethWithInst);
          Expr paramsArray = (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
          return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CALL, expr1, methodInfo, paramsArray);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitPROP(ExprProperty expr)
    {
      Expr expr1 = expr.PropWithTypeSlot.Prop().isStatic || expr.MemberGroup.OptionalObject == null ? (Expr) ExprFactory.CreateNull() : this.Visit(expr.MemberGroup.OptionalObject);
      Expr propertyInfo = (Expr) ExprFactory.CreatePropertyInfo(expr.PropWithTypeSlot.Prop(), expr.PropWithTypeSlot.GetType());
      if (expr.OptionalArguments == null)
        return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, expr1, propertyInfo);
      Expr paramsArray = (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, expr1, propertyInfo, paramsArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitARRINIT(ExprArrayInit expr)
    {
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT, (Expr) ExpressionTreeRewriter.CreateTypeOf(((ArrayType) expr.Type).ElementType), (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitZEROINIT(ExprZeroInit expr)
    {
      return ExpressionTreeRewriter.GenerateConstant((Expr) expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected override Expr VisitTYPEOF(ExprTypeOf expr)
    {
      return ExpressionTreeRewriter.GenerateConstant((Expr) expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateDelegateInvoke(ExprCall expr)
    {
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_INVOKE, this.Visit(expr.MemberGroup.OptionalObject), (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateBuiltInBinaryOperator(ExprBinOp expr)
    {
      PREDEFMETH predefmeth;
      switch (expr.Kind)
      {
        case ExpressionKind.Eq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EQUAL;
          break;
        case ExpressionKind.NotEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_NOTEQUAL;
          break;
        case ExpressionKind.LessThan:
          predefmeth = PREDEFMETH.PM_EXPRESSION_LESSTHAN;
          break;
        case ExpressionKind.LessThanOrEqual:
          predefmeth = PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL;
          break;
        case ExpressionKind.GreaterThan:
          predefmeth = PREDEFMETH.PM_EXPRESSION_GREATERTHAN;
          break;
        case ExpressionKind.GreaterThanOrEqual:
          predefmeth = PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL;
          break;
        case ExpressionKind.Add:
          predefmeth = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_ADDCHECKED : PREDEFMETH.PM_EXPRESSION_ADD;
          break;
        case ExpressionKind.Subtract:
          predefmeth = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED : PREDEFMETH.PM_EXPRESSION_SUBTRACT;
          break;
        case ExpressionKind.Multiply:
          predefmeth = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED : PREDEFMETH.PM_EXPRESSION_MULTIPLY;
          break;
        case ExpressionKind.Divide:
          predefmeth = PREDEFMETH.PM_EXPRESSION_DIVIDE;
          break;
        case ExpressionKind.Modulo:
          predefmeth = PREDEFMETH.PM_EXPRESSION_MODULO;
          break;
        case ExpressionKind.BitwiseAnd:
          predefmeth = PREDEFMETH.PM_EXPRESSION_AND;
          break;
        case ExpressionKind.BitwiseOr:
          predefmeth = PREDEFMETH.PM_EXPRESSION_OR;
          break;
        case ExpressionKind.BitwiseExclusiveOr:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR;
          break;
        case ExpressionKind.LeftShirt:
          predefmeth = PREDEFMETH.PM_EXPRESSION_LEFTSHIFT;
          break;
        case ExpressionKind.RightShift:
          predefmeth = PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT;
          break;
        case ExpressionKind.LogicalAnd:
          predefmeth = PREDEFMETH.PM_EXPRESSION_ANDALSO;
          break;
        case ExpressionKind.LogicalOr:
          predefmeth = PREDEFMETH.PM_EXPRESSION_ORELSE;
          break;
        case ExpressionKind.StringEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EQUAL;
          break;
        case ExpressionKind.StringNotEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_NOTEQUAL;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      PREDEFMETH pdm = predefmeth;
      Expr optionalLeftChild = expr.OptionalLeftChild;
      Expr optionalRightChild = expr.OptionalRightChild;
      CType ctype1 = optionalLeftChild.Type;
      CType ctype2 = optionalRightChild.Type;
      Expr expr1 = this.Visit(optionalLeftChild);
      Expr expr2 = this.Visit(optionalRightChild);
      bool flag = false;
      CType type1 = (CType) null;
      CType type2 = (CType) null;
      if (ctype1.IsEnumType)
      {
        type1 = (CType) TypeManager.GetNullable((CType) ctype1.UnderlyingEnumType);
        ctype1 = type1;
        flag = true;
      }
      else if (ctype1 is NullableType nullableType1 && nullableType1.UnderlyingType.IsEnumType)
      {
        type1 = (CType) TypeManager.GetNullable((CType) nullableType1.UnderlyingType.UnderlyingEnumType);
        ctype1 = type1;
        flag = true;
      }
      if (ctype2.IsEnumType)
      {
        type2 = (CType) TypeManager.GetNullable((CType) ctype2.UnderlyingEnumType);
        ctype2 = type2;
        flag = true;
      }
      else if (ctype2 is NullableType nullableType2 && nullableType2.UnderlyingType.IsEnumType)
      {
        type2 = (CType) TypeManager.GetNullable((CType) nullableType2.UnderlyingType.UnderlyingEnumType);
        ctype2 = type2;
        flag = true;
      }
      if (ctype1 is NullableType nullableType3 && nullableType3.UnderlyingType == ctype2)
        type2 = ctype1;
      if (ctype2 is NullableType nullableType4 && nullableType4.UnderlyingType == ctype1)
        type1 = ctype2;
      if (type1 != null)
        expr1 = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr1, (Expr) ExpressionTreeRewriter.CreateTypeOf(type1));
      if (type2 != null)
        expr2 = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr2, (Expr) ExpressionTreeRewriter.CreateTypeOf(type2));
      Expr call = (Expr) ExpressionTreeRewriter.GenerateCall(pdm, expr1, expr2);
      if (flag && expr.Type.StripNubs().IsEnumType)
        call = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, call, (Expr) ExpressionTreeRewriter.CreateTypeOf(expr.Type));
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateBuiltInUnaryOperator(ExprUnaryOp expr)
    {
      PREDEFMETH pdm;
      switch (expr.Kind)
      {
        case ExpressionKind.LogicalNot:
          pdm = PREDEFMETH.PM_EXPRESSION_NOT;
          break;
        case ExpressionKind.Negate:
          pdm = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_NEGATECHECKED : PREDEFMETH.PM_EXPRESSION_NEGATE;
          break;
        case ExpressionKind.UnaryPlus:
          return this.Visit(expr.Child);
        case ExpressionKind.BitwiseNot:
          pdm = PREDEFMETH.PM_EXPRESSION_NOT;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      Expr child = expr.Child;
      return (Expr) ExpressionTreeRewriter.GenerateCall(pdm, this.Visit(child));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateUserDefinedBinaryOperator(ExprBinOp expr)
    {
      PREDEFMETH pdm;
      switch (expr.Kind)
      {
        case ExpressionKind.Eq:
        case ExpressionKind.NotEq:
        case ExpressionKind.LessThan:
        case ExpressionKind.LessThanOrEqual:
        case ExpressionKind.GreaterThan:
        case ExpressionKind.GreaterThanOrEqual:
        case ExpressionKind.StringEq:
        case ExpressionKind.StringNotEq:
        case ExpressionKind.DelegateEq:
        case ExpressionKind.DelegateNotEq:
          return this.GenerateUserDefinedComparisonOperator(expr);
        case ExpressionKind.Add:
        case ExpressionKind.DelegateAdd:
          pdm = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED;
          break;
        case ExpressionKind.Subtract:
        case ExpressionKind.DelegateSubtract:
          pdm = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED;
          break;
        case ExpressionKind.Multiply:
          pdm = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED;
          break;
        case ExpressionKind.Divide:
          pdm = PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED;
          break;
        case ExpressionKind.Modulo:
          pdm = PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED;
          break;
        case ExpressionKind.BitwiseAnd:
          pdm = PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED;
          break;
        case ExpressionKind.BitwiseOr:
          pdm = PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED;
          break;
        case ExpressionKind.BitwiseExclusiveOr:
          pdm = PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED;
          break;
        case ExpressionKind.LeftShirt:
          pdm = PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED;
          break;
        case ExpressionKind.RightShift:
          pdm = PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED;
          break;
        case ExpressionKind.LogicalAnd:
          pdm = PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED;
          break;
        case ExpressionKind.LogicalOr:
          pdm = PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      Expr pExpr1 = expr.OptionalLeftChild;
      Expr pExpr2 = expr.OptionalRightChild;
      Expr optionalUserDefinedCall = expr.OptionalUserDefinedCall;
      if (optionalUserDefinedCall != null)
      {
        if (optionalUserDefinedCall is ExprCall exprCall)
        {
          ExprList optionalArguments = (ExprList) exprCall.OptionalArguments;
          pExpr1 = optionalArguments.OptionalElement;
          pExpr2 = optionalArguments.OptionalNextListNode;
        }
        else
        {
          ExprList optionalArguments = (ExprList) (optionalUserDefinedCall as ExprUserLogicalOp).OperatorCall.OptionalArguments;
          pExpr1 = ((ExprWrap) optionalArguments.OptionalElement).OptionalExpression;
          pExpr2 = optionalArguments.OptionalNextListNode;
        }
      }
      Expr pp1 = this.Visit(pExpr1);
      Expr pp2 = this.Visit(pExpr2);
      ExpressionTreeRewriter.FixLiftedUserDefinedBinaryOperators(expr, ref pp1, ref pp2);
      Expr methodInfo = (Expr) ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
      Expr call = (Expr) ExpressionTreeRewriter.GenerateCall(pdm, pp1, pp2, methodInfo);
      if (expr.Kind != ExpressionKind.DelegateSubtract && expr.Kind != ExpressionKind.DelegateAdd)
        return call;
      Expr expr1 = (Expr) ExpressionTreeRewriter.CreateTypeOf(expr.Type);
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, call, expr1);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateUserDefinedUnaryOperator(ExprUnaryOp expr)
    {
      Expr pExpr = expr.Child;
      ExprCall optionalUserDefinedCall = (ExprCall) expr.OptionalUserDefinedCall;
      if (optionalUserDefinedCall != null)
        pExpr = optionalUserDefinedCall.OptionalArguments;
      PREDEFMETH pdm;
      switch (expr.Kind)
      {
        case ExpressionKind.True:
        case ExpressionKind.False:
          return this.Visit((Expr) optionalUserDefinedCall);
        case ExpressionKind.Inc:
        case ExpressionKind.Dec:
        case ExpressionKind.DecimalInc:
        case ExpressionKind.DecimalDec:
          pdm = PREDEFMETH.PM_EXPRESSION_CALL;
          break;
        case ExpressionKind.LogicalNot:
          pdm = PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED;
          break;
        case ExpressionKind.Negate:
        case ExpressionKind.DecimalNegate:
          pdm = expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED;
          break;
        case ExpressionKind.UnaryPlus:
          pdm = PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED;
          break;
        case ExpressionKind.BitwiseNot:
          pdm = PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      Expr args = this.Visit(pExpr);
      Expr methodInfo = (Expr) ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
      return expr.Kind == ExpressionKind.Inc || expr.Kind == ExpressionKind.Dec || expr.Kind == ExpressionKind.DecimalInc || expr.Kind == ExpressionKind.DecimalDec ? (Expr) ExpressionTreeRewriter.GenerateCall(pdm, (Expr) null, methodInfo, (Expr) ExpressionTreeRewriter.GenerateParamsArray(args, PredefinedType.PT_EXPRESSION)) : (Expr) ExpressionTreeRewriter.GenerateCall(pdm, args, methodInfo);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateUserDefinedComparisonOperator(ExprBinOp expr)
    {
      PREDEFMETH predefmeth;
      switch (expr.Kind)
      {
        case ExpressionKind.Eq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED;
          break;
        case ExpressionKind.NotEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED;
          break;
        case ExpressionKind.LessThan:
          predefmeth = PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED;
          break;
        case ExpressionKind.LessThanOrEqual:
          predefmeth = PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED;
          break;
        case ExpressionKind.GreaterThan:
          predefmeth = PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED;
          break;
        case ExpressionKind.GreaterThanOrEqual:
          predefmeth = PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED;
          break;
        case ExpressionKind.StringEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED;
          break;
        case ExpressionKind.StringNotEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED;
          break;
        case ExpressionKind.DelegateEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED;
          break;
        case ExpressionKind.DelegateNotEq:
          predefmeth = PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED;
          break;
        default:
          throw Error.InternalCompilerError();
      }
      PREDEFMETH pdm = predefmeth;
      Expr pExpr1 = expr.OptionalLeftChild;
      Expr pExpr2 = expr.OptionalRightChild;
      if (expr.OptionalUserDefinedCall != null)
      {
        ExprList optionalArguments = (ExprList) ((ExprWithArgs) expr.OptionalUserDefinedCall).OptionalArguments;
        pExpr1 = optionalArguments.OptionalElement;
        pExpr2 = optionalArguments.OptionalNextListNode;
      }
      Expr pp1 = this.Visit(pExpr1);
      Expr pp2 = this.Visit(pExpr2);
      ExpressionTreeRewriter.FixLiftedUserDefinedBinaryOperators(expr, ref pp1, ref pp2);
      Expr boolConstant = (Expr) ExprFactory.CreateBoolConstant(false);
      Expr methodInfo = (Expr) ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
      return (Expr) ExpressionTreeRewriter.GenerateCall(pdm, pp1, pp2, boolConstant, methodInfo);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateConversion(Expr arg, CType CType, bool bChecked)
    {
      return ExpressionTreeRewriter.GenerateConversionWithSource(this.Visit(arg), CType, bChecked || arg.isChecked());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr GenerateConversionWithSource(Expr pTarget, CType pType, bool bChecked)
    {
      PREDEFMETH pdm = bChecked ? PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED : PREDEFMETH.PM_EXPRESSION_CONVERT;
      Expr expr = (Expr) ExpressionTreeRewriter.CreateTypeOf(pType);
      return (Expr) ExpressionTreeRewriter.GenerateCall(pdm, pTarget, expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateValueAccessConversion(Expr pArgument)
    {
      Expr expr = (Expr) ExpressionTreeRewriter.CreateTypeOf(pArgument.Type.StripNubs());
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, this.Visit(pArgument), expr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateUserDefinedConversion(Expr arg, CType type, MethWithInst method)
    {
      Expr target = this.Visit(arg);
      return ExpressionTreeRewriter.GenerateUserDefinedConversion(arg, type, target, method);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr GenerateUserDefinedConversion(
      Expr arg,
      CType CType,
      Expr target,
      MethWithInst method)
    {
      if (ExpressionTreeRewriter.isEnumToDecimalConversion(arg.Type, CType))
      {
        Expr expr = (Expr) ExpressionTreeRewriter.CreateTypeOf((CType) TypeManager.GetNullable((CType) arg.Type.StripNubs().UnderlyingEnumType));
        target = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, target, expr);
      }
      CType ctype = TypeManager.SubstType(method.Meth().RetType, method.GetType(), method.TypeArgs);
      bool flag = ctype == CType || ExpressionTreeRewriter.IsNullableValueType(arg.Type) && ExpressionTreeRewriter.IsNullableValueType(CType);
      Expr expr1 = (Expr) ExpressionTreeRewriter.CreateTypeOf(flag ? CType : ctype);
      Expr methodInfo = (Expr) ExprFactory.CreateMethodInfo((MethPropWithInst) method);
      Expr call = (Expr) ExpressionTreeRewriter.GenerateCall(arg.isChecked() ? PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED, target, expr1, methodInfo);
      if (flag)
        return call;
      PREDEFMETH pdm = arg.isChecked() ? PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED : PREDEFMETH.PM_EXPRESSION_CONVERT;
      Expr expr2 = (Expr) ExpressionTreeRewriter.CreateTypeOf(CType);
      return (Expr) ExpressionTreeRewriter.GenerateCall(pdm, call, expr2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateUserDefinedConversion(ExprUserDefinedConversion pExpr, Expr pArgument)
    {
      Expr userDefinedCall = pExpr.UserDefinedCall;
      Expr pExpr1 = pExpr.Argument;
      Expr target;
      if (!ExpressionTreeRewriter.isEnumToDecimalConversion(pArgument.Type, pExpr.Type) && ExpressionTreeRewriter.IsNullableValueAccess(pExpr1, pArgument))
      {
        target = this.GenerateValueAccessConversion(pArgument);
      }
      else
      {
        Expr pconversions = userDefinedCall is ExprCall expr ? expr.PConversions : (Expr) null;
        if (pconversions != null)
        {
          if (!(pconversions is ExprCall exprCall))
            return this.GenerateUserDefinedConversion((ExprUserDefinedConversion) pconversions, pArgument);
          Expr optionalArguments = exprCall.OptionalArguments;
          return ExpressionTreeRewriter.GenerateConversionWithSource(!ExpressionTreeRewriter.IsNullableValueAccess(optionalArguments, pArgument) ? this.Visit(optionalArguments) : this.GenerateValueAccessConversion(pArgument), userDefinedCall.Type, expr.isChecked());
        }
        target = this.Visit(pExpr1);
      }
      return ExpressionTreeRewriter.GenerateUserDefinedConversion(pExpr1, pExpr.Type, target, pExpr.UserDefinedCallMethod);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr GenerateParameter(string name, CType CType)
    {
      SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
      ExprConstant stringConstant = ExprFactory.CreateStringConstant(name);
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_PARAMETER, (Expr) ExpressionTreeRewriter.CreateTypeOf(CType), (Expr) stringConstant);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static MethodSymbol GetPreDefMethod(PREDEFMETH pdm) => PredefinedMembers.GetMethod(pdm);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprTypeOf CreateTypeOf(CType type) => ExprFactory.CreateTypeOf(type);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr CreateWraps(ExprBoundLambda anonmeth)
    {
      Expr first = (Expr) null;
      for (Symbol symbol = anonmeth.ArgumentScope.firstChild; symbol != null; symbol = symbol.nextChild)
      {
        if (symbol is LocalVariableSymbol localVariableSymbol)
        {
          Expr parameter = ExpressionTreeRewriter.GenerateParameter(localVariableSymbol.name.Text, localVariableSymbol.GetType());
          localVariableSymbol.wrap = ExprFactory.CreateWrap(parameter);
          Expr save = (Expr) ExprFactory.CreateSave(localVariableSymbol.wrap);
          first = first != null ? (Expr) ExprFactory.CreateSequence(first, save) : save;
        }
      }
      return first;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateConstructor(ExprCall expr)
    {
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_NEW, (Expr) ExprFactory.CreateMethodInfo((MethPropWithInst) expr.MethWithInst), (Expr) ExpressionTreeRewriter.GenerateParamsArray(this.GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateArgsList(Expr oldArgs)
    {
      Expr first = (Expr) null;
      Expr last = first;
      ExpressionIterator expressionIterator = new ExpressionIterator(oldArgs);
      while (!expressionIterator.AtEnd())
      {
        ExprFactory.AppendItemToList(this.Visit(expressionIterator.Current()), ref first, ref last);
        expressionIterator.MoveNext();
      }
      return first;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr GenerateIndexList(Expr oldIndices)
    {
      CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_INT);
      Expr first = (Expr) null;
      Expr last = first;
      ExpressionIterator expressionIterator = new ExpressionIterator(oldIndices);
      while (!expressionIterator.AtEnd())
      {
        Expr pExpr = expressionIterator.Current();
        if (pExpr.Type != predefindType)
        {
          pExpr = (Expr) ExprFactory.CreateCast(EXPRFLAG.EXF_LITERALCONST, predefindType, pExpr);
          pExpr.Flags |= EXPRFLAG.EXF_CHECKOVERFLOW;
        }
        ExprFactory.AppendItemToList(this.Visit(pExpr), ref first, ref last);
        expressionIterator.MoveNext();
      }
      return first;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expr GenerateConstant(Expr expr)
    {
      EXPRFLAG flags = (EXPRFLAG) 0;
      AggregateType predefindType1 = SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT);
      if (expr.Type is NullType)
      {
        ExprTypeOf exprTypeOf = ExpressionTreeRewriter.CreateTypeOf((CType) predefindType1);
        return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, expr, (Expr) exprTypeOf);
      }
      AggregateType predefindType2 = SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
      if (expr.Type != predefindType2)
        flags = EXPRFLAG.EXF_CTOR;
      return (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, (Expr) ExprFactory.CreateCast(flags, (CType) predefindType1, expr), (Expr) ExpressionTreeRewriter.CreateTypeOf(expr.Type));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1)
    {
      MethodSymbol preDefMethod = ExpressionTreeRewriter.GetPreDefMethod(pdm);
      if (preDefMethod == null)
        return (ExprCall) null;
      AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
      MethWithInst method = new MethWithInst(preDefMethod, predefindType);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, method.Meth().RetType, arg1, memGroup, method);
      call.PredefinedMethod = pdm;
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1, Expr arg2)
    {
      MethodSymbol preDefMethod = ExpressionTreeRewriter.GetPreDefMethod(pdm);
      if (preDefMethod == null)
        return (ExprCall) null;
      AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
      Expr list = (Expr) ExprFactory.CreateList(arg1, arg2);
      MethWithInst method = new MethWithInst(preDefMethod, predefindType);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, method.Meth().RetType, list, memGroup, method);
      call.PredefinedMethod = pdm;
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1, Expr arg2, Expr arg3)
    {
      MethodSymbol preDefMethod = ExpressionTreeRewriter.GetPreDefMethod(pdm);
      if (preDefMethod == null)
        return (ExprCall) null;
      AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
      Expr list = (Expr) ExprFactory.CreateList(arg1, arg2, arg3);
      MethWithInst method = new MethWithInst(preDefMethod, predefindType);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, method.Meth().RetType, list, memGroup, method);
      call.PredefinedMethod = pdm;
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprCall GenerateCall(
      PREDEFMETH pdm,
      Expr arg1,
      Expr arg2,
      Expr arg3,
      Expr arg4)
    {
      MethodSymbol preDefMethod = ExpressionTreeRewriter.GetPreDefMethod(pdm);
      if (preDefMethod == null)
        return (ExprCall) null;
      AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
      Expr list = (Expr) ExprFactory.CreateList(arg1, arg2, arg3, arg4);
      MethWithInst method = new MethWithInst(preDefMethod, predefindType);
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup((Expr) null, (MethPropWithInst) method);
      ExprCall call = ExprFactory.CreateCall((EXPRFLAG) 0, method.Meth().RetType, list, memGroup, method);
      call.PredefinedMethod = pdm;
      return call;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprArrayInit GenerateParamsArray(Expr args, PredefinedType pt)
    {
      int x = ExpressionIterator.Count(args);
      ArrayType array = TypeManager.GetArray((CType) SymbolLoader.GetPredefindType(pt), 1, true);
      ExprConstant integerConstant = ExprFactory.CreateIntegerConstant(x);
      return ExprFactory.CreateArrayInit((CType) array, args, (Expr) integerConstant, new int[1]
      {
        x
      });
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void FixLiftedUserDefinedBinaryOperators(
      ExprBinOp expr,
      ref Expr pp1,
      ref Expr pp2)
    {
      MethodSymbol methodSymbol = expr.UserDefinedCallMethod.Meth();
      Expr optionalLeftChild = expr.OptionalLeftChild;
      Expr optionalRightChild = expr.OptionalRightChild;
      Expr expr1 = pp1;
      Expr expr2 = pp2;
      CType pUnderlyingType1 = methodSymbol.Params[0];
      CType pUnderlyingType2 = methodSymbol.Params[1];
      CType type1 = optionalLeftChild.Type;
      CType type2 = optionalRightChild.Type;
      if (!(pUnderlyingType1 is AggregateType aggregateType1) || !aggregateType1.OwningAggregate.IsValueType() || !(pUnderlyingType2 is AggregateType aggregateType2) || !aggregateType2.OwningAggregate.IsValueType())
        return;
      CType nullable1 = (CType) TypeManager.GetNullable(pUnderlyingType1);
      CType nullable2 = (CType) TypeManager.GetNullable(pUnderlyingType2);
      if (type1 is NullType || type1 == pUnderlyingType1 && (type2 == nullable2 || type2 is NullType))
        expr1 = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr1, (Expr) ExpressionTreeRewriter.CreateTypeOf(nullable1));
      if (type2 is NullType || type2 == pUnderlyingType2 && (type1 == nullable1 || type1 is NullType))
        expr2 = (Expr) ExpressionTreeRewriter.GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr2, (Expr) ExpressionTreeRewriter.CreateTypeOf(nullable2));
      pp1 = expr1;
      pp2 = expr2;
    }

    private static bool IsNullableValueType(CType pType)
    {
      return pType is NullableType && pType.StripNubs() is AggregateType aggregateType && aggregateType.OwningAggregate.IsValueType();
    }

    private static bool IsNullableValueAccess(Expr pExpr, Expr pObject)
    {
      return pExpr is ExprProperty exprProperty && exprProperty.MemberGroup.OptionalObject == pObject && pObject.Type is NullableType;
    }

    private static bool isEnumToDecimalConversion(CType argtype, CType desttype)
    {
      return argtype.StripNubs().IsEnumType && desttype.StripNubs().IsPredefType(PredefinedType.PT_DECIMAL);
    }
  }
}
