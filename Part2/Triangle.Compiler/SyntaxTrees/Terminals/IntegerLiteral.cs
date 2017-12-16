using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class IntegerLiteral : Terminal
    {
        public IntegerLiteral(string spelling, SourcePosition position)
            : base(spelling, position)
        {
        }

        public IntegerLiteral(Token token) : this(token.Spelling, token.Position)
        {
        }

        public IntegerLiteral(int value, SourcePosition position)
            : base(value.ToString(), position)
        {
        }

        public int Value { get { return int.Parse(Spelling); } }
    }
}