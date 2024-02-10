// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.BinderEquivalence
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal static class BinderEquivalence
  {
    private static int cachedBinderCount;
    private static readonly ConcurrentDictionary<ICSharpBinder, ICSharpBinder> binderEquivalenceCache = new ConcurrentDictionary<ICSharpBinder, ICSharpBinder>(2, 32, (IEqualityComparer<ICSharpBinder>) new BinderEquivalence.BinderEqualityComparer());

    internal static T TryGetExisting<T>(this T binder) where T : ICSharpBinder
    {
      ICSharpBinder orAdd = BinderEquivalence.binderEquivalenceCache.GetOrAdd((ICSharpBinder) binder, (ICSharpBinder) binder);
      if (orAdd == (object) binder && (uint) Interlocked.Increment(ref BinderEquivalence.cachedBinderCount) > 4096U)
      {
        BinderEquivalence.binderEquivalenceCache.Clear();
        BinderEquivalence.cachedBinderCount = 0;
      }
      return (T) orAdd;
    }

    internal sealed class BinderEqualityComparer : IEqualityComparer<ICSharpBinder>
    {
      public bool Equals(ICSharpBinder x, ICSharpBinder y) => x.IsEquivalentTo(y);

      public int GetHashCode(ICSharpBinder obj) => obj.GetGetBinderEquivalenceHash();
    }
  }
}
