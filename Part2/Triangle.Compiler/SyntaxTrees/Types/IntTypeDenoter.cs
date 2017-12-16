using Triangle.AbstractMachine;


namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class IntTypeDenoter : TypeDenoter
    {
        public IntTypeDenoter() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}