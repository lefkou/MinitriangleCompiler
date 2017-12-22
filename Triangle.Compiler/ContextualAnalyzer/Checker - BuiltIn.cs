using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
	public partial class Checker : IDeclarationVisitor, IFormalParameterVisitor,
			IFormalParameterSequenceVisitor
    {
        
        public Void VisitFuncDeclaration(FuncDeclaration ast, Void arg)
        {
            ast.Type = ast.Type.Visit(this);
            // permits recursion
            _idTable.Enter(ast.Identifier, ast);
            CheckAndReportError(!ast.Duplicated, "identifier \"%\" already declared",
                ast.Identifier, ast);
            _idTable.OpenScope();
            ast.Formals.Visit(this);
            var expressionType = ast.Expression.Visit(this);
            _idTable.CloseScope();
            CheckAndReportError(ast.Type.Equals(expressionType),
                "body of function \"%\" has wrong type", ast.Identifier, ast.Expression);
            return null;
        }

        public Void VisitProcDeclaration(ProcDeclaration ast, Void arg)
        {
            // permits recursion
            _idTable.Enter(ast.Identifier, ast);
            CheckAndReportError(!ast.Duplicated, "identifier \"%\" already declared",
                ast.Identifier, ast);
            _idTable.OpenScope();
            ast.Formals.Visit(this);
            ast.Command.Visit(this);
            _idTable.CloseScope();
            return null;
        }

		public Void VisitConstFormalParameter(ConstFormalParameter ast, Void arg)
		{
			ast.Type = ast.Type.Visit(this);
			_idTable.Enter(ast.Identifier, ast);
			CheckAndReportError(!ast.Duplicated, "duplicated formal parameter \"%\"",
				ast.Identifier, ast);
			return null;
		}

		public Void VisitFuncFormalParameter(FuncFormalParameter ast, Void arg)
		{
			_idTable.OpenScope();
			ast.Formals.Visit(this);
			_idTable.CloseScope();
			ast.Type = ast.Type.Visit(this);
			_idTable.Enter(ast.Identifier, ast);
			CheckAndReportError(!ast.Duplicated, "duplicated formal parameter \"%\"",
				ast.Identifier, ast);
			return null;
		}

		public Void VisitProcFormalParameter(ProcFormalParameter ast, Void arg)
		{
			_idTable.OpenScope();
			ast.Formals.Visit(this);
			_idTable.CloseScope();
			_idTable.Enter(ast.Identifier, ast);
			CheckAndReportError(!ast.Duplicated, "duplicated formal parameter \"%\"",
				ast.Identifier, ast);
			return null;
		}

		public Void VisitVarFormalParameter(VarFormalParameter ast, Void arg)
		{
			ast.Type = ast.Type.Visit(this);
			_idTable.Enter(ast.Identifier, ast);
			CheckAndReportError(!ast.Duplicated, "duplicated formal parameter \"%\"",
				ast.Identifier, ast);
			return null;
		}

		public Void VisitEmptyFormalParameterSequence(EmptyFormalParameterSequence ast, Void arg)
		{
			return null;
		}

		public Void VisitMultipleFormalParameterSequence(MultipleFormalParameterSequence ast, Void arg)
		{
			ast.Formal.Visit(this);
			ast.Formals.Visit(this);
			return null;
		}

		public Void VisitSingleFormalParameterSequence(SingleFormalParameterSequence ast, Void arg)
		{
			ast.Formal.Visit(this);
			return null;
		}

    }
}