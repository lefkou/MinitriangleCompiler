using Triangle.AbstractMachine;


namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class BoolTypeDenoter : TypeDenoter
    {
        public BoolTypeDenoter() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }



    }
}