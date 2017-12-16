using Triangle.Compiler.SyntaxTrees.Aggregates;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IRecordAggregateVisitor<TArg, TResult>
    {
        TResult VisitSingleRecordAggregate(SingleRecordAggregate ast, TArg arg);

        TResult VisitMultipleRecordAggregate(MultipleRecordAggregate ast, TArg arg);
    }
}