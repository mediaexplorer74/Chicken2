// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteParameterCollection
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteParameterCollection : DbParameterCollection
  {
    private readonly List<SqliteParameter> _parameters = new List<SqliteParameter>();

    protected internal SqliteParameterCollection()
    {
    }

    public override int Count => this._parameters.Count;

    public override object SyncRoot => ((ICollection) this._parameters).SyncRoot;

    public virtual SqliteParameter this[int index]
    {
      get => this._parameters[index];
      set
      {
        if (this._parameters[index] == value)
          return;
        this._parameters[index] = value;
      }
    }

    public virtual SqliteParameter this[string parameterName]
    {
      get => this[this.IndexOfChecked(parameterName)];
      set => this[this.IndexOfChecked(parameterName)] = value;
    }

    public override int Add(object value)
    {
      this._parameters.Add((SqliteParameter) value);
      return this.Count - 1;
    }

    public virtual SqliteParameter Add(SqliteParameter value)
    {
      this._parameters.Add(value);
      return value;
    }

    public virtual SqliteParameter Add(string? parameterName, SqliteType type)
    {
      return this.Add(new SqliteParameter(parameterName, type));
    }

    public virtual SqliteParameter Add(string? parameterName, SqliteType type, int size)
    {
      return this.Add(new SqliteParameter(parameterName, type, size));
    }

    public virtual SqliteParameter Add(
      string? parameterName,
      SqliteType type,
      int size,
      string? sourceColumn)
    {
      return this.Add(new SqliteParameter(parameterName, type, size, sourceColumn));
    }

    public override void AddRange(Array values) => this.AddRange(values.Cast<SqliteParameter>());

    public virtual void AddRange(IEnumerable<SqliteParameter> values)
    {
      this._parameters.AddRange(values);
    }

    public virtual SqliteParameter AddWithValue(string? parameterName, object? value)
    {
      return this.Add(new SqliteParameter(parameterName, value));
    }

    public override void Clear() => this._parameters.Clear();

    public override bool Contains(object value) => this.Contains((SqliteParameter) value);

    public virtual bool Contains(SqliteParameter value) => this._parameters.Contains(value);

    public override bool Contains(string value) => this.IndexOf(value) != -1;

    public override void CopyTo(Array array, int index)
    {
      this.CopyTo((SqliteParameter[]) array, index);
    }

    public virtual void CopyTo(SqliteParameter[] array, int index)
    {
      this._parameters.CopyTo(array, index);
    }

    public override IEnumerator GetEnumerator() => (IEnumerator) this._parameters.GetEnumerator();

    protected override DbParameter GetParameter(int index) => (DbParameter) this[index];

    protected override DbParameter GetParameter(string parameterName)
    {
      return this.GetParameter(this.IndexOfChecked(parameterName));
    }

    public override int IndexOf(object value) => this.IndexOf((SqliteParameter) value);

    public virtual int IndexOf(SqliteParameter value) => this._parameters.IndexOf(value);

    public override int IndexOf(string parameterName)
    {
      for (int index = 0; index < this._parameters.Count; ++index)
      {
        if (this._parameters[index].ParameterName == parameterName)
          return index;
      }
      return -1;
    }

    public override void Insert(int index, object value)
    {
      this.Insert(index, (SqliteParameter) value);
    }

    public virtual void Insert(int index, SqliteParameter value)
    {
      this._parameters.Insert(index, value);
    }

    public override void Remove(object value) => this.Remove((SqliteParameter) value);

    public virtual void Remove(SqliteParameter value) => this._parameters.Remove(value);

    public override void RemoveAt(int index) => this._parameters.RemoveAt(index);

    public override void RemoveAt(string parameterName)
    {
      this.RemoveAt(this.IndexOfChecked(parameterName));
    }

    protected override void SetParameter(int index, DbParameter value)
    {
      this[index] = (SqliteParameter) value;
    }

    protected override void SetParameter(string parameterName, DbParameter value)
    {
      this.SetParameter(this.IndexOfChecked(parameterName), value);
    }

    internal int Bind(sqlite3_stmt stmt)
    {
      int num = 0;
      foreach (SqliteParameter parameter in this._parameters)
      {
        if (parameter.Bind(stmt))
          ++num;
      }
      return num;
    }

    private int IndexOfChecked(string parameterName)
    {
      int num = this.IndexOf(parameterName);
      return num != -1 ? num : throw new IndexOutOfRangeException(Resources.ParameterNotFound((object) parameterName));
    }
  }
}
