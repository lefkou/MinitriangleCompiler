using Triangle.Compiler.SyntaxTrees.Expressions;


namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class ConstActualParameter : ActualParameter
    {
        readonly Expression _expression;

        public ConstActualParameter(Expression expression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _expression = expression;
        }

        public Expression Expression { get { return _expression; } }

     
    }
}