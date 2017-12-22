using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public interface IFunctionDeclaration
    {
        FormalParameterSequence Formals { get; }

        TypeDenoter Type { get; }
    }
}