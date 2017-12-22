using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface ITypeDenoterVisitor<TArg, TResult> 
    {
        TResult VisitAnyTypeDenoter(AnyTypeDenoter ast, TArg arg);

        TResult VisitBoolTypeDenoter(BoolTypeDenoter ast, TArg arg);

        TResult VisitCharTypeDenoter(CharTypeDenoter ast, TArg arg);

        TResult VisitErrorTypeDenoter(ErrorTypeDenoter ast, TArg arg);

        TResult VisitIntTypeDenoter(IntTypeDenoter ast, TArg arg);

        TResult VisitSimpleTypeDenoter(SimpleTypeDenoter ast, TArg arg);
    }
}