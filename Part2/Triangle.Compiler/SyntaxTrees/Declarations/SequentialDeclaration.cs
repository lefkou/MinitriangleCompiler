

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class SequentialDeclaration : Declaration
    {
        Declaration _firstDeclaration;

        Declaration _secondDeclaration;

        public SequentialDeclaration(Declaration firstDeclaration, Declaration secondDeclaration,
                SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _firstDeclaration = firstDeclaration;
            _secondDeclaration = secondDeclaration;
        }

        public Declaration FirstDeclaration { get { return _firstDeclaration; } }

        public Declaration SecondDeclaration { get { return _secondDeclaration; } }


    }
}