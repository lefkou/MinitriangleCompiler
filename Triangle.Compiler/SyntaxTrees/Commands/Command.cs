using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public abstract class Command : AbstractSyntaxTree
    {
        protected Command(SourcePosition position) : base(position) { }

        public abstract TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(ICommandVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}