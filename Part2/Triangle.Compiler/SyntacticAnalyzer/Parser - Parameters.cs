using Triangle.Compiler.SyntaxTrees.Actuals;


namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        ///////////////////////////////////////////////////////////////////////////////
        //
        // PARAMETERS
        //
        ///////////////////////////////////////////////////////////////////////////////

       

       

        /**
         * Parses the actual parameter sequence, and constructs an AST to represent
         * its phrase structure.
         * 
         * @return an
         *         {@link triangle.compiler.syntax.trees.actuals.ActualParameterSequence}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void  ParseActualParameterSequence()
        {

            var startLocation = _currentToken.Position.Start;
            if (_currentToken.Kind == TokenKind.RightParen)
            {
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);

            }
          
        }

        /**
         * Parses the proper (non-empty) actual parameter sequence, and constructs an
         * AST to represent its phrase structure.
         * 
         * @return an
         *         {@link triangle.compiler.syntax.trees.actuals.ActualParameterSequence}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseProperActualParameterSequence()
        {

            var startLocation = _currentToken.Position.Start;
            ParseActualParameter();
            if (_currentToken.Kind == TokenKind.Comma)
            {
                AcceptIt();
                ParseProperActualParameterSequence();
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);

            }
            else
            {
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);

            }
           
        }

        /**
         * Parses the actual parameter, and constructs an AST to represent its phrase
         * structure.
         * 
         * @return an {@link triangle.compiler.syntax.trees.actuals.ActualParameter}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseActualParameter()
        {

            var startLocation = _currentToken.Position.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.Identifier:
                case TokenKind.IntLiteral:
                case TokenKind.CharLiteral:
                case TokenKind.Operator:
                case TokenKind.Let:
                case TokenKind.If:
                case TokenKind.LeftParen:
                case TokenKind.LeftBracket:
                case TokenKind.LeftCurly:
                    {
                        ParseExpression();
                        var actualPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                        break;
                    }

                case TokenKind.Var:
                    {
                        AcceptIt();
                        ParseVname();
                        var actualPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                        break;
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start an actual parameter", _currentToken);
                        break;
                    }

            }

        }
    }
}