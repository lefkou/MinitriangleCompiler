using Triangle.Compiler.SyntaxTrees.Declarations;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public abstract class FieldTypeDenoter : TypeDenoter
    {
        protected FieldTypeDenoter(SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }
    }
}