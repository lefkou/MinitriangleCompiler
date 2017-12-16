using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class ArrayTypeDenoter : TypeDenoter
    {
        IntegerLiteral _integerLiteral;

        TypeDenoter _type;

        public ArrayTypeDenoter(IntegerLiteral integerLiteral, TypeDenoter type, SourcePosition position)
            : base(position)
        {
            _integerLiteral = integerLiteral;
            _type = type;
        }

        public IntegerLiteral IntegerLiteral { get { return _integerLiteral; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override int Size
        {
            get { return _integerLiteral.Value * _type.Size; }
        }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitArrayTypeDenoter(this, arg);
        }
    }
}