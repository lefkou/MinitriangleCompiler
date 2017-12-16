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
            var identifier = ParseIdentifier();
            return ParseRestOfVname(identifier);
            // return new SimpleVname(identifier);
        }

        Vname ParseRestOfVname(Identifier identifier)
        {
            var startLocation = identifier.Start;
            Vname vname = new SimpleVname(identifier, identifier.Position);
            return vname;
        }

    }
}