// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.RuntimeBinder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Errors;
using Microsoft.CSharp.RuntimeBinder.Semantics;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal readonly struct RuntimeBinder
  {
    private static readonly object s_bindLock = new object();
    private readonly ExpressionBinder _binder;

    internal bool IsChecked => this._binder.Context.Checked;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public RuntimeBinder(Type contextType, bool isChecked = false)
    {
      AggregateSymbol context;
      if (contextType != (Type) null)
      {
        lock (Microsoft.CSharp.RuntimeBinder.RuntimeBinder.s_bindLock)
          context = ((AggregateType) SymbolTable.GetCTypeFromType(contextType)).OwningAggregate;
      }
      else
        context = (AggregateSymbol) null;
      this._binder = new ExpressionBinder(new BindingContext(context, isChecked));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public Expression Bind(
      ICSharpBinder payload,
      Expression[] parameters,
      DynamicMetaObject[] args,
      out DynamicMetaObject deferredBinding)
    {
      lock (Microsoft.CSharp.RuntimeBinder.RuntimeBinder.s_bindLock)
        return this.BindCore(payload, parameters, args, out deferredBinding);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expression BindCore(
      ICSharpBinder payload,
      Expression[] parameters,
      DynamicMetaObject[] args,
      out DynamicMetaObject deferredBinding)
    {
      ArgumentObject[] argumentArray = this.CreateArgumentArray(payload, parameters, args);
      payload.PopulateSymbolTableWithName(argumentArray[0].Type, argumentArray);
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder.AddConversionsForArguments(argumentArray);
      Scope scope = SymFactory.CreateScope();
      LocalVariableSymbol[] locals = Microsoft.CSharp.RuntimeBinder.RuntimeBinder.PopulateLocalScope(payload, scope, argumentArray, parameters);
      if (this.DeferBinding(payload, argumentArray, args, locals, out deferredBinding))
        return (Expression) null;
      Expr pResult = payload.DispatchPayload(this, argumentArray, locals);
      return Microsoft.CSharp.RuntimeBinder.RuntimeBinder.CreateExpressionTreeFromResult(parameters, scope, pResult);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private bool DeferBinding(
      ICSharpBinder payload,
      ArgumentObject[] arguments,
      DynamicMetaObject[] args,
      LocalVariableSymbol[] locals,
      out DynamicMetaObject deferredBinding)
    {
      if (payload is CSharpInvokeMemberBinder payload1)
      {
        Type[] typeArguments = payload1.TypeArguments;
        int length = typeArguments != null ? typeArguments.Length : 0;
        MemberLookup mem = new MemberLookup();
        Expr callingObjectForCall = this.CreateCallingObjectForCall((ICSharpInvokeOrInvokeMemberBinder) payload1, arguments, locals);
        SymWithType symWithType = SymbolTable.LookupMember(payload1.Name, callingObjectForCall, (ParentSymbol) this._binder.Context.ContextForMemberLookup, length, mem, (payload1.Flags & CSharpCallFlags.EventHookup) != 0, true);
        if (symWithType != (SymWithType) null && symWithType.Sym.getKind() != SYMKIND.SK_MethodSymbol)
        {
          CSharpGetMemberBinder existing1 = new CSharpGetMemberBinder(payload1.Name, false, payload1.CallingContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            payload1.GetArgumentInfo(0)
          }).TryGetExisting<CSharpGetMemberBinder>();
          CSharpArgumentInfo[] argumentInfo = payload1.ArgumentInfoArray();
          argumentInfo[0] = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null);
          CSharpInvokeBinder existing2 = new CSharpInvokeBinder(payload1.Flags, payload1.CallingContext, (IEnumerable<CSharpArgumentInfo>) argumentInfo).TryGetExisting<CSharpInvokeBinder>();
          DynamicMetaObject[] destinationArray = new DynamicMetaObject[args.Length - 1];
          Array.Copy((Array) args, 1, (Array) destinationArray, 0, args.Length - 1);
          deferredBinding = existing2.Defer(existing1.Defer(args[0]), destinationArray);
          return true;
        }
      }
      deferredBinding = (DynamicMetaObject) null;
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static Expression CreateExpressionTreeFromResult(
      Expression[] parameters,
      Scope pScope,
      Expr pResult)
    {
      return ExpressionTreeCallRewriter.Rewrite(ExpressionTreeRewriter.Rewrite(Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GenerateBoundLambda(pScope, pResult)), parameters);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Type GetArgumentType(
      ICSharpBinder p,
      CSharpArgumentInfo argInfo,
      Expression param,
      DynamicMetaObject arg,
      int index)
    {
      Type type = argInfo.UseCompileTimeType ? param.Type : arg.LimitType;
      if (argInfo.IsByRefOrOut)
      {
        if (index != 0 || !p.IsBinderThatCanHaveRefReceiver)
          type = type.MakeByRefType();
      }
      else if (!argInfo.UseCompileTimeType)
        type = TypeManager.GetBestAccessibleType(this._binder.Context.ContextForMemberLookup, SymbolTable.GetCTypeFromType(type)).AssociatedSystemType;
      return type;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ArgumentObject[] CreateArgumentArray(
      ICSharpBinder payload,
      Expression[] parameters,
      DynamicMetaObject[] args)
    {
      ArgumentObject[] argumentArray = new ArgumentObject[parameters.Length];
      for (int index = 0; index < parameters.Length; ++index)
      {
        CSharpArgumentInfo argumentInfo = payload.GetArgumentInfo(index);
        argumentArray[index] = new ArgumentObject(args[index].Value, argumentInfo, this.GetArgumentType(payload, argumentInfo, parameters[index], args[index], index));
      }
      return argumentArray;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static void PopulateSymbolTableWithPayloadInformation(
      ICSharpInvokeOrInvokeMemberBinder callOrInvoke,
      Type callingType,
      ArgumentObject[] arguments)
    {
      Type callingType1;
      if (callOrInvoke.StaticCall)
      {
        callingType1 = arguments[0].Value as Type;
        if (callingType1 == (Type) null)
          throw Error.BindStaticRequiresType(arguments[0].Info.Name);
      }
      else
        callingType1 = callingType;
      SymbolTable.PopulateSymbolTableWithName(callOrInvoke.Name, (IEnumerable<Type>) callOrInvoke.TypeArguments, callingType1);
      if (!callOrInvoke.Name.StartsWith("set_", StringComparison.Ordinal) && !callOrInvoke.Name.StartsWith("get_", StringComparison.Ordinal))
        return;
      SymbolTable.PopulateSymbolTableWithName(callOrInvoke.Name.Substring(4), (IEnumerable<Type>) callOrInvoke.TypeArguments, callingType1);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddConversionsForArguments(ArgumentObject[] arguments)
    {
      foreach (ArgumentObject argumentObject in arguments)
        SymbolTable.AddConversionsForType(argumentObject.Type);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal ExprWithArgs DispatchPayload(
      ICSharpInvokeOrInvokeMemberBinder payload,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      return this.BindCall(payload, this.CreateCallingObjectForCall(payload, arguments, locals), arguments, locals);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static LocalVariableSymbol[] PopulateLocalScope(
      ICSharpBinder payload,
      Scope pScope,
      ArgumentObject[] arguments,
      Expression[] parameterExpressions)
    {
      LocalVariableSymbol[] localVariableSymbolArray = new LocalVariableSymbol[parameterExpressions.Length];
      for (int index = 0; index < parameterExpressions.Length; ++index)
      {
        Expression parameterExpression1 = parameterExpressions[index];
        CType ctype = SymbolTable.GetCTypeFromType(parameterExpression1.Type);
        if ((index != 0 || !payload.IsBinderThatCanHaveRefReceiver) && parameterExpression1 is ParameterExpression parameterExpression2 && parameterExpression2.IsByRef)
        {
          CSharpArgumentInfo info = arguments[index].Info;
          if (info.IsByRefOrOut)
            ctype = (CType) TypeManager.GetParameterModifier(ctype, info.IsOut);
        }
        LocalVariableSymbol localVar = SymFactory.CreateLocalVar(NameManager.Add("p" + index.ToString()), pScope, ctype);
        localVariableSymbolArray[index] = localVar;
      }
      return localVariableSymbolArray;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprBoundLambda GenerateBoundLambda(Scope pScope, Expr call)
    {
      return ExprFactory.CreateAnonymousMethod(SymbolLoader.GetPredefindType(PredefinedType.PT_FUNC), pScope, call);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateLocal(Type type, bool isOut, LocalVariableSymbol local)
    {
      CType dest = !isOut ? SymbolTable.GetCTypeFromType(type) : (CType) TypeManager.GetParameterModifier(SymbolTable.GetCTypeFromType(type.GetElementType()), true);
      ExprLocal local1 = ExprFactory.CreateLocal(local);
      Expr local2 = this._binder.tryConvert((Expr) local1, dest) ?? this._binder.mustCast((Expr) local1, dest);
      local2.Flags |= EXPRFLAG.EXF_LVALUE;
      return local2;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr CreateArgumentListEXPR(
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals,
      int startIndex,
      int endIndex)
    {
      Expr first = (Expr) null;
      Expr last = (Expr) null;
      if (arguments != null)
      {
        for (int index = startIndex; index < endIndex; ++index)
        {
          Expr argumentExpr = this.CreateArgumentEXPR(arguments[index], locals[index]);
          if (first == null)
          {
            first = argumentExpr;
            last = first;
          }
          else
            ExprFactory.AppendItemToList(argumentExpr, ref first, ref last);
        }
      }
      return first;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateArgumentEXPR(ArgumentObject argument, LocalVariableSymbol local)
    {
      Expr argumentExpr = !argument.Info.LiteralConstant ? (argument.Info.UseCompileTimeType || argument.Value != null ? this.CreateLocal(argument.Type, argument.Info.IsOut, local) : (Expr) ExprFactory.CreateNull()) : (argument.Value != null ? (Expr) ExprFactory.CreateConstant(SymbolTable.GetCTypeFromType(argument.Type), ConstVal.Get(argument.Value)) : (!argument.Info.UseCompileTimeType ? (Expr) ExprFactory.CreateNull() : (Expr) ExprFactory.CreateConstant(SymbolTable.GetCTypeFromType(argument.Type), new ConstVal())));
      if (argument.Info.NamedArgument)
        argumentExpr = (Expr) ExprFactory.CreateNamedArgumentSpecification(NameManager.Add(argument.Info.Name), argumentExpr);
      if (!argument.Info.UseCompileTimeType && argument.Value != null)
      {
        argumentExpr.RuntimeObject = argument.Value;
        argumentExpr.RuntimeObjectActualType = SymbolTable.GetCTypeFromType(argument.Value.GetType());
      }
      return argumentExpr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ExprMemberGroup CreateMemberGroupExpr(
      string Name,
      Type[] typeArguments,
      Expr callingObject,
      SYMKIND kind)
    {
      Name name = NameManager.Add(Name);
      CType type = callingObject.Type;
      AggregateType parentType;
      switch (type)
      {
        case ArrayType _:
          parentType = SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY);
          break;
        case NullableType nullableType:
          parentType = nullableType.GetAts();
          break;
        default:
          parentType = (AggregateType) type;
          break;
      }
      HashSet<CType> ctypeSet = new HashSet<CType>();
      List<CType> ctypeList = new List<CType>();
      symbmask_t mask = symbmask_t.MASK_MethodSymbol;
      switch (kind)
      {
        case SYMKIND.SK_MethodSymbol:
          mask = symbmask_t.MASK_MethodSymbol;
          break;
        case SYMKIND.SK_PropertySymbol:
        case SYMKIND.SK_IndexerSymbol:
          mask = symbmask_t.MASK_PropertySymbol;
          break;
      }
      bool flag = name == NameManager.GetPredefinedName(PredefinedName.PN_CTOR);
      foreach (AggregateType aggregateType in parentType.TypeHierarchy)
      {
        if (SymbolTable.AggregateContainsMethod(aggregateType.OwningAggregate, Name, mask) && ctypeSet.Add((CType) aggregateType))
          ctypeList.Add((CType) aggregateType);
        if (flag)
          break;
      }
      EXPRFLAG flags = EXPRFLAG.EXF_USERCALLABLE;
      if (Name == "Invoke" && callingObject.Type.IsDelegateType)
        flags |= EXPRFLAG.EXF_GOTONOTBLOCKED;
      if (Name == ".ctor")
        flags |= EXPRFLAG.EXF_CTOR;
      if (Name == "$Item$")
        flags |= EXPRFLAG.EXF_INDEXER;
      TypeArray typeArgs = typeArguments == null || typeArguments.Length == 0 ? TypeArray.Empty : TypeArray.Allocate(SymbolTable.GetCTypeArrayFromTypes(typeArguments));
      ExprMemberGroup memGroup = ExprFactory.CreateMemGroup(flags, name, typeArgs, kind, (CType) parentType, (Expr) null, new CMemberLookupResults(TypeArray.Allocate(ctypeList.ToArray()), name));
      if (!(callingObject is ExprClass))
        memGroup.OptionalObject = callingObject;
      return memGroup;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateProperty(SymWithType swt, Expr callingObject, BindingFlag flags)
    {
      PropertySymbol prop = swt.Prop();
      AggregateType type = swt.GetType();
      PropWithType pwt = new PropWithType(prop, type);
      ExprMemberGroup memberGroupExpr = Microsoft.CSharp.RuntimeBinder.RuntimeBinder.CreateMemberGroupExpr(prop.name.Text, (Type[]) null, callingObject, SYMKIND.SK_PropertySymbol);
      return (Expr) this._binder.BindToProperty(callingObject is ExprClass ? (Expr) null : callingObject, pwt, flags, (Expr) null, memberGroupExpr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprWithArgs CreateIndexer(
      SymWithType swt,
      Expr callingObject,
      Expr arguments,
      BindingFlag bindFlags)
    {
      ExprMemberGroup memberGroupExpr = Microsoft.CSharp.RuntimeBinder.RuntimeBinder.CreateMemberGroupExpr((swt.Sym as IndexerSymbol).name.Text, (Type[]) null, callingObject, SYMKIND.SK_PropertySymbol);
      ExprWithArgs arguments1 = this._binder.BindMethodGroupToArguments(bindFlags, memberGroupExpr, arguments);
      this.ReorderArgumentsForNamedAndOptional(callingObject, arguments1);
      return arguments1;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateArray(Expr callingObject, Expr optionalIndexerArguments)
    {
      return this._binder.BindArrayIndexCore(callingObject, optionalIndexerArguments);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateField(SymWithType swt, Expr callingObject)
    {
      FieldWithType fwt = new FieldWithType(swt.Field(), swt.GetType());
      return this._binder.BindToField(callingObject is ExprClass ? (Expr) null : callingObject, fwt, (BindingFlag) 0);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private Expr CreateCallingObjectForCall(
      ICSharpInvokeOrInvokeMemberBinder payload,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      Expr callingObjectForCall;
      if (payload.StaticCall)
      {
        callingObjectForCall = (Expr) ExprFactory.CreateClass(SymbolTable.GetCTypeFromType(arguments[0].Value as Type));
      }
      else
      {
        if (!arguments[0].Info.UseCompileTimeType && arguments[0].Value == null)
          throw Error.NullReferenceOnMemberException();
        callingObjectForCall = this._binder.mustConvert(this.CreateArgumentEXPR(arguments[0], locals[0]), SymbolTable.GetCTypeFromType(arguments[0].Type));
        if (arguments[0].Type.IsValueType && callingObjectForCall is ExprCast)
          callingObjectForCall.Flags |= EXPRFLAG.EXF_USERCALLABLE;
      }
      return callingObjectForCall;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private ExprWithArgs BindCall(
      ICSharpInvokeOrInvokeMemberBinder payload,
      Expr callingObject,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      if (payload is InvokeBinder && !callingObject.Type.IsDelegateType)
        throw Error.BindInvokeFailedNonDelegate();
      Type[] typeArguments = payload.TypeArguments;
      int length = typeArguments != null ? typeArguments.Length : 0;
      MemberLookup mem1 = new MemberLookup();
      SymWithType symWithType1 = SymbolTable.LookupMember(payload.Name, callingObject, (ParentSymbol) this._binder.Context.ContextForMemberLookup, length, mem1, (payload.Flags & CSharpCallFlags.EventHookup) != 0, true);
      if (symWithType1 == (SymWithType) null)
        throw mem1.ReportErrors();
      if (symWithType1.Sym.getKind() != SYMKIND.SK_MethodSymbol)
        throw Error.InternalCompilerError();
      ExprMemberGroup memberGroupExpr = Microsoft.CSharp.RuntimeBinder.RuntimeBinder.CreateMemberGroupExpr(payload.Name, payload.TypeArguments, callingObject, symWithType1.Sym.getKind());
      if ((payload.Flags & CSharpCallFlags.SimpleNameCall) != CSharpCallFlags.None)
        callingObject.Flags |= EXPRFLAG.EXF_UNREALIZEDGOTO;
      if ((payload.Flags & CSharpCallFlags.EventHookup) != CSharpCallFlags.None)
      {
        MemberLookup mem2 = new MemberLookup();
        SymWithType symWithType2 = SymbolTable.LookupMember(payload.Name.Split('_')[1], callingObject, (ParentSymbol) this._binder.Context.ContextForMemberLookup, length, mem2, (payload.Flags & CSharpCallFlags.EventHookup) != 0, true);
        if (symWithType2 == (SymWithType) null)
          throw mem2.ReportErrors();
        CType typeSrc = (CType) null;
        if (symWithType2.Sym.getKind() == SYMKIND.SK_FieldSymbol)
          typeSrc = symWithType2.Field().GetType();
        else if (symWithType2.Sym.getKind() == SYMKIND.SK_EventSymbol)
          typeSrc = symWithType2.Event().type;
        Type associatedSystemType = TypeManager.SubstType(typeSrc, symWithType2.Ats).AssociatedSystemType;
        if (associatedSystemType != (Type) null)
          this.BindImplicitConversion(new ArgumentObject[1]
          {
            arguments[1]
          }, associatedSystemType, locals, false);
        memberGroupExpr.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
      }
      if (payload.Name.StartsWith("set_", StringComparison.Ordinal) && ((MethodOrPropertySymbol) symWithType1.Sym).Params.Count > 1 || payload.Name.StartsWith("get_", StringComparison.Ordinal) && ((MethodOrPropertySymbol) symWithType1.Sym).Params.Count > 0)
        memberGroupExpr.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
      ExprCall arguments1 = this._binder.BindMethodGroupToArguments(BindingFlag.BIND_RVALUEREQUIRED | BindingFlag.BIND_STMTEXPRONLY, memberGroupExpr, this.CreateArgumentListEXPR(arguments, locals, 1, arguments.Length)) as ExprCall;
      Microsoft.CSharp.RuntimeBinder.RuntimeBinder.CheckForConditionalMethodError(arguments1);
      this.ReorderArgumentsForNamedAndOptional(callingObject, (ExprWithArgs) arguments1);
      return (ExprWithArgs) arguments1;
    }

    private static void CheckForConditionalMethodError(ExprCall call)
    {
      MethodSymbol methodSymbol = call.MethWithInst.Meth();
      if (methodSymbol.AssociatedMemberInfo.GetCustomAttributes(typeof (ConditionalAttribute), true).Length != 0)
        throw Error.BindCallToConditionalMethod((object) methodSymbol.name);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void ReorderArgumentsForNamedAndOptional(Expr callingObject, ExprWithArgs result)
    {
      Expr optionalArguments = result.OptionalArguments;
      AggregateType ats;
      MethodOrPropertySymbol pMethProp;
      ExprMemberGroup memberGroup;
      TypeArray typeArgsMeth;
      if (result is ExprCall exprCall)
      {
        ats = exprCall.MethWithInst.Ats;
        pMethProp = (MethodOrPropertySymbol) exprCall.MethWithInst.Meth();
        memberGroup = exprCall.MemberGroup;
        typeArgsMeth = exprCall.MethWithInst.TypeArgs;
      }
      else
      {
        ExprProperty exprProperty = result as ExprProperty;
        ats = exprProperty.PropWithTypeSlot.Ats;
        pMethProp = (MethodOrPropertySymbol) exprProperty.PropWithTypeSlot.Prop();
        memberGroup = exprProperty.MemberGroup;
        typeArgsMeth = (TypeArray) null;
      }
      ArgInfos argInfos = new ArgInfos()
      {
        carg = ExpressionBinder.CountArguments(optionalArguments)
      };
      ExpressionBinder.FillInArgInfoFromArgList(argInfos, optionalArguments);
      TypeArray pCurrentParameters = TypeManager.SubstTypeArray(pMethProp.Params, ats, typeArgsMeth);
      ExpressionBinder.GroupToArgsBinder.ReOrderArgsForNamedArguments(ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(pMethProp, callingObject.Type), pCurrentParameters, ats, memberGroup, argInfos);
      Expr op2 = (Expr) null;
      for (int index = argInfos.carg - 1; index >= 0; --index)
      {
        Expr op1 = this._binder.tryConvert(this.StripNamedArgument(argInfos.prgexpr[index]), pCurrentParameters[index]);
        op2 = op2 == null ? op1 : (Expr) ExprFactory.CreateList(op1, op2);
      }
      result.OptionalArguments = op2;
    }

    private Expr StripNamedArgument(Expr pArg)
    {
      switch (pArg)
      {
        case ExprNamedArgumentSpecification argumentSpecification:
          pArg = argumentSpecification.Value;
          break;
        case ExprArrayInit exprArrayInit:
          exprArrayInit.OptionalArguments = this.StripNamedArguments(exprArrayInit.OptionalArguments);
          break;
      }
      return pArg;
    }

    private Expr StripNamedArguments(Expr pArg)
    {
      if (pArg is ExprList exprList1)
      {
        do
        {
          exprList1.OptionalElement = this.StripNamedArgument(exprList1.OptionalElement);
        }
        while (exprList1.OptionalNextListNode is ExprList exprList1);
        exprList1.OptionalNextListNode = this.StripNamedArgument(exprList1.OptionalNextListNode);
      }
      return this.StripNamedArgument(pArg);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindUnaryOperation(
      CSharpUnaryOperationBinder payload,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      OperatorKind operatorKind = Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(payload.Operation);
      Expr argumentExpr = this.CreateArgumentEXPR(arguments[0], locals[0]);
      argumentExpr.ErrorString = Operators.GetDisplayName(Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(payload.Operation));
      if (operatorKind != OperatorKind.OP_TRUE && operatorKind != OperatorKind.OP_FALSE)
        return this._binder.BindStandardUnaryOperator(operatorKind, argumentExpr);
      Expr pArgument = this._binder.tryConvert(argumentExpr, (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL));
      if (pArgument != null && operatorKind == OperatorKind.OP_FALSE)
        pArgument = this._binder.BindStandardUnaryOperator(OperatorKind.OP_LOGNOT, pArgument);
      return pArgument ?? this._binder.bindUDUnop(operatorKind == OperatorKind.OP_TRUE ? ExpressionKind.True : ExpressionKind.False, argumentExpr) ?? this._binder.mustConvert(argumentExpr, (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindBinaryOperation(
      CSharpBinaryOperationBinder payload,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      ExpressionKind expressionKind = Operators.GetExpressionKind(Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
      Expr argumentExpr1 = this.CreateArgumentEXPR(arguments[0], locals[0]);
      Expr argumentExpr2 = this.CreateArgumentEXPR(arguments[1], locals[1]);
      argumentExpr1.ErrorString = Operators.GetDisplayName(Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
      argumentExpr2.ErrorString = Operators.GetDisplayName(Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
      if (expressionKind > ExpressionKind.MultiOffset)
        expressionKind -= ExpressionKind.MultiOffset;
      return this._binder.BindStandardBinop(expressionKind, argumentExpr1, argumentExpr2);
    }

    private static OperatorKind GetOperatorKind(ExpressionType p)
    {
      return Microsoft.CSharp.RuntimeBinder.RuntimeBinder.GetOperatorKind(p, false);
    }

    private static OperatorKind GetOperatorKind(ExpressionType p, bool bIsLogical)
    {
      switch (p)
      {
        case ExpressionType.Add:
          return OperatorKind.OP_ADD;
        case ExpressionType.And:
          return !bIsLogical ? OperatorKind.OP_BITAND : OperatorKind.OP_LOGAND;
        case ExpressionType.Divide:
          return OperatorKind.OP_DIV;
        case ExpressionType.Equal:
          return OperatorKind.OP_EQ;
        case ExpressionType.ExclusiveOr:
          return OperatorKind.OP_BITXOR;
        case ExpressionType.GreaterThan:
          return OperatorKind.OP_GT;
        case ExpressionType.GreaterThanOrEqual:
          return OperatorKind.OP_GE;
        case ExpressionType.LeftShift:
          return OperatorKind.OP_LSHIFT;
        case ExpressionType.LessThan:
          return OperatorKind.OP_LT;
        case ExpressionType.LessThanOrEqual:
          return OperatorKind.OP_LE;
        case ExpressionType.Modulo:
          return OperatorKind.OP_MOD;
        case ExpressionType.Multiply:
          return OperatorKind.OP_MUL;
        case ExpressionType.Negate:
          return OperatorKind.OP_NEG;
        case ExpressionType.UnaryPlus:
          return OperatorKind.OP_UPLUS;
        case ExpressionType.Not:
          return OperatorKind.OP_LOGNOT;
        case ExpressionType.NotEqual:
          return OperatorKind.OP_NEQ;
        case ExpressionType.Or:
          return !bIsLogical ? OperatorKind.OP_BITOR : OperatorKind.OP_LOGOR;
        case ExpressionType.RightShift:
          return OperatorKind.OP_RSHIFT;
        case ExpressionType.Subtract:
          return OperatorKind.OP_SUB;
        case ExpressionType.Decrement:
          return OperatorKind.OP_PREDEC;
        case ExpressionType.Increment:
          return OperatorKind.OP_PREINC;
        case ExpressionType.AddAssign:
          return OperatorKind.OP_ADDEQ;
        case ExpressionType.AndAssign:
          return OperatorKind.OP_ANDEQ;
        case ExpressionType.DivideAssign:
          return OperatorKind.OP_DIVEQ;
        case ExpressionType.ExclusiveOrAssign:
          return OperatorKind.OP_XOREQ;
        case ExpressionType.LeftShiftAssign:
          return OperatorKind.OP_LSHIFTEQ;
        case ExpressionType.ModuloAssign:
          return OperatorKind.OP_MODEQ;
        case ExpressionType.MultiplyAssign:
          return OperatorKind.OP_MULEQ;
        case ExpressionType.OrAssign:
          return OperatorKind.OP_OREQ;
        case ExpressionType.RightShiftAssign:
          return OperatorKind.OP_RSHIFTEQ;
        case ExpressionType.SubtractAssign:
          return OperatorKind.OP_SUBEQ;
        case ExpressionType.OnesComplement:
          return OperatorKind.OP_BITNOT;
        case ExpressionType.IsTrue:
          return OperatorKind.OP_TRUE;
        case ExpressionType.IsFalse:
          return OperatorKind.OP_FALSE;
        default:
          throw Error.InternalCompilerError();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindProperty(
      ICSharpBinder payload,
      ArgumentObject argument,
      LocalVariableSymbol local,
      Expr optionalIndexerArguments)
    {
      Expr callingObject = argument.Info.IsStaticType ? (Expr) ExprFactory.CreateClass(SymbolTable.GetCTypeFromType(argument.Value as Type)) : this.CreateLocal(argument.Type, argument.Info.IsOut, local);
      if (!argument.Info.UseCompileTimeType && argument.Value == null)
        throw Error.NullReferenceOnMemberException();
      if (argument.Type.IsValueType && callingObject is ExprCast)
        callingObject.Flags |= EXPRFLAG.EXF_USERCALLABLE;
      string name = payload.Name;
      BindingFlag bindingFlags = payload.BindingFlags;
      MemberLookup mem = new MemberLookup();
      SymWithType swt = SymbolTable.LookupMember(name, callingObject, (ParentSymbol) this._binder.Context.ContextForMemberLookup, 0, mem, false, false);
      if (swt == (SymWithType) null)
      {
        int num = optionalIndexerArguments != null ? ExpressionIterator.Count(optionalIndexerArguments) : throw mem.ReportErrors();
        Type type = argument.Type;
        if (type.IsArray)
        {
          if (type.IsArray && type.GetArrayRank() != num)
            throw ErrorHandling.Error(ErrorCode.ERR_BadIndexCount, (ErrArg) type.GetArrayRank());
          return this.CreateArray(callingObject, optionalIndexerArguments);
        }
      }
      else
      {
        switch (swt.Sym.getKind())
        {
          case SYMKIND.SK_FieldSymbol:
            return this.CreateField(swt, callingObject);
          case SYMKIND.SK_MethodSymbol:
            throw Error.BindPropertyFailedMethodGroup((object) name);
          case SYMKIND.SK_PropertySymbol:
            if (swt.Sym is IndexerSymbol)
              return (Expr) this.CreateIndexer(swt, callingObject, optionalIndexerArguments, bindingFlags);
            callingObject.Flags |= EXPRFLAG.EXF_LVALUE;
            return this.CreateProperty(swt, callingObject, payload.BindingFlags);
          case SYMKIND.SK_EventSymbol:
            throw Error.BindPropertyFailedEvent((object) name);
          default:
            throw Error.InternalCompilerError();
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindImplicitConversion(
      ArgumentObject[] arguments,
      Type returnType,
      LocalVariableSymbol[] locals,
      bool bIsArrayCreationConversion)
    {
      SymbolTable.AddConversionsForType(returnType);
      Expr argumentExpr = this.CreateArgumentEXPR(arguments[0], locals[0]);
      CType ctypeFromType = SymbolTable.GetCTypeFromType(returnType);
      if (!bIsArrayCreationConversion)
        return this._binder.mustConvert(argumentExpr, ctypeFromType);
      CType dest = this._binder.ChooseArrayIndexType(argumentExpr);
      return this._binder.mustCast(this._binder.mustConvert(argumentExpr, dest), ctypeFromType, CONVERTTYPE.NOUDC | CONVERTTYPE.CHECKOVERFLOW);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindExplicitConversion(
      ArgumentObject[] arguments,
      Type returnType,
      LocalVariableSymbol[] locals)
    {
      SymbolTable.AddConversionsForType(returnType);
      return this._binder.mustCast(this.CreateArgumentEXPR(arguments[0], locals[0]), SymbolTable.GetCTypeFromType(returnType));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindAssignment(
      ICSharpBinder payload,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      string name = payload.Name;
      Expr optionalIndexerArguments;
      bool compoundAssignment;
      if (payload is CSharpSetIndexBinder csharpSetIndexBinder)
      {
        optionalIndexerArguments = this.CreateArgumentListEXPR(arguments, locals, 1, arguments.Length - 1);
        compoundAssignment = csharpSetIndexBinder.IsCompoundAssignment;
      }
      else
      {
        optionalIndexerArguments = (Expr) null;
        compoundAssignment = (payload as CSharpSetMemberBinder).IsCompoundAssignment;
      }
      SymbolTable.PopulateSymbolTableWithName(name, (IEnumerable<Type>) null, arguments[0].Type);
      Expr op1 = this.BindProperty(payload, arguments[0], locals[0], optionalIndexerArguments);
      int index = arguments.Length - 1;
      Expr argumentExpr = this.CreateArgumentEXPR(arguments[index], locals[index]);
      return this._binder.BindAssignment(op1, argumentExpr, compoundAssignment);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal Expr BindIsEvent(
      CSharpIsEventBinder binder,
      ArgumentObject[] arguments,
      LocalVariableSymbol[] locals)
    {
      Expr local = this.CreateLocal(arguments[0].Type, false, locals[0]);
      MemberLookup mem = new MemberLookup();
      CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL);
      bool flag = false;
      if (arguments[0].Value == null)
        throw Error.NullReferenceOnMemberException();
      SymWithType symWithType = SymbolTable.LookupMember(binder.Name, local, (ParentSymbol) this._binder.Context.ContextForMemberLookup, 0, mem, false, false);
      if (symWithType != (SymWithType) null)
      {
        if (symWithType.Sym.getKind() == SYMKIND.SK_EventSymbol)
          flag = true;
        else if (symWithType.Sym is FieldSymbol sym && sym.isEvent)
          flag = true;
      }
      return (Expr) ExprFactory.CreateConstant(predefindType, ConstVal.Get(flag));
    }
  }
}
