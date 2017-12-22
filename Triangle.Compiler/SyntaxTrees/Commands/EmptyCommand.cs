using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(SourcePosition position)
            : base(position)
        { }

        public EmptyCommand()
            : this(SourcePosition.Empty)
        {
        }

        public override TResult Visit<TArg, TResult>(ICommandVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitEmptyCommand(this, arg);
        }
    }
}