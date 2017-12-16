using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class SimpleTypeDenoter : TypeDenoter
    {
        Identifier _identifier;

        public SimpleTypeDenoter(Identifier identifier, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
        }

        public Identifier Identifier { get { return _identifier; } }


    }
}