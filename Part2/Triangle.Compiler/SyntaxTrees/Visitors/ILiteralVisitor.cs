using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface ILiteralVisitor<TArg, TResult>
    {
        TResult VisitCharacterLiteral(CharacterLiteral ast, TArg arg);

        TResult VisitIntegerLiteral(IntegerLiteral ast, TArg arg);
    }
}