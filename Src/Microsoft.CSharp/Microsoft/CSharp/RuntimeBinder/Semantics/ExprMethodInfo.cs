// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprMethodInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprMethodInfo : ExprWithType
  {
    public ExprMethodInfo(
      CType type,
      MethodSymbol method,
      AggregateType methodType,
      TypeArray methodParameters)
      : base(ExpressionKind.MethodInfo, type)
    {
      this.Method = new MethWithInst(method, methodType, methodParameters);
    }

    public MethWithInst Method { get; }

    public MethodInfo MethodInfo
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        AggregateType ats = this.Method.Ats;
        MethodSymbol methodSymbol = this.Method.Meth();
        TypeArray typeArray1 = TypeManager.SubstTypeArray(methodSymbol.Params, ats, methodSymbol.typeVars);
        TypeManager.SubstType(methodSymbol.RetType, ats, methodSymbol.typeVars);
        System.Type type = ats.AssociatedSystemType;
        MethodInfo associatedMemberInfo = methodSymbol.AssociatedMemberInfo as MethodInfo;
        if (!type.IsGenericType && !type.IsNested)
          type = associatedMemberInfo.DeclaringType;
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (method.HasSameMetadataDefinitionAs((MemberInfo) associatedMemberInfo))
          {
            bool flag = true;
            ParameterInfo[] parameters = method.GetParameters();
            for (int i = 0; i < typeArray1.Count; ++i)
            {
              if (!ExprWithType.TypesAreEqual(parameters[i].ParameterType, typeArray1[i].AssociatedSystemType))
              {
                flag = false;
                break;
              }
            }
            if (flag)
            {
              if (!method.IsGenericMethod)
                return method;
              TypeArray typeArgs = this.Method.TypeArgs;
              int count = typeArgs != null ? typeArgs.Count : 0;
              System.Type[] typeArray2 = new System.Type[count];
              if (count > 0)
              {
                for (int i = 0; i < this.Method.TypeArgs.Count; ++i)
                  typeArray2[i] = this.Method.TypeArgs[i].AssociatedSystemType;
              }
              return method.MakeGenericMethod(typeArray2);
            }
          }
        }
        throw Error.InternalCompilerError();
      }
    }

    public ConstructorInfo ConstructorInfo
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        AggregateType ats = this.Method.Ats;
        MethodSymbol methodSymbol = this.Method.Meth();
        TypeArray typeArray = TypeManager.SubstTypeArray(methodSymbol.Params, ats);
        System.Type type = ats.AssociatedSystemType;
        ConstructorInfo associatedMemberInfo = (ConstructorInfo) methodSymbol.AssociatedMemberInfo;
        if (!type.IsGenericType && !type.IsNested)
          type = associatedMemberInfo.DeclaringType;
        foreach (ConstructorInfo constructor in type.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (constructor.HasSameMetadataDefinitionAs((MemberInfo) associatedMemberInfo))
          {
            bool flag = true;
            ParameterInfo[] parameters = constructor.GetParameters();
            for (int i = 0; i < typeArray.Count; ++i)
            {
              if (!ExprWithType.TypesAreEqual(parameters[i].ParameterType, typeArray[i].AssociatedSystemType))
              {
                flag = false;
                break;
              }
            }
            if (flag)
              return constructor;
          }
        }
        throw Error.InternalCompilerError();
      }
    }

    public override object Object
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        return (object) this.MethodInfo;
      }
    }
  }
}
