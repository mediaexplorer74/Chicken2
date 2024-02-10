// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteConnectionExtensions
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System.Collections.Generic;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  internal static class SqliteConnectionExtensions
  {
    public static int ExecuteNonQuery(
      this SqliteConnection connection,
      string commandText,
      params SqliteParameter[] parameters)
    {
      using (SqliteCommand command = connection.CreateCommand())
      {
        command.CommandText = commandText;
        command.Parameters.AddRange((IEnumerable<SqliteParameter>) parameters);
        return command.ExecuteNonQuery();
      }
    }

    public static T ExecuteScalar<T>(
      this SqliteConnection connection,
      string commandText,
      params SqliteParameter[] parameters)
    {
      return (T) connection.ExecuteScalar(commandText, parameters);
    }

    private static object? ExecuteScalar(
      this SqliteConnection connection,
      string commandText,
      params SqliteParameter[] parameters)
    {
      using (SqliteCommand command = connection.CreateCommand())
      {
        command.CommandText = commandText;
        command.Parameters.AddRange((IEnumerable<SqliteParameter>) parameters);
        return command.ExecuteScalar();
      }
    }
  }
}
