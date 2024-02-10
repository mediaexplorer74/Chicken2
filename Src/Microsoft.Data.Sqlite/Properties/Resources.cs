// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.Properties.Resources
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using System.Resources;

#nullable enable
namespace Microsoft.Data.Sqlite.Properties
{
  internal static class Resources
  {
    private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Data.Sqlite.Properties.Resources", typeof (Microsoft.Data.Sqlite.Properties.Resources).Assembly);

    public static string CallRequiresOpenConnection(object methodName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (CallRequiresOpenConnection), nameof (methodName)), methodName);
    }

    public static string ConnectionStringRequiresClosedConnection
    {
      get => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (ConnectionStringRequiresClosedConnection));
    }

    public static string DataReaderClosed(object operation)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (DataReaderClosed), nameof (operation)), operation);
    }

    public static string InvalidCommandType(object commandType)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (InvalidCommandType), nameof (commandType)), commandType);
    }

    public static string InvalidIsolationLevel(object isolationLevel)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (InvalidIsolationLevel), nameof (isolationLevel)), isolationLevel);
    }

    public static string InvalidParameterDirection(object direction)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (InvalidParameterDirection), nameof (direction)), direction);
    }

    public static string KeywordNotSupported(object keyword)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (KeywordNotSupported), nameof (keyword)), keyword);
    }

    public static string MissingParameters(object parameters)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (MissingParameters), nameof (parameters)), parameters);
    }

    public static string NoData => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (NoData));

    public static string ParallelTransactionsNotSupported
    {
      get => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (ParallelTransactionsNotSupported));
    }

    public static string ParameterNotFound(object parameterName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (ParameterNotFound), nameof (parameterName)), parameterName);
    }

    public static string RequiresSet(object propertyName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (RequiresSet), nameof (propertyName)), propertyName);
    }

    public static string TransactionCompleted => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (TransactionCompleted));

    public static string TransactionConnectionMismatch
    {
      get => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (TransactionConnectionMismatch));
    }

    public static string TransactionRequired => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (TransactionRequired));

    public static string UnknownDataType(object typeName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (UnknownDataType), nameof (typeName)), typeName);
    }

    public static string SqliteNativeError(object errorCode, object message)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (SqliteNativeError), nameof (errorCode), nameof (message)), errorCode, message);
    }

    public static string DefaultNativeError => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (DefaultNativeError));

    public static string AmbiguousParameterName(object parameterName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (AmbiguousParameterName), nameof (parameterName)), parameterName);
    }

    public static string InvalidEnumValue(object enumType, object value)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (InvalidEnumValue), nameof (enumType), nameof (value)), enumType, value);
    }

    public static string ConvertFailed(object sourceType, object targetType)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (ConvertFailed), nameof (sourceType), nameof (targetType)), sourceType, targetType);
    }

    public static string CannotStoreNaN => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (CannotStoreNaN));

    public static string DataReaderOpen => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (DataReaderOpen));

    public static string SetRequiresNoOpenReader(object propertyName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (SetRequiresNoOpenReader), nameof (propertyName)), propertyName);
    }

    public static string CalledOnNullValue(object ordinal)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (CalledOnNullValue), nameof (ordinal)), ordinal);
    }

    public static string UDFCalledWithNull(object function, object ordinal)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (UDFCalledWithNull), nameof (function), nameof (ordinal)), function, ordinal);
    }

    public static string SqlBlobRequiresOpenConnection
    {
      get => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (SqlBlobRequiresOpenConnection));
    }

    public static string InvalidOffsetAndCount
    {
      get => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (InvalidOffsetAndCount));
    }

    public static string ResizeNotSupported => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (ResizeNotSupported));

    public static string SeekBeforeBegin => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (SeekBeforeBegin));

    public static string WriteNotSupported => Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (WriteNotSupported));

    public static string EncryptionNotSupported(object libraryName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (EncryptionNotSupported), nameof (libraryName)), libraryName);
    }

    public static string TooManyRestrictions(object collectionName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (TooManyRestrictions), nameof (collectionName)), collectionName);
    }

    public static string UnknownCollection(object collectionName)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (UnknownCollection), nameof (collectionName)), collectionName);
    }

    public static string AmbiguousColumnName(object name, object column1, object column2)
    {
      return string.Format(Microsoft.Data.Sqlite.Properties.Resources.GetString(nameof (AmbiguousColumnName), nameof (name), nameof (column1), nameof (column2)), name, column1, column2);
    }

    private static string GetString(string name, params string[] formatterNames)
    {
      string str = Microsoft.Data.Sqlite.Properties.Resources._resourceManager.GetString(name);
      for (int index = 0; index < formatterNames.Length; ++index)
        str = str.Replace("{" + formatterNames[index] + "}", "{" + index.ToString() + "}");
      return str;
    }
  }
}
