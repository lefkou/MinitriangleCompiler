using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class FuncFormalParameter : FormalParameter
    {
        readonly Identifier _identifier;

        readonly FormalParameterSequence _formals;

        TypeDenoter _type;

        public FuncFormalParameter(Identifier identifier, FormalParameterSequence formals,
                TypeDenoter type, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _formals = formals;
            _type = type;
        }

        public Identifier Identifier { get { return _identifier; } }

        public FormalParameterSequence Formals { get { return _formals; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitFuncFormalParameter(this, arg);
        }
    }
}