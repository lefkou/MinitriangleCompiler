using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class SingleFormalParameterSequence : FormalParameterSequence
    {
        FormalParameter _formal;

        public SingleFormalParameterSequence(FormalParameter formal, SourcePosition position)
            : base(position)
        {
            _formal = formal;
        }

        public SingleFormalParameterSequence(FormalParameter formal) : this(formal, SourcePosition.Empty)
        {
        }

        public FormalParameter Formal { get { return _formal; } }

        public override TResult Visit<TArg, TResult>(IFormalParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSingleFormalParameterSequence(this, arg);
        }
    }
}