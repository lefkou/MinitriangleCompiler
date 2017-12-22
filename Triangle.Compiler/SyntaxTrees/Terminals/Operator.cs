using Triangle.Compiler.SyntacticAnalyzer;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class Operator : Terminal
    {
        public Operator(string spelling, SourcePosition position)
            : base(spelling, position)
        {
        }

        public Operator(Token token) : this(token.Spelling, token.Position)
        {
        }

        public Operator(string spelling) : this(spelling, SourcePosition.Empty)
        {
        }

        public Declaration Declaration { get; set; }

        public TResult Visit<TArg, TResult>(IOperatorVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitOperator(this, arg);
        }

        public TResult Visit<TResult>(IOperatorVisitor<Void, TResult> visitor)
        {
            return visitor.VisitOperator(this, null);
        }
    }
}