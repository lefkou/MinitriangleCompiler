using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class SingleActualParameterSequence : ActualParameterSequence
    {
        readonly ActualParameter _actual;

        public SingleActualParameterSequence(ActualParameter actual, SourcePosition position)
            : base(position)
        {
            _actual = actual;
        }

        public ActualParameter Actual { get { return _actual; } }

        public override TResult Visit<TArg, TResult>(IActualParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSingleActualParameterSequence(this, arg);
        }
    }
}