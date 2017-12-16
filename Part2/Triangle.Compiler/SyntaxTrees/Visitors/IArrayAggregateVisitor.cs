using Triangle.Compiler.SyntaxTrees.Aggregates;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IArrayAggregateVisitor<TArg, TResult>
    {
        TResult VisitSingleArrayAggregate(SingleArrayAggregate ast, TArg arg);

        TResult VisitMultipleArrayAggregate(MultipleArrayAggregate ast, TArg arg);
    }
}