// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteFactory
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System.Data.Common;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteFactory : DbProviderFactory
  {
    public static readonly SqliteFactory Instance = new SqliteFactory();

    private SqliteFactory()
    {
    }

    public override DbCommand CreateCommand() => (DbCommand) new SqliteCommand();

    public override DbConnection CreateConnection() => (DbConnection) new SqliteConnection();

    public override DbConnectionStringBuilder CreateConnectionStringBuilder()
    {
      return (DbConnectionStringBuilder) new SqliteConnectionStringBuilder();
    }

    public override DbParameter CreateParameter() => (DbParameter) new SqliteParameter();
  }
}
