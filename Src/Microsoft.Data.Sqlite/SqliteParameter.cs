// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteParameter
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteParameter : DbParameter
  {
    private string _parameterName = string.Empty;
    private object? _value;
    private int? _size;
    private SqliteType? _sqliteType;
    private string _sourceColumn = string.Empty;
    private static readonly char[] _parameterPrefixes = new char[3]
    {
      '@',
      '$',
      ':'
    };

    public SqliteParameter()
    {
    }

    public SqliteParameter(string? name, object? value)
    {
      this.ParameterName = name;
      this.Value = value;
    }

    public SqliteParameter(string? name, SqliteType type)
    {
      this.ParameterName = name;
      this.SqliteType = type;
    }

    public SqliteParameter(string? name, SqliteType type, int size)
      : this(name, type)
    {
      this.Size = size;
    }

    public SqliteParameter(string? name, SqliteType type, int size, string? sourceColumn)
      : this(name, type, size)
    {
      this.SourceColumn = sourceColumn;
    }

    public override DbType DbType { get; set; } = DbType.String;

    public virtual SqliteType SqliteType
    {
      get => this._sqliteType ?? SqliteValueBinder.GetSqliteType(this._value);
      set => this._sqliteType = new SqliteType?(value);
    }

    public override ParameterDirection Direction
    {
      get => ParameterDirection.Input;
      set
      {
        if (value != ParameterDirection.Input)
          throw new ArgumentException(Resources.InvalidParameterDirection((object) value));
      }
    }

    public override bool IsNullable { get; set; }

    public override string ParameterName
    {
      get => this._parameterName;
      [param: AllowNull] set => this._parameterName = value ?? string.Empty;
    }

    public override int Size
    {
      get
      {
        int? size = this._size;
        if (size.HasValue)
          return size.GetValueOrDefault();
        if (this._value is string str)
          return str.Length;
        return !(this._value is byte[] numArray) ? 0 : numArray.Length;
      }
      set
      {
        this._size = value >= -1 ? new int?(value) : throw new ArgumentOutOfRangeException(nameof (value), (object) value, (string) null);
      }
    }

    public override string SourceColumn
    {
      get => this._sourceColumn;
      [param: AllowNull] set => this._sourceColumn = value ?? string.Empty;
    }

    public override bool SourceColumnNullMapping { get; set; }

    public override object? Value
    {
      get => this._value;
      set => this._value = value;
    }

    public override void ResetDbType() => this.ResetSqliteType();

    public virtual void ResetSqliteType()
    {
      this.DbType = DbType.String;
      this.SqliteType = SqliteType.Text;
    }

    internal bool Bind(sqlite3_stmt stmt)
    {
      int index = !string.IsNullOrEmpty(this.ParameterName) ? raw.sqlite3_bind_parameter_index(stmt, this.ParameterName) : throw new InvalidOperationException(Resources.RequiresSet((object) "ParameterName"));
      if (index == 0 && (index = this.FindPrefixedParameter(stmt)) == 0)
        return false;
      if (this._value == null)
        throw new InvalidOperationException(Resources.RequiresSet((object) "Value"));
      new SqliteParameterBinder(stmt, index, this._value, this._size, this._sqliteType).Bind();
      return true;
    }

    private int FindPrefixedParameter(sqlite3_stmt stmt)
    {
      int prefixedParameter = 0;
      foreach (char parameterPrefix in SqliteParameter._parameterPrefixes)
      {
        if ((int) this.ParameterName[0] == (int) parameterPrefix)
          return 0;
        int num = raw.sqlite3_bind_parameter_index(stmt, parameterPrefix.ToString() + this.ParameterName);
        if (num != 0)
          prefixedParameter = prefixedParameter == 0 ? num : throw new InvalidOperationException(Resources.AmbiguousParameterName((object) this.ParameterName));
      }
      return prefixedParameter;
    }
  }
}
