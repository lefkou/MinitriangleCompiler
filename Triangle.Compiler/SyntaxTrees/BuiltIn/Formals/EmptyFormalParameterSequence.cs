using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public class EmptyFormalParameterSequence : FormalParameterSequence
    {
        public EmptyFormalParameterSequence(SourcePosition position)
            : base(position)
        {
        }

        public EmptyFormalParameterSequence()
            : this(SourcePosition.Empty)
        {
        }

        public override TResult Visit<TArg, TResult>(IFormalParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitEmptyFormalParameterSequence(this, arg);
        }
    }
}