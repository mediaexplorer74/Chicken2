// JuicyChicken.SQL

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

#nullable disable
namespace JuicyChicken
{
  public static class SQL
  {
    private static SqliteConnection connection;
    private static int id;
    private const string ConnectionName = "Content/database.db";

    public static void VerifyUser(string username)
    {
            /*
      SQL.connection.Open();
      if (Convert.ToInt32(new SqliteCommand("SELECT count(*) FROM users WHERE name = '" 
          + username + "'", SQL.connection).ExecuteScalar()) <= 0)
        new SqliteCommand("INSERT INTO users VALUES(null, '" + username + "')", 
            SQL.connection).ExecuteNonQuery();

      SQL.id = Convert.ToInt32(new SqliteCommand(
          "SELECT id FROM users WHERE name = '" + username + "'", SQL.connection).ExecuteScalar());
      SQL.connection.Close();
            */
    }

    public static void Initialize()
    {
            /*
      SQL.connection = new SqliteConnection("data source = Content/database.db;");
      SQL.connection.Open();
      new SqliteCommand("PRAGMA foreign_keys = ON;", SQL.connection).ExecuteNonQuery();
      if (!SQL.TableExists("users"))
        new SqliteCommand("CREATE TABLE users (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name TEXT UNIQUE NOT NULL)", SQL.connection).ExecuteNonQuery();
      SQL.connection.Close();
            */
    }

    public static void ClearTable(string table)
    {
            /*
      SQL.CorrectTableName(ref table);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table))
        return;
      new SqliteCommand("DROP TABLE " + table, SQL.connection).ExecuteNonQuery();
      SQL.TryCloseConnection();
            */
    }

    private static void CreateTable(string table, string user)
    {
            /*
      new SqliteCommand("CREATE TABLE " + table +
          " (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT REFERENCES users(id) ON DELETE CASCADE, name TEXT UNIQUE NOT NULL REFERENCES users(name) ON DELETE CASCADE)", SQL.connection).ExecuteNonQuery();
      
      //RnD
      DefaultInterpolatedStringHandler interpolatedStringHandler =
      new DefaultInterpolatedStringHandler(25, 3);
      interpolatedStringHandler.AppendLiteral("INSERT INTO ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" VALUES(");
      interpolatedStringHandler.AppendFormatted<int>(SQL.id);
      interpolatedStringHandler.AppendLiteral(", '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("')");
      new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteNonQuery();
            */
     
    }

    private static void AddColumn(string table, string column)
    {
            /*
      new SqliteCommand("ALTER TABLE " + table + " ADD " + column, SQL.connection).ExecuteNonQuery();
            */
    }

    private static void AddRow(string table, string user)
    {
            /*
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 3);
      interpolatedStringHandler.AppendLiteral("INSERT INTO ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" (id, name) VALUES (");
      interpolatedStringHandler.AppendFormatted<int>(SQL.id);
      interpolatedStringHandler.AppendLiteral(", '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("')");
      new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteNonQuery();
            */
    }

    public static void SetValue<T>(string table, string column, string user, T value) where T : IConvertible
    {
            /*
      SQL.CorrectTableName(ref table);
      SQL.CorrectColumnName(ref column);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table))
        SQL.CreateTable(table, user);
      if (!SQL.ColumnExists(table, column))
        SQL.AddColumn(table, column);
      if (!SQL.TableContainsUser(table, user))
        SQL.AddRow(table, user);

      DefaultInterpolatedStringHandler interpolatedStringHandler 
                = new DefaultInterpolatedStringHandler(31, 4);      

      interpolatedStringHandler.AppendLiteral("UPDATE ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" SET ");
      interpolatedStringHandler.AppendFormatted(column);
      interpolatedStringHandler.AppendLiteral(" = ");
      interpolatedStringHandler.AppendFormatted(SQL.CorrectValue<T>(value));
      interpolatedStringHandler.AppendLiteral(" WHERE name = '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("'");
      new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteNonQuery();
      SQL.TryCloseConnection();
            */
    }

    // T default value  = null
    public static T GetValue<T>(string table, string column, string user, T defaultValue) where T : IConvertible
    {
            /*
      SQL.CorrectTableName(ref table);
      SQL.CorrectColumnName(ref column);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table) || !SQL.ColumnExists(table, column))
      {
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(41, 1);
        interpolatedStringHandler.AppendLiteral("No value found, returning default value: ");
        interpolatedStringHandler.AppendFormatted<T>(defaultValue);
        Debug.Log<string>(interpolatedStringHandler.ToStringAndClear());
        return defaultValue;
      }
      DefaultInterpolatedStringHandler interpolatedStringHandler1 = new DefaultInterpolatedStringHandler(29, 3);
      interpolatedStringHandler1.AppendLiteral("SELECT ");
      interpolatedStringHandler1.AppendFormatted(column);
      interpolatedStringHandler1.AppendLiteral(" FROM ");
      interpolatedStringHandler1.AppendFormatted(table);
      interpolatedStringHandler1.AppendLiteral(" WHERE name = '");
      interpolatedStringHandler1.AppendFormatted(user);
      interpolatedStringHandler1.AppendLiteral("'");
      SqliteDataReader sqliteDataReader = new SqliteCommand(interpolatedStringHandler1.ToStringAndClear(), SQL.connection).ExecuteReader();
      T obj = defaultValue;
      try
      {
        while (sqliteDataReader.Read())
          obj = sqliteDataReader.GetFieldValue<T>(0);
      }
      catch
      {
        obj = defaultValue;
      }
      sqliteDataReader.Close();
      SQL.TryCloseConnection();
      return obj;
            */
       return default;
    }
    
    public static List<T> GetAllValues<T>(string table, string column, T defaultValue) where T : IConvertible
    {
      List<T> allValues = new List<T>();
      SQL.CorrectTableName(ref table);
      SQL.CorrectColumnName(ref column);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table) || !SQL.ColumnExists(table, column))
        throw new Exception("Table and/or column does not exist");
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 2);
      interpolatedStringHandler.AppendLiteral("SELECT ");
      interpolatedStringHandler.AppendFormatted(column);
      interpolatedStringHandler.AppendLiteral(" FROM ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral("'");
      SqliteDataReader sqliteDataReader = new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteReader();
      int num = 0;
      while (sqliteDataReader.Read())
        allValues.Add(sqliteDataReader.GetFieldValue<T>(num++));
      return allValues;
    }

    public static void ClearValue(string table, string column, string user)
    {
      SQL.CorrectTableName(ref table);
      SQL.CorrectColumnName(ref column);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table) || !SQL.ColumnExists(table, column))
        return;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 3);
      interpolatedStringHandler.AppendLiteral("UPDATE ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" SET ");
      interpolatedStringHandler.AppendFormatted(column);
      interpolatedStringHandler.AppendLiteral(" = null WHERE name = '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("'");
      new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteNonQuery();
      SQL.TryCloseConnection();
    }

    public static void DeleteRow(string table, string user)
    {
      SQL.CorrectTableName(ref table);
      SQL.TryOpenConnection();
      if (!SQL.TableExists(table))
        return;
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
      interpolatedStringHandler.AppendLiteral("DELETE FROM ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" WHERE name = '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("'");
      new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), SQL.connection).ExecuteNonQuery();
      Debug.Log<string>("Deleted entry");
      SQL.TryCloseConnection();
    }

    private static string CorrectValue<T>(T value)
    {
      return !((object) value is string) && !((object) value is char) ? value.ToString().Replace(',', '.') : "'" + (object) value + "'";
    }

    private static void CorrectTableName(ref string table)
    {
      table = table.ToLower();
    if (table == nameof(table))
    {
      //throw new Exception("Invalid table name!");
      System.Diagnostics.Debug.WriteLine("[ex] SQL - CorrectTableName - Invalid table name: " + table);
    }
    }

    private static void CorrectColumnName(ref string column)
    {
      column = column.ToLower();
      if (column == nameof (column))
        throw new Exception("Invalid column name!");
    }

    public static bool TableExists(string table)
    {
      SQL.TryOpenConnection();
      return Convert.ToInt32(new SqliteCommand(
          "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = '" 
          + table + "'", SQL.connection).ExecuteScalar()) > 0;
    }

    private static bool ColumnExists(string table, string column)
    {
      SqliteDataReader sqliteDataReader = new SqliteCommand("PRAGMA table_info(" + table + ")",
          SQL.connection).ExecuteReader();

      int ordinal = sqliteDataReader.GetOrdinal("Name");
      while (sqliteDataReader.Read())
      {
        if (sqliteDataReader.GetString(ordinal).Equals(column))
          return true;
      }
      sqliteDataReader.Close();
      return false;
    }

    private static bool TableContainsUser(string table, string user)
    {
      DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(37, 2);
      interpolatedStringHandler.AppendLiteral("SELECT count(*) FROM ");
      interpolatedStringHandler.AppendFormatted(table);
      interpolatedStringHandler.AppendLiteral(" WHERE name = '");
      interpolatedStringHandler.AppendFormatted(user);
      interpolatedStringHandler.AppendLiteral("'");
      return Convert.ToInt32(new SqliteCommand(interpolatedStringHandler.ToStringAndClear(), 
          SQL.connection).ExecuteScalar()) > 0;
    }

    private static void TryOpenConnection()
    {
      if (SQL.connection.State == ConnectionState.Open)
        return;
      SQL.connection.Open();
    }

    private static void TryCloseConnection()
    {
      if (SQL.connection.State == ConnectionState.Closed)
        return;
      SQL.connection.Close();
    }

    public static void RunNonQuery(string input)
    {
      SqliteCommand sqliteCommand = new SqliteCommand(input, SQL.connection);
      SQL.TryOpenConnection();
      try
      {
        sqliteCommand.ExecuteNonQuery();
        Debug.Log<string>("Executed - " + input, Debug.SuccesColor);
      }
      catch (SqliteException ex)
      {
        //RnD
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
        interpolatedStringHandler.AppendLiteral("SQL nonqeury command failed - ");
        interpolatedStringHandler.AppendFormatted<SqliteException>(ex);
        Debug.Log<string>(interpolatedStringHandler.ToStringAndClear(), Debug.ErrorColor);
      }
      SQL.TryCloseConnection();
    }
  }
}
