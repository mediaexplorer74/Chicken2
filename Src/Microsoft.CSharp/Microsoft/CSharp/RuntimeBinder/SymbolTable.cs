// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.SymbolTable
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder
{
  internal static class SymbolTable
  {
    private static readonly HashSet<Type> s_typesWithConversionsLoaded = new HashSet<Type>();
    private static readonly HashSet<SymbolTable.NameHashKey> s_namesLoadedForEachType = new HashSet<SymbolTable.NameHashKey>();

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static void PopulateSymbolTableWithName(
      string name,
      IEnumerable<Type> typeArguments,
      Type callingType)
    {
      if (callingType.IsGenericType)
        callingType = callingType.GetGenericTypeDefinition();
      if (name == "$Item$")
        name = callingType.GetIndexerName() ?? "$Item$";
      SymbolTable.NameHashKey key = new SymbolTable.NameHashKey(callingType, name);
      if (SymbolTable.s_namesLoadedForEachType.Contains(key))
        return;
      SymbolTable.AddNamesOnType(key);
      if (typeArguments == null)
        return;
      foreach (Type typeArgument in typeArguments)
        SymbolTable.AddConversionsForType(typeArgument);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static SymWithType LookupMember(
      string name,
      Expr callingObject,
      ParentSymbol context,
      int arity,
      MemberLookup mem,
      bool allowSpecialNames,
      bool requireInvocable)
    {
      CType typeSrc = callingObject.Type;
      if (typeSrc is ArrayType)
        typeSrc = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY);
      if (typeSrc is NullableType nullableType)
        typeSrc = (CType) nullableType.GetAts();
      return !mem.Lookup(typeSrc, callingObject, context, SymbolTable.GetName(name), arity, (MemLookFlags) ((allowSpecialNames ? 0 : 256) | (name == "$Item$" ? 4 : 0) | (name == ".ctor" ? 2 : 0) | (requireInvocable ? 536870912 : 0))) ? (SymWithType) null : mem.SwtFirst();
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddParameterConversions(MethodBase method)
    {
      foreach (ParameterInfo parameter in method.GetParameters())
        SymbolTable.AddConversionsForType(parameter.ParameterType);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddNamesOnType(SymbolTable.NameHashKey key)
    {
      List<Type> inheritanceHierarchyList = SymbolTable.CreateInheritanceHierarchyList(key.Type);
      SymbolTable.AddNamesInInheritanceHierarchy(key.Name, inheritanceHierarchyList);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddNamesInInheritanceHierarchy(string name, List<Type> inheritance)
    {
      for (int index = inheritance.Count - 1; index >= 0; --index)
      {
        Type type = inheritance[index];
        if (type.IsGenericType)
          type = type.GetGenericTypeDefinition();
        if (SymbolTable.s_namesLoadedForEachType.Add(new SymbolTable.NameHashKey(type, name)))
        {
          IEnumerator<MemberInfo> enumerator = ((IEnumerable<MemberInfo>) type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)).Where<MemberInfo>((Func<MemberInfo, bool>) (member => member.DeclaringType == type && member.Name == name)).GetEnumerator();
          if (enumerator.MoveNext())
          {
            List<EventInfo> eventInfoList = (List<EventInfo>) null;
            if (SymbolTable.GetCTypeFromType(type) is AggregateType ctypeFromType)
            {
              AggregateSymbol owningAggregate = ctypeFromType.OwningAggregate;
              FieldSymbol addedField = (FieldSymbol) null;
              do
              {
                MemberInfo current = enumerator.Current;
                MethodInfo methodInfo = current as MethodInfo;
                if ((object) methodInfo != null)
                {
                  MethodKindEnum methodKindEnum;
                  switch (current.Name)
                  {
                    case "Invoke":
                      methodKindEnum = MethodKindEnum.Invoke;
                      break;
                    case "op_Implicit":
                      methodKindEnum = MethodKindEnum.ImplicitConv;
                      break;
                    case "op_Explicit":
                      methodKindEnum = MethodKindEnum.ExplicitConv;
                      break;
                    default:
                      methodKindEnum = MethodKindEnum.Actual;
                      break;
                  }
                  MethodKindEnum kind = methodKindEnum;
                  SymbolTable.AddMethodToSymbolTable((MethodBase) methodInfo, owningAggregate, kind);
                  SymbolTable.AddParameterConversions((MethodBase) methodInfo);
                }
                else
                {
                  ConstructorInfo constructorInfo = current as ConstructorInfo;
                  if ((object) constructorInfo != null)
                  {
                    SymbolTable.AddMethodToSymbolTable((MethodBase) constructorInfo, owningAggregate, MethodKindEnum.Constructor);
                    SymbolTable.AddParameterConversions((MethodBase) constructorInfo);
                  }
                  else
                  {
                    PropertyInfo property = current as PropertyInfo;
                    if ((object) property != null)
                    {
                      SymbolTable.AddPropertyToSymbolTable(property, owningAggregate);
                    }
                    else
                    {
                      FieldInfo fieldInfo = current as FieldInfo;
                      if ((object) fieldInfo != null)
                      {
                        addedField = SymbolTable.AddFieldToSymbolTable(fieldInfo, owningAggregate);
                      }
                      else
                      {
                        EventInfo eventInfo = current as EventInfo;
                        if ((object) eventInfo != null)
                          (eventInfoList = eventInfoList ?? new List<EventInfo>()).Add(eventInfo);
                      }
                    }
                  }
                }
              }
              while (enumerator.MoveNext());
              if (eventInfoList != null)
              {
                foreach (EventInfo eventInfo in eventInfoList)
                  SymbolTable.AddEventToSymbolTable(eventInfo, owningAggregate, addedField);
              }
            }
          }
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static List<Type> CreateInheritanceHierarchyList(Type type)
    {
      List<Type> inheritanceHierarchyList;
      if (type.IsInterface)
      {
        inheritanceHierarchyList = new List<Type>(type.GetInterfaces().Length + 2)
        {
          type
        };
        foreach (Type type1 in type.GetInterfaces())
        {
          SymbolTable.LoadSymbolsFromType(type1);
          inheritanceHierarchyList.Add(type1);
        }
        Type type2 = typeof (object);
        SymbolTable.LoadSymbolsFromType(type2);
        inheritanceHierarchyList.Add(type2);
      }
      else
      {
        inheritanceHierarchyList = new List<Type>() { type };
        for (Type baseType = type.BaseType; baseType != (Type) null; baseType = baseType.BaseType)
        {
          SymbolTable.LoadSymbolsFromType(baseType);
          inheritanceHierarchyList.Add(baseType);
        }
      }
      return inheritanceHierarchyList;
    }

    private static Name GetName(string p) => NameManager.Add(p ?? "");

    private static Name GetName(Type type)
    {
      string name = type.Name;
      if (type.IsGenericType)
      {
        int length = name.IndexOf('`');
        if (length >= 0)
          return NameManager.Add(name, length);
      }
      return NameManager.Add(name);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeArray GetMethodTypeParameters(MethodInfo method, MethodSymbol parent)
    {
      if (!method.IsGenericMethod)
        return TypeArray.Empty;
      Type[] genericArguments = method.GetGenericArguments();
      CType[] ctypeArray = new CType[genericArguments.Length];
      for (int index = 0; index < genericArguments.Length; ++index)
      {
        Type t = genericArguments[index];
        ctypeArray[index] = (CType) SymbolTable.LoadMethodTypeParameter(parent, t);
      }
      for (int index = 0; index < genericArguments.Length; ++index)
      {
        Type type = genericArguments[index];
        ((TypeParameterType) ctypeArray[index]).Symbol.SetBounds(TypeArray.Allocate(SymbolTable.GetCTypeArrayFromTypes(type.GetGenericParameterConstraints())));
      }
      return TypeArray.Allocate(ctypeArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeArray GetAggregateTypeParameters(Type type, AggregateSymbol agg)
    {
      if (!type.IsGenericType)
        return TypeArray.Empty;
      Type genericTypeDefinition = type.GetGenericTypeDefinition();
      Type[] genericArguments = genericTypeDefinition.GetGenericArguments();
      List<CType> ctypeList = new List<CType>();
      int count = agg.isNested() ? agg.GetOuterAgg().GetTypeVarsAll().Count : 0;
      for (int index = 0; index < genericArguments.Length; ++index)
      {
        Type type1 = genericArguments[index];
        if (type1.GenericParameterPosition >= count)
        {
          CType ctype = !type1.IsGenericParameter || !(type1.DeclaringType == genericTypeDefinition) ? SymbolTable.GetCTypeFromType(type1) : (CType) SymbolTable.LoadClassTypeParameter(agg, type1);
          if (((TypeParameterType) ctype).OwningSymbol == agg)
            ctypeList.Add(ctype);
        }
      }
      return TypeArray.Allocate(ctypeList.ToArray());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeParameterType LoadClassTypeParameter(AggregateSymbol parent, Type t)
    {
      for (AggregateSymbol parent1 = parent; parent1 != null; parent1 = parent1.parent as AggregateSymbol)
      {
        for (TypeParameterSymbol typeParameterSymbol = SymbolStore.LookupSym(SymbolTable.GetName(t), (ParentSymbol) parent1, symbmask_t.MASK_TypeParameterSymbol) as TypeParameterSymbol; typeParameterSymbol != null; typeParameterSymbol = typeParameterSymbol.LookupNext(symbmask_t.MASK_TypeParameterSymbol) as TypeParameterSymbol)
        {
          if (SymbolTable.AreTypeParametersEquivalent(typeParameterSymbol.GetTypeParameterType().AssociatedSystemType, t))
            return typeParameterSymbol.GetTypeParameterType();
        }
      }
      return SymbolTable.AddTypeParameterToSymbolTable(parent, (MethodSymbol) null, t, true);
    }

    private static bool AreTypeParametersEquivalent(Type t1, Type t2)
    {
      return t1 == t2 || SymbolTable.GetOriginalTypeParameterType(t1) == SymbolTable.GetOriginalTypeParameterType(t2);
    }

    private static Type GetOriginalTypeParameterType(Type t)
    {
      int parameterPosition = t.GenericParameterPosition;
      Type type1 = t.DeclaringType;
      if (type1 != (Type) null && type1.IsGenericType)
        type1 = type1.GetGenericTypeDefinition();
      if (t.DeclaringMethod != (MethodBase) null && (type1.GetGenericArguments() == null || parameterPosition >= type1.GetGenericArguments().Length))
        return t;
      Type type2;
      for (; type1.GetGenericArguments().Length > parameterPosition; type1 = type2)
      {
        type2 = type1.DeclaringType;
        if (type2 != (Type) null && type2.IsGenericType)
          type2 = type2.GetGenericTypeDefinition();
        if ((object) type2 != null)
        {
          int? length = type2.GetGenericArguments()?.Length;
          int num = parameterPosition;
          if (!(length.GetValueOrDefault() > num & length.HasValue))
            break;
        }
        else
          break;
      }
      return type1.GetGenericArguments()[parameterPosition];
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeParameterType LoadMethodTypeParameter(MethodSymbol parent, Type t)
    {
      for (Symbol symbol = parent.firstChild; symbol != null; symbol = symbol.nextChild)
      {
        if (symbol is TypeParameterSymbol typeParameterSymbol)
        {
          TypeParameterType typeParameterType = typeParameterSymbol.GetTypeParameterType();
          if (SymbolTable.AreTypeParametersEquivalent(typeParameterType.AssociatedSystemType, t))
            return typeParameterType;
        }
      }
      return SymbolTable.AddTypeParameterToSymbolTable((AggregateSymbol) null, parent, t, false);
    }

    private static TypeParameterType AddTypeParameterToSymbolTable(
      AggregateSymbol agg,
      MethodSymbol meth,
      Type t,
      bool bIsAggregate)
    {
      TypeParameterSymbol pSymbol = !bIsAggregate ? SymFactory.CreateMethodTypeParameter(SymbolTable.GetName(t), meth, t.GenericParameterPosition, t.GenericParameterPosition) : SymFactory.CreateClassTypeParameter(SymbolTable.GetName(t), agg, t.GenericParameterPosition, t.GenericParameterPosition);
      if ((t.GenericParameterAttributes & GenericParameterAttributes.Covariant) != GenericParameterAttributes.None)
        pSymbol.Covariant = true;
      if ((t.GenericParameterAttributes & GenericParameterAttributes.Contravariant) != GenericParameterAttributes.None)
        pSymbol.Contravariant = true;
      SpecCons constraints = SpecCons.None;
      if ((t.GenericParameterAttributes & GenericParameterAttributes.DefaultConstructorConstraint) != GenericParameterAttributes.None)
        constraints |= SpecCons.New;
      if ((t.GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) != GenericParameterAttributes.None)
        constraints |= SpecCons.Ref;
      if ((t.GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != GenericParameterAttributes.None)
        constraints |= SpecCons.Val;
      pSymbol.SetConstraints(constraints);
      pSymbol.SetAccess(ACCESS.ACC_PUBLIC);
      return TypeManager.GetTypeParameter(pSymbol);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static CType LoadSymbolsFromType(Type type)
    {
      List<object> objectList = SymbolTable.BuildDeclarationChain(type);
      NamespaceOrAggregateSymbol parent = (NamespaceOrAggregateSymbol) NamespaceSymbol.Root;
      for (int index = 0; index < objectList.Count; ++index)
      {
        object sz = objectList[index];
        Type type1 = sz as Type;
        if ((object) type1 != null)
        {
          if (type1.IsNullableType())
            return (CType) TypeManager.GetNullable(SymbolTable.GetCTypeFromType(type1.GetGenericArguments()[0]));
          AggregateSymbol agg = SymbolTable.FindSymForType(SymbolStore.LookupSym(SymbolTable.GetName(type1), (ParentSymbol) parent, symbmask_t.MASK_AggregateSymbol), type1);
          if (agg == null)
          {
            CType ctype = SymbolTable.ProcessSpecialTypeInChain(parent, type1);
            if (ctype != null)
              return ctype;
            agg = SymbolTable.AddAggregateToSymbolTable(parent, type1);
          }
          if (type1 == type)
            return SymbolTable.GetConstructedType(type, agg);
          parent = (NamespaceOrAggregateSymbol) agg;
        }
        else
        {
          MethodInfo methinfo = sz as MethodInfo;
          if ((object) methinfo != null)
          {
            int num;
            return (CType) SymbolTable.ProcessMethodTypeParameter(methinfo, objectList[num = index + 1] as Type, parent as AggregateSymbol);
          }
          parent = (NamespaceOrAggregateSymbol) SymbolTable.AddNamespaceToSymbolTable(parent, sz as string);
        }
      }
      return (CType) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeParameterType ProcessMethodTypeParameter(
      MethodInfo methinfo,
      Type t,
      AggregateSymbol parent)
    {
      return SymbolTable.LoadMethodTypeParameter(SymbolTable.FindMatchingMethod((MemberInfo) methinfo, parent) ?? SymbolTable.AddMethodToSymbolTable((MethodBase) methinfo, parent, MethodKindEnum.Actual), t);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static CType GetConstructedType(Type type, AggregateSymbol agg)
    {
      if (!type.IsGenericType)
        return (CType) agg.getThisType();
      List<CType> ctypeList = new List<CType>();
      foreach (Type genericArgument in type.GetGenericArguments())
        ctypeList.Add(SymbolTable.GetCTypeFromType(genericArgument));
      TypeArray typeArgsAll = TypeArray.Allocate(ctypeList.ToArray());
      return (CType) TypeManager.GetAggregate(agg, typeArgsAll);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static CType ProcessSpecialTypeInChain(NamespaceOrAggregateSymbol parent, Type t)
    {
      if (t.IsGenericParameter)
        return (CType) SymbolTable.LoadClassTypeParameter(parent as AggregateSymbol, t);
      if (t.IsArray)
        return (CType) TypeManager.GetArray(SymbolTable.GetCTypeFromType(t.GetElementType()), t.GetArrayRank(), t.GetElementType().MakeArrayType() == t);
      return t.IsPointer ? (CType) TypeManager.GetPointer(SymbolTable.GetCTypeFromType(t.GetElementType())) : (CType) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static List<object> BuildDeclarationChain(Type callingType)
    {
      if (callingType.IsByRef)
        callingType = callingType.GetElementType();
      List<object> objectList = new List<object>();
      for (Type type = callingType; type != (Type) null; type = type.DeclaringType)
      {
        objectList.Add((object) type);
        if (type.IsGenericParameter && type.DeclaringMethod != (MethodBase) null)
        {
          MethodBase declaringMethod = type.DeclaringMethod;
          bool flag = false;
          foreach (MethodInfo method in type.DeclaringType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
          {
            if (method.HasSameMetadataDefinitionAs((MemberInfo) declaringMethod) && method.IsGenericMethod)
            {
              objectList.Add((object) method);
              flag = true;
            }
          }
        }
      }
      objectList.Reverse();
      if (callingType.Namespace != null)
        objectList.InsertRange(0, (IEnumerable<object>) callingType.Namespace.Split('.'));
      return objectList;
    }

    private static AggregateSymbol FindSymForType(Symbol sym, Type t)
    {
      for (; sym != null; sym = sym.nextSameName)
      {
        if (sym is AggregateSymbol symForType && symForType.AssociatedSystemType.IsEquivalentTo(t.IsGenericType ? t.GetGenericTypeDefinition() : t))
          return symForType;
      }
      return (AggregateSymbol) null;
    }

    private static NamespaceSymbol AddNamespaceToSymbolTable(
      NamespaceOrAggregateSymbol parent,
      string sz)
    {
      Name name = SymbolTable.GetName(sz);
      return SymbolStore.LookupSym(name, (ParentSymbol) parent, symbmask_t.MASK_NamespaceSymbol) is NamespaceSymbol namespaceSymbol ? namespaceSymbol : SymFactory.CreateNamespace(name, parent as NamespaceSymbol);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static CType[] GetCTypeArrayFromTypes(Type[] types)
    {
      int length = types.Length;
      if (length == 0)
        return Array.Empty<CType>();
      CType[] ctypeArrayFromTypes = new CType[length];
      for (int index = 0; index < types.Length; ++index)
      {
        Type type = types[index];
        ctypeArrayFromTypes[index] = SymbolTable.GetCTypeFromType(type);
      }
      return ctypeArrayFromTypes;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static CType GetCTypeFromType(Type type)
    {
      return !type.IsByRef ? SymbolTable.LoadSymbolsFromType(type) : (CType) TypeManager.GetParameterModifier(SymbolTable.LoadSymbolsFromType(type.GetElementType()), false);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static AggregateSymbol AddAggregateToSymbolTable(
      NamespaceOrAggregateSymbol parent,
      Type type)
    {
      AggregateSymbol aggregate = SymFactory.CreateAggregate(SymbolTable.GetName(type), parent);
      aggregate.AssociatedSystemType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
      aggregate.AssociatedAssembly = type.Assembly;
      AggKindEnum aggKind;
      if (type.IsInterface)
        aggKind = AggKindEnum.Interface;
      else if (type.IsEnum)
      {
        aggKind = AggKindEnum.Enum;
        aggregate.SetUnderlyingType((AggregateType) SymbolTable.GetCTypeFromType(Enum.GetUnderlyingType(type)));
      }
      else
        aggKind = !type.IsValueType ? (!(type.BaseType != (Type) null) || !(type.BaseType.FullName == "System.MulticastDelegate") && !(type.BaseType.FullName == "System.Delegate") || !(type.FullName != "System.MulticastDelegate") ? AggKindEnum.Class : AggKindEnum.Delegate) : AggKindEnum.Struct;
      aggregate.SetAggKind(aggKind);
      aggregate.SetTypeVars(TypeArray.Empty);
      ACCESS access = !type.IsPublic ? (!type.IsNested ? ACCESS.ACC_INTERNAL : (!type.IsNestedAssembly ? (!type.IsNestedFamORAssem ? (!type.IsNestedPrivate ? (!type.IsNestedFamily ? (!type.IsNestedFamANDAssem ? ACCESS.ACC_PUBLIC : ACCESS.ACC_INTERNAL_AND_PROTECTED) : ACCESS.ACC_PROTECTED) : ACCESS.ACC_PRIVATE) : ACCESS.ACC_INTERNALPROTECTED) : ACCESS.ACC_INTERNAL)) : ACCESS.ACC_PUBLIC;
      aggregate.SetAccess(access);
      if (!type.IsGenericParameter)
        aggregate.SetTypeVars(SymbolTable.GetAggregateTypeParameters(type, aggregate));
      if (type.IsGenericType)
      {
        Type[] genericArguments = type.GetGenericTypeDefinition().GetGenericArguments();
        for (int i = 0; i < aggregate.GetTypeVars().Count; ++i)
        {
          Type type1 = genericArguments[i];
          if (aggregate.GetTypeVars()[i] is TypeParameterType typeVar)
            typeVar.Symbol.SetBounds(TypeArray.Allocate(SymbolTable.GetCTypeArrayFromTypes(type1.GetGenericParameterConstraints())));
        }
      }
      aggregate.SetAbstract(type.IsAbstract);
      string fullName = type.FullName;
      if (type.IsGenericType)
        fullName = type.GetGenericTypeDefinition().FullName;
      if (fullName != null)
      {
        PredefinedType predefTypeIndex = PredefinedTypeFacts.TryGetPredefTypeIndex(fullName);
        if (predefTypeIndex != PredefinedType.PT_UNDEFINEDINDEX)
          PredefinedTypes.InitializePredefinedType(aggregate, predefTypeIndex);
      }
      aggregate.SetSealed(type.IsSealed);
      if (type.BaseType != (Type) null)
      {
        Type type2 = type.BaseType;
        if (type2.IsGenericType)
          type2 = type2.GetGenericTypeDefinition();
        aggregate.SetBaseClass((AggregateType) SymbolTable.GetCTypeFromType(type2));
      }
      aggregate.SetFirstUDConversion((MethodSymbol) null);
      SymbolTable.SetInterfacesOnAggregate(aggregate, type);
      aggregate.SetHasPubNoArgCtor(type.GetConstructor(Type.EmptyTypes) != (ConstructorInfo) null);
      if (aggregate.IsDelegate())
      {
        SymbolTable.PopulateSymbolTableWithName(".ctor", (IEnumerable<Type>) null, type);
        SymbolTable.PopulateSymbolTableWithName("Invoke", (IEnumerable<Type>) null, type);
      }
      return aggregate;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void SetInterfacesOnAggregate(AggregateSymbol aggregate, Type type)
    {
      if (type.IsGenericType)
        type = type.GetGenericTypeDefinition();
      Type[] interfaces = type.GetInterfaces();
      aggregate.SetIfaces(TypeArray.Allocate(SymbolTable.GetCTypeArrayFromTypes(interfaces)));
      aggregate.SetIfacesAll(aggregate.GetIfaces());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static FieldSymbol AddFieldToSymbolTable(FieldInfo fieldInfo, AggregateSymbol aggregate)
    {
      if (SymbolStore.LookupSym(SymbolTable.GetName(fieldInfo.Name), (ParentSymbol) aggregate, symbmask_t.MASK_FieldSymbol) is FieldSymbol symbolTable)
        return symbolTable;
      FieldSymbol memberVar = SymFactory.CreateMemberVar(SymbolTable.GetName(fieldInfo.Name), aggregate);
      memberVar.AssociatedFieldInfo = fieldInfo;
      memberVar.isStatic = fieldInfo.IsStatic;
      ACCESS access = !fieldInfo.IsPublic ? (!fieldInfo.IsPrivate ? (!fieldInfo.IsFamily ? (!fieldInfo.IsAssembly ? (!fieldInfo.IsFamilyOrAssembly ? ACCESS.ACC_INTERNAL_AND_PROTECTED : ACCESS.ACC_INTERNALPROTECTED) : ACCESS.ACC_INTERNAL) : ACCESS.ACC_PROTECTED) : ACCESS.ACC_PRIVATE) : ACCESS.ACC_PUBLIC;
      memberVar.SetAccess(access);
      memberVar.isReadOnly = fieldInfo.IsInitOnly;
      memberVar.isEvent = false;
      memberVar.SetType(SymbolTable.GetCTypeFromType(fieldInfo.FieldType));
      return memberVar;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddEventToSymbolTable(
      EventInfo eventInfo,
      AggregateSymbol aggregate,
      FieldSymbol addedField)
    {
      if (SymbolStore.LookupSym(SymbolTable.GetName(eventInfo.Name), (ParentSymbol) aggregate, symbmask_t.MASK_EventSymbol) is EventSymbol)
        return;
      EventSymbol evt = SymFactory.CreateEvent(SymbolTable.GetName(eventInfo.Name), aggregate);
      evt.AssociatedEventInfo = eventInfo;
      ACCESS access = ACCESS.ACC_PRIVATE;
      if (eventInfo.AddMethod != (MethodInfo) null)
      {
        evt.methAdd = SymbolTable.AddMethodToSymbolTable((MethodBase) eventInfo.AddMethod, aggregate, MethodKindEnum.EventAccessor);
        evt.methAdd.SetEvent(evt);
        evt.isOverride = evt.methAdd.IsOverride();
        access = evt.methAdd.GetAccess();
      }
      if (eventInfo.RemoveMethod != (MethodInfo) null)
      {
        evt.methRemove = SymbolTable.AddMethodToSymbolTable((MethodBase) eventInfo.RemoveMethod, aggregate, MethodKindEnum.EventAccessor);
        evt.methRemove.SetEvent(evt);
        evt.isOverride = evt.methRemove.IsOverride();
        access = evt.methRemove.GetAccess();
      }
      evt.isStatic = false;
      evt.type = SymbolTable.GetCTypeFromType(eventInfo.EventHandlerType);
      evt.SetAccess(access);
      CType type = addedField?.GetType();
      if (type == null || type != evt.type)
        return;
      addedField.isEvent = true;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static void AddPredefinedPropertyToSymbolTable(AggregateSymbol type, Name property)
    {
      foreach (PropertyInfo property1 in type.getThisType().AssociatedSystemType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
      {
        if (property1.Name == property.Text)
          SymbolTable.AddPropertyToSymbolTable(property1, type);
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddPropertyToSymbolTable(PropertyInfo property, AggregateSymbol aggregate)
    {
      int num;
      if (property.GetIndexParameters().Length != 0)
      {
        Type declaringType = property.DeclaringType;
        num = ((object) declaringType != null ? declaringType.GetCustomAttribute<DefaultMemberAttribute>()?.MemberName : (string) null) == property.Name ? 1 : 0;
      }
      else
        num = 0;
      bool flag = num != 0;
      Name name = !flag ? SymbolTable.GetName(property.Name) : SymbolTable.GetName("$Item$");
      if (SymbolStore.LookupSym(name, (ParentSymbol) aggregate, symbmask_t.MASK_PropertySymbol) is PropertySymbol propertySymbol1)
      {
        PropertySymbol propertySymbol = (PropertySymbol) null;
        for (; propertySymbol1 != null; propertySymbol1 = propertySymbol1.LookupNext(symbmask_t.MASK_PropertySymbol) as PropertySymbol)
        {
          if (propertySymbol1.AssociatedPropertyInfo.IsEquivalentTo((MemberInfo) property))
            return;
          propertySymbol = propertySymbol1;
        }
        propertySymbol1 = propertySymbol;
        if (flag)
          propertySymbol1 = (PropertySymbol) null;
      }
      if (propertySymbol1 == null)
      {
        if (flag)
        {
          propertySymbol1 = (PropertySymbol) SymFactory.CreateIndexer(name, (ParentSymbol) aggregate);
          propertySymbol1.Params = SymbolTable.CreateParameterArray((MemberInfo) null, property.GetIndexParameters());
        }
        else
        {
          propertySymbol1 = SymFactory.CreateProperty(SymbolTable.GetName(property.Name), aggregate);
          propertySymbol1.Params = TypeArray.Empty;
        }
      }
      propertySymbol1.AssociatedPropertyInfo = property;
      propertySymbol1.isStatic = property.GetGetMethod(true) != (MethodInfo) null ? property.GetGetMethod(true).IsStatic : property.GetSetMethod(true).IsStatic;
      propertySymbol1.isParamArray = SymbolTable.DoesMethodHaveParameterArray(property.GetIndexParameters());
      propertySymbol1.swtSlot = (SymWithType) null;
      propertySymbol1.RetType = SymbolTable.GetCTypeFromType(property.PropertyType);
      propertySymbol1.isOperator = flag;
      if (property.GetMethod != (MethodInfo) null || property.SetMethod != (MethodInfo) null)
      {
        MethodInfo methodInfo1 = property.GetMethod;
        if ((object) methodInfo1 == null)
          methodInfo1 = property.SetMethod;
        MethodInfo methodInfo2 = methodInfo1;
        propertySymbol1.isOverride = methodInfo2.IsVirtual && methodInfo2.IsHideBySig && methodInfo2.GetBaseDefinition() != methodInfo2;
        propertySymbol1.isHideByName = !methodInfo2.IsHideBySig;
      }
      SymbolTable.SetParameterDataForMethProp((MethodOrPropertySymbol) propertySymbol1, property.GetIndexParameters());
      MethodInfo getMethod = property.GetMethod;
      MethodInfo setMethod = property.SetMethod;
      ACCESS access = ACCESS.ACC_PRIVATE;
      if (getMethod != (MethodInfo) null)
      {
        propertySymbol1.GetterMethod = SymbolTable.AddMethodToSymbolTable((MethodBase) getMethod, aggregate, MethodKindEnum.PropAccessor);
        if (flag || propertySymbol1.GetterMethod.Params.Count == 0)
        {
          propertySymbol1.GetterMethod.SetProperty(propertySymbol1);
        }
        else
        {
          propertySymbol1.Bogus = true;
          propertySymbol1.GetterMethod.SetMethKind(MethodKindEnum.Actual);
        }
        if (propertySymbol1.GetterMethod.GetAccess() > access)
          access = propertySymbol1.GetterMethod.GetAccess();
      }
      if (setMethod != (MethodInfo) null)
      {
        propertySymbol1.SetterMethod = SymbolTable.AddMethodToSymbolTable((MethodBase) setMethod, aggregate, MethodKindEnum.PropAccessor);
        if (flag || propertySymbol1.SetterMethod.Params.Count == 1)
        {
          propertySymbol1.SetterMethod.SetProperty(propertySymbol1);
        }
        else
        {
          propertySymbol1.Bogus = true;
          propertySymbol1.SetterMethod.SetMethKind(MethodKindEnum.Actual);
        }
        if (propertySymbol1.SetterMethod.GetAccess() > access)
          access = propertySymbol1.SetterMethod.GetAccess();
      }
      propertySymbol1.SetAccess(access);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static void AddPredefinedMethodToSymbolTable(AggregateSymbol type, Name methodName)
    {
      Type associatedSystemType = type.getThisType().AssociatedSystemType;
      if (methodName == NameManager.GetPredefinedName(PredefinedName.PN_CTOR))
      {
        foreach (MethodBase constructor in associatedSystemType.GetConstructors())
          SymbolTable.AddMethodToSymbolTable(constructor, type, MethodKindEnum.Constructor);
      }
      else
      {
        foreach (MethodInfo method in associatedSystemType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
          if (method.Name == methodName.Text && method.DeclaringType == associatedSystemType)
            SymbolTable.AddMethodToSymbolTable((MethodBase) method, type, method.Name == "Invoke" ? MethodKindEnum.Invoke : MethodKindEnum.Actual);
        }
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static MethodSymbol AddMethodToSymbolTable(
      MethodBase member,
      AggregateSymbol callingAggregate,
      MethodKindEnum kind)
    {
      MethodInfo method1 = member as MethodInfo;
      if (kind == MethodKindEnum.Actual && (method1 == (MethodInfo) null || !method1.IsStatic && method1.IsSpecialName))
        return (MethodSymbol) null;
      MethodSymbol matchingMethod = SymbolTable.FindMatchingMethod((MemberInfo) member, callingAggregate);
      if (matchingMethod != null)
        return matchingMethod;
      ParameterInfo[] parameters = member.GetParameters();
      MethodSymbol method2 = SymFactory.CreateMethod(SymbolTable.GetName(member.Name), callingAggregate);
      method2.AssociatedMemberInfo = (MemberInfo) member;
      method2.SetMethKind(kind);
      if (kind == MethodKindEnum.ExplicitConv || kind == MethodKindEnum.ImplicitConv)
      {
        callingAggregate.SetHasConversion();
        method2.SetConvNext(callingAggregate.GetFirstUDConversion());
        callingAggregate.SetFirstUDConversion(method2);
      }
      ACCESS access = !member.IsPublic ? (!member.IsPrivate ? (!member.IsFamily ? (!member.IsFamilyOrAssembly ? (!member.IsAssembly ? ACCESS.ACC_INTERNAL_AND_PROTECTED : ACCESS.ACC_INTERNAL) : ACCESS.ACC_INTERNALPROTECTED) : ACCESS.ACC_PROTECTED) : ACCESS.ACC_PRIVATE) : ACCESS.ACC_PUBLIC;
      method2.SetAccess(access);
      method2.isVirtual = member.IsVirtual;
      method2.isStatic = member.IsStatic;
      if (method1 != (MethodInfo) null)
      {
        method2.typeVars = SymbolTable.GetMethodTypeParameters(method1, method2);
        method2.isOverride = method1.IsVirtual && method1.IsHideBySig && method1.GetBaseDefinition() != method1;
        method2.isOperator = SymbolTable.IsOperator(method1);
        method2.swtSlot = SymbolTable.GetSlotForOverride(method1);
        method2.RetType = SymbolTable.GetCTypeFromType(method1.ReturnType);
      }
      else
      {
        method2.typeVars = TypeArray.Empty;
        method2.isOverride = false;
        method2.isOperator = false;
        method2.swtSlot = (SymWithType) null;
        method2.RetType = (CType) VoidType.Instance;
      }
      method2.modOptCount = 0U;
      method2.isParamArray = SymbolTable.DoesMethodHaveParameterArray(parameters);
      method2.isHideByName = false;
      method2.Params = SymbolTable.CreateParameterArray(method2.AssociatedMemberInfo, parameters);
      SymbolTable.SetParameterDataForMethProp((MethodOrPropertySymbol) method2, parameters);
      return method2;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void SetParameterDataForMethProp(
      MethodOrPropertySymbol methProp,
      ParameterInfo[] parameters)
    {
      if (parameters.Length == 0)
        return;
      if (parameters[parameters.Length - 1].GetCustomAttribute(typeof (ParamArrayAttribute), false) != null)
        methProp.isParamArray = true;
      for (int i = 0; i < parameters.Length; ++i)
      {
        SymbolTable.SetParameterAttributes(methProp, parameters, i);
        methProp.ParameterNames.Add(SymbolTable.GetName(parameters[i].Name));
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void SetParameterAttributes(
      MethodOrPropertySymbol methProp,
      ParameterInfo[] parameters,
      int i)
    {
      ParameterInfo parameter = parameters[i];
      if ((parameter.Attributes & ParameterAttributes.Optional) != ParameterAttributes.None && !parameter.ParameterType.IsByRef)
      {
        methProp.SetOptionalParameter(i);
        SymbolTable.PopulateSymbolTableWithName("Value", (IEnumerable<Type>) new Type[1]
        {
          typeof (Missing)
        }, typeof (Missing));
      }
      if ((parameter.Attributes & ParameterAttributes.HasFieldMarshal) != ParameterAttributes.None)
      {
        MarshalAsAttribute customAttribute = parameter.GetCustomAttribute<MarshalAsAttribute>(false);
        if (customAttribute != null)
          methProp.SetMarshalAsParameter(i, customAttribute.Value);
      }
      DateTimeConstantAttribute customAttribute1 = parameter.GetCustomAttribute<DateTimeConstantAttribute>(false);
      if (customAttribute1 != null)
      {
        ConstVal cv = ConstVal.Get(((DateTime) customAttribute1.Value).Ticks);
        CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_DATETIME);
        methProp.SetDefaultParameterValue(i, predefindType, cv);
      }
      else
      {
        DecimalConstantAttribute customAttribute2 = parameter.GetCustomAttribute<DecimalConstantAttribute>();
        if (customAttribute2 != null)
        {
          ConstVal cv = ConstVal.Get(customAttribute2.Value);
          CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_DECIMAL);
          methProp.SetDefaultParameterValue(i, predefindType, cv);
        }
        else
        {
          if ((parameter.Attributes & ParameterAttributes.HasDefault) == ParameterAttributes.None || parameter.ParameterType.IsByRef)
            return;
          ConstVal cv = new ConstVal();
          CType predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT);
          if (parameter.DefaultValue != null)
          {
            object defaultValue = parameter.DefaultValue;
            switch (Type.GetTypeCode(defaultValue.GetType()))
            {
              case TypeCode.Boolean:
                cv = ConstVal.Get((bool) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL);
                break;
              case TypeCode.Char:
                cv = ConstVal.Get((int) (char) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_CHAR);
                break;
              case TypeCode.SByte:
                cv = ConstVal.Get((int) (sbyte) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_SBYTE);
                break;
              case TypeCode.Byte:
                cv = ConstVal.Get((int) (byte) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_BYTE);
                break;
              case TypeCode.Int16:
                cv = ConstVal.Get((int) (short) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_SHORT);
                break;
              case TypeCode.UInt16:
                cv = ConstVal.Get((int) (ushort) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_USHORT);
                break;
              case TypeCode.Int32:
                cv = ConstVal.Get((int) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_INT);
                break;
              case TypeCode.UInt32:
                cv = ConstVal.Get((uint) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_UINT);
                break;
              case TypeCode.Int64:
                cv = ConstVal.Get((long) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_LONG);
                break;
              case TypeCode.UInt64:
                cv = ConstVal.Get((ulong) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_ULONG);
                break;
              case TypeCode.Single:
                cv = ConstVal.Get((float) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_FLOAT);
                break;
              case TypeCode.Double:
                cv = ConstVal.Get((double) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_DOUBLE);
                break;
              case TypeCode.String:
                cv = ConstVal.Get((string) defaultValue);
                predefindType = (CType) SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
                break;
            }
          }
          methProp.SetDefaultParameterValue(i, predefindType, cv);
        }
      }
    }

    private static MethodSymbol FindMatchingMethod(
      MemberInfo method,
      AggregateSymbol callingAggregate)
    {
      for (MethodSymbol matchingMethod = SymbolStore.LookupSym(SymbolTable.GetName(method.Name), (ParentSymbol) callingAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol; matchingMethod != null; matchingMethod = matchingMethod.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol)
      {
        if (matchingMethod.AssociatedMemberInfo.IsEquivalentTo(method))
          return matchingMethod;
      }
      return (MethodSymbol) null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static TypeArray CreateParameterArray(
      MemberInfo associatedInfo,
      ParameterInfo[] parameters)
    {
      MethodBase methodBase = associatedInfo as MethodBase;
      bool flag = (object) methodBase != null && (methodBase.CallingConvention & CallingConventions.VarArgs) != 0;
      CType[] ctypeArray = new CType[flag ? parameters.Length + 1 : parameters.Length];
      for (int index = 0; index < parameters.Length; ++index)
        ctypeArray[index] = SymbolTable.GetTypeOfParameter(parameters[index], associatedInfo);
      if (flag)
        ctypeArray[ctypeArray.Length - 1] = (CType) ArgumentListType.Instance;
      return TypeArray.Allocate(ctypeArray);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static CType GetTypeOfParameter(ParameterInfo p, MemberInfo m)
    {
      Type parameterType = p.ParameterType;
      CType typeOfParameter = !parameterType.IsGenericParameter || !(parameterType.DeclaringMethod != (MethodBase) null) || !((MemberInfo) parameterType.DeclaringMethod == m) ? SymbolTable.GetCTypeFromType(parameterType) : (CType) SymbolTable.LoadMethodTypeParameter(SymbolTable.FindMethodFromMemberInfo(m), parameterType);
      if (typeOfParameter is ParameterModifierType parameterModifierType && p.IsOut && !p.IsIn)
        typeOfParameter = (CType) TypeManager.GetParameterModifier(parameterModifierType.ParameterType, true);
      return typeOfParameter;
    }

    private static bool DoesMethodHaveParameterArray(ParameterInfo[] parameters)
    {
      if (parameters.Length == 0)
        return false;
      foreach (object customAttribute in parameters[parameters.Length - 1].GetCustomAttributes(false))
      {
        if (customAttribute is ParamArrayAttribute)
          return true;
      }
      return false;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static SymWithType GetSlotForOverride(MethodInfo method)
    {
      if (!method.IsVirtual || !method.IsHideBySig)
        return (SymWithType) null;
      MethodInfo baseDefinition = method.GetBaseDefinition();
      if (baseDefinition == method)
        return (SymWithType) null;
      AggregateSymbol owningAggregate = ((AggregateType) SymbolTable.GetCTypeFromType(baseDefinition.DeclaringType)).OwningAggregate;
      return new SymWithType((Symbol) SymbolTable.FindMethodFromMemberInfo((MemberInfo) baseDefinition), owningAggregate.getThisType());
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static MethodSymbol FindMethodFromMemberInfo(MemberInfo baseMemberInfo)
    {
      AggregateSymbol owningAggregate = ((AggregateType) SymbolTable.GetCTypeFromType(baseMemberInfo.DeclaringType)).OwningAggregate;
      MethodSymbol methodFromMemberInfo = SymbolLoader.LookupAggMember(SymbolTable.GetName(baseMemberInfo.Name), owningAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol;
      while (methodFromMemberInfo != null && !methodFromMemberInfo.AssociatedMemberInfo.IsEquivalentTo(baseMemberInfo))
        methodFromMemberInfo = methodFromMemberInfo.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol;
      return methodFromMemberInfo;
    }

    internal static bool AggregateContainsMethod(
      AggregateSymbol agg,
      string szName,
      symbmask_t mask)
    {
      return SymbolLoader.LookupAggMember(SymbolTable.GetName(szName), agg, mask) != null;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    internal static void AddConversionsForType(Type type)
    {
      if (type.IsInterface)
        SymbolTable.AddConversionsForOneType(type);
      for (Type type1 = type; type1.BaseType != (Type) null; type1 = type1.BaseType)
        SymbolTable.AddConversionsForOneType(type1);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private static void AddConversionsForOneType(Type type)
    {
      if (type.IsGenericType)
        type = type.GetGenericTypeDefinition();
      if (!SymbolTable.s_typesWithConversionsLoaded.Add(type))
        return;
      CType ctype1 = SymbolTable.GetCTypeFromType(type);
      if (!(ctype1 is AggregateType))
      {
        CType parameterOrElementType;
        while ((parameterOrElementType = ctype1.BaseOrParameterOrElementType) != null)
          ctype1 = parameterOrElementType;
      }
      if (ctype1 is TypeParameterType typeParameterType)
      {
        foreach (CType ctype2 in typeParameterType.Bounds.Items)
          SymbolTable.AddConversionsForType(ctype2.AssociatedSystemType);
      }
      else
      {
        AggregateSymbol owningAggregate = ((AggregateType) ctype1).OwningAggregate;
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
          if (method.DeclaringType == type && method.IsSpecialName && !method.IsGenericMethod)
          {
            MethodKindEnum kind;
            switch (method.Name)
            {
              case "op_Implicit":
                kind = MethodKindEnum.ImplicitConv;
                break;
              case "op_Explicit":
                kind = MethodKindEnum.ExplicitConv;
                break;
              default:
                continue;
            }
            SymbolTable.AddMethodToSymbolTable((MethodBase) method, owningAggregate, kind);
          }
        }
      }
    }

    private static bool IsOperator(MethodInfo method)
    {
      if (method.IsSpecialName && method.IsStatic)
      {
        switch (method.Name)
        {
          case "op_Addition":
          case "op_BitwiseAnd":
          case "op_BitwiseOr":
          case "op_Decrement":
          case "op_Division":
          case "op_Equality":
          case "op_ExclusiveOr":
          case "op_Explicit":
          case "op_False":
          case "op_GreaterThan":
          case "op_GreaterThanOrEqual":
          case "op_Implicit":
          case "op_Increment":
          case "op_Inequality":
          case "op_LeftShift":
          case "op_LessThan":
          case "op_LessThanOrEqual":
          case "op_LogicalNot":
          case "op_Modulus":
          case "op_Multiply":
          case "op_OnesComplement":
          case "op_RightShift":
          case "op_Subtraction":
          case "op_True":
          case "op_UnaryNegation":
          case "op_UnaryPlus":
            return true;
        }
      }
      return false;
    }

    private readonly struct NameHashKey : IEquatable<SymbolTable.NameHashKey>
    {
      internal Type Type { get; }

      internal string Name { get; }

      public NameHashKey(Type type, string name)
      {
        this.Type = type;
        this.Name = name;
      }

      public bool Equals(SymbolTable.NameHashKey other)
      {
        return this.Type.Equals(other.Type) && this.Name.Equals(other.Name);
      }

      public override bool Equals(object obj)
      {
        return obj is SymbolTable.NameHashKey other && this.Equals(other);
      }

      public override int GetHashCode() => this.Type.GetHashCode() ^ this.Name.GetHashCode();
    }
  }
}
