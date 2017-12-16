

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class EmptyExpression : Expression
    {
        public EmptyExpression() : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}