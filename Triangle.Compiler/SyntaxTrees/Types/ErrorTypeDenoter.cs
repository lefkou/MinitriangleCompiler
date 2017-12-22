using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class ErrorTypeDenoter : TypeDenoter
    {
        public ErrorTypeDenoter() : base(SourcePosition.Empty)
        {
        }

        public override int Size { get { return 0; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitErrorTypeDenoter(this, arg);
        }
    }
}