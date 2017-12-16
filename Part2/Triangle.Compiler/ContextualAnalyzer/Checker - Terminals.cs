using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Types;
using Triangle.Compiler.SyntaxTrees.Visitors;

namespace Triangle.Compiler.ContextualAnalyzer
{
    public partial class Checker : ILiteralVisitor<Void, TypeDenoter>,
            IIdentifierVisitor<Void, Declaration>,
            IOperatorVisitor<Void, Declaration>
    {
        // Literals, Identifiers and Operators

        public TypeDenoter VisitCharacterLiteral(CharacterLiteral literal, Void arg)
        {
            return StandardEnvironment.CharType;
        }

        public Declaration VisitIdentifier(Identifier identifier, Void arg)
        {
            
            return null;
        }

        public TypeDenoter VisitIntegerLiteral(IntegerLiteral literal, Void arg)
        {
            return StandardEnvironment.IntegerType;
        }

        public Declaration VisitOperator(Operator op, Void arg)
        {
            
            return null;
        }

    }
}