using Triangle.Compiler.SyntaxTrees.Declarations;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        ///////////////////////////////////////////////////////////////////////////////
        //
        // DECLARATIONS
        //
        ///////////////////////////////////////////////////////////////////////////////

        /**
         * Parses the declaration, and constructs an AST to represent its phrase
         * structure.
         * 
         * @return a {@link triangle.compiler.syntax.trees.declarations.Declaration}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseDeclaration()
        {
            var startLocation = _currentToken.Start;
            ParseSingleDeclaration();
            while (_currentToken.Kind == TokenKind.Semicolon)
            {
                AcceptIt();
                ParseSingleDeclaration();
                var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);

            }

        }

        /**
         * Parses the single declaration, and constructs an AST to represent its
         * phrase structure.
         * 
         * @return a {@link triangle.compiler.syntax.trees.declarations.Declaration}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseSingleDeclaration()
        {
            var startLocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.Const:
                    {
                        AcceptIt();
                        ParseIdentifier();
                        Accept(TokenKind.Is);
                        ParseExpression();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        break;

                    }

                case TokenKind.Var:
                    {
                        AcceptIt();
                        ParseIdentifier();
                        Accept(TokenKind.Colon);
                        ParseTypeDenoter();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        break;
                    }


                case TokenKind.Type:
                    {
                        AcceptIt();
                        ParseIdentifier();
                        Accept(TokenKind.Is);
                        ParseTypeDenoter();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        break;
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start a declaration", _currentToken);
                        break;
                    }

            }

        }
    }
}