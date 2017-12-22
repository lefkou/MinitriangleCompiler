using Triangle.Compiler.SyntaxTrees.Actuals;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IActualParameterVisitor<FormalParameter, Void>,
            IActualParameterSequenceVisitor<FormalParameterSequence, Void>
    {
      
        // Actual Parameters

        // Always returns null. Uses the given FormalParameter.

        public Void VisitConstActualParameter(ConstActualParameter ast, FormalParameter arg)
        {
            var expressionType = ast.Expression.Visit(this);
            var param = arg as ConstFormalParameter;
            if (param != null)
            {
                CheckAndReportError(expressionType.Equals(param.Type),
                    "wrong type for const actual parameter", ast.Expression);
            }
            else
            {
                ReportError("const actual parameter not expected here", ast);
            }
            return null;
        }

       
        
        public Void VisitVarActualParameter(VarActualParameter ast, FormalParameter arg)
        {
            var actualType = ast.Vname.Visit(this);
            if (!ast.Vname.IsVariable)
            {
                ReportError("actual parameter is not a variable", ast.Vname);
            }
            else if (arg is VarFormalParameter)
            {
                var parameter = (VarFormalParameter)arg;
                CheckAndReportError(actualType.Equals(parameter.Type),
                    "wrong type for var actual parameter", ast.Vname);
            }
            else
            {
                ReportError("var actual parameter not expected here", ast.Vname);
            }
            return null;
        }

        public Void VisitEmptyActualParameterSequence(EmptyActualParameterSequence ast,
                FormalParameterSequence arg)
        {
            CheckAndReportError(arg is EmptyFormalParameterSequence, "too few actual parameters",
                ast);
            return null;
        }

        public Void VisitMultipleActualParameterSequence(MultipleActualParameterSequence ast,
                FormalParameterSequence arg)
        {
            var formals = arg as MultipleFormalParameterSequence;
            if (formals != null)
            {
                ast.Actual.Visit(this, formals.Formal);
                ast.Actuals.Visit(this, formals.Formals);
            }
            else
            {
                ReportError("too many actual parameters", ast);
            }
            return null;
        }

        public Void VisitSingleActualParameterSequence(SingleActualParameterSequence ast,
                FormalParameterSequence arg)
        {
            var formal = arg as SingleFormalParameterSequence;
            if (formal != null)
            {
                ast.Actual.Visit(this, formal.Formal);
            }
            else
            {
                ReportError("incorrect number of actual parameters", ast);
            }
            return null;
        }

    }
}