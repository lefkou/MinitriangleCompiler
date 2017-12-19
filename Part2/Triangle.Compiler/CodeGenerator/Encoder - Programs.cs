using Triangle.Compiler.SyntaxTrees;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder : IProgramVisitor<Frame, Void>
    {
         public Void VisitProgram(Program ast, Frame frame)
        {

            return ast.Command.Visit(this, frame);
        }
    }
}