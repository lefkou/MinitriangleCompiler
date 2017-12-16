using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IDeclarationVisitor
    {
        

        public Void VisitConstDeclaration(ConstDeclaration ast, Void arg)
        {
            return null;
        }

		public Void VisitVarDeclaration(VarDeclaration ast, Void arg)
		{

			return null;
		}

        public Void VisitSequentialDeclaration(SequentialDeclaration ast, Void arg)
        {
            
            return null;
        }

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