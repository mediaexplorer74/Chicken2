// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.ComEventsMethod
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Generic;
using System.Reflection;
using System.Threading;

#nullable disable
namespace System.Runtime.InteropServices
{
  internal sealed class ComEventsMethod
  {
    private ComEventsMethod.DelegateWrapper[] _delegateWrappers = Array.Empty<ComEventsMethod.DelegateWrapper>();
    private readonly int _dispid;
    private ComEventsMethod _next;

    public ComEventsMethod(int dispid) => this._dispid = dispid;

    public static ComEventsMethod Find(ComEventsMethod methods, int dispid)
    {
      while (methods != null && methods._dispid != dispid)
        methods = methods._next;
      return methods;
    }

    public static ComEventsMethod Add(ComEventsMethod methods, ComEventsMethod method)
    {
      method._next = methods;
      return method;
    }

    public static ComEventsMethod Remove(ComEventsMethod methods, ComEventsMethod method)
    {
      if (methods == method)
        return methods._next;
      ComEventsMethod comEventsMethod = methods;
      while (comEventsMethod != null && comEventsMethod._next != method)
        comEventsMethod = comEventsMethod._next;
      if (comEventsMethod != null)
        comEventsMethod._next = method._next;
      return methods;
    }

    public bool Empty => this._delegateWrappers.Length == 0;

    public void AddDelegate(Delegate d, bool wrapArgs = false)
    {
      ComEventsMethod.DelegateWrapper[] delegateWrappers;
      ComEventsMethod.DelegateWrapper[] newWrappers;
      do
      {
        delegateWrappers = this._delegateWrappers;
        newWrappers = new ComEventsMethod.DelegateWrapper[delegateWrappers.Length + 1];
        delegateWrappers.CopyTo((Array) newWrappers, 0);
        ComEventsMethod.DelegateWrapper[] delegateWrapperArray = newWrappers;
        delegateWrapperArray[delegateWrapperArray.Length - 1] = new ComEventsMethod.DelegateWrapper(d, wrapArgs);
      }
      while (!this.PublishNewWrappers(newWrappers, delegateWrappers));
    }

    public void RemoveDelegate(Delegate d, bool wrapArgs = false)
    {
      ComEventsMethod.DelegateWrapper[] delegateWrappers;
      ComEventsMethod.DelegateWrapper[] delegateWrapperArray;
      do
      {
        delegateWrappers = this._delegateWrappers;
        int num = -1;
        for (int index = 0; index < delegateWrappers.Length; ++index)
        {
          ComEventsMethod.DelegateWrapper delegateWrapper = delegateWrappers[index];
          if (delegateWrapper.Delegate == d && delegateWrapper.WrapArgs == wrapArgs)
          {
            num = index;
            break;
          }
        }
        if (num < 0)
          break;
        delegateWrapperArray = new ComEventsMethod.DelegateWrapper[delegateWrappers.Length - 1];
        Span<ComEventsMethod.DelegateWrapper> span = delegateWrappers.AsSpan<ComEventsMethod.DelegateWrapper>(0, num);
        span.CopyTo((Span<ComEventsMethod.DelegateWrapper>) delegateWrapperArray);
        span = delegateWrappers.AsSpan<ComEventsMethod.DelegateWrapper>(num + 1);
        span.CopyTo(delegateWrapperArray.AsSpan<ComEventsMethod.DelegateWrapper>(num));
      }
      while (!this.PublishNewWrappers(delegateWrapperArray, delegateWrappers));
    }

    public void RemoveDelegates(Func<Delegate, bool> condition)
    {
      ComEventsMethod.DelegateWrapper[] delegateWrappers;
      List<ComEventsMethod.DelegateWrapper> delegateWrapperList;
      do
      {
        delegateWrappers = this._delegateWrappers;
        delegateWrapperList = new List<ComEventsMethod.DelegateWrapper>((IEnumerable<ComEventsMethod.DelegateWrapper>) delegateWrappers);
        delegateWrapperList.RemoveAll((Predicate<ComEventsMethod.DelegateWrapper>) (w => condition(w.Delegate)));
      }
      while (!this.PublishNewWrappers(delegateWrapperList.ToArray(), delegateWrappers));
    }

    public object Invoke(object[] args)
    {
      object obj = (object) null;
      foreach (ComEventsMethod.DelegateWrapper delegateWrapper in this._delegateWrappers)
        obj = delegateWrapper.Invoke(args);
      return obj;
    }

    private bool PublishNewWrappers(
      ComEventsMethod.DelegateWrapper[] newWrappers,
      ComEventsMethod.DelegateWrapper[] currentMaybe)
    {
      return Interlocked.CompareExchange<ComEventsMethod.DelegateWrapper[]>(ref this._delegateWrappers, newWrappers, currentMaybe) == currentMaybe;
    }

    public class DelegateWrapper
    {
      private bool _once;
      private int _expectedParamsCount;
      private Type[] _cachedTargetTypes;

      public DelegateWrapper(Delegate d, bool wrapArgs)
      {
        this.Delegate = d;
        this.WrapArgs = wrapArgs;
      }

      public Delegate Delegate { get; set; }

      public bool WrapArgs { get; }

      public object Invoke(object[] args)
      {
        if ((object) this.Delegate == null)
          return (object) null;
        if (!this._once)
        {
          this.PreProcessSignature();
          this._once = true;
        }
        if (this._cachedTargetTypes != null && this._expectedParamsCount == args.Length)
        {
          for (int index = 0; index < this._expectedParamsCount; ++index)
          {
            Type cachedTargetType = this._cachedTargetTypes[index];
            if ((object) cachedTargetType != null)
              args[index] = Enum.ToObject(cachedTargetType, args[index]);
          }
        }
        Delegate @delegate = this.Delegate;
        object[] objArray;
        if (!this.WrapArgs)
          objArray = args;
        else
          objArray = new object[1]{ (object) args };
        return @delegate.DynamicInvoke(objArray);
      }

      private void PreProcessSignature()
      {
        ParameterInfo[] parameters = this.Delegate.Method.GetParameters();
        this._expectedParamsCount = parameters.Length;
        Type[] typeArray = (Type[]) null;
        for (int index = 0; index < this._expectedParamsCount; ++index)
        {
          ParameterInfo parameterInfo = parameters[index];
          if (parameterInfo.ParameterType.IsByRef && parameterInfo.ParameterType.HasElementType && parameterInfo.ParameterType.GetElementType().IsEnum)
          {
            if (typeArray == null)
              typeArray = new Type[this._expectedParamsCount];
            typeArray[index] = parameterInfo.ParameterType.GetElementType();
          }
        }
        if (typeArray == null)
          return;
        this._cachedTargetTypes = typeArray;
      }
    }
  }
}
