using Triangle.Compiler.SyntaxTrees.Actuals;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class CallExpression : Expression
    {
        Identifier _identifier;

        ActualParameterSequence _actuals;

        public CallExpression(Identifier identifier, ActualParameterSequence actuals,
                SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _actuals = actuals;
        }

        public Identifier Identifier { get { return _identifier; } }

        public ActualParameterSequence Actuals { get { return _actuals; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitCallExpression(this, arg);
        }
    }
}