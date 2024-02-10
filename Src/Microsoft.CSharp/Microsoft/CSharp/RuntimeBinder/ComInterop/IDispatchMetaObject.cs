// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.IDispatchMetaObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class IDispatchMetaObject : ComFallbackMetaObject
  {
    private readonly IDispatchComObject _self;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal IDispatchMetaObject(Expression expression, IDispatchComObject self)
      : base(expression, BindingRestrictions.Empty, (object) self)
    {
      this._self = self;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindInvokeMember(
      InvokeMemberBinder binder,
      DynamicMetaObject[] args)
    {
      ComMethodDesc method;
      if (!this._self.TryGetMemberMethod(binder.Name, out method) && !this._self.TryGetMemberMethodExplicit(binder.Name, out method))
        return base.BindInvokeMember(binder, args);
      bool[] isByRef = ComBinderHelpers.ProcessArgumentsForCom(ref args);
      return this.BindComInvoke(args, method, binder.CallInfo, isByRef);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
    {
      ComMethodDesc method;
      if (!this._self.TryGetGetItem(out method))
        return base.BindInvoke(binder, args);
      bool[] isByRef = ComBinderHelpers.ProcessArgumentsForCom(ref args);
      return this.BindComInvoke(args, method, binder.CallInfo, isByRef);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject BindComInvoke(
      DynamicMetaObject[] args,
      ComMethodDesc method,
      CallInfo callInfo,
      bool[] isByRef)
    {
      return new ComInvokeBinder(callInfo, args, isByRef, this.IDispatchRestriction(), (Expression) Expression.Constant((object) method), (Expression) Expression.Property(Helpers.Convert(this.Expression, typeof (IDispatchComObject)), typeof (IDispatchComObject).GetProperty("DispatchObject")), method).Invoke();
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
    {
      bool canReturnCallables = binder is ComBinder.ComGetMemberBinder comGetMemberBinder && comGetMemberBinder._canReturnCallables;
      ComMethodDesc method;
      if (this._self.TryGetMemberMethod(binder.Name, out method))
        return this.BindGetMember(method, canReturnCallables);
      ComEventDesc @event;
      if (this._self.TryGetMemberEvent(binder.Name, out @event))
        return this.BindEvent(@event);
      return this._self.TryGetMemberMethodExplicit(binder.Name, out method) ? this.BindGetMember(method, canReturnCallables) : base.BindGetMember(binder);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject BindGetMember(ComMethodDesc method, bool canReturnCallables)
    {
      if (method.IsDataMember && method.ParamCount == 0)
        return this.BindComInvoke(DynamicMetaObject.EmptyMetaObjects, method, new CallInfo(0, Array.Empty<string>()), Array.Empty<bool>());
      return !canReturnCallables ? this.BindComInvoke(DynamicMetaObject.EmptyMetaObjects, method, new CallInfo(0, Array.Empty<string>()), Array.Empty<bool>()) : new DynamicMetaObject((Expression) Expression.Call(typeof (ComRuntimeHelpers).GetMethod("CreateDispCallable"), Helpers.Convert(this.Expression, typeof (IDispatchComObject)), (Expression) Expression.Constant((object) method)), this.IDispatchRestriction());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject BindEvent(ComEventDesc eventDesc)
    {
      return new DynamicMetaObject((Expression) Expression.Call(typeof (ComRuntimeHelpers).GetMethod("CreateComEvent"), (Expression) ComObject.RcwFromComObject(this.Expression), (Expression) Expression.Constant((object) eventDesc.SourceIID), (Expression) Expression.Constant((object) eventDesc.Dispid)), this.IDispatchRestriction());
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindGetIndex(
      GetIndexBinder binder,
      DynamicMetaObject[] indexes)
    {
      ComMethodDesc method;
      if (!this._self.TryGetGetItem(out method))
        return base.BindGetIndex(binder, indexes);
      bool[] isByRef = ComBinderHelpers.ProcessArgumentsForCom(ref indexes);
      return this.BindComInvoke(indexes, method, binder.CallInfo, isByRef);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindSetIndex(
      SetIndexBinder binder,
      DynamicMetaObject[] indexes,
      DynamicMetaObject value)
    {
      ComMethodDesc method;
      if (!this._self.TryGetSetItem(out method))
        return base.BindSetIndex(binder, indexes, value);
      bool[] isByRef = ((IList<bool>) ComBinderHelpers.ProcessArgumentsForCom(ref indexes)).AddLast<bool>(false);
      DynamicMetaObject dynamicMetaObject = this.BindComInvoke(((IList<DynamicMetaObject>) indexes).AddLast<DynamicMetaObject>(value), method, binder.CallInfo, isByRef);
      return new DynamicMetaObject((Expression) Expression.Block(dynamicMetaObject.Expression, (Expression) Expression.Convert(value.Expression, typeof (object))), dynamicMetaObject.Restrictions);
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
    {
      return this.TryPropertyPut(binder, value) ?? this.TryEventHandlerNoop(binder, value) ?? base.BindSetMember(binder, value);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject TryPropertyPut(SetMemberBinder binder, DynamicMetaObject value)
    {
      bool holdsNull = value.Value == null && value.HasValue;
      ComMethodDesc method;
      if (!this._self.TryGetPropertySetter(binder.Name, out method, value.LimitType, holdsNull) && !this._self.TryGetPropertySetterExplicit(binder.Name, out method, value.LimitType, holdsNull))
        return (DynamicMetaObject) null;
      BindingRestrictions restrictions = this.IDispatchRestriction();
      Expression dispatch = (Expression) Expression.Property(Helpers.Convert(this.Expression, typeof (IDispatchComObject)), typeof (IDispatchComObject).GetProperty("DispatchObject"));
      DynamicMetaObject dynamicMetaObject = new ComInvokeBinder(new CallInfo(1, Array.Empty<string>()), new DynamicMetaObject[1]
      {
        value
      }, new bool[1], restrictions, (Expression) Expression.Constant((object) method), dispatch, method).Invoke();
      return new DynamicMetaObject((Expression) Expression.Block(dynamicMetaObject.Expression, (Expression) Expression.Convert(value.Expression, typeof (object))), dynamicMetaObject.Restrictions);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private DynamicMetaObject TryEventHandlerNoop(SetMemberBinder binder, DynamicMetaObject value)
    {
      return this._self.TryGetMemberEvent(binder.Name, out ComEventDesc _) && value.LimitType == typeof (BoundDispEvent) ? new DynamicMetaObject((Expression) Expression.Constant((object) null), value.Restrictions.Merge(this.IDispatchRestriction()).Merge(BindingRestrictions.GetTypeRestriction(value.Expression, typeof (BoundDispEvent)))) : (DynamicMetaObject) null;
    }

    private BindingRestrictions IDispatchRestriction()
    {
      return IDispatchMetaObject.IDispatchRestriction(this.Expression, this._self.ComTypeDesc);
    }

    internal static BindingRestrictions IDispatchRestriction(Expression expr, ComTypeDesc typeDesc)
    {
      return BindingRestrictions.GetTypeRestriction(expr, typeof (IDispatchComObject)).Merge(BindingRestrictions.GetExpressionRestriction((Expression) Expression.Equal((Expression) Expression.Property(Helpers.Convert(expr, typeof (IDispatchComObject)), typeof (IDispatchComObject).GetProperty("ComTypeDesc")), (Expression) Expression.Constant((object) typeDesc))));
    }

    protected override ComUnwrappedMetaObject UnwrapSelf()
    {
      return new ComUnwrappedMetaObject((Expression) ComObject.RcwFromComObject(this.Expression), this.IDispatchRestriction(), this._self.RuntimeCallableWrapper);
    }
  }
}
