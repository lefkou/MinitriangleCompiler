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

                //var startLocation = _source.Location;
                var kind = ScanToken();
                //var endLocation = _source.Location;
                //var position = new SourcePosition(startLocation, endLocation);

                var token = new Token(kind, _currentSpelling.ToString());
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
        //the next character from the source program.

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
            TokenKind value;

            // create a map that holds character - tokenKind mappings
            var map = new Dictionary<int, TokenKind>();
            var resWordsMap = new Dictionary<string, TokenKind>();
            // for end of text
            map[-1]  = TokenKind.EndOfText;

            // for brackets
            map['['] = TokenKind.LeftBracket;
            map[']'] = TokenKind.RightBracket;
            map['{'] = TokenKind.LeftCurly;
            map['}'] = TokenKind.RightCurly;
            map['('] = TokenKind.LeftParen;
            map[')'] = TokenKind.RightParen;
            // for punctuation
            map['.'] = TokenKind.Dot;
            map[':'] = TokenKind.Colon;
            map[';'] = TokenKind.Semicolon;
            map[','] = TokenKind.Comma;
            // // for reserved words
            // resWordsMap["array"] = TokenKind.Array;
            // resWordsMap["begin"] = TokenKind.Begin;
            // resWordsMap["const"] = TokenKind.Const;
            // resWordsMap["do"]    = TokenKind.Do;
            // resWordsMap["else"]  = TokenKind.Else;
            // resWordsMap["end"]   = TokenKind.End;
            // resWordsMap["func"]  = TokenKind.Func;
            // resWordsMap["if"]    = TokenKind.If;
            // resWordsMap["in"]    = TokenKind.In;
            // resWordsMap["let"]   = TokenKind.Let;
            // resWordsMap["of"]    = TokenKind.Of;
            // resWordsMap["proc"]  = TokenKind.Proc;
            // resWordsMap["record"]= TokenKind.Record;
            // resWordsMap["then"]  = TokenKind.Then;
            // resWordsMap["type"]  = TokenKind.Type;
            // resWordsMap["var"]   = TokenKind.Var;
            // resWordsMap["while"] = TokenKind.While;

            // number
            if(IsDigit(_source.Current)) {
                TakeIt();
                while (IsDigit(_source.Current)) {
                    TakeIt();
                }
                return TokenKind.IntLiteral;
            }
            
            // operator
            if(IsOperator(_source.Current)) {
                TakeIt();
                return TokenKind.Operator;
            }

            // letter
            if(IsLetter(_source.Current)) {
                // string tempString = "";
                // while(IsLetter(_source.Current)) {
                //     tempString = tempString + _source.Current;
                // }
                // if (resWordsMap.TryGetValue(tempString, out value)) {
                //     TakeIt();
                // }
                // if(tempString == 'in') {
                //         Console.WriteLine("TempString" + tempString);
                // }
                TakeIt();
                return TokenKind.CharLiteral;
            }

            // return value from map 
            if (map.TryGetValue(_source.Current, out value)) {
                if (_source.Current != -1) {
                    TakeIt();
                }
                return value;
            }

            TakeIt();
            return TokenKind.Error;
            
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


        bool IsBracket(int ch) 
        {
            switch(ch)
            {
                case '[':
                case ']':
                case '{':
                case '}':
                case '(':
                case ')':
                    return true;
                default:
                    return false;

            }

        }
    }
}