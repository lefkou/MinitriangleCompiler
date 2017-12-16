using Triangle.Compiler.SyntaxTrees.Formals;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public interface IProcedureDeclaration
    {
        FormalParameterSequence Formals { get; }
    }
}