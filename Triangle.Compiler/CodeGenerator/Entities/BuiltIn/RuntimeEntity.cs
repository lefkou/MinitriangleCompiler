namespace Triangle.Compiler.CodeGenerator.Entities
{
    public abstract class RuntimeEntity
    {

        readonly int _size;

        protected RuntimeEntity(int size)
        {
            _size = size;
        }

        public int Size
        {
            get { return _size; }
        }
    }
}