

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class EmptyActualParameterSequence : ActualParameterSequence
    {
        public EmptyActualParameterSequence(SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}