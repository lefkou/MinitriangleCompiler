using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public abstract class Expression : AbstractSyntaxTree
    {
        protected Expression(SourcePosition position) : base(position) { }

        public TypeDenoter Type { get; set; }

        public virtual bool IsLiteral
        {
            get { return false; }
        }

        public virtual int Value
        {
            get { throw new System.NotSupportedException(); }
        }

        public abstract TResult Visit<TArg, TResult>(IExpressionVisitor<TArg, TResult> visitor, TArg arg);

        public TResult Visit<TResult>(IExpressionVisitor<Void, TResult> visitor)
        {
            return Visit(visitor, null);
        }
    }
}