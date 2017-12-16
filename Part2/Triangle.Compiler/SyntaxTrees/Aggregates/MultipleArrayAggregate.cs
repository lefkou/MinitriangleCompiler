using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public class MultipleArrayAggregate : ArrayAggregate
    {
        Expression _expression;

        ArrayAggregate _arrayAggregate;

        public MultipleArrayAggregate(Expression expression, ArrayAggregate arrayAggregate, SourcePosition position)
            : base(position)
        {
            _expression = expression;
            _arrayAggregate = arrayAggregate;
        }

        public Expression Expression { get { return _expression; } }

        public ArrayAggregate ArrayAggregate { get { return _arrayAggregate; } }

        public override int ElementCount { get { return 1 + _arrayAggregate.ElementCount; } }

        public override TResult Visit<TArg, TResult>(IArrayAggregateVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitMultipleArrayAggregate(this, arg);
        }
    }
}