using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class CharacterLiteral : Terminal
    {
        public CharacterLiteral(string spelling, SourcePosition position)
            : base(spelling, position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public CharacterLiteral(Token token) : this(token.Spelling, token.Position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public int Value { get { return Spelling[1]; } }
    }
}