// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprPropertyInfo
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExprPropertyInfo : ExprWithType
  {
    public ExprPropertyInfo(CType type, PropertySymbol propertySymbol, AggregateType propertyType)
      : base(ExpressionKind.PropertyInfo, type)
    {
      this.Property = new PropWithType(propertySymbol, propertyType);
    }

    public PropWithType Property { get; }

    public PropertyInfo PropertyInfo
    {
      [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")] get
      {
        AggregateType ats = this.Property.Ats;
        PropertySymbol propertySymbol = this.Property.Prop();
        TypeArray typeArray = TypeManager.SubstTypeArray(propertySymbol.Params, ats, (TypeArray) null);
        System.Type type = ats.AssociatedSystemType;
        PropertyInfo associatedPropertyInfo = propertySymbol.AssociatedPropertyInfo;
        if (!type.IsGenericType && !type.IsNested)
          type = associatedPropertyInfo.DeclaringType;
        foreach (PropertyInfo property in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (property.HasSameMetadataDefinitionAs((MemberInfo) associatedPropertyInfo))
          {
            bool flag = true;
            ParameterInfo[] parameterInfoArray = property.GetSetMethod(true) != (MethodInfo) null ? property.GetSetMethod(true).GetParameters() : property.GetGetMethod(true).GetParameters();
            for (int i = 0; i < typeArray.Count; ++i)
            {
              if (!ExprWithType.TypesAreEqual(parameterInfoArray[i].ParameterType, typeArray[i].AssociatedSystemType))
              {
                flag = false;
                break;
              }
            }
            if (flag)
              return property;
          }
        }
        throw Error.InternalCompilerError();
      }
    }
  }
}
