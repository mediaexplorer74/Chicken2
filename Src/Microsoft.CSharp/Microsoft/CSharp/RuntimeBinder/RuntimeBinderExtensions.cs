// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.RuntimeBinderExtensions
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal static class RuntimeBinderExtensions
  {
    public static bool IsNullableType(this Type type)
    {
      return type.IsConstructedGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>);
    }

    public static bool IsEquivalentTo(this MemberInfo mi1, MemberInfo mi2)
    {
      if (mi1 == (MemberInfo) null || mi2 == (MemberInfo) null)
        return mi1 == (MemberInfo) null && mi2 == (MemberInfo) null;
      if (mi1.Equals((object) mi2))
        return true;
      MethodInfo methodInfo1 = mi1 as MethodInfo;
      if ((object) methodInfo1 != null)
      {
        MethodInfo methodInfo2 = mi2 as MethodInfo;
        if ((object) methodInfo2 == null || methodInfo1.IsGenericMethod != methodInfo2.IsGenericMethod)
          return false;
        if (methodInfo1.IsGenericMethod)
        {
          methodInfo1 = methodInfo1.GetGenericMethodDefinition();
          methodInfo2 = methodInfo2.GetGenericMethodDefinition();
          if (methodInfo1.GetGenericArguments().Length != methodInfo2.GetGenericArguments().Length)
            return false;
        }
        return methodInfo1 != methodInfo2 && methodInfo1.CallingConvention == methodInfo2.CallingConvention && methodInfo1.Name == methodInfo2.Name && methodInfo1.DeclaringType.IsGenericallyEqual(methodInfo2.DeclaringType) && methodInfo1.ReturnType.IsGenericallyEquivalentTo(methodInfo2.ReturnType, (MemberInfo) methodInfo1, (MemberInfo) methodInfo2) && methodInfo1.AreParametersEquivalent((MethodBase) methodInfo2);
      }
      ConstructorInfo method1 = mi1 as ConstructorInfo;
      if ((object) method1 != null)
      {
        ConstructorInfo method2 = mi2 as ConstructorInfo;
        return (object) method2 != null && method1 != method2 && method1.CallingConvention == method2.CallingConvention && method1.DeclaringType.IsGenericallyEqual(method2.DeclaringType) && method1.AreParametersEquivalent((MethodBase) method2);
      }
      PropertyInfo member1 = mi1 as PropertyInfo;
      if ((object) member1 != null)
      {
        PropertyInfo member2 = mi2 as PropertyInfo;
        if ((object) member2 != null && member1 != member2 && member1.Name == member2.Name && member1.DeclaringType.IsGenericallyEqual(member2.DeclaringType) && member1.PropertyType.IsGenericallyEquivalentTo(member2.PropertyType, (MemberInfo) member1, (MemberInfo) member2) && member1.GetGetMethod(true).IsEquivalentTo((MemberInfo) member2.GetGetMethod(true)))
          return member1.GetSetMethod(true).IsEquivalentTo((MemberInfo) member2.GetSetMethod(true));
      }
      return false;
    }

    private static bool AreParametersEquivalent(this MethodBase method1, MethodBase method2)
    {
      ParameterInfo[] parameters1 = method1.GetParameters();
      ParameterInfo[] parameters2 = method2.GetParameters();
      if (parameters1.Length != parameters2.Length)
        return false;
      for (int index = 0; index < parameters1.Length; ++index)
      {
        if (!parameters1[index].IsEquivalentTo(parameters2[index], method1, method2))
          return false;
      }
      return true;
    }

    private static bool IsEquivalentTo(
      this ParameterInfo pi1,
      ParameterInfo pi2,
      MethodBase method1,
      MethodBase method2)
    {
      return pi1 == null || pi2 == null ? pi1 == null && pi2 == null : pi1.Equals((object) pi2) || pi1.ParameterType.IsGenericallyEquivalentTo(pi2.ParameterType, (MemberInfo) method1, (MemberInfo) method2);
    }

    private static bool IsGenericallyEqual(this Type t1, Type t2)
    {
      if (t1 == (Type) null || t2 == (Type) null)
        return t1 == (Type) null && t2 == (Type) null;
      if (t1.Equals(t2))
        return true;
      return (t1.IsConstructedGenericType || t2.IsConstructedGenericType) && (t1.IsConstructedGenericType ? t1.GetGenericTypeDefinition() : t1).Equals(t2.IsConstructedGenericType ? t2.GetGenericTypeDefinition() : t2);
    }

    private static bool IsGenericallyEquivalentTo(
      this Type t1,
      Type t2,
      MemberInfo member1,
      MemberInfo member2)
    {
      if (t1.Equals(t2))
        return true;
      if (t1.IsGenericParameter)
      {
        if (!t2.IsGenericParameter)
          return t1.IsTypeParameterEquivalentToTypeInst(t2, member2);
        if (t1.DeclaringMethod == (MethodBase) null && member1.DeclaringType.Equals(t1.DeclaringType))
        {
          if (!(t2.DeclaringMethod == (MethodBase) null) || !member2.DeclaringType.Equals(t2.DeclaringType))
            return t1.IsTypeParameterEquivalentToTypeInst(t2, member2);
        }
        else if (t2.DeclaringMethod == (MethodBase) null && member2.DeclaringType.Equals(t2.DeclaringType))
          return t2.IsTypeParameterEquivalentToTypeInst(t1, member1);
        return false;
      }
      if (t2.IsGenericParameter)
        return t2.IsTypeParameterEquivalentToTypeInst(t1, member1);
      if (t1.IsGenericType && t2.IsGenericType)
      {
        Type[] genericArguments1 = t1.GetGenericArguments();
        Type[] genericArguments2 = t2.GetGenericArguments();
        if (genericArguments1.Length == genericArguments2.Length)
        {
          if (!t1.IsGenericallyEqual(t2))
            return false;
          for (int index = 0; index < genericArguments1.Length; ++index)
          {
            if (!genericArguments1[index].IsGenericallyEquivalentTo(genericArguments2[index], member1, member2))
              return false;
          }
          return true;
        }
      }
      return t1.IsArray && t2.IsArray ? t1.GetArrayRank() == t2.GetArrayRank() && t1.GetElementType().IsGenericallyEquivalentTo(t2.GetElementType(), member1, member2) : (t1.IsByRef && t2.IsByRef || t1.IsPointer && t2.IsPointer) && t1.GetElementType().IsGenericallyEquivalentTo(t2.GetElementType(), member1, member2);
    }

    private static bool IsTypeParameterEquivalentToTypeInst(
      this Type typeParam,
      Type typeInst,
      MemberInfo member)
    {
      if (!(typeParam.DeclaringMethod != (MethodBase) null))
        return member.DeclaringType.GetGenericArguments()[typeParam.GenericParameterPosition].Equals(typeInst);
      if ((object) (member as MethodBase) == null)
        return false;
      MethodBase methodBase = (MethodBase) member;
      int parameterPosition = typeParam.GenericParameterPosition;
      Type[] genericArguments = methodBase.IsGenericMethod ? methodBase.GetGenericArguments() : (Type[]) null;
      return genericArguments != null && genericArguments.Length > parameterPosition && genericArguments[parameterPosition].Equals(typeInst);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    public static string GetIndexerName(this Type type)
    {
      string typeIndexerName = RuntimeBinderExtensions.GetTypeIndexerName(type);
      if (typeIndexerName == null && type.IsInterface)
      {
        foreach (Type type1 in type.GetInterfaces())
        {
          typeIndexerName = RuntimeBinderExtensions.GetTypeIndexerName(type1);
          if (typeIndexerName != null)
            break;
        }
      }
      return typeIndexerName;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static string GetTypeIndexerName(Type type)
    {
      string memberName = type.GetCustomAttribute<DefaultMemberAttribute>()?.MemberName;
      if (memberName != null)
      {
        foreach (PropertyInfo property in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (property.Name == memberName && property.GetIndexParameters().Length != 0)
            return memberName;
        }
      }
      return (string) null;
    }
  }
}
