using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;


namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class UnaryOperatorDeclaration : Declaration
    {
        Operator _operator;

        TypeDenoter _argument;

        TypeDenoter _result;

        public UnaryOperatorDeclaration(Operator op, TypeDenoter argument,
                TypeDenoter result)
            : base(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _operator = op;
            _argument = argument;
            _result = result;
        }

        public Operator Operator { get { return _operator; } }

        public TypeDenoter Argument { get { return _argument; } }

        public TypeDenoter Result { get { return _result; } }


    }
}