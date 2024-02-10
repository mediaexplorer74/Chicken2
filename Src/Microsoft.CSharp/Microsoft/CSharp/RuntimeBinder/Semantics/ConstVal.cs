// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ConstVal
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System;
using System.Globalization;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal readonly struct ConstVal
  {
    private static readonly object s_false = (object) false;
    private static readonly object s_true = (object) true;
    private static readonly object s_zeroInt32 = (object) 0;

    private ConstVal(object value) => this.ObjectVal = value;

    public object ObjectVal { get; }

    public bool BooleanVal => ConstVal.SpecialUnbox<bool>(this.ObjectVal);

    public sbyte SByteVal => ConstVal.SpecialUnbox<sbyte>(this.ObjectVal);

    public byte ByteVal => ConstVal.SpecialUnbox<byte>(this.ObjectVal);

    public short Int16Val => ConstVal.SpecialUnbox<short>(this.ObjectVal);

    public ushort UInt16Val => ConstVal.SpecialUnbox<ushort>(this.ObjectVal);

    public int Int32Val => ConstVal.SpecialUnbox<int>(this.ObjectVal);

    public uint UInt32Val => ConstVal.SpecialUnbox<uint>(this.ObjectVal);

    public long Int64Val => ConstVal.SpecialUnbox<long>(this.ObjectVal);

    public ulong UInt64Val => ConstVal.SpecialUnbox<ulong>(this.ObjectVal);

    public float SingleVal => ConstVal.SpecialUnbox<float>(this.ObjectVal);

    public double DoubleVal => ConstVal.SpecialUnbox<double>(this.ObjectVal);

    public Decimal DecimalVal => ConstVal.SpecialUnbox<Decimal>(this.ObjectVal);

    public char CharVal => ConstVal.SpecialUnbox<char>(this.ObjectVal);

    public string StringVal => ConstVal.SpecialUnbox<string>(this.ObjectVal);

    public bool IsNullRef => this.ObjectVal == null;

    public bool IsZero(ConstValKind kind)
    {
      bool flag;
      switch (kind)
      {
        case ConstValKind.String:
          flag = false;
          break;
        case ConstValKind.Decimal:
          flag = this.DecimalVal == 0M;
          break;
        default:
          flag = ConstVal.IsDefault(this.ObjectVal);
          break;
      }
      return flag;
    }

    private static T SpecialUnbox<T>(object o)
    {
      return ConstVal.IsDefault(o) ? default (T) : (T) Convert.ChangeType(o, typeof (T), (IFormatProvider) CultureInfo.InvariantCulture);
    }

    private static bool IsDefault(object o)
    {
      bool flag1 = o == null;
      if (!flag1)
      {
        bool flag2;
        switch (Type.GetTypeCode(o.GetType()))
        {
          case TypeCode.Boolean:
            flag2 = false.Equals(o);
            break;
          case TypeCode.Char:
            flag2 = char.MinValue.Equals(o);
            break;
          case TypeCode.SByte:
            flag2 = (sbyte) 0.Equals(o);
            break;
          case TypeCode.Byte:
            flag2 = (byte) 0.Equals(o);
            break;
          case TypeCode.Int16:
            flag2 = (short) 0.Equals(o);
            break;
          case TypeCode.UInt16:
            flag2 = (ushort) 0.Equals(o);
            break;
          case TypeCode.Int32:
            flag2 = 0.Equals(o);
            break;
          case TypeCode.UInt32:
            flag2 = 0U.Equals(o);
            break;
          case TypeCode.Int64:
            flag2 = 0L.Equals(o);
            break;
          case TypeCode.UInt64:
            flag2 = 0UL.Equals(o);
            break;
          case TypeCode.Single:
            flag2 = 0.0f.Equals(o);
            break;
          case TypeCode.Double:
            flag2 = 0.0.Equals(o);
            break;
          case TypeCode.Decimal:
            flag2 = 0M.Equals(o);
            break;
          default:
            flag2 = false;
            break;
        }
        flag1 = flag2;
      }
      return flag1;
    }

    public static ConstVal GetDefaultValue(ConstValKind kind)
    {
      ConstVal defaultValue;
      switch (kind)
      {
        case ConstValKind.Int:
          defaultValue = new ConstVal(ConstVal.s_zeroInt32);
          break;
        case ConstValKind.Double:
          defaultValue = new ConstVal((object) 0.0);
          break;
        case ConstValKind.Long:
          defaultValue = new ConstVal((object) 0L);
          break;
        case ConstValKind.Decimal:
          defaultValue = new ConstVal((object) 0M);
          break;
        case ConstValKind.Float:
          defaultValue = new ConstVal((object) 0.0f);
          break;
        case ConstValKind.Boolean:
          defaultValue = new ConstVal(ConstVal.s_false);
          break;
        default:
          defaultValue = new ConstVal();
          break;
      }
      return defaultValue;
    }

    public static ConstVal Get(bool value)
    {
      return new ConstVal(value ? ConstVal.s_true : ConstVal.s_false);
    }

    public static ConstVal Get(int value)
    {
      return new ConstVal(value == 0 ? ConstVal.s_zeroInt32 : (object) value);
    }

    public static ConstVal Get(uint value) => new ConstVal((object) value);

    public static ConstVal Get(Decimal value) => new ConstVal((object) value);

    public static ConstVal Get(string value) => new ConstVal((object) value);

    public static ConstVal Get(float value) => new ConstVal((object) value);

    public static ConstVal Get(double value) => new ConstVal((object) value);

    public static ConstVal Get(long value) => new ConstVal((object) value);

    public static ConstVal Get(ulong value) => new ConstVal((object) value);

    public static ConstVal Get(object p) => new ConstVal(p);
  }
}
