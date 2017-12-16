using Triangle.Compiler.SyntacticAnalyzer;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class Identifier : Terminal
    {
        public static readonly Identifier Empty = new Identifier(string.Empty, SourcePosition.Empty);

        public Identifier(string spelling, SourcePosition position)
            : base(spelling, position)
        {
        }

        public Identifier(Token token) : this(token.Spelling, token.Position)
        {
        }

        public Identifier(string spelling)
            : this(spelling, SourcePosition.Empty)
        {
        }

        public TypeDenoter Type { get; set; }

        public IDeclaration Declaration { get; set; }

        public TResult Visit<TArg, TResult>(IIdentifierVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitIdentifier(this, arg);
        }

        public TResult Visit<TResult>(IIdentifierVisitor<Void, TResult> visitor)
        {
            return visitor.VisitIdentifier(this, null);
        }
    }
}