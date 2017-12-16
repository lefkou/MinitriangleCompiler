//using Triangle.Compiler.SyntaxTrees.Terminals;
//using Triangle.Compiler.SyntaxTrees.Visitors;

//namespace Triangle.Compiler.SyntaxTrees.Actuals
//{
//    public class ProcActualParameter : ActualParameter
//    {
//        readonly Identifier _identifier;

//        public ProcActualParameter(Identifier identifier, SourcePosition position)
//            : base(position)
//        {
//            _identifier = identifier;
//        }

//        public Identifier Identifier { get { return _identifier; } }

//        public override TResult Visit<TArg, TResult>(IActualParameterVisitor<TArg, TResult> visitor, TArg arg)
//        {
//            return visitor.VisitProcActualParameter(this, arg);
//        }
//    }
//}