// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.DispCallable
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal sealed class DispCallable : IPseudoComObject
  {
    internal DispCallable(IDispatchComObject dispatch, string memberName, int dispId)
    {
      this.DispatchComObject = dispatch;
      this.MemberName = memberName;
      this.DispId = dispId;
    }

    public override string ToString() => "<bound dispmethod " + this.MemberName + ">";

    public IDispatchComObject DispatchComObject { get; }

    public IDispatch DispatchObject => this.DispatchComObject.DispatchObject;

    public string MemberName { get; }

    public int DispId { get; }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public DynamicMetaObject GetMetaObject(Expression parameter)
    {
      return (DynamicMetaObject) new DispCallableMetaObject(parameter, this);
    }

    public override bool Equals(object obj)
    {
      return obj is DispCallable dispCallable && dispCallable.DispatchComObject == this.DispatchComObject && dispCallable.DispId == this.DispId;
    }

    public override int GetHashCode() => this.DispatchComObject.GetHashCode() ^ this.DispId;
  }
}
