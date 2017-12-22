using Triangle.Compiler.SyntaxTrees;
using Triangle.Compiler.SyntaxTrees.Commands;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        ///////////////////////////////////////////////////////////////////////////////
        //
        // PROGRAMS
        //
        ///////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Parses a Triangle program, and constructs an AST to represent it.
        /// </summary>
        /// <returns>
        /// a {@link triangle.compiler.syntax.trees.Program} or null if there
        /// is a syntactic error
        /// </returns>
        public Program ParseProgram()
        {

            try
            {
                _tokens.MoveNext();
                _currentToken = _tokens.Current;
                var startLocation = _currentToken.Start;
                var command = ParseCommand();
                var pos = new SourcePosition(startLocation, _currentToken.Finish);
                var program = new Program(command, pos);
                if (_currentToken.Kind != TokenKind.EndOfText)
                {
                    RaiseSyntacticError("\"%\" not expected after end of program", _currentToken);
                }
                return program;

            }
            catch (SyntaxError)
            {
                return null;
            }
        }
    }
}