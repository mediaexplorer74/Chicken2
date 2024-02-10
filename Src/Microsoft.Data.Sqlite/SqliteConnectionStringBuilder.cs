// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionStringBuilder
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteConnectionStringBuilder : DbConnectionStringBuilder
  {
    private const string DataSourceKeyword = "Data Source";
    private const string DataSourceNoSpaceKeyword = "DataSource";
    private const string ModeKeyword = "Mode";
    private const string CacheKeyword = "Cache";
    private const string FilenameKeyword = "Filename";
    private const string PasswordKeyword = "Password";
    private const string ForeignKeysKeyword = "Foreign Keys";
    private const string RecursiveTriggersKeyword = "Recursive Triggers";
    private const string DefaultTimeoutKeyword = "Default Timeout";
    private const string CommandTimeoutKeyword = "Command Timeout";
    private const string PoolingKeyword = "Pooling";
    private static readonly IReadOnlyList<string> _validKeywords = (IReadOnlyList<string>) new string[8]
    {
      "Data Source",
      nameof (Mode),
      nameof (Cache),
      nameof (Password),
      "Foreign Keys",
      "Recursive Triggers",
      "Default Timeout",
      nameof (Pooling)
    };
    private static readonly IReadOnlyDictionary<string, SqliteConnectionStringBuilder.Keywords> _keywords = (IReadOnlyDictionary<string, SqliteConnectionStringBuilder.Keywords>) new Dictionary<string, SqliteConnectionStringBuilder.Keywords>(11, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      ["Data Source"] = SqliteConnectionStringBuilder.Keywords.DataSource,
      [nameof (Mode)] = SqliteConnectionStringBuilder.Keywords.Mode,
      [nameof (Cache)] = SqliteConnectionStringBuilder.Keywords.Cache,
      [nameof (Password)] = SqliteConnectionStringBuilder.Keywords.Password,
      ["Foreign Keys"] = SqliteConnectionStringBuilder.Keywords.ForeignKeys,
      ["Recursive Triggers"] = SqliteConnectionStringBuilder.Keywords.RecursiveTriggers,
      ["Default Timeout"] = SqliteConnectionStringBuilder.Keywords.DefaultTimeout,
      [nameof (Pooling)] = SqliteConnectionStringBuilder.Keywords.Pooling,
      ["Filename"] = SqliteConnectionStringBuilder.Keywords.DataSource,
      [nameof (DataSource)] = SqliteConnectionStringBuilder.Keywords.DataSource,
      ["Command Timeout"] = SqliteConnectionStringBuilder.Keywords.DefaultTimeout
    };
    private string _dataSource = string.Empty;
    private SqliteOpenMode _mode;
    private SqliteCacheMode _cache;
    private string _password = string.Empty;
    private bool? _foreignKeys;
    private bool _recursiveTriggers;
    private int _defaultTimeout = 30;
    private bool _pooling = true;

    public SqliteConnectionStringBuilder()
    {
    }

    public SqliteConnectionStringBuilder(string? connectionString)
    {
      this.ConnectionString = connectionString;
    }

    public virtual string DataSource
    {
      get => this._dataSource;
      [param: AllowNull] set
      {
        base["Data Source"] = (object) (this._dataSource = value ?? string.Empty);
      }
    }

    public virtual SqliteOpenMode Mode
    {
      get => this._mode;
      set => base[nameof (Mode)] = (object) (this._mode = value);
    }

    public override ICollection Keys
    {
      get
      {
        return (ICollection) new ReadOnlyCollection<string>((IList<string>) (string[]) SqliteConnectionStringBuilder._validKeywords);
      }
    }

    public override ICollection Values
    {
      get
      {
        object[] list = new object[SqliteConnectionStringBuilder._validKeywords.Count];
        for (int index = 0; index < SqliteConnectionStringBuilder._validKeywords.Count; ++index)
          list[index] = this.GetAt((SqliteConnectionStringBuilder.Keywords) index);
        return (ICollection) new ReadOnlyCollection<object>((IList<object>) list);
      }
    }

    public virtual SqliteCacheMode Cache
    {
      get => this._cache;
      set => base[nameof (Cache)] = (object) (this._cache = value);
    }

    public string Password
    {
      get => this._password;
      [param: AllowNull] set
      {
        base[nameof (Password)] = (object) (this._password = value ?? string.Empty);
      }
    }

    public bool? ForeignKeys
    {
      get => this._foreignKeys;
      set => base["Foreign Keys"] = (object) (this._foreignKeys = value);
    }

    public bool RecursiveTriggers
    {
      get => this._recursiveTriggers;
      set => base["Recursive Triggers"] = (object) (this._recursiveTriggers = value);
    }

    public int DefaultTimeout
    {
      get => this._defaultTimeout;
      set => base["Default Timeout"] = (object) (this._defaultTimeout = value);
    }

    public bool Pooling
    {
      get => this._pooling;
      set => base[nameof (Pooling)] = (object) (this._pooling = value);
    }

    public override object? this[string keyword]
    {
      get => this.GetAt(SqliteConnectionStringBuilder.GetIndex(keyword));
      set
      {
        if (value == null)
        {
          this.Remove(keyword);
        }
        else
        {
          switch (SqliteConnectionStringBuilder.GetIndex(keyword))
          {
            case SqliteConnectionStringBuilder.Keywords.DataSource:
              this.DataSource = Convert.ToString(value, (IFormatProvider) CultureInfo.InvariantCulture);
              break;
            case SqliteConnectionStringBuilder.Keywords.Mode:
              this.Mode = SqliteConnectionStringBuilder.ConvertToEnum<SqliteOpenMode>(value);
              break;
            case SqliteConnectionStringBuilder.Keywords.Cache:
              this.Cache = SqliteConnectionStringBuilder.ConvertToEnum<SqliteCacheMode>(value);
              break;
            case SqliteConnectionStringBuilder.Keywords.Password:
              this.Password = Convert.ToString(value, (IFormatProvider) CultureInfo.InvariantCulture);
              break;
            case SqliteConnectionStringBuilder.Keywords.ForeignKeys:
              this.ForeignKeys = SqliteConnectionStringBuilder.ConvertToNullableBoolean(value);
              break;
            case SqliteConnectionStringBuilder.Keywords.RecursiveTriggers:
              this.RecursiveTriggers = Convert.ToBoolean(value, (IFormatProvider) CultureInfo.InvariantCulture);
              break;
            case SqliteConnectionStringBuilder.Keywords.DefaultTimeout:
              this.DefaultTimeout = Convert.ToInt32(value);
              break;
            case SqliteConnectionStringBuilder.Keywords.Pooling:
              this.Pooling = Convert.ToBoolean(value, (IFormatProvider) CultureInfo.InvariantCulture);
              break;
          }
        }
      }
    }

    private static TEnum ConvertToEnum<TEnum>(object value) where TEnum : struct
    {
      if (value is string str)
        return (TEnum) Enum.Parse(typeof (TEnum), str, true);
      if (!(value is TEnum @enum))
        @enum = !value.GetType().IsEnum ? (TEnum) Enum.ToObject(typeof (TEnum), value) : throw new ArgumentException(Resources.ConvertFailed((object) value.GetType(), (object) typeof (TEnum)));
      return Enum.IsDefined(typeof (TEnum), (object) @enum) ? @enum : throw new ArgumentOutOfRangeException(nameof (value), value, Resources.InvalidEnumValue((object) typeof (TEnum), (object) @enum));
    }

    private static bool? ConvertToNullableBoolean(object value)
    {
      return value == null || value is string str && str.Length == 0 ? new bool?() : new bool?(Convert.ToBoolean(value, (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public override void Clear()
    {
      base.Clear();
      for (int index = 0; index < SqliteConnectionStringBuilder._validKeywords.Count; ++index)
        this.Reset((SqliteConnectionStringBuilder.Keywords) index);
    }

    public override bool ContainsKey(string keyword)
    {
      return SqliteConnectionStringBuilder._keywords.ContainsKey(keyword);
    }

    public override bool Remove(string keyword)
    {
      SqliteConnectionStringBuilder.Keywords index;
      if (!SqliteConnectionStringBuilder._keywords.TryGetValue(keyword, out index) || !base.Remove(SqliteConnectionStringBuilder._validKeywords[(int) index]))
        return false;
      this.Reset(index);
      return true;
    }

    public override bool ShouldSerialize(string keyword)
    {
      SqliteConnectionStringBuilder.Keywords index;
      return SqliteConnectionStringBuilder._keywords.TryGetValue(keyword, out index) && base.ShouldSerialize(SqliteConnectionStringBuilder._validKeywords[(int) index]);
    }

    public override bool TryGetValue(string keyword, out object? value)
    {
      SqliteConnectionStringBuilder.Keywords index;
      if (!SqliteConnectionStringBuilder._keywords.TryGetValue(keyword, out index))
      {
        value = (object) null;
        return false;
      }
      value = this.GetAt(index);
      return true;
    }

    private object? GetAt(SqliteConnectionStringBuilder.Keywords index)
    {
      switch (index)
      {
        case SqliteConnectionStringBuilder.Keywords.DataSource:
          return (object) this.DataSource;
        case SqliteConnectionStringBuilder.Keywords.Mode:
          return (object) this.Mode;
        case SqliteConnectionStringBuilder.Keywords.Cache:
          return (object) this.Cache;
        case SqliteConnectionStringBuilder.Keywords.Password:
          return (object) this.Password;
        case SqliteConnectionStringBuilder.Keywords.ForeignKeys:
          return (object) this.ForeignKeys;
        case SqliteConnectionStringBuilder.Keywords.RecursiveTriggers:
          return (object) this.RecursiveTriggers;
        case SqliteConnectionStringBuilder.Keywords.DefaultTimeout:
          return (object) this.DefaultTimeout;
        case SqliteConnectionStringBuilder.Keywords.Pooling:
          return (object) this.Pooling;
        default:
          return (object) null;
      }
    }

    private static SqliteConnectionStringBuilder.Keywords GetIndex(string keyword)
    {
      SqliteConnectionStringBuilder.Keywords index;
      if (SqliteConnectionStringBuilder._keywords.TryGetValue(keyword, out index))
        return index;
      throw new ArgumentException(Resources.KeywordNotSupported((object) keyword));
    }

    private void Reset(SqliteConnectionStringBuilder.Keywords index)
    {
      switch (index)
      {
        case SqliteConnectionStringBuilder.Keywords.DataSource:
          this._dataSource = string.Empty;
          break;
        case SqliteConnectionStringBuilder.Keywords.Mode:
          this._mode = SqliteOpenMode.ReadWriteCreate;
          break;
        case SqliteConnectionStringBuilder.Keywords.Cache:
          this._cache = SqliteCacheMode.Default;
          break;
        case SqliteConnectionStringBuilder.Keywords.Password:
          this._password = string.Empty;
          break;
        case SqliteConnectionStringBuilder.Keywords.ForeignKeys:
          this._foreignKeys = new bool?();
          break;
        case SqliteConnectionStringBuilder.Keywords.RecursiveTriggers:
          this._recursiveTriggers = false;
          break;
        case SqliteConnectionStringBuilder.Keywords.DefaultTimeout:
          this._defaultTimeout = 30;
          break;
        case SqliteConnectionStringBuilder.Keywords.Pooling:
          this._pooling = true;
          break;
      }
    }

    private enum Keywords
    {
      DataSource,
      Mode,
      Cache,
      Password,
      ForeignKeys,
      RecursiveTriggers,
      DefaultTimeout,
      Pooling,
    }
  }
}
