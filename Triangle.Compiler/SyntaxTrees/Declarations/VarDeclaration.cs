using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class VarDeclaration : Declaration, IVariableDeclaration
    {
        Identifier _identifier;

        TypeDenoter _type;

        public VarDeclaration(Identifier identifier, TypeDenoter type, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _type = type;
        }

        public Identifier Identifier { get { return _identifier; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitVarDeclaration(this, arg);
        }
    }
}