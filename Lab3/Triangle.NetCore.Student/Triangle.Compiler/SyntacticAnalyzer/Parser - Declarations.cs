/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Declarations.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{

    // DECLARATIONS. THis class handles all the declarations and is based on the 
    // language definition provided. Error handling is done in the Common subclass 
    // in the Accept() and AcceptIt() methods.
    public partial class Parser
    {
        // parse declaration
        void ParseDeclaration() {
            System.Console.WriteLine("parsing declaration");
            ParseSingleDeclaration();
            while(_currentToken.Kind == TokenKind.Semicolon) {
                AcceptIt();
                ParseSingleDeclaration();
            }
        }
        
        // parsing single declaration
        void ParseSingleDeclaration() {
            System.Console.WriteLine("parsing single declaration");
            switch(_currentToken.Kind){
                case TokenKind.Const:
                    AcceptIt();
                    ParseIdentifier();
                    if (_currentToken.Kind == TokenKind.Is) { 
                        Accept(TokenKind.Is);
                        ParseExpression();
                    }
                    // System.Console.WriteLine(_currentToken);
                    break;
                case TokenKind.Var:
                    AcceptIt();
                    ParseIdentifier();
                    if (_currentToken.Kind == TokenKind.Colon) {
                        AcceptIt();
                        ParseTypeDenoter();
                    }
                    break;
                default:
                    System.Console.WriteLine("error");
                    // System.Console.WriteLine(_currentToken);
                    Accept(TokenKind.Error);
                    break;
            }
            
        }

        
    }
}