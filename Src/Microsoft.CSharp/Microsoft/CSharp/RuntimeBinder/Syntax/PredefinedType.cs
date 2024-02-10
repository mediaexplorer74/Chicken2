// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Syntax.PredefinedType
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Syntax
{
  internal enum PredefinedType : uint
  {
    PT_BYTE = 0,
    PT_SHORT = 1,
    PT_INT = 2,
    PT_LONG = 3,
    PT_FLOAT = 4,
    PT_DOUBLE = 5,
    PT_DECIMAL = 6,
    PT_CHAR = 7,
    PT_BOOL = 8,
    PT_SBYTE = 9,
    PT_USHORT = 10, // 0x0000000A
    PT_UINT = 11, // 0x0000000B
    PT_ULONG = 12, // 0x0000000C
    FirstNonSimpleType = 13, // 0x0000000D
    PT_INTPTR = 13, // 0x0000000D
    PT_UINTPTR = 14, // 0x0000000E
    PT_OBJECT = 15, // 0x0000000F
    PT_STRING = 16, // 0x00000010
    PT_DELEGATE = 17, // 0x00000011
    PT_MULTIDEL = 18, // 0x00000012
    PT_ARRAY = 19, // 0x00000013
    PT_TYPE = 20, // 0x00000014
    PT_VALUE = 21, // 0x00000015
    PT_ENUM = 22, // 0x00000016
    PT_DATETIME = 23, // 0x00000017
    PT_IENUMERABLE = 24, // 0x00000018
    PT_G_IENUMERABLE = 25, // 0x00000019
    PT_G_OPTIONAL = 26, // 0x0000001A
    PT_G_IQUERYABLE = 27, // 0x0000001B
    PT_G_ICOLLECTION = 28, // 0x0000001C
    PT_G_ILIST = 29, // 0x0000001D
    PT_G_EXPRESSION = 30, // 0x0000001E
    PT_EXPRESSION = 31, // 0x0000001F
    PT_BINARYEXPRESSION = 32, // 0x00000020
    PT_UNARYEXPRESSION = 33, // 0x00000021
    PT_CONSTANTEXPRESSION = 34, // 0x00000022
    PT_PARAMETEREXPRESSION = 35, // 0x00000023
    PT_MEMBEREXPRESSION = 36, // 0x00000024
    PT_METHODCALLEXPRESSION = 37, // 0x00000025
    PT_NEWEXPRESSION = 38, // 0x00000026
    PT_NEWARRAYEXPRESSION = 39, // 0x00000027
    PT_INVOCATIONEXPRESSION = 40, // 0x00000028
    PT_FIELDINFO = 41, // 0x00000029
    PT_METHODINFO = 42, // 0x0000002A
    PT_CONSTRUCTORINFO = 43, // 0x0000002B
    PT_PROPERTYINFO = 44, // 0x0000002C
    PT_MISSING = 45, // 0x0000002D
    PT_G_IREADONLYLIST = 46, // 0x0000002E
    PT_G_IREADONLYCOLLECTION = 47, // 0x0000002F
    PT_FUNC = 48, // 0x00000030
    PT_COUNT = 49, // 0x00000031
    PT_VOID = 50, // 0x00000032
    PT_UNDEFINEDINDEX = 4294967295, // 0xFFFFFFFF
  }
}
