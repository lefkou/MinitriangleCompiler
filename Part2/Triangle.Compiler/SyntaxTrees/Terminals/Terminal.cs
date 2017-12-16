using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public abstract class Terminal : AbstractSyntaxTree
    {
        readonly string _spelling;

        protected Terminal(string spelling, SourcePosition position)
            : base(position)
        {
            _spelling = spelling;
        }

        public string Spelling { get { return _spelling; } }
        
    }
}