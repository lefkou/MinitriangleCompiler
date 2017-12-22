using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder : IDeclarationVisitor<Frame, int>
    {
        // Declarations
        public int VisitBinaryOperatorDeclaration(BinaryOperatorDeclaration ast, Frame frame)
        {
            return 0;
        }


        // visit the ConstDeclaration in the ast and manage the related
        // entity in the stack
        public int VisitConstDeclaration(ConstDeclaration ast, Frame frame)
        {
            var extraSize = 0;
            var expr = ast.Expression;
            if (expr.IsLiteral)
            {
                ast.Entity = new KnownValue(expr.Type.Size, expr.Value);
            }
            else
            {
                extraSize = expr.Visit(this, frame);
                ast.Entity = new UnknownValue(extraSize, frame);
            }
            Encoder.WriteTableDetails(ast);
            return extraSize;
        }


        // visit the SequentialDeclaration in the ast and manage the related
        // entity in the stack
        public int VisitSequentialDeclaration(SequentialDeclaration ast, Frame frame)
        {
            var extraSize1 = ast.FirstDeclaration.Visit(this, frame);
            var extraSize2 = ast.SecondDeclaration.Visit(this, frame.Expand(extraSize1));
            return extraSize1 + extraSize2;
        }


        // visit the TypeDeclaration in the ast and manage the related
        // entity in the stack
        public int VisitTypeDeclaration(TypeDeclaration ast, Frame frame)
        {
            // just to ensure the type's representation is decided
            ast.Type.Visit(this, null);
            return 0;
        }

        public int VisitUnaryOperatorDeclaration(UnaryOperatorDeclaration ast, Frame frame)
        {
            return 0;
        }

        public int VisitVarDeclaration(VarDeclaration ast, Frame frame)
        {
            var extraSize = ast.Type.Visit(this, null);
            _emitter.Emit(OpCode.PUSH, (short)extraSize);
            ast.Entity = new KnownAddress(Machine.AddressSize, frame);
            Encoder.WriteTableDetails(ast);
            return extraSize;
        }

    }
}