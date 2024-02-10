// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.BoundDispEvent
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class BoundDispEvent : DynamicObject
  {
    private readonly object _rcw;
    private readonly Guid _sourceIid;
    private readonly int _dispid;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal BoundDispEvent(object rcw, Guid sourceIid, int dispid)
    {
      this._rcw = rcw;
      this._sourceIid = sourceIid;
      this._dispid = dispid;
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This whole class is unsafe. Constructors are marked as such.")]
    public override bool TryBinaryOperation(
      BinaryOperationBinder binder,
      object handler,
      out object result)
    {
      if (binder.Operation == ExpressionType.AddAssign)
      {
        result = this.InPlaceAdd(handler);
        return true;
      }
      if (binder.Operation == ExpressionType.SubtractAssign)
      {
        result = this.InPlaceSubtract(handler);
        return true;
      }
      result = (object) null;
      return false;
    }

    private static void VerifyHandler(object handler)
    {
      if ((object) (handler as Delegate) != null && handler.GetType() != typeof (Delegate))
        return;
      switch (handler)
      {
        case IDynamicMetaObjectProvider _:
          break;
        case DispCallable _:
          break;
        default:
          throw Error.UnsupportedHandlerType();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private object InPlaceAdd(object handler)
    {
      BoundDispEvent.VerifyHandler(handler);
      ComEventsSink.FromRuntimeCallableWrapper(this._rcw, this._sourceIid, true).AddHandler(this._dispid, handler);
      return (object) this;
    }

    private object InPlaceSubtract(object handler)
    {
      BoundDispEvent.VerifyHandler(handler);
      ComEventsSink.FromRuntimeCallableWrapper(this._rcw, this._sourceIid, false)?.RemoveHandler(this._dispid, handler);
      return (object) this;
    }
  }
}
