using Triangle.Compiler.SyntaxTrees.Expressions;


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
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _expression = expression;
            _trueCommand = trueCommand;
            _falseCommand = falseCommand;
        }

        public Expression Expression { get { return _expression; } }

        public Command TrueCommand { get { return _trueCommand; } }

        public Command FalseCommand { get { return _falseCommand; } }


    }
}