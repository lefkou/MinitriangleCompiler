

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public abstract class TypeDenoter : AbstractSyntaxTree
    {
        protected TypeDenoter(SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


       
    }
}