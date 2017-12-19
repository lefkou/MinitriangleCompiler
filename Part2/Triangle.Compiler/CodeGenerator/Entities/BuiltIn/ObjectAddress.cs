namespace Triangle.Compiler.CodeGenerator.Entities
{
    public sealed class ObjectAddress
    {

        readonly int _level;

        readonly int _displacement;

        public ObjectAddress(int level, int displacement)
        {
            _level = level;
            _displacement = displacement;
        }

        public int Level
        {
            get { return _level; }
        }

        public int Displacement
        {
            get { return _displacement; }
        }
    }
}