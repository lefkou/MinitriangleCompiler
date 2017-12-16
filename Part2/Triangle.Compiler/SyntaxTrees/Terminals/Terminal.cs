

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public abstract class Terminal : AbstractSyntaxTree
    {
        readonly string _spelling;

        protected Terminal(string spelling, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _spelling = spelling;
        }

        public string Spelling { get { return _spelling; } }
        
    }
}