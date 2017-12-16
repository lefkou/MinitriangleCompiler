/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Parser - Common.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */



using System.Collections.Generic;

namespace Triangle.Compiler.SyntacticAnalyzer
{   

    // COMMON. Constructor of the Parser as well the Accept() and AcceptIt() methods 
    // that parse the tokens and handle the errors!

    public partial class Parser
    {
        Scanner _scanner;
        public ErrorReporter _errorReporter;
        Token _currentToken;
        // Location _previousLocation;
        IEnumerator<Token> _tokens;

        public Parser(Scanner scanner, ErrorReporter errorReporter)
        {
            _scanner = scanner;
            _errorReporter = errorReporter;
            // _previousLocation = Location.Empty;
            _tokens = _scanner.GetEnumerator();
        }


        // Checks that the kind of the current token matches the expected kind 
        // else outputs an error and fetches the next token from the source file
        void Accept(TokenKind expectedKind)
        {
            if (_currentToken.Kind == expectedKind)
            {
                Token token = _currentToken;
                // _previousLocation = token.Start;
                _tokens.MoveNext();
                _currentToken = _tokens.Current;
            }
            else {
                 _errorReporter.ReportError(expectedKind.ToString(), 
                                        _currentToken, _currentToken._position);
            }
        }


        // Just Fetches the next token from the source file.
        void AcceptIt()
        {
            // _previousLocation = _currentToken.Finish;
            _tokens.MoveNext();
            _currentToken = _tokens.Current;
        }

    
    }
}
