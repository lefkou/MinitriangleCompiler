using Triangle.Compiler.SyntaxTrees.Declarations;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IDeclarationVisitor<TArg, TResult> : IFormalParameterVisitor<TArg, TResult>
    {
        TResult VisitBinaryOperatorDeclaration(BinaryOperatorDeclaration ast, TArg arg);

        TResult VisitConstDeclaration(ConstDeclaration ast, TArg arg);

        TResult VisitFuncDeclaration(FuncDeclaration ast, TArg arg);

        TResult VisitProcDeclaration(ProcDeclaration ast, TArg arg);

        TResult VisitSequentialDeclaration(SequentialDeclaration ast, TArg arg);

        TResult VisitTypeDeclaration(TypeDeclaration ast, TArg arg);

        TResult VisitUnaryOperatorDeclaration(UnaryOperatorDeclaration ast, TArg arg);

        TResult VisitVarDeclaration(VarDeclaration ast, TArg arg);
    }

    public interface IDeclarationVisitor : IDeclarationVisitor<Void, Void>
    {
    }
}