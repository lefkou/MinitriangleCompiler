using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class LetExpression : Expression
    {
        Declaration _declaration;

        Expression _expression;

        public LetExpression(Declaration declaration, Expression expression, SourcePosition position)
        : base(position)
        {
            _declaration = declaration;
            _expression = expression;
        }

        public Declaration Declaration { get { return _declaration; } }

        public Expression Expression { get { return _expression; } }
        
        public override TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitLetExpression(this, arg);
        }
    }
}