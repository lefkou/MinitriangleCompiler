using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public abstract class Expression : AbstractSyntaxTree
    {
        protected Expression(SourcePosition position) : base(position) 
        {
        if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public TypeDenoter Type { get; set; }

        public virtual bool IsLiteral
        {
            get { return false; }
        }

        public virtual int Value
        {
            get { throw new System.NotSupportedException(); }
        }


    }
}