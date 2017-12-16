using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class BinaryExpression : Expression
    {
        readonly Expression _leftExpression;

        readonly Operator _operator;

        readonly Expression _rightExpression;

        public BinaryExpression(Expression leftExpression, Operator op,
                Expression rightExpression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _leftExpression = leftExpression;
            _operator = op;
            _rightExpression = rightExpression;
        }

        public Expression LeftExpression { get { return _leftExpression; } }

        public Operator Operator { get { return _operator; } }

        public Expression RightExpression { get { return _rightExpression; } }


    }
}