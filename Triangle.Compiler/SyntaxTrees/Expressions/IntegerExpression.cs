using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class IntegerExpression : Expression
    {
        IntegerLiteral _integerLiteral;

        public IntegerExpression(IntegerLiteral integerLiteral, SourcePosition position)
            : base(position)
        {
            _integerLiteral = integerLiteral;
        }

        public IntegerExpression(IntegerLiteral integerLiteral)
            : this(integerLiteral, SourcePosition.Empty)
        {
        }

        public IntegerLiteral IntegerLiteral { get { return _integerLiteral; } }

        public override bool IsLiteral
        {
            get { return true; }
        }

        public override int Value
        {
            get { return _integerLiteral.Value; }
        }
        
        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitIntegerExpression(this, arg);
        }
    }
}