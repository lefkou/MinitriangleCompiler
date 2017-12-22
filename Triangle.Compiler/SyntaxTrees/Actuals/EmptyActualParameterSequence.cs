using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class EmptyActualParameterSequence : ActualParameterSequence
    {
        public EmptyActualParameterSequence(SourcePosition position)
            : base(position)
        {
        }

        public override TResult Visit<TArg, TResult>(IActualParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitEmptyActualParameterSequence(this, arg);
        }
    }
}