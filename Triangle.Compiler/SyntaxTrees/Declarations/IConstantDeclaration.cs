using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public interface IConstantDeclaration
    {
        TypeDenoter Type { get; }
    }
}