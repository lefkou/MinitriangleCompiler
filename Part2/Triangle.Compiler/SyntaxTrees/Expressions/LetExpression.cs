using Triangle.Compiler.SyntaxTrees.Declarations;


namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class LetExpression : Expression
    {
        Declaration _declaration;

        Expression _expression;

        public LetExpression(Declaration declaration, Expression expression, SourcePosition position)
        : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _declaration = declaration;
            _expression = expression;
        }

        public Declaration Declaration { get { return _declaration; } }

        public Expression Expression { get { return _expression; } }
        

    }
}