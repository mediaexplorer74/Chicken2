// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprFactory
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class ExprFactory
  {
    public static ExprCall CreateCall(
      EXPRFLAG flags,
      CType type,
      Expr arguments,
      ExprMemberGroup memberGroup,
      MethWithInst method)
    {
      return new ExprCall(type, flags, arguments, memberGroup, method);
    }

    public static ExprField CreateField(CType type, Expr optionalObject, FieldWithType field)
    {
      return new ExprField(type, optionalObject, field);
    }

    public static ExprArrayInit CreateArrayInit(
      CType type,
      Expr arguments,
      Expr argumentDimensions,
      int[] dimSizes)
    {
      return new ExprArrayInit(type, arguments, argumentDimensions, dimSizes);
    }

    public static ExprProperty CreateProperty(
      CType type,
      Expr optionalObjectThrough,
      Expr arguments,
      ExprMemberGroup memberGroup,
      PropWithType property,
      MethWithType setMethod)
    {
      return new ExprProperty(type, optionalObjectThrough, arguments, memberGroup, property, setMethod);
    }

    public static ExprMemberGroup CreateMemGroup(
      EXPRFLAG flags,
      Name name,
      TypeArray typeArgs,
      SYMKIND symKind,
      CType parentType,
      Expr obj,
      CMemberLookupResults memberLookupResults)
    {
      return new ExprMemberGroup(flags, name, typeArgs, symKind, parentType, obj, memberLookupResults);
    }

    public static ExprMemberGroup CreateMemGroup(Expr obj, MethPropWithInst method)
    {
      Name name1 = method.Sym?.name;
      Name name2 = name1;
      TypeArray typeArgs = method.TypeArgs;
      MethodOrPropertySymbol orPropertySymbol = method.MethProp();
      int num = orPropertySymbol != null ? (int) orPropertySymbol.getKind() : 5;
      AggregateType type = method.GetType();
      Expr expr = obj;
      CMemberLookupResults memberLookupResults = new CMemberLookupResults(TypeArray.Allocate((CType) method.GetType()), name1);
      return ExprFactory.CreateMemGroup((EXPRFLAG) 0, name2, typeArgs, (SYMKIND) num, (CType) type, expr, memberLookupResults);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprUserDefinedConversion CreateUserDefinedConversion(
      Expr arg,
      Expr call,
      MethWithInst method)
    {
      return new ExprUserDefinedConversion(arg, call, method);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprCast CreateCast(CType type, Expr argument)
    {
      return ExprFactory.CreateCast((EXPRFLAG) 0, type, argument);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprCast CreateCast(EXPRFLAG flags, CType type, Expr argument)
    {
      return new ExprCast(flags, type, argument);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprLocal CreateLocal(LocalVariableSymbol local) => new ExprLocal(local);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprBoundLambda CreateAnonymousMethod(
      AggregateType delegateType,
      Scope argumentScope,
      Expr expression)
    {
      return new ExprBoundLambda(delegateType, argumentScope, expression);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprMethodInfo CreateMethodInfo(MethPropWithInst mwi)
    {
      return ExprFactory.CreateMethodInfo(mwi.Meth(), mwi.GetType(), mwi.TypeArgs);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprMethodInfo CreateMethodInfo(
      MethodSymbol method,
      AggregateType methodType,
      TypeArray methodParameters)
    {
      return new ExprMethodInfo((CType) TypeManager.GetPredefAgg(method.IsConstructor() ? PredefinedType.PT_CONSTRUCTORINFO : PredefinedType.PT_METHODINFO).getThisType(), method, methodType, methodParameters);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprPropertyInfo CreatePropertyInfo(
      PropertySymbol prop,
      AggregateType propertyType)
    {
      return new ExprPropertyInfo((CType) TypeManager.GetPredefAgg(PredefinedType.PT_PROPERTYINFO).getThisType(), prop, propertyType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprFieldInfo CreateFieldInfo(FieldSymbol field, AggregateType fieldType)
    {
      return new ExprFieldInfo(field, fieldType, (CType) TypeManager.GetPredefAgg(PredefinedType.PT_FIELDINFO).getThisType());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprTypeOf CreateTypeOf(CType sourceType)
    {
      return new ExprTypeOf((CType) TypeManager.GetPredefAgg(PredefinedType.PT_TYPE).getThisType(), sourceType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprUserLogicalOp CreateUserLogOp(
      CType type,
      Expr trueFalseCall,
      ExprCall operatorCall)
    {
      return new ExprUserLogicalOp(type, trueFalseCall, operatorCall);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprConcat CreateConcat(Expr first, Expr second) => new ExprConcat(first, second);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprConstant CreateStringConstant(string str)
    {
      return ExprFactory.CreateConstant((CType) TypeManager.GetPredefAgg(PredefinedType.PT_STRING).getThisType(), ConstVal.Get(str));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprMultiGet CreateMultiGet(EXPRFLAG flags, CType type, ExprMulti multi)
    {
      return new ExprMultiGet(type, flags, multi);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprMulti CreateMulti(EXPRFLAG flags, CType type, Expr left, Expr op)
    {
      return new ExprMulti(type, flags, left, op);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static Expr CreateZeroInit(CType type)
    {
      if (type.IsEnumType)
        return (Expr) ExprFactory.CreateConstant(type, ConstVal.Get(Activator.CreateInstance(type.AssociatedSystemType)));
      switch (type.FundamentalType)
      {
        case FUNDTYPE.FT_STRUCT:
          if (type.IsPredefType(PredefinedType.PT_DECIMAL))
            break;
          goto case FUNDTYPE.FT_VAR;
        case FUNDTYPE.FT_PTR:
          return (Expr) ExprFactory.CreateCast((EXPRFLAG) 0, type, (Expr) ExprFactory.CreateNull());
        case FUNDTYPE.FT_VAR:
          return (Expr) new ExprZeroInit(type);
      }
      return (Expr) ExprFactory.CreateConstant(type, ConstVal.GetDefaultValue(type.ConstValKind));
    }

    public static ExprConstant CreateConstant(CType type, ConstVal constVal)
    {
      return new ExprConstant(type, constVal);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprConstant CreateIntegerConstant(int x)
    {
      return ExprFactory.CreateConstant((CType) TypeManager.GetPredefAgg(PredefinedType.PT_INT).getThisType(), ConstVal.Get(x));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ExprConstant CreateBoolConstant(bool b)
    {
      return ExprFactory.CreateConstant((CType) TypeManager.GetPredefAgg(PredefinedType.PT_BOOL).getThisType(), ConstVal.Get(b));
    }

    public static ExprArrayIndex CreateArrayIndex(CType type, Expr array, Expr index)
    {
      return new ExprArrayIndex(type, array, index);
    }

    public static ExprBinOp CreateBinop(
      ExpressionKind exprKind,
      CType type,
      Expr left,
      Expr right)
    {
      return new ExprBinOp(exprKind, type, left, right);
    }

    public static ExprUnaryOp CreateUnaryOp(ExpressionKind exprKind, CType type, Expr operand)
    {
      return new ExprUnaryOp(exprKind, type, operand);
    }

    public static ExprOperator CreateOperator(
      ExpressionKind exprKind,
      CType type,
      Expr arg1,
      Expr arg2)
    {
      return !exprKind.IsUnaryOperator() ? (ExprOperator) ExprFactory.CreateBinop(exprKind, type, arg1, arg2) : (ExprOperator) ExprFactory.CreateUnaryOp(exprKind, type, arg1);
    }

    public static ExprBinOp CreateUserDefinedBinop(
      ExpressionKind exprKind,
      CType type,
      Expr left,
      Expr right,
      Expr call,
      MethPropWithInst userMethod)
    {
      return new ExprBinOp(exprKind, type, left, right, call, userMethod);
    }

    public static ExprUnaryOp CreateUserDefinedUnaryOperator(
      ExpressionKind exprKind,
      CType type,
      Expr operand,
      ExprCall call,
      MethPropWithInst userMethod)
    {
      return new ExprUnaryOp(exprKind, type, operand, (Expr) call, userMethod);
    }

    public static ExprUnaryOp CreateNeg(EXPRFLAG flags, Expr operand)
    {
      ExprUnaryOp unaryOp = ExprFactory.CreateUnaryOp(ExpressionKind.Negate, operand.Type, operand);
      unaryOp.Flags |= flags;
      return unaryOp;
    }

    public static ExprBinOp CreateSequence(Expr first, Expr second)
    {
      return ExprFactory.CreateBinop(ExpressionKind.Sequence, second.Type, first, second);
    }

    public static ExprAssignment CreateAssignment(Expr left, Expr right)
    {
      return new ExprAssignment(left, right);
    }

    public static ExprNamedArgumentSpecification CreateNamedArgumentSpecification(
      Name name,
      Expr value)
    {
      return new ExprNamedArgumentSpecification(name, value);
    }

    public static ExprWrap CreateWrap(Expr expression) => new ExprWrap(expression);

    public static ExprBinOp CreateSave(ExprWrap wrap)
    {
      ExprBinOp binop = ExprFactory.CreateBinop(ExpressionKind.Save, wrap.Type, wrap.OptionalExpression, (Expr) wrap);
      binop.SetAssignment();
      return binop;
    }

    public static ExprConstant CreateNull()
    {
      return ExprFactory.CreateConstant((CType) NullType.Instance, new ConstVal());
    }

    public static void AppendItemToList(Expr newItem, ref Expr first, ref Expr last)
    {
      if (newItem == null)
        return;
      if (first == null)
      {
        first = newItem;
        last = newItem;
      }
      else if (first.Kind != ExpressionKind.List)
      {
        first = (Expr) ExprFactory.CreateList(first, newItem);
        last = first;
      }
      else
      {
        ExprList exprList = (ExprList) last;
        exprList.OptionalNextListNode = (Expr) ExprFactory.CreateList(exprList.OptionalNextListNode, newItem);
        last = exprList.OptionalNextListNode;
      }
    }

    public static ExprList CreateList(Expr op1, Expr op2) => new ExprList(op1, op2);

    public static ExprList CreateList(Expr op1, Expr op2, Expr op3)
    {
      return ExprFactory.CreateList(op1, (Expr) ExprFactory.CreateList(op2, op3));
    }

    public static ExprList CreateList(Expr op1, Expr op2, Expr op3, Expr op4)
    {
      return ExprFactory.CreateList(op1, (Expr) ExprFactory.CreateList(op2, (Expr) ExprFactory.CreateList(op3, op4)));
    }

    public static ExprClass CreateClass(CType type) => new ExprClass(type);
  }
}
