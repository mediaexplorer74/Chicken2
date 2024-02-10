// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Errors.UserStringBuilder
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using Microsoft.CSharp.RuntimeBinder.Semantics;
using Microsoft.CSharp.RuntimeBinder.Syntax;
using System;
using System.Globalization;
using System.Text;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
  internal struct UserStringBuilder
  {
    private StringBuilder _strBuilder;

    private void BeginString()
    {
      if (this._strBuilder != null)
        return;
      this._strBuilder = new StringBuilder();
    }

    private string EndString()
    {
      string str = this._strBuilder.ToString();
      this._strBuilder.Clear();
      return str;
    }

    private static string ErrSK(SYMKIND sk)
    {
      MessageID id;
      switch (sk)
      {
        case SYMKIND.SK_NamespaceSymbol:
          id = MessageID.SK_NAMESPACE;
          break;
        case SYMKIND.SK_AggregateSymbol:
          id = MessageID.SK_CLASS;
          break;
        case SYMKIND.SK_TypeParameterSymbol:
          id = MessageID.SK_TYVAR;
          break;
        case SYMKIND.SK_FieldSymbol:
          id = MessageID.SK_FIELD;
          break;
        case SYMKIND.SK_LocalVariableSymbol:
          id = MessageID.SK_VARIABLE;
          break;
        case SYMKIND.SK_MethodSymbol:
          id = MessageID.SK_METHOD;
          break;
        case SYMKIND.SK_PropertySymbol:
          id = MessageID.SK_PROPERTY;
          break;
        case SYMKIND.SK_EventSymbol:
          id = MessageID.SK_EVENT;
          break;
        default:
          id = MessageID.SK_UNKNOWN;
          break;
      }
      return UserStringBuilder.ErrId(id);
    }

    private void ErrAppendParamList(TypeArray @params, bool isParamArray)
    {
      if (@params == null)
        return;
      for (int i = 0; i < @params.Count; ++i)
      {
        if (i > 0)
          this.ErrAppendString(", ");
        if (isParamArray && i == @params.Count - 1)
          this.ErrAppendString("params ");
        this.ErrAppendType(@params[i], (SubstContext) null);
      }
    }

    private void ErrAppendString(string str) => this._strBuilder.Append(str);

    private void ErrAppendChar(char ch) => this._strBuilder.Append(ch);

    private void ErrAppendPrintf(string format, params object[] args)
    {
      this.ErrAppendString(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args));
    }

    private void ErrAppendName(Name name)
    {
      if (name == NameManager.GetPredefinedName(PredefinedName.PN_INDEXERINTERNAL))
        this.ErrAppendString("this");
      else
        this.ErrAppendString(name.Text);
    }

    private void ErrAppendParentSym(Symbol sym, SubstContext pctx)
    {
      this.ErrAppendParentCore((Symbol) sym.parent, pctx);
    }

    private void ErrAppendParentCore(Symbol parent, SubstContext pctx)
    {
      if (parent == null || parent == NamespaceSymbol.Root)
        return;
      if (pctx != null && !pctx.IsNop && parent is AggregateSymbol aggregateSymbol && aggregateSymbol.GetTypeVarsAll().Count != 0)
        this.ErrAppendType((CType) TypeManager.SubstType(aggregateSymbol.getThisType(), pctx), (SubstContext) null);
      else
        this.ErrAppendSym(parent, (SubstContext) null);
      this.ErrAppendChar('.');
    }

    private void ErrAppendTypeParameters(TypeArray @params, SubstContext pctx)
    {
      if (@params == null || @params.Count == 0)
        return;
      this.ErrAppendChar('<');
      this.ErrAppendType(@params[0], pctx);
      for (int i = 1; i < @params.Count; ++i)
      {
        this.ErrAppendString(",");
        this.ErrAppendType(@params[i], pctx);
      }
      this.ErrAppendChar('>');
    }

    private void ErrAppendMethod(MethodSymbol meth, SubstContext pctx, bool fArgs)
    {
      if (meth.IsExpImpl() && (bool) meth.swtSlot)
      {
        this.ErrAppendParentSym((Symbol) meth, pctx);
        SubstContext pctx1 = new SubstContext(TypeManager.SubstType(meth.swtSlot.GetType(), pctx));
        this.ErrAppendSym(meth.swtSlot.Sym, pctx1, fArgs);
      }
      else
      {
        MethodKindEnum methKind = meth.MethKind;
        switch (methKind)
        {
          case MethodKindEnum.PropAccessor:
            PropertySymbol property = meth.getProperty();
            this.ErrAppendSym((Symbol) property, pctx);
            if (property.GetterMethod == meth)
            {
              this.ErrAppendString(".get");
              break;
            }
            this.ErrAppendString(".set");
            break;
          case MethodKindEnum.EventAccessor:
            EventSymbol sym = meth.getEvent();
            this.ErrAppendSym((Symbol) sym, pctx);
            if (sym.methAdd == meth)
            {
              this.ErrAppendString(".add");
              break;
            }
            this.ErrAppendString(".remove");
            break;
          default:
            this.ErrAppendParentSym((Symbol) meth, pctx);
            switch (methKind - 1)
            {
              case MethodKindEnum.None:
                this.ErrAppendName(meth.getClass().name);
                goto label_20;
              case MethodKindEnum.Constructor:
                this.ErrAppendChar('~');
                goto case MethodKindEnum.None;
              case MethodKindEnum.EventAccessor:
                this.ErrAppendString("explicit");
                break;
              case MethodKindEnum.ExplicitConv:
                this.ErrAppendString("implicit");
                break;
              default:
                if (meth.isOperator)
                {
                  this.ErrAppendString("operator ");
                  this.ErrAppendString(Operators.OperatorOfMethodName(meth.name));
                  goto label_20;
                }
                else if (!meth.IsExpImpl())
                {
                  this.ErrAppendName(meth.name);
                  goto label_20;
                }
                else
                  goto label_20;
            }
            this.ErrAppendString(" operator ");
            this.ErrAppendType(meth.RetType, pctx);
label_20:
            this.ErrAppendTypeParameters(meth.typeVars, pctx);
            if (!fArgs)
              break;
            this.ErrAppendChar('(');
            this.ErrAppendParamList(TypeManager.SubstTypeArray(meth.Params, pctx), meth.isParamArray);
            this.ErrAppendChar(')');
            break;
        }
      }
    }

    private void ErrAppendIndexer(IndexerSymbol indexer, SubstContext pctx)
    {
      this.ErrAppendString("this[");
      this.ErrAppendParamList(TypeManager.SubstTypeArray(indexer.Params, pctx), indexer.isParamArray);
      this.ErrAppendChar(']');
    }

    private void ErrAppendProperty(PropertySymbol prop, SubstContext pctx)
    {
      this.ErrAppendParentSym((Symbol) prop, pctx);
      if (prop.IsExpImpl())
      {
        if (prop.swtSlot.Sym != null)
        {
          SubstContext pctx1 = new SubstContext(TypeManager.SubstType(prop.swtSlot.GetType(), pctx));
          this.ErrAppendSym(prop.swtSlot.Sym, pctx1);
        }
        else
        {
          if (!(prop is IndexerSymbol indexer))
            return;
          this.ErrAppendChar('.');
          this.ErrAppendIndexer(indexer, pctx);
        }
      }
      else if (prop is IndexerSymbol indexer1)
        this.ErrAppendIndexer(indexer1, pctx);
      else
        this.ErrAppendName(prop.name);
    }

    private void ErrAppendId(MessageID id) => this.ErrAppendString(UserStringBuilder.ErrId(id));

    private void ErrAppendSym(Symbol sym, SubstContext pctx) => this.ErrAppendSym(sym, pctx, true);

    private void ErrAppendSym(Symbol sym, SubstContext pctx, bool fArgs)
    {
      switch (sym.getKind())
      {
        case SYMKIND.SK_NamespaceSymbol:
          if (sym == NamespaceSymbol.Root)
          {
            this.ErrAppendId(MessageID.GlobalNamespace);
            break;
          }
          this.ErrAppendParentSym(sym, (SubstContext) null);
          this.ErrAppendName(sym.name);
          break;
        case SYMKIND.SK_AggregateSymbol:
          string niceName = PredefinedTypes.GetNiceName(sym as AggregateSymbol);
          if (niceName != null)
          {
            this.ErrAppendString(niceName);
            break;
          }
          this.ErrAppendParentSym(sym, pctx);
          this.ErrAppendName(sym.name);
          this.ErrAppendTypeParameters(((AggregateSymbol) sym).GetTypeVars(), pctx);
          break;
        case SYMKIND.SK_TypeParameterSymbol:
          if (sym.name == null)
          {
            TypeParameterSymbol typeParameterSymbol = (TypeParameterSymbol) sym;
            if (typeParameterSymbol.IsMethodTypeParameter())
              this.ErrAppendChar('!');
            this.ErrAppendChar('!');
            this.ErrAppendPrintf("{0}", (object) typeParameterSymbol.GetIndexInTotalParameters());
            break;
          }
          this.ErrAppendName(sym.name);
          break;
        case SYMKIND.SK_FieldSymbol:
          this.ErrAppendParentSym(sym, pctx);
          this.ErrAppendName(sym.name);
          break;
        case SYMKIND.SK_LocalVariableSymbol:
          this.ErrAppendName(sym.name);
          break;
        case SYMKIND.SK_MethodSymbol:
          this.ErrAppendMethod((MethodSymbol) sym, pctx, fArgs);
          break;
        case SYMKIND.SK_PropertySymbol:
          this.ErrAppendProperty((PropertySymbol) sym, pctx);
          break;
      }
    }

    private void ErrAppendType(CType pType, SubstContext pctx)
    {
      if (pctx != null && !pctx.IsNop)
        pType = TypeManager.SubstType(pType, pctx);
      switch (pType.TypeKind)
      {
        case TypeKind.TK_AggregateType:
          AggregateType aggregateType = (AggregateType) pType;
          string niceName = PredefinedTypes.GetNiceName(aggregateType.OwningAggregate);
          if (niceName != null)
          {
            this.ErrAppendString(niceName);
          }
          else
          {
            if (aggregateType.OuterType != null)
            {
              this.ErrAppendType((CType) aggregateType.OuterType, (SubstContext) null);
              this.ErrAppendChar('.');
            }
            else
              this.ErrAppendParentSym((Symbol) aggregateType.OwningAggregate, (SubstContext) null);
            this.ErrAppendName(aggregateType.OwningAggregate.name);
          }
          this.ErrAppendTypeParameters(aggregateType.TypeArgsThis, (SubstContext) null);
          break;
        case TypeKind.TK_VoidType:
          this.ErrAppendName(NameManager.GetPredefinedName(PredefinedName.PN_VOID));
          break;
        case TypeKind.TK_NullType:
          this.ErrAppendId(MessageID.NULL);
          break;
        case TypeKind.TK_MethodGroupType:
          this.ErrAppendId(MessageID.MethodGroup);
          break;
        case TypeKind.TK_ArgumentListType:
          this.ErrAppendString(TokenFacts.GetText(TokenKind.ArgList));
          break;
        case TypeKind.TK_ArrayType:
          this.ErrAppendType(((ArrayType) pType).BaseElementType, (SubstContext) null);
          for (CType ctype = pType; ctype is ArrayType arrayType; ctype = arrayType.ElementType)
          {
            int rank = arrayType.Rank;
            this.ErrAppendChar('[');
            if (rank == 1)
            {
              if (!arrayType.IsSZArray)
                this.ErrAppendChar('*');
            }
            else
            {
              for (int index = rank; index > 1; --index)
                this.ErrAppendChar(',');
            }
            this.ErrAppendChar(']');
          }
          break;
        case TypeKind.TK_PointerType:
          this.ErrAppendType(((PointerType) pType).ReferentType, (SubstContext) null);
          this.ErrAppendChar('*');
          break;
        case TypeKind.TK_ParameterModifierType:
          ParameterModifierType parameterModifierType = (ParameterModifierType) pType;
          this.ErrAppendString(parameterModifierType.IsOut ? "out " : "ref ");
          this.ErrAppendType(parameterModifierType.ParameterType, (SubstContext) null);
          break;
        case TypeKind.TK_NullableType:
          this.ErrAppendType(((NullableType) pType).UnderlyingType, (SubstContext) null);
          this.ErrAppendChar('?');
          break;
        case TypeKind.TK_TypeParameterType:
          TypeParameterType typeParameterType = (TypeParameterType) pType;
          if (typeParameterType.Name == null)
          {
            if (typeParameterType.IsMethodTypeParameter)
              this.ErrAppendChar('!');
            this.ErrAppendChar('!');
            this.ErrAppendPrintf("{0}", (object) typeParameterType.IndexInTotalParameters);
            break;
          }
          this.ErrAppendName(typeParameterType.Name);
          break;
      }
    }

    public bool ErrArgToString(out string psz, ErrArg parg, out bool fUserStrings)
    {
      fUserStrings = false;
      psz = (string) null;
      bool flag = true;
      switch (parg.eak)
      {
        case ErrArgKind.SymKind:
          psz = UserStringBuilder.ErrSK(parg.sk);
          break;
        case ErrArgKind.Sym:
          this.BeginString();
          this.ErrAppendSym(parg.sym, (SubstContext) null);
          psz = this.EndString();
          fUserStrings = true;
          break;
        case ErrArgKind.Type:
          this.BeginString();
          this.ErrAppendType(parg.pType, (SubstContext) null);
          psz = this.EndString();
          fUserStrings = true;
          break;
        case ErrArgKind.Name:
          psz = parg.name != NameManager.GetPredefinedName(PredefinedName.PN_INDEXERINTERNAL) ? parg.name.Text : "this";
          break;
        case ErrArgKind.Str:
          psz = parg.psz;
          break;
        case ErrArgKind.SymWithType:
          SubstContext pctx1 = new SubstContext(parg.swtMemo.ats, (TypeArray) null);
          this.BeginString();
          this.ErrAppendSym(parg.swtMemo.sym, pctx1, true);
          psz = this.EndString();
          fUserStrings = true;
          break;
        case ErrArgKind.MethWithInst:
          SubstContext pctx2 = new SubstContext(parg.mpwiMemo.ats, parg.mpwiMemo.typeArgs);
          this.BeginString();
          this.ErrAppendSym(parg.mpwiMemo.sym, pctx2, true);
          psz = this.EndString();
          fUserStrings = true;
          break;
        default:
          flag = false;
          break;
      }
      return flag;
    }

    private static string ErrId(MessageID id) => ErrorFacts.GetMessage(id);
  }
}
