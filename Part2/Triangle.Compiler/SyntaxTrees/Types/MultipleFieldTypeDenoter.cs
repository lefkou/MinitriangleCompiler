using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class MultipleFieldTypeDenoter : FieldTypeDenoter
    {
        Identifier _identifier;

        TypeDenoter _type;

        FieldTypeDenoter _fieldType;

        public MultipleFieldTypeDenoter(Identifier identifier, TypeDenoter type,
                FieldTypeDenoter fieldType, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _type = type;
            _fieldType = fieldType;
        }

        public Identifier Identifier { get { return _identifier; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public FieldTypeDenoter FieldType { get { return _fieldType; } }

        public override int Size { get { return _type.Size + _fieldType.Size; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitMultipleFieldTypeDenoter(this, arg);
        }
    }
}