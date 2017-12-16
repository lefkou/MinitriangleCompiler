

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class SingleActualParameterSequence : ActualParameterSequence
    {
        readonly ActualParameter _actual;

        public SingleActualParameterSequence(ActualParameter actual, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _actual = actual;
        }

        public ActualParameter Actual { get { return _actual; } }


    }
}