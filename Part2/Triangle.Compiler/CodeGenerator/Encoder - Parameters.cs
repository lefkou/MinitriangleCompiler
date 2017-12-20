using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Actuals;
using Triangle.Compiler.SyntaxTrees.Formals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder :
            IActualParameterVisitor<Frame, int>,
            IActualParameterSequenceVisitor<Frame, int>
            
    {
        
        // Actual Parameters
        public int VisitConstActualParameter(ConstActualParameter ast, Frame frame)
        {
            return ast.Expression.Visit(this, frame);
        }


        public int VisitVarActualParameter(VarActualParameter ast, Frame frame)
        {
            EncodeFetchAddress(ast.Vname, frame);
            return Machine.AddressSize;
        }

        public int VisitEmptyActualParameterSequence(EmptyActualParameterSequence ast, Frame frame)
        {
            return 0;
        }

        public int VisitMultipleActualParameterSequence(MultipleActualParameterSequence ast,
            Frame frame)
        {
            var argsSize1 = ast.Actual.Visit(this, frame);
            var frame1 = frame.Expand(argsSize1);
            var argsSize2 = ast.Actuals.Visit(this, frame1);
            return argsSize1 + argsSize2;
        }

        public int VisitSingleActualParameterSequence(SingleActualParameterSequence ast,
            Frame frame)
        {
            return ast.Actual.Visit(this, frame);
        }
    }
}