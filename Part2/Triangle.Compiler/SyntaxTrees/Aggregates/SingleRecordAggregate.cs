using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public class SingleRecordAggregate : RecordAggregate
    {
        Identifier _identifier;

        Expression _expression;

        public SingleRecordAggregate(Identifier identifier, Expression expression, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _expression = expression;
        }

        public Identifier Identifier { get { return _identifier; } }

        public Expression Expression { get { return _expression; } }

        public override TResult Visit<TArg, TResult>(IRecordAggregateVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSingleRecordAggregate(this, arg);
        }
    }
}