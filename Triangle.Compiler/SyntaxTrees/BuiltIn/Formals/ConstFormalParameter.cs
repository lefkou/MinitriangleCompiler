using System;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class ConstFormalParameter : FormalParameter
    {
        Identifier _identifier;

        TypeDenoter _type;

        public ConstFormalParameter(Identifier identifier, TypeDenoter type,
                SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _type = type;
        }

        public ConstFormalParameter(TypeDenoter typeDenoter)
            : this(Identifier.Empty, typeDenoter, SourcePosition.Empty)
        {
        }

        public Identifier Identifier { get { return _identifier; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitConstFormalParameter(this, arg);
        }
    }
}