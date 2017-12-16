

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class IfExpression : Expression
    {
        Expression _testExpression;

        Expression _trueExpression;

        Expression _falseExpression;

        public IfExpression(Expression testExpression, Expression trueExpression,
            Expression falseExpression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _testExpression = testExpression;
            _trueExpression = trueExpression;
            _falseExpression = falseExpression;
        }

        public Expression TestExpression { get { return _trueExpression; } }

        public Expression TrueExpression { get { return _trueExpression; } }

        public Expression FalseExpression { get { return _falseExpression; } }


    }
}