using Triangle.Compiler.SyntaxTrees.Actuals;
using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class CallCommand : Command
    {
        readonly Identifier _identifier;

        readonly ActualParameterSequence _actuals;

        public CallCommand(Identifier identifier, ActualParameterSequence actuals, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
            _actuals = actuals;
        }

        public Identifier Identifier { get { return _identifier; } }

        public ActualParameterSequence Actuals { get { return _actuals; } }

    }
}