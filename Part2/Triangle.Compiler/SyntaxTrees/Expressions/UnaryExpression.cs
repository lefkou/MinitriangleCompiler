using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class UnaryExpression : Expression
    {
        readonly Operator _operator;

        readonly Expression _expression;

        public UnaryExpression(Operator op, Expression expression, SourcePosition position)
            : base(position)
        {
            _operator = op;
            _expression = expression;
        }

        public Operator Operator { get { return _operator; } }

        public Expression Expression { get { return _expression; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitUnaryExpression(this, arg);
        }
    }
}