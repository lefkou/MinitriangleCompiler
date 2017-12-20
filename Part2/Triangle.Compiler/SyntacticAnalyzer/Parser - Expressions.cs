/*
    for the expressions each time an object is 
    returned based on the AbstractSyntaxTree structure
    provided
*/



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
        Expression ParseExpression()
        {   

            var startLocation = _currentToken.Start;

            switch (_currentToken.Kind)
            {

                case TokenKind.Let:
                    {
                        AcceptIt();
                        var declaration = ParseDeclaration();
                        Accept(TokenKind.In);
                        var expression = ParseExpression();
                        var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                        return new LetExpression(declaration, expression, expressionPos);
                    }

                case TokenKind.If:
                    {
                        AcceptIt();
                        var testExpression = ParseExpression();
                        Accept(TokenKind.Then);
                        var trueExpression = ParseExpression();
                        Accept(TokenKind.Else);
                        var falseExpression = ParseExpression();
                        var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                        return new IfExpression(testExpression, trueExpression, falseExpression, expressionPos);
                    }

                default:
                    {
                        return ParseSecondaryExpression();
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
        Expression ParseSecondaryExpression()
        {

            var startLocation = _currentToken.Start;
            var expression = ParsePrimaryExpression();
            while (_currentToken.Kind == TokenKind.Operator)
            {
                var expressionOperator = ParseOperator();
                var expression2 = ParsePrimaryExpression();
                var expressionPos = new SourcePosition(startLocation, _currentToken.Finish);
                expression = new BinaryExpression(expression, expressionOperator, expression2, expressionPos);
            }
            return expression;

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
        Expression ParsePrimaryExpression()
        {

            var startlocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.IntLiteral:
                    {
                        var intLit = ParseIntegerLiteral();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        return new IntegerExpression(intLit, expressionPos);
                    }

                case TokenKind.CharLiteral:
                    {
                        var charLit = ParseCharacterLiteral();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        return new CharacterExpression(charLit, expressionPos);
                    }


                case TokenKind.Identifier:
                    {
                        var identifier = ParseIdentifier();
                        if (_currentToken.Kind == TokenKind.LeftParen)
                        {
                            AcceptIt();
                            var actuals = ParseActualParameterSequence();
                            Accept(TokenKind.RightParen);
                            var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                            return new CallExpression(identifier, actuals, expressionPos);
                        }
                        else
                        {
                            var vname = ParseRestOfVname(identifier);
                            var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                            return new VnameExpression(vname, expressionPos);
                        }
                    }

                case TokenKind.Operator:
                    {
                        var expressionOperator = ParseOperator();
                        var primaryExpression = ParsePrimaryExpression();
                        var expressionPos = new SourcePosition(startlocation, _currentToken.Finish);
                        return new UnaryExpression(expressionOperator, primaryExpression, expressionPos);
                    }

                case TokenKind.LeftParen:
                    {
                        AcceptIt();
                        var expression = ParseExpression();
                        Accept(TokenKind.RightParen);
                        return expression;
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start an expression", _currentToken);
                        return null;
                    }
            }
        }

    }
}