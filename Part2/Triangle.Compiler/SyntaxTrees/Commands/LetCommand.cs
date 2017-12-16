using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class LetCommand : Command
    {
        readonly Declaration _declaration;

        readonly Command _command;

        public LetCommand(Declaration declaration, Command command, SourcePosition position)
            : base(position)
        {
            _declaration = declaration;
            _command = command;
        }

        public Declaration Declaration { get { return _declaration; } }

        public Command Command { get { return _command; } }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitLetCommand(this, arg);
        }
    }
}