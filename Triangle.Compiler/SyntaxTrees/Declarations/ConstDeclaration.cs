using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class ConstDeclaration : Declaration, IConstantDeclaration
    {
        Identifier _identifier;

        Expression _expression;

        public ConstDeclaration(Identifier identifier, Expression expression, SourcePosition position)
            : base(position)
        {
            _identifier = identifier;
            _expression = expression;
        }

        public ConstDeclaration(Identifier identifier, Expression expression)
            : this(identifier, expression, SourcePosition.Empty)
        {
        }

        public Identifier Identifier { get { return _identifier; } }

        public Expression Expression { get { return _expression; } }

        public TypeDenoter Type { get { return _expression.Type; } }
        
        public override TResult Visit<TArg, TResult>(IDeclarationVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitConstDeclaration(this, arg);
        }
    }
}