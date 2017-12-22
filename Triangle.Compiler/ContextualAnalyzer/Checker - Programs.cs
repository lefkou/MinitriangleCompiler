using Triangle.Compiler.SyntaxTrees;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : IProgramVisitor
    {
        public Void VisitProgram(Program ast, Void arg)
        {
            ast.Command.Visit(this, null);
            return null;
        }
    }
}