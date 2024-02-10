// Decompiled with JetBrains decompiler
// Type: Microsoft.Data.Sqlite.SqliteBlob
// Assembly: Microsoft.Data.Sqlite, Version=6.0.4.0, Culture=neutral, PublicKeyToken=adb9793829ddae60
// MVID: 311654AE-5ED9-4CE6-BCEE-171C8FCE8697
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.Data.Sqlite.dll

using Microsoft.Data.Sqlite.Properties;
using SQLitePCL;
using System;
using System.Data;
using System.IO;

#nullable enable
namespace Microsoft.Data.Sqlite
{
  public class SqliteBlob : Stream
  {
    private sqlite3_blob? _blob;
    private readonly SqliteConnection _connection;
    private long _position;

    public SqliteBlob(
      SqliteConnection connection,
      string tableName,
      string columnName,
      long rowid,
      bool readOnly = false)
      : this(connection, "main", tableName, columnName, rowid, readOnly)
    {
    }

    public SqliteBlob(
      SqliteConnection connection,
      string databaseName,
      string tableName,
      string columnName,
      long rowid,
      bool readOnly = false)
    {
      if ((connection != null ? (connection.State != ConnectionState.Open ? 1 : 0) : 1) != 0)
        throw new InvalidOperationException(Resources.SqlBlobRequiresOpenConnection);
      if (tableName == null)
        throw new ArgumentNullException(nameof (tableName));
      if (columnName == null)
        throw new ArgumentNullException(nameof (columnName));
      this._connection = connection;
      this.CanWrite = !readOnly;
      SqliteException.ThrowExceptionForRC(raw.sqlite3_blob_open(this._connection.Handle, databaseName, tableName, columnName, rowid, readOnly ? 0 : 1, out this._blob), this._connection.Handle);
      this.Length = (long) raw.sqlite3_blob_bytes(this._blob);
    }

    public override bool CanRead => true;

    public override bool CanWrite { get; }

    public override bool CanSeek => true;

    public override long Length { get; }

    public override long Position
    {
      get => this._position;
      set
      {
        this._position = value >= 0L ? value : throw new ArgumentOutOfRangeException(nameof (value), (object) value, (string) null);
      }
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), (object) offset, (string) null);
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), (object) count, (string) null);
      if (offset + count > buffer.Length)
        throw new ArgumentException(Resources.InvalidOffsetAndCount);
      return this.Read(buffer.AsSpan<byte>(offset, count));
    }

    public override int Read(Span<byte> buffer)
    {
      if (this._blob == null)
        throw new ObjectDisposedException((string) null);
      long offset = this._position;
      if (offset > this.Length)
        offset = this.Length;
      int length = buffer.Length;
      if (offset + (long) length > this.Length)
        length = (int) (this.Length - offset);
      SqliteException.ThrowExceptionForRC(raw.sqlite3_blob_read(this._blob, buffer.Slice(0, length), (int) offset), this._connection.Handle);
      this._position += (long) length;
      return length;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      if (buffer == null)
        throw new ArgumentNullException(nameof (buffer));
      if (offset < 0)
        throw new ArgumentOutOfRangeException(nameof (offset), (object) offset, (string) null);
      if (count < 0)
        throw new ArgumentOutOfRangeException(nameof (count), (object) count, (string) null);
      if (offset + count > buffer.Length)
        throw new ArgumentException(Resources.InvalidOffsetAndCount);
      if (this._blob == null)
        throw new ObjectDisposedException((string) null);
      this.Write((ReadOnlySpan<byte>) buffer.AsSpan<byte>(offset, count));
    }

    public override void Write(ReadOnlySpan<byte> buffer)
    {
      if (!this.CanWrite)
        throw new NotSupportedException(Resources.WriteNotSupported);
      long offset = this._position;
      if (offset > this.Length)
        offset = this.Length;
      int length = buffer.Length;
      if (offset + (long) length > this.Length)
        throw new NotSupportedException(Resources.ResizeNotSupported);
      SqliteException.ThrowExceptionForRC(raw.sqlite3_blob_write(this._blob, buffer.Slice(0, length), (int) offset), this._connection.Handle);
      this._position += (long) length;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      long num;
      switch (origin)
      {
        case SeekOrigin.Begin:
          num = offset;
          break;
        case SeekOrigin.Current:
          num = this._position + offset;
          break;
        case SeekOrigin.End:
          num = this.Length + offset;
          break;
        default:
          throw new ArgumentException(Resources.InvalidEnumValue((object) typeof (SeekOrigin), (object) origin), nameof (origin));
      }
      if (num < 0L)
        throw new IOException(Resources.SeekBeforeBegin);
      return this._position = num;
    }

    protected override void Dispose(bool disposing)
    {
      if (this._blob == null)
        return;
      this._blob.Dispose();
      this._blob = (sqlite3_blob) null;
    }

    public override void Flush()
    {
    }

    public override void SetLength(long value)
    {
      throw new NotSupportedException(Resources.ResizeNotSupported);
    }
  }
}
