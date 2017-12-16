using Triangle.Compiler.SyntaxTrees.Terminals;


namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class IntegerExpression : Expression
    {
        IntegerLiteral _integerLiteral;

        public IntegerExpression(IntegerLiteral integerLiteral, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _integerLiteral = integerLiteral;
        }

        public IntegerExpression(IntegerLiteral integerLiteral)
            : this(integerLiteral, SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public IntegerLiteral IntegerLiteral { get { return _integerLiteral; } }

        public override bool IsLiteral
        {
            get { return true; }
        }

        public override int Value
        {
            get { return _integerLiteral.Value; }
        }
        

    }
}