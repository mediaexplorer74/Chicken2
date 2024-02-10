// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExpressionKind
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal enum ExpressionKind
  {
    NoOp = 0,
    BinaryOp = 1,
    UnaryOp = 2,
    Assignment = 3,
    List = 4,
    ArrayIndex = 5,
    Call = 6,
    Field = 7,
    Local = 8,
    Constant = 9,
    Class = 10, // 0x0000000A
    Property = 11, // 0x0000000B
    Multi = 12, // 0x0000000C
    MultiGet = 13, // 0x0000000D
    Wrap = 14, // 0x0000000E
    Concat = 15, // 0x0000000F
    ArrayInit = 16, // 0x00000010
    Cast = 17, // 0x00000011
    UserDefinedConversion = 18, // 0x00000012
    TypeOf = 19, // 0x00000013
    ZeroInit = 20, // 0x00000014
    UserLogicalOp = 21, // 0x00000015
    MemberGroup = 22, // 0x00000016
    BoundLambda = 23, // 0x00000017
    FieldInfo = 24, // 0x00000018
    MethodInfo = 25, // 0x00000019
    PropertyInfo = 26, // 0x0000001A
    NamedArgumentSpecification = 27, // 0x0000001B
    ExpressionKindCount = 28, // 0x0000001C
    TypeLimit = 28, // 0x0000001C
    EqualsParam = 29, // 0x0000001D
    FirstOp = 29, // 0x0000001D
    Compare = 30, // 0x0000001E
    True = 31, // 0x0000001F
    False = 32, // 0x00000020
    Inc = 33, // 0x00000021
    Dec = 34, // 0x00000022
    LogicalNot = 35, // 0x00000023
    Eq = 36, // 0x00000024
    RelationalMin = 36, // 0x00000024
    NotEq = 37, // 0x00000025
    LessThan = 38, // 0x00000026
    LessThanOrEqual = 39, // 0x00000027
    GreaterThan = 40, // 0x00000028
    GreaterThanOrEqual = 41, // 0x00000029
    RelationalMax = 41, // 0x00000029
    Add = 42, // 0x0000002A
    Subtract = 43, // 0x0000002B
    Multiply = 44, // 0x0000002C
    Divide = 45, // 0x0000002D
    Modulo = 46, // 0x0000002E
    Negate = 47, // 0x0000002F
    UnaryPlus = 48, // 0x00000030
    BitwiseAnd = 49, // 0x00000031
    BitwiseOr = 50, // 0x00000032
    BitwiseExclusiveOr = 51, // 0x00000033
    BitwiseNot = 52, // 0x00000034
    LeftShirt = 53, // 0x00000035
    RightShift = 54, // 0x00000036
    LogicalAnd = 55, // 0x00000037
    LogicalOr = 56, // 0x00000038
    Sequence = 57, // 0x00000039
    Save = 58, // 0x0000003A
    Swap = 59, // 0x0000003B
    Indir = 60, // 0x0000003C
    Addr = 61, // 0x0000003D
    StringEq = 62, // 0x0000003E
    StringNotEq = 63, // 0x0000003F
    DelegateEq = 64, // 0x00000040
    DelegateNotEq = 65, // 0x00000041
    DelegateAdd = 66, // 0x00000042
    DelegateSubtract = 67, // 0x00000043
    DecimalNegate = 68, // 0x00000044
    DecimalInc = 69, // 0x00000045
    DecimalDec = 70, // 0x00000046
    MultiOffset = 71, // 0x00000047
  }
}
