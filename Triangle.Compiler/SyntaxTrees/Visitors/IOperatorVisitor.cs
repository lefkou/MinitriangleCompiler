using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IOperatorVisitor<TArg, TResult>
    {
        TResult VisitOperator(Operator ast, TArg arg);
    }
}