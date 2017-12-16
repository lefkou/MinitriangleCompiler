using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.SyntaxTrees.Vnames
{
    public class DotVname : Vname
    {
        Vname _vname;

        Identifier _identifier;

        public DotVname(Vname vname, Identifier identifier, SourcePosition position)
            : base(position)
        {
            _vname = vname;
            _identifier = identifier;
        }

        public Vname Vname { get { return _vname; } }

        public Identifier Identifier { get { return _identifier; } }

        public override bool IsVariable { get { return _vname.IsVariable; } }

        public override bool IsIndexed { get { return _vname.IsIndexed; } }
        
        public override TResult Visit<TArg, TResult>(IVnameVisitor<TArg, TResult> visitor, TArg arg)
        {
            return visitor.VisitDotVname(this, arg);
        }
    }
}