﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Syntax.NameManager
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Syntax
{
  internal static class NameManager
  {
    private static readonly Name[] s_predefinedNames = new Name[121]
    {
      new Name(".ctor"),
      new Name("Finalize"),
      new Name(".cctor"),
      new Name("*"),
      new Name("?*"),
      new Name("#"),
      new Name("&"),
      new Name("[X\001"),
      new Name("[X\002"),
      new Name("[X\003"),
      new Name("[G\001"),
      new Name("[G\002"),
      new Name("[G\003"),
      new Name("Invoke"),
      new Name("Length"),
      new Name("Item"),
      new Name("$Item$"),
      new Name("Combine"),
      new Name("Remove"),
      new Name("op_Explicit"),
      new Name("op_Implicit"),
      new Name("op_UnaryPlus"),
      new Name("op_UnaryNegation"),
      new Name("op_OnesComplement"),
      new Name("op_Increment"),
      new Name("op_Decrement"),
      new Name("op_Addition"),
      new Name("op_Subtraction"),
      new Name("op_Multiply"),
      new Name("op_Division"),
      new Name("op_Modulus"),
      new Name("op_ExclusiveOr"),
      new Name("op_BitwiseAnd"),
      new Name("op_BitwiseOr"),
      new Name("op_LeftShift"),
      new Name("op_RightShift"),
      new Name("op_Equals"),
      new Name("op_Compare"),
      new Name("op_Equality"),
      new Name("op_Inequality"),
      new Name("op_GreaterThan"),
      new Name("op_LessThan"),
      new Name("op_GreaterThanOrEqual"),
      new Name("op_LessThanOrEqual"),
      new Name("op_True"),
      new Name("op_False"),
      new Name("op_LogicalNot"),
      new Name("Concat"),
      new Name("Add"),
      new Name("get_Length"),
      new Name("get_Chars"),
      new Name("CreateDelegate"),
      new Name("FixedElementField"),
      new Name("HasValue"),
      new Name("get_HasValue"),
      new Name("Value"),
      new Name("get_Value"),
      new Name("GetValueOrDefault"),
      new Name("?"),
      new Name("<?>"),
      new Name("Lambda"),
      new Name("Parameter"),
      new Name("Constant"),
      new Name("Convert"),
      new Name("ConvertChecked"),
      new Name("AddChecked"),
      new Name("Divide"),
      new Name("Modulo"),
      new Name("Multiply"),
      new Name("MultiplyChecked"),
      new Name("Subtract"),
      new Name("SubtractChecked"),
      new Name("And"),
      new Name("Or"),
      new Name("ExclusiveOr"),
      new Name("LeftShift"),
      new Name("RightShift"),
      new Name("AndAlso"),
      new Name("OrElse"),
      new Name("Equal"),
      new Name("NotEqual"),
      new Name("GreaterThanOrEqual"),
      new Name("GreaterThan"),
      new Name("LessThan"),
      new Name("LessThanOrEqual"),
      new Name("ArrayIndex"),
      new Name("Assign"),
      new Name("Condition"),
      new Name("Field"),
      new Name("Call"),
      new Name("New"),
      new Name("Quote"),
      new Name("ArrayLength"),
      new Name("UnaryPlus"),
      new Name("Negate"),
      new Name("NegateChecked"),
      new Name("Not"),
      new Name("NewArrayInit"),
      new Name("Property"),
      new Name("AddEventHandler"),
      new Name("RemoveEventHandler"),
      new Name("InvocationList"),
      new Name("GetOrCreateEventRegistrationTokenTable"),
      new Name("void"),
      new Name(""),
      new Name("true"),
      new Name("false"),
      new Name("null"),
      new Name("base"),
      new Name("this"),
      new Name("explicit"),
      new Name("implicit"),
      new Name("__arglist"),
      new Name("__makeref"),
      new Name("__reftype"),
      new Name("__refvalue"),
      new Name("as"),
      new Name("checked"),
      new Name("is"),
      new Name("typeof"),
      new Name("unchecked")
    };
    private static readonly NameTable s_names = NameManager.GetKnownNames();

    private static NameTable GetKnownNames()
    {
      NameTable knownNames = new NameTable();
      foreach (Name predefinedName in NameManager.s_predefinedNames)
        knownNames.Add(predefinedName);
      return knownNames;
    }

    internal static Name Add(string key)
    {
      return key != null ? NameManager.s_names.Add(key) : throw Error.InternalCompilerError();
    }

    internal static Name Add(string key, int length) => NameManager.s_names.Add(key, length);

    internal static Name GetPredefinedName(PredefinedName id)
    {
      return NameManager.s_predefinedNames[(int) id];
    }
  }
}
