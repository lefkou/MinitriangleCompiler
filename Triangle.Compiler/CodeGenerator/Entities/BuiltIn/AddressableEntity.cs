using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public abstract class AddressableEntity : RuntimeEntity, IFetchableEntity
    {

        protected readonly ObjectAddress _address;

        protected AddressableEntity(int size, int level, int displacement) : base(size)
        {
            _address = new ObjectAddress(level, displacement);
        }

        protected AddressableEntity(int size, Frame frame)
            : this(size, frame.Level, frame.Size)
        { }

        public ObjectAddress Address
        {
            get { return _address; }
        }

        public abstract void EncodeAssign(Emitter emitter, Frame frame, int size, Vname vname);

        public abstract void EncodeFetchAddress(Emitter emitter, Frame frame, Vname vname);

        public abstract void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname);
    }
}