using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public abstract class Vname : AbstractSyntaxTree
    {
        protected Vname(SourcePosition position)
            : base(position)
        { }

        public TypeDenoter Type { get; set; }

        public abstract bool IsVariable { get; }

        public abstract bool IsIndexed { get; }

        public short Offset { get; set; }

        public abstract TResult Visit<TArg, TResult>(IVnameVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IVnameVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}