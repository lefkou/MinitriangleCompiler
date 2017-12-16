using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Aggregates
{
    public abstract class ArrayAggregate : AbstractSyntaxTree
    {
        protected ArrayAggregate(SourcePosition position)
            : base(position)
        {
        }

        public abstract int ElementCount { get; }

        public abstract TResult Visit<TArg, TResult>(IArrayAggregateVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IArrayAggregateVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}