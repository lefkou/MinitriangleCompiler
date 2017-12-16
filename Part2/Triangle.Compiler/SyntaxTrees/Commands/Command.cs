

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public abstract class Command : AbstractSyntaxTree
    {
        protected Command(SourcePosition position) : base(position) {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); } 
        }

    }
}