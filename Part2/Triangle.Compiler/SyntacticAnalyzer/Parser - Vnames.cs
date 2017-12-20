
/*
    for the vnames each time an object is 
    returned based on the AbstractSyntaxTree structure
    provided
*/


using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        // /////////////////////////////////////////////////////////////////////////////
        //
        // VALUE-OR-VARIABLE NAMES
        //
        // /////////////////////////////////////////////////////////////////////////////

        /**
         * Parses the v-name, and constructs an AST to represent its phrase structure.
         * 
         * @return a {@link triangle.compiler.syntax.trees.vnames.Vname}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        Vname ParseVname()
        {
            // parse the vname and return an appopriate object
            var identifier = ParseIdentifier();
            return ParseRestOfVname(identifier);
        }

        Vname ParseRestOfVname(Identifier identifier)
        {
            // parse the restofvname and return an appopriate object
            var startLocation = identifier.Start;
            Vname vname = new SimpleVname(identifier, identifier.Position);
            return vname;
        }

    }
}