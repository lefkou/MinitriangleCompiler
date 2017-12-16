using Triangle.Compiler.SyntaxTrees.Expressions;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IExpressionVisitor<TArg, TResult>
    {
        TResult VisitArrayExpression(ArrayExpression ast, TArg arg);

        TResult VisitBinaryExpression(BinaryExpression ast, TArg arg);

        TResult VisitCallExpression(CallExpression ast, TArg arg);

        TResult VisitCharacterExpression(CharacterExpression ast, TArg arg);

        TResult VisitEmptyExpression(EmptyExpression ast, TArg arg);

        TResult VisitIfExpression(IfExpression ast, TArg arg);

        TResult VisitIntegerExpression(IntegerExpression ast, TArg arg);

        TResult VisitLetExpression(LetExpression ast, TArg arg);

        TResult VisitRecordExpression(RecordExpression ast, TArg arg);

        TResult VisitUnaryExpression(UnaryExpression ast, TArg arg);

        TResult VisitVnameExpression(VnameExpression ast, TArg arg);
    }
}