using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IIdentifierVisitor<TArg, TResult>
    {
        TResult VisitIdentifier(Identifier ast, TArg arg);
    }
}