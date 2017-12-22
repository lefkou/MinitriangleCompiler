using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public class Scanner : IEnumerable<Token>
    {
        SourceFile _source;

        StringBuilder _currentSpelling;

        bool _debug;

        public Scanner(SourceFile source)
        {
            _source = source;
            _source.Reset();
            _currentSpelling = new StringBuilder();
        }

        public Scanner EnableDebugging()
        {
            _debug = true;
            return this;
        }
        public IEnumerator<Token> GetEnumerator()
        {
            while (true)
            {
                while (_source.Current == '!' || _source.Current == ' ' || _source.Current == '\t' || _source.Current == '\n')
                {
                    ScanSeparator();
                }

                _currentSpelling.Clear();

                var startLocation = _source.Location;
                var kind = ScanToken();
                var endLocation = _source.Location;
                var position = new SourcePosition(startLocation, endLocation);

                var token = new Token(kind, _currentSpelling.ToString(), position);
                if (_debug)
                {
                    Console.WriteLine(token);
                }

                yield return token;
                if (token.Kind == TokenKind.EndOfText) { break; }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Appends the current character to the current token, and gets
        /// the next character from the source program.
        /// </summary>
        void TakeIt()
        {
            _currentSpelling.Append((char)_source.Current);
            _source.MoveNext();
        }

        /// <summary>
        /// Skip a single separator.
        /// </summary>
        void ScanSeparator()
        {
            switch (_source.Current)
            {
                case '!':
                    _source.SkipRestOfLine();
                    _source.MoveNext();
                    break;

                case ' ':
                case '\n':
                case '\r':
                case '\t':
                    _source.MoveNext();
                    break;
            }
        }

        TokenKind ScanToken()
        {

            switch (_source.Current)
            {

                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    TakeIt();
                    while (IsLetter(_source.Current) || IsDigit(_source.Current))
                    {
                        TakeIt();
                    }
                    return TokenKind.Identifier;

                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    TakeIt();
                    while (IsDigit(_source.Current))
                    {
                        TakeIt();
                    }
                    return TokenKind.IntLiteral;

                case '+':
                case '-':
                case '*':
                case '/':
                case '=':
                case '<':
                case '>':
                case '\\':
                case '&':
                case '@':
                case '%':
                case '^':
                case '?':
                    TakeIt();
                    while (IsOperator(_source.Current))
                    {
                        TakeIt();
                    }
                    return TokenKind.Operator;

                case '\'':
                    TakeIt();
                    TakeIt(); // the quoted character
                    if (_source.Current == '\'')
                    {
                        TakeIt();
                        return TokenKind.CharLiteral;
                    }
                    return TokenKind.Error;

                case '.':
                    TakeIt();
                    return TokenKind.Dot;

                case ':':
                    TakeIt();
                    if (_source.Current == '=')
                    {
                        TakeIt();
                        return TokenKind.Becomes;
                    }
                    return TokenKind.Colon;

                case ';':
                    TakeIt();
                    return TokenKind.Semicolon;

                case ',':
                    TakeIt();
                    return TokenKind.Comma;

                case '~':
                    TakeIt();
                    return TokenKind.Is;

                case '(':
                    TakeIt();
                    return TokenKind.LeftParen;

                case ')':
                    TakeIt();
                    return TokenKind.RightParen;

                case '[':
                    TakeIt();
                    return TokenKind.LeftBracket;

                case ']':
                    TakeIt();
                    return TokenKind.RightBracket;

                case '{':
                    TakeIt();
                    return TokenKind.LeftCurly;

                case '}':
                    TakeIt();
                    return TokenKind.RightCurly;

                case -1:
                    return TokenKind.EndOfText;

                default:
                    TakeIt();
                    return TokenKind.Error;
            }
        }

        bool IsLetter(int ch)
        {
            return ('a' <= ch && ch <= 'z') || ('A' <= ch && ch <= 'Z');
        }

        bool IsDigit(int ch)
        {
            return '0' <= ch && ch <= '9';
        }

        bool IsOperator(int ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                case '=':
                case '<':
                case '>':
                case '\\':
                case '&':
                case '@':
                case '%':
                case '^':
                case '?':
                    return true;

                default:
                    return false;
            }
        }
    }
}