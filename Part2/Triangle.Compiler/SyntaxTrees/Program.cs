using Triangle.Compiler.SyntaxTrees.Commands;


namespace Triangle.Compiler.SyntaxTrees
{
    public class Program : AbstractSyntaxTree
    {
        Command _command;

        public Program(Command command, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _command = command;
        }

        public Command Command { get { return _command; } }
        

    }
}