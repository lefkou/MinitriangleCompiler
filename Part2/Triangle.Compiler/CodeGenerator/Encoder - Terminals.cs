using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder :
            ILiteralVisitor<Frame, Void>,
            IIdentifierVisitor<Frame, Void>,
            IOperatorVisitor<Frame, Void>
    {
        // Literals, Identifiers and Operators

        public Void VisitCharacterLiteral(CharacterLiteral ast, Frame frame)
        {
            return null;
        }

		public Void VisitIntegerLiteral(IntegerLiteral ast, Frame frame)
		{
			return null;
		}

        public Void VisitIdentifier(Identifier ast, Frame frame)
        {
            var routine = ast.Declaration.Entity as IProcedureEntity;
            routine.EncodeCall(_emitter, frame);
            return null;
        }



        public Void VisitOperator(Operator ast, Frame frame)
        {
            var routine = ast.Declaration.Entity as IProcedureEntity;
            routine.EncodeCall(_emitter, frame);
            return null;
        }

    }
}