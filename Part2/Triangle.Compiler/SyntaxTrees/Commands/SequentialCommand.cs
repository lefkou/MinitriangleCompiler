

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class SequentialCommand : Command
    {
        readonly Command _firstCommand;

        readonly Command _secondCommand;

        public SequentialCommand(Command firstCommand, Command secondCommand,
                SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _firstCommand = firstCommand;
            _secondCommand = secondCommand;
        }

        public Command FirstCommand { get { return _firstCommand; } }

        public Command SecondCommand { get { return _secondCommand; } }


    }
}