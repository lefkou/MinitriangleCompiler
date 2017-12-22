using Triangle.Compiler.SyntaxTrees.Visitors;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class VnameExpression : Expression
    {
        readonly Vname _vname;

        public VnameExpression(Vname vname, SourcePosition position)
            : base(position)
        {
            _vname = vname;
        }

        public Vname Vname { get { return _vname; } }

        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitVnameExpression(this, arg);
        }
    }
}