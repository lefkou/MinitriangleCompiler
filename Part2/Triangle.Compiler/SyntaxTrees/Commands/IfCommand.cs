using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class IfCommand : Command
    {
        readonly Expression _expression;

        readonly Command _trueCommand;

        readonly Command _falseCommand;

        public IfCommand(Expression expression, Command trueCommand,
                Command falseCommand, SourcePosition position)
            : base(position)
        {
            _expression = expression;
            _trueCommand = trueCommand;
            _falseCommand = falseCommand;
        }

        public Expression Expression { get { return _expression; } }

        public Command TrueCommand { get { return _trueCommand; } }

        public Command FalseCommand { get { return _falseCommand; } }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitIfCommand(this, arg);
        }
    }
}