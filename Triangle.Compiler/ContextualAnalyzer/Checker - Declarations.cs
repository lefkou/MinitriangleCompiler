using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IDeclarationVisitor
    {
        

        // visit the constdeclaration in the ast and return errors
        // in case of error
        public Void VisitConstDeclaration(ConstDeclaration ast, Void arg)
        {
            ast.Expression.Visit(this);
            _idTable.Enter(ast.Identifier, ast);
            CheckAndReportError(!ast.Duplicated, "identifier \"%\" already declared",
                ast.Identifier, ast);
            return null;
        }

        // visit the vardeclaration in the ast and return errors
        // in case of error
		public Void VisitVarDeclaration(VarDeclaration ast, Void arg)
		{
            ast.Type = ast.Type.Visit(this);
            _idTable.Enter(ast.Identifier, ast);
            CheckAndReportError(!ast.Duplicated, "identifier \"%\" already declared",
                ast.Identifier, ast);
            return null;
		}

        // visit the sequential declaration in the ast and return errors
        // in case of error
        public Void VisitSequentialDeclaration(SequentialDeclaration ast, Void arg)
        {
            
            ast.FirstDeclaration.Visit(this);
            ast.SecondDeclaration.Visit(this);
            return null;
        }

        // visit the type declaration in the ast and return errors
        // in case of error
		public Void VisitTypeDeclaration(TypeDeclaration ast, Void arg)
		{
			ast.Type = ast.Type.Visit(this);
			_idTable.Enter(ast.Identifier, ast);
			CheckAndReportError(!ast.Duplicated, "identifier \"%\" already declared",
				ast.Identifier, ast);
			return null;
		}

        public Void VisitUnaryOperatorDeclaration(UnaryOperatorDeclaration ast, Void arg)
        {
            return null;
        }


		public Void VisitBinaryOperatorDeclaration(BinaryOperatorDeclaration ast, Void arg)
		{
			return null;
		}



    }
}