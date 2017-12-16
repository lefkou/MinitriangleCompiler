using Triangle.Compiler.SyntaxTrees.Visitors;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class VarActualParameter : ActualParameter
    {
        readonly Vname _vname;

        public VarActualParameter(Vname vname, SourcePosition position)
            : base(position)
        {
            _vname = vname;
        }

        public Vname Vname { get { return _vname; } }

        public override TResult Visit<TArg, TResult>(IActualParameterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitVarActualParameter(this, arg);
        }
    }
}