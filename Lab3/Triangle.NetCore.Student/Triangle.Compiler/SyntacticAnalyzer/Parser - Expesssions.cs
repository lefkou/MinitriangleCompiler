namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        void ParseExpression() {
          ParsePrimaryExpression();
          while(_currentToken.Kind == TokenKind.Operator) {
            ParsePrimaryExpression();
          }

        }

        void ParsePrimaryExpression() {

            switch(_currentToken.Kind){
              case TokenKind.IntLiteral:
                ParseIntLiteral();
                break;
              case TokenKind.Identifier:
                ParseIdentifier();
                break;
              case TokenKind.Operator:
                ParseOperator();
                ParsePrimaryExpression();
                break;
              case TokenKind.LeftParen:
                AcceptIt();
                ParseExpression();
                break;
              case TokenKind.RightParen:
                AcceptIt();
                break;
              default:
                System.Console.WriteLine("error");
                Accept(TokenKind.Error);
                break;
        }

        
    }
    }
}