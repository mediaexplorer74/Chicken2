// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.ComInterop.UnsafeMethods
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.ComInterop
{
  internal static class UnsafeMethods
  {
    private static readonly object s_lock = new object();
    private static ModuleBuilder s_dynamicModule;

    public static unsafe IntPtr ConvertInt32ByrefToPtr(ref int value)
    {
      return (IntPtr) Unsafe.AsPointer<int>(ref value);
    }

    public static unsafe IntPtr ConvertVariantByrefToPtr(ref Variant value)
    {
      return (IntPtr) Unsafe.AsPointer<Variant>(ref value);
    }

    internal static Variant GetVariantForObject(object obj)
    {
      Variant variant = new Variant();
      if (obj == null)
        return variant;
      UnsafeMethods.InitVariantForObject(obj, ref variant);
      return variant;
    }

    internal static void InitVariantForObject(object obj, ref Variant variant)
    {
      if (obj is IDispatch)
        variant.AsDispatch = obj;
      else
        Marshal.GetNativeVariantForObject(obj, UnsafeMethods.ConvertVariantByrefToPtr(ref variant));
    }

    public static object GetObjectForVariant(Variant variant)
    {
      return Marshal.GetObjectForNativeVariant(UnsafeMethods.ConvertVariantByrefToPtr(ref variant));
    }

    public static unsafe int IUnknownRelease(IntPtr interfacePointer)
    {
      // ISSUE: cast to a function pointer type
      // ISSUE: function pointer call
      return __calli((__FnPtr<int (IntPtr)>) *(IntPtr*) (*(IntPtr*) (void*) interfacePointer + new IntPtr(2) * sizeof (void*)))(interfacePointer);
    }

    public static void IUnknownReleaseNotZero(IntPtr interfacePointer)
    {
      if (!(interfacePointer != IntPtr.Zero))
        return;
      UnsafeMethods.IUnknownRelease(interfacePointer);
    }

    public static unsafe int IDispatchInvoke(
      IntPtr dispatchPointer,
      int memberDispId,
      INVOKEKIND flags,
      ref DISPPARAMS dispParams,
      out Variant result,
      out ExcepInfo excepInfo,
      out uint argErr)
    {
      Guid guid = new Guid();
      fixed (DISPPARAMS* dispparamsPtr = &dispParams)
        fixed (Variant* variantPtr = &result)
          fixed (ExcepInfo* excepInfoPtr = &excepInfo)
            fixed (uint* numPtr = &argErr)
            {
              // ISSUE: cast to a function pointer type
              __FnPtr<int (IntPtr, int, Guid*, int, ushort, DISPPARAMS*, Variant*, ExcepInfo*, uint*)> local = (__FnPtr<int (IntPtr, int, Guid*, int, ushort, DISPPARAMS*, Variant*, ExcepInfo*, uint*)>) *(IntPtr*) (*(IntPtr*) (void*) dispatchPointer + new IntPtr(6) * sizeof (void*));
              // ISSUE: function pointer call
              int num = __calli(local)((uint*) dispatchPointer, (ExcepInfo*) memberDispId, (Variant*) &guid, (DISPPARAMS*) 0, (ushort) flags, (int) dispparamsPtr, (Guid*) variantPtr, (int) excepInfoPtr, (IntPtr) numPtr);
              if (num == -2147352573 && (flags & INVOKEKIND.INVOKE_FUNC) != (INVOKEKIND) 0 && (flags & (INVOKEKIND.INVOKE_PROPERTYPUT | INVOKEKIND.INVOKE_PROPERTYPUTREF)) == (INVOKEKIND) 0)
              {
                // ISSUE: function pointer call
                num = __calli(local)((uint*) dispatchPointer, (ExcepInfo*) memberDispId, (Variant*) &guid, (DISPPARAMS*) 0, (ushort) 1, (int) dispparamsPtr, (Guid*) null, (int) excepInfoPtr, (IntPtr) numPtr);
              }
              return num;
            }
    }

    public static IntPtr GetIdsOfNamedParameters(
      IDispatch dispatch,
      string[] names,
      int methodDispId,
      out GCHandle pinningHandle)
    {
      pinningHandle = GCHandle.Alloc((object) null, GCHandleType.Pinned);
      int[] numArray = new int[names.Length];
      Guid empty = Guid.Empty;
      int idsOfNames = dispatch.TryGetIDsOfNames(ref empty, names, (uint) names.Length, 0, numArray);
      if (idsOfNames < 0)
        Marshal.ThrowExceptionForHR(idsOfNames);
      int[] arr = methodDispId == numArray[0] ? numArray.RemoveFirst<int>() : throw Error.GetIDsOfNamesInvalid((object) names[0]);
      pinningHandle.Target = (object) arr;
      return Marshal.UnsafeAddrOfPinnedArrayElement<int>(arr, 0);
    }

    internal static ModuleBuilder DynamicModule
    {
      get
      {
        if ((Module) UnsafeMethods.s_dynamicModule != (Module) null)
          return UnsafeMethods.s_dynamicModule;
        lock (UnsafeMethods.s_lock)
        {
          if ((Module) UnsafeMethods.s_dynamicModule == (Module) null)
          {
            string str = typeof (VariantArray).Namespace + ".DynamicAssembly";
            UnsafeMethods.s_dynamicModule = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(str), AssemblyBuilderAccess.Run).DefineDynamicModule(str);
          }
          return UnsafeMethods.s_dynamicModule;
        }
      }
    }
  }
}
