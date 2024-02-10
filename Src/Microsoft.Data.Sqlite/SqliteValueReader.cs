// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteValueReader
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using System;
using System.Globalization;
using System.Text;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal abstract class SqliteValueReader
  {
    public abstract int FieldCount { get; }

    protected abstract int GetSqliteType(int ordinal);

    public virtual bool IsDBNull(int ordinal) => this.GetSqliteType(ordinal) == 5;

    public virtual bool GetBoolean(int ordinal) => this.GetInt64(ordinal) != 0L;

    public virtual byte GetByte(int ordinal) => checked ((byte) this.GetInt64(ordinal));

    public virtual char GetChar(int ordinal)
    {
      if (this.GetSqliteType(ordinal) == 3)
      {
        string str = this.GetString(ordinal);
        if (str.Length == 1)
          return str[0];
      }
      return checked ((char) this.GetInt64(ordinal));
    }

    public virtual DateTime GetDateTime(int ordinal)
    {
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
        case 2:
          return SqliteValueReader.FromJulianDate(this.GetDouble(ordinal));
        default:
          return DateTime.Parse(this.GetString(ordinal), (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    public virtual DateTimeOffset GetDateTimeOffset(int ordinal)
    {
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
        case 2:
          return new DateTimeOffset(SqliteValueReader.FromJulianDate(this.GetDouble(ordinal)));
        default:
          return DateTimeOffset.Parse(this.GetString(ordinal), (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    public virtual DateOnly GetDateOnly(int ordinal)
    {
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
        case 2:
          return DateOnly.FromDateTime(SqliteValueReader.FromJulianDate(this.GetDouble(ordinal)));
        default:
          return DateOnly.Parse(this.GetString(ordinal), (IFormatProvider) CultureInfo.InvariantCulture);
      }
    }

    public virtual TimeOnly GetTimeOnly(int ordinal)
    {
      return TimeOnly.Parse(this.GetString(ordinal), (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public virtual Decimal GetDecimal(int ordinal)
    {
      return Decimal.Parse(this.GetString(ordinal), NumberStyles.Number | NumberStyles.AllowExponent, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public virtual double GetDouble(int ordinal)
    {
      return !this.IsDBNull(ordinal) ? this.GetDoubleCore(ordinal) : throw new InvalidOperationException(this.GetOnNullErrorMsg(ordinal));
    }

    protected abstract double GetDoubleCore(int ordinal);

    public virtual float GetFloat(int ordinal) => (float) this.GetDouble(ordinal);

    public virtual Guid GetGuid(int ordinal)
    {
      if (this.GetSqliteType(ordinal) != 4)
        return new Guid(this.GetString(ordinal));
      byte[] blob = this.GetBlob(ordinal);
      return blob.Length != 16 ? new Guid(Encoding.UTF8.GetString(blob, 0, blob.Length)) : new Guid(blob);
    }

    public virtual TimeSpan GetTimeSpan(int ordinal)
    {
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
        case 2:
          return TimeSpan.FromDays(this.GetDouble(ordinal));
        default:
          return TimeSpan.Parse(this.GetString(ordinal));
      }
    }

    public virtual short GetInt16(int ordinal) => checked ((short) this.GetInt64(ordinal));

    public virtual int GetInt32(int ordinal) => checked ((int) this.GetInt64(ordinal));

    public virtual long GetInt64(int ordinal)
    {
      return !this.IsDBNull(ordinal) ? this.GetInt64Core(ordinal) : throw new InvalidOperationException(this.GetOnNullErrorMsg(ordinal));
    }

    protected abstract long GetInt64Core(int ordinal);

    public virtual string GetString(int ordinal)
    {
      return !this.IsDBNull(ordinal) ? this.GetStringCore(ordinal) : throw new InvalidOperationException(this.GetOnNullErrorMsg(ordinal));
    }

    protected abstract string GetStringCore(int ordinal);

    public virtual T? GetFieldValue<T>(int ordinal)
    {
      if (this.IsDBNull(ordinal) && typeof (T).IsNullable())
        return this.GetNull<T>(ordinal);
      Type type = typeof (T).UnwrapNullableType().UnwrapEnumType();
      if (type == typeof (bool))
        return (T) (ValueType) this.GetBoolean(ordinal);
      if (type == typeof (byte))
        return (T) (ValueType) this.GetByte(ordinal);
      if (type == typeof (byte[]))
        return (T) this.GetBlob(ordinal);
      if (type == typeof (char))
        return (T) (ValueType) this.GetChar(ordinal);
      if (type == typeof (DateTime))
        return (T) (ValueType) this.GetDateTime(ordinal);
      if (type == typeof (DateTimeOffset))
        return (T) (ValueType) this.GetDateTimeOffset(ordinal);
      if (type == typeof (DateOnly))
        return (T) (ValueType) this.GetDateOnly(ordinal);
      if (type == typeof (TimeOnly))
        return (T) (ValueType) this.GetTimeOnly(ordinal);
      if (type == typeof (DBNull))
        throw new InvalidCastException();
      if (type == typeof (Decimal))
        return (T) (ValueType) this.GetDecimal(ordinal);
      if (type == typeof (double))
        return (T) (ValueType) this.GetDouble(ordinal);
      if (type == typeof (float))
        return (T) (ValueType) this.GetFloat(ordinal);
      if (type == typeof (Guid))
        return (T) (ValueType) this.GetGuid(ordinal);
      if (type == typeof (int))
        return (T) (ValueType) this.GetInt32(ordinal);
      if (type == typeof (long))
        return (T) (ValueType) this.GetInt64(ordinal);
      if (type == typeof (sbyte))
        return (T) (ValueType) checked ((sbyte) this.GetInt64(ordinal));
      if (type == typeof (short))
        return (T) (ValueType) this.GetInt16(ordinal);
      if (type == typeof (string))
        return (T) this.GetString(ordinal);
      if (type == typeof (TimeSpan))
        return (T) (ValueType) this.GetTimeSpan(ordinal);
      if (type == typeof (uint))
        return (T) (ValueType) checked ((uint) this.GetInt64(ordinal));
      if (type == typeof (ulong))
        return (T) (ValueType) (ulong) this.GetInt64(ordinal);
      return type == typeof (ushort) ? (T) (ValueType) checked ((ushort) this.GetInt64(ordinal)) : (T) this.GetValue(ordinal);
    }

    public virtual object? GetValue(int ordinal)
    {
      switch (this.GetSqliteType(ordinal))
      {
        case 1:
          return (object) this.GetInt64(ordinal);
        case 2:
          return (object) this.GetDouble(ordinal);
        case 3:
          return (object) this.GetString(ordinal);
        case 5:
          return this.GetNull<object>(ordinal);
        default:
          return (object) this.GetBlob(ordinal);
      }
    }

    public virtual int GetValues(object?[] values)
    {
      int ordinal;
      for (ordinal = 0; ordinal < this.FieldCount; ++ordinal)
        values[ordinal] = this.GetValue(ordinal);
      return ordinal;
    }

    protected virtual byte[]? GetBlob(int ordinal)
    {
      return !this.IsDBNull(ordinal) ? this.GetBlobCore(ordinal) ?? Array.Empty<byte>() : this.GetNull<byte[]>(ordinal);
    }

    protected abstract byte[] GetBlobCore(int ordinal);

    protected virtual T? GetNull<T>(int ordinal)
    {
      return !(typeof (T) == typeof (DBNull)) ? default (T) : (T) DBNull.Value;
    }

    protected virtual string GetOnNullErrorMsg(int ordinal)
    {
      return Resources.CalledOnNullValue((object) ordinal);
    }

    private static DateTime FromJulianDate(double julianDate)
    {
      long num1 = (long) (julianDate * 86400000.0 + 0.5);
      int num2;
      int num3 = (int) (((double) (num2 = (int) ((num1 + 43200000L) / 86400000L)) - 1867216.25) / 36524.25);
      int num4;
      int num5 = (int) (((double) (num4 = num2 + 1 + num3 - num3 / 4 + 1524) - 122.1) / 365.25);
      int num6 = 36525 * (num5 & (int) short.MaxValue) / 100;
      int num7 = (int) ((double) (num4 - num6) / 30.6001);
      int num8 = (int) (30.6001 * (double) num7);
      int num9 = num4 - num6 - num8;
      int num10 = num7 < 14 ? num7 - 1 : num7 - 13;
      int year = num10 > 2 ? num5 - 4716 : num5 - 4715;
      int num11;
      double num12 = (double) (num11 = (int) ((double) (int) ((num1 + 43200000L) % 86400000L) / 1000.0)) - (double) num11;
      int num13 = num11 / 3600;
      int num14 = num11 - num13 * 3600;
      int num15 = num14 / 60;
      double num16 = (double) (num14 - num15 * 60);
      int num17;
      int num18 = (int) Math.Round(((double) (num17 = (int) (num12 + num16)) - (double) num17) * 1000.0);
      int month = num10;
      int day = num9;
      int hour = num13;
      int minute = num15;
      int second = num17;
      int millisecond = num18;
      return new DateTime(year, month, day, hour, minute, second, millisecond);
    }
  }
}
