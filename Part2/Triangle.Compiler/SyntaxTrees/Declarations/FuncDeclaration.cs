using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class FuncDeclaration : Declaration, IFunctionDeclaration
    {
        readonly Identifier _identifier;

        readonly FormalParameterSequence _formals;

        TypeDenoter _type;

        readonly Expression _expression;

        public FuncDeclaration(Identifier identifier, FormalParameterSequence formals,
                TypeDenoter type, Expression expression, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _formals = formals;
            _type = type;
            _expression = expression;
        }

        public FuncDeclaration(Identifier identifier, FormalParameterSequence formals,
                TypeDenoter type)
            : this(identifier, formals, type, new EmptyExpression(), SourcePosition.Empty)
        {
        }

        public Identifier Identifier { get { return _identifier; } }

        public FormalParameterSequence Formals { get { return _formals; } }

        public TypeDenoter Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Expression Expression { get { return _expression; } }

        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitFuncDeclaration(this, arg);
        }
    }
}