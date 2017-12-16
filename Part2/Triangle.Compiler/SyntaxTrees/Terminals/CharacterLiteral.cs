using Triangle.Compiler.SyntacticAnalyzer;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class CharacterLiteral : Terminal
    {
        public CharacterLiteral(string spelling, SourcePosition position)
            : base(spelling, position)
        {
        }

        public CharacterLiteral(Token token) : this(token.Spelling, token.Position)
        {
        }

        public int Value { get { return Spelling[1]; } }
    }
}