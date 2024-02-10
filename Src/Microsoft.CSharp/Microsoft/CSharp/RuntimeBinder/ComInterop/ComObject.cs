// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.ComObject
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal class ComObject : IDynamicMetaObjectProvider
  {
    private static readonly object s_comObjectInfoKey = new object();

    internal ComObject(object rcw) => this.RuntimeCallableWrapper = rcw;

    internal object RuntimeCallableWrapper { get; }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static ComObject ObjectToComObject(object rcw)
    {
      object comObjectData1 = Marshal.GetComObjectData(rcw, ComObject.s_comObjectInfoKey);
      if (comObjectData1 != null)
        return (ComObject) comObjectData1;
      lock (ComObject.s_comObjectInfoKey)
      {
        object comObjectData2 = Marshal.GetComObjectData(rcw, ComObject.s_comObjectInfoKey);
        if (comObjectData2 != null)
          return (ComObject) comObjectData2;
        ComObject comObject = ComObject.CreateComObject(rcw);
        if (!Marshal.SetComObjectData(rcw, ComObject.s_comObjectInfoKey, (object) comObject))
          throw Error.SetComObjectDataFailed();
        return comObject;
      }
    }

    internal static MemberExpression RcwFromComObject(Expression comObject)
    {
      return Expression.Property(Helpers.Convert(comObject, typeof (ComObject)), typeof (ComObject).GetProperty("RuntimeCallableWrapper", BindingFlags.Instance | BindingFlags.NonPublic));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static MethodCallExpression RcwToComObject(Expression rcw)
    {
      return Expression.Call(typeof (ComObject).GetMethod("ObjectToComObject"), Helpers.Convert(rcw, typeof (object)));
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static ComObject CreateComObject(object rcw)
    {
      return rcw is IDispatch rcw1 ? (ComObject) new IDispatchComObject(rcw1) : new ComObject(rcw);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal virtual IList<string> GetMemberNames(bool dataOnly)
    {
      return (IList<string>) Array.Empty<string>();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal virtual IList<KeyValuePair<string, object>> GetMembers(IEnumerable<string> names)
    {
      return (IList<KeyValuePair<string, object>>) Array.Empty<KeyValuePair<string, object>>();
    }

    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
    {
      return (DynamicMetaObject) new ComFallbackMetaObject(parameter, BindingRestrictions.Empty, (object) this);
    }
  }
}
