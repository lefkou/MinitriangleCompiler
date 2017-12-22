using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;
using Triangle.Compiler.SyntaxTrees.Formals;


namespace Triangle.Compiler.CodeGenerator
{
	public partial class Encoder : IDeclarationVisitor<Frame, int>, IFormalParameterVisitor<Frame, int>,
			IFormalParameterSequenceVisitor<Frame, int>
    {
        
        public int VisitFuncDeclaration(FuncDeclaration ast, Frame frame)
        {
            var argsSize = 0;
            var valSize = 0;
            var jumpAddr = _emitter.Emit(OpCode.JUMP, Register.CB);
            ast.Entity = new KnownProcedure(Machine.ClosureSize, frame.Level, _emitter.NextInstrAddr);
            Encoder.WriteTableDetails(ast);
            if (frame.Level == Machine.MaximumRoutineLevel)
            {
                _errorReporter.ReportRestriction("can't nest routines more than 7 deep");
            }
            else
            {
                argsSize = ast.Formals.Visit(this, frame.Push(0));
                valSize = ast.Expression.Visit(this, frame.Push(Machine.LinkDataSize));
            }
            _emitter.Emit(OpCode.RETURN, (byte)valSize, argsSize);
            _emitter.Patch(jumpAddr);
            return 0;
        }

        public int VisitProcDeclaration(ProcDeclaration ast, Frame frame)
        {
            var argsSize = 0;
            var jumpAddr = _emitter.Emit(OpCode.JUMP, Register.CB);
            ast.Entity = new KnownProcedure(Machine.ClosureSize, frame.Level, _emitter.NextInstrAddr);
            Encoder.WriteTableDetails(ast);
            if (frame.Level == Machine.MaximumRoutineLevel)
            {
                _errorReporter.ReportRestriction("can't nest routines so deeply");
            }
            else
            {
                argsSize = ast.Formals.Visit(this, frame.Push(0));
                ast.Command.Visit(this, frame.Push(Machine.LinkDataSize));
            }
            _emitter.Emit(OpCode.RETURN, argsSize);
            _emitter.Patch(jumpAddr);
            return 0;
        }

		// Formal Parameters

		public int VisitConstFormalParameter(ConstFormalParameter ast, Frame frame)
		{
			var valSize = ast.Type.Visit(this, null);
			ast.Entity = new UnknownValue(valSize, frame.Level, -frame.Size - valSize);
			Encoder.WriteTableDetails(ast);
			return valSize;
		}

		public int VisitFuncFormalParameter(FuncFormalParameter ast, Frame frame)
		{
			var argsSize = Machine.ClosureSize;
			ast.Entity = new UnknownProcedure(argsSize, frame.Level, -frame.Size - argsSize);
			Encoder.WriteTableDetails(ast);
			return argsSize;
		}

		public int VisitProcFormalParameter(ProcFormalParameter ast, Frame frame)
		{
			var argsSize = Machine.ClosureSize;
			ast.Entity = new UnknownProcedure(argsSize, frame.Level, -frame.Size - argsSize);
			Encoder.WriteTableDetails(ast);
			return argsSize;
		}

		public int VisitVarFormalParameter(VarFormalParameter ast, Frame frame)
		{
			ast.Type.Visit(this, null);
			var argSize = Machine.AddressSize;
			ast.Entity = new UnknownAddress(argSize, frame.Level, -frame.Size - argSize);
			Encoder.WriteTableDetails(ast);
			return Machine.AddressSize;
		}

		public int VisitEmptyFormalParameterSequence(EmptyFormalParameterSequence ast, Frame frame)
		{
			return 0;
		}

		public int VisitMultipleFormalParameterSequence(MultipleFormalParameterSequence ast,
			Frame frame)
		{
			var argsSize1 = ast.Formals.Visit(this, frame);
			var frame1 = frame.Expand(argsSize1);
			var argsSize2 = ast.Formal.Visit(this, frame1);
			return argsSize1 + argsSize2;
		}

		public int VisitSingleFormalParameterSequence(SingleFormalParameterSequence ast,
			Frame frame)
		{
			return ast.Formal.Visit(this, frame);
		}

	}
}