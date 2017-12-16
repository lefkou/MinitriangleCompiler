using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class IntegerLiteral : Terminal
    {
        public IntegerLiteral(string spelling, SourcePosition position)
            : base(spelling, position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public IntegerLiteral(Token token) : this(token.Spelling, token.Position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public IntegerLiteral(int value, SourcePosition position)
            : base(value.ToString(), position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public int Value { get { return int.Parse(Spelling); } }
    }
}