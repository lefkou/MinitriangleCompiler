using System;
using System.Collections.Generic;
using System.Linq;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public class Token
    {

        /// <summary>
        /// Lookup table of reserved words used to screen tokens.
        /// </summary>
        static readonly IDictionary<string, TokenKind> ReservedWords =
                Enumerable.Range((int)TokenKind.Array, (int)TokenKind.While).Cast<TokenKind>()
                    .ToDictionary(kind => kind.ToString().ToLower(), kind => kind);

        /// <summary>
        /// The kind of a source token.
        /// </summary>
        public TokenKind Kind { get; private set; }

        /// <summary>
        /// The spelling of a source token.
        /// </summary>
        public string Spelling { get; private set; }

        /// <summary>
        /// The position of a source token in the source file.
        /// </summary>
        public SourcePosition Position { get; private set; }

        public Location Start { get { return Position.Start; } }

        public Location Finish { get { return Position.Finish; } }

        /// <summary>
        /// Creates a token with the given kind, spelling and source position. If the
        /// given token kind is an identifier, the spelling is checked for a reserved
        /// word. If it is a reserved word, the kind of the created token is that of
        /// the reserved word.
        /// </summary>
        /// <param name="kind">
        /// the token kind
        /// </param>
        /// <param name="spelling">
        /// the token spelling
        /// </param>
        /// <param  name="position">
        /// the token source position
        /// </param>
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

            Spelling = spelling;
            Position = position;
        }

        public override string ToString()
        {
            return string.Format("Kind={0}, spelling=\"{1}\", position={2}", Kind, Spelling, Position);
        }
    }
}