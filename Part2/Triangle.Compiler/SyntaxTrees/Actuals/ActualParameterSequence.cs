

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public abstract class ActualParameterSequence : AbstractSyntaxTree
    {
        protected ActualParameterSequence(SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}