using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder : IExpressionVisitor<Frame, int>
    {



		public int VisitCharacterExpression(CharacterExpression ast, Frame frame)
		{
			var valSize = ast.Type.Visit(this, null);
			_emitter.Emit(OpCode.LOADL, (short)ast.CharacterLiteral.Value);
			return valSize;
		}

		public int VisitIntegerExpression(IntegerExpression ast, Frame frame)
		{
			var valSize = ast.Type.Visit(this, null);
			_emitter.Emit(OpCode.LOADL, (short)ast.IntegerLiteral.Value);
			return valSize;
		}


        public int VisitBinaryExpression(BinaryExpression ast, Frame frame)
        {
            var valSize = ast.Type.Visit(this, null);
            var valSize1 = ast.LeftExpression.Visit(this, frame);
            var frame1 = frame.Expand(valSize1);
            var valSize2 = ast.RightExpression.Visit(this, frame1);
            var frame2 = frame1.Replace(valSize1 + valSize2);
            ast.Operator.Visit(this, frame2);
            return valSize;
        }

        public int VisitCallExpression(CallExpression ast, Frame frame)
        {
            var valSize = ast.Type.Visit(this, null);
            var argsSize = ast.Actuals.Visit(this, frame);
            ast.Identifier.Visit(this, frame.Replace(argsSize));
            return valSize;
        }

		public int VisitEmptyExpression(EmptyExpression ast, Frame frame)
        {
            return 0;
        }

        public int VisitIfExpression(IfExpression ast, Frame frame)
        {
            ast.Type.Visit(this, null);
            ast.TestExpression.Visit(this, frame);
            var jumpifAddr = _emitter.Emit(OpCode.JUMPIF, Machine.FalseValue, Register.CB);
            var valSize = ast.TrueExpression.Visit(this, frame);
            var jumpAddr = _emitter.Emit(OpCode.JUMP, Register.CB);
            _emitter.Patch(jumpifAddr);
            ast.FalseExpression.Visit(this, frame);
            _emitter.Patch(jumpAddr);
            return valSize;
        }


        public int VisitLetExpression(LetExpression ast, Frame frame)
        {
            ast.Type.Visit(this, null);
            var extraSize = ast.Declaration.Visit(this, frame);
            var valSize = ast.Expression.Visit(this, frame.Expand(extraSize));
            if (extraSize > 0)
            {
                _emitter.Emit(OpCode.POP, valSize, extraSize);
            }
            return valSize;
        }

       

        public int VisitUnaryExpression(UnaryExpression ast, Frame frame)
        {
            var valSize = ast.Type.Visit(this, null);
            ast.Expression.Visit(this, frame);
            ast.Operator.Visit(this, frame.Replace(valSize));
            return valSize;
        }

        public int VisitVnameExpression(VnameExpression ast, Frame frame)
        {
            var valSize = ast.Type.Visit(this, null);
            EncodeFetch(ast.Vname, frame, valSize);
            return valSize;
        }

    }
}