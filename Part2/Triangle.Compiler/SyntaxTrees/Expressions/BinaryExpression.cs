using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class BinaryExpression : Expression
    {
        readonly Expression _leftExpression;

        readonly Operator _operator;

        readonly Expression _rightExpression;

        public BinaryExpression(Expression leftExpression, Operator op,
                Expression rightExpression, SourcePosition position)
            : base(position)
        {
            _leftExpression = leftExpression;
            _operator = op;
            _rightExpression = rightExpression;
        }

        public Expression LeftExpression { get { return _leftExpression; } }

        public Operator Operator { get { return _operator; } }

        public Expression RightExpression { get { return _rightExpression; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitBinaryExpression(this, arg);
        }
    }
}