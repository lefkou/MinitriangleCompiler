using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class ConstActualParameter : ActualParameter
    {
        readonly Expression _expression;

        public ConstActualParameter(Expression expression, SourcePosition position)
            : base(position)
        {
            _expression = expression;
        }

        public Expression Expression { get { return _expression; } }

        public override TResult Visit<TArg, TResult>(IActualParameterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitConstActualParameter(this, arg);
        }
    }
}