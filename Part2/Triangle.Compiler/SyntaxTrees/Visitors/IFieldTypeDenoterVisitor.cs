using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IFieldTypeDenoterVisitor<TArg, TResult>
    {
        TResult VisitMultipleFieldTypeDenoter(MultipleFieldTypeDenoter ast, TArg arg);

        TResult VisitSingleFieldTypeDenoter(SingleFieldTypeDenoter ast, TArg arg);
    }
}