using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public class Token
    {
        // Lookup table of reserved words used to screen tokens.
        static readonly IDictionary<string, TokenKind> ReservedWords =
                Enumerable.Range((int)TokenKind.Array, (int)TokenKind.While).Cast<TokenKind>()
                    .ToDictionary(kind => kind.ToString().ToLower(), kind => kind);

   
        //The kind of a source token.
        public TokenKind Kind { get; private set; }

        //The spelling of a source token.
        public string Spelling { get; private set; }

        public SourcePosition _position;

        // Creates a token
        public Token(TokenKind kind, string spelling, SourcePosition position)
        {

            Kind = kind;
            if (kind == TokenKind.Identifier)
            {
                TokenKind match;
                if (ReservedWords.TryGetValue(spelling, out match))
                {
                    Kind = match;
                }
            }
            _position = position;
            Spelling = spelling;
        }

        public override string ToString()
        {
            string output = string.Format("Kind={0}, spelling=\"{1}\"", Kind, Spelling);
            // if (Kind == TokenKind.Error){
                output += string.Format(", Position = {0}", _position);
            // }
            return output;
        }
    }
}