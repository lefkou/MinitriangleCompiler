using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class UnknownAddress : AddressableEntity
    {

        public UnknownAddress(int size, int level, int displacement)
            : base(size, level, displacement)
        {
        }

        public override void EncodeAssign(Emitter emitter, Frame frame, int size, Vname vname)
        {
            emitter.Emit(OpCode.LOAD, Machine.AddressSize, frame.DisplayRegister(_address), _address.Displacement);
            emitter.Emit(OpCode.STOREI, size, 0, 0); 
            //System.Console.WriteLine("Unknown address assigning");

        }

        public override void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname)
        {
            emitter.Emit(OpCode.LOAD, Machine.AddressSize, frame.DisplayRegister(_address));
            emitter.Emit(OpCode.LOADA, size);
            //System.Console.WriteLine("unKnown address fetching");

        }

        public override void EncodeFetchAddress(Emitter emitter, Frame frame, Vname vname)
        {
            emitter.Emit(OpCode.LOAD, Machine.AddressSize, frame.DisplayRegister(_address), _address.Displacement);
            //System.Console.WriteLine("unKnown address fetching address");

        }

    }
}