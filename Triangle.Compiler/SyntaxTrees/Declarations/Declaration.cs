using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public abstract class Declaration : AbstractSyntaxTree, IDeclaration
    {
        protected Declaration(SourcePosition pos) : base(pos) { }

        public bool Duplicated { get; set; }

        public abstract TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IDeclarationVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}