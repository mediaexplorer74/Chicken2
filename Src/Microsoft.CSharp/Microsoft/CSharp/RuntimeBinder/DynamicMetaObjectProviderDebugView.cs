// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.DynamicMetaObjectProviderDebugView
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.ComInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal sealed class DynamicMetaObjectProviderDebugView
  {
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private IList<KeyValuePair<string, object>> results;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly object obj;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly ParameterExpression parameter = Expression.Parameter(typeof (object), "debug");
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly Type ComObjectType = Type.GetType("System.__ComObject, System.Private.CoreLib");

    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    internal DynamicMetaObjectProviderDebugView.DynamicProperty[] Items
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        if (this.results == null || this.results.Count == 0)
        {
          this.results = DynamicMetaObjectProviderDebugView.QueryDynamicObject(this.obj);
          if (this.results == null || this.results.Count == 0)
            throw new DynamicMetaObjectProviderDebugView.DynamicDebugViewEmptyException();
        }
        DynamicMetaObjectProviderDebugView.DynamicProperty[] items = new DynamicMetaObjectProviderDebugView.DynamicProperty[this.results.Count];
        for (int index1 = 0; index1 < this.results.Count; ++index1)
        {
          DynamicMetaObjectProviderDebugView.DynamicProperty[] dynamicPropertyArray = items;
          int index2 = index1;
          KeyValuePair<string, object> result = this.results[index1];
          string key = result.Key;
          result = this.results[index1];
          object obj = result.Value;
          DynamicMetaObjectProviderDebugView.DynamicProperty dynamicProperty = new DynamicMetaObjectProviderDebugView.DynamicProperty(key, obj);
          dynamicPropertyArray[index2] = dynamicProperty;
        }
        return items;
      }
    }

    public DynamicMetaObjectProviderDebugView(object arg) => this.obj = arg;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TryEvalBinaryOperators<T1, T2>(
      T1 arg1,
      T2 arg2,
      CSharpArgumentInfoFlags arg1Flags,
      CSharpArgumentInfoFlags arg2Flags,
      ExpressionType opKind,
      Type accessibilityContext)
    {
      CSharpArgumentInfo csharpArgumentInfo1 = CSharpArgumentInfo.Create(arg1Flags, (string) null);
      CSharpArgumentInfo csharpArgumentInfo2 = CSharpArgumentInfo.Create(arg2Flags, (string) null);
      CallSite<Func<CallSite, T1, T2, object>> callSite = CallSite<Func<CallSite, T1, T2, object>>.Create((CallSiteBinder) new CSharpBinaryOperationBinder(opKind, false, CSharpBinaryOperationFlags.None, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        csharpArgumentInfo1,
        csharpArgumentInfo2
      }));
      return callSite.Target((CallSite) callSite, arg1, arg2);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TryEvalUnaryOperators<T>(
      T obj,
      ExpressionType oper,
      Type accessibilityContext)
    {
      if (oper == ExpressionType.IsTrue || oper == ExpressionType.IsFalse)
      {
        CallSite<Func<CallSite, T, bool>> callSite = CallSite<Func<CallSite, T, bool>>.Create((CallSiteBinder) new CSharpUnaryOperationBinder(oper, false, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
        }));
        return (object) callSite.Target((CallSite) callSite, obj);
      }
      CallSite<Func<CallSite, T, object>> callSite1 = CallSite<Func<CallSite, T, object>>.Create((CallSiteBinder) new CSharpUnaryOperationBinder(oper, false, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      }));
      return callSite1.Target((CallSite) callSite1, obj);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static K TryEvalCast<T, K>(
      T obj,
      Type type,
      CSharpBinderFlags kind,
      Type accessibilityContext)
    {
      CallSite<Func<CallSite, T, K>> callSite = CallSite<Func<CallSite, T, K>>.Create(Binder.Convert(kind, type, accessibilityContext));
      return callSite.Target((CallSite) callSite, obj);
    }

    private static void CreateDelegateSignatureAndArgumentInfos(
      object[] args,
      Type[] argTypes,
      CSharpArgumentInfoFlags[] argFlags,
      out Type[] delegateSignatureTypes,
      out CSharpArgumentInfo[] argInfos)
    {
      int length = args.Length;
      delegateSignatureTypes = new Type[length + 2];
      delegateSignatureTypes[0] = typeof (CallSite);
      argInfos = new CSharpArgumentInfo[length];
      for (int index = 0; index < length; ++index)
      {
        delegateSignatureTypes[index + 1] = !(argTypes[index] != (Type) null) ? (args[index] == null ? typeof (object) : args[index].GetType()) : argTypes[index];
        argInfos[index] = CSharpArgumentInfo.Create(argFlags[index], (string) null);
      }
      delegateSignatureTypes[length + 1] = typeof (object);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static object CreateDelegateAndInvoke(
      Type[] delegateSignatureTypes,
      CallSiteBinder binder,
      object[] args)
    {
      CallSite callSite = CallSite.Create(Expression.GetDelegateType(delegateSignatureTypes), binder);
      Delegate @delegate = (Delegate) callSite.GetType().GetField("Target").GetValue((object) callSite);
      object[] objArray = new object[args.Length + 1];
      objArray[0] = (object) callSite;
      args.CopyTo((Array) objArray, 1);
      return @delegate.DynamicInvoke(objArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TryEvalMethodVarArgs(
      object[] methodArgs,
      Type[] argTypes,
      CSharpArgumentInfoFlags[] argFlags,
      string methodName,
      Type accessibilityContext,
      Type[] typeArguments)
    {
      Type[] delegateSignatureTypes = (Type[]) null;
      CSharpArgumentInfo[] argInfos = (CSharpArgumentInfo[]) null;
      DynamicMetaObjectProviderDebugView.CreateDelegateSignatureAndArgumentInfos(methodArgs, argTypes, argFlags, out delegateSignatureTypes, out argInfos);
      CallSiteBinder binder = !string.IsNullOrEmpty(methodName) ? (CallSiteBinder) new CSharpInvokeMemberBinder(CSharpCallFlags.ResultDiscarded, methodName, accessibilityContext, (IEnumerable<Type>) typeArguments, (IEnumerable<CSharpArgumentInfo>) argInfos) : (CallSiteBinder) new CSharpInvokeBinder(CSharpCallFlags.ResultDiscarded, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) argInfos);
      return DynamicMetaObjectProviderDebugView.CreateDelegateAndInvoke(delegateSignatureTypes, binder, methodArgs);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TryGetMemberValue<T>(
      T obj,
      string propName,
      Type accessibilityContext,
      bool isResultIndexed)
    {
      CallSite<Func<CallSite, T, object>> callSite = CallSite<Func<CallSite, T, object>>.Create((CallSiteBinder) new CSharpGetMemberBinder(propName, (isResultIndexed ? 1 : 0) != 0, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
      {
        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
      }));
      return callSite.Target((CallSite) callSite, obj);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TryGetMemberValueVarArgs(
      object[] propArgs,
      Type[] argTypes,
      CSharpArgumentInfoFlags[] argFlags,
      Type accessibilityContext)
    {
      Type[] delegateSignatureTypes = (Type[]) null;
      CSharpArgumentInfo[] argInfos = (CSharpArgumentInfo[]) null;
      DynamicMetaObjectProviderDebugView.CreateDelegateSignatureAndArgumentInfos(propArgs, argTypes, argFlags, out delegateSignatureTypes, out argInfos);
      CallSiteBinder binder = (CallSiteBinder) new CSharpGetIndexBinder(accessibilityContext, (IEnumerable<CSharpArgumentInfo>) argInfos);
      return DynamicMetaObjectProviderDebugView.CreateDelegateAndInvoke(delegateSignatureTypes, binder, propArgs);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TrySetMemberValue<TObject, TValue>(
      TObject obj,
      string propName,
      TValue value,
      CSharpArgumentInfoFlags valueFlags,
      Type accessibilityContext)
    {
      CSharpArgumentInfo csharpArgumentInfo1 = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null);
      CSharpArgumentInfo csharpArgumentInfo2 = CSharpArgumentInfo.Create(valueFlags, (string) null);
      CallSite<Func<CallSite, TObject, TValue, object>> callSite = CallSite<Func<CallSite, TObject, TValue, object>>.Create((CallSiteBinder) new CSharpSetMemberBinder(propName, false, false, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
      {
        csharpArgumentInfo1,
        csharpArgumentInfo2
      }));
      return callSite.Target((CallSite) callSite, obj, value);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static object TrySetMemberValueVarArgs(
      object[] propArgs,
      Type[] argTypes,
      CSharpArgumentInfoFlags[] argFlags,
      Type accessibilityContext)
    {
      Type[] delegateSignatureTypes = (Type[]) null;
      CSharpArgumentInfo[] argInfos = (CSharpArgumentInfo[]) null;
      DynamicMetaObjectProviderDebugView.CreateDelegateSignatureAndArgumentInfos(propArgs, argTypes, argFlags, out delegateSignatureTypes, out argInfos);
      CallSiteBinder binder = (CallSiteBinder) new CSharpSetIndexBinder(false, false, accessibilityContext, (IEnumerable<CSharpArgumentInfo>) argInfos);
      return DynamicMetaObjectProviderDebugView.CreateDelegateAndInvoke(delegateSignatureTypes, binder, propArgs);
    }

    internal static object TryGetMemberValue(object obj, string name, bool ignoreException)
    {
      bool ignoreCase = false;
      CallSite<Func<CallSite, object, object>> callSite = CallSite<Func<CallSite, object, object>>.Create((CallSiteBinder) new GetMemberValueBinder(name, ignoreCase));
      try
      {
        return callSite.Target((CallSite) callSite, obj);
      }
      catch (DynamicBindingFailedException ex)
      {
        if (ignoreException)
          return (object) null;
        throw;
      }
      catch (MissingMemberException ex)
      {
        if (ignoreException)
          return (object) SR.GetValueonWriteOnlyProperty;
        throw;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static IList<KeyValuePair<string, object>> QueryDynamicObject(object obj)
    {
      if (obj is IDynamicMetaObjectProvider metaObjectProvider)
      {
        List<string> stringList = new List<string>(metaObjectProvider.GetMetaObject((Expression) DynamicMetaObjectProviderDebugView.parameter).GetDynamicMemberNames());
        stringList.Sort();
        List<KeyValuePair<string, object>> keyValuePairList = new List<KeyValuePair<string, object>>();
        foreach (string str in stringList)
        {
          object memberValue;
          if ((memberValue = DynamicMetaObjectProviderDebugView.TryGetMemberValue(obj, str, true)) != null)
            keyValuePairList.Add(new KeyValuePair<string, object>(str, memberValue));
        }
        return (IList<KeyValuePair<string, object>>) keyValuePairList;
      }
      if (obj == null || !DynamicMetaObjectProviderDebugView.ComObjectType.IsAssignableFrom(obj.GetType()))
        return (IList<KeyValuePair<string, object>>) Array.Empty<KeyValuePair<string, object>>();
      IList<string> dynamicDataMemberNames = ComBinder.GetDynamicDataMemberNames(obj);
      return ComBinder.GetDynamicDataMembers(obj, (IEnumerable<string>) dynamicDataMemberNames.OrderBy<string, string>((Func<string, string>) (n => n)));
    }

    [DebuggerDisplay("{value}", Name = "{name, nq}", Type = "{type, nq}")]
    internal sealed class DynamicProperty
    {
      [DebuggerBrowsable(DebuggerBrowsableState.Never)]
      private readonly string name;
      [DebuggerBrowsable(DebuggerBrowsableState.Never)]
      private readonly object value;
      [DebuggerBrowsable(DebuggerBrowsableState.Never)]
      private readonly string type;

      public DynamicProperty(string name, object value)
      {
        this.name = name;
        this.value = value;
        this.type = value == null ? "<null>" : value.GetType().ToString();
      }
    }

    [Serializable]
    internal sealed class DynamicDebugViewEmptyException : Exception
    {
      public DynamicDebugViewEmptyException()
      {
      }

      private DynamicDebugViewEmptyException(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
      }

      public string Empty => SR.EmptyDynamicView;
    }
  }
}
