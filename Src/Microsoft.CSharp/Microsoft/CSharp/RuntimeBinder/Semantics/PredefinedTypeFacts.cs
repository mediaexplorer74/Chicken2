// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.PredefinedTypeFacts
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal static class PredefinedTypeFacts
  {
    private static readonly PredefinedTypeFacts.PredefinedTypeInfo[] s_types = new PredefinedTypeFacts.PredefinedTypeInfo[49]
    {
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_BYTE, typeof (byte), "System.Byte", FUNDTYPE.FT_U1),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_SHORT, typeof (short), "System.Int16", FUNDTYPE.FT_I2),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_INT, typeof (int), "System.Int32", FUNDTYPE.FT_I4),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_LONG, typeof (long), "System.Int64", FUNDTYPE.FT_I8),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_FLOAT, typeof (float), "System.Single", FUNDTYPE.FT_R4),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_DOUBLE, typeof (double), "System.Double", FUNDTYPE.FT_R8),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_DECIMAL, typeof (Decimal), "System.Decimal", FUNDTYPE.FT_STRUCT),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_CHAR, typeof (char), "System.Char", FUNDTYPE.FT_U2),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_BOOL, typeof (bool), "System.Boolean", FUNDTYPE.FT_I1),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_SBYTE, typeof (sbyte), "System.SByte", FUNDTYPE.FT_I1),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_USHORT, typeof (ushort), "System.UInt16", FUNDTYPE.FT_U2),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_UINT, typeof (uint), "System.UInt32", FUNDTYPE.FT_U4),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_ULONG, typeof (ulong), "System.UInt64", FUNDTYPE.FT_U8),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.FirstNonSimpleType, typeof (IntPtr), "System.IntPtr", FUNDTYPE.FT_STRUCT),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_UINTPTR, typeof (UIntPtr), "System.UIntPtr", FUNDTYPE.FT_STRUCT),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_OBJECT, typeof (object), "System.Object"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_STRING, typeof (string), "System.String"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_DELEGATE, typeof (Delegate), "System.Delegate"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_MULTIDEL, typeof (MulticastDelegate), "System.MulticastDelegate"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_ARRAY, typeof (Array), "System.Array"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_TYPE, typeof (Type), "System.Type"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_VALUE, typeof (ValueType), "System.ValueType"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_ENUM, typeof (Enum), "System.Enum"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_DATETIME, typeof (DateTime), "System.DateTime", FUNDTYPE.FT_STRUCT),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_IENUMERABLE, typeof (IEnumerable), "System.Collections.IEnumerable"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_IENUMERABLE, typeof (IEnumerable<>), "System.Collections.Generic.IEnumerable`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_OPTIONAL, typeof (Nullable<>), "System.Nullable`1", FUNDTYPE.FT_STRUCT),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_IQUERYABLE, typeof (IQueryable<>), "System.Linq.IQueryable`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_ICOLLECTION, typeof (ICollection<>), "System.Collections.Generic.ICollection`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_ILIST, typeof (IList<>), "System.Collections.Generic.IList`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_EXPRESSION, typeof (Expression<>), "System.Linq.Expressions.Expression`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_EXPRESSION, typeof (Expression), "System.Linq.Expressions.Expression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_BINARYEXPRESSION, typeof (BinaryExpression), "System.Linq.Expressions.BinaryExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_UNARYEXPRESSION, typeof (UnaryExpression), "System.Linq.Expressions.UnaryExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_CONSTANTEXPRESSION, typeof (ConstantExpression), "System.Linq.Expressions.ConstantExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_PARAMETEREXPRESSION, typeof (ParameterExpression), "System.Linq.Expressions.ParameterExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_MEMBEREXPRESSION, typeof (MemberExpression), "System.Linq.Expressions.MemberExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_METHODCALLEXPRESSION, typeof (MethodCallExpression), "System.Linq.Expressions.MethodCallExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_NEWEXPRESSION, typeof (NewExpression), "System.Linq.Expressions.NewExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_NEWARRAYEXPRESSION, typeof (NewArrayExpression), "System.Linq.Expressions.NewArrayExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_INVOCATIONEXPRESSION, typeof (InvocationExpression), "System.Linq.Expressions.InvocationExpression"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_FIELDINFO, typeof (FieldInfo), "System.Reflection.FieldInfo"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_METHODINFO, typeof (MethodInfo), "System.Reflection.MethodInfo"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_CONSTRUCTORINFO, typeof (ConstructorInfo), "System.Reflection.ConstructorInfo"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_PROPERTYINFO, typeof (PropertyInfo), "System.Reflection.PropertyInfo"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_MISSING, typeof (Missing), "System.Reflection.Missing"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_IREADONLYLIST, typeof (IReadOnlyList<>), "System.Collections.Generic.IReadOnlyList`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_G_IREADONLYCOLLECTION, typeof (IReadOnlyCollection<>), "System.Collections.Generic.IReadOnlyCollection`1"),
      new PredefinedTypeFacts.PredefinedTypeInfo(PredefinedType.PT_FUNC, typeof (Func<>), "System.Func`1")
    };
    private static readonly Dictionary<string, PredefinedType> s_typesByName = PredefinedTypeFacts.CreatePredefinedTypeFacts();

    internal static FUNDTYPE GetFundType(PredefinedType type)
    {
      return PredefinedTypeFacts.s_types[(int) type].FundType;
    }

    internal static Type GetAssociatedSystemType(PredefinedType type)
    {
      return PredefinedTypeFacts.s_types[(int) type].AssociatedSystemType;
    }

    internal static bool IsSimpleType(PredefinedType type)
    {
      return type < PredefinedType.FirstNonSimpleType;
    }

    internal static bool IsNumericType(PredefinedType type)
    {
      switch (type)
      {
        case PredefinedType.PT_BYTE:
        case PredefinedType.PT_SHORT:
        case PredefinedType.PT_INT:
        case PredefinedType.PT_LONG:
        case PredefinedType.PT_FLOAT:
        case PredefinedType.PT_DOUBLE:
        case PredefinedType.PT_DECIMAL:
        case PredefinedType.PT_SBYTE:
        case PredefinedType.PT_USHORT:
        case PredefinedType.PT_UINT:
        case PredefinedType.PT_ULONG:
          return true;
        default:
          return false;
      }
    }

    internal static string GetNiceName(PredefinedType type)
    {
      string niceName;
      switch (type)
      {
        case PredefinedType.PT_BYTE:
          niceName = "byte";
          break;
        case PredefinedType.PT_SHORT:
          niceName = "short";
          break;
        case PredefinedType.PT_INT:
          niceName = "int";
          break;
        case PredefinedType.PT_LONG:
          niceName = "long";
          break;
        case PredefinedType.PT_FLOAT:
          niceName = "float";
          break;
        case PredefinedType.PT_DOUBLE:
          niceName = "double";
          break;
        case PredefinedType.PT_DECIMAL:
          niceName = "decimal";
          break;
        case PredefinedType.PT_CHAR:
          niceName = "char";
          break;
        case PredefinedType.PT_BOOL:
          niceName = "bool";
          break;
        case PredefinedType.PT_SBYTE:
          niceName = "sbyte";
          break;
        case PredefinedType.PT_USHORT:
          niceName = "ushort";
          break;
        case PredefinedType.PT_UINT:
          niceName = "uint";
          break;
        case PredefinedType.PT_ULONG:
          niceName = "ulong";
          break;
        case PredefinedType.PT_OBJECT:
          niceName = "object";
          break;
        case PredefinedType.PT_STRING:
          niceName = "string";
          break;
        default:
          niceName = (string) null;
          break;
      }
      return niceName;
    }

    public static PredefinedType TryGetPredefTypeIndex(string name)
    {
      PredefinedType predefinedType;
      return !PredefinedTypeFacts.s_typesByName.TryGetValue(name, out predefinedType) ? PredefinedType.PT_UNDEFINEDINDEX : predefinedType;
    }

    private static Dictionary<string, PredefinedType> CreatePredefinedTypeFacts()
    {
      Dictionary<string, PredefinedType> predefinedTypeFacts = new Dictionary<string, PredefinedType>(49);
      for (int index = 0; index < 49; ++index)
        predefinedTypeFacts.Add(PredefinedTypeFacts.s_types[index].Name, (PredefinedType) index);
      return predefinedTypeFacts;
    }

    private sealed class PredefinedTypeInfo
    {
      public readonly string Name;
      public readonly FUNDTYPE FundType;
      public readonly Type AssociatedSystemType;

      internal PredefinedTypeInfo(
        PredefinedType type,
        Type associatedSystemType,
        string name,
        FUNDTYPE fundType)
      {
        this.Name = name;
        this.FundType = fundType;
        this.AssociatedSystemType = associatedSystemType;
      }

      internal PredefinedTypeInfo(PredefinedType type, Type associatedSystemType, string name)
        : this(type, associatedSystemType, name, FUNDTYPE.FT_REF)
      {
      }
    }
  }
}
