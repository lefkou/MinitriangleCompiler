using Triangle.AbstractMachine;
using Triangle.Compiler.CodeGenerator.Entities;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.CodeGenerator
{
    public partial class Encoder : ITypeDenoterVisitor<Frame, int>
    // Type Denoters
    {
        public int VisitAnyTypeDenoter(AnyTypeDenoter ast, Frame frame)
        {
            return 0;
        }

        public int VisitBoolTypeDenoter(BoolTypeDenoter ast, Frame frame)
        {
            if (ast.Entity == null)
            {
                ast.Entity = new TypeRepresentation(Machine.BooleanSize);
                Encoder.WriteTableDetails(ast);
            }
            return Machine.BooleanSize;
        }

        public int VisitCharTypeDenoter(CharTypeDenoter ast, Frame frame)
        {
            if (ast.Entity == null)
            {
                ast.Entity = new TypeRepresentation(Machine.IntegerSize);
                Encoder.WriteTableDetails(ast);
            }
            return Machine.IntegerSize;
        }

        public int VisitErrorTypeDenoter(ErrorTypeDenoter ast, Frame frame)
        {
            return 0;
        }

        public int VisitSimpleTypeDenoter(SimpleTypeDenoter ast, Frame frame)
        {
            return 0;
        }

        public int VisitIntTypeDenoter(IntTypeDenoter ast, Frame frame)
        {
            if (ast.Entity == null)
            {
                ast.Entity = new TypeRepresentation(Machine.IntegerSize);
                Encoder.WriteTableDetails(ast);
            }
            return Machine.IntegerSize;
        }


    }
}