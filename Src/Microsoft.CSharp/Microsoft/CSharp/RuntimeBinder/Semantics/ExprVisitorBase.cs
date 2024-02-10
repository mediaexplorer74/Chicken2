// Decompiled with JetBrains decompiler
// Type: Microsoft.CSharp.RuntimeBinder.Semantics.ExprVisitorBase
// Assembly: Microsoft.CSharp, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// MVID: DC6D2496-69CF-48FE-AD2F-4EB0C173A6F4
// Assembly location: C:\Users\Admin\Desktop\RE\ChickWinx64\Microsoft.CSharp.dll
// XML documentation location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8\Microsoft.CSharp.xml

using System.Diagnostics.CodeAnalysis;

#nullable disable
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
  internal abstract class ExprVisitorBase
  {
    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected Expr Visit(Expr pExpr) => pExpr != null ? this.Dispatch(pExpr) : (Expr) null;

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr Dispatch(Expr pExpr)
    {
      switch (pExpr.Kind)
      {
        case ExpressionKind.BinaryOp:
          return this.VisitBINOP(pExpr as ExprBinOp);
        case ExpressionKind.UnaryOp:
          return this.VisitUNARYOP(pExpr as ExprUnaryOp);
        case ExpressionKind.Assignment:
          return this.VisitASSIGNMENT(pExpr as ExprAssignment);
        case ExpressionKind.List:
          return this.VisitLIST(pExpr as ExprList);
        case ExpressionKind.ArrayIndex:
          return this.VisitARRAYINDEX(pExpr as ExprArrayIndex);
        case ExpressionKind.Call:
          return this.VisitCALL(pExpr as ExprCall);
        case ExpressionKind.Field:
          return this.VisitFIELD(pExpr as ExprField);
        case ExpressionKind.Local:
          return this.VisitLOCAL(pExpr as ExprLocal);
        case ExpressionKind.Constant:
          return this.VisitCONSTANT(pExpr as ExprConstant);
        case ExpressionKind.Class:
          return pExpr;
        case ExpressionKind.Property:
          return this.VisitPROP(pExpr as ExprProperty);
        case ExpressionKind.Multi:
          return this.VisitMULTI(pExpr as ExprMulti);
        case ExpressionKind.MultiGet:
          return this.VisitMULTIGET(pExpr as ExprMultiGet);
        case ExpressionKind.Wrap:
          return this.VisitWRAP(pExpr as ExprWrap);
        case ExpressionKind.Concat:
          return this.VisitCONCAT(pExpr as ExprConcat);
        case ExpressionKind.ArrayInit:
          return this.VisitARRINIT(pExpr as ExprArrayInit);
        case ExpressionKind.Cast:
          return this.VisitCAST(pExpr as ExprCast);
        case ExpressionKind.UserDefinedConversion:
          return this.VisitUSERDEFINEDCONVERSION(pExpr as ExprUserDefinedConversion);
        case ExpressionKind.TypeOf:
          return this.VisitTYPEOF(pExpr as ExprTypeOf);
        case ExpressionKind.ZeroInit:
          return this.VisitZEROINIT(pExpr as ExprZeroInit);
        case ExpressionKind.UserLogicalOp:
          return this.VisitUSERLOGOP(pExpr as ExprUserLogicalOp);
        case ExpressionKind.MemberGroup:
          return this.VisitMEMGRP(pExpr as ExprMemberGroup);
        case ExpressionKind.FieldInfo:
          return this.VisitFIELDINFO(pExpr as ExprFieldInfo);
        case ExpressionKind.MethodInfo:
          return this.VisitMETHODINFO(pExpr as ExprMethodInfo);
        case ExpressionKind.EqualsParam:
          return this.VisitEQUALS(pExpr as ExprBinOp);
        case ExpressionKind.Compare:
          return this.VisitCOMPARE(pExpr as ExprBinOp);
        case ExpressionKind.True:
          return this.VisitTRUE(pExpr as ExprUnaryOp);
        case ExpressionKind.False:
          return this.VisitFALSE(pExpr as ExprUnaryOp);
        case ExpressionKind.Inc:
          return this.VisitINC(pExpr as ExprUnaryOp);
        case ExpressionKind.Dec:
          return this.VisitDEC(pExpr as ExprUnaryOp);
        case ExpressionKind.LogicalNot:
          return this.VisitLOGNOT(pExpr as ExprUnaryOp);
        case ExpressionKind.Eq:
          return this.VisitEQ(pExpr as ExprBinOp);
        case ExpressionKind.NotEq:
          return this.VisitNE(pExpr as ExprBinOp);
        case ExpressionKind.LessThan:
          return this.VisitLT(pExpr as ExprBinOp);
        case ExpressionKind.LessThanOrEqual:
          return this.VisitLE(pExpr as ExprBinOp);
        case ExpressionKind.GreaterThan:
          return this.VisitGT(pExpr as ExprBinOp);
        case ExpressionKind.GreaterThanOrEqual:
          return this.VisitGE(pExpr as ExprBinOp);
        case ExpressionKind.Add:
          return this.VisitADD(pExpr as ExprBinOp);
        case ExpressionKind.Subtract:
          return this.VisitSUB(pExpr as ExprBinOp);
        case ExpressionKind.Multiply:
          return this.VisitMUL(pExpr as ExprBinOp);
        case ExpressionKind.Divide:
          return this.VisitDIV(pExpr as ExprBinOp);
        case ExpressionKind.Modulo:
          return this.VisitMOD(pExpr as ExprBinOp);
        case ExpressionKind.Negate:
          return this.VisitNEG(pExpr as ExprUnaryOp);
        case ExpressionKind.UnaryPlus:
          return this.VisitUPLUS(pExpr as ExprUnaryOp);
        case ExpressionKind.BitwiseAnd:
          return this.VisitBITAND(pExpr as ExprBinOp);
        case ExpressionKind.BitwiseOr:
          return this.VisitBITOR(pExpr as ExprBinOp);
        case ExpressionKind.BitwiseExclusiveOr:
          return this.VisitBITXOR(pExpr as ExprBinOp);
        case ExpressionKind.BitwiseNot:
          return this.VisitBITNOT(pExpr as ExprUnaryOp);
        case ExpressionKind.LeftShirt:
          return this.VisitLSHIFT(pExpr as ExprBinOp);
        case ExpressionKind.RightShift:
          return this.VisitRSHIFT(pExpr as ExprBinOp);
        case ExpressionKind.LogicalAnd:
          return this.VisitLOGAND(pExpr as ExprBinOp);
        case ExpressionKind.LogicalOr:
          return this.VisitLOGOR(pExpr as ExprBinOp);
        case ExpressionKind.Sequence:
          return this.VisitSEQUENCE(pExpr as ExprBinOp);
        case ExpressionKind.Save:
          return this.VisitSAVE(pExpr as ExprBinOp);
        case ExpressionKind.Swap:
          return this.VisitSWAP(pExpr as ExprBinOp);
        case ExpressionKind.Indir:
          return this.VisitINDIR(pExpr as ExprBinOp);
        case ExpressionKind.Addr:
          return this.VisitADDR(pExpr as ExprUnaryOp);
        case ExpressionKind.StringEq:
          return this.VisitSTRINGEQ(pExpr as ExprBinOp);
        case ExpressionKind.StringNotEq:
          return this.VisitSTRINGNE(pExpr as ExprBinOp);
        case ExpressionKind.DelegateEq:
          return this.VisitDELEGATEEQ(pExpr as ExprBinOp);
        case ExpressionKind.DelegateNotEq:
          return this.VisitDELEGATENE(pExpr as ExprBinOp);
        case ExpressionKind.DelegateAdd:
          return this.VisitDELEGATEADD(pExpr as ExprBinOp);
        case ExpressionKind.DelegateSubtract:
          return this.VisitDELEGATESUB(pExpr as ExprBinOp);
        case ExpressionKind.DecimalNegate:
          return this.VisitDECIMALNEG(pExpr as ExprUnaryOp);
        case ExpressionKind.DecimalInc:
          return this.VisitDECIMALINC(pExpr as ExprUnaryOp);
        case ExpressionKind.DecimalDec:
          return this.VisitDECIMALDEC(pExpr as ExprUnaryOp);
        default:
          throw Error.InternalCompilerError();
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    private void VisitChildren(Expr pExpr)
    {
      switch (pExpr.Kind)
      {
        case ExpressionKind.NoOp:
          break;
        case ExpressionKind.UnaryOp:
        case ExpressionKind.True:
        case ExpressionKind.False:
        case ExpressionKind.Inc:
        case ExpressionKind.Dec:
        case ExpressionKind.LogicalNot:
        case ExpressionKind.Negate:
        case ExpressionKind.UnaryPlus:
        case ExpressionKind.BitwiseNot:
        case ExpressionKind.Addr:
        case ExpressionKind.DecimalNegate:
        case ExpressionKind.DecimalInc:
        case ExpressionKind.DecimalDec:
          Expr expr1 = this.Visit((pExpr as ExprUnaryOp).Child);
          (pExpr as ExprUnaryOp).Child = expr1;
          break;
        case ExpressionKind.Assignment:
          Expr expr2 = this.Visit((pExpr as ExprAssignment).LHS);
          (pExpr as ExprAssignment).LHS = expr2;
          Expr expr3 = this.Visit((pExpr as ExprAssignment).RHS);
          (pExpr as ExprAssignment).RHS = expr3;
          break;
        case ExpressionKind.List:
          ExprList exprList1 = (ExprList) pExpr;
          Expr optionalNextListNode;
          while (true)
          {
            exprList1.OptionalElement = this.Visit(exprList1.OptionalElement);
            optionalNextListNode = exprList1.OptionalNextListNode;
            if (optionalNextListNode != null)
            {
              if (optionalNextListNode is ExprList exprList2)
                exprList1 = exprList2;
              else
                goto label_6;
            }
            else
              break;
          }
          break;
label_6:
          exprList1.OptionalNextListNode = this.Visit(optionalNextListNode);
          break;
        case ExpressionKind.ArrayIndex:
          Expr expr4 = this.Visit((pExpr as ExprArrayIndex).Array);
          (pExpr as ExprArrayIndex).Array = expr4;
          Expr expr5 = this.Visit((pExpr as ExprArrayIndex).Index);
          (pExpr as ExprArrayIndex).Index = expr5;
          break;
        case ExpressionKind.Call:
          Expr expr6 = this.Visit((pExpr as ExprCall).OptionalArguments);
          (pExpr as ExprCall).OptionalArguments = expr6;
          Expr expr7 = this.Visit((Expr) (pExpr as ExprCall).MemberGroup);
          (pExpr as ExprCall).MemberGroup = expr7 as ExprMemberGroup;
          break;
        case ExpressionKind.Field:
          Expr expr8 = this.Visit((pExpr as ExprField).OptionalObject);
          (pExpr as ExprField).OptionalObject = expr8;
          break;
        case ExpressionKind.Local:
          break;
        case ExpressionKind.Constant:
          Expr expr9 = this.Visit((pExpr as ExprConstant).OptionalConstructorCall);
          (pExpr as ExprConstant).OptionalConstructorCall = expr9;
          break;
        case ExpressionKind.Class:
          break;
        case ExpressionKind.Property:
          Expr expr10 = this.Visit((pExpr as ExprProperty).OptionalArguments);
          (pExpr as ExprProperty).OptionalArguments = expr10;
          Expr expr11 = this.Visit((Expr) (pExpr as ExprProperty).MemberGroup);
          (pExpr as ExprProperty).MemberGroup = expr11 as ExprMemberGroup;
          break;
        case ExpressionKind.Multi:
          Expr expr12 = this.Visit((pExpr as ExprMulti).Left);
          (pExpr as ExprMulti).Left = expr12;
          Expr expr13 = this.Visit((pExpr as ExprMulti).Operator);
          (pExpr as ExprMulti).Operator = expr13;
          break;
        case ExpressionKind.MultiGet:
          break;
        case ExpressionKind.Wrap:
          break;
        case ExpressionKind.Concat:
          Expr expr14 = this.Visit((pExpr as ExprConcat).FirstArgument);
          (pExpr as ExprConcat).FirstArgument = expr14;
          Expr expr15 = this.Visit((pExpr as ExprConcat).SecondArgument);
          (pExpr as ExprConcat).SecondArgument = expr15;
          break;
        case ExpressionKind.ArrayInit:
          Expr expr16 = this.Visit((pExpr as ExprArrayInit).OptionalArguments);
          (pExpr as ExprArrayInit).OptionalArguments = expr16;
          Expr expr17 = this.Visit((pExpr as ExprArrayInit).OptionalArgumentDimensions);
          (pExpr as ExprArrayInit).OptionalArgumentDimensions = expr17;
          break;
        case ExpressionKind.Cast:
          Expr expr18 = this.Visit((pExpr as ExprCast).Argument);
          (pExpr as ExprCast).Argument = expr18;
          break;
        case ExpressionKind.UserDefinedConversion:
          Expr expr19 = this.Visit((pExpr as ExprUserDefinedConversion).UserDefinedCall);
          (pExpr as ExprUserDefinedConversion).UserDefinedCall = expr19;
          break;
        case ExpressionKind.TypeOf:
          break;
        case ExpressionKind.ZeroInit:
          break;
        case ExpressionKind.UserLogicalOp:
          Expr expr20 = this.Visit((pExpr as ExprUserLogicalOp).TrueFalseCall);
          (pExpr as ExprUserLogicalOp).TrueFalseCall = expr20;
          Expr expr21 = this.Visit((Expr) (pExpr as ExprUserLogicalOp).OperatorCall);
          (pExpr as ExprUserLogicalOp).OperatorCall = expr21 as ExprCall;
          Expr expr22 = this.Visit((pExpr as ExprUserLogicalOp).FirstOperandToExamine);
          (pExpr as ExprUserLogicalOp).FirstOperandToExamine = expr22;
          break;
        case ExpressionKind.MemberGroup:
          Expr expr23 = this.Visit((pExpr as ExprMemberGroup).OptionalObject);
          (pExpr as ExprMemberGroup).OptionalObject = expr23;
          break;
        case ExpressionKind.FieldInfo:
          break;
        case ExpressionKind.MethodInfo:
          break;
        default:
          Expr expr24 = this.Visit((pExpr as ExprBinOp).OptionalLeftChild);
          (pExpr as ExprBinOp).OptionalLeftChild = expr24;
          Expr expr25 = this.Visit((pExpr as ExprBinOp).OptionalRightChild);
          (pExpr as ExprBinOp).OptionalRightChild = expr25;
          break;
      }
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitEXPR(Expr pExpr)
    {
      this.VisitChildren(pExpr);
      return pExpr;
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitBINOP(ExprBinOp pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLIST(ExprList pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitASSIGNMENT(ExprAssignment pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitARRAYINDEX(ExprArrayIndex pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitUNARYOP(ExprUnaryOp pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitUSERLOGOP(ExprUserLogicalOp pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitTYPEOF(ExprTypeOf pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitCAST(ExprCast pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitUSERDEFINEDCONVERSION(ExprUserDefinedConversion pExpr)
    {
      return this.VisitEXPR((Expr) pExpr);
    }

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitZEROINIT(ExprZeroInit pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMEMGRP(ExprMemberGroup pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitCALL(ExprCall pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitPROP(ExprProperty pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitFIELD(ExprField pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLOCAL(ExprLocal pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitCONSTANT(ExprConstant pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMULTIGET(ExprMultiGet pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMULTI(ExprMulti pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitWRAP(ExprWrap pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitCONCAT(ExprConcat pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitARRINIT(ExprArrayInit pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitFIELDINFO(ExprFieldInfo pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMETHODINFO(ExprMethodInfo pExpr) => this.VisitEXPR((Expr) pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitEQUALS(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitCOMPARE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitEQ(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitNE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitGE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitADD(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSUB(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDIV(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitBITAND(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitBITOR(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLSHIFT(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLOGAND(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSEQUENCE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSAVE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitINDIR(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSTRINGEQ(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDELEGATEEQ(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDELEGATEADD(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLT(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMUL(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitBITXOR(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitRSHIFT(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLOGOR(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSTRINGNE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDELEGATENE(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitGT(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitMOD(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitSWAP(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDELEGATESUB(ExprBinOp pExpr) => this.VisitBINOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitTRUE(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitINC(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitLOGNOT(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitNEG(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitBITNOT(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitADDR(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDECIMALNEG(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDECIMALDEC(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitFALSE(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDEC(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitUPLUS(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);

    [RequiresUnreferencedCode("Using dynamic types might cause types or members to be removed by trimmer.")]
    protected virtual Expr VisitDECIMALINC(ExprUnaryOp pExpr) => this.VisitUNARYOP(pExpr);
  }
}
