/**
 * @Author: Eleftherios Kousis <lef>
 * @Date:   5-Nov-2017
 * @Filename: Scanner.cs
 * @Last modified by:   lef
 * @Last modified time: 5-Nov-2017
 */


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

     
        // Appends the current character to the current token, and gets
        // the next character from the source program.

        void TakeIt()
        {
            _currentSpelling.Append((char)_source.Current);
            _source.MoveNext();
        }


        //Skip a single separator.
       
        void ScanSeparator()
        {
            switch(_source.Current) {
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

		//Build up tokens.
		TokenKind ScanToken()
        {
            
            // Operator
            if(IsOperator(_source.Current)){
                TakeIt();
                while (IsOperator(_source.Current))
                    TakeIt();
                return TokenKind.Operator;
            }
                
            // Int literal
            if(IsDigit(_source.Current)) {
                TakeIt();
                while (IsDigit(_source.Current)) 
                { 
                    TakeIt();
                }
                return TokenKind.IntLiteral;
            }
            // Identifier
            if(IsLetter(_source.Current)) {
                TakeIt();
                while (IsLetter(_source.Current) || IsDigit(_source.Current)) 
                {
                    TakeIt();
                }
                return TokenKind.Identifier;
            }
            
            switch(_source.Current) 
            {
                // Char literal
                case '\'':
                    TakeIt();
                    TakeIt(); // the quoted character
                    if (_source.Current == '\'') {
                        TakeIt();
                        return TokenKind.CharLiteral;
                    } else {
                        return TokenKind.Error;
                    }

                // Punctuation
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
                case '(':
                    TakeIt();
                    return TokenKind.LeftParen;
                case ')':
                    TakeIt();
                    return TokenKind.RightParen;
                case '.':
                    TakeIt();
                    return TokenKind.Dot;

                // Becomes
                case ':':
                    TakeIt();
                    if (_source.Current == '=') {
                        TakeIt();
                        return TokenKind.Becomes;
                    } else {
                        return TokenKind.Colon;
                    }

                // Is
                case '~':
                    TakeIt();
                    return TokenKind.Is;
                case ';':
                    TakeIt();
                    return TokenKind.Semicolon;
                case ',':
                    TakeIt(); 
                    return TokenKind.Comma;

                // End of text
                case -1 :
                    return TokenKind.EndOfText;
                // Error
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
            return (ch == '+' || ch == '-' || ch == '*' || ch == '/'  ||
                    ch == '=' || ch == '<' || ch == '>' || ch == '\\' ||
                    ch == '&' || ch == '@' || ch == '%' || ch == '^'  ||
                    ch == '?');
        }

    }
}