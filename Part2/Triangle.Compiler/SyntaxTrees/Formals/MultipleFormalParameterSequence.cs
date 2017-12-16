using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class MultipleFormalParameterSequence : FormalParameterSequence
    {
        FormalParameter _formal;

        FormalParameterSequence _formals;

        public MultipleFormalParameterSequence(FormalParameter formal, FormalParameterSequence formals,
                SourcePosition position)
            : base(position)
        {
            _formal = formal;
            _formals = formals;
        }

        public FormalParameter Formal { get { return _formal; } }

        public FormalParameterSequence Formals { get { return _formals; } }

        public override TResult Visit<TArg, TResult>(IFormalParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitMultipleFormalParameterSequence(this, arg);
        }
    }
}