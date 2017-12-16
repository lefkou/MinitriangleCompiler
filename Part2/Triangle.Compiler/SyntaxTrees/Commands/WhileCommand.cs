using Triangle.Compiler.SyntaxTrees.Expressions;


namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class WhileCommand : Command
    {
        readonly Command _command;

        readonly Expression _expression;

        public WhileCommand(Expression expression, Command command, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _command = command;
            _expression = expression;
        }

        public Expression Expression { get { return _expression; } }

        public Command Command { get { return _command; } }


    }
}