namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class Field : RuntimeEntity
    {

        readonly int _fieldOffset;

        public Field(int size, int fieldOffset)
            : base(size)

        {
            this._fieldOffset = fieldOffset;
        }

        public int FieldOffset
        {
            get { return _fieldOffset; }
        }
    }
}