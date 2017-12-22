using Triangle.Compiler.SyntaxTrees.Actuals;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class CallCommand : Command
    {
        readonly Identifier _identifier;

        readonly ActualParameterSequence _actuals;

        public CallCommand(Identifier identifier, ActualParameterSequence actuals, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _actuals = actuals;
        }

        public Identifier Identifier { get { return _identifier; } }

        public ActualParameterSequence Actuals { get { return _actuals; } }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitCallCommand(this, arg);
        }
    }
}