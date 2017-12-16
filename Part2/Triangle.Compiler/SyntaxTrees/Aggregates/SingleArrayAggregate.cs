using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public class SingleArrayAggregate : ArrayAggregate
    {
        readonly Expression _expression;

        public SingleArrayAggregate(Expression expression, SourcePosition position)
            : base(position)
        {
            _expression = expression;
        }

        public Expression Expression { get { return _expression; } }

        public override int ElementCount { get { return 1; } }
        
        public override TResult Visit<TArg, TResult>(IArrayAggregateVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSingleArrayAggregate(this, arg);
        }
    }
}