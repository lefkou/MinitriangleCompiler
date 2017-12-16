using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IVnameVisitor<Void, TypeDenoter>
    {
        
        public TypeDenoter VisitSimpleVname(SimpleVname ast, Void arg)
        {
            var binding = ast.Identifier.Visit(this);
            if (binding is IConstantDeclaration constant)
            {
                return ast.Type = constant.Type;
            }

            if (binding is IVariableDeclaration variable)
            {
                return ast.Type = variable.Type;
            }

            ReportUndeclaredOrError(binding, ast.Identifier, "\"%\" is not a const or var identifier");
            return ast.Type = StandardEnvironment.ErrorType;
        }

    }
}