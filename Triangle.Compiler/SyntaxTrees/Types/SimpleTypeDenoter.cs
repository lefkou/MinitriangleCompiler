using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class SimpleTypeDenoter : TypeDenoter
    {
        Identifier _identifier;

        public SimpleTypeDenoter(Identifier identifier, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
        }

        public Identifier Identifier { get { return _identifier; } }

        public override int Size { get { return 0; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSimpleTypeDenoter(this, arg);
        }
    }
}