

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class ErrorTypeDenoter : TypeDenoter
    {
        public ErrorTypeDenoter() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }



    }
}