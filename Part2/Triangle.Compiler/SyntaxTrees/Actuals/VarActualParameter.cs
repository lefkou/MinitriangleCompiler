
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Actuals
{
    public class VarActualParameter : ActualParameter
    {
        readonly Vname _vname;

        public VarActualParameter(Vname vname, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _vname = vname;
        }

        public Vname Vname { get { return _vname; } }

      
    }
}