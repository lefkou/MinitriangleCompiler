namespace Triangle.Compiler.CodeGenerator.Entities
{
    public interface IProcedureEntity
    {

        void EncodeCall(Emitter emitter, Frame frame);

        void EncodeFetch(Emitter emitter, Frame frame);

    }

}