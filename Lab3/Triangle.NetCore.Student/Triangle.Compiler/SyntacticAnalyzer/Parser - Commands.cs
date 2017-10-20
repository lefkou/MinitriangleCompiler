/**
 * @Author: John Isaacs <john>
 * @Date:   10-Oct-172017
 * @Filename: Parser - Commands.cs
 * @Last modified by:   john
 * @Last modified time: 19-Oct-172017
 */



namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        ///////////////////////////////////////////////////////////////////////////////
        //
        // COMMANDS
        //
        ///////////////////////////////////////////////////////////////////////////////


        /// Parses the command error
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


        /// Parses the single command

        void ParseSingleCommand()
        {
          System.Console.WriteLine("parsing single command");
            switch (_currentToken.Kind)
            {

                case TokenKind.Identifier:
                    {
                        ParseIdentifier();
                        Accept(TokenKind.Becomes);
                        ParseExpression();
                        break;

                    }

                case TokenKind.Begin:
                    {
                        AcceptIt();
                        ParseExpression();
                        break;
                    }
                case TokenKind.End:
                    {
                        AcceptIt();
                        break;
                    }

                case TokenKind.If:
                    {
                        AcceptIt();
                        ParseExpression();
                        break;
                    }
                case TokenKind.Else:
                    {
                        AcceptIt();
                        ParseSingleCommand();
                        break;
                    }
                case TokenKind.While:
                    {
                        AcceptIt();
                        ParseExpression();
                        break;
                    }
                case TokenKind.Let:
                    {
                        AcceptIt();
                        ParseDeclaration();
                        break;
                    }
                case TokenKind.In:
                    {
                        AcceptIt();
                        ParseDeclaration();
                        break;
                    }
                case TokenKind.Do:
                    {
                        AcceptIt();
                        ParseSingleCommand();
                        break;
                    }
                case TokenKind.Then:
                    {
                        AcceptIt();
                        ParseSingleCommand();
                        break;
                    }
                default:
                    System.Console.WriteLine("error");
                    break;

            }
        }
    }
}
