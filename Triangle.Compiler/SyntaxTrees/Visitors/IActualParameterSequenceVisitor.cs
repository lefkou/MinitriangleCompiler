using Triangle.Compiler.SyntaxTrees.Actuals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IActualParameterSequenceVisitor<TArg, TResult>
    {
        TResult VisitEmptyActualParameterSequence(EmptyActualParameterSequence ast, TArg arg);

        TResult VisitMultipleActualParameterSequence(MultipleActualParameterSequence ast, TArg arg);

        TResult VisitSingleActualParameterSequence(SingleActualParameterSequence ast, TArg arg);
    }
}