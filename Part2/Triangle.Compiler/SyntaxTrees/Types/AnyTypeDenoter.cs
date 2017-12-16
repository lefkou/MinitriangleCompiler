using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class AnyTypeDenoter : TypeDenoter
    {
        public AnyTypeDenoter() : base(SourcePosition.Empty)
        {
        }

        public override int Size { get { return 0; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitAnyTypeDenoter(this, arg);
        }
    }
}