using Triangle.Compiler.SyntaxTrees.Visitors;

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
            _firstDeclaration = firstDeclaration;
            _secondDeclaration = secondDeclaration;
        }

        public Declaration FirstDeclaration { get { return _firstDeclaration; } }

        public Declaration SecondDeclaration { get { return _secondDeclaration; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitSequentialDeclaration(this, arg);
        }
    }
}