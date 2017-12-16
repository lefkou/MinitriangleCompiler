using System.Collections.Generic;
using Triangle.Compiler.SyntaxTrees;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {
        Scanner _scanner;

        ErrorReporter _errorReporter;

        Token _currentToken;

        Location _previousLocation;

        IEnumerator<Token> _tokens;

        public Parser(Scanner scanner, ErrorReporter errorReporter)
        {
            _scanner = scanner;
            _errorReporter = errorReporter;
            _previousLocation = Location.Empty;
            _tokens = _scanner.GetEnumerator();
        }

        /// <summary>
        /// Checks that the kind of the current token matches the expected kind, and
        /// fetches the next token from the source file, if not it throws a
        /// {@link SyntaxError}.
        /// </summary>
        /// <param name="expectedKind">
        /// the TokenKind expected
        /// </param>
        /// <returns>
        /// the current token
        /// </returns>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        Token Accept(TokenKind expectedKind)
        {
            if (_currentToken.Kind == expectedKind)
            {
                Token token = _currentToken;
                _previousLocation = token.Start;
                _tokens.MoveNext();
                _currentToken = _tokens.Current;
                return token;
            }

            RaiseSyntacticError("\"%\" expected here", expectedKind);
            return null;
        }

        /// <summary>
        /// Fetches the next token from the source file.
        /// </summary>
        void AcceptIt()
        {
            _previousLocation = _currentToken.Finish;
            _tokens.MoveNext();
            _currentToken = _tokens.Current;
        }

        /// <summary>
        /// Reports an error and then throws a {@link SyntaxError} exception. The error
        /// is reported by calling
        /// {@link Parser#reportError(String, String, SourcePosition)} using the given
        /// template and quoted token, and the current source position. A new
        /// {@link SyntaxError} exception is then thrown to end the parsing of the
        /// source program.
        /// </summary>
        /// <param name="messageTemplate">
        /// the message template
        /// </param>
        /// <param name="quotedToken">
        /// the quoted token
        /// </param>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void RaiseSyntacticError(string messageTemplate, string quotedToken)
        {
            var pos = _currentToken.Position;
            _errorReporter.ReportError(messageTemplate, quotedToken, pos);
            throw new SyntaxError();
        }

        /// <summary>
        /// Reports an error and then throws a {@link SyntaxError} exception. It calls
        /// {@link #raiseSyntacticError(String, String)} using the spelling of the
        /// given token or the empty string if the token is null.
        /// </summary>
        /// <param name="messageTemplate">
        /// the message template
        /// </param>
        /// <param name="token">
        /// the token
        /// </param>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void RaiseSyntacticError(string messageTemplate, Token token)
        {
            RaiseSyntacticError(messageTemplate, token == null ? string.Empty : token.Spelling);
        }

        /// <summary>
        /// Reports an error and then throws a {@link SyntaxError} exception. It calls
        /// {@link #RaiseSyntacticError(string, string)} using the spelling of the
        /// given token kind, or the empty string if the token kind is null.
        /// </summary>
        /// <param name="messageTemplate">
        /// the message template
        /// </param>
        /// <param name="kind">
        /// the token kind
        /// </param>
        /// <throws type="SyntaxError">
        /// a syntactic error
        /// </throws>
        void RaiseSyntacticError(string messageTemplate, TokenKind kind)
        {
            RaiseSyntacticError(messageTemplate, kind.ToString());
        }
    }
}