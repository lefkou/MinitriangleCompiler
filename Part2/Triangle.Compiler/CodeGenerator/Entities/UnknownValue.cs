using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class UnknownValue : RuntimeEntity, IFetchableEntity
    {

        readonly ObjectAddress _address;

        public UnknownValue(int size, int level, int displacement)
            : base(size)
        {
            _address = new ObjectAddress(level, displacement);
        }

        public UnknownValue(int size, Frame frame)
            :
            this(size, frame.Level, frame.Size)
        {
        }

        public void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname)
        {
            if (vname.IsIndexed)
            {
                emitter.Emit(OpCode.LOAD, frame.DisplayRegister(_address), _address.Displacement);
                System.Console.WriteLine("UnKnown value indexed loading");


            }
            else
            {
                emitter.Emit(OpCode.LOAD, size, frame.DisplayRegister(_address), _address.Displacement);
                System.Console.WriteLine("unKnow value loading");

            }
        }
    }
}