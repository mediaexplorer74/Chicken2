// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExpressionIterator
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal sealed class ExpressionIterator
  {
    private ExprList _pList;
    private Expr _pCurrent;

    public ExpressionIterator(Expr pExpr) => this.Init(pExpr);

    public bool AtEnd() => this._pCurrent == null && this._pList == null;

    public Expr Current() => this._pCurrent;

    public void MoveNext()
    {
      if (this.AtEnd())
        return;
      if (this._pList == null)
        this._pCurrent = (Expr) null;
      else
        this.Init(this._pList.OptionalNextListNode);
    }

    public static int Count(Expr pExpr)
    {
      int num = 0;
      ExpressionIterator expressionIterator = new ExpressionIterator(pExpr);
      while (!expressionIterator.AtEnd())
      {
        ++num;
        expressionIterator.MoveNext();
      }
      return num;
    }

    private void Init(Expr pExpr)
    {
      if (pExpr == null)
      {
        this._pList = (ExprList) null;
        this._pCurrent = (Expr) null;
      }
      else if (pExpr is ExprList exprList)
      {
        this._pList = exprList;
        this._pCurrent = exprList.OptionalElement;
      }
      else
      {
        this._pList = (ExprList) null;
        this._pCurrent = pExpr;
      }
    }
  }
}
