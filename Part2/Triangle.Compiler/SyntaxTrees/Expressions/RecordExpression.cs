using Triangle.Compiler.SyntaxTrees.Aggregates;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class RecordExpression : Expression
    {
        RecordAggregate _recordAggregate;

        public RecordExpression(RecordAggregate recordAggregate, SourcePosition position)
            : base(position)
        {
            _recordAggregate = recordAggregate;
        }

        public RecordAggregate RecordAggregate { get { return _recordAggregate; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitRecordExpression(this, arg);
        }
    }
}