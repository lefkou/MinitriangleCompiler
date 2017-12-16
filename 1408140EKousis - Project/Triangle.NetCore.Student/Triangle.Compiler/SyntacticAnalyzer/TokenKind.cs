namespace Triangle.Compiler.SyntacticAnalyzer
{
    public enum TokenKind
    {
        // literals, identifiers, operators...
        IntLiteral, CharLiteral, Identifier, Operator,

        // reserved words - must be in alphabetical order...
        Array, Begin, Const, Do, Else, End, Func, If, In,
        Let, Of, Proc, Record, Then, Type, Var, While,

        // punctuation...
        Dot, Colon, Semicolon, Comma, Becomes, Is,

        // brackets...
        LeftParen, RightParen, LeftBracket, RightBracket,
        LeftCurly, RightCurly,

        // special tokens...
        EndOfText, Error
    }
}