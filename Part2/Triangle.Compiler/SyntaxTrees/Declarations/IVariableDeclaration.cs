using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public interface IVariableDeclaration
    {
        TypeDenoter Type { get; }
    }
}