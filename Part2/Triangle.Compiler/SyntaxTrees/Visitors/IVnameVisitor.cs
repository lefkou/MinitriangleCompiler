using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IVnameVisitor<TArg, TResult>
    {
        TResult VisitDotVname(DotVname vname, TArg arg);

        TResult VisitSimpleVname(SimpleVname vname, TArg arg);

        TResult VisitSubscriptVname(SubscriptVname vname, TArg arg);
    }
}