using Triangle.Compiler.SyntaxTrees.Actuals;

namespace Triangle.Compiler.SyntaxTrees.Visitors
{
    public interface IActualParameterVisitor<TArg, TResult>
    {
        TResult VisitConstActualParameter(ConstActualParameter ast, TArg arg);

        TResult VisitFuncActualParameter(FuncActualParameter ast, TArg arg);

        TResult VisitProcActualParameter(ProcActualParameter ast, TArg arg);

        TResult VisitVarActualParameter(VarActualParameter ast, TArg arg);
    }
}