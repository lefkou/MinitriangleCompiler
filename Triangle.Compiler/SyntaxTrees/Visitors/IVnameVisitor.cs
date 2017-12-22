using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IVnameVisitor<TArg, TResult>
    {
        
        TResult VisitSimpleVname(SimpleVname vname, TArg arg);

    }
}