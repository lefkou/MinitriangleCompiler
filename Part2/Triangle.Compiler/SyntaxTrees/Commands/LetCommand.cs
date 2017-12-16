using Triangle.Compiler.SyntaxTrees.Declarations;


namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class LetCommand : Command
    {
        readonly Declaration _declaration;

        readonly Command _command;

        public LetCommand(Declaration declaration, Command command, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _declaration = declaration;
            _command = command;
        }

        public Declaration Declaration { get { return _declaration; } }

        public Command Command { get { return _command; } }


    }
}