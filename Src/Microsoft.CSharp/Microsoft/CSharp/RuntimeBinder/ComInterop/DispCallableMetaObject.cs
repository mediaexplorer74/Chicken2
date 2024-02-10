// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.DispCallableMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class DispCallableMetaObject : DynamicMetaObject
  {
    private readonly DispCallable _callable;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal DispCallableMetaObject(Expression expression, DispCallable callable)
      : base(expression, BindingRestrictions.Empty, (object) callable)
    {
      this._callable = callable;
    }

    public override DynamicMetaObject BindGetIndex(
      GetIndexBinder binder,
      DynamicMetaObject[] indexes)
    {
      return this.BindGetOrInvoke(indexes, binder.CallInfo) ?? base.BindGetIndex(binder, indexes);
    }

    public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
    {
      return this.BindGetOrInvoke(args, binder.CallInfo) ?? base.BindInvoke(binder, args);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    private DynamicMetaObject BindGetOrInvoke(DynamicMetaObject[] args, CallInfo callInfo)
    {
      IDispatchComObject dispatchComObject = this._callable.DispatchComObject;
      string memberName = this._callable.MemberName;
      ComMethodDesc method;
      if (!dispatchComObject.TryGetMemberMethod(memberName, out method) && !dispatchComObject.TryGetMemberMethodExplicit(memberName, out method))
        return (DynamicMetaObject) null;
      bool[] isByRef = ComBinderHelpers.ProcessArgumentsForCom(ref args);
      return this.BindComInvoke(method, args, callInfo, isByRef);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindSetIndex(
      SetIndexBinder binder,
      DynamicMetaObject[] indexes,
      DynamicMetaObject value)
    {
      IDispatchComObject dispatchComObject = this._callable.DispatchComObject;
      string memberName = this._callable.MemberName;
      bool holdsNull = value.Value == null && value.HasValue;
      ComMethodDesc method;
      if (!dispatchComObject.TryGetPropertySetter(memberName, out method, value.LimitType, holdsNull) && !dispatchComObject.TryGetPropertySetterExplicit(memberName, out method, value.LimitType, holdsNull))
        return base.BindSetIndex(binder, indexes, value);
      bool[] isByRef = ((IList<bool>) ComBinderHelpers.ProcessArgumentsForCom(ref indexes)).AddLast<bool>(false);
      DynamicMetaObject dynamicMetaObject = this.BindComInvoke(method, ((IList<DynamicMetaObject>) indexes).AddLast<DynamicMetaObject>(value), binder.CallInfo, isByRef);
      return new DynamicMetaObject((Expression) Expression.Block(dynamicMetaObject.Expression, (Expression) Expression.Convert(value.Expression, typeof (object))), dynamicMetaObject.Restrictions);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject BindComInvoke(
      ComMethodDesc method,
      DynamicMetaObject[] indexes,
      CallInfo callInfo,
      bool[] isByRef)
    {
      Expression expression = Helpers.Convert(this.Expression, typeof (DispCallable));
      return new ComInvokeBinder(callInfo, indexes, isByRef, this.DispCallableRestrictions(), (Expression) Expression.Constant((object) method), (Expression) Expression.Property(expression, typeof (DispCallable).GetProperty("DispatchObject")), method).Invoke();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private BindingRestrictions DispCallableRestrictions()
    {
      Expression expression1 = this.Expression;
      BindingRestrictions typeRestriction = BindingRestrictions.GetTypeRestriction(expression1, typeof (DispCallable));
      Expression expression2 = Helpers.Convert(expression1, typeof (DispCallable));
      MemberExpression expr = Expression.Property(expression2, typeof (DispCallable).GetProperty("DispatchComObject"));
      MemberExpression left = Expression.Property(expression2, typeof (DispCallable).GetProperty("DispId"));
      BindingRestrictions restrictions = IDispatchMetaObject.IDispatchRestriction((Expression) expr, this._callable.DispatchComObject.ComTypeDesc);
      BindingRestrictions expressionRestriction = BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal((Expression) left, (Expression) Expression.Constant((object) this._callable.DispId)));
      return typeRestriction.Merge(restrictions).Merge(expressionRestriction);
    }
  }
}
