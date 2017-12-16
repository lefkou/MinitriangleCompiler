using Triangle.Compiler.SyntaxTrees.Declarations;

namespace Triangle.Compiler.SyntaxTrees.Formals
{
    public abstract class FormalParameter : Declaration
    {
        protected FormalParameter(SourcePosition position)
            : base(position)
        {
        }
    }
}