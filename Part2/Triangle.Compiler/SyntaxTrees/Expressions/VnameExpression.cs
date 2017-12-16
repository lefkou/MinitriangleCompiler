
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Expressions
{
    public class VnameExpression : Expression
    {
        readonly Vname _vname;

        public VnameExpression(Vname vname, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _vname = vname;
        }

        public Vname Vname { get { return _vname; } }


    }
}