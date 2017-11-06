/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Expressions.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */




namespace Triangle.Compiler.SyntacticAnalyzer
{
    // EXPRESSIONS. This class handles all expressions based on the guideline of the
    // language definition provided.
    public partial class Parser
    {
        void ParseExpression() {
          System.Console.WriteLine("parsing expression");
          switch (_currentToken.Kind) {
            case TokenKind.Let:
							AcceptIt();
              ParseDeclaration();
              Accept(TokenKind.In);
              ParseExpression();
              break;
            case TokenKind.If:
							AcceptIt();
              ParseExpression();
              Accept(TokenKind.Then);
              ParseExpression();
              Accept(TokenKind.Else);
              ParseExpression();
              break;
            default:
              ParseSecondaryExpression();
              break;
          }
        }
        
        void ParsePrimaryExpression() {
            System.Console.WriteLine("parsing primary expression");
						// System.Console.WriteLine(_currentToken);
            switch(_currentToken.Kind){
                case TokenKind.IntLiteral:
                  ParseIntLiteral();
                  break;
                case TokenKind.CharLiteral:
                  ParseCharLiteral();
                  break;
                case TokenKind.Identifier:
                  ParseIdentifier();
                  if (_currentToken.Kind == TokenKind.LeftParen) {
                    AcceptIt();
                    ParseActualParameterSequence();
                    Accept(TokenKind.RightParen);
                  }
                  break;
                case TokenKind.Operator:
                  ParseOperator();
                  ParsePrimaryExpression();
                  break;
                case TokenKind.LeftParen:
                  AcceptIt();
                  ParseExpression();
                  Accept(TokenKind.RightParen);
                  break;
                default:
                  System.Console.WriteLine("error");
                  Accept(TokenKind.Error);
                  break;
            }
        }

        void ParseSecondaryExpression() {
            System.Console.WriteLine("parsing secondary expression");
            ParsePrimaryExpression();
            if(_currentToken.Kind == TokenKind.Operator) 
            {
              ParseOperator();
              ParsePrimaryExpression();
            }
        }

        
    }
}
