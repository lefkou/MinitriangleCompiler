using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Types
{
    public class RecordTypeDenoter : TypeDenoter
    {
        FieldTypeDenoter _fieldType;

        public RecordTypeDenoter(FieldTypeDenoter fieldType, SourcePosition position)
            : base(position)
        {
            _fieldType = fieldType;
        }

        public FieldTypeDenoter FieldType
        {
            get { return _fieldType; }
            set { _fieldType = value; }
        }

        public override int Size { get { return _fieldType.Size; } }

        public override TResult Visit<TArg, TResult>(ITypeDenoterVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitRecordTypeDenoter(this, arg);
        }
    }
}