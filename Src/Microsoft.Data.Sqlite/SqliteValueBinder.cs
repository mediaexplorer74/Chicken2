// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteValueBinder
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal abstract class SqliteValueBinder
  {
    private readonly object? _value;
    private readonly SqliteType? _sqliteType;
    private static readonly Dictionary<Type, SqliteType> _sqliteTypeMapping = new Dictionary<Type, SqliteType>()
    {
      {
        typeof (bool),
        SqliteType.Integer
      },
      {
        typeof (byte),
        SqliteType.Integer
      },
      {
        typeof (byte[]),
        SqliteType.Blob
      },
      {
        typeof (char),
        SqliteType.Text
      },
      {
        typeof (DateTime),
        SqliteType.Text
      },
      {
        typeof (DateTimeOffset),
        SqliteType.Text
      },
      {
        typeof (DBNull),
        SqliteType.Text
      },
      {
        typeof (Decimal),
        SqliteType.Text
      },
      {
        typeof (double),
        SqliteType.Real
      },
      {
        typeof (float),
        SqliteType.Real
      },
      {
        typeof (Guid),
        SqliteType.Text
      },
      {
        typeof (int),
        SqliteType.Integer
      },
      {
        typeof (long),
        SqliteType.Integer
      },
      {
        typeof (sbyte),
        SqliteType.Integer
      },
      {
        typeof (short),
        SqliteType.Integer
      },
      {
        typeof (string),
        SqliteType.Integer
      },
      {
        typeof (TimeSpan),
        SqliteType.Text
      },
      {
        typeof (uint),
        SqliteType.Integer
      },
      {
        typeof (ulong),
        SqliteType.Integer
      },
      {
        typeof (ushort),
        SqliteType.Integer
      }
    };

    protected SqliteValueBinder(object? value)
      : this(value, new SqliteType?())
    {
    }

    protected SqliteValueBinder(object? value, SqliteType? sqliteType)
    {
      this._value = value;
      this._sqliteType = sqliteType;
    }

    protected abstract void BindInt64(long value);

    protected virtual void BindDouble(double value)
    {
      if (double.IsNaN(value))
        throw new InvalidOperationException(Resources.CannotStoreNaN);
      this.BindDoubleCore(value);
    }

    protected abstract void BindDoubleCore(double value);

    protected abstract void BindText(string value);

    protected abstract void BindBlob(byte[] value);

    protected abstract void BindNull();

    public virtual void Bind()
    {
      if (this._value == null)
      {
        this.BindNull();
      }
      else
      {
        Type typeName = this._value.GetType().UnwrapNullableType().UnwrapEnumType();
        if (typeName == typeof (bool))
          this.BindInt64((bool) this._value ? 1L : 0L);
        else if (typeName == typeof (byte))
          this.BindInt64((long) (byte) this._value);
        else if (typeName == typeof (byte[]))
          this.BindBlob((byte[]) this._value);
        else if (typeName == typeof (char))
        {
          char c = (char) this._value;
          SqliteType? sqliteType1 = this._sqliteType;
          SqliteType sqliteType2 = SqliteType.Integer;
          if (!(sqliteType1.GetValueOrDefault() == sqliteType2 & sqliteType1.HasValue))
            this.BindText(new string(c, 1));
          else
            this.BindInt64((long) c);
        }
        else if (typeName == typeof (DateTime))
        {
          DateTime dateTime = (DateTime) this._value;
          SqliteType? sqliteType3 = this._sqliteType;
          SqliteType sqliteType4 = SqliteType.Real;
          if (sqliteType3.GetValueOrDefault() == sqliteType4 & sqliteType3.HasValue)
            this.BindDouble(SqliteValueBinder.ToJulianDate(dateTime));
          else
            this.BindText(dateTime.ToString("yyyy\\-MM\\-dd HH\\:mm\\:ss.FFFFFFF", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else if (typeName == typeof (DateTimeOffset))
        {
          DateTimeOffset dateTimeOffset = (DateTimeOffset) this._value;
          SqliteType? sqliteType5 = this._sqliteType;
          SqliteType sqliteType6 = SqliteType.Real;
          if (sqliteType5.GetValueOrDefault() == sqliteType6 & sqliteType5.HasValue)
            this.BindDouble(SqliteValueBinder.ToJulianDate(dateTimeOffset.DateTime));
          else
            this.BindText(dateTimeOffset.ToString("yyyy\\-MM\\-dd HH\\:mm\\:ss.FFFFFFFzzz", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else if (typeName == typeof (DateOnly))
        {
          DateOnly dateOnly = (DateOnly) this._value;
          SqliteType? sqliteType7 = this._sqliteType;
          SqliteType sqliteType8 = SqliteType.Real;
          if (sqliteType7.GetValueOrDefault() == sqliteType8 & sqliteType7.HasValue)
            this.BindDouble(SqliteValueBinder.ToJulianDate(dateOnly.Year, dateOnly.Month, dateOnly.Day, 0, 0, 0, 0));
          else
            this.BindText(dateOnly.ToString("yyyy\\-MM\\-dd", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else if (typeName == typeof (TimeOnly))
        {
          TimeOnly timeOnly = (TimeOnly) this._value;
          SqliteType? sqliteType9 = this._sqliteType;
          SqliteType sqliteType10 = SqliteType.Real;
          if (sqliteType9.GetValueOrDefault() == sqliteType10 & sqliteType9.HasValue)
            this.BindDouble(SqliteValueBinder.GetTotalDays(timeOnly.Hour, timeOnly.Minute, timeOnly.Second, timeOnly.Millisecond));
          else
            this.BindText(timeOnly.Ticks % 10000000L == 0L ? timeOnly.ToString("HH:mm:ss", (IFormatProvider) CultureInfo.InvariantCulture) : timeOnly.ToString("HH:mm:ss.fffffff", (IFormatProvider) CultureInfo.InvariantCulture));
        }
        else if (typeName == typeof (DBNull))
          this.BindNull();
        else if (typeName == typeof (Decimal))
          this.BindText(((Decimal) this._value).ToString("0.0###########################", (IFormatProvider) CultureInfo.InvariantCulture));
        else if (typeName == typeof (double))
          this.BindDouble((double) this._value);
        else if (typeName == typeof (float))
          this.BindDouble((double) (float) this._value);
        else if (typeName == typeof (Guid))
        {
          Guid guid = (Guid) this._value;
          SqliteType? sqliteType11 = this._sqliteType;
          SqliteType sqliteType12 = SqliteType.Blob;
          if (!(sqliteType11.GetValueOrDefault() == sqliteType12 & sqliteType11.HasValue))
            this.BindText(guid.ToString().ToUpperInvariant());
          else
            this.BindBlob(guid.ToByteArray());
        }
        else if (typeName == typeof (int))
          this.BindInt64((long) (int) this._value);
        else if (typeName == typeof (long))
          this.BindInt64((long) this._value);
        else if (typeName == typeof (sbyte))
          this.BindInt64((long) (sbyte) this._value);
        else if (typeName == typeof (short))
          this.BindInt64((long) (short) this._value);
        else if (typeName == typeof (string))
          this.BindText((string) this._value);
        else if (typeName == typeof (TimeSpan))
        {
          TimeSpan timeSpan = (TimeSpan) this._value;
          SqliteType? sqliteType13 = this._sqliteType;
          SqliteType sqliteType14 = SqliteType.Real;
          if (sqliteType13.GetValueOrDefault() == sqliteType14 & sqliteType13.HasValue)
            this.BindDouble(timeSpan.TotalDays);
          else
            this.BindText(timeSpan.ToString("c"));
        }
        else if (typeName == typeof (uint))
          this.BindInt64((long) (uint) this._value);
        else if (typeName == typeof (ulong))
        {
          this.BindInt64((long) (ulong) this._value);
        }
        else
        {
          if (!(typeName == typeof (ushort)))
            throw new InvalidOperationException(Resources.UnknownDataType((object) typeName));
          this.BindInt64((long) (ushort) this._value);
        }
      }
    }

    internal static SqliteType GetSqliteType(object? value)
    {
      if (value == null)
        return SqliteType.Text;
      Type type = value.GetType().UnwrapNullableType().UnwrapEnumType();
      SqliteType sqliteType;
      if (SqliteValueBinder._sqliteTypeMapping.TryGetValue(type, out sqliteType))
        return sqliteType;
      throw new InvalidOperationException(Resources.UnknownDataType((object) type));
    }

    private static double ToJulianDate(DateTime dateTime)
    {
      return SqliteValueBinder.ToJulianDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
    }

    private static double ToJulianDate(
      int year,
      int month,
      int day,
      int hour,
      int minute,
      int second,
      int millisecond)
    {
      int num1 = year;
      int num2 = month;
      int num3 = day;
      if (num2 <= 2)
      {
        --num1;
        num2 += 12;
      }
      int num4 = num1 / 100;
      int num5 = 2 - num4 + num4 / 4;
      return (double) ((long) (((double) (36525 * (num1 + 4716) / 100 + 306001 * (num2 + 1) / 10000 + num3 + num5) - 1524.5) * 86400000.0) + ((long) (hour * 3600000 + minute * 60000) + (long) (((double) second + (double) millisecond / 1000.0) * 1000.0))) / 86400000.0;
    }

    private static double GetTotalDays(int hour, int minute, int second, int millisecond)
    {
      return (double) ((long) (hour * 3600000 + minute * 60000) + (long) (((double) second + (double) millisecond / 1000.0) * 1000.0)) / 86400000.0;
    }
  }
}
