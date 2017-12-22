using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class WhileCommand : Command
    {
        readonly Command _command;

        readonly Expression _expression;

        public WhileCommand(Expression expression, Command command, SourcePosition position)
            : base(position)
        {
            _command = command;
            _expression = expression;
        }

        public Expression Expression { get { return _expression; } }

        public Command Command { get { return _command; } }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitWhileCommand(this, arg);
        }
    }
}