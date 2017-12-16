using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public class SimpleVname : Vname
    {
        Identifier _identifier;

        public SimpleVname(Identifier identifier, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
        }

        public Identifier Identifier { get { return _identifier; } }

       

       
    }
}