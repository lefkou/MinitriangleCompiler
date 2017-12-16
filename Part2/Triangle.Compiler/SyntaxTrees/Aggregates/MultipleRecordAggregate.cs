using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public class MultipleRecordAggregate : RecordAggregate
    {
        Identifier _identifier;

        Expression _expression;

        RecordAggregate _recordAggregate;

        public MultipleRecordAggregate(Identifier identifier, Expression expression,
                RecordAggregate recordAggregate, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _expression = expression;
            _recordAggregate = recordAggregate;
        }

        public Identifier Identifier { get { return _identifier; } }

        public Expression Expression { get { return _expression; } }

        public RecordAggregate RecordAggregate { get { return _recordAggregate; } }

        public override TResult Visit<TArg, TResult>(IRecordAggregateVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitMultipleRecordAggregate(this, arg);
        }
    }
}