using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;


namespace Triangle.Compiler.SyntaxTrees.Declarations
{
    public class ConstDeclaration : Declaration
    {
        Identifier _identifier;

        Expression _expression;

        public ConstDeclaration(Identifier identifier, Expression expression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _identifier = identifier;
            _expression = expression;
        }

        public ConstDeclaration(Identifier identifier, Expression expression)
            : this(identifier, expression, SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public Identifier Identifier { get { return _identifier; } }

        public Expression Expression { get { return _expression; } }

        public TypeDenoter Type { get { return _expression.Type; } }

    }
}