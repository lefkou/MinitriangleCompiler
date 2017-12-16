using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class IntTypeDenoter : TypeDenoter
    {
        public IntTypeDenoter() : base(SourcePosition.Empty)
        {
        }

        public override int Size { get { return Machine.IntegerSize; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitIntTypeDenoter(this, arg);
        }
    }
}