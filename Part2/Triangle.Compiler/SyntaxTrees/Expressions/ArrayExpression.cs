using Triangle.Compiler.SyntaxTrees.Aggregates;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class ArrayExpression : Expression
    {
        ArrayAggregate _arrayAggregate;

        public ArrayExpression(ArrayAggregate arrayAggregate, SourcePosition position)
            : base(position)
        {
            _arrayAggregate = arrayAggregate;
        }

        public ArrayAggregate ArrayAggregate { get { return _arrayAggregate; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitArrayExpression(this, arg);
        }
    }
}