using Triangle.Compiler.SyntaxTrees.Formals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IFormalParameterSequenceVisitor<TArg, TResult>
    {
        TResult VisitEmptyFormalParameterSequence(EmptyFormalParameterSequence ast, TArg arg);

        TResult VisitMultipleFormalParameterSequence(MultipleFormalParameterSequence ast, TArg arg);

        TResult VisitSingleFormalParameterSequence(SingleFormalParameterSequence ast, TArg arg);
    }

    public interface IFormalParameterSequenceVisitor : IFormalParameterSequenceVisitor<Void, Void>
    {
    }
}