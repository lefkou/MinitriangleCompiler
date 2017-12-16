using Triangle.Compiler.SyntaxTrees.Commands;
using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class ProcDeclaration : Declaration, IProcedureDeclaration
    {
        Identifier _identifier;

        FormalParameterSequence _formals;

        Command _command;

        public ProcDeclaration(Identifier identifier, FormalParameterSequence formals,
                Command command, SourcePosition position)
                : base(position)
        {
            _identifier = identifier;
            _formals = formals;
            _command = command;
        }

        public ProcDeclaration(Identifier identifier, FormalParameterSequence formals)
            : this(identifier, formals, new EmptyCommand(), SourcePosition.Empty)
        {
        }

        public Identifier Identifier { get { return _identifier; } }

        public FormalParameterSequence Formals { get { return _formals; } }

        public Command Command { get { return _command; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitProcDeclaration(this, arg);
        }
    }
}