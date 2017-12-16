using Triangle.Compiler.SyntaxTrees.Types;


namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public abstract class Vname : AbstractSyntaxTree
    {
        protected Vname(SourcePosition position)
            : base(position)
        { if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); } }

        public TypeDenoter Type { get; set; }


    }
}