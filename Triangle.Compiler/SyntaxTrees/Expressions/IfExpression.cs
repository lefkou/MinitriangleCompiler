using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class IfExpression : Expression
    {
        Expression _testExpression;

        Expression _trueExpression;

        Expression _falseExpression;

        public IfExpression(Expression testExpression, Expression trueExpression,
            Expression falseExpression, SourcePosition position)
            : base(position)
        {
            _testExpression = testExpression;
            _trueExpression = trueExpression;
            _falseExpression = falseExpression;
        }

        public Expression TestExpression { get { return _trueExpression; } }

        public Expression TrueExpression { get { return _trueExpression; } }

        public Expression FalseExpression { get { return _falseExpression; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitIfExpression(this, arg);
        }
    }
}