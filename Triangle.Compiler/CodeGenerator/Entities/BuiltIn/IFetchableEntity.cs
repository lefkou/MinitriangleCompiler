using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public interface IFetchableEntity
    {

        void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname);

    }
}