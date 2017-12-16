using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class UnaryExpression : Expression
    {
        readonly Operator _operator;

        readonly Expression _expression;

        public UnaryExpression(Operator op, Expression expression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _operator = op;
            _expression = expression;
        }

        public Operator Operator { get { return _operator; } }

        public Expression Expression { get { return _expression; } }

       
    }
}