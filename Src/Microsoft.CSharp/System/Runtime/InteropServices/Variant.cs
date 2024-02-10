// Decompiled with JetBrains decompiler
// Type: System.Runtime.InteropServices.Variant
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.ComInterop;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

#nullable disable
namespace System.Runtime.InteropServices
{
  [SupportedOSPlatform("windows")]
  [StructLayout(LayoutKind.Explicit)]
  internal struct Variant
  {
    [FieldOffset(0)]
    private Variant.TypeUnion _typeUnion;
    [FieldOffset(0)]
    private Decimal _decimal;

    public static bool IsPrimitiveType(VarEnum varEnum)
    {
      switch (varEnum)
      {
        case VarEnum.VT_I2:
        case VarEnum.VT_I4:
        case VarEnum.VT_R4:
        case VarEnum.VT_R8:
        case VarEnum.VT_CY:
        case VarEnum.VT_DATE:
        case VarEnum.VT_BSTR:
        case VarEnum.VT_ERROR:
        case VarEnum.VT_BOOL:
        case VarEnum.VT_DECIMAL:
        case VarEnum.VT_I1:
        case VarEnum.VT_UI1:
        case VarEnum.VT_UI2:
        case VarEnum.VT_UI4:
        case VarEnum.VT_I8:
        case VarEnum.VT_UI8:
        case VarEnum.VT_INT:
        case VarEnum.VT_UINT:
          return true;
        default:
          return false;
      }
    }

    public unsafe void CopyFromIndirect(object value)
    {
      VarEnum varEnum = this.VariantType & ~VarEnum.VT_BYREF;
      if (value == null)
      {
        if (varEnum != VarEnum.VT_DISPATCH && varEnum != VarEnum.VT_UNKNOWN && varEnum != VarEnum.VT_BSTR)
          return;
        *(IntPtr*) (void*) this._typeUnion._unionTypes._byref = IntPtr.Zero;
      }
      else if ((varEnum & VarEnum.VT_ARRAY) != VarEnum.VT_EMPTY)
      {
        Variant variant;
        Marshal.GetNativeVariantForObject(value, (IntPtr) (void*) &variant);
        *(IntPtr*) (void*) this._typeUnion._unionTypes._byref = variant._typeUnion._unionTypes._byref;
      }
      else
      {
        switch (varEnum)
        {
          case VarEnum.VT_I2:
            *(short*) (void*) this._typeUnion._unionTypes._byref = (short) value;
            break;
          case VarEnum.VT_I4:
          case VarEnum.VT_INT:
            *(int*) (void*) this._typeUnion._unionTypes._byref = (int) value;
            break;
          case VarEnum.VT_R4:
            *(float*) (void*) this._typeUnion._unionTypes._byref = (float) value;
            break;
          case VarEnum.VT_R8:
            *(double*) (void*) this._typeUnion._unionTypes._byref = (double) value;
            break;
          case VarEnum.VT_CY:
            *(long*) (void*) this._typeUnion._unionTypes._byref = Decimal.ToOACurrency((Decimal) value);
            break;
          case VarEnum.VT_DATE:
            *(double*) (void*) this._typeUnion._unionTypes._byref = ((DateTime) value).ToOADate();
            break;
          case VarEnum.VT_BSTR:
            *(IntPtr*) (void*) this._typeUnion._unionTypes._byref = Marshal.StringToBSTR((string) value);
            break;
          case VarEnum.VT_DISPATCH:
            *(IntPtr*) (void*) this._typeUnion._unionTypes._byref = Marshal.GetIDispatchForObject(value);
            break;
          case VarEnum.VT_ERROR:
            *(int*) (void*) this._typeUnion._unionTypes._byref = ((ErrorWrapper) value).ErrorCode;
            break;
          case VarEnum.VT_BOOL:
            *(short*) (void*) this._typeUnion._unionTypes._byref = (bool) value ? (short) -1 : (short) 0;
            break;
          case VarEnum.VT_VARIANT:
            Marshal.GetNativeVariantForObject(value, this._typeUnion._unionTypes._byref);
            break;
          case VarEnum.VT_UNKNOWN:
            *(IntPtr*) (void*) this._typeUnion._unionTypes._byref = Marshal.GetIUnknownForObject(value);
            break;
          case VarEnum.VT_DECIMAL:
            *(Decimal*) (void*) this._typeUnion._unionTypes._byref = (Decimal) value;
            break;
          case VarEnum.VT_I1:
            *(sbyte*) (void*) this._typeUnion._unionTypes._byref = (sbyte) value;
            break;
          case VarEnum.VT_UI1:
            *(sbyte*) (void*) this._typeUnion._unionTypes._byref = (sbyte) (byte) value;
            break;
          case VarEnum.VT_UI2:
            *(short*) (void*) this._typeUnion._unionTypes._byref = (short) (ushort) value;
            break;
          case VarEnum.VT_UI4:
          case VarEnum.VT_UINT:
            *(int*) (void*) this._typeUnion._unionTypes._byref = (int) (uint) value;
            break;
          case VarEnum.VT_I8:
            *(long*) (void*) this._typeUnion._unionTypes._byref = (long) value;
            break;
          case VarEnum.VT_UI8:
            *(long*) (void*) this._typeUnion._unionTypes._byref = (long) (ulong) value;
            break;
          default:
            throw new ArgumentException();
        }
      }
    }

    public unsafe object ToObject()
    {
      if (this.IsEmpty)
        return (object) null;
      switch (this.VariantType)
      {
        case VarEnum.VT_NULL:
          return (object) DBNull.Value;
        case VarEnum.VT_I2:
          return (object) this.AsI2;
        case VarEnum.VT_I4:
          return (object) this.AsI4;
        case VarEnum.VT_R4:
          return (object) this.AsR4;
        case VarEnum.VT_R8:
          return (object) this.AsR8;
        case VarEnum.VT_CY:
          return (object) this.AsCy;
        case VarEnum.VT_DATE:
          return (object) this.AsDate;
        case VarEnum.VT_BSTR:
          return (object) this.AsBstr;
        case VarEnum.VT_DISPATCH:
          return this.AsDispatch;
        case VarEnum.VT_ERROR:
          return (object) this.AsError;
        case VarEnum.VT_BOOL:
          return (object) this.AsBool;
        case VarEnum.VT_UNKNOWN:
          return this.AsUnknown;
        case VarEnum.VT_DECIMAL:
          return (object) this.AsDecimal;
        case VarEnum.VT_I1:
          return (object) this.AsI1;
        case VarEnum.VT_UI1:
          return (object) this.AsUi1;
        case VarEnum.VT_UI2:
          return (object) this.AsUi2;
        case VarEnum.VT_UI4:
          return (object) this.AsUi4;
        case VarEnum.VT_I8:
          return (object) this.AsI8;
        case VarEnum.VT_UI8:
          return (object) this.AsUi8;
        case VarEnum.VT_INT:
          return (object) this.AsInt;
        case VarEnum.VT_UINT:
          return (object) this.AsUint;
        default:
          fixed (Variant* pSrcNativeVariant = &this)
            return Marshal.GetObjectForNativeVariant((IntPtr) (void*) pSrcNativeVariant);
      }
    }

    public unsafe void Clear()
    {
      VarEnum variantType = this.VariantType;
      if ((variantType & VarEnum.VT_BYREF) != VarEnum.VT_EMPTY)
        this.VariantType = VarEnum.VT_EMPTY;
      else if ((variantType & VarEnum.VT_ARRAY) != VarEnum.VT_EMPTY || variantType == VarEnum.VT_BSTR || variantType == VarEnum.VT_UNKNOWN || variantType == VarEnum.VT_DISPATCH || variantType == VarEnum.VT_VARIANT || variantType == VarEnum.VT_RECORD)
      {
        fixed (Variant* variant = &this)
          Interop.OleAut32.VariantClear((IntPtr) (void*) variant);
      }
      else
        this.VariantType = VarEnum.VT_EMPTY;
    }

    public VarEnum VariantType
    {
      get => (VarEnum) this._typeUnion._vt;
      set => this._typeUnion._vt = (ushort) value;
    }

    public bool IsEmpty => this._typeUnion._vt == (ushort) 0;

    public bool IsByRef => ((uint) this._typeUnion._vt & 16384U) > 0U;

    public void SetAsNULL() => this.VariantType = VarEnum.VT_NULL;

    public sbyte AsI1
    {
      get => this._typeUnion._unionTypes._i1;
      set
      {
        this.VariantType = VarEnum.VT_I1;
        this._typeUnion._unionTypes._i1 = value;
      }
    }

    public short AsI2
    {
      get => this._typeUnion._unionTypes._i2;
      set
      {
        this.VariantType = VarEnum.VT_I2;
        this._typeUnion._unionTypes._i2 = value;
      }
    }

    public int AsI4
    {
      get => this._typeUnion._unionTypes._i4;
      set
      {
        this.VariantType = VarEnum.VT_I4;
        this._typeUnion._unionTypes._i4 = value;
      }
    }

    public long AsI8
    {
      get => this._typeUnion._unionTypes._i8;
      set
      {
        this.VariantType = VarEnum.VT_I8;
        this._typeUnion._unionTypes._i8 = value;
      }
    }

    public byte AsUi1
    {
      get => this._typeUnion._unionTypes._ui1;
      set
      {
        this.VariantType = VarEnum.VT_UI1;
        this._typeUnion._unionTypes._ui1 = value;
      }
    }

    public ushort AsUi2
    {
      get => this._typeUnion._unionTypes._ui2;
      set
      {
        this.VariantType = VarEnum.VT_UI2;
        this._typeUnion._unionTypes._ui2 = value;
      }
    }

    public uint AsUi4
    {
      get => this._typeUnion._unionTypes._ui4;
      set
      {
        this.VariantType = VarEnum.VT_UI4;
        this._typeUnion._unionTypes._ui4 = value;
      }
    }

    public ulong AsUi8
    {
      get => this._typeUnion._unionTypes._ui8;
      set
      {
        this.VariantType = VarEnum.VT_UI8;
        this._typeUnion._unionTypes._ui8 = value;
      }
    }

    public int AsInt
    {
      get => this._typeUnion._unionTypes._int;
      set
      {
        this.VariantType = VarEnum.VT_INT;
        this._typeUnion._unionTypes._int = value;
      }
    }

    public uint AsUint
    {
      get => this._typeUnion._unionTypes._uint;
      set
      {
        this.VariantType = VarEnum.VT_UINT;
        this._typeUnion._unionTypes._uint = value;
      }
    }

    public bool AsBool
    {
      get => this._typeUnion._unionTypes._bool != (short) 0;
      set
      {
        this.VariantType = VarEnum.VT_BOOL;
        this._typeUnion._unionTypes._bool = value ? (short) -1 : (short) 0;
      }
    }

    public int AsError
    {
      get => this._typeUnion._unionTypes._error;
      set
      {
        this.VariantType = VarEnum.VT_ERROR;
        this._typeUnion._unionTypes._error = value;
      }
    }

    public float AsR4
    {
      get => this._typeUnion._unionTypes._r4;
      set
      {
        this.VariantType = VarEnum.VT_R4;
        this._typeUnion._unionTypes._r4 = value;
      }
    }

    public double AsR8
    {
      get => this._typeUnion._unionTypes._r8;
      set
      {
        this.VariantType = VarEnum.VT_R8;
        this._typeUnion._unionTypes._r8 = value;
      }
    }

    public Decimal AsDecimal
    {
      get
      {
        Variant variant = this;
        variant._typeUnion._vt = (ushort) 0;
        return variant._decimal;
      }
      set
      {
        this.VariantType = VarEnum.VT_DECIMAL;
        this._decimal = value;
        this._typeUnion._vt = (ushort) 14;
      }
    }

    public Decimal AsCy
    {
      get => Decimal.FromOACurrency(this._typeUnion._unionTypes._cy);
      set
      {
        this.VariantType = VarEnum.VT_CY;
        this._typeUnion._unionTypes._cy = Decimal.ToOACurrency(value);
      }
    }

    public DateTime AsDate
    {
      get => DateTime.FromOADate(this._typeUnion._unionTypes._date);
      set
      {
        this.VariantType = VarEnum.VT_DATE;
        this._typeUnion._unionTypes._date = value.ToOADate();
      }
    }

    public string AsBstr
    {
      get
      {
        return this._typeUnion._unionTypes._bstr == IntPtr.Zero ? (string) null : Marshal.PtrToStringBSTR(this._typeUnion._unionTypes._bstr);
      }
      set
      {
        this.VariantType = VarEnum.VT_BSTR;
        this._typeUnion._unionTypes._bstr = Marshal.StringToBSTR(value);
      }
    }

    public object AsUnknown
    {
      get
      {
        return this._typeUnion._unionTypes._unknown == IntPtr.Zero ? (object) null : Marshal.GetObjectForIUnknown(this._typeUnion._unionTypes._unknown);
      }
      set
      {
        this.VariantType = VarEnum.VT_UNKNOWN;
        if (value == null)
          this._typeUnion._unionTypes._unknown = IntPtr.Zero;
        else
          this._typeUnion._unionTypes._unknown = Marshal.GetIUnknownForObject(value);
      }
    }

    public object AsDispatch
    {
      get
      {
        return this._typeUnion._unionTypes._dispatch == IntPtr.Zero ? (object) null : Marshal.GetObjectForIUnknown(this._typeUnion._unionTypes._dispatch);
      }
      set
      {
        this.VariantType = VarEnum.VT_DISPATCH;
        if (value == null)
          this._typeUnion._unionTypes._dispatch = IntPtr.Zero;
        else
          this._typeUnion._unionTypes._dispatch = Marshal.GetIDispatchForObject(value);
      }
    }

    public IntPtr AsByRefVariant => this._typeUnion._unionTypes._pvarVal;

    public void SetAsByrefI1(ref sbyte value) => this.SetAsByref<sbyte>(ref value, VarEnum.VT_I1);

    public void SetAsByrefI2(ref short value) => this.SetAsByref<short>(ref value, VarEnum.VT_I2);

    public void SetAsByrefI4(ref int value) => this.SetAsByref<int>(ref value, VarEnum.VT_I4);

    public void SetAsByrefI8(ref long value) => this.SetAsByref<long>(ref value, VarEnum.VT_I8);

    public void SetAsByrefUi1(ref byte value) => this.SetAsByref<byte>(ref value, VarEnum.VT_UI1);

    public void SetAsByrefUi2(ref ushort value)
    {
      this.SetAsByref<ushort>(ref value, VarEnum.VT_UI2);
    }

    public void SetAsByrefUi4(ref uint value) => this.SetAsByref<uint>(ref value, VarEnum.VT_UI4);

    public void SetAsByrefUi8(ref ulong value) => this.SetAsByref<ulong>(ref value, VarEnum.VT_UI8);

    public void SetAsByrefInt(ref int value) => this.SetAsByref<int>(ref value, VarEnum.VT_INT);

    public void SetAsByrefUint(ref uint value) => this.SetAsByref<uint>(ref value, VarEnum.VT_UINT);

    public void SetAsByrefBool(ref short value)
    {
      this.SetAsByref<short>(ref value, VarEnum.VT_BOOL);
    }

    public void SetAsByrefError(ref int value) => this.SetAsByref<int>(ref value, VarEnum.VT_ERROR);

    public void SetAsByrefR4(ref float value) => this.SetAsByref<float>(ref value, VarEnum.VT_R4);

    public void SetAsByrefR8(ref double value) => this.SetAsByref<double>(ref value, VarEnum.VT_R8);

    public void SetAsByrefDecimal(ref Decimal value)
    {
      this.SetAsByref<Decimal>(ref value, VarEnum.VT_DECIMAL);
    }

    public void SetAsByrefCy(ref long value) => this.SetAsByref<long>(ref value, VarEnum.VT_CY);

    public void SetAsByrefDate(ref double value)
    {
      this.SetAsByref<double>(ref value, VarEnum.VT_DATE);
    }

    public void SetAsByrefBstr(ref IntPtr value)
    {
      this.SetAsByref<IntPtr>(ref value, VarEnum.VT_BSTR);
    }

    public void SetAsByrefUnknown(ref IntPtr value)
    {
      this.SetAsByref<IntPtr>(ref value, VarEnum.VT_UNKNOWN);
    }

    public void SetAsByrefDispatch(ref IntPtr value)
    {
      this.SetAsByref<IntPtr>(ref value, VarEnum.VT_DISPATCH);
    }

    public object AsVariant
    {
      get => Marshal.GetObjectForNativeVariant(UnsafeMethods.ConvertVariantByrefToPtr(ref this));
      set
      {
        if (value == null)
          return;
        UnsafeMethods.InitVariantForObject(value, ref this);
      }
    }

    public void SetAsByrefVariant(ref Variant value)
    {
      this.SetAsByref<Variant>(ref value, VarEnum.VT_VARIANT);
    }

    public unsafe void SetAsByrefVariantIndirect(ref Variant value)
    {
      switch (value.VariantType)
      {
        case VarEnum.VT_EMPTY:
        case VarEnum.VT_NULL:
          this.SetAsByrefVariant(ref value);
          return;
        case VarEnum.VT_DECIMAL:
          this._typeUnion._unionTypes._byref = (IntPtr) Unsafe.AsPointer<Decimal>(ref value._decimal);
          break;
        case VarEnum.VT_RECORD:
          this._typeUnion._unionTypes._record = value._typeUnion._unionTypes._record;
          break;
        default:
          this._typeUnion._unionTypes._byref = (IntPtr) Unsafe.AsPointer<IntPtr>(ref value._typeUnion._unionTypes._byref);
          break;
      }
      this.VariantType = value.VariantType | VarEnum.VT_BYREF;
    }

    private unsafe void SetAsByref<T>(ref T value, VarEnum type)
    {
      this.VariantType = type | VarEnum.VT_BYREF;
      this._typeUnion._unionTypes._byref = (IntPtr) Unsafe.AsPointer<T>(ref value);
    }

    internal static PropertyInfo GetAccessor(VarEnum varType)
    {
      switch (varType)
      {
        case VarEnum.VT_I2:
          return typeof (Variant).GetProperty("AsI2");
        case VarEnum.VT_I4:
          return typeof (Variant).GetProperty("AsI4");
        case VarEnum.VT_R4:
          return typeof (Variant).GetProperty("AsR4");
        case VarEnum.VT_R8:
          return typeof (Variant).GetProperty("AsR8");
        case VarEnum.VT_CY:
          return typeof (Variant).GetProperty("AsCy");
        case VarEnum.VT_DATE:
          return typeof (Variant).GetProperty("AsDate");
        case VarEnum.VT_BSTR:
          return typeof (Variant).GetProperty("AsBstr");
        case VarEnum.VT_DISPATCH:
          return typeof (Variant).GetProperty("AsDispatch");
        case VarEnum.VT_ERROR:
          return typeof (Variant).GetProperty("AsError");
        case VarEnum.VT_BOOL:
          return typeof (Variant).GetProperty("AsBool");
        case VarEnum.VT_VARIANT:
        case VarEnum.VT_RECORD:
        case VarEnum.VT_ARRAY:
          return typeof (Variant).GetProperty("AsVariant");
        case VarEnum.VT_UNKNOWN:
          return typeof (Variant).GetProperty("AsUnknown");
        case VarEnum.VT_DECIMAL:
          return typeof (Variant).GetProperty("AsDecimal");
        case VarEnum.VT_I1:
          return typeof (Variant).GetProperty("AsI1");
        case VarEnum.VT_UI1:
          return typeof (Variant).GetProperty("AsUi1");
        case VarEnum.VT_UI2:
          return typeof (Variant).GetProperty("AsUi2");
        case VarEnum.VT_UI4:
          return typeof (Variant).GetProperty("AsUi4");
        case VarEnum.VT_I8:
          return typeof (Variant).GetProperty("AsI8");
        case VarEnum.VT_UI8:
          return typeof (Variant).GetProperty("AsUi8");
        case VarEnum.VT_INT:
          return typeof (Variant).GetProperty("AsInt");
        case VarEnum.VT_UINT:
          return typeof (Variant).GetProperty("AsUint");
        default:
          throw new NotSupportedException();
      }
    }

    internal static MethodInfo GetByrefSetter(VarEnum varType)
    {
      switch (varType)
      {
        case VarEnum.VT_I2:
          return typeof (Variant).GetMethod("SetAsByrefI2");
        case VarEnum.VT_I4:
          return typeof (Variant).GetMethod("SetAsByrefI4");
        case VarEnum.VT_R4:
          return typeof (Variant).GetMethod("SetAsByrefR4");
        case VarEnum.VT_R8:
          return typeof (Variant).GetMethod("SetAsByrefR8");
        case VarEnum.VT_CY:
          return typeof (Variant).GetMethod("SetAsByrefCy");
        case VarEnum.VT_DATE:
          return typeof (Variant).GetMethod("SetAsByrefDate");
        case VarEnum.VT_BSTR:
          return typeof (Variant).GetMethod("SetAsByrefBstr");
        case VarEnum.VT_DISPATCH:
          return typeof (Variant).GetMethod("SetAsByrefDispatch");
        case VarEnum.VT_ERROR:
          return typeof (Variant).GetMethod("SetAsByrefError");
        case VarEnum.VT_BOOL:
          return typeof (Variant).GetMethod("SetAsByrefBool");
        case VarEnum.VT_VARIANT:
          return typeof (Variant).GetMethod("SetAsByrefVariant");
        case VarEnum.VT_UNKNOWN:
          return typeof (Variant).GetMethod("SetAsByrefUnknown");
        case VarEnum.VT_DECIMAL:
          return typeof (Variant).GetMethod("SetAsByrefDecimal");
        case VarEnum.VT_I1:
          return typeof (Variant).GetMethod("SetAsByrefI1");
        case VarEnum.VT_UI1:
          return typeof (Variant).GetMethod("SetAsByrefUi1");
        case VarEnum.VT_UI2:
          return typeof (Variant).GetMethod("SetAsByrefUi2");
        case VarEnum.VT_UI4:
          return typeof (Variant).GetMethod("SetAsByrefUi4");
        case VarEnum.VT_I8:
          return typeof (Variant).GetMethod("SetAsByrefI8");
        case VarEnum.VT_UI8:
          return typeof (Variant).GetMethod("SetAsByrefUi8");
        case VarEnum.VT_INT:
          return typeof (Variant).GetMethod("SetAsByrefInt");
        case VarEnum.VT_UINT:
          return typeof (Variant).GetMethod("SetAsByrefUint");
        case VarEnum.VT_RECORD:
        case VarEnum.VT_ARRAY:
          return typeof (Variant).GetMethod("SetAsByrefVariantIndirect");
        default:
          throw new NotSupportedException();
      }
    }

    public override string ToString()
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
      interpolatedStringHandler.AppendLiteral("Variant (");
      interpolatedStringHandler.AppendFormatted<VarEnum>(this.VariantType);
      interpolatedStringHandler.AppendLiteral(")");
      return interpolatedStringHandler.ToStringAndClear();
    }

    public void SetAsIConvertible(IConvertible value)
    {
      TypeCode typeCode = value.GetTypeCode();
      CultureInfo currentCulture = CultureInfo.CurrentCulture;
      switch (typeCode)
      {
        case TypeCode.Empty:
          break;
        case TypeCode.Object:
          this.AsUnknown = (object) value;
          break;
        case TypeCode.DBNull:
          this.SetAsNULL();
          break;
        case TypeCode.Boolean:
          this.AsBool = value.ToBoolean((IFormatProvider) currentCulture);
          break;
        case TypeCode.Char:
          this.AsUi2 = (ushort) value.ToChar((IFormatProvider) currentCulture);
          break;
        case TypeCode.SByte:
          this.AsI1 = value.ToSByte((IFormatProvider) currentCulture);
          break;
        case TypeCode.Byte:
          this.AsUi1 = value.ToByte((IFormatProvider) currentCulture);
          break;
        case TypeCode.Int16:
          this.AsI2 = value.ToInt16((IFormatProvider) currentCulture);
          break;
        case TypeCode.UInt16:
          this.AsUi2 = value.ToUInt16((IFormatProvider) currentCulture);
          break;
        case TypeCode.Int32:
          this.AsI4 = value.ToInt32((IFormatProvider) currentCulture);
          break;
        case TypeCode.UInt32:
          this.AsUi4 = value.ToUInt32((IFormatProvider) currentCulture);
          break;
        case TypeCode.Int64:
          this.AsI8 = value.ToInt64((IFormatProvider) currentCulture);
          break;
        case TypeCode.UInt64:
          this.AsI8 = value.ToInt64((IFormatProvider) currentCulture);
          break;
        case TypeCode.Single:
          this.AsR4 = value.ToSingle((IFormatProvider) currentCulture);
          break;
        case TypeCode.Double:
          this.AsR8 = value.ToDouble((IFormatProvider) currentCulture);
          break;
        case TypeCode.Decimal:
          this.AsDecimal = value.ToDecimal((IFormatProvider) currentCulture);
          break;
        case TypeCode.DateTime:
          this.AsDate = value.ToDateTime((IFormatProvider) currentCulture);
          break;
        case TypeCode.String:
          this.AsBstr = value.ToString((IFormatProvider) currentCulture);
          break;
        default:
          throw new NotSupportedException();
      }
    }

    private struct TypeUnion
    {
      public ushort _vt;
      public ushort _wReserved1;
      public ushort _wReserved2;
      public ushort _wReserved3;
      public Variant.UnionTypes _unionTypes;
    }

    private struct Record
    {
      public IntPtr _record;
      public IntPtr _recordInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct UnionTypes
    {
      [FieldOffset(0)]
      public sbyte _i1;
      [FieldOffset(0)]
      public short _i2;
      [FieldOffset(0)]
      public int _i4;
      [FieldOffset(0)]
      public long _i8;
      [FieldOffset(0)]
      public byte _ui1;
      [FieldOffset(0)]
      public ushort _ui2;
      [FieldOffset(0)]
      public uint _ui4;
      [FieldOffset(0)]
      public ulong _ui8;
      [FieldOffset(0)]
      public int _int;
      [FieldOffset(0)]
      public uint _uint;
      [FieldOffset(0)]
      public short _bool;
      [FieldOffset(0)]
      public int _error;
      [FieldOffset(0)]
      public float _r4;
      [FieldOffset(0)]
      public double _r8;
      [FieldOffset(0)]
      public long _cy;
      [FieldOffset(0)]
      public double _date;
      [FieldOffset(0)]
      public IntPtr _bstr;
      [FieldOffset(0)]
      public IntPtr _unknown;
      [FieldOffset(0)]
      public IntPtr _dispatch;
      [FieldOffset(0)]
      public IntPtr _pvarVal;
      [FieldOffset(0)]
      public IntPtr _byref;
      [FieldOffset(0)]
      public Variant.Record _record;
    }
  }
}
