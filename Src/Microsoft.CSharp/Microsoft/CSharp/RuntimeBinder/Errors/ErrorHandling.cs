// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Errors.ErrorHandling
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using System;
using System.Globalization;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
  internal static class ErrorHandling
  {
    public static RuntimeBinderException Error(ErrorCode id, params ErrArg[] args)
    {
      string[] sourceArray = new string[args.Length];
      int[] numArray = new int[args.Length];
      int index1 = 0;
      int index2 = 0;
      int num1 = 0;
      UserStringBuilder userStringBuilder = new UserStringBuilder();
      for (int index3 = 0; index3 < args.Length; ++index3)
      {
        ErrArg parg = args[index3];
        if ((parg.eaf & ErrArgFlags.NoStr) == ErrArgFlags.None)
        {
          bool fUserStrings;
          if (!userStringBuilder.ErrArgToString(out sourceArray[index1], parg, out fUserStrings) && parg.eak == ErrArgKind.Int)
            sourceArray[index1] = parg.n.ToString((IFormatProvider) CultureInfo.InvariantCulture);
          ++index1;
          int num2;
          if (!fUserStrings || (parg.eaf & ErrArgFlags.Unique) == ErrArgFlags.None)
          {
            num2 = -1;
          }
          else
          {
            num2 = index3;
            ++num1;
          }
          numArray[index2] = num2;
          ++index2;
        }
      }
      int length = index1;
      if (num1 > 1)
      {
        string[] destinationArray = new string[length];
        Array.Copy((Array) sourceArray, (Array) destinationArray, length);
        for (int index4 = 0; index4 < length; ++index4)
        {
          if (numArray[index4] >= 0 && !(destinationArray[index4] != sourceArray[index4]))
          {
            ErrArg errArg1 = args[numArray[index4]];
            Symbol symbol1 = (Symbol) null;
            CType ctype1 = (CType) null;
            switch (errArg1.eak)
            {
              case ErrArgKind.Sym:
                symbol1 = errArg1.sym;
                break;
              case ErrArgKind.Type:
                ctype1 = errArg1.pType;
                break;
              case ErrArgKind.SymWithType:
                symbol1 = errArg1.swtMemo.sym;
                break;
              case ErrArgKind.MethWithInst:
                symbol1 = errArg1.mpwiMemo.sym;
                break;
              default:
                continue;
            }
            bool flag = false;
            for (int index5 = index4 + 1; index5 < length; ++index5)
            {
              if (numArray[index5] >= 0 && !(sourceArray[index4] != sourceArray[index5]))
              {
                if (destinationArray[index5] != sourceArray[index5])
                {
                  flag = true;
                }
                else
                {
                  ErrArg errArg2 = args[numArray[index5]];
                  Symbol symbol2 = (Symbol) null;
                  CType ctype2 = (CType) null;
                  switch (errArg2.eak)
                  {
                    case ErrArgKind.Sym:
                      symbol2 = errArg2.sym;
                      break;
                    case ErrArgKind.Type:
                      ctype2 = errArg2.pType;
                      break;
                    case ErrArgKind.SymWithType:
                      symbol2 = errArg2.swtMemo.sym;
                      break;
                    case ErrArgKind.MethWithInst:
                      symbol2 = errArg2.mpwiMemo.sym;
                      break;
                    default:
                      continue;
                  }
                  if (symbol2 != symbol1 || ctype2 != ctype1 || flag)
                  {
                    destinationArray[index5] = sourceArray[index5];
                    flag = true;
                  }
                }
              }
            }
            if (flag)
              destinationArray[index4] = sourceArray[index4];
          }
        }
        sourceArray = destinationArray;
      }
      return new RuntimeBinderException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, ErrorFacts.GetMessage(id), (object[]) sourceArray));
    }
  }
}
