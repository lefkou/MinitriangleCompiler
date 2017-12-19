using Triangle.AbstractMachine;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class EqualityProcedure : RuntimeEntity, IProcedureEntity
    {

        readonly Primitive _primitive;

        public EqualityProcedure(int size, Primitive primitive)
            : base(size)
        {
            _primitive = primitive;
        }

        public void EncodeCall(Emitter emitter, Frame frame)
        {
            emitter.Emit(OpCode.LOADL, frame.Size / 2);
            emitter.Emit(OpCode.CALL, Register.SB, Register.PB, _primitive);
        }

        public void EncodeFetch(Emitter emitter, Frame frame)
        {
            emitter.Emit(OpCode.LOADA, 0, Register.SB, 0);
            emitter.Emit(OpCode.LOADA, 0, Register.PB, _primitive);
        }

    }
}