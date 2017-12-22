using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class MultipleActualParameterSequence : ActualParameterSequence
    {
        ActualParameter _actual;

        ActualParameterSequence _actuals;

        public MultipleActualParameterSequence(ActualParameter actual, ActualParameterSequence actuals,
                SourcePosition position)
            : base(position)
        {
            _actual = actual;
            _actuals = actuals;
        }

        public ActualParameter Actual { get { return _actual; } }

        public ActualParameterSequence Actuals { get { return _actuals; } }

        public override TResult Visit<TArg, TResult>(IActualParameterSequenceVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitMultipleActualParameterSequence(this, arg);
        }
    }
}