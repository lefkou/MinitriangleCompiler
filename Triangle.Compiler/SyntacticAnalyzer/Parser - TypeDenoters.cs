/*
    for the type denoters each time an object is 
    returned based on the AbstractSyntaxTree structure
    provided
*/



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
        TypeDenoter ParseTypeDenoter()
        {
            // parse the typedenoter and return an appopriate 
            // object
            var startLocation = _currentToken.Start;
            switch (_currentToken.Kind)
            {

                case TokenKind.Identifier:
                    {
                        var identifier = ParseIdentifier();
                        var typePosition = new SourcePosition(startLocation, _currentToken.Finish);
                        return new SimpleTypeDenoter(identifier, typePosition);
                    }

              
                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start a type denoter", _currentToken);
                        return null;
                    }

            }

        }

    }
}