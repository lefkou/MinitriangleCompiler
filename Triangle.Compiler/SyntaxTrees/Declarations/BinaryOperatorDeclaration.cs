using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

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
            _operator = op;
            _firstArgument = firstArgument;
            _secondArgument = secondArgument;
            _result = result;
        }

        public Operator Operator { get { return _operator; } }

        public TypeDenoter FirstArgument { get { return _firstArgument; } }

        public TypeDenoter SecondArgument { get { return _secondArgument; } }

        public TypeDenoter Result { get { return _result; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitBinaryOperatorDeclaration(this, arg);
        }
    }
}