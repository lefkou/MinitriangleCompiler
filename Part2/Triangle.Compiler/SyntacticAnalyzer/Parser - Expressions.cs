
using Triangle.Compiler.SyntaxTrees.Expressions;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        ///////////////////////////////////////////////////////////////////////////////
        //
        // EXPRESSIONS
        //
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Parses the expression, and constructs an AST to represent its phrase
        /// structure.
        /// </summary>
        /// <returns>
        /// an <link>Triangle.SyntaxTrees.Expressions.Expression</link>
        /// </returns> 
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void ParseExpression()
        {

            var startLocation = _currentToken.Start;

            switch (_currentToken.Kind)
            {

                case TokenKind.Let:
                    {
                        AcceptIt();
                        ParseDeclaration();
                        Accept(TokenKind.In);
                        ParseExpression();
                        var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                        break;
                    }

                case TokenKind.If:
                    {
                        AcceptIt();
                        ParseExpression();
                        Accept(TokenKind.Then);
                        ParseExpression();
                        Accept(TokenKind.Else);
                        ParseExpression();
                        var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                        break;
                    }

                default:
                    {
                        ParseSecondaryExpression();
                        break;
                    }
            }
        }

        /// <summary>
        // Parses the secondary expression, and constructs an AST to represent its
        /// phrase structure.
        /// </summary>
        /// <returns>
        /// an <link>Triangle.SyntaxTrees.Expressions.Expression</link>
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void ParseSecondaryExpression()
        {

            var startLocation = _currentToken.Start;
            ParsePrimaryExpression();
            while (_currentToken.Kind == TokenKind.Operator)
            {
                ParseOperator();
                ParsePrimaryExpression();
                var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                break;
            }

        }

        /// <summary>
        /// Parses the primary expression, and constructs an AST to represent its
        /// phrase structure.
        /// </summary>
        /// <returns>
        /// an <link>Triangle.SyntaxTrees.Expressions.Expression</link>
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void ParsePrimaryExpression()
        {

            var startlocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.IntLiteral:
                    {
                        ParseIntegerLiteral();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        break;
                    }

                case TokenKind.CharLiteral:
                    {
                        ParseCharacterLiteral();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        break;
                    }


                case TokenKind.Identifier:
                    {
                        ParseIdentifier();
                        if (_currentToken.Kind == TokenKind.LeftParen)
                        {
                            AcceptIt();
                            ParseActualParameterSequence();
                            Accept(TokenKind.RightParen);
                            var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                            break;
                        }
                        else
                        {
                            //ParseRestOfVname(identifier);
                            var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                            break;
                        }
                    }

                case TokenKind.Operator:
                    {
                        ParseOperator();
                        ParsePrimaryExpression();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        break;
                    }

                case TokenKind.LeftParen:
                    {
                        AcceptIt();
                        ParseExpression();
                        Accept(TokenKind.RightParen);
                        break;
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start an expression", _currentToken);
                        break;
                    }
            }
        }

    }
}