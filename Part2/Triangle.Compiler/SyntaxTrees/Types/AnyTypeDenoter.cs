

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class AnyTypeDenoter : TypeDenoter
    {
        public AnyTypeDenoter() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}