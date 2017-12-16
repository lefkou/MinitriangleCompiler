using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class CharacterExpression : Expression
    {
        CharacterLiteral _characterLiteral;

        public CharacterExpression(CharacterLiteral characterLiteral, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _characterLiteral = characterLiteral;
        }

        public CharacterLiteral CharacterLiteral { get { return _characterLiteral; } }

        public override bool IsLiteral
        {
            get { return true; }
        }

        public override int Value
        {
            get { return _characterLiteral.Value; }
        }

       
    }
}