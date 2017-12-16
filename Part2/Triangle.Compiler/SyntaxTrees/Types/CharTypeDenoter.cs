using Triangle.AbstractMachine;


namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class CharTypeDenoter : TypeDenoter
    {
        public CharTypeDenoter() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}