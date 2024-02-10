// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnection
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using Microsoft.Data.Sqlite.Utilities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteConnection : DbConnection
  {
    internal const string MainDatabaseName = "main";
    private readonly List<WeakReference<SqliteCommand>> _commands = new List<WeakReference<SqliteCommand>>();
    private Dictionary<string, (object? state, strdelegate_collation? collation)>? _collations;
    private Dictionary<(string name, int arity), (int flags, object? state, delegate_function_scalar? func)>? _functions;
    private Dictionary<(string name, int arity), (int flags, object? state, delegate_function_aggregate_step? func_step, delegate_function_aggregate_final? func_final)>? _aggregates;
    private HashSet<(string file, string? proc)>? _extensions;
    private string _connectionString;
    private ConnectionState _state;
    private SqliteConnectionInternal? _innerConnection;
    private bool _extensionsEnabled;
    private int? _defaultTimeout;

    public virtual void CreateAggregate<TAccumulate>(
      string name,
      Func<TAccumulate?, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 0, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 1, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 2, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 3, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 4, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 5, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 6, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 7, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 8, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 9, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 10, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 11, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 12, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 13, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 14, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate>(
      string name,
      Func<TAccumulate?, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 15, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<TAccumulate>(
      string name,
      Func<TAccumulate?, object?[], TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, -1, default (TAccumulate), SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, SqliteConnection.GetValues(r)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 0, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 1, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 2, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 3, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 4, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 5, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 6, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 7, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 8, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 9, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 10, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 11, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 12, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 13, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 14, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, 15, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<TAccumulate>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, object?[], TAccumulate>? func,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TAccumulate>(name, -1, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, SqliteConnection.GetValues(r)))), (Func<TAccumulate, TAccumulate>) (a => a), isDeterministic);
    }

    public virtual void CreateAggregate<TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 0, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 1, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 2, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 3, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 4, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 5, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 6, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 7, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 8, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 9, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 10, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 11, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 12, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 13, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 14, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, 15, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14)))), resultSelector, isDeterministic);
    }

    public virtual void CreateAggregate<TAccumulate, TResult>(
      string name,
      TAccumulate seed,
      Func<TAccumulate, object?[], TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic = false)
    {
      this.CreateAggregateCore<TAccumulate, TResult>(name, -1, seed, SqliteConnection.IfNotNull<TAccumulate, TAccumulate>((object) func, (Func<TAccumulate, SqliteValueReader, TAccumulate>) ((a, r) => func(a, SqliteConnection.GetValues(r)))), resultSelector, isDeterministic);
    }

    public virtual void CreateFunction<TResult>(
      string name,
      Func<TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 0, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function())), isDeterministic);
    }

    public virtual void CreateFunction<T1, TResult>(
      string name,
      Func<T1, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 1, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, TResult>(
      string name,
      Func<T1, T2, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 2, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, TResult>(
      string name,
      Func<T1, T2, T3, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 3, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, TResult>(
      string name,
      Func<T1, T2, T3, T4, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 4, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 5, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 6, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 7, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 8, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 9, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 10, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 11, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 12, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 13, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 14, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 15, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14)))), isDeterministic);
    }

    public virtual void CreateFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
      string name,
      Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, 16, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14), r.GetFieldValue<T16>(15)))), isDeterministic);
    }

    public virtual void CreateFunction<TResult>(
      string name,
      Func<object?[], TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<object, TResult>(name, -1, (object) null, SqliteConnection.IfNotNull<object, TResult>((object) function, (Func<object, SqliteValueReader, TResult>) ((s, r) => function(SqliteConnection.GetValues(r)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, TResult>(
      string name,
      TState state,
      Func<TState, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 0, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, TResult>(
      string name,
      TState state,
      Func<TState, T1, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 1, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 2, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 3, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 4, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 5, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 6, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 7, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 8, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 9, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 10, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 11, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 12, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 13, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 14, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
      string name,
      TState state,
      Func<TState, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, 15, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, r.GetFieldValue<T1>(0), r.GetFieldValue<T2>(1), r.GetFieldValue<T3>(2), r.GetFieldValue<T4>(3), r.GetFieldValue<T5>(4), r.GetFieldValue<T6>(5), r.GetFieldValue<T7>(6), r.GetFieldValue<T8>(7), r.GetFieldValue<T9>(8), r.GetFieldValue<T10>(9), r.GetFieldValue<T11>(10), r.GetFieldValue<T12>(11), r.GetFieldValue<T13>(12), r.GetFieldValue<T14>(13), r.GetFieldValue<T15>(14)))), isDeterministic);
    }

    public virtual void CreateFunction<TState, TResult>(
      string name,
      TState state,
      Func<TState, object?[], TResult>? function,
      bool isDeterministic = false)
    {
      this.CreateFunctionCore<TState, TResult>(name, -1, state, SqliteConnection.IfNotNull<TState, TResult>((object) function, (Func<TState, SqliteValueReader, TResult>) ((s, r) => function(s, SqliteConnection.GetValues(r)))), isDeterministic);
    }

    static SqliteConnection() => BundleInitializer.Initialize();

    public SqliteConnection()
      : this((string) null)
    {
    }

    public SqliteConnection(string? connectionString) => this.ConnectionString = connectionString;

    public virtual sqlite3? Handle => this._innerConnection?.Handle;

    public override string ConnectionString
    {
      get => this._connectionString;
      [MemberNotNull(new string[] {"_connectionString", "PoolGroup"})] [param: AllowNull] set
      {
        if (this.State != ConnectionState.Closed)
          throw new InvalidOperationException(Resources.ConnectionStringRequiresClosedConnection);
        this._connectionString = value ?? string.Empty;
        this.PoolGroup = SqliteConnectionFactory.Instance.GetPoolGroup(this._connectionString);
      }
    }

    internal SqliteConnectionPoolGroup PoolGroup { get; set; }

    internal SqliteConnectionStringBuilder ConnectionOptions => this.PoolGroup.ConnectionOptions;

    public override string Database => "main";

    public override string DataSource
    {
      get
      {
        string str = (string) null;
        if (this.State == ConnectionState.Open)
          str = raw.sqlite3_db_filename(this.Handle, "main").utf8_to_string();
        return str ?? this.ConnectionOptions.DataSource;
      }
    }

    public virtual int DefaultTimeout
    {
      get => this._defaultTimeout ?? this.ConnectionOptions.DefaultTimeout;
      set => this._defaultTimeout = new int?(value);
    }

    public override string ServerVersion => raw.sqlite3_libversion().utf8_to_string();

    public override ConnectionState State => this._state;

    protected override DbProviderFactory DbProviderFactory
    {
      get => (DbProviderFactory) SqliteFactory.Instance;
    }

    protected internal virtual SqliteTransaction? Transaction { get; set; }

    public static void ClearAllPools() => SqliteConnectionFactory.Instance.ClearPools();

    public static void ClearPool(SqliteConnection connection) => connection.PoolGroup.Clear();

    public override void Open()
    {
      if (this.State == ConnectionState.Open)
        return;
      this._innerConnection = SqliteConnectionFactory.Instance.GetConnection(this);
      this._state = ConnectionState.Open;
      try
      {
        bool? nullable;
        if (this.ConnectionOptions.Password.Length != 0)
        {
          string libraryName;
          nullable = SQLitePCLExtensions.EncryptionSupported(out libraryName);
          bool flag1 = false;
          if (nullable.GetValueOrDefault() == flag1 & nullable.HasValue)
            throw new InvalidOperationException(Resources.EncryptionNotSupported((object) libraryName));
          this.ExecuteNonQuery("PRAGMA key = " + this.ExecuteScalar<string>("SELECT quote($password);", new SqliteParameter("$password", (object) this.ConnectionOptions.Password)) + ";");
          nullable = SQLitePCLExtensions.EncryptionSupported();
          bool flag2 = false;
          if (!(nullable.GetValueOrDefault() == flag2 & nullable.HasValue))
            this.ExecuteNonQuery("SELECT COUNT(*) FROM sqlite_master;");
        }
        nullable = this.ConnectionOptions.ForeignKeys;
        if (nullable.HasValue)
        {
          nullable = this.ConnectionOptions.ForeignKeys;
          this.ExecuteNonQuery("PRAGMA foreign_keys = " + (nullable.Value ? "1" : "0") + ";");
        }
        if (this.ConnectionOptions.RecursiveTriggers)
          this.ExecuteNonQuery("PRAGMA recursive_triggers = 1;");
        if (this._collations != null)
        {
          foreach (KeyValuePair<string, (object state, strdelegate_collation collation)> collation in this._collations)
            SqliteException.ThrowExceptionForRC(raw.sqlite3_create_collation(this.Handle, collation.Key, collation.Value.state, collation.Value.collation), this.Handle);
        }
        if (this._functions != null)
        {
          foreach (KeyValuePair<(string name, int arity), (int flags, object state, delegate_function_scalar func)> function in this._functions)
            SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, function.Key.name, function.Key.arity, function.Value.state, function.Value.func), this.Handle);
        }
        if (this._aggregates != null)
        {
          foreach (KeyValuePair<(string name, int arity), (int flags, object state, delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final)> aggregate in this._aggregates)
            SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, aggregate.Key.name, aggregate.Key.arity, aggregate.Value.state, aggregate.Value.func_step, aggregate.Value.func_final), this.Handle);
        }
        bool flag = false;
        if (this._extensions != null && this._extensions.Count != 0)
        {
          SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, 1), this.Handle);
          flag = true;
          foreach ((string file, string proc) extension in this._extensions)
            this.LoadExtensionCore(extension.file, extension.proc);
        }
        if (this._extensionsEnabled != flag)
          SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, this._extensionsEnabled ? 1 : 0), this.Handle);
      }
      catch
      {
        this._innerConnection.Close();
        this._innerConnection = (SqliteConnectionInternal) null;
        this._state = ConnectionState.Closed;
        throw;
      }
      this.OnStateChange(new StateChangeEventArgs(ConnectionState.Closed, ConnectionState.Open));
    }

    public override void Close()
    {
      if (this.State != ConnectionState.Open)
        return;
      this.Transaction?.Dispose();
      for (int index = this._commands.Count - 1; index >= 0; --index)
      {
        SqliteCommand target;
        if (this._commands[index].TryGetTarget(out target))
          target.Dispose();
        else
          this._commands.RemoveAt(index);
      }
      this._innerConnection.Close();
      this._innerConnection = (SqliteConnectionInternal) null;
      this._state = ConnectionState.Closed;
      this.OnStateChange(new StateChangeEventArgs(ConnectionState.Open, ConnectionState.Closed));
    }

    internal void Deactivate()
    {
      if (this._collations != null)
      {
        foreach (string key in this._collations.Keys)
          SqliteException.ThrowExceptionForRC(raw.sqlite3_create_collation(this.Handle, key, (object) null, (strdelegate_collation) null), this.Handle);
      }
      if (this._functions != null)
      {
        foreach ((string name, int arity) key in this._functions.Keys)
          SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, key.name, key.arity, (object) null, (delegate_function_scalar) null), this.Handle);
      }
      if (this._aggregates != null)
      {
        foreach ((string name, int arity) key in this._aggregates.Keys)
          SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, key.name, key.arity, (object) null, (delegate_function_aggregate_step) null, (delegate_function_aggregate_final) null), this.Handle);
      }
      if (!this._extensionsEnabled)
        return;
      SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, 0), this.Handle);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.Close();
      base.Dispose(disposing);
    }

    public virtual SqliteCommand CreateCommand()
    {
      SqliteCommand command = new SqliteCommand();
      command.Connection = this;
      command.CommandTimeout = this.DefaultTimeout;
      command.Transaction = this.Transaction;
      return command;
    }

    protected override DbCommand CreateDbCommand() => (DbCommand) this.CreateCommand();

    internal void AddCommand(SqliteCommand command)
    {
      this._commands.Add(new WeakReference<SqliteCommand>(command));
    }

    internal void RemoveCommand(SqliteCommand command)
    {
      for (int index = this._commands.Count - 1; index >= 0; --index)
      {
        SqliteCommand target;
        if (this._commands[index].TryGetTarget(out target) && target == command)
          this._commands.RemoveAt(index);
      }
    }

    public virtual void CreateCollation(string name, Comparison<string>? comparison)
    {
      this.CreateCollation<object>(name, (object) null, comparison != null ? (Func<object, string, string, int>) ((_, s1, s2) => comparison(s1, s2)) : (Func<object, string, string, int>) null);
    }

    public virtual void CreateCollation<T>(
      string name,
      T state,
      Func<T, string, string, int>? comparison)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentNullException(nameof (name));
      strdelegate_collation f = comparison != null ? (strdelegate_collation) ((v, s1, s2) => comparison((T) v, s1, s2)) : (strdelegate_collation) null;
      if (this.State == ConnectionState.Open)
        SqliteException.ThrowExceptionForRC(raw.sqlite3_create_collation(this.Handle, name, (object) state, f), this.Handle);
      if (this._collations == null)
        this._collations = new Dictionary<string, (object, strdelegate_collation)>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
      this._collations[name] = ((object) state, f);
    }

    public virtual SqliteTransaction BeginTransaction()
    {
      return this.BeginTransaction(IsolationLevel.Unspecified);
    }

    public virtual SqliteTransaction BeginTransaction(bool deferred)
    {
      return this.BeginTransaction(IsolationLevel.Unspecified, deferred);
    }

    protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
    {
      return (DbTransaction) this.BeginTransaction(isolationLevel);
    }

    public virtual SqliteTransaction BeginTransaction(IsolationLevel isolationLevel)
    {
      return this.BeginTransaction(isolationLevel, isolationLevel == IsolationLevel.ReadUncommitted);
    }

    public virtual SqliteTransaction BeginTransaction(IsolationLevel isolationLevel, bool deferred)
    {
      if (this.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (BeginTransaction)));
      if (this.Transaction != null)
        throw new InvalidOperationException(Resources.ParallelTransactionsNotSupported);
      return this.Transaction = new SqliteTransaction(this, isolationLevel, deferred);
    }

    public override void ChangeDatabase(string databaseName) => throw new NotSupportedException();

    public virtual void EnableExtensions(bool enable = true)
    {
      if (this.State == ConnectionState.Open)
        SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, enable ? 1 : 0), this.Handle);
      this._extensionsEnabled = enable;
    }

    public virtual void LoadExtension(string file, string? proc = null)
    {
      if (this.State == ConnectionState.Open)
      {
        bool flag = false;
        if (!this._extensionsEnabled)
        {
          SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, 1), this.Handle);
          flag = true;
        }
        this.LoadExtensionCore(file, proc);
        if (flag)
          SqliteException.ThrowExceptionForRC(raw.sqlite3_enable_load_extension(this.Handle, 0), this.Handle);
      }
      if (this._extensions == null)
        this._extensions = new HashSet<(string, string)>();
      this._extensions.Add((file, proc));
    }

    private void LoadExtensionCore(string file, string? proc)
    {
      if (proc == null)
        this.ExecuteNonQuery("SELECT load_extension($file);", new SqliteParameter("$file", (object) file));
      else
        this.ExecuteNonQuery("SELECT load_extension($file, $proc);", new SqliteParameter("$file", (object) file), new SqliteParameter("$proc", (object) proc));
    }

    public virtual void BackupDatabase(SqliteConnection destination)
    {
      this.BackupDatabase(destination, "main", "main");
    }

    public virtual void BackupDatabase(
      SqliteConnection destination,
      string destinationName,
      string sourceName)
    {
      if (this.State != ConnectionState.Open)
        throw new InvalidOperationException(Resources.CallRequiresOpenConnection((object) nameof (BackupDatabase)));
      if (destination == null)
        throw new ArgumentNullException(nameof (destination));
      bool flag = false;
      if (destination.State != ConnectionState.Open)
      {
        destination.Open();
        flag = true;
      }
      try
      {
        using (sqlite3_backup backup = raw.sqlite3_backup_init(destination.Handle, destinationName, this.Handle, sourceName))
        {
          if (backup.IsInvalid)
            SqliteException.ThrowExceptionForRC(raw.sqlite3_errcode(destination.Handle), destination.Handle);
          SqliteException.ThrowExceptionForRC(raw.sqlite3_backup_step(backup, -1), destination.Handle);
        }
      }
      finally
      {
        if (flag)
          destination.Close();
      }
    }

    public override DataTable GetSchema()
    {
      return this.GetSchema(DbMetaDataCollectionNames.MetaDataCollections);
    }

    public override DataTable GetSchema(string collectionName)
    {
      return this.GetSchema(collectionName, Array.Empty<string>());
    }

    public override DataTable GetSchema(string collectionName, string?[] restrictionValues)
    {
      if (restrictionValues != null && restrictionValues.Length != 0)
        throw new ArgumentException(Resources.TooManyRestrictions((object) collectionName));
      if (string.Equals(collectionName, DbMetaDataCollectionNames.MetaDataCollections, StringComparison.OrdinalIgnoreCase))
        return new DataTable(DbMetaDataCollectionNames.MetaDataCollections)
        {
          Columns = {
            DbMetaDataColumnNames.CollectionName,
            {
              DbMetaDataColumnNames.NumberOfRestrictions,
              typeof (int)
            },
            {
              DbMetaDataColumnNames.NumberOfIdentifierParts,
              typeof (int)
            }
          },
          Rows = {
            new object[3]
            {
              (object) DbMetaDataCollectionNames.MetaDataCollections,
              (object) 0,
              (object) 0
            },
            new object[3]
            {
              (object) DbMetaDataCollectionNames.ReservedWords,
              (object) 0,
              (object) 0
            }
          }
        };
      DataTable schema = string.Equals(collectionName, DbMetaDataCollectionNames.ReservedWords, StringComparison.OrdinalIgnoreCase) ? new DataTable(DbMetaDataCollectionNames.ReservedWords)
      {
        Columns = {
          DbMetaDataColumnNames.ReservedWord
        }
      } : throw new ArgumentException(Resources.UnknownCollection((object) collectionName));
      int num = raw.sqlite3_keyword_count();
      for (int i = 0; i < num; ++i)
      {
        string name;
        SqliteException.ThrowExceptionForRC(raw.sqlite3_keyword_name(i, out name), (sqlite3) null);
        schema.Rows.Add((object) name);
      }
      return schema;
    }

    private void CreateFunctionCore<TState, TResult>(
      string name,
      int arity,
      TState state,
      Func<TState, SqliteValueReader, TResult>? function,
      bool isDeterministic)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      delegate_function_scalar func = (delegate_function_scalar) null;
      if (function != null)
        func = (delegate_function_scalar) ((ctx, user_data, args) =>
        {
          SqliteParameterReader sqliteParameterReader = new SqliteParameterReader(name, args);
          try
          {
            TResult result = function((TState) user_data, (SqliteValueReader) sqliteParameterReader);
            new SqliteResultBinder(ctx, (object) result).Bind();
          }
          catch (Exception ex)
          {
            raw.sqlite3_result_error(ctx, ex.Message);
            if (!(ex is SqliteException sqliteException2))
              return;
            raw.sqlite3_result_error_code(ctx, sqliteException2.SqliteErrorCode);
          }
        });
      int flags = isDeterministic ? 2048 : 0;
      if (this.State == ConnectionState.Open)
        SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, name, arity, flags, (object) state, func), this.Handle);
      if (this._functions == null)
        this._functions = new Dictionary<(string, int), (int, object, delegate_function_scalar)>((IEqualityComparer<(string, int)>) SqliteConnection.FunctionsKeyComparer.Instance);
      this._functions[(name, arity)] = (flags, (object) state, func);
    }

    private void CreateAggregateCore<TAccumulate, TResult>(
      string name,
      int arity,
      TAccumulate seed,
      Func<TAccumulate, SqliteValueReader, TAccumulate>? func,
      Func<TAccumulate, TResult>? resultSelector,
      bool isDeterministic)
    {
      if (name == null)
        throw new ArgumentNullException(nameof (name));
      delegate_function_aggregate_step func_step = (delegate_function_aggregate_step) null;
      if (func != null)
        func_step = (delegate_function_aggregate_step) ((ctx, user_data, args) =>
        {
          SqliteConnection.AggregateContext<TAccumulate> aggregateContext = (SqliteConnection.AggregateContext<TAccumulate>) user_data;
          if (aggregateContext.Exception != null)
            return;
          SqliteParameterReader sqliteParameterReader = new SqliteParameterReader(name, args);
          try
          {
            aggregateContext.Accumulate = func(aggregateContext.Accumulate, (SqliteValueReader) sqliteParameterReader);
          }
          catch (Exception ex)
          {
            aggregateContext.Exception = ex;
          }
        });
      delegate_function_aggregate_final func_final = (delegate_function_aggregate_final) null;
      if (resultSelector != null)
        func_final = (delegate_function_aggregate_final) ((ctx, user_data) =>
        {
          SqliteConnection.AggregateContext<TAccumulate> aggregateContext = (SqliteConnection.AggregateContext<TAccumulate>) user_data;
          if (aggregateContext.Exception == null)
          {
            try
            {
              TResult result = resultSelector(aggregateContext.Accumulate);
              new SqliteResultBinder(ctx, (object) result).Bind();
            }
            catch (Exception ex)
            {
              aggregateContext.Exception = ex;
            }
          }
          if (aggregateContext.Exception == null)
            return;
          raw.sqlite3_result_error(ctx, aggregateContext.Exception.Message);
          if (!(aggregateContext.Exception is SqliteException exception2))
            return;
          raw.sqlite3_result_error_code(ctx, exception2.SqliteErrorCode);
        });
      int flags = isDeterministic ? 2048 : 0;
      SqliteConnection.AggregateContext<TAccumulate> v = new SqliteConnection.AggregateContext<TAccumulate>(seed);
      if (this.State == ConnectionState.Open)
        SqliteException.ThrowExceptionForRC(raw.sqlite3_create_function(this.Handle, name, arity, flags, (object) v, func_step, func_final), this.Handle);
      if (this._aggregates == null)
        this._aggregates = new Dictionary<(string, int), (int, object, delegate_function_aggregate_step, delegate_function_aggregate_final)>((IEqualityComparer<(string, int)>) SqliteConnection.FunctionsKeyComparer.Instance);
      this._aggregates[(name, arity)] = (flags, (object) v, func_step, func_final);
    }

    private static Func<TState, SqliteValueReader, TResult>? IfNotNull<TState, TResult>(
      object? x,
      Func<TState, SqliteValueReader, TResult> value)
    {
      return x == null ? (Func<TState, SqliteValueReader, TResult>) null : value;
    }

    private static object?[] GetValues(SqliteValueReader reader)
    {
      object[] values = new object[reader.FieldCount];
      reader.GetValues(values);
      return values;
    }

    private sealed class AggregateContext<T>
    {
      public AggregateContext(T seed) => this.Accumulate = seed;

      public T Accumulate { get; set; }

      public Exception? Exception { get; set; }
    }

    private sealed class FunctionsKeyComparer : IEqualityComparer<(string name, int arity)>
    {
      public static readonly SqliteConnection.FunctionsKeyComparer Instance = new SqliteConnection.FunctionsKeyComparer();

      public bool Equals((string name, int arity) x, (string name, int arity) y)
      {
        return StringComparer.OrdinalIgnoreCase.Equals(x.name, y.name) && x.arity == y.arity;
      }

      public int GetHashCode((string name, int arity) obj)
      {
        int hashCode1 = StringComparer.OrdinalIgnoreCase.GetHashCode(obj.name);
        int hashCode2 = obj.arity.GetHashCode();
        return (hashCode1 << 5 | hashCode1 >>> 27) + hashCode1 ^ hashCode2;
      }
    }
  }
}
