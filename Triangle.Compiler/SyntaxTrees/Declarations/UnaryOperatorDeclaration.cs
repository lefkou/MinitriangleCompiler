using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

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
            _operator = op;
            _argument = argument;
            _result = result;
        }

        public Operator Operator { get { return _operator; } }

        public TypeDenoter Argument { get { return _argument; } }

        public TypeDenoter Result { get { return _result; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitUnaryOperatorDeclaration(this, arg);
        }
    }
}