

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class EmptyCommand : Command
    {
        public EmptyCommand(SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); } 
        }

        public EmptyCommand()
            : this(SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }


    }
}