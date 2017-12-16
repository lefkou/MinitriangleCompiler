using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;


namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class BinaryOperatorDeclaration : Declaration
    {
        Operator _operator;

        TypeDenoter _firstArgument;

        TypeDenoter _secondArgument;

        TypeDenoter _result;

        public BinaryOperatorDeclaration(Operator op, TypeDenoter firstArgument,
                TypeDenoter secondArgument, TypeDenoter result)
            : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _operator = op;
            _firstArgument = firstArgument;
            _secondArgument = secondArgument;
            _result = result;
        }

        public Operator Operator { get { return _operator; } }

        public TypeDenoter FirstArgument { get { return _firstArgument; } }

        public TypeDenoter SecondArgument { get { return _secondArgument; } }

        public TypeDenoter Result { get { return _result; } }


    }
}