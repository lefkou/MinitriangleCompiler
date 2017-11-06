/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Commands.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        // COMMANDS. All the following code is based on the language definition provided.
        //  Errors are handled inside the Accept() and AcceptIt() methods of Parser - Common.cs

        // Parses the command
        void ParseCommand()
        {
            System.Console.WriteLine("parsing command");
            ParseSingleCommand();
            while (_currentToken.Kind == TokenKind.Semicolon)
            {
                AcceptIt();
                ParseSingleCommand();
            }
        }


        // Parses the single command
        void ParseSingleCommand()
        {
            System.Console.WriteLine("parsing single command");
            switch (_currentToken.Kind)
            {
                case TokenKind.Identifier:
                    ParseVname();
                    if (_currentToken.Kind == TokenKind.LeftParen) {
                        AcceptIt();
                        ParseActualParameterSequence();
                        Accept(TokenKind.RightParen);
                    }
                    else {
                        Accept(TokenKind.Becomes);
                        ParseExpression(); 
                    } 
                    break;
                case TokenKind.If:
                    AcceptIt();
                    ParseExpression();
                    Accept(TokenKind.Then);
                    ParseSingleCommand();
                    Accept(TokenKind.Else);
                    ParseSingleCommand();
                    break;
                case TokenKind.While:
                    AcceptIt();
                    ParseExpression();
                    Accept(TokenKind.Do);
                    ParseSingleCommand();
                    break;
                case TokenKind.Let:
                    AcceptIt();
                    ParseDeclaration();
                    Accept(TokenKind.In);
                    ParseSingleCommand();
                    break;
                case TokenKind.Begin:
                    AcceptIt();
                    ParseCommand();
                    Accept(TokenKind.End);
                    break;
                default:
                    // Accept(TokenKind.Error);
                    break;
            }
        }
    }
}
