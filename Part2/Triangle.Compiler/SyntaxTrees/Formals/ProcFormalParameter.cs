using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class ProcFormalParameter : FormalParameter
    {
        readonly Identifier _identifier;

        readonly FormalParameterSequence _formals;

        public ProcFormalParameter(Identifier identifier, FormalParameterSequence formals,
                SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _formals = formals;
        }

        public Identifier Identifier { get { return _identifier; } }

        public FormalParameterSequence Formals { get { return _formals; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitProcFormalParameter(this, arg);
        }
    }
}