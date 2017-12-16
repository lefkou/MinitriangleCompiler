using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        // /////////////////////////////////////////////////////////////////////////////
        //
        // TYPE-DENOTERS
        //
        // /////////////////////////////////////////////////////////////////////////////

        /**
         * Parses the type denoter, and constructs an AST to represent its phrase
         * structure.
         * 
         * @return a {@link triangle.compiler.syntax.trees.types.TypeDenoter}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        void ParseTypeDenoter()
        {

            var startLocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.Identifier:
                    {
                        ParseIdentifier();
                        var typePosition = new SourcePosition(startLocation, _currentToken.Finish);
                        break;
                    }

              
                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start a type denoter", _currentToken);
                        break;
                    }

            }

        }

    }
}