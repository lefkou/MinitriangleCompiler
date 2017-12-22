using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public abstract class FormalParameterSequence : AbstractSyntaxTree
    {
        protected FormalParameterSequence(SourcePosition position)
            : base(position)
        {
        }

        public abstract TResult Visit<TArg, TResult>(IFormalParameterSequenceVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IFormalParameterSequenceVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}