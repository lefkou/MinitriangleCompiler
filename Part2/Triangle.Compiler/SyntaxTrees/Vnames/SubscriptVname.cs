using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public class SubscriptVname : Vname
    {
        Vname _vname;

        Expression _expression;

        public SubscriptVname(Vname vname, Expression expression, SourcePosition position)
            : base(position)
        {
            _vname = vname;
            _expression = expression;
        }

        public Vname Vname { get { return _vname; } }

        public Expression Expression { get { return _expression; } }

        public override bool IsVariable { get { return _vname.IsVariable; } }

        public override bool IsIndexed { get { return _vname.IsIndexed || !_expression.IsLiteral; } }

        public override TResult Visit<TArg, TResult>(IVnameVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSubscriptVname(this, arg);
        }
    }
}