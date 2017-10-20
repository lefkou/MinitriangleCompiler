/**
 * @Author: John Isaacs <john>
 * @Date:   10-Oct-172017
 * @Filename: Parser - Common.cs
 * @Last modified by:   john
 * @Last modified time: 19-Oct-172017
 */



using System.Collections.Generic;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        Scanner _scanner;

        Token _currentToken;

        IEnumerator<Token> _tokens;

        public Parser(Scanner scanner)
        {
            _scanner = scanner;
            //_errorReporter = errorReporter;
            //_previousLocation = Location.Empty;
            _tokens = _scanner.GetEnumerator();
        }


        /// Checks that the kind of the current token matches the expected kind, and
        /// fetches the next token from the source file, if not it throws a
        void Accept(TokenKind expectedKind)
        {
            if (_currentToken.Kind == expectedKind)
            {
                Token token = _currentToken;
                //_previousLocation = token.Start;
                _tokens.MoveNext();
                _currentToken = _tokens.Current;
            }
        }


        // Just Fetches the next token from the source file.
        void AcceptIt()
        {
            //_previousLocation = _currentToken.Finish;
            _tokens.MoveNext();
            _currentToken = _tokens.Current;
        }

    }
}
