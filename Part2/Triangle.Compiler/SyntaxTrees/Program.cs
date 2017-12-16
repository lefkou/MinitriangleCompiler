using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees
{
    public class Program : AbstractSyntaxTree
    {
        Command _command;

        public Program(Command command, SourcePosition position)
            : base(position)
        {
            _command = command;
        }

        public Command Command { get { return _command; } }
        
        public TResult Visit<TArg, TResult>(IProgramVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitProgram(this, arg);
        }
    }
}