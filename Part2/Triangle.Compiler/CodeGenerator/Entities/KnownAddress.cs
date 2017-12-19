using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class KnownAddress : AddressableEntity
    {

        public KnownAddress(int size, int level, int displacement)
            : base(size, level, displacement)
        {
        }

        public KnownAddress(int size, Frame frame)
             : base(size, frame)
        {
        }

        public override void EncodeAssign(Emitter emitter, Frame frame, int size, Vname vname)
        {
            emitter.Emit(OpCode.STORE, size, frame.DisplayRegister(Address), Address.Displacement);
            //emitter.Emit(OpCode.STOREI, size, 0, 0); 
            System.Console.WriteLine("Known address assigning");
        }

        public override void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname)
        {
            emitter.Emit(OpCode.LOAD, size, frame.DisplayRegister(Address), Address.Displacement);
            System.Console.WriteLine("Known address fetch");
        }

        public override void EncodeFetchAddress(Emitter emitter, Frame frame, Vname vname)
        {
            emitter.Emit(OpCode.LOADA, frame.DisplayRegister(Address), Address.Displacement);
            System.Console.WriteLine("Known address fetching address");

        }
    }
}