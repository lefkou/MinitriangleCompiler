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
        Declaration ParseDeclaration()
        {
            var startLocation = _currentToken.Start;
            var declaration = ParseSingleDeclaration();
            while (_currentToken.Kind == TokenKind.Semicolon)
            {
                AcceptIt();
                var declaration2 = ParseSingleDeclaration();
                var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                declaration = new SequentialDeclaration(declaration, declaration2, declarationPosition);
            }
            return declaration;
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
        Declaration ParseSingleDeclaration()
        {
            var startLocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.Const:
                    {
                        AcceptIt();
                        var identifier = ParseIdentifier();
                        Accept(TokenKind.Is);
                        var expression = ParseExpression();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new ConstDeclaration(identifier, expression, declarationPosition);
                    }

                case TokenKind.Var:
                    {
                        AcceptIt();
                        var identifier = ParseIdentifier();
                        Accept(TokenKind.Colon);
                        var type = ParseTypeDenoter();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new VarDeclaration(identifier, type, declarationPosition);
                    }


                case TokenKind.Type:
                    {
                        AcceptIt();
                        var identifier = ParseIdentifier();
                        Accept(TokenKind.Is);
                        var type = ParseTypeDenoter();
                        var declarationPosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new TypeDeclaration(identifier, type, declarationPosition);
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start a declaration", _currentToken);
                        return null;
                    }

            }

        }
    }
}