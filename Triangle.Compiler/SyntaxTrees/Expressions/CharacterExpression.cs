using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class CharacterExpression : Expression
    {
        CharacterLiteral _characterLiteral;

        public CharacterExpression(CharacterLiteral characterLiteral, SourcePosition position)
            : base(position)
        {
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

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitCharacterExpression(this, arg);
        }
    }
}