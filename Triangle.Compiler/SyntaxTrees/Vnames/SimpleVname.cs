using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public class SimpleVname : Vname
    {
        Identifier _identifier;

        public SimpleVname(Identifier identifier, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
        }

        public Identifier Identifier { get { return _identifier; } }

        public override bool IsVariable { get { return _identifier.Declaration is IVariableDeclaration; } }

        public override bool IsIndexed { get { return false; } }

        public override TResult Visit<TArg, TResult>(IVnameVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSimpleVname(this, arg);
        }
    }
}