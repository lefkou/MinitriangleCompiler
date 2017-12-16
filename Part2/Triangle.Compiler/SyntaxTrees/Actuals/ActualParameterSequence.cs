using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public abstract class ActualParameterSequence : AbstractSyntaxTree
    {
        protected ActualParameterSequence(SourcePosition position)
            : base(position)
        {
        }

        public abstract TResult Visit<TArg, TResult>(IActualParameterSequenceVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IActualParameterSequenceVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}