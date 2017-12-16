

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public abstract class Declaration : AbstractSyntaxTree
    {
        protected Declaration(SourcePosition pos) : base(pos) {
        if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
		}

        public bool Duplicated { get; set; }


    }
}