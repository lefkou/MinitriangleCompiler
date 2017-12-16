using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        ///////////////////////////////////////////////////////////////////////////////
        //
        // TERMINALS
        //
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Parses an integer-literal, and constructs a leaf AST to represent it.
        /// </summary>
        /// <returns>
        /// an <link>Triangle.SyntaxTrees.Terminals.IntegerLiteral</link>
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void ParseIntegerLiteral()
        {
            Token token = Accept(TokenKind.IntLiteral);

        }

        /**
         * Parses a character-literal, and constructs a leaf AST to represent it.
         * 
         * @return a {@link triangle.compiler.syntax.trees.terminals.CharacterLiteral}
         * 
         * @throws SyntaxError
         *           a syntactic error
         */
        void ParseCharacterLiteral()
        {
            Token token = Accept(TokenKind.CharLiteral);

        }

        /**
         * Parses an identifier, and constructs a leaf AST to represent it.
         * 
         * @return an {@link triangle.compiler.syntax.trees.terminals.Identifier}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseIdentifier()
        {
            Token token = Accept(TokenKind.Identifier);

        }

        /**
         * Parses an operator, and constructs a leaf AST to represent it.
         *
         * @return an {@link triangle.compiler.syntax.trees.terminals.Operator}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        Operator ParseOperator()
        {
            Token token = Accept(TokenKind.Operator);
            return new Operator(token);
        }
    }
}