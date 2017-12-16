using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class SequentialCommand : Command
    {
        readonly Command _firstCommand;

        readonly Command _secondCommand;

        public SequentialCommand(Command firstCommand, Command secondCommand,
                SourcePosition position)
            : base(position)
        {
            _firstCommand = firstCommand;
            _secondCommand = secondCommand;
        }

        public Command FirstCommand { get { return _firstCommand; } }

        public Command SecondCommand { get { return _secondCommand; } }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSequentialCommand(this, arg);
        }
    }
}