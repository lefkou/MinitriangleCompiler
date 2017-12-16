using Triangle.Compiler.SyntaxTrees.Formals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IFormalParameterVisitor<TArg, TResult>
    {
        TResult VisitConstFormalParameter(ConstFormalParameter ast, TArg arg);

        TResult VisitFuncFormalParameter(FuncFormalParameter ast, TArg arg);

        TResult VisitProcFormalParameter(ProcFormalParameter ast, TArg arg);

        TResult VisitVarFormalParameter(VarFormalParameter ast, TArg arg);
    }

    public interface IFormalParameterVisitor : IFormalParameterVisitor<Void, Void>
    {
    }
}