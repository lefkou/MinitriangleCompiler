using Triangle.Compiler.SyntacticAnalyzer;
using Triangle.Compiler.SyntaxTrees.Declarations;
using Triangle.Compiler.SyntaxTrees.Types;

namespace Triangle.Compiler.SyntaxTrees.Terminals
{
    public class Identifier : Terminal
    {
        public static readonly Identifier Empty = new Identifier(string.Empty, SourcePosition.Empty);

        public Identifier(string spelling, SourcePosition position)
            : base(spelling, position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public Identifier(Token token) : this(token.Spelling, token.Position)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public Identifier(string spelling)
            : this(spelling, SourcePosition.Empty)
        {
            if (Compiler.debug) { System.Console.WriteLine(this.GetType().Name); }
        }

        public TypeDenoter Type { get; set; }

        public Declaration Declaration { get; set; }


    }
}