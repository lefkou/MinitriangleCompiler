

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
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _actual = actual;
            _actuals = actuals;
        }

        public ActualParameter Actual { get { return _actual; } }

        public ActualParameterSequence Actuals { get { return _actuals; } }


    }
}