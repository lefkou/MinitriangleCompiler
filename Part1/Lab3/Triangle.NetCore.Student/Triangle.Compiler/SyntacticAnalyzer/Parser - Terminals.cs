/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Terminals.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */



namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        // TERMINALS contain all the parse methods for TERMINALS.
        /**
         * Parses an identifier, and constructs a leaf AST to represent it.
         */
        void ParseIdentifier()
        {
            System.Console.WriteLine("parsing identifier");
            Accept(TokenKind.Identifier);
        }

       /**
         * Parses an operator, and constructs a leaf AST to represent it.
         */
        void ParseOperator() 
        {
            System.Console.WriteLine("parsing operator");
            Accept(TokenKind.Operator);
        }
        /**
         * Parses an int literal, and constructs a leaf AST to represent it.
         */
        void ParseIntLiteral()
        {
            Accept(TokenKind.IntLiteral);
            System.Console.WriteLine("parsing integer");  
        }
        /**
         * Parses an char literal, and constructs a leaf AST to represent it.
         */
        void ParseCharLiteral()
        {
            Accept(TokenKind.CharLiteral);
            System.Console.WriteLine("parsing character");
            
        }
    }
}
