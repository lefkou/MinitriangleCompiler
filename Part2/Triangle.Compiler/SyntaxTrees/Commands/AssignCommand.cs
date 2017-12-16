using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntaxTrees.Commands
{
    public class AssignCommand : Command
    {
        readonly Vname _vname;

        readonly Expression _expression;

        public AssignCommand(Vname vname, Expression expression, SourcePosition position)
            : base(position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
            _vname = vname;
            _expression = expression;
        }

        public Vname Vname { get { return _vname; } }

        public Expression Expression { get { return _expression; } }

    }
}