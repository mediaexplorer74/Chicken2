// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Syntax.NameTable
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Syntax
{
  internal sealed class NameTable
  {
    private NameTable.Entry[] _entries;
    private int _count;
    private int _mask;

    internal NameTable()
    {
      this._mask = 31;
      this._entries = new NameTable.Entry[this._mask + 1];
    }

    public Name Add(string key)
    {
      int hashCode = NameTable.ComputeHashCode(key);
      for (NameTable.Entry entry = this._entries[hashCode & this._mask]; entry != null; entry = entry.Next)
      {
        if (entry.HashCode == hashCode && entry.Name.Text.Equals(key))
          return entry.Name;
      }
      return this.AddEntry(new Name(key), hashCode);
    }

    public Name Add(string key, int length)
    {
      int hashCode = NameTable.ComputeHashCode(key, length);
      for (NameTable.Entry entry = this._entries[hashCode & this._mask]; entry != null; entry = entry.Next)
      {
        if (entry.HashCode == hashCode && NameTable.Equals(entry.Name.Text, key, length))
          return entry.Name;
      }
      return this.AddEntry(new Name(key.Substring(0, length)), hashCode);
    }

    internal void Add(Name name)
    {
      int hashCode = NameTable.ComputeHashCode(name.Text);
      this.AddEntry(name, hashCode);
    }

    private static int ComputeHashCode(string key)
    {
      int length = key.Length;
      for (int index = 0; index < key.Length; ++index)
        length += length << 7 ^ (int) key[index];
      int num1 = length - (length >> 17);
      int num2 = num1 - (num1 >> 11);
      return num2 - (num2 >> 5);
    }

    private static int ComputeHashCode(string key, int length)
    {
      int num1 = length;
      for (int index = 0; index < length; ++index)
        num1 += num1 << 7 ^ (int) key[index];
      int num2 = num1 - (num1 >> 17);
      int num3 = num2 - (num2 >> 11);
      return num3 - (num3 >> 5);
    }

    private static bool Equals(string candidate, string key, int length)
    {
      if (candidate.Length != length)
        return false;
      for (int index = 0; index < candidate.Length; ++index)
      {
        if ((int) candidate[index] != (int) key[index])
          return false;
      }
      return true;
    }

    private Name AddEntry(Name name, int hashCode)
    {
      int index = hashCode & this._mask;
      NameTable.Entry entry = new NameTable.Entry(name, hashCode, this._entries[index]);
      this._entries[index] = entry;
      if (this._count++ == this._mask)
        this.Grow();
      return entry.Name;
    }

    private void Grow()
    {
      int num = this._mask * 2 + 1;
      NameTable.Entry[] entries = this._entries;
      NameTable.Entry[] entryArray = new NameTable.Entry[num + 1];
      NameTable.Entry next;
      for (int index1 = 0; index1 < entries.Length; ++index1)
      {
        for (NameTable.Entry entry = entries[index1]; entry != null; entry = next)
        {
          int index2 = entry.HashCode & num;
          next = entry.Next;
          entry.Next = entryArray[index2];
          entryArray[index2] = entry;
        }
      }
      this._entries = entryArray;
      this._mask = num;
    }

    private sealed class Entry
    {
      public readonly Name Name;
      public readonly int HashCode;
      public NameTable.Entry Next;

      public Entry(Name name, int hashCode, NameTable.Entry next)
      {
        this.Name = name;
        this.HashCode = hashCode;
        this.Next = next;
      }
    }
  }
}
