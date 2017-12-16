using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public abstract class ActualParameter : AbstractSyntaxTree
    {
        protected ActualParameter(SourcePosition position)
            : base(position)
        {
        }

        public abstract TResult Visit<TArg, TResult>(IActualParameterVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IActualParameterVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}