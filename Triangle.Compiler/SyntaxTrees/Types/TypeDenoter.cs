using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public abstract class TypeDenoter : AbstractSyntaxTree
    {
        protected TypeDenoter(SourcePosition position)
            : base(position)
        {
        }

        public abstract int Size { get; }

        public abstract TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(ITypeDenoterVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}